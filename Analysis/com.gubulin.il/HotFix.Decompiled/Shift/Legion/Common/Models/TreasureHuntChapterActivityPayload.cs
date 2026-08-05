using System;
using System.Collections.Generic;
using Shift.Legion.Common.Enums;
using Shift.Legion.Common.Managers;
using Shift.Legion.Helpers;

namespace Shift.Legion.Common.Models;

public class TreasureHuntChapterActivityPayload : ActivityContentPayload
{
	public string ChapterId;

	public int Tickets;

	public int Score;

	public Dictionary<string, int> ExtraScore;

	public Dictionary<string, object> EnableFilters;

	public string IconUrl;

	public Chapter Chapter;

	public List<string> Level_IDs => Chapter?.Level_IDs;

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
			if (value is List<string> collection)
			{
				list.AddRange(collection);
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

	public TreasureHuntChapterActivityPayload(int payloadIndex, string chapterId, Dictionary<string, object> data, Activity activity)
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
		if (data.TryGetValue("Icon", out var value3))
		{
			IconUrl = value3.ToString();
		}
		if (data.TryGetValue("ExtraScore", out var value4))
		{
			ExtraScore = JsonHelper.ToObject<Dictionary<string, int>>(value4.ToString());
		}
		if (!data.TryGetValue("EnableFilters", out var value5))
		{
			return;
		}
		EnableFilters = JsonHelper.ToObject<Dictionary<string, object>>(value5.ToString());
		List<string> list = new List<string>();
		list.AddRange(EnableFilters.Keys);
		foreach (string item in list)
		{
			string text = item;
			string text2 = text;
			if (text2 == "Levels")
			{
				EnableFilters[item] = JsonHelper.ToObject<List<string>>(EnableFilters[item].ToString());
			}
		}
	}

	public bool OnLevelComplete(GameManagers managers, string battleId, Level level, Team winner, bool newCompleteFlag)
	{
		return false;
	}

	public void OnChapterComplete(GameManagers managers, bool newCompleteFlag)
	{
	}

	public override void Reset(GameManagers managers, bool autoReset = false)
	{
	}
}
