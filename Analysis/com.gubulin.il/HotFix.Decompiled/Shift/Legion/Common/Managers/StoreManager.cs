using System;
using System.Collections.Generic;
using GameDataEditor;
using HotFix.Sources.Base.Scripts.Helper;
using Shift.Legion.ClientApi.Protocol.UserAction;
using Shift.Legion.Common.Models;
using Shift.Legion.Common.Models.Store;
using Shift.Legion.Common.Sources.Enums;

namespace Shift.Legion.Common.Managers;

public class StoreManager : Manager
{
	private const string PurchaseStatKey = "PurchaseStat";

	private const string LimitTimeMerchandiseKey = "LimitTimeMerchandise";

	private Config<PurchaseConfig> _purchaseStat;

	public Config<Dictionary<string, Dictionary<string, DateTimeOffset>>> _limitTimeMerchandise;

	public Config<PurchaseConfig> PurchaseStat
	{
		get
		{
			if (_purchaseStat == null)
			{
				UserArchiveManager userArchiveManager = Managers.UserArchiveManager;
				if (!userArchiveManager.Contains("PurchaseStat"))
				{
					userArchiveManager.SetConfigValue("PurchaseStat", new PurchaseConfig());
				}
				_purchaseStat = userArchiveManager.GetConfig<PurchaseConfig>("PurchaseStat");
			}
			_purchaseStat.GetValue().CheckDate();
			_purchaseStat.Save();
			return _purchaseStat;
		}
	}

	public Config<Dictionary<string, Dictionary<string, DateTimeOffset>>> LimitTimeMerchandise
	{
		get
		{
			if (_limitTimeMerchandise == null)
			{
				UserArchiveManager userArchiveManager = Managers.UserArchiveManager;
				if (!userArchiveManager.Contains("LimitTimeMerchandise"))
				{
					userArchiveManager.SetConfigValue("LimitTimeMerchandise", new Dictionary<string, Dictionary<string, DateTimeOffset>>());
				}
				_limitTimeMerchandise = userArchiveManager.GetConfig<Dictionary<string, Dictionary<string, DateTimeOffset>>>("LimitTimeMerchandise");
			}
			return _limitTimeMerchandise;
		}
	}

	public StoreManager(GameManagers managers)
		: base(managers)
	{
	}

	public int GetPurchaseCntAtLimitPeriod(string storeItemId)
	{
		GDEStoreContentConfigData gDEStoreContentConfigData = GDMgr.Get<GDEStoreContentConfigData>(storeItemId);
		if (gDEStoreContentConfigData == null)
		{
			return 0;
		}
		PurchaseConfig value = PurchaseStat.GetValue();
		Dictionary<string, int> dictionary = new Dictionary<string, int>();
		int value2;
		return ((PurchaseLimitType)gDEStoreContentConfigData.LimitPeriod switch
		{
			PurchaseLimitType.Daily => value.DailyPurchaseStat, 
			PurchaseLimitType.Weekly => value.WeeklyPurchaseStat, 
			PurchaseLimitType.Monthly => value.MonthlyPurchaseStat, 
			PurchaseLimitType.Activity_PVP => value.PvPPurchaseStat, 
			PurchaseLimitType.Activity_Recall => value.RecallPurchaseStat, 
			PurchaseLimitType.Activity_SpinWeek => value.WeeklyActivityPurchaseStat, 
			PurchaseLimitType.Activity_WarOfRealm => value.WarOfRealmPurchaseStat, 
			_ => value.PurchaseStat, 
		}).TryGetValue(storeItemId, out value2) ? value2 : 0;
	}

	public int GetPurchaseCnt(string storeItemId)
	{
		PurchaseConfig value = PurchaseStat.GetValue();
		if (value.PurchaseStat.TryGetValue(storeItemId, out var value2))
		{
			return value2;
		}
		return 0;
	}

	public Dictionary<string, DateTimeOffset> GetActivityLimitTimeMerchandise(string activityId)
	{
		Dictionary<string, Dictionary<string, DateTimeOffset>> value = LimitTimeMerchandise.GetValue();
		value.TryGetValue(activityId, out var value2);
		return value2 ?? new Dictionary<string, DateTimeOffset>();
	}

	public int GetLimitTimeMerchandiseRemainingTime(string activityId, string storeItemId)
	{
		Dictionary<string, DateTimeOffset> activityLimitTimeMerchandise = GetActivityLimitTimeMerchandise(activityId);
		if (!activityLimitTimeMerchandise.TryGetValue(storeItemId, out var value))
		{
			return -1;
		}
		return (int)(value - DateTimeHelper.Now).TotalSeconds;
	}

	public void SetLimitTimeMerchandise(string activityId, string storeItemId, DateTimeOffset expireAt)
	{
		Dictionary<string, Dictionary<string, DateTimeOffset>> value = LimitTimeMerchandise.GetValue();
		if (!value.ContainsKey(activityId))
		{
			value.Add(activityId, new Dictionary<string, DateTimeOffset>());
		}
		if (!value[activityId].ContainsKey(storeItemId))
		{
			value[activityId].Add(storeItemId, expireAt);
		}
		LimitTimeMerchandise.Save();
		Managers.Messenger.Broadcast("LIMIT_TIME_MERCHANDISE_ENABLED", storeItemId, expireAt);
	}

