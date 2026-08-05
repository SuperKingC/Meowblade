using System;
using System.Collections.Generic;

namespace Shift.Legion.Common.Models;

public class LevelProgressConfig
{
	public Dictionary<string, Dictionary<string, int>> ClearStageStats = new Dictionary<string, Dictionary<string, int>>();

	public Dictionary<string, Dictionary<string, int>> ClearStageStatsUntilLastCheck = new Dictionary<string, Dictionary<string, int>>();

	public DateTimeOffset CheckTime;

	public LevelProgressConfig(DateTimeOffset checkTime)
	{
		CheckTime = checkTime;
	}

	public object Clone()
	{
		LevelProgressConfig levelProgressConfig = new LevelProgressConfig(CheckTime);
		foreach (KeyValuePair<string, Dictionary<string, int>> clearStageStat in ClearStageStats)
		{
			string key = clearStageStat.Key;
			levelProgressConfig.ClearStageStats.Add(key, new Dictionary<string, int>());
			foreach (KeyValuePair<string, int> item in clearStageStat.Value)
			{
				levelProgressConfig.ClearStageStats[key].Add(item.Key, item.Value);
			}
		}
		foreach (KeyValuePair<string, Dictionary<string, int>> item2 in ClearStageStatsUntilLastCheck)
		{
			string key2 = item2.Key;
			levelProgressConfig.ClearStageStatsUntilLastCheck.Add(key2, new Dictionary<string, int>());
			foreach (KeyValuePair<string, int> item3 in item2.Value)
			{
				levelProgressConfig.ClearStageStatsUntilLastCheck[key2].Add(item3.Key, item3.Value);
			}
		}
		return levelProgressConfig;
	}
}
