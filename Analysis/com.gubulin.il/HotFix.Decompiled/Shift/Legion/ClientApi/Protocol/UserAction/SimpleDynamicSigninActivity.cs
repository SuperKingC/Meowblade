using System;
using System.Collections.Generic;
using System.Linq;
using GameMaths;
using ILRuntime_LitJson;
using Shift.Legion.Common.Managers;
using Shift.Legion.Common.Models;
using Shift.Legion.Helpers;

namespace Shift.Legion.ClientApi.Protocol.UserAction;

public class SimpleDynamicSigninActivity
{
	private const string USEABLE_RETROACTIVE_SIGN_IN_COUNT = "UseableRetroactiveSignInCount";

	private const string SIGN_DAY_IDX = "SignInDayIdx";

	private const string CLAIM_BONUS = "ClaimedBonus";

	private const string CLAIM_TIME = "ClaimedTime";

	public string ActivityId;

	public string ActivityName;

	public string PageName;

	public string Desc;

	public List<DateTimeOffset> BeginTime;

	public List<DateTimeOffset> EndTime;

	public string ImgUrl;

	public string SignInSerialActivityPayload;

	public string SignInSerialInfo;

	public bool CanSignIn;

	public int TotalSignInCount;

	public List<string> LevelCase;

	public bool RetroactiveSignInAvailable;

	public int TodayIndex;

	public string Progress;

	[JsonIgnore]
	private List<SignInBonusData> _signInBonusData;

	public List<SignInBonusData> GetBonusData()
	{
		if (_signInBonusData != null)
		{
			return _signInBonusData;
		}
		if (!string.IsNullOrEmpty(SignInSerialInfo))
		{
			_signInBonusData = JsonHelper.ToObject<List<SignInBonusData>>(SignInSerialInfo);
		}
		return _signInBonusData;
	}

	public List<Bonus> SerialSignIn(GameManagers managers, bool canSignIn, int totalSignInCount, string activityProgress)
	{
		if (string.IsNullOrEmpty(activityProgress))
		{
			return null;
		}
		if (!CanSignIn)
		{
			return null;
		}
		CanSignIn = canSignIn;
		TotalSignInCount = totalSignInCount;
		managers.UserArchiveManager.SetActivityProgress(JsonHelper.ToObject<ActivityConfig>(activityProgress));
		foreach (SignInBonusData bonusDatum in GetBonusData())
		{
			if (bonusDatum.Target == TotalSignInCount)
			{
				List<Bonus> list = new List<Bonus>();
				foreach (Bonus bonus in bonusDatum.BonusList)
				{
					bonus.Claim(managers);
					list.Add(bonus);
				}
				return list;
			}
			if (bonusDatum.Target > TotalSignInCount)
			{
				break;
			}
		}
		return null;
	}

	public List<Bonus> ParallelSignIn(GameManagers managers, int dayTarget)
	{
		List<Bonus> list = new List<Bonus>();
		List<SignInBonusData> bonusData = GetBonusData();
		List<Bonus> list2 = bonusData.Find((SignInBonusData s) => s.Target == dayTarget)?.BonusList;
		if (list2 == null)
		{
			return list;
		}
		foreach (Bonus item in list2)
		{
			item.Claim(managers);
			list.Add(item);
		}
		ActivityConfig activityConfig = GetActivityConfig();
		Dictionary<string, object> progress = activityConfig.Progress;
		List<string> signInTimeRecord = GetSignInTimeRecord(managers);
		signInTimeRecord.Add(DateTimeHelper.Now.ToString("yyyy-MM-dd HH:mm:ss%K"));
		progress["ClaimedTime"] = JsonHelper.ToJson(signInTimeRecord);
		activityConfig.Score++;
		HashSet<int> signDayIndexRecord = GetSignDayIndexRecord(managers);
		signDayIndexRecord.Add(TodayIndex);
		progress["SignInDayIdx"] = JsonHelper.ToJson(signDayIndexRecord.ToList());
		List<int> signInBonusClaimRecord = GetSignInBonusClaimRecord(GameManagers.Instance);
		signInBonusClaimRecord.Add(dayTarget);
		progress["ClaimedBonus"] = JsonHelper.ToJson(signInBonusClaimRecord);
		managers.UserArchiveManager.SetActivityProgress(activityConfig);
		CanSignIn = RetroactiveCanSignIn(GameManagers.Instance);
		return list;
	}

