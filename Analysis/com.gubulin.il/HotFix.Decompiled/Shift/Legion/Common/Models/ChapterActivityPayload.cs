using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using GameDataEditor;
using ILRuntime_LitJson;
using Shift.Legion.ClientApi.Models;
using Shift.Legion.Common.Enums;
using Shift.Legion.Common.Managers;
using Shift.Legion.Common.Sources.Enums;
using Shift.Legion.Helpers;

namespace Shift.Legion.Common.Models;

public class ChapterActivityPayload : ActivityContentPayload
{
	public string ChapterId;

	public int Tickets;

	public int Score;

	public Dictionary<string, object> ExtraScore;

	public string PortalRoute;

	public Dictionary<string, object> EnableFilters;

	public DateTimeOffset BeginTime;

	public DateTimeOffset EndTime;

	public int CooldownPeriod;

	public string IconUrl;

	public float[] IconPosition;

	public Chapter Chapter;

	public int TotalLevels = 5;

	public bool IsPortal => !string.IsNullOrEmpty(PortalRoute);

	public Activity PortalTargetActivity
	{
		get
		{
			if (string.IsNullOrEmpty(PortalRoute))
			{
				return null;
			}
			if (!ActivityManager.Activities.TryGetValue(PortalRoute, out var value))
			{
				return null;
			}
			return value;
		}
	}

	public bool AllEnableFiltersPassed(GameManagers managers)
	{
		foreach (KeyValuePair<string, object> enableFilter in EnableFilters)
		{
			string key = enableFilter.Key;
			object value = enableFilter.Value;
			string text = key;
			string text2 = text;
			if (!(text2 == "Levels"))
			{
				continue;
			}
			List<string> list = new List<string>();
			JsonData val = (JsonData)((value is JsonData) ? value : null);
			if (val != null && val.IsArray)
			{
				for (int i = 0; i < val.Count; i++)
				{
					JsonData val2 = val[i];
					if (val2.IsString)
					{
						list.Add(((object)val2).ToString());
					}
				}
			}
			if (list.Count < 1)
			{
				continue;
			}
			Dictionary<string, List<string>> levelProgress = managers.UserArchiveManager.GetLevelProgress();
			foreach (List<string> value2 in levelProgress.Values)
			{
				foreach (string item in value2)
				{
					list.Remove(item);
					if (list.Count < 1)
					{
						break;
					}
				}
				if (list.Count < 1)
				{
					break;
				}
			}
			if (list.Count <= 0)
			{
				continue;
			}
			return false;
		}
		return true;
	}

	public List<KeyValuePair<string, LevelStatus>> LevelProgress(GameManagers managers)
	{
		ActivityConfig activityConfig = Activity.ActivityProgress(managers);
		List<KeyValuePair<string, LevelStatus>> levelProgressRecord = GetLevelProgressRecord(activityConfig);
		if (levelProgressRecord.Count < 1)
		{
			foreach (Level item in Levels(managers))
			{
				levelProgressRecord.Add(new KeyValuePair<string, LevelStatus>(item.LevelId, LevelStatus.Pending));
			}
			managers.UserArchiveManager.SetActivityProgress(activityConfig, updateModifiedAt: false);
		}
		return levelProgressRecord;
	}

	public ActivityUiInfo UiInfo(ActivityConfig activityProgress)
	{
		if (!activityProgress.PayloadUiInfo.TryGetValue(ChapterId, out var value))
		{
			value = new ActivityUiInfo();
			activityProgress.PayloadUiInfo.Add(ChapterId, value);
		}
		return value;
	}

	public List<List<BonusConfig>> LevelBonusInfo(ActivityConfig activityProgress)
	{
		if (!activityProgress.PayloadBonusInfo.TryGetValue(ChapterId, out var value))
		{
			value = new List<List<BonusConfig>>();
			activityProgress.PayloadBonusInfo.Add(ChapterId, value);
		}
		return value;
	}

	public void SetLevelBonusInfo(ActivityConfig activityProgress, List<List<BonusConfig>> value)
	{
		activityProgress.PayloadBonusInfo[ChapterId] = value;
	}

