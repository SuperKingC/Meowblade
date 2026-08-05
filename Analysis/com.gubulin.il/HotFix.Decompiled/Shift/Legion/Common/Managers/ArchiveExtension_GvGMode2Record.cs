using System;
using System.Collections.Generic;
using System.Linq;
using HotFix.Sources.Shift.Legion.Shift.Legion.Common.Sources.Models;

namespace Shift.Legion.Common.Managers;

public static class ArchiveExtension_GvGMode2Record
{
	public class Model
	{
		public Dictionary<string, Record> Records;
	}

	public class Record
	{
		public int IZId;

		public bool HasReadResult = false;
	}

	public class GvGMode2DailyRecord
	{
		public List<int> DailyMissionRecord { get; set; } = new List<int>();

		public List<string> IZIDRecord { get; set; } = new List<string>();
	}

	public const string IslandComeAgainDailyMissionRecord = "IslandComeAgainDailyMissionRecord";

	public const string IslandComeAgainRecord = "IslandComeAgainRecord";

	private static string GvGMode2RecordKey = "GvGMode2Record2024";

	private static void EnsureNewGuideMode(this UserArchiveManager manager)
	{
		if (!manager.Contains(GvGMode2RecordKey))
		{
			manager.saveGvGMode2Record(new Model
			{
				Records = new Dictionary<string, Record>()
			});
		}
	}

	private static void saveGvGMode2Record(this UserArchiveManager manager, Model _model)
	{
		manager.SetConfigValue(GvGMode2RecordKey, _model);
	}

	private static Record getGvGMode2Record(this UserArchiveManager manager, int IZId)
	{
		manager.EnsureNewGuideMode();
		Model configValue = manager.GetConfigValue<Model>(GvGMode2RecordKey);
		if (configValue.Records.TryGetValue(IZId.ToString(), out var value))
		{
			return value;
		}
		return null;
	}

	private static void addGvGMode2Record(this UserArchiveManager manager, int IZId)
	{
		manager.EnsureNewGuideMode();
		Model configValue = manager.GetConfigValue<Model>(GvGMode2RecordKey);
		if (!configValue.Records.ContainsKey(IZId.ToString()))
		{
			configValue.Records.Add(IZId.ToString(), new Record
			{
				IZId = IZId,
				HasReadResult = false
			});
		}
		manager.saveGvGMode2Record(configValue);
	}

	public static bool AddGvGMode2Record(this UserArchiveManager manager, int IZId)
	{
		Record gvGMode2Record = manager.getGvGMode2Record(IZId);
		if (gvGMode2Record == null)
		{
			manager.addGvGMode2Record(IZId);
			return true;
		}
		return false;
	}

	public static void SetReadGvGMode2Result(this UserArchiveManager manager, int IZId)
	{
		Record gvGMode2Record = manager.getGvGMode2Record(IZId);
		if (gvGMode2Record != null)
		{
			gvGMode2Record.HasReadResult = true;
		}
	}

	public static List<int> GetLatestGvGMode2Results(this UserArchiveManager manager, int cnt = 3)
	{
		manager.EnsureNewGuideMode();
		Model configValue = manager.GetConfigValue<Model>(GvGMode2RecordKey);
		return (from _r in configValue.Records.Values.OrderByDescending((Record _r) => _r.IZId).Take(cnt)
			select _r.IZId).ToList();
	}

	public static GvGMode2DailyRecord EnsureIslandComeAgainDailyRecord(this UserArchiveManager manager, DateTimeOffset date, out Dictionary<string, GvGMode2DailyRecord> allRecords)
	{
		allRecords = manager.GetIslandComeAgainDailyRecord();
		string key = DateTimeHelper.GetDailyRefreshTime(date).ToString("yyyy-MM-dd HH:mm:ss");
		if (!allRecords.TryGetValue(key, out var value))
		{
			value = new GvGMode2DailyRecord();
			allRecords.Add(key, value);
			manager.SetIslandComeAgainDailyRecord(allRecords);
		}
		return value;
	}

