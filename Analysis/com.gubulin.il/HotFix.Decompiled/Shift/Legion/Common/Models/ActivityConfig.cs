using System;
using System.Collections.Generic;
using System.Linq;
using Shift.Legion.ClientApi.Models;

namespace Shift.Legion.Common.Models;

public class ActivityConfig
{
	public string ActivityId;

	public int Score = 0;

	public Dictionary<string, object> Progress = new Dictionary<string, object>();

	public Dictionary<string, object> Cooldown = new Dictionary<string, object>();

	public List<float> ClaimProgress = new List<float>();

	public DateTimeOffset ModifiedAt;

	public DateTimeOffset BeginAt;

	public DateTimeOffset EndAt;

	public DateTimeOffset LastResetAt;

	public DateTimeOffset LastAutoFillAt = new DateTimeOffset(2020, 1, 1, 0, 0, 0, TimeSpan.Zero);

	public DateTimeOffset PeriodStartAt = new DateTimeOffset(2020, 1, 1, 0, 0, 0, TimeSpan.Zero);

	public Dictionary<string, ActivityUiInfo> PayloadUiInfo = new Dictionary<string, ActivityUiInfo>();

	public Dictionary<string, List<List<BonusConfig>>> PayloadBonusInfo = new Dictionary<string, List<List<BonusConfig>>>();

	public bool IsNew = true;

	public DateTimeOffset LastPeriodStarAt;

	public object Clone()
	{
		ActivityConfig activityConfig = new ActivityConfig
		{
			ActivityId = ActivityId,
			Score = Score,
			Progress = new Dictionary<string, object>(),
			Cooldown = new Dictionary<string, object>(),
			ClaimProgress = new List<float>(),
			ModifiedAt = ModifiedAt,
			LastResetAt = LastResetAt,
			LastAutoFillAt = LastAutoFillAt,
			PeriodStartAt = PeriodStartAt,
			PayloadUiInfo = new Dictionary<string, ActivityUiInfo>(),
			PayloadBonusInfo = new Dictionary<string, List<List<BonusConfig>>>(),
			LastPeriodStarAt = LastPeriodStarAt
		};
		foreach (KeyValuePair<string, object> item in Progress)
		{
			activityConfig.Progress.Add(item.Key, item.Value);
		}
		foreach (KeyValuePair<string, object> item2 in Cooldown)
		{
			activityConfig.Cooldown.Add(item2.Key, item2.Value);
		}
		activityConfig.ClaimProgress.AddRange(ClaimProgress);
		foreach (KeyValuePair<string, ActivityUiInfo> item3 in PayloadUiInfo)
		{
			activityConfig.PayloadUiInfo.Add(item3.Key, item3.Value);
		}
		foreach (KeyValuePair<string, List<List<BonusConfig>>> item4 in PayloadBonusInfo)
		{
			activityConfig.PayloadBonusInfo.Add(item4.Key, item4.Value.ToList());
		}
		return activityConfig;
	}

	public void Reset(bool autoReset = false, object injectConfig = null)
	{
		DateTimeOffset now = DateTimeHelper.Now;
		if (injectConfig != null)
		{
			if (injectConfig is Shift.Legion.ClientApi.Models.ActivityConfig newConfig)
			{
				InjectWithApiConfigModel(newConfig);
			}
			return;
		}
		Score = 0;
		Progress.Clear();
		Cooldown.Clear();
		ClaimProgress.Clear();
		PayloadUiInfo.Clear();
		PayloadBonusInfo.Clear();
		IsNew = true;
		ModifiedAt = now;
		if (autoReset)
		{
			LastPeriodStarAt = PeriodStartAt;
			PeriodStartAt = DateTimeHelper.GetDailyRefreshTime(now, DateTimeHelper.TimezoneOffset, DateTimeHelper.RefreshHours);
		}
		else
		{
			LastResetAt = now;
		}
	}

