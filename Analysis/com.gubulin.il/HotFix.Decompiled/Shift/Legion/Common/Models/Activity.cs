using System;
using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Managers;
using Assets.Scripts.UI;
using GameDataEditor;
using GameMaths;
using HotFix;
using HotFix.Sources.Shift.Legion.Shift.Legion.Common.Sources.Interfaces;
using HotFix.Sources.Shift.Legion.Shift.Legion.Common.Sources.Models;
using HotFix.Sources.Shift.Legion.Shift.Legion.Common.Sources.Models.Activities;
using ObjectPool;
using Shift.Legion.ClientApi.Protocol.UserAction;
using Shift.Legion.Common.Enums;
using Shift.Legion.Common.Helpers;
using Shift.Legion.Common.Managers;
using Shift.Legion.Common.Sources.Enums;
using Shift.Legion.Helpers;

namespace Shift.Legion.Common.Models;

public class Activity : ICompletableActivity
{
	public class BonusPoint
	{
		public int Score;

		public Dictionary<string, float> BonusItems;
	}

	private readonly object _lock = new object();

	private static readonly Dictionary<DayOfWeek, string> WeekDayNames = new Dictionary<DayOfWeek, string>
	{
		{
			DayOfWeek.Monday,
			LanguagesManager.GetDesc("CsharpCodeZhTcText456")
		},
		{
			DayOfWeek.Tuesday,
			LanguagesManager.GetDesc("CsharpCodeZhTcText457")
		},
		{
			DayOfWeek.Wednesday,
			LanguagesManager.GetDesc("CsharpCodeZhTcText458")
		},
		{
			DayOfWeek.Thursday,
			LanguagesManager.GetDesc("CsharpCodeZhTcText459")
		},
		{
			DayOfWeek.Friday,
			LanguagesManager.GetDesc("CsharpCodeZhTcText460")
		},
		{
			DayOfWeek.Saturday,
			LanguagesManager.GetDesc("CsharpCodeZhTcText461")
		},
		{
			DayOfWeek.Sunday,
			LanguagesManager.GetDesc("CsharpCodeZhTcText398")
		}
	};

	private const string LEGION_CULTIVATE_FUND_PANEL = "UI_LegionCultivateFundPanel";

	private const string FUNDS5 = "Funds5";

	public GDEActivityData Data;

	public List<string> ChildIds = new List<string>();

	public int SortOrder;

	private List<DateTimeOffset> _beginTime;

	private List<DateTimeOffset> _endTime;

	private DateTimeOffset _lastCheckTime;

	private readonly Dictionary<string, float> _ticketPrice;

	public string TitleBonus;

	public List<string> BonusExhibition;

	public Dictionary<float, Dictionary<string, float>> BonusProgress;

	public List<BonusPoint> BonusProgressList;

	public MissionSerialForeignActivityPayload ProgressMissionData;

	public ChallengeMissionPayload ChallengeMissionData;

	public MoonBattlePassPayload WeekActPassPayload;

	private Dictionary<string, ActivityContentPayload> _contentPayload;

	private Dictionary<string, List<string>> _contentTypeToIds;

	public readonly List<Bonus> Bonuses;

	public readonly string UiName;

	public readonly Dictionary<string, object> UiParams;

	public readonly List<Dictionary<string, int>> ResetCost;

	public readonly List<string> LevelCase;

	public readonly Dictionary<string, Dictionary<string, int>> SoldierCase;

	public readonly List<string> PurchaseCase;

	public string ActivityId => Data.Key;

	public string Parent => Data.Parent;

	public int DifficultyLevel => Data.DifficultyLevel;

	public string FormationTag => string.IsNullOrEmpty(Data.FormationTag) ? ActivityId : Data.FormationTag;

	public ActivityType Type => (ActivityType)Data.Type;

	public List<DateTimeOffset> BeginTime => GetBeginTime(DateTimeHelper.ParseTimeStamp((int)GameController.Instance.GetServerTime()), DateTimeHelper.RefreshHours, DateTimeHelper.TimezoneOffset);

	public List<DateTimeOffset> EndTime => GetEndTime(DateTimeHelper.ParseTimeStamp((int)GameController.Instance.GetServerTime()), DateTimeHelper.RefreshHours, DateTimeHelper.TimezoneOffset);

	public ActivityPeriod Period => (ActivityPeriod)Data.Period;

	public string Name => Data.Name;

	public string Desc => Data.Desc;

	public string ImgUrl => Data.ImgUrl;

	public string BackgroundUrl => Data.Background;

	public bool AutoFillTicket => Data.AutoFillTicket;

	public int TicketFillPeriod => Data.TicketFillPeriod;

	public int TicketFillQuantity => Data.TicketFillQuantity;

	public int TicketLimit => Data.TicketLimit;

	public string TicketItem => Data.TicketItem;

	public string ScoreItem => Data.ScoreItem;

	public ActivityContentType ContentType => (ActivityContentType)Data.ContentType;

	public ActivityContentUnlockType ContentUnlockType => (ActivityContentUnlockType)Data.ContentUnlockType;

	public List<DateTimeOffset> GetBeginTime(DateTimeOffset now, TimeSpan refreshHours, TimeSpan timezoneOffset)
	{
		RefreshTime(now, refreshHours, timezoneOffset);
		return _beginTime;
	}

	public List<DateTimeOffset> GetEndTime(DateTimeOffset now, TimeSpan refreshHours, TimeSpan timezoneOffset)
	{
		RefreshTime(now, refreshHours, timezoneOffset);
		return _endTime;
	}

	public static DateTimeOffset GetRefreshTime(ActivityPeriod period, DateTimeOffset now, TimeSpan refreshHours, TimeSpan timeZoneOffset)
	{
		if (now.Offset != timeZoneOffset)
		{
			now = now.ToOffset(timeZoneOffset);
		}
		DateTimeOffset result = default(DateTimeOffset);
		switch (period)
		{
		case ActivityPeriod.Daily:
			return DateTimeHelper.GetDailyRefreshTime(now, timeZoneOffset, refreshHours);
		case ActivityPeriod.Weekly:
			return DateTimeHelper.GetWeeklyRefreshTime(now, timeZoneOffset, refreshHours);
		case ActivityPeriod.Monthly:
			return DateTimeHelper.GetMonthlyRefreshTime(now, timeZoneOffset, refreshHours);
		default:
			throw new ArgumentOutOfRangeException("period", period, null);
		case ActivityPeriod.Single:
		case ActivityPeriod.Permanent:
		case ActivityPeriod.NDaysCycle:
		case ActivityPeriod.Hybrid:
			return result;
		}
	}

	public static bool ParseDailyTime(string timeStr, int dayOffset, DateTimeOffset refreshTime, out DateTimeOffset result)
	{
		if (DateTimeHelper.TryParseTime(refreshTime, timeStr, out var dateTime))
		{
			dateTime = dateTime.AddDays(dayOffset);
			if (dateTime.CompareTo(refreshTime) < 0)
			{
				dateTime = dateTime.AddDays(1.0);
			}
			result = dateTime;
			return true;
		}
		result = default(DateTimeOffset);
		return false;
	}

	public static bool ParseWeeklyTime(string timeStr, int dayOfWeek, DateTimeOffset refreshTime, out DateTimeOffset result)
	{
		if (DateTimeHelper.TryParseTime(refreshTime, timeStr, out var dateTime))
		{
			dateTime = dateTime.AddDays(dayOfWeek - 1);
			if (dateTime.CompareTo(refreshTime) < 0)
			{
				dateTime = dateTime.AddDays(7.0);
			}
			result = dateTime;
			return true;
		}
		result = default(DateTimeOffset);
		return false;
	}

	public static bool ParseMonthlyTime(string timeStr, int dayOfMonth, DateTimeOffset refreshTime, out DateTimeOffset result)
	{
		if (DateTimeHelper.TryParseTime(refreshTime, timeStr, out var dateTime))
		{
			dateTime = ((dayOfMonth <= 0) ? dateTime.AddMonths(1).AddDays(dayOfMonth) : dateTime.AddDays(dayOfMonth - 1));
			if (dateTime.CompareTo(refreshTime) < 0)
			{
				dateTime = dateTime.AddMonths(1);
			}
			result = dateTime;
			return true;
		}
		result = default(DateTimeOffset);
		return false;
	}

	private void RefreshTime(DateTimeOffset now, TimeSpan refreshHours, TimeSpan timezoneOffset)
	{
		lock (_lock)
		{
			if (now.Offset != timezoneOffset)
			{
				now = now.ToOffset(timezoneOffset);
			}
			if (!(_lastCheckTime != default(DateTimeOffset)) || now.Hour != _lastCheckTime.Hour)
			{
				_lastCheckTime = now;
				CalcTime(Data.BeginTime, Data.EndTime, Period, now, refreshHours, timezoneOffset, out _beginTime, out _endTime);
			}
		}
	}