	public static Dictionary<string, GvGMode2DailyRecord> GetIslandComeAgainDailyRecord(this UserArchiveManager manager)
	{
		if (!manager.TryGetConfigValue<Dictionary<string, GvGMode2DailyRecord>>("IslandComeAgainDailyMissionRecord", out var val))
		{
			val = new Dictionary<string, GvGMode2DailyRecord>();
			manager.SetIslandComeAgainDailyRecord(val);
		}
		return val;
	}

	public static List<string> GetTodayIZIDRecord(this UserArchiveManager manager)
	{
		Dictionary<string, GvGMode2DailyRecord> allRecords;
		GvGMode2DailyRecord gvGMode2DailyRecord = manager.EnsureIslandComeAgainDailyRecord(DateTimeHelper.ServerNow, out allRecords);
		return gvGMode2DailyRecord.IZIDRecord;
	}

	public static List<int> GetTodayIZIDClaimRecord(this UserArchiveManager manager)
	{
		Dictionary<string, GvGMode2DailyRecord> allRecords;
		GvGMode2DailyRecord gvGMode2DailyRecord = manager.EnsureIslandComeAgainDailyRecord(DateTimeHelper.ServerNow, out allRecords);
		return gvGMode2DailyRecord.DailyMissionRecord;
	}

	public static void AddTodayIZIDRecord(this UserArchiveManager manager, string IZID)
	{
		Dictionary<string, GvGMode2DailyRecord> allRecords;
		GvGMode2DailyRecord gvGMode2DailyRecord = manager.EnsureIslandComeAgainDailyRecord(DateTimeHelper.ServerNow, out allRecords);
		if (gvGMode2DailyRecord.IZIDRecord.Contains(IZID))
		{
			ILRuntimeDebug.LogError("[IslandComeAgain] 重复记录副本" + IZID);
			return;
		}
		gvGMode2DailyRecord.IZIDRecord.Add(IZID);
		manager.SetIslandComeAgainDailyRecord(allRecords);
	}

	public static void AddTodayIZIDClaimRecord(this UserArchiveManager manager, int missionId)
	{
		Dictionary<string, GvGMode2DailyRecord> allRecords;
		GvGMode2DailyRecord gvGMode2DailyRecord = manager.EnsureIslandComeAgainDailyRecord(DateTimeHelper.ServerNow, out allRecords);
		if (!gvGMode2DailyRecord.DailyMissionRecord.Contains(missionId))
		{
			gvGMode2DailyRecord.DailyMissionRecord.Add(missionId);
			manager.SetIslandComeAgainDailyRecord(allRecords);
		}
	}

	public static void SetIslandComeAgainDailyRecord(this UserArchiveManager manager, Dictionary<string, GvGMode2DailyRecord> record)
	{
		manager.SetConfigValue("IslandComeAgainDailyMissionRecord", record);
	}

	public static int GetIslandComeAgainScoreItemCostRecord(this UserArchiveManager manager, string activityId)
	{
		IslandComeAgainRecord value;
		return manager.GetIslandComeAgainRecord().TryGetValue(activityId, out value) ? value.ScoreItemCost : 0;
	}

	public static void SetIslandComeAgainScoreItemCostRecord(this UserArchiveManager manager, string activityId, int cost)
	{
		if (!string.IsNullOrEmpty(activityId))
		{
			Dictionary<string, IslandComeAgainRecord> islandComeAgainRecord = manager.GetIslandComeAgainRecord();
			islandComeAgainRecord[activityId] = new IslandComeAgainRecord
			{
				ScoreItemCost = cost
			};
			manager.SetIslandComeAgainRecord(islandComeAgainRecord);
		}
	}

	public static Dictionary<string, IslandComeAgainRecord> GetIslandComeAgainRecord(this UserArchiveManager manager)
	{
		if (!manager.TryGetConfigValue<Dictionary<string, IslandComeAgainRecord>>("IslandComeAgainRecord", out var val))
		{
			val = new Dictionary<string, IslandComeAgainRecord>();
			manager.SetIslandComeAgainRecord(val);
		}
		return val;
	}

	public static void SetIslandComeAgainRecord(this UserArchiveManager manager, Dictionary<string, IslandComeAgainRecord> value)
	{
		manager.SetConfigValue("IslandComeAgainRecord", value);
	}
}