	public Shift.Legion.ClientApi.Models.ActivityConfig ToProto()
	{
		Shift.Legion.ClientApi.Models.ActivityConfig activityConfig = new Shift.Legion.ClientApi.Models.ActivityConfig
		{
			ActivityId = ActivityId,
			IsNew = IsNew,
			Score = Score,
			Progress = new Dictionary<string, object>(),
			Cooldown = new Dictionary<string, object>(),
			ClaimProgress = new List<float>(),
			BeginAt = BeginAt,
			ModifiedAt = ModifiedAt,
			LastResetAt = LastResetAt,
			LastAutoFillAt = LastAutoFillAt,
			PeriodStartAt = PeriodStartAt,
			PayloadUiInfo = new Dictionary<string, ActivityUiInfo>(),
			PayloadBonusInfo = new Dictionary<string, List<List<ModelsBonus>>>(),
			LastPeriodStarAt = LastPeriodStarAt
		};
		foreach (KeyValuePair<string, object> item in Progress)
		{
			activityConfig.Progress.Add(item.Key, item.Value);
		}
		foreach (KeyValuePair<string, object> item2 in Cooldown)
		{
			activityConfig.Cooldown.Add(item2.Key, item2.Value);
		}
		activityConfig.ClaimProgress.AddRange(ClaimProgress);
		foreach (KeyValuePair<string, ActivityUiInfo> item3 in PayloadUiInfo)
		{
			activityConfig.PayloadUiInfo.Add(item3.Key, item3.Value);
		}
		foreach (KeyValuePair<string, List<List<BonusConfig>>> item4 in PayloadBonusInfo)
		{
			List<List<BonusConfig>> value = item4.Value;
			List<List<ModelsBonus>> list = new List<List<ModelsBonus>>();
			foreach (List<BonusConfig> item5 in item4.Value)
			{
				List<ModelsBonus> list2 = new List<ModelsBonus>();
				foreach (BonusConfig item6 in item5)
				{
					list2.Add(new ModelsBonus
					{
						ItemId = item6.ItemId,
						Qty = item6.Qty,
						IsShining = item6.IsShining
					});
				}
				list.Add(list2);
			}
			activityConfig.PayloadBonusInfo.Add(item4.Key, list);
		}
		return activityConfig;
	}

	public void InjectWithApiConfigModel(Shift.Legion.ClientApi.Models.ActivityConfig newConfig)
	{
		Score = newConfig.Score;
		ModifiedAt = newConfig.ModifiedAt;
		BeginAt = newConfig.BeginAt;
		LastResetAt = newConfig.LastResetAt;
		LastAutoFillAt = newConfig.LastAutoFillAt;
		PeriodStartAt = newConfig.PeriodStartAt;
		IsNew = newConfig.IsNew;
		Progress.Clear();
		foreach (KeyValuePair<string, object> item in newConfig.Progress)
		{
			Progress.Add(item.Key, item.Value);
		}
		Cooldown.Clear();
		foreach (KeyValuePair<string, object> item2 in newConfig.Cooldown)
		{
			Cooldown.Add(item2.Key, item2.Value);
		}
		ClaimProgress.Clear();
		foreach (float item3 in newConfig.ClaimProgress)
		{
			ClaimProgress.Add(item3);
		}
		PayloadUiInfo.Clear();
		foreach (KeyValuePair<string, ActivityUiInfo> item4 in newConfig.PayloadUiInfo)
		{
			string key = item4.Key;
			ActivityUiInfo value = item4.Value;
			PayloadUiInfo.Add(key, new ActivityUiInfo
			{
				LevelUiTemplate = value.LevelUiTemplate
			});
		}
		PayloadBonusInfo.Clear();
		foreach (KeyValuePair<string, List<List<ModelsBonus>>> item5 in newConfig.PayloadBonusInfo)
		{
			string key2 = item5.Key;
			List<List<ModelsBonus>> value2 = item5.Value;
			List<List<BonusConfig>> list = new List<List<BonusConfig>>();
			foreach (List<ModelsBonus> item6 in value2)
			{
				List<BonusConfig> list2 = new List<BonusConfig>();
				foreach (ModelsBonus item7 in item6)
				{
					list2.Add(new BonusConfig
					{
						ItemId = item7.ItemId,
						Qty = item7.Qty,
						IsShining = item7.IsShining
					});
				}
				list.Add(list2);
			}
			PayloadBonusInfo.Add(key2, list);
		}
		LastPeriodStarAt = newConfig.LastPeriodStarAt;
	}
}
