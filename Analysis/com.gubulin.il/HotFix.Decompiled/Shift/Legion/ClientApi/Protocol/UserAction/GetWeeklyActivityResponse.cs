using System;
using System.Collections.Generic;
using System.Linq;
using ProtoBuf;
using Shift.Legion.Common.Enums;
using Shift.Legion.Common.Managers;
using Shift.Legion.Common.Models;
using Shift.Legion.Common.Models.Store;
using Shift.Legion.Common.Sources.Enums;
using Shift.Legion.Helpers;

namespace Shift.Legion.ClientApi.Protocol.UserAction;

[ProtoContract]
public class GetWeeklyActivityResponse : IPacketBody
{
	public class Config
	{
		public int BeginTime;

		public int EndTime;

		public string LotteryItemId;

		public string ExchangeItemId;

		public int ExchangeRate;

		public List<SpinWeekActivityPayload.StoreContent> StoreContents;

		public List<SpinWeekActivityPayload.SpinWeekCard> SpinWeekCards;

		public List<SpinWeekActivityPayload.ExhibitPrize> ExhibitPrizes { get; set; } = new List<SpinWeekActivityPayload.ExhibitPrize>();

		public List<SpinWeekActivityPayload.SpinWeekExchangePrize> ExchangePrizes { get; set; } = new List<SpinWeekActivityPayload.SpinWeekExchangePrize>();
	}

	public class Progress
	{
		public Dictionary<string, int> Exchanged;

		public List<SpinWeekActivityPayload.SpinWeekCard> SpinWeekCardClaimRecord;

		public bool UnlockPaySource;

		public bool NewPeroid;

		public int ConsumedPointQty;
	}

	public class Announcement
	{
		public string LanguageKey;

		public int UserId;

		public int Index;

		public long TimeStamp;

		public SpinWeekActivityPayload.ExhibitPrize Prize;
	}

	public enum SpinWeekType
	{
		Empty = -1,
		BigWheel,
		MagicTree,
		SmashEgg,
		OpenChest
	}

	private Config _config;

	private Progress _progress;

	private List<Announcement> _lotteryAnnouncement;

	[ProtoMember(999)]
	public int ErrorCode { get; set; }

	[ProtoMember(1)]
	public int ActivityContentType { get; set; }

	[ProtoMember(2)]
	public string WeeklyActivityConfig { get; set; }

	[ProtoMember(3)]
	public string WeeklyActivityRecord { get; set; }

	[ProtoMember(4)]
	public List<string> LotteryAnnouncement { get; set; }

	public int PacketId => PacketIds.USER_ACTION_GET_WeeklyActivity_REQUEST;

	public SpinWeekType ActivityType => (ActivityContentType)ActivityContentType switch
	{
		Shift.Legion.Common.Enums.ActivityContentType.SpinWeek => SpinWeekType.BigWheel, 
		Shift.Legion.Common.Enums.ActivityContentType.MagicTree => SpinWeekType.MagicTree, 
		Shift.Legion.Common.Enums.ActivityContentType.SmashEgg => SpinWeekType.SmashEgg, 
		Shift.Legion.Common.Enums.ActivityContentType.OpenChest => SpinWeekType.OpenChest, 
		_ => SpinWeekType.Empty, 
	};

	public Config ActivityConfig
	{
		get
		{
			if (_config == null)
			{
				_config = JsonHelper.ToObject<Config>(WeeklyActivityConfig);
			}
			return _config;
		}
	}

	public Progress ActivityProgress
	{
		get
		{
			if (_progress == null)
			{
				_progress = JsonHelper.ToObject<Progress>(WeeklyActivityRecord);
			}
			return _progress;
		}
	}

	public List<Announcement> GetLotteryAnnouncement()
	{
		if (_lotteryAnnouncement == null)
		{
			_lotteryAnnouncement = new List<Announcement>();
			if (LotteryAnnouncement != null)
			{
				foreach (string item in LotteryAnnouncement)
				{
					string[] array = item.Split(new string[1] { "##" }, StringSplitOptions.None);
					Announcement announcement = new Announcement
					{
						LanguageKey = array[1],
						UserId = int.Parse(array[2]),
						Index = int.Parse(array[3])
					};
					announcement.TimeStamp = (long.TryParse(array[0], out var result) ? result : 0);
					announcement.Prize = ActivityConfig.ExhibitPrizes[announcement.Index];
					_lotteryAnnouncement.Add(announcement);
				}
			}
		}
		return _lotteryAnnouncement;
	}

	public int GetDay()
	{
		int serverNowTimestamp = DateTimeHelper.ServerNowTimestamp;
		return TimeSpan.FromSeconds(serverNowTimestamp - ActivityConfig.BeginTime).Days + 1;
	}

