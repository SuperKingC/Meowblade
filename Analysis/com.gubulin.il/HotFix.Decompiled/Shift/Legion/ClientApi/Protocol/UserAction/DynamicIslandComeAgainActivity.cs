using System.Collections.Generic;
using System.Linq;
using Shift.Legion.Helpers;
using UnityEngine;

namespace Shift.Legion.ClientApi.Protocol.UserAction;

public class DynamicIslandComeAgainActivity
{
	public string ActivityId;

	public string Name;

	public string Desc;

	public string[] BeginTime;

	public string[] EndTime;

	public string ImgUrl;

	public Dictionary<string, string> Config;

	public string TicketItem;

	public List<string> LevelCase;

	public string ScoreItem;

	public Dictionary<string, int> RewardInfo;

	private List<IslandComeAgainPrizePool> allPrizePool;

	public List<DailyMission> DailyMissions { get; set; }

	public List<int> DailyMissionsRecord { get; set; }

	public List<int> DailyActiveTime { get; set; }

	public IslandComeAgainPrizePool UpdatePrizePool(int poolKey, List<IslandComeAgainPrizePool.ItemInfo> rewards)
	{
		if (allPrizePool == null)
		{
			return null;
		}
		IslandComeAgainPrizePool islandComeAgainPrizePool = null;
		for (int i = 0; i < allPrizePool.Count; i++)
		{
			if (allPrizePool[i].PoolKey == poolKey)
			{
				islandComeAgainPrizePool = allPrizePool[i];
				break;
			}
		}
		if (islandComeAgainPrizePool == null)
		{
			return null;
		}
		for (int j = 0; j < islandComeAgainPrizePool.Reward.Count; j++)
		{
			IslandComeAgainPrizePool.ItemInfo itemInfo = islandComeAgainPrizePool.Reward[j];
			for (int num = rewards.Count - 1; num >= 0; num--)
			{
				if (rewards[num].RewardId == itemInfo.RewardId)
				{
					itemInfo.Available = rewards[num].Available;
					rewards.RemoveAt(num);
					break;
				}
			}
		}
		return islandComeAgainPrizePool;
	}

	public List<IslandComeAgainPrizePool> GetAllPrizePool()
	{
		if (allPrizePool != null)
		{
			return allPrizePool;
		}
		if (Config == null || Config.Count <= 0)
		{
			return null;
		}
		allPrizePool = new List<IslandComeAgainPrizePool>();
		string[] array = Config.Values.ToArray();
		foreach (string text in array)
		{
			if (!string.IsNullOrEmpty(text))
			{
				allPrizePool.Add(JsonHelper.ToObject<IslandComeAgainPrizePool>(text));
			}
		}
		return allPrizePool;
	}

	public bool PrizePoolIsEmpty()
	{
		if (Config == null || Config.Count <= 0)
		{
			return true;
		}
		if (allPrizePool == null)
		{
			allPrizePool = new List<IslandComeAgainPrizePool>();
			string[] array = Config.Values.ToArray();
			foreach (string text in array)
			{
				if (!string.IsNullOrEmpty(text))
				{
					allPrizePool.Add(JsonHelper.ToObject<IslandComeAgainPrizePool>(text));
				}
			}
		}
		bool flag = true;
		for (int j = 0; j < allPrizePool.Count; j++)
		{
			int count = allPrizePool[j].Reward.Count;
			for (int k = 0; k < count; k++)
			{
				if (allPrizePool[j].Reward[k].Available)
				{
					flag = false;
					break;
				}
			}
			if (!flag)
			{
				break;
			}
		}
		return flag;
	}

	public int GetAvailablePoolIndex()
	{
		return Mathf.Max(allPrizePool.FindIndex((IslandComeAgainPrizePool p) => p.Reward.Any((IslandComeAgainPrizePool.ItemInfo r) => r.Available)), 0);
	}

	public int TicketDrawOnce(string poolKey)
	{
		if (string.IsNullOrEmpty(poolKey) || string.IsNullOrEmpty(TicketItem))
		{
			return 0;
		}
		Dictionary<string, int> dictionary = JsonHelper.ToObject<Dictionary<string, int>>(TicketItem);
		dictionary.TryGetValue(poolKey, out var value);
		return value;
	}
}