	public static void CalcTime(List<string> beginTimeConf, List<string> endTimeConf, ActivityPeriod period, DateTimeOffset now, TimeSpan refreshHours, TimeSpan timezoneOffset, out List<DateTimeOffset> beginTime, out List<DateTimeOffset> endTime)
	{
		if (now.Offset != timezoneOffset)
		{
			now = now.ToOffset(timezoneOffset);
		}
		DateTimeOffset refreshTime = GetRefreshTime(period, now, refreshHours, timezoneOffset);
		beginTime = new List<DateTimeOffset>();
		endTime = new List<DateTimeOffset>();
		switch (period)
		{
		case ActivityPeriod.Permanent:
			beginTime.Add(default(DateTimeOffset));
			endTime.Add(default(DateTimeOffset));
			break;
		case ActivityPeriod.Single:
		{
			if (beginTimeConf.Count == 0)
			{
				beginTime.Add(default(DateTimeOffset));
				endTime.Add(default(DateTimeOffset));
				break;
			}
			DateTimeHelper.TryParse(beginTimeConf[0], out var dateTime);
			DateTimeHelper.TryParse(endTimeConf[0], out var dateTime2);
			beginTime.Add(dateTime);
			endTime.Add(dateTime2);
			break;
		}
		case ActivityPeriod.Daily:
		{
			for (int k = 0; k < beginTimeConf.Count; k++)
			{
				string[] array3 = beginTimeConf[k].Split(new char[1] { '|' }, StringSplitOptions.RemoveEmptyEntries);
				if (array3.Length != 2)
				{
					throw new ArgumentException("BeginTime格式错误:" + beginTimeConf[k]);
				}
				int dayOffset = int.Parse(array3[0]);
				string timeStr3 = array3[1];
				ParseDailyTime(timeStr3, dayOffset, refreshTime, out var result5);
				array3 = endTimeConf[k].Split(new char[1] { '|' }, StringSplitOptions.RemoveEmptyEntries);
				if (array3.Length != 2)
				{
					throw new ArgumentException("EndTime格式错误:" + endTimeConf[k]);
				}
				dayOffset = int.Parse(array3[0]);
				timeStr3 = array3[1];
				ParseDailyTime(timeStr3, dayOffset, refreshTime, out var result6);
				beginTime.Add(result5);
				endTime.Add(result6);
				if (result6 > now)
				{
					break;
				}
			}
			break;
		}
		case ActivityPeriod.Weekly:
		{
			for (int j = 0; j < beginTimeConf.Count; j++)
			{
				string[] array2 = beginTimeConf[j].Split(new char[1] { '|' }, StringSplitOptions.RemoveEmptyEntries);
				if (array2.Length != 2)
				{
					throw new ArgumentException("BeginTime格式错误:" + beginTimeConf[j]);
				}
				int dayOfWeek = int.Parse(array2[0]);
				string timeStr2 = array2[1];
				ParseWeeklyTime(timeStr2, dayOfWeek, refreshTime, out var result3);
				array2 = endTimeConf[j].Split(new char[1] { '|' }, StringSplitOptions.RemoveEmptyEntries);
				if (array2.Length != 2)
				{
					throw new ArgumentException("EndTime格式错误:" + endTimeConf[j]);
				}
				dayOfWeek = int.Parse(array2[0]);
				timeStr2 = array2[1];
				ParseWeeklyTime(timeStr2, dayOfWeek, refreshTime, out var result4);
				beginTime.Add(result3);
				endTime.Add(result4);
				if (result4 > now)
				{
					break;
				}
			}
			break;
		}
		case ActivityPeriod.Monthly:
		{
			for (int i = 0; i < beginTimeConf.Count; i++)
			{
				string[] array = beginTimeConf[i].Split(new char[1] { '|' }, StringSplitOptions.RemoveEmptyEntries);
				if (array.Length != 2)
				{
					throw new ArgumentException("BeginTime格式错误:" + beginTimeConf[i]);
				}
				int dayOfMonth = int.Parse(array[0]);
				string timeStr = array[1];
				ParseMonthlyTime(timeStr, dayOfMonth, refreshTime, out var result);
				array = endTimeConf[i].Split(new char[1] { '|' }, StringSplitOptions.RemoveEmptyEntries);
				if (array.Length != 2)
				{
					throw new ArgumentException("EndTime格式错误:" + endTimeConf[i]);
				}
				dayOfMonth = int.Parse(array[0]);
				timeStr = array[1];
				ParseMonthlyTime(timeStr, dayOfMonth, refreshTime, out var result2);
				beginTime.Add(result);
				endTime.Add(result2);
				if (result2 > now)
				{
					break;
				}
			}
			break;
		}
		case ActivityPeriod.NDaysCycle:
			break;
		case ActivityPeriod.Hybrid:
			break;
		default:
			throw new ArgumentOutOfRangeException();
		}
	}

	public DateTimeOffset CurBeginTime(GameManagers managers, DateTimeOffset now)
	{
		ActivityConfig activityConfig = ActivityProgress(managers);
		List<DateTimeOffset> beginTime = BeginTime;
		if (Period == ActivityPeriod.Permanent || Data.DynamicBeginTime)
		{
			return activityConfig.BeginAt;
		}
		DateTimeOffset result = default(DateTimeOffset);
		foreach (DateTimeOffset item in beginTime)
		{
			if (item < now)
			{
				result = item;
				continue;
			}
			break;
		}
		return result;
	}

	public string GetPeriodTimeDesc(bool shortFormat = false)
	{
		return GetPeriodTimeDesc(DateTimeHelper.TimezoneOffset, shortFormat);
	}

	public string GetPeriodTimeDesc(TimeSpan targetTimezoneOffset, bool shortFormat = false)
	{
		switch (Period)
		{
		case ActivityPeriod.Daily:
			return JoinDailyPeriodPieceDesc(targetTimezoneOffset, shortFormat);
		case ActivityPeriod.Weekly:
			return JoinWeeklyPeriodPieceDesc(targetTimezoneOffset, shortFormat);
		case ActivityPeriod.Monthly:
			return JoinMonthlyPeriodPieceDesc(targetTimezoneOffset, shortFormat);
		case ActivityPeriod.Single:
			return JoinSinglePeriodPieceDesc(targetTimezoneOffset, shortFormat);
		case ActivityPeriod.NDaysCycle:
		case ActivityPeriod.Hybrid:
			return JoinNDaysCyclePeriodPieceDesc(targetTimezoneOffset, shortFormat);
		default:
			return "";
		}
	}

	public TimeSpan CurRemainingTime(DateTimeOffset now)
	{
		if (Period == ActivityPeriod.NDaysCycle || Period == ActivityPeriod.Hybrid)
		{
			return GameManagers.Instance.UserArchiveManager.GetActivityProgressOrNew(ActivityId).EndAt.Subtract(now);
		}
		if (Period != ActivityPeriod.Permanent)
		{
			for (int i = 0; i < EndTime.Count; i++)
			{
				DateTimeOffset dateTimeOffset = BeginTime[i];
				DateTimeOffset dateTimeOffset2 = EndTime[i];
				if (now.CompareTo(dateTimeOffset.ToUniversalTime()) >= 0 && now.CompareTo(dateTimeOffset2.ToUniversalTime()) <= 0)
				{
					return dateTimeOffset2.Subtract(now);
				}
			}
		}
		return default(TimeSpan);
	}

	public TimeSpan UnderlineTimeRemaining(DateTimeOffset now)
	{
		if (Period != ActivityPeriod.Permanent)
		{
			DateTimeOffset dateTimeOffset = default(DateTimeOffset);
			List<DateTimeOffset> beginTime = BeginTime;
			List<DateTimeOffset> endTime = EndTime;
			for (int i = 0; i < beginTime.Count; i++)
			{
				if (dateTimeOffset > now)
				{
					break;
				}
				DateTimeOffset dateTimeOffset2 = beginTime[i];
				if (dateTimeOffset2 > now)
				{
					return dateTimeOffset2 - now;
				}
				dateTimeOffset = endTime[i];
			}
		}
		return default(TimeSpan);
	}

	public TimeSpan SettleTimeRemaining(DateTimeOffset now)
	{
		if (Period == ActivityPeriod.Single)
		{
			List<DateTimeOffset> endTime = EndTime;
			if (endTime.Count > 0)
			{
				TimeSpan timeSpan = now - endTime[0].ToUniversalTime();
				TimeSpan timeSpan2 = TimeSpan.FromSeconds(Data.SettleTime);
				return timeSpan2 - timeSpan;
			}
		}
		return default(TimeSpan);
	}

	public Dictionary<string, ActivityContentPayload> ContentPayload(GameManagers gameManagers)
	{
		Dictionary<string, ActivityContentPayload> dictionary = new Dictionary<string, ActivityContentPayload>();
		ActivityContentPayload activityContentPayload = null;
		string key = null;
		foreach (KeyValuePair<string, ActivityContentPayload> item in _contentPayload)
		{
			activityContentPayload = item.Value;
			key = item.Key;
			if (activityContentPayload.CaseConfig == null || CheckContentCase(gameManagers, activityContentPayload.CaseConfig))
			{
				dictionary.Add(key, activityContentPayload);
			}
		}
		if (dictionary.Count < 1 && activityContentPayload != null)
		{
			dictionary.Add(key, activityContentPayload);
		}
		return dictionary;
	}

	public Dictionary<string, ActivityContentPayload> AllContentPayload()
	{
		return _contentPayload;
	}

	public Dictionary<string, List<string>> ContentProgress(GameManagers managers)
	{
		Dictionary<string, ActivityContentPayload> dictionary = ContentPayload(managers);
		if (dictionary == null)
		{
			return null;
		}
		if (ContentType == ActivityContentType.Chapter)
		{
			Dictionary<string, List<string>> dictionary2 = new Dictionary<string, List<string>>();
			foreach (string key in dictionary.Keys)
			{
				dictionary2.Add(key, managers.UserArchiveManager.GetChapterLevelProgress(key, insert: true));
			}
			return dictionary2;
		}
		return null;
	}

	public List<string> UnlockedContent(GameManagers managers)
	{
		List<string> list = new List<string>();
		Dictionary<string, ActivityContentPayload> dictionary = ContentPayload(managers);
		ActivityContentUnlockType contentUnlockType = ContentUnlockType;
		ActivityContentUnlockType activityContentUnlockType = contentUnlockType;
		if (activityContentUnlockType == ActivityContentUnlockType.Sequence)
		{
			if (ContentType == ActivityContentType.Chapter)
			{
				int num = GetUnlockedContentLength(managers);
				if (Type == ActivityType.DefenseInstance || Type == ActivityType.TreasureHunt)
				{
					foreach (Activity item in managers.ActivityManager.GetActivitiesByType(Type, null, isSort: false))
					{
						if (!(item.ActivityId == ActivityId))
						{
							int unlockedContentLength = item.GetUnlockedContentLength(managers);
							if (unlockedContentLength > num)
							{
								num = unlockedContentLength;
							}
						}
					}
				}
				foreach (string key in dictionary.Keys)
				{
					if (!list.Contains(key))
					{
						list.Add(key);
					}
					if (list.Count >= num)
					{
						break;
					}
				}
			}
		}
		else
		{
			list.AddRange(dictionary.Keys);
		}
		return list;
	}