	public List<KeyValuePair<string, LevelStatus>> GetLevelProgressRecord(ActivityConfig activityProgress)
	{
		if (!activityProgress.Progress.TryGetValue(ChapterId, out var value))
		{
			value = new List<KeyValuePair<string, LevelStatus>>();
			activityProgress.Progress.Add(ChapterId, value);
		}
		List<KeyValuePair<string, LevelStatus>> list = new List<KeyValuePair<string, LevelStatus>>();
		if (value is ArrayList)
		{
			foreach (Dictionary<string, object> item in (ArrayList)value)
			{
				string text = item["Key"].ToString();
				string s = item["Value"].ToString();
				list.Add(new KeyValuePair<string, LevelStatus>(text.ToString(), (LevelStatus)int.Parse(s)));
			}
		}
		else if (value is IList)
		{
			foreach (KeyValuePair<string, int> item2 in (IList)value)
			{
				object key = item2.Key;
				object obj = item2.Value;
				list.Add(new KeyValuePair<string, LevelStatus>(key.ToString(), (LevelStatus)obj));
			}
		}
		else
		{
			ILRuntimeDebug.LogError("GetLevelProgressRecord 预期之外的数据类型！ActivityId=" + Activity.ActivityId + " ChapterId=" + ChapterId);
		}
		activityProgress.Progress[ChapterId] = list;
		return (List<KeyValuePair<string, LevelStatus>>)activityProgress.Progress[ChapterId];
	}

	public Dictionary<string, DateTimeOffset> GetLevelCooldownRecord(ActivityConfig activityProgress)
	{
		if (!activityProgress.Cooldown.TryGetValue(ChapterId, out var value))
		{
			Dictionary<string, DateTimeOffset> result = new Dictionary<string, DateTimeOffset>();
			activityProgress.Cooldown.Add(ChapterId, new Dictionary<string, DateTimeOffset>());
			return result;
		}
		Dictionary<string, object> dictionary = new Dictionary<string, object>();
		try
		{
			dictionary = (Dictionary<string, object>)value;
		}
		catch (Exception exception)
		{
			ILRuntimeDebug.LogException(exception);
			dictionary = new Dictionary<string, object>();
		}
		Dictionary<string, DateTimeOffset> dictionary2 = new Dictionary<string, DateTimeOffset>();
		if (dictionary != null && dictionary.Count > 0)
		{
			dictionary2.Add(dictionary.Keys.First(), DateTimeOffset.Parse(dictionary.Values.First().ToString()));
		}
		return dictionary2;
	}

	public void ClearLevelProgressRecord(ActivityConfig activityProgress)
	{
		GetLevelProgressRecord(activityProgress).Clear();
	}

	public void ClearLevelCooldownRecord(ActivityConfig activityProgress)
	{
		GetLevelCooldownRecord(activityProgress).Clear();
	}

	public ChapterActivityPayload(int payloadIndex, string chapterId, Dictionary<string, object> data, Activity activity)
		: base(data)
	{
		ContentIndex = payloadIndex;
		Activity = activity;
		ChapterId = chapterId;
		ChapterManager.Chapters.TryGetValue(chapterId, out Chapter);
		if (data.TryGetValue("Tickets", out var value))
		{
			Tickets = Convert.ToInt32(value);
		}
		if (data.TryGetValue("Score", out var value2))
		{
			Score = Convert.ToInt32(value2);
		}
		if (data.TryGetValue("Levels", out var value3))
		{
			TotalLevels = Convert.ToInt32(value3);
		}
		if (data.TryGetValue("Cooldown", out var value4))
		{
			CooldownPeriod = Convert.ToInt32(value4);
		}
		if (data.TryGetValue("Icon", out var value5))
		{
			IconUrl = value5.ToString();
		}
		if (data.TryGetValue("Portal", out var value6))
		{
			PortalRoute = value6.ToString();
		}
		if (data.TryGetValue("ExtraScore", out var value7))
		{
			ExtraScore = (Dictionary<string, object>)value7;
		}
		if (data.TryGetValue("EnableFilters", out var value8))
		{
			EnableFilters = (Dictionary<string, object>)value8;
			List<string> list = new List<string>();
			list.AddRange(EnableFilters.Keys);
			foreach (string item in list)
			{
				string text = item;
				string text2 = text;
				if (text2 == "Levels")
				{
					EnableFilters[item] = (List<string>)EnableFilters[item];
				}
			}
		}
		DateTimeOffset now = DateTimeHelper.Now;
		if (data.TryGetValue("BeginTime", out var value9))
		{
			BeginTime = DateTimeHelper.Parse(value9.ToString(), now);
		}
		if (data.TryGetValue("EndTime", out var value10))
		{
			EndTime = DateTimeHelper.Parse(value10.ToString(), now);
		}
	}