	public void GetStoreItemBonus(string storeItemId, out Dictionary<string, int> baseBonusDict, out Dictionary<string, int> extraBonusDict)
	{
		baseBonusDict = new Dictionary<string, int>();
		extraBonusDict = new Dictionary<string, int>();
		StoreItem storeItem = new StoreItem(Managers, storeItemId);
		PurchaseConfig value = PurchaseStat.GetValue();
		int value2;
		bool flag = !value.PurchaseStat.TryGetValue(storeItemId, out value2) || value2 < 1;
		foreach (KeyValuePair<string, int> item in storeItem.Content)
		{
			int num = item.Value;
			if (storeItem.DoubleAtFirst && flag)
			{
				num *= 2;
			}
			baseBonusDict.Add(item.Key, num);
		}
		if (!(storeItem.BonusAtFirst != null && flag))
		{
			return;
		}
		foreach (KeyValuePair<string, int> item2 in storeItem.BonusAtFirst)
		{
			extraBonusDict.Add(item2.Key, item2.Value);
		}
	}

	public void ClaimStoreItem(string storeItemId, int qty = 1)
	{
		StoreItem storeItem = StoreItem.Get(GameManagers.Instance, storeItemId);
		if (storeItem.Tags != null && storeItem.Tags.Contains("PayBonusFromItem"))
		{
			string key = storeItem.Tags[1];
			Dictionary<string, int> dictionary = new Dictionary<string, int> { 
			{
				key,
				-qty
			} };
			StockChangeRecord[] stockChangeRecords = dictionary.ToStockChangeRecords(StockInContext.Unknown);
			GameManagers.Instance.StockController.ReadStockChangeRecords(stockChangeRecords);
		}
		GetStoreItemBonus(storeItemId, out var baseBonusDict, out var extraBonusDict);
		List<Bonus> list = new List<Bonus>();
		foreach (KeyValuePair<string, int> item in baseBonusDict)
		{
			Bonus bonus = Bonus.Get(item.Key, item.Value * qty);
			bonus.Claim(Managers);
			list.Add(bonus);
		}
		List<Bonus> list2 = new List<Bonus>();
		foreach (KeyValuePair<string, int> item2 in extraBonusDict)
		{
			Bonus bonus2 = Bonus.Get(item2.Key, item2.Value * qty);
			bonus2.Claim(Managers);
			list2.Add(bonus2);
		}
		Stat(storeItemId, qty);
		Managers.Messenger.Broadcast("ORDER_SHIP_SUCCESS", list, list2);
		Managers.Messenger.Broadcast("ORDER_SHIP_SUCCESS_WITH_STOREITEM", storeItem.StoreItemId);
	}

	public void Stat(string storeItemId, int qty)
	{
		PurchaseConfig value = PurchaseStat.GetValue();
		if (value.PurchaseStat.ContainsKey(storeItemId))
		{
			value.PurchaseStat[storeItemId] += qty;
		}
		else
		{
			value.PurchaseStat.Add(storeItemId, qty);
		}
		if (value.DailyPurchaseStat.ContainsKey(storeItemId))
		{
			value.DailyPurchaseStat[storeItemId] += qty;
		}
		else
		{
			value.DailyPurchaseStat.Add(storeItemId, qty);
		}
		if (value.WeeklyPurchaseStat.ContainsKey(storeItemId))
		{
			value.WeeklyPurchaseStat[storeItemId] += qty;
		}
		else
		{
			value.WeeklyPurchaseStat.Add(storeItemId, qty);
		}
		if (value.MonthlyPurchaseStat.ContainsKey(storeItemId))
		{
			value.MonthlyPurchaseStat[storeItemId] += qty;
		}
		else
		{
			value.MonthlyPurchaseStat.Add(storeItemId, qty);
		}
		if (value.PvPPurchaseStat.ContainsKey(storeItemId))
		{
			value.PvPPurchaseStat[storeItemId] += qty;
		}
		else
		{
			value.PvPPurchaseStat.Add(storeItemId, qty);
		}
		if (value.RecallPurchaseStat.ContainsKey(storeItemId))
		{
			value.RecallPurchaseStat[storeItemId] += qty;
		}
		else
		{
			value.RecallPurchaseStat.Add(storeItemId, qty);
		}
		if (value.WeeklyActivityPurchaseStat.ContainsKey(storeItemId))
		{
			value.WeeklyActivityPurchaseStat[storeItemId] += qty;
		}
		else
		{
			value.WeeklyActivityPurchaseStat.Add(storeItemId, qty);
		}
		if (value.WarOfRealmPurchaseStat.ContainsKey(storeItemId))
		{
			value.WarOfRealmPurchaseStat[storeItemId] += qty;
		}
		else
		{
			value.WarOfRealmPurchaseStat.Add(storeItemId, qty);
		}
		PurchaseStat.Save();
		Managers.Messenger.Broadcast("ON_PURCHASE_STATS");
	}
}