	private Dictionary<string, int> FindValidResetCost(GameManagers managers)
	{
		for (int num = ResetCost.Count - 1; num >= 0; num--)
		{
			Dictionary<string, int> dictionary = ResetCost[num];
			bool flag = true;
			foreach (KeyValuePair<string, int> item in dictionary)
			{
				if (managers.StockController.GetStock(item.Key) >= item.Value)
				{
					continue;
				}
				flag = false;
				break;
			}
			if (flag)
			{
				return dictionary;
			}
		}
		return null;
	}

	public ActivityConfig ActivityProgress(GameManagers managers)
	{
		return managers.UserArchiveManager.GetActivityProgressOrNew(ActivityId);
	}

	public float Score(GameManagers managers)
	{
		int num = 0;
		if (Type != ActivityType.TreasureHunt)
		{
			if (Type == ActivityType.LegendItemLottery)
			{
				if (GameManagers.Instance.ActivityManager.LegendItemLotteryActivityProgresses.TryGetValue(ActivityId, out var value))
				{
					num = value.Score;
				}
			}
			else
			{
				ActivityConfig activityConfig = ActivityProgress(managers);
				num = activityConfig.Score;
			}
		}
		return num;
	}

	public List<float> ClaimProgress(GameManagers managers)
	{
		return ActivityProgress(managers).ClaimProgress;
	}

	public Activity(GDEActivityData data)
	{
		Data = data;
		ResetCost = new List<Dictionary<string, int>>();
		if (!string.IsNullOrEmpty(data.ResetCost))
		{
			ResetCost.AddRange(JsonHelper.ToObject<List<Dictionary<string, int>>>(data.ResetCost));
		}
		LevelCase = new List<string>();
		if (!string.IsNullOrEmpty(data.LevelCase))
		{
			LevelCase.AddRange(JsonHelper.ToObject<List<string>>(data.LevelCase));
		}
		SoldierCase = new Dictionary<string, Dictionary<string, int>>();
		if (!string.IsNullOrEmpty(data.SoldierCase))
		{
			foreach (KeyValuePair<string, Dictionary<string, int>> item in JsonHelper.ToObject<Dictionary<string, Dictionary<string, int>>>(data.SoldierCase))
			{
				SoldierCase.Add(item.Key, item.Value);
			}
		}
		PurchaseCase = new List<string>();
		if (!string.IsNullOrEmpty(data.PurchaseCase))
		{
			PurchaseCase.AddRange(JsonHelper.ToObject<List<string>>(data.PurchaseCase));
		}
		int count = data.BonusExhibition.Count;
		if (count > 0)
		{
			TitleBonus = data.BonusExhibition.First();
			if (count > 1)
			{
				BonusExhibition = data.BonusExhibition.GetRange(1, count - 1);
			}
		}
		BonusProgress = new Dictionary<float, Dictionary<string, float>>();
		if (!string.IsNullOrEmpty(data.BonusProgress))
		{
			foreach (KeyValuePair<float, Dictionary<string, float>> item2 in JsonHelper.ToObject<Dictionary<float, Dictionary<string, float>>>(data.BonusProgress))
			{
				BonusProgress.Add(item2.Key, item2.Value);
			}
			BonusProgressList = new List<BonusPoint>();
			foreach (KeyValuePair<float, Dictionary<string, float>> item3 in BonusProgress)
			{
				BonusProgressList.Add(new BonusPoint
				{
					Score = Mathf.RoundToInt(item3.Key),
					BonusItems = item3.Value
				});
			}
			BonusProgressList.Sort((BonusPoint a, BonusPoint b) => a.Score.CompareTo(b.Score));
		}
		UiParams = new Dictionary<string, object> { { "Activity", this } };
		if (!string.IsNullOrEmpty(Data.UI))
		{
			if (data.UI.Contains('{'))
			{
				int num = data.UI.IndexOf(':');
				UiName = data.UI.Substring(0, num);
				Dictionary<string, object> dictionary = JsonHelper.ToObject<Dictionary<string, object>>(data.UI.Substring(num + 1));
				if (dictionary.Remove("Activity"))
				{
				}
				foreach (KeyValuePair<string, object> item4 in dictionary)
				{
					UiParams.Add(item4.Key, item4.Value);
				}
			}
			else
			{
				UiName = data.UI;
			}
		}
		_ticketPrice = JsonHelper.ToObject<Dictionary<string, float>>(Data.TicketPrice);
		if (!string.IsNullOrEmpty(data.SubActivity))
		{
			ChildIds = data.SubActivity.Split(',').ToList();
		}
		ProcessContentPayload(data.ContentPayload);
	}

	public ActivityStatus GetStatus(GameManagers managers)
	{
		if (managers.UserArchiveManager.TryGetActivityStatus(ActivityId, out var status))
		{
			return status;
		}
		return (ActivityStatus)Data.Status;
	}

	private ActivityStatus CheckPeriodFromProgress(GameManagers managers, DateTimeOffset now, ref bool hasOldStatus)
	{
		ActivityConfig activityConfig = ActivityProgress(managers);
		string[] array = Data.BeginTime.First().Split(new char[1] { '|' }, StringSplitOptions.RemoveEmptyEntries);
		string dateTimeStr = array[0];
		DateTimeOffset dateTimeOffset = DateTimeHelper.Parse(dateTimeStr, now);
		DateTimeOffset dateTimeOffset2 = DateTimeHelper.Parse(Data.EndTime.First(), now);
		if (now < dateTimeOffset || now > dateTimeOffset2)
		{
			return ActivityStatus.Disabled;
		}
		if (activityConfig.BeginAt == default(DateTimeOffset))
		{
			hasOldStatus = false;
			return ActivityStatus.Pending;
		}
		ActivityStatus result;
		if (now < activityConfig.BeginAt)
		{
			result = ActivityStatus.Pending;
		}
		else
		{
			if (now > activityConfig.EndAt)
			{
				hasOldStatus = false;
				return ActivityStatus.Pending;
			}
			result = ActivityStatus.Enabled;
		}
		return result;
	}

	private ActivityStatus CheckPeriodFromConfig(GameManagers managers, DateTimeOffset now, ref bool hasOldStatus)
	{
		ActivityStatus activityStatus = (ActivityStatus)Data.Status;
		if (!hasOldStatus || activityStatus != ActivityStatus.Disabled)
		{
			if (Data.DynamicBeginTime)
			{
				activityStatus = ActivityStatus.Enabled;
			}
			else if (!(ActivityId == "Funds5") || !(UiName == "UI_LegionCultivateFundPanel"))
			{
				TimeSpan timeSpan;
				activityStatus = ((Period == ActivityPeriod.Permanent) ? ActivityStatus.Enabled : (((timeSpan = CurRemainingTime(now)) != default(TimeSpan) && timeSpan.TotalSeconds > 0.0) ? ActivityStatus.Enabled : (((timeSpan = UnderlineTimeRemaining(now)) != default(TimeSpan) && timeSpan.TotalSeconds > 0.0) ? ActivityStatus.Underline : (((timeSpan = SettleTimeRemaining(now)) != default(TimeSpan) && timeSpan.TotalSeconds > 0.0) ? ActivityStatus.Settlement : ActivityStatus.Disabled))));
			}
			else
			{
				string newGuideMode = managers.UserArchiveManager.GetNewGuideMode();
				if (newGuideMode == "New" || newGuideMode == "Default" || newGuideMode == "New2")
				{
					activityStatus = ActivityStatus.Disabled;
				}
			}
		}
		return activityStatus;
	}

	public bool CheckStatus(GameManagers managers, out ActivityStatus newStatus, bool sendEvent)
	{
		DateTimeOffset now = DateTimeHelper.ParseTimeStamp((int)GameController.Instance.GetServerTime());
		ActivityStatus status;
		bool hasOldStatus = managers.UserArchiveManager.TryGetActivityStatus(ActivityId, out status);
		if (Period == ActivityPeriod.Hybrid)
		{
			newStatus = GetStatus(managers);
			return true;
		}
		if (Period == ActivityPeriod.NDaysCycle)
		{
			newStatus = CheckPeriodFromProgress(managers, now, ref hasOldStatus);
		}
		else
		{
			newStatus = CheckPeriodFromConfig(managers, now, ref hasOldStatus);
		}
		if (Type == ActivityType.NeutralDungeonInstance && FGUIManager.Instance.NeutralDungeonData != null && now.CompareTo(FGUIManager.Instance.NeutralDungeonData.CurBeginTime) > -1 && now.CompareTo(FGUIManager.Instance.NeutralDungeonData.CurEndTime) < 1)
		{
			newStatus = ActivityStatus.Enabled;
		}
		if (newStatus == ActivityStatus.Enabled && !CheckEnableCase(managers))
		{
			newStatus = ActivityStatus.Pending;
		}
		if (newStatus == ActivityStatus.Enabled && !CheckContentPayloadCase(managers))
		{
			newStatus = ActivityStatus.Pending;
		}
		newStatus = CheckSpecial(managers, now, hasOldStatus, status, newStatus);
		if (!hasOldStatus || status != newStatus)
		{
			Dictionary<string, ActivityContentPayload> dictionary = ContentPayload(managers);
			if (dictionary != null)
			{
				switch (newStatus)
				{
				case ActivityStatus.Enabled:
					foreach (ActivityContentPayload value in dictionary.Values)
					{
						value.OnBegin(managers);
					}
					break;
				case ActivityStatus.Disabled:
					foreach (ActivityContentPayload value2 in dictionary.Values)
					{
						value2.OnFinish(managers);
					}
					break;
				case ActivityStatus.Pending:
					if ((Period != ActivityPeriod.NDaysCycle && Period != ActivityPeriod.Hybrid) || (hasOldStatus && status != ActivityStatus.Enabled))
					{
						break;
					}
					foreach (ActivityContentPayload value3 in dictionary.Values)
					{
						value3.OnFinish(managers);
					}
					break;
				}
			}
			managers.UserArchiveManager.SetActivityProgress(ActivityProgress(managers));
			managers.UserArchiveManager.SetActivityStatus(ActivityId, newStatus);
			if (sendEvent)
			{
				managers.Messenger.Broadcast("ACTIVITY_STATUS_CHANGED", ActivityId, (int)newStatus);
				managers.UserArchiveManager.SetActivityProgress(ActivityProgress(managers));
			}
			return true;
		}
		return false;
	}

