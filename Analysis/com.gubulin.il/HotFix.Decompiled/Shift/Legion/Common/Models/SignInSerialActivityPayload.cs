using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using GameDataEditor;
using Shift.Legion.Common.Managers;
using Shift.Legion.Helpers;

namespace Shift.Legion.Common.Models;

public class SignInSerialActivityPayload : ActivityContentPayload
{
	public readonly string PageName;

	public readonly List<SignInBonusData> SignInList;

	public SignInSerialActivityPayload(int payloadIndex, string pageName, Dictionary<string, object> data, Activity activity)
		: base(data)
	{
		if (!data.TryGetValue("SignInSerial", out var value))
		{
			return;
		}
		ContentIndex = payloadIndex;
		PageName = pageName;
		Activity = activity;
		SignInList = new List<SignInBonusData>();
		foreach (GDESignInSerialData allItem in GDMgr.GetAllItems<GDESignInSerialData>())
		{
			if (!(allItem.SerialId != value.ToString()))
			{
				SignInList.Add(new SignInBonusData(allItem));
			}
		}
		SignInList.Sort((SignInBonusData a, SignInBonusData b) => a.Target.CompareTo(b.Target));
	}

	public bool CanSignIn(GameManagers managers)
	{
		List<string> list;
		if (!Activity.ActivityProgress(managers).Progress.TryGetValue(PageName, out var value))
		{
			list = new List<string>();
			Activity.ActivityProgress(managers).Progress.Add(PageName, list);
		}
		else if (value is List<string> list2)
		{
			list = list2;
		}
		else
		{
			list = new List<string>();
			ArrayList arrayList = (ArrayList)value;
			foreach (object item in arrayList)
			{
				list.Add(item.ToString());
			}
			Activity.ActivityProgress(managers).Progress[PageName] = list;
		}
		if (list.Count < 1)
		{
			return true;
		}
		if (list.Count >= SignInList.Count)
		{
			return false;
		}
		if (!DateTimeHelper.TryParse(list.Last(), out var dateTime))
		{
			return false;
		}
		DateTimeOffset now = DateTimeHelper.Now;
		DateTimeOffset dailyRefreshTime = DateTimeHelper.GetDailyRefreshTime(DateTimeHelper.Now, DateTimeHelper.TimezoneOffset, DateTimeHelper.RefreshHours);
		return dateTime < dailyRefreshTime;
	}

	public List<Bonus> SignIn(GameManagers managers)
	{
		if (!CanSignIn(managers))
		{
			return null;
		}
		ActivityConfig activityConfig = Activity.ActivityProgress(managers);
		List<string> list = (List<string>)activityConfig.Progress[PageName];
		list.Add(DateTimeHelper.Now.ToString("yyyy-MM-dd HH:mm:ss%K"));
		activityConfig.Score++;
		managers.UserArchiveManager.SetActivityProgress(activityConfig);
		foreach (SignInBonusData signIn in SignInList)
		{
			if (signIn.Target == TotalSignInCount(managers))
			{
				List<Bonus> list2 = new List<Bonus>();
				foreach (Bonus bonus in signIn.BonusList)
				{
					bonus.Claim(managers);
					list2.Add(bonus);
				}
				return list2;
			}
			if (signIn.Target > TotalSignInCount(managers))
			{
				break;
			}
		}
		return null;
	}

	public int TotalSignInCount(GameManagers managers)
	{
		int result = 0;
		if (Activity.ActivityProgress(managers).Progress.TryGetValue(PageName, out var value))
		{
			result = ((!(value is List<string> list)) ? ((!(value is ArrayList arrayList)) ? JsonHelper.ToObject<List<string>>(value.ToString()).Count : arrayList.Count) : list.Count);
		}
		return result;
	}

	public override bool HasAnyNewMsg(GameManagers managers)
	{
		return CanSignIn(managers);
	}
}