	public int GetMissedDayCount()
	{
		List<SignInBonusData> bonusData = GetBonusData();
		List<int> signInBonusClaimRecord = GetSignInBonusClaimRecord(GameManagers.Instance);
		HashSet<int> signDayIndexRecord = GetSignDayIndexRecord(GameManagers.Instance);
		bool flag = signDayIndexRecord.Contains(TodayIndex);
		int num = Mathf.Min(TodayIndex, bonusData.Count) - signInBonusClaimRecord.Count;
		num = ((!flag) ? (num - 1) : num);
		int num2 = TryGetUseableRetroactiveSignInCount(GameManagers.Instance);
		return Mathf.Max(0, num - num2);
	}

	private int TryGetUseableRetroactiveSignInCount(GameManagers managers)
	{
		ActivityConfig activityConfig = GetActivityConfig();
		Dictionary<string, object> progress = activityConfig.Progress;
		object value;
		int result;
		return progress.TryGetValue("UseableRetroactiveSignInCount", out value) ? (int.TryParse(value.ToString(), out result) ? result : 0) : 0;
	}

	public void AddUseableRetroactiveSignInCount(GameManagers managers, int count = 1)
	{
		if (RetroactiveSignInAvailable)
		{
			ActivityConfig activityConfig = GetActivityConfig();
			Dictionary<string, object> progress = activityConfig.Progress;
			progress["UseableRetroactiveSignInCount"] = ((!progress.TryGetValue("UseableRetroactiveSignInCount", out var value)) ? count : (int.TryParse(value.ToString(), out var result) ? (result + count) : count));
			managers.UserArchiveManager.SetActivityProgress(activityConfig);
		}
	}

	public int GetSignInRange(GameManagers managers)
	{
		List<int> signInBonusClaimRecord = GetSignInBonusClaimRecord(managers);
		HashSet<int> signDayIndexRecord = GetSignDayIndexRecord(managers);
		int num = TryGetUseableRetroactiveSignInCount(managers);
		int num2 = ((!signDayIndexRecord.Contains(TodayIndex)) ? 1 : 0);
		int num3 = num2 + num + signDayIndexRecord.Count;
		List<SignInBonusData> bonusData = GetBonusData();
		num3 = Mathf.Min(num3, bonusData.Count);
		return Mathf.Min(num3, TodayIndex);
	}

	private bool RetroactiveCanSignIn(GameManagers managers)
	{
		List<SignInBonusData> bonusData = GetBonusData();
		List<int> signInBonusClaimRecord = GetSignInBonusClaimRecord(managers);
		if (signInBonusClaimRecord.Count >= bonusData.Count)
		{
			return false;
		}
		HashSet<int> signDayIndexRecord = GetSignDayIndexRecord(managers);
		int num = TryGetUseableRetroactiveSignInCount(managers);
		int num2 = ((!signDayIndexRecord.Contains(TodayIndex)) ? 1 : 0);
		int num3 = num2 + num + signDayIndexRecord.Count;
		num3 = Mathf.Min(num3, bonusData.Count);
		num3 = Mathf.Min(num3, TodayIndex);
		for (int i = 1; i <= num3; i++)
		{
			if (!signInBonusClaimRecord.Contains(i))
			{
				return true;
			}
		}
		return false;
	}

	public List<int> GetSignInBonusClaimRecord(GameManagers managers)
	{
		string key = "ClaimedBonus";
		ActivityConfig activityConfig = GetActivityConfig();
		Dictionary<string, object> progress = activityConfig.Progress;
		if (!progress.TryGetValue(key, out var value))
		{
			return new List<int>();
		}
		string value2 = value.ToString();
		return string.IsNullOrEmpty(value2) ? new List<int>() : JsonHelper.ToObject<List<int>>(value.ToString());
	}

	public HashSet<int> GetSignDayIndexRecord(GameManagers managers)
	{
		string key = "SignInDayIdx";
		ActivityConfig activityConfig = GetActivityConfig();
		Dictionary<string, object> progress = activityConfig.Progress;
		if (!progress.TryGetValue(key, out var value))
		{
			return new HashSet<int>();
		}
		string text = value.ToString();
		return new HashSet<int>(string.IsNullOrEmpty(text) ? new List<int>() : JsonHelper.ToObject<List<int>>(text));
	}

	private List<string> GetSignInTimeRecord(GameManagers managers)
	{
		ActivityConfig activityConfig = GetActivityConfig();
		Dictionary<string, object> progress = activityConfig.Progress;
		if (!progress.TryGetValue("ClaimedTime", out var value))
		{
			return new List<string>();
		}
		string value2 = value.ToString();
		return string.IsNullOrEmpty(value2) ? new List<string>() : JsonHelper.ToObject<List<string>>(value.ToString());
	}

	private ActivityConfig GetActivityConfig()
	{
		return GameManagers.Instance.UserArchiveManager.GetActivityProgressOrNew(ActivityId);
	}
}