	private bool CheckContentPayloadCase(GameManagers managers)
	{
		ActivityContentType contentType = ContentType;
		ActivityContentType activityContentType = contentType;
		return true;
	}

	private ActivityStatus CheckSpecial(GameManagers managers, DateTimeOffset now, bool hasStatus, ActivityStatus oldStatus, ActivityStatus newStatus)
	{
		switch (ContentType)
		{
		case ActivityContentType.ChallengeMission:
		{
			if (hasStatus && oldStatus == ActivityStatus.Disabled && newStatus != oldStatus)
			{
				return ActivityStatus.Disabled;
			}
			ActivityConfig activityConfig2 = ActivityProgress(managers);
			if (activityConfig2.EndAt != default(DateTimeOffset) && activityConfig2.EndAt < now)
			{
				return ActivityStatus.Disabled;
			}
			break;
		}
		case ActivityContentType.SoliderDevelop:
		{
			if (hasStatus && oldStatus == ActivityStatus.Disabled && newStatus != oldStatus)
			{
				return ActivityStatus.Disabled;
			}
			ActivityConfig activityConfig = ActivityProgress(managers);
			if (hasStatus && oldStatus == ActivityStatus.Pending && newStatus == ActivityStatus.Enabled)
			{
				SoliderDevelopPayload soliderDevelopPayload = (SoliderDevelopPayload)ContentPayload(GameManagers.Instance).Values.First();
				int period = soliderDevelopPayload.Period;
				DateTimeOffset endAt = now.AddDays(period);
				activityConfig.EndAt = endAt;
				GameManagers.Instance.UserArchiveManager.SetActivityProgress(activityConfig);
			}
			if (activityConfig.EndAt != default(DateTimeOffset) && activityConfig.EndAt < now)
			{
				return ActivityStatus.Disabled;
			}
			break;
		}
		}
		return newStatus;
	}

	public bool CheckOverPeriod(GameManagers managers)
	{
		DateTimeOffset now = DateTimeHelper.Parse((int)GameController.Instance.GetServerTime());
		TimeSpan refreshHours = DateTimeHelper.RefreshHours;
		TimeSpan timezoneOffset = DateTimeHelper.TimezoneOffset;
		List<string> value = managers.ActivityManager.DefaultActivities.GetValue();
		Dictionary<string, Dictionary<string, List<string>>> value2 = managers.ActivityManager.DefaultActivityContent.GetValue();
		if (value.Contains(ActivityId) || value2.ContainsKey(ActivityId))
		{
			return false;
		}
		DateTimeOffset refreshTime = GetRefreshTime(Period, now, refreshHours, timezoneOffset);
		switch (Period)
		{
		case ActivityPeriod.NDaysCycle:
			return false;
		case ActivityPeriod.Hybrid:
			return false;
		default:
			return false;
		case ActivityPeriod.Daily:
		case ActivityPeriod.Weekly:
		case ActivityPeriod.Monthly:
			return ActivityProgress(managers).PeriodStartAt < refreshTime;
		}
	}

	public bool CheckCooldown(GameManagers managers, DateTimeOffset now = default(DateTimeOffset))
	{
		if (now == default(DateTimeOffset))
		{
			now = DateTimeHelper.Now;
		}
		foreach (ActivityContentPayload value in ContentPayload(managers).Values)
		{
			if (!(value is ChapterActivityPayload { CooldownPeriod: >0 } chapterActivityPayload))
			{
				continue;
			}
			ActivityConfig activityProgress = ActivityProgress(managers);
			List<KeyValuePair<string, LevelStatus>> levelProgressRecord = chapterActivityPayload.GetLevelProgressRecord(activityProgress);
			DateTimeOffset[] array = chapterActivityPayload.GetLevelCooldownRecord(activityProgress).Values.ToArray();
			for (int i = 0; i < array.Length; i++)
			{
				DateTimeOffset dateTimeOffset = array[i];
				if (dateTimeOffset.CompareTo(now) <= 0 && levelProgressRecord[i].Value == LevelStatus.Completed)
				{
					return true;
				}
			}
		}
		return false;
	}

	public int CheckAutoFill(GameManagers managers, DateTimeOffset now = default(DateTimeOffset))
	{
		if (!AutoFillTicket)
		{
			return 0;
		}
		if (TicketFillPeriod <= 0)
		{
			return 0;
		}
		if (now == default(DateTimeOffset))
		{
			now = DateTimeHelper.Now;
		}
		ActivityConfig activityConfig = ActivityProgress(managers);
		if (activityConfig.LastAutoFillAt == default(DateTimeOffset))
		{
			activityConfig.LastAutoFillAt = now;
			return 0;
		}
		int num = (int)(now - activityConfig.LastAutoFillAt).TotalSeconds;
		if (num <= 0)
		{
			return 0;
		}
		int num2 = num / TicketFillPeriod;
		return (TicketFillQuantity > 0) ? (num2 * TicketFillQuantity) : TicketLimit;
	}

	public bool CheckEnableCase(GameManagers managers)
	{
		Dictionary<string, List<string>> levelProgress = managers.UserArchiveManager.GetLevelProgress();
		int num = LevelCase.Count;
		List<string> excludeLevelCaseActivities = managers.UserArchiveManager.GetExcludeLevelCaseActivities();
		if (!excludeLevelCaseActivities.Contains(ActivityId))
		{
			foreach (List<string> value5 in levelProgress.Values)
			{
				foreach (string item in value5)
				{
					if (LevelCase.Contains(item) && --num == 0)
					{
						break;
					}
				}
				if (num == 0)
				{
					break;
				}
			}
			if (num > 0)
			{
				return false;
			}
		}
		foreach (KeyValuePair<string, Dictionary<string, int>> item2 in SoldierCase)
		{
			string key = item2.Key;
			List<string> unlockedSoldiers = managers.UserArchiveManager.GetUnlockedSoldiers();
			if (!unlockedSoldiers.Contains(key))
			{
				return false;
			}
			Dictionary<string, int> value = item2.Value;
			if (value.TryGetValue("Level", out var value2) && managers.UserArchiveManager.GetSoldierLevel(key) < value2)
			{
				return false;
			}
			if (value.TryGetValue("EvoLevel", out var value3) && managers.UserArchiveManager.GetSoldierEvolutionLevel(key) < value3)
			{
				return false;
			}
		}
		Dictionary<string, int> purchaseStat = managers.StoreManager.PurchaseStat.GetValue().PurchaseStat;
		foreach (string item3 in PurchaseCase)
		{
			if (!purchaseStat.TryGetValue(item3, out var value4) || value4 < 1)
			{
				return false;
			}
		}
		return true;
	}

	private string JoinDailyPeriodPieceDesc(TimeSpan targetTimezoneOffset, bool shortFormat = false, string splitter = "，")
	{
		string text = LanguagesManager.GetDesc("CsharpCodeZhTcText813");
		List<DateTimeOffset> beginTime = BeginTime;
		List<DateTimeOffset> endTime = EndTime;
		int count = beginTime.Count;
		int num = 0;
		while (num < count)
		{
			DateTimeOffset dateTimeOffset = beginTime[num];
			DateTimeOffset dateTimeOffset2 = endTime[num];
			if (dateTimeOffset.Offset != targetTimezoneOffset)
			{
				dateTimeOffset = dateTimeOffset.ToOffset(targetTimezoneOffset);
			}
			if (dateTimeOffset2.Offset != targetTimezoneOffset)
			{
				dateTimeOffset2 = dateTimeOffset2.ToOffset(targetTimezoneOffset);
			}
			bool flag = dateTimeOffset2.Day != dateTimeOffset.Day;
			string text2 = dateTimeOffset.ToString("HH:mm:ss");
			string text3 = dateTimeOffset2.ToString("HH:mm:ss");
			if (text2 == "00:00:00" && text3 == "23:59:59")
			{
				text2 = "";
				text3 = "";
			}
			if (text2.EndsWith(":00"))
			{
				text2 = text2.ReplaceFirst(":00", "");
			}
			if (text3.EndsWith(":00"))
			{
				text3 = text3.ReplaceFirst(":00", "");
			}
			text = text + text2 + "~" + (flag ? LanguagesManager.GetDesc("CsharpCodeZhTcText814") : "") + text3;
			if (++num < count)
			{
				text += splitter;
			}
		}
		return text;
	}

	private string JoinNDaysUniversal(TimeSpan targetTimezoneOffset)
	{
		DateTimeOffset dateTimeOffset = GameManagers.Instance.UserArchiveManager.GetActivityProgressOrNew(ActivityId).BeginAt;
		DateTimeOffset dateTimeOffset2 = GameManagers.Instance.UserArchiveManager.GetActivityProgressOrNew(ActivityId).EndAt;
		if (dateTimeOffset.Offset != targetTimezoneOffset)
		{
			dateTimeOffset = dateTimeOffset.ToOffset(targetTimezoneOffset);
		}
		if (dateTimeOffset2.Offset != targetTimezoneOffset)
		{
			dateTimeOffset2 = dateTimeOffset2.ToOffset(targetTimezoneOffset);
		}
		return UiHelper.GetDateStringMMddHH(dateTimeOffset.DateTime) + " ~ " + UiHelper.GetDateStringMMddHH(dateTimeOffset2.DateTime);
	}

