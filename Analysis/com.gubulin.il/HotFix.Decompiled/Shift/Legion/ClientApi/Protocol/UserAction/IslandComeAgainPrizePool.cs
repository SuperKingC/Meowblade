using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Managers;
using Assets.Scripts.UI;
using Shift.Legion.Common.Managers;
using Shift.Legion.Common.Models;

namespace Shift.Legion.ClientApi.Protocol.UserAction;

public class IslandComeAgainPrizePool
{
	public class ItemInfo
	{
		public int RewardId;

		public string ItemId;

		public int Qty;

		public int Rarity;

		public bool Available;
	}

	public int PoolKey;

	public string PoolName;

	public int UnlockTime;

	public int ExpiredTime;

	public List<ItemInfo> Reward;

	public Dictionary<string, int> RewardInfo;

	private int bigPrizeIndex = -1;

	public void UpdateRewardInfo(ItemInfo reward, int index)
	{
		string key = reward.RewardId.ToString();
		if (!RewardInfo.ContainsKey(key))
		{
			RewardInfo.Add(key, index);
			List<string> arg = new List<string> { $"{Shift.Legion.Common.Models.Item.Name(GameManagers.Instance, reward.ItemId)}+{reward.Qty}" };
			SharedMessenger.Broadcast("SHOW_TIPS", arg, 1, arg3: false);
		}
	}

	public bool CurrentPrizeLoaderUsed(int index, out ItemInfo reward)
	{
		int rewardId = -1;
		reward = null;
		foreach (KeyValuePair<string, int> item in RewardInfo)
		{
			if (index == item.Value)
			{
				rewardId = int.Parse(item.Key);
				break;
			}
		}
		if (rewardId < 0)
		{
			return false;
		}
		reward = Reward.FirstOrDefault((ItemInfo t) => t.RewardId == rewardId);
		return reward != null;
	}

	public bool PoolIsLock(out string time)
	{
		time = string.Empty;
		int num = (int)GameController.Instance.GetServerTime();
		if (num > UnlockTime)
		{
			return false;
		}
		time = UiHelper.ParseTimeChinsesDH(UnlockTime - num) + LanguagesManager.GetDesc("CsharpCodeZhTcText433");
		return true;
	}

	public ItemInfo GetBigPrize()
	{
		if (bigPrizeIndex >= 0)
		{
			return Reward[bigPrizeIndex];
		}
		for (int i = 0; i < Reward.Count; i++)
		{
			if (Reward[i].Rarity > 1)
			{
				bigPrizeIndex = i;
				break;
			}
		}
		return Reward[bigPrizeIndex];
	}

	public bool BigPrizeReceived()
	{
		if (RewardInfo == null)
		{
			return false;
		}
		return RewardInfo.ContainsKey(GetBigPrize().RewardId.ToString());
	}
}
