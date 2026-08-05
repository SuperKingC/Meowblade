using System.Collections.Generic;
using HotFix.Sources.Base.Scripts.Helper;
using Shift.Legion.Common.Models;

namespace Shift.Legion.Common.Managers;

public static class ArchiveExtension_GvGMode3SettlementHistory
{
	private static string GvGMode3CompletedFlag = "GvGMode3CompletedFlag";

	private static string GvGMode3CompletedHistory = "GvGMode3CompletedHistory";

	private static string GvGMode3HistoryRecord = "GvGMode3HistoryRecord";

	private static string GvGRareStone = "GvGRareStone";

	public static GvGRareStoneRecord LoadGvGMode3RareStoneRecord(this UserArchiveManager manager)
	{
		if (!manager.TryGetConfigValue<GvGRareStoneRecord>(GvGRareStone, out var val))
		{
			val = new GvGRareStoneRecord
			{
				Count = 0,
				HistoryCount = 0
			};
			manager.SetConfigValue(GvGRareStone, val);
		}
		return val;
	}

	public static void AddGvGRareStone(this UserArchiveManager manager, int count)
	{
		GvGRareStoneRecord gvGRareStoneRecord = manager.LoadGvGMode3RareStoneRecord();
		gvGRareStoneRecord.Count += count;
		manager.SetConfigValue(GvGRareStone, gvGRareStoneRecord);
	}

	private static void EnsureCompletedHistory(this UserArchiveManager manager)
	{
		if (!manager.Contains(GvGMode3CompletedHistory))
		{
			manager.SetConfigValue(GvGMode3CompletedHistory, new List<string>());
		}
	}

	public static int LoadGvGMode3HistoryRecord(this UserArchiveManager manager)
	{
		if (!manager.Contains(GvGMode3HistoryRecord))
		{
			manager.SetConfigValue(GvGMode3HistoryRecord, 0);
		}
		return manager.GetConfigValue<int>(GvGMode3HistoryRecord);
	}

	public static void AddGvGMode3CompletedHistory(this UserArchiveManager manager, string IZId)
	{
		manager.EnsureCompletedFlag();
		manager.SetCompletedFlag();
		manager.EnsureCompletedHistory();
		List<string> configValue = manager.GetConfigValue<List<string>>(GvGMode3CompletedHistory);
		if (configValue.AddDistinct(IZId))
		{
			manager.SetConfigValue(GvGMode3CompletedHistory, configValue);
		}
		SharedMessenger.Broadcast("ON_GVG3_IZ_COMPLETED");
	}

	public static List<string> LoadGvGMode3CompletedHistory(this UserArchiveManager manager)
	{
		manager.EnsureCompletedHistory();
		return manager.GetConfigValue<List<string>>(GvGMode3CompletedHistory);
	}

	private static void EnsureCompletedFlag(this UserArchiveManager manager)
	{
		if (!manager.Contains(GvGMode3CompletedFlag))
		{
			manager.SetConfigValue(GvGMode3CompletedFlag, "0");
		}
	}

	public static int LoadGvGMode3SettlementHistory(this UserArchiveManager manager)
	{
		manager.EnsureCompletedFlag();
		string configValue = manager.GetConfigValue<string>(GvGMode3CompletedFlag);
		return (!string.IsNullOrEmpty(configValue)) ? int.Parse(configValue) : 0;
	}

	private static void SetCompletedFlag(this UserArchiveManager manager)
	{
		manager.SetConfigValue(GvGMode3CompletedFlag, "1");
	}
}