	private string JoinWeeklyPeriodPieceDesc(TimeSpan targetTimezoneOffset, bool shortFormat = false, string splitter = "，")
	{
		string text = LanguagesManager.GetDesc("CsharpCodeZhTcText815");
		int count = BeginTime.Count;
		int num = 0;
		while (num < count)
		{
			DateTimeOffset dateTimeOffset = BeginTime[num];
			DateTimeOffset dateTimeOffset2 = EndTime[num];
			if (dateTimeOffset.Offset != targetTimezoneOffset)
			{
				dateTimeOffset = dateTimeOffset.ToOffset(targetTimezoneOffset);
			}
			if (dateTimeOffset2.Offset != targetTimezoneOffset)
			{
				dateTimeOffset2 = dateTimeOffset2.ToOffset(targetTimezoneOffset);
			}
			DayOfWeek dayOfWeek = dateTimeOffset.DayOfWeek;
			DayOfWeek dayOfWeek2 = dateTimeOffset2.DayOfWeek;
			bool flag = dayOfWeek == dayOfWeek2;
			bool flag2 = dayOfWeek2 < dayOfWeek;
			if (shortFormat)
			{
				text = text + LanguagesManager.GetDesc("CsharpCodeZhTcText818") + WeekDayNames[dayOfWeek];
				if (!flag)
				{
					text = text + "~" + (flag2 ? LanguagesManager.GetDesc("CsharpCodeZhTcText236") : "") + LanguagesManager.GetDesc("CsharpCodeZhTcText818") + WeekDayNames[dayOfWeek2];
				}
			}
			else
			{
				string text2 = dateTimeOffset.ToString("HH:mm:ss");
				string text3 = dateTimeOffset2.ToString("HH:mm:ss");
				bool flag3 = false;
				if (text2 == "00:00:00" && text3 == "23:59:59")
				{
					flag3 = true;
					text2 = "";
					text3 = "";
				}
				if (text2.EndsWith(":00"))
				{
					text2 = text2.ReplaceFirst(":00", "");
				}
				if (text3.EndsWith(":00"))
				{
					text3 = text3.ReplaceFirst(":00", "");
				}
				text = text + LanguagesManager.GetDesc("CsharpCodeZhTcText818") + WeekDayNames[dayOfWeek] + text2;
				if (!flag || !flag3)
				{
					text += "~";
				}
				if (!flag)
				{
					text = text + (flag2 ? LanguagesManager.GetDesc("CsharpCodeZhTcText236") : "") + LanguagesManager.GetDesc("CsharpCodeZhTcText818") + WeekDayNames[dayOfWeek2];
				}
				if (!flag3)
				{
					text += text3;
				}
			}
			if (++num < count)
			{
				text += splitter;
			}
		}
		return text;
	}

	private string JoinMonthlyPeriodPieceDesc(TimeSpan targetTimezoneOffset, bool shortFormat = false, string splitter = "，")
	{
		string text = LanguagesManager.GetDesc("CsharpCodeZhTcText816");
		int count = BeginTime.Count;
		int num = 0;
		while (num < count)
		{
			DateTimeOffset dateTimeOffset = BeginTime[num];
			DateTimeOffset dateTimeOffset2 = EndTime[num];
			if (dateTimeOffset.Offset != targetTimezoneOffset)
			{
				dateTimeOffset = dateTimeOffset.ToOffset(targetTimezoneOffset);
			}
			if (dateTimeOffset2.Offset != targetTimezoneOffset)
			{
				dateTimeOffset2 = dateTimeOffset2.ToOffset(targetTimezoneOffset);
			}
			int day = dateTimeOffset.Day;
			int day2 = dateTimeOffset2.Day;
			bool flag = day2 == day;
			bool flag2 = day2 < day;
			if (shortFormat)
			{
				text += string.Format("{0}{1}", day, LanguagesManager.GetDesc("CsharpCodeZhTcText398"));
				if (!flag)
				{
					text += string.Format("~{0}{1}{2}", flag2 ? LanguagesManager.GetDesc("CsharpCodeZhTcText817") : "", day2, LanguagesManager.GetDesc("CsharpCodeZhTcText398"));
				}
			}
			else
			{
				string text2 = dateTimeOffset.ToString("HH:mm:ss");
				string text3 = dateTimeOffset2.ToString("HH:mm:ss");
				bool flag3 = false;
				if (text2 == "00:00:00" && text3 == "23:59:59")
				{
					flag3 = true;
					text2 = "";
					text3 = "";
				}
				if (text2.EndsWith(":00"))
				{
					text2 = text2.ReplaceFirst(":00", "");
				}
				if (text3.EndsWith(":00"))
				{
					text3 = text3.ReplaceFirst(":00", "");
				}
				text += string.Format("{0}{1}{2}", day, LanguagesManager.GetDesc("CsharpCodeZhTcText398"), text2);
				if (!flag || !flag3)
				{
					text += "~";
				}
				if (!flag)
				{
					text += string.Format("{0}{1}{2}{3}", flag2 ? LanguagesManager.GetDesc("CsharpCodeZhTcText236") : "", LanguagesManager.GetDesc("CsharpCodeZhTcText397"), day2, LanguagesManager.GetDesc("CsharpCodeZhTcText398"));
				}
				if (!flag3)
				{
					text += text3;
				}
			}
			if (++num < count)
			{
				text += splitter;
			}
		}
		return text;
	}

	private string JoinNDaysCyclePeriodPieceDesc(TimeSpan targetTimezoneOffset, bool shortFormat = false, string splitter = "，")
	{
		if (HotUpdateProcess.Instance.IsRegionOutCN)
		{
			return JoinNDaysUniversal(targetTimezoneOffset);
		}
		string text = "";
		DateTimeOffset dateTimeOffset = GameManagers.Instance.UserArchiveManager.GetActivityProgressOrNew(ActivityId).BeginAt;
		DateTimeOffset dateTimeOffset2 = GameManagers.Instance.UserArchiveManager.GetActivityProgressOrNew(ActivityId).EndAt;
		if (dateTimeOffset.Offset != targetTimezoneOffset)
		{
			dateTimeOffset = dateTimeOffset.ToOffset(targetTimezoneOffset);
		}
		if (dateTimeOffset2.Offset != targetTimezoneOffset)
		{
			dateTimeOffset2 = dateTimeOffset2.ToOffset(targetTimezoneOffset);
		}
		if (shortFormat)
		{
			text += $"{dateTimeOffset.Month}/{dateTimeOffset.Day}-{dateTimeOffset2.Month}/{dateTimeOffset2.Day}";
		}
		else
		{
			string text2 = dateTimeOffset.ToString("HH:mm:ss");
			string text3 = dateTimeOffset2.ToString("HH:mm:ss");
			if (text2 == "00:00:00" && text3 == "23:59:59")
			{
				text2 = "";
				text3 = "";
			}
			if (text2.EndsWith(":00"))
			{
				text2 = text2.ReplaceFirst(":00", "");
			}
			if (text3.EndsWith(":00"))
			{
				text3 = text3.ReplaceFirst(":00", "");
			}
			text += string.Format("{0}{1}{2}{3}{4}{5}{6}~{7}{8}{9}{10}{11}{12}{13}", dateTimeOffset.Year, LanguagesManager.GetDesc("CsharpCodeZhTcText557"), dateTimeOffset.Month, LanguagesManager.GetDesc("CsharpCodeZhTcText397"), dateTimeOffset.Day, LanguagesManager.GetDesc("CsharpCodeZhTcText398"), text2, dateTimeOffset2.Year, LanguagesManager.GetDesc("CsharpCodeZhTcText557"), dateTimeOffset2.Month, LanguagesManager.GetDesc("CsharpCodeZhTcText397"), dateTimeOffset2.Day, LanguagesManager.GetDesc("CsharpCodeZhTcText398"), text3);
		}
		return text;
	}

	private string JoinSinglePeriodPieceDesc(TimeSpan targetTimezoneOffset, bool shortFormat = false, string splitter = "，")
	{
		string text = "";
		int count = BeginTime.Count;
		int num = 0;
		while (num < count)
		{
			DateTimeOffset dateTimeOffset = BeginTime[num];
			DateTimeOffset dateTimeOffset2 = EndTime[num];
			if (dateTimeOffset.Offset != targetTimezoneOffset)
			{
				dateTimeOffset = dateTimeOffset.ToOffset(targetTimezoneOffset);
			}
			if (dateTimeOffset2.Offset != targetTimezoneOffset)
			{
				dateTimeOffset2 = dateTimeOffset2.ToOffset(targetTimezoneOffset);
			}
			if (shortFormat)
			{
				text += $"{dateTimeOffset.Month}/{dateTimeOffset.Day}-{dateTimeOffset2.Month}/{dateTimeOffset2.Day}";
			}
			else
			{
				string text2 = dateTimeOffset.ToString("HH:mm:ss");
				string text3 = dateTimeOffset2.ToString("HH:mm:ss");
				if (text2 == "00:00:00" && text3 == "23:59:59")
				{
					text2 = "";
					text3 = "";
				}
				if (text2.EndsWith(":00"))
				{
					text2 = text2.ReplaceFirst(":00", "");
				}
				if (text3.EndsWith(":00"))
				{
					text3 = text3.ReplaceFirst(":00", "");
				}
				text += string.Format("{0}{1}{2}{3}{4}{5}{6}~{7}{8}{9}{10}{11}{12}{13}", dateTimeOffset.Year, LanguagesManager.GetDesc("CsharpCodeZhTcText557"), dateTimeOffset.Month, LanguagesManager.GetDesc("CsharpCodeZhTcText397"), dateTimeOffset.Day, LanguagesManager.GetDesc("CsharpCodeZhTcText398"), text2, dateTimeOffset2.Year, LanguagesManager.GetDesc("CsharpCodeZhTcText557"), dateTimeOffset2.Month, LanguagesManager.GetDesc("CsharpCodeZhTcText397"), dateTimeOffset2.Day, LanguagesManager.GetDesc("CsharpCodeZhTcText398"), text3);
			}
			if (++num < count)
			{
				text += splitter;
			}
		}
		return text;
	}