	public bool OnLevelComplete(GameManagers managers, string battleId, Level level, Team winner, bool newCompleteFlag)
	{
		bool result = false;
		bool flag = CooldownPeriod > 0;
		if (flag && winner == Team.Red)
		{
			result = true;
			Dictionary<string, DateTimeOffset> levelCooldownRecord = GetLevelCooldownRecord(Activity.ActivityProgress(managers));
			if (!levelCooldownRecord.TryGetValue(level.LevelId, out var _))
			{
				levelCooldownRecord.Add(level.LevelId, default(DateTimeOffset));
			}
			levelCooldownRecord[level.LevelId] = DateTimeHelper.Now.AddSeconds(CooldownPeriod);
		}
		int num = IndexOfLevel(managers, level);
		if (num < 0)
		{
			throw new Exception(level.LevelId + " 不在 " + Activity.ActivityId + " 里");
		}
		if (num < LevelProgress(managers).Count)
		{
			result = true;
			LevelStatus value2 = ((winner == Team.Red) ? LevelStatus.Completed : (flag ? LevelStatus.Battling : LevelStatus.Pending));
			List<KeyValuePair<string, LevelStatus>> list = LevelProgress(managers);
			list[num] = new KeyValuePair<string, LevelStatus>(level.LevelId, value2);
		}
		return result;
	}

	public void OnChapterComplete(GameManagers managers, bool newCompleteFlag)
	{
		UpdateDifficultyLevel(managers);
	}

	private void GainScore(GameManagers managers, bool newCompleteFlag)
	{
		int score = Score;
		ActivityConfig activityConfig = Activity.ActivityProgress(managers);
		activityConfig.Score += score;
		managers.UserArchiveManager.SetActivityProgress(activityConfig);
		if (ExtraScore == null)
		{
			return;
		}
		foreach (KeyValuePair<string, object> item in ExtraScore)
		{
			string key = item.Key;
			ActivityManager.Activities.TryGetValue(key, out var value);
			if (value != null)
			{
				object value2 = item.Value;
				ActivityConfig activityConfig2 = value.ActivityProgress(managers);
				activityConfig2.Score += int.Parse(value2.ToString());
				managers.UserArchiveManager.SetActivityProgress(activityConfig2);
			}
		}
	}

	private void UpdateDifficultyLevel(GameManagers managers)
	{
		if (!IsPortal || !ActivityManager.Activities.TryGetValue(PortalRoute, out var value) || value.DifficultyLevel <= 0)
		{
			return;
		}
		Dictionary<string, int> value2 = managers.ActivityManager.ActivityMaxDifficultyLevels.GetValue();
		if (value2.TryGetValue(value.Type.ToString(), out var value3))
		{
			if (value3 < value.DifficultyLevel)
			{
				value2[value.Type.ToString()] = value.DifficultyLevel;
			}
		}
		else
		{
			value2.Add(value.Type.ToString(), value.DifficultyLevel);
		}
		managers.ActivityManager.ActivityMaxDifficultyLevels.Save();
		Dictionary<string, int> value4 = managers.ActivityManager.ActivityDifficultyLevels.GetValue();
		if (value4.TryGetValue(value.Type.ToString(), out var value5))
		{
			if (value5 < value.DifficultyLevel)
			{
				value4[value.Type.ToString()] = value.DifficultyLevel;
			}
		}
		else
		{
			value4.Add(value.Type.ToString(), value.DifficultyLevel);
		}
		managers.ActivityManager.ActivityDifficultyLevels.Save();
	}

	public override void BeforeReset(GameManagers managers, bool autoReset = false)
	{
		List<Level> list = Levels(managers);
		if (list == null)
		{
			return;
		}
		foreach (Level item in list)
		{
			managers.UserArchiveManager.RemoveLevelLotteryBonus(item);
		}
	}

	public override void AfterReset(GameManagers managers)
	{
		Levels(managers);
	}

	public override void Reset(GameManagers managers, bool autoReset = false)
	{
		ActivityConfig activityConfig = Activity.ActivityProgress(managers);
		activityConfig.IsNew = true;
		LevelProgress(managers);
	}

	public int IndexOfLevel(GameManagers managers, Level level)
	{
		int result = -1;
		List<Level> list = Levels(managers);
		for (int i = 0; i < list.Count; i++)
		{
			if (list[i].LevelId == level.LevelId)
			{
				result = i;
			}
		}
		return result;
	}

