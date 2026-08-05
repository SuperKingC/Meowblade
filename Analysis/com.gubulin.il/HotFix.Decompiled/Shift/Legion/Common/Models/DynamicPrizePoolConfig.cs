using System.Collections.Generic;
using GameDataEditor;
using Shift.Legion.Helpers;

namespace Shift.Legion.Common.Models;

public class DynamicPrizePoolConfig
{
	public bool Replacement;

	public Dictionary<string, List<int>> Content;

	public Dictionary<string, Dictionary<string, List<int>>> Schedule;

	public DynamicPrizePoolConfig()
	{
		Content = new Dictionary<string, List<int>>();
		Schedule = new Dictionary<string, Dictionary<string, List<int>>>();
	}

	public DynamicPrizePoolConfig(GDEDynamicPrizePoolData data)
		: this()
	{
		Replacement = data.Replacement;
		if (!string.IsNullOrEmpty(data.Content))
		{
			foreach (KeyValuePair<string, List<int>> item in JsonHelper.ToObject<Dictionary<string, List<int>>>(data.Content))
			{
				Content.Add(item.Key, item.Value);
			}
		}
		if (string.IsNullOrEmpty(data.Schedule))
		{
			return;
		}
		foreach (KeyValuePair<string, Dictionary<string, List<int>>> item2 in JsonHelper.ToObject<Dictionary<string, Dictionary<string, List<int>>>>(data.Schedule))
		{
			Schedule.Add(item2.Key, item2.Value);
		}
	}

	public void AddToSchedule(string nodeId, params KeyValuePair<string, List<int>>[] newContent)
	{
		if (!Schedule.ContainsKey(nodeId))
		{
			Schedule.Add(nodeId, new Dictionary<string, List<int>>());
		}
		for (int i = 0; i < newContent.Length; i++)
		{
			KeyValuePair<string, List<int>> keyValuePair = newContent[i];
			if (Schedule[nodeId].ContainsKey(keyValuePair.Key))
			{
				Schedule[nodeId][keyValuePair.Key] = keyValuePair.Value;
			}
			else
			{
				Schedule[nodeId].Add(keyValuePair.Key, keyValuePair.Value);
			}
		}
	}

	public void AddToContent(params KeyValuePair<string, List<int>>[] newContent)
	{
		for (int i = 0; i < newContent.Length; i++)
		{
			KeyValuePair<string, List<int>> keyValuePair = newContent[i];
			if (Content.ContainsKey(keyValuePair.Key))
			{
				Content[keyValuePair.Key] = keyValuePair.Value;
			}
			else
			{
				Content.Add(keyValuePair.Key, keyValuePair.Value);
			}
		}
	}

	public void RemoveFromContent(string contentKey)
	{
		Content.Remove(contentKey);
	}

	public void ExtractFromSchedule(string nodeId)
	{
		if (!Schedule.TryGetValue(nodeId, out var value) || Schedule.Count < 1)
		{
			return;
		}
		Schedule.Remove(nodeId);
		foreach (KeyValuePair<string, List<int>> item in value)
		{
			if (Content.ContainsKey(item.Key))
			{
				Content[item.Key] = item.Value;
			}
			else
			{
				Content.Add(item.Key, item.Value);
			}
		}
	}
}