	public Dictionary<string, int> GetTicketPrice(GameManagers managers, Dictionary<string, int> buffer)
	{
		if (buffer == null)
		{
			buffer = new Dictionary<string, int>();
		}
		else
		{
			buffer.Clear();
		}
		float num = 1f + managers.ModifierManager.GetPercentFloatPayload("ActivityTicketCost");
		foreach (KeyValuePair<string, float> item in _ticketPrice)
		{
			buffer.Add(item.Key, Mathf.RoundToInt(item.Value * num));
		}
		return buffer;
	}

	private void ProcessContentPayload(string payload)
	{
		_contentPayload = new Dictionary<string, ActivityContentPayload>();
		_contentTypeToIds = new Dictionary<string, List<string>>();
		if (string.IsNullOrEmpty(payload))
		{
			return;
		}
		Dictionary<string, Dictionary<string, object>> dictionary = JsonHelper.ToObject<Dictionary<string, Dictionary<string, object>>>(payload);
		List<string> list = dictionary.Keys.ToList();
		ActivityContentPayload activityContentPayload = null;
		string item = null;
		switch (ContentType)
		{
		case ActivityContentType.Chapter:
		{
			DateTimeOffset serverNow = DateTimeHelper.ServerNow;
			foreach (KeyValuePair<string, Dictionary<string, object>> item2 in dictionary)
			{
				string key3 = item2.Key;
				int payloadIndex3 = list.IndexOf(key3);
				Dictionary<string, object> value3 = item2.Value;
				activityContentPayload = new ChapterActivityPayload(payloadIndex3, key3, value3, this);
				item = key3;
				if (((ChapterActivityPayload)activityContentPayload).BeginTime == default(DateTimeOffset))
				{
					_contentPayload.Add(key3, activityContentPayload);
				}
				else if (serverNow.CompareTo(((ChapterActivityPayload)activityContentPayload).BeginTime) > 0 && serverNow.CompareTo(((ChapterActivityPayload)activityContentPayload).EndTime) < 0)
				{
					_contentPayload.Add(key3, activityContentPayload);
				}
			}
			break;
		}
		case ActivityContentType.Lottery:
		case ActivityContentType.UpCardPool:
		case ActivityContentType.NeutralCardPool:
			foreach (KeyValuePair<string, Dictionary<string, object>> item3 in dictionary)
			{
				string key15 = item3.Key;
				Dictionary<string, object> value15 = item3.Value;
				int payloadIndex12 = list.IndexOf(key15);
				activityContentPayload = new LotteryActivityPayload(payloadIndex12, key15, value15, this);
				item = key15;
				_contentPayload.Add(key15, activityContentPayload);
			}
			break;
		case ActivityContentType.Store:
		{
			DateTimeOffset serverNow3 = DateTimeHelper.ServerNow;
			foreach (KeyValuePair<string, Dictionary<string, object>> item4 in dictionary)
			{
				string key14 = item4.Key;
				Dictionary<string, object> value14 = item4.Value;
				int payloadIndex11 = list.IndexOf(key14);
				activityContentPayload = new StoreActivityPayload(payloadIndex11, key14, value14, this);
				item = key14;
				if (((StoreActivityPayload)activityContentPayload).BeginTime == default(DateTimeOffset))
				{
					_contentPayload.Add(key14, activityContentPayload);
				}
				else if (serverNow3.CompareTo(((StoreActivityPayload)activityContentPayload).BeginTime) > 0 && serverNow3.CompareTo(((StoreActivityPayload)activityContentPayload).EndTime) < 0)
				{
					_contentPayload.Add(key14, activityContentPayload);
				}
			}
			break;
		}
		case ActivityContentType.MissionSerial:
			foreach (KeyValuePair<string, Dictionary<string, object>> item5 in dictionary)
			{
				string key13 = item5.Key;
				Dictionary<string, object> value13 = item5.Value;
				int payloadIndex10 = list.IndexOf(key13);
				activityContentPayload = new MissionSerialActivityPayload(payloadIndex10, key13, value13, this);
				item = key13;
				_contentPayload.Add(key13, new MissionSerialActivityPayload(payloadIndex10, key13, value13, this));
			}
			break;
		case ActivityContentType.SignInSerial:
			foreach (KeyValuePair<string, Dictionary<string, object>> item6 in dictionary)
			{
				string key12 = item6.Key;
				Dictionary<string, object> value12 = item6.Value;
				int payloadIndex9 = list.IndexOf(key12);
				activityContentPayload = new SignInSerialActivityPayload(payloadIndex9, key12, value12, this);
				item = key12;
				_contentPayload.Add(key12, activityContentPayload);
			}
			break;
		case ActivityContentType.TreasureHunt:
			foreach (KeyValuePair<string, Dictionary<string, object>> item7 in dictionary)
			{
				string key11 = item7.Key;
				Dictionary<string, object> value11 = item7.Value;
				int payloadIndex8 = list.IndexOf(key11);
				activityContentPayload = new TreasureHuntChapterActivityPayload(payloadIndex8, key11, value11, this);
				item = key11;
				_contentPayload.Add(key11, activityContentPayload);
			}
			break;
		case ActivityContentType.LoopSignInSerial:
			foreach (KeyValuePair<string, Dictionary<string, object>> item8 in dictionary)
			{
				string key10 = item8.Key;
				Dictionary<string, object> value10 = item8.Value;
				int payloadIndex7 = list.IndexOf(key10);
				activityContentPayload = new LoopSignInSerialActivityPayload(payloadIndex7, key10, value10, this);
				_contentPayload.Add(key10, activityContentPayload);
			}
			break;
		case ActivityContentType.BattlePass:
		case ActivityContentType.WeekActPassContent:
			foreach (KeyValuePair<string, Dictionary<string, object>> item9 in dictionary)
			{
				string key9 = item9.Key;
				Dictionary<string, object> value9 = item9.Value;
				int contentPayloadIndex2 = list.IndexOf(key9);
				activityContentPayload = new BattlePassActivityPayload(contentPayloadIndex2, value9, this);
				_contentPayload.Add(key9, activityContentPayload);
			}
			break;
		case ActivityContentType.GvG3BattlePass:
			foreach (KeyValuePair<string, Dictionary<string, object>> item10 in dictionary)
			{
				string key8 = item10.Key;
				Dictionary<string, object> value8 = item10.Value;
				int contentPayloadIndex = list.IndexOf(key8);
				activityContentPayload = new GvG3BattlePassActivityPayload(contentPayloadIndex, value8, this);
				_contentPayload.Add(key8, activityContentPayload);
			}
			break;
		case ActivityContentType.NewbieGACHA:
			foreach (KeyValuePair<string, Dictionary<string, object>> item11 in dictionary)
			{
				string key7 = item11.Key;
				Dictionary<string, object> value7 = item11.Value;
				int payloadIndex6 = list.IndexOf(key7);
				activityContentPayload = new NewbieGACHAActivityPayload(payloadIndex6, key7, value7, this);
				_contentPayload.Add(key7, activityContentPayload);
			}
			break;
		case ActivityContentType.StoreMission:
			foreach (KeyValuePair<string, Dictionary<string, object>> item12 in dictionary)
			{
				string key6 = item12.Key;
				Dictionary<string, object> value6 = item12.Value;
				int payloadIndex5 = list.IndexOf(key6);
				activityContentPayload = new StoreMissionActivityPayload(payloadIndex5, key6, value6, this);
				item = key6;
				_contentPayload.Add(key6, activityContentPayload);
			}
			break;
		case ActivityContentType.TreasureHouseRecharge:
		{
			DateTimeOffset serverNow2 = DateTimeHelper.ServerNow;
			foreach (KeyValuePair<string, Dictionary<string, object>> item13 in dictionary)
			{
				string key5 = item13.Key;
				Dictionary<string, object> value5 = item13.Value;
				activityContentPayload = new TreasureHouseActivityPayload(key5, value5, this);
				if (((TreasureHouseActivityPayload)activityContentPayload).BeginTime == default(DateTimeOffset))
				{
					_contentPayload.Add(key5, activityContentPayload);
				}
				else if (serverNow2.CompareTo(((TreasureHouseActivityPayload)activityContentPayload).BeginTime) > 0 && serverNow2.CompareTo(((TreasureHouseActivityPayload)activityContentPayload).EndTime) < 0)
				{
					_contentPayload.Add(key5, activityContentPayload);
				}
			}
			break;
		}
		case ActivityContentType.ProgressMission:
			ProgressMissionData = new MissionSerialForeignActivityPayload(0, dictionary["成长任务"], this);
			break;
		case ActivityContentType.ChallengeMission:
			ChallengeMissionData = new ChallengeMissionPayload(0, dictionary["挑战任务"], this);
			break;
		case ActivityContentType.StoreContentConfig:
			foreach (KeyValuePair<string, Dictionary<string, object>> item14 in dictionary)
			{
				string key4 = item14.Key;
				Dictionary<string, object> value4 = item14.Value;
				int payloadIndex4 = list.IndexOf(key4);
				activityContentPayload = new StoreContentConfigActivityPayload(payloadIndex4, key4, value4, this);
				_contentPayload.Add(key4, activityContentPayload);
			}
			break;
		case ActivityContentType.SoliderDevelop:
			foreach (KeyValuePair<string, Dictionary<string, object>> item15 in dictionary)
			{
				string key2 = item15.Key;
				Dictionary<string, object> value2 = item15.Value;
				int payloadIndex2 = list.IndexOf(key2);
				activityContentPayload = new SoliderDevelopPayload(payloadIndex2, key2, value2, this, payload);
				_contentPayload.Add(key2, activityContentPayload);
			}
			ActivityManager.ShadowDemonGift = this;
			break;
		case ActivityContentType.WarOfRealm:
			foreach (KeyValuePair<string, Dictionary<string, object>> item16 in dictionary)
			{
				string key = item16.Key;
				Dictionary<string, object> value = item16.Value;
				int payloadIndex = list.IndexOf(key);
				activityContentPayload = new WarOfRealmPayload(payloadIndex, key, value, this);
				_contentPayload.Add(key, activityContentPayload);
			}
			break;
		}
		string text = activityContentPayload?.Type;
		if (!string.IsNullOrEmpty(text))
		{
			if (!_contentTypeToIds.TryGetValue(text, out var value16))
			{
				value16 = new List<string>();
				_contentTypeToIds.Add(text, value16);
			}
			value16.Add(item);
		}
	}

