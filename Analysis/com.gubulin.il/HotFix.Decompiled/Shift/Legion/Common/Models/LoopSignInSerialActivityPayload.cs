using System;
using System.Collections;
using System.Collections.Generic;
using GameDataEditor;
using Shift.Legion.Common.Managers;

namespace Shift.Legion.Common.Models;

public class LoopSignInSerialActivityPayload : ActivityContentPayload
{
	public readonly string PageName;

	public readonly List<SignInBonusData> SignInList;

	public LoopSignInSerialActivityPayload(int payloadIndex, string pageName, Dictionary<string, object> data, Activity activity)
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
		if (!DateTimeHelper.TryParse(list[0], out var dateTime))
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
		list.Clear();
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
					bonus.Claim(managers, null, null, forceClaim: true, broadcastInform: false);
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
		return (Activity.ActivityProgress(managers).Score - 1) % SignInList.Count + 1;
	}

	public override bool HasAnyNewMsg(GameManagers managers)
	{
		return CanSignIn(managers);
	}
}