	public int GetExchangedCount(int index)
	{
		string key = index.ToString();
		if (ActivityProgress.Exchanged.TryGetValue(key, out var value))
		{
			return value;
		}
		return 0;
	}

	private bool TryGetExchangedCount(int index, out int count)
	{
		string key = index.ToString();
		if (ActivityProgress.Exchanged.TryGetValue(key, out count))
		{
			return true;
		}
		count = 0;
		return false;
	}

	public bool HasNotPurchaseGiftPack()
	{
		List<SpinWeekActivityPayload.SpinWeekStoreItem> displayStoreItems = GetDisplayStoreItems();
		foreach (SpinWeekActivityPayload.SpinWeekStoreItem item in displayStoreItems)
		{
			foreach (Dictionary<string, float> item2 in item.StoreItem.Price)
			{
				if (item2.First().Key == "Gem")
				{
					int num = 1;
					if (item.StoreItem.PurchaseLimitPeriod != PurchaseLimitType.NoLimit)
					{
						int purchaseCntAtLimitPeriod = GameManagers.Instance.StoreManager.GetPurchaseCntAtLimitPeriod(item.StoreItem.StoreItemId);
						num = item.StoreItem.PurchaseLimit - purchaseCntAtLimitPeriod;
					}
					if (num > 0)
					{
						return true;
					}
				}
			}
		}
		return false;
	}

	public bool HasNotClaimedWeekCard()
	{
		int day = GetDay();
		bool unlockPaySource = ActivityProgress.UnlockPaySource;
		foreach (SpinWeekActivityPayload.SpinWeekCard item in ActivityProgress.SpinWeekCardClaimRecord)
		{
			if (item.Day <= day)
			{
				bool flag = unlockPaySource && !item.ClaimedPay;
				bool flag2 = !item.ClaimedFree;
				if (flag || flag2)
				{
					return true;
				}
			}
		}
		return false;
	}

	public bool HasAnyInform()
	{
		return HasNotPurchaseGiftPack() || HasNotClaimedWeekCard();
	}

	public List<SpinWeekActivityPayload.SpinWeekExchangePrize> GetDisplayExchangePrizes()
	{
		List<SpinWeekActivityPayload.SpinWeekExchangePrize> list = new List<SpinWeekActivityPayload.SpinWeekExchangePrize>();
		IEnumerable<int> enumerable = ActivityConfig.ExchangePrizes.Select((SpinWeekActivityPayload.SpinWeekExchangePrize k) => k.Priority).Distinct();
		foreach (int priority in enumerable)
		{
			List<SpinWeekActivityPayload.SpinWeekExchangePrize> list2 = (from k in ActivityConfig.ExchangePrizes
				where k.Priority == priority
				orderby k.Index
				select k).ToList();
			SpinWeekActivityPayload.SpinWeekExchangePrize spinWeekExchangePrize = null;
			if (list2.Count > 1)
			{
				foreach (SpinWeekActivityPayload.SpinWeekExchangePrize item in list2)
				{
					if (TryGetExchangedCount(item.Index, out var count) && count >= item.ExchangeLimit)
					{
						continue;
					}
					spinWeekExchangePrize = item;
					break;
				}
				if (spinWeekExchangePrize == null)
				{
					spinWeekExchangePrize = ((list2.Count > 0) ? list2[list2.Count - 1] : null);
				}
			}
			else
			{
				spinWeekExchangePrize = list2[0];
			}
			if (spinWeekExchangePrize != null && GameManagers.Instance.UserArchiveManager.IsLevelCompleted(spinWeekExchangePrize.ShowLevelCase) && GameManagers.Instance.UserArchiveManager.GetUserLevel() >= spinWeekExchangePrize.ShowUserLevelCase)
			{
				list.Add(spinWeekExchangePrize);
			}
		}
		return list;
	}

	public List<SpinWeekActivityPayload.SpinWeekStoreItem> GetDisplayStoreItems()
	{
		List<SpinWeekActivityPayload.SpinWeekStoreItem> list = new List<SpinWeekActivityPayload.SpinWeekStoreItem>();
		foreach (SpinWeekActivityPayload.StoreContent storeContent in ActivityConfig.StoreContents)
		{
			StoreItem storeItem = StoreItem.Get(GameManagers.Instance, storeContent.StoreItemId);
			if (storeItem.IsPassedFilters)
			{
				list.Add(new SpinWeekActivityPayload.SpinWeekStoreItem
				{
					Index = storeContent.Index,
					StoreItem = storeItem
				});
			}
		}
		return list;
	}
}