	private bool CheckContentCase(GameManagers managers, Dictionary<string, List<float>> caseDict)
	{
		foreach (KeyValuePair<string, List<float>> item in caseDict)
		{
			if (item.Value.Count != 2)
			{
				return false;
			}
			string key = item.Key;
			string text = key;
			float num;
			if (!(text == "BattlePower"))
			{
				if (!(text == "ClearStages"))
				{
					return false;
				}
				num = managers.ChapterManager.GetTotalClearStagesUntilLastCheckByActivity(ActivityId);
			}
			else
			{
				num = managers.SoldierManager.LegionPowerConfig.GetValue().MaxPower;
			}
			if (num < item.Value[0] || num > item.Value[1])
			{
				return false;
			}
		}
		return true;
	}

	public int GetUnlockedContentLength(GameManagers managers)
	{
		Dictionary<string, ActivityContentPayload> dictionary = ContentPayload(managers);
		if (ContentUnlockType == ActivityContentUnlockType.Free)
		{
			return dictionary.Count;
		}
		if (ContentType == ActivityContentType.Chapter)
		{
			int result = 1;
			int num = 0;
			foreach (string key in dictionary.Keys)
			{
				num++;
				if (managers.ChapterManager.IsChapterDone(key))
				{
					result = num + 1;
				}
			}
			return result;
		}
		return 0;
	}

	public bool HasAnyNewMsg(GameManagers managers)
	{
		ActivityStatus status = GetStatus(managers);
		if ((status == ActivityStatus.Enabled || status == ActivityStatus.Settlement) && CanClaimBonus(managers))
		{
			return true;
		}
		if (status != ActivityStatus.Enabled)
		{
			return false;
		}
		ActivityConfig activityConfig = ActivityProgress(managers);
		if (activityConfig.IsNew)
		{
			return true;
		}
		if (CanClaimBonus(managers))
		{
			return true;
		}
		if (ContentType == ActivityContentType.Chapter && !string.IsNullOrEmpty(TicketItem) && TicketLimit > 0 && managers.StockController.GetStock(TicketItem) >= TicketLimit)
		{
			return true;
		}
		foreach (KeyValuePair<string, ActivityContentPayload> item in ContentPayload(managers))
		{
			ActivityContentPayload value = item.Value;
			if (value.HasAnyNewMsg(managers))
			{
				return true;
			}
		}
		return false;
	}

	public bool CanBuyTicket()
	{
		return _ticketPrice != null;
	}

	public int BuyTicket(GameManagers managers, int qty = 1)
	{
		if (!CanBuyTicket())
		{
			return 0;
		}
		int num = managers.StockController.GetStock(TicketItem) + qty - TicketLimit;
		if (num > 0)
		{
			qty -= num;
		}
		if (qty <= 0)
		{
			return 0;
		}
		PooledDictionary<string, int> buffer = ObjectPool<PooledDictionary<string, int>>.Spawn((Func<PooledDictionary<string, int>>)(() => new PooledDictionary<string, int>()));
		buffer = (PooledDictionary<string, int>)(object)GetTicketPrice(managers, (Dictionary<string, int>)(object)buffer);
		Dictionary<string, int> dictionary = new Dictionary<string, int>();
		foreach (KeyValuePair<string, int> item in (Dictionary<string, int>)(object)buffer)
		{
			int num2 = item.Value * qty;
			if (managers.StockController.GetStock(item.Key) < num2)
			{
				return 0;
			}
			dictionary.Add(item.Key, item.Value * qty);
		}
		buffer.UnSpawn();
		foreach (KeyValuePair<string, int> item2 in dictionary)
		{
			managers.StockController.IncrStock(item2.Key, -item2.Value, StockInContext.Redeem, ActivityId);
		}
		managers.StockController.AddStock(TicketItem, qty, StockInContext.Ticket, ActivityId);
		return qty;
	}

	public bool CanPlay(GameManagers managers, string contentId = null)
	{
		if (GetStatus(managers) != ActivityStatus.Enabled)
		{
			return false;
		}
		if (contentId == null)
		{
			Dictionary<string, ActivityContentPayload> contentPayloads = ContentPayload(GameManagers.Instance);
			if (contentPayloads.Count < 1)
			{
				return false;
			}
			if (contentPayloads.Keys.All((string _contentId) => !contentPayloads.TryGetValue(_contentId, out var value2) || managers.StockController.GetStock(TicketItem) < ((ChapterActivityPayload)value2).Tickets))
			{
				return false;
			}
			List<string> unlockedContents = UnlockedContent(managers);
			if (!contentPayloads.Keys.Any((string _contentId) => unlockedContents.Contains(_contentId)))
			{
				return false;
			}
		}
		else
		{
			if (!UnlockedContent(managers).Contains(contentId))
			{
				return false;
			}
			if (ContentType == ActivityContentType.Chapter && (!ContentPayload(managers).TryGetValue(contentId, out var value) || managers.StockController.GetStock(TicketItem) < ((ChapterActivityPayload)value).Tickets))
			{
				return false;
			}
		}
		return true;
	}

	public bool CanClaimBonus(GameManagers managers)
	{
		float num = Score(managers);
		foreach (KeyValuePair<float, Dictionary<string, float>> item in BonusProgress)
		{
			if (item.Key > num || ClaimProgress(managers).Contains(item.Key))
			{
				continue;
			}
			return true;
		}
		return false;
	}

	public void ClaimBonus(GameManagers managers, ref Dictionary<string, float> claimed, string node = "", int nodeV2 = -1)
	{
		switch (ContentType)
		{
		case ActivityContentType.Lottery:
		case ActivityContentType.UpCardPool:
		case ActivityContentType.NeutralCardPool:
			LotteryClaimBonus(managers, ref claimed);
			break;
		case ActivityContentType.BattlePass:
			BattlePassClaimBonus(managers, node, ref claimed);
			break;
		case ActivityContentType.WeekActPassContent:
			BattlePassClaimBonusV2(managers, nodeV2, ref claimed);
			break;
		case ActivityContentType.GvG3BattlePass:
			break;
		default:
			CommonClaimBonus(managers, ref claimed);
			break;
		}
	}

	private void BattlePassClaimAllUnclaimedBonus(GameManagers managers, ref Dictionary<string, float> claimed)
	{
		Dictionary<string, ActivityContentPayload>.Enumerator enumerator = _contentPayload.GetEnumerator();
		enumerator.MoveNext();
		if (!(enumerator.Current.Value is BattlePassActivityPayload battlePassActivityPayload))
		{
			return;
		}
		ActivityConfig activityConfig = ActivityProgress(managers);
		List<int> list = new List<int>();
		list.AddRange(battlePassActivityPayload.BonusConfig.Keys);
		int stock = managers.StockController.GetStock(battlePassActivityPayload.ScoreItem);
		List<int> list2 = new List<int>();
		foreach (int item in list)
		{
			bool flag = false;
			foreach (float item2 in activityConfig.ClaimProgress)
			{
				if (Math.Round(item2) == (double)item)
				{
					flag = true;
					break;
				}
			}
			if (!flag && stock >= item)
			{
				list2.Add(item);
			}
		}
		foreach (int item3 in list2)
		{
			int num = battlePassActivityPayload.ClaimBonus(managers, new List<int> { item3 }, ref claimed);
			if (num == 0)
			{
				foreach (KeyValuePair<string, float> item4 in claimed)
				{
					activityConfig.ClaimProgress.Add(item3);
				}
				claimed.Clear();
				continue;
			}
			ILRequestHelper.ShowErrorCode(num);
			break;
		}
		managers.UserArchiveManager.SetActivityProgress(activityConfig);
	}

	private void BattlePassClaimBonus(GameManagers managers, string node, ref Dictionary<string, float> claimed)
	{
		Dictionary<string, ActivityContentPayload>.Enumerator enumerator = _contentPayload.GetEnumerator();
		enumerator.MoveNext();
		if (!(enumerator.Current.Value is BattlePassActivityPayload battlePassActivityPayload))
		{
			return;
		}
		if (string.IsNullOrEmpty(node))
		{
			BattlePassClaimAllUnclaimedBonus(managers, ref claimed);
			return;
		}
		ActivityConfig activityConfig = ActivityProgress(managers);
		NumericParser.TryFloat(node, out var value);
		if (activityConfig.ClaimProgress.IndexOf(value) >= 0)
		{
			return;
		}
		int num = battlePassActivityPayload.ClaimBonus(managers, new List<int> { (int)value }, ref claimed);
		if (num == 0)
		{
			foreach (KeyValuePair<string, float> item in claimed)
			{
				activityConfig.ClaimProgress.Add(value);
			}
			managers.UserArchiveManager.SetActivityProgress(activityConfig);
		}
		else
		{
			ILRequestHelper.ShowErrorCode(num);
		}
	}