	public List<Level> Levels(GameManagers managers)
	{
		if (Chapter == null)
		{
			return null;
		}
		List<KeyValuePair<string, LevelStatus>> levelProgressRecord = GetLevelProgressRecord(Activity.ActivityProgress(managers));
		List<Level> list = new List<Level>();
		if (levelProgressRecord.Count > 0)
		{
			foreach (KeyValuePair<string, LevelStatus> item in levelProgressRecord)
			{
				Level levelInstance = managers.ChapterManager.GetLevelInstance(item.Key);
				list.Add(levelInstance);
			}
		}
		else if (Chapter.Levelship == Levelship.RandomLevels)
		{
			ILRuntimeDebug.LogError("报错！ 不应该在客户端生成随机关卡！ActivityId={0}, ChapterId={1}", Activity.ActivityId, ChapterId);
		}
		else
		{
			if (Activity.Type != ActivityType.NeutralDungeonInstance)
			{
				ILRuntimeDebug.LogError("报错！ 不应该在客户端走到这里！ActivityId={0}, ChapterId={1}", Activity.ActivityId, ChapterId);
			}
			foreach (Level value in Chapter.Levels.Values)
			{
				list.Add(value);
			}
		}
		ActivityConfig activityConfig = Activity.ActivityProgress(managers);
		List<List<BonusConfig>> list2 = LevelBonusInfo(activityConfig);
		if (list2.Count == list.Count)
		{
			for (int i = 0; i < list2.Count; i++)
			{
				Level level = list[i];
				managers.UserArchiveManager.SetLevelLotteryBonus(level, list2[i]);
			}
		}
		else
		{
			list2.Clear();
			foreach (Level item2 in list)
			{
				if (!item2.AutoLottery)
				{
					continue;
				}
				List<BonusConfig> list3 = new List<BonusConfig>();
				list2.Add(list3);
				foreach (KeyValuePair<Bonus, int> item3 in item2.ReGetLotteryBonus(managers))
				{
					Bonus key = item3.Key;
					list3.Add(new BonusConfig
					{
						ItemId = key.ItemId,
						Qty = key.Qty,
						Category = key.Category,
						Type = key.Type,
						IsShining = item3.Value,
						IsCard3 = false
					});
				}
			}
			SetLevelBonusInfo(activityConfig, list2);
			managers.UserArchiveManager.SetActivityProgress(activityConfig, updateModifiedAt: false);
		}
		return list;
	}

	public int GetLevelPosOnUI(GameManagers managers, int totalTemplates = 3)
	{
		ActivityConfig activityProgress = Activity.ActivityProgress(managers);
		ActivityUiInfo activityUiInfo = UiInfo(activityProgress);
		if (activityUiInfo.LevelUiTemplate == -1)
		{
			activityUiInfo.LevelUiTemplate = managers.RandomManager.Int(totalTemplates);
		}
		return activityUiInfo.LevelUiTemplate;
	}

	public override void OnFinish(GameManagers managers)
	{
		if (Activity.Period == ActivityPeriod.NDaysCycle || Activity.Period == ActivityPeriod.Hybrid)
		{
			Reset(managers);
			ReCalcTime(managers);
		}
	}

	public void ReCalcTime(GameManagers managers)
	{
		GDEActivityData data = Activity.Data;
		string[] array = data.BeginTime.First().Split(new char[1] { '|' }, StringSplitOptions.RemoveEmptyEntries);
		if (array.Length != 3)
		{
			throw new ArgumentException("NDaysCycle BeginTime格式错误:" + JsonHelper.ToJson(data.BeginTime));
		}
		DateTimeOffset now = DateTimeHelper.Now;
		TimeSpan timeSpan = TimeSpan.FromDays(int.Parse(array[2]));
		string dateTimeStr = array[0];
		DateTimeOffset dateTimeOffset = DateTimeHelper.Parse(dateTimeStr, now);
		int num = (int)Math.Floor((now - dateTimeOffset).TotalDays / timeSpan.TotalDays);
		ActivityConfig activityConfig = Activity.ActivityProgress(managers);
		activityConfig.BeginAt = dateTimeOffset.AddDays((double)num * timeSpan.TotalDays);
		DateTimeOffset dateTimeOffset2 = activityConfig.BeginAt.AddDays(int.Parse(array[1]));
		if (data.EndTime.Count > 0 && DateTimeHelper.TryParse(data.EndTime.First(), out var dateTime) && dateTime < dateTimeOffset2)
		{
			dateTimeOffset2 = dateTime;
		}
		activityConfig.EndAt = dateTimeOffset2;
	}
}