	public void BattlePassClaimBonusV2(GameManagers managers, int node, ref Dictionary<string, float> claimed)
	{
		Dictionary<string, ActivityContentPayload>.Enumerator enumerator = _contentPayload.GetEnumerator();
		enumerator.MoveNext();
		if (!(enumerator.Current.Value is BattlePassActivityPayload battlePassActivityPayload))
		{
			return;
		}
		if (node < 0)
		{
			BattlePassClaimAllUnclaimedBonus(managers, ref claimed);
			return;
		}
		ActivityConfig activityConfig = ActivityProgress(managers);
		if (activityConfig.ClaimProgress.IndexOf(node) >= 0)
		{
			return;
		}
		int num = battlePassActivityPayload.ClaimBonus(managers, new List<int> { node }, ref claimed);
		if (num == 0)
		{
			foreach (KeyValuePair<string, float> item in claimed)
			{
				activityConfig.ClaimProgress.Add(node);
			}
			managers.UserArchiveManager.SetActivityProgress(activityConfig);
		}
		else
		{
			ILRequestHelper.ShowErrorCode(num);
		}
	}

	private void LotteryClaimBonus(GameManagers managers, ref Dictionary<string, float> claimed)
	{
		float num = Score(managers);
		float[] array = BonusProgress.Keys.ToArray();
		if (array.Length < 1)
		{
			return;
		}
		for (int i = array.Length - 1; i >= 0; i++)
		{
			float num2 = array[i];
			if (num2 > num)
			{
				continue;
			}
			Dictionary<string, float> dictionary = BonusProgress[num2];
			foreach (KeyValuePair<string, float> item in dictionary)
			{
				string key = item.Key;
				float value = item.Value;
				managers.StockController.IncrStock(key, value, StockInContext.Bonus, ActivityId);
				if (claimed.ContainsKey(key))
				{
					claimed[key] += value;
				}
				else
				{
					claimed.Add(key, value);
				}
			}
			ActivityConfig activityConfig = ActivityProgress(managers);
			activityConfig.Score -= (int)num2;
			managers.UserArchiveManager.SetActivityProgress(activityConfig);
			break;
		}
	}

	private void CommonClaimBonus(GameManagers managers, ref Dictionary<string, float> claimed)
	{
		float num = Score(managers);
		foreach (KeyValuePair<float, Dictionary<string, float>> item in BonusProgress)
		{
			if (item.Key > num)
			{
				break;
			}
			if (ClaimProgress(managers).Contains(item.Key))
			{
				continue;
			}
			foreach (KeyValuePair<string, float> item2 in item.Value)
			{
				Bonus bonus = Bonus.Get(item2.Key, item2.Value);
				bonus.Claim(managers, claimed);
			}
			ClaimProgress(managers).Add(item.Key);
			managers.UserArchiveManager.SetActivityProgress(ActivityProgress(managers));
			break;
		}
	}

	public void FillTickets(GameManagers managers, int cnt, bool force = false)
	{
		if (cnt + managers.StockController.GetStock(TicketItem) > TicketLimit)
		{
			cnt = TicketLimit - managers.StockController.GetStock(TicketItem);
		}
		if (cnt > 0)
		{
			if (force)
			{
				managers.StockController.IncrStock(TicketItem, cnt, StockInContext.AutoFill, ActivityId);
			}
			else
			{
				managers.StockController.AddStock(TicketItem, cnt, StockInContext.AutoFill, ActivityId);
			}
		}
	}

	public bool CanReset(GameManagers managers, List<string> resetCostItems, out Dictionary<string, int> resetCostConfig)
	{
		resetCostConfig = null;
		if (!Data.CanReset)
		{
			return false;
		}
		if (ResetCost.Count < 1)
		{
			return true;
		}
		if (resetCostItems == null || resetCostItems.Count < 1)
		{
			resetCostConfig = FindValidResetCost(managers);
			return resetCostConfig != null;
		}
		foreach (Dictionary<string, int> item in ResetCost)
		{
			if (item.Count != resetCostItems.Count || item.Keys.Any((string itemId) => !resetCostItems.Contains(itemId)))
			{
				continue;
			}
			resetCostConfig = item;
			using Dictionary<string, int>.Enumerator enumerator2 = item.GetEnumerator();
			if (enumerator2.MoveNext())
			{
				KeyValuePair<string, int> current2 = enumerator2.Current;
				if (managers.StockController.GetStock(current2.Key) < current2.Value)
				{
					return false;
				}
				return true;
			}
		}
		return false;
	}

	private void ConsumeReset(GameManagers managers, Dictionary<string, int> costDict = null)
	{
		if (costDict == null || costDict.Count < 1)
		{
			return;
		}
		StockChangeRecord[] array = new StockChangeRecord[costDict.Count];
		int num = 0;
		foreach (KeyValuePair<string, int> item in costDict)
		{
			array[num++] = new StockChangeRecord
			{
				ItemId = item.Key,
				Offset = -item.Value,
				Context = 14,
				ContextValue = ActivityId,
				Type = 1
			};
		}
		managers.StockController.ReadStockChangeRecords(array);
	}

	public bool Reset(GameManagers managers, List<string> costItems = null, bool autoReset = false, object injectConfig = null)
	{
		if (!CanReset(managers, costItems, out var resetCostConfig) && !autoReset)
		{
			return false;
		}
		if (!autoReset)
		{
			ConsumeReset(managers, resetCostConfig);
			List<string> value = managers.ActivityManager.DefaultActivities.GetValue();
			if (value.Remove(ActivityId))
			{
				managers.ActivityManager.DefaultActivities.Save();
			}
			Dictionary<string, Dictionary<string, List<string>>> value2 = managers.ActivityManager.DefaultActivityContent.GetValue();
			if (value2.Remove(ActivityId))
			{
				managers.ActivityManager.DefaultActivityContent.Save();
			}
		}
		Dictionary<string, ActivityContentPayload> dictionary = ContentPayload(managers);
		if (dictionary != null)
		{
			foreach (KeyValuePair<string, ActivityContentPayload> item in dictionary)
			{
				item.Value.BeforeReset(managers, autoReset);
			}
		}
		ActivityProgress(managers).Reset(autoReset, injectConfig);
		managers.UserArchiveManager.SetActivityProgress(ActivityProgress(managers));
		dictionary = ContentPayload(managers);
		if (dictionary != null)
		{
			foreach (KeyValuePair<string, ActivityContentPayload> item2 in dictionary)
			{
				item2.Value.AfterReset(managers);
			}
		}
		managers.ActivityManager.StatsReset(ActivityId, resetCostConfig);
		managers.Messenger.Broadcast("ACTIVITY_RESET", this, autoReset);
		return true;
	}

	public bool IsCompleted()
	{
		return UiName switch
		{
			"UI_SignInPanel" => SignInActivityIsCompleted(), 
			"UI_FirstTimeRewardPanel" => FirstAndNoviceRechargeActivityIsCompleted(), 
			"UI_LegionCultivateFundPanel" => LegionCultivateFundActivityIsCompleted(), 
			"UI_SevenDaysMissionPanel" => SevenDaysMissionActivityIsCompleted(), 
			_ => false, 
		};
	}

	private bool SignInActivityIsCompleted()
	{
		if (ContentType != ActivityContentType.SignInSerial)
		{
			return false;
		}
		SignInSerialActivityPayload signInSerialActivityPayload = (SignInSerialActivityPayload)ContentPayload(GameManagers.Instance).Values.First();
		bool flag = signInSerialActivityPayload.CanSignIn(GameManagers.Instance);
		int num = signInSerialActivityPayload.TotalSignInCount(GameManagers.Instance);
		int num2 = (flag ? (num + 1) : num);
		if (num2 >= signInSerialActivityPayload.SignInList.Count && !flag && !CanClaimBonus(GameManagers.Instance))
		{
			return true;
		}
		return false;
	}

	private bool FirstAndNoviceRechargeActivityIsCompleted()
	{
		return FirstRechargeActivityIsCompleted() && NoviceRechargeActivityIsCompleted();
	}

	private static bool NoviceRechargeActivityIsCompleted()
	{
		return FGUIManager.Instance.NoviceRechargeData?.Progress.Values.All((ContinuousRechargeBonus bonus) => bonus.BonusStatus == BonusStatus.HasClaimedBonus) ?? true;
	}

	private bool FirstRechargeActivityIsCompleted()
	{
		if (ContentType != ActivityContentType.MissionSerial)
		{
			return false;
		}
		if (GetStatus(GameManagers.Instance) == ActivityStatus.Disabled)
		{
			return true;
		}
		MissionSerialActivityPayload missionSerialActivityPayload = (MissionSerialActivityPayload)ContentPayload(GameManagers.Instance).Values.First();
		return (from mission in missionSerialActivityPayload.Missions(GameManagers.Instance)
			select mission.MissionState(GameManagers.Instance).Status).All((MissionStatus status) => status == MissionStatus.Claimed);
	}

	private bool LegionCultivateFundActivityIsCompleted()
	{
		if (ContentType != ActivityContentType.MissionSerial)
		{
			return false;
		}
		if (GetStatus(GameManagers.Instance) == ActivityStatus.Disabled)
		{
			return true;
		}
		MissionSerialActivityPayload missionSerialActivityPayload = (MissionSerialActivityPayload)ContentPayload(GameManagers.Instance).Values.First();
		return (from mission in missionSerialActivityPayload.Missions(GameManagers.Instance)
			select mission.MissionState(GameManagers.Instance).Status).All((MissionStatus status) => status == MissionStatus.Claimed);
	}

	private bool SevenDaysMissionActivityIsCompleted()
	{
		if (ContentType != ActivityContentType.MissionSerial)
		{
			return false;
		}
		foreach (ActivityContentPayload value in ContentPayload(GameManagers.Instance).Values)
		{
			MissionSerialActivityPayload missionSerialActivityPayload = (MissionSerialActivityPayload)value;
			if (missionSerialActivityPayload == null || missionSerialActivityPayload.AllBonusClaimed(GameManagers.Instance))
			{
				continue;
			}
			return false;
		}
		return true;
	}
}
