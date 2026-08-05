using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using Assets.Scripts.Managers;
using GameDataEditor;
using HotFix;
using Shift.Legion.Common.Enums;
using Shift.Legion.Common.Managers;
using Shift.Legion.Common.Sources.Enums;
using Shift.Legion.Helpers;
using UnityEngine;

namespace Shift.Legion.Common.Models.Store;

public class StoreItem
{
	private GameManagers _managers;

	[NotMapped]
	public GDEStoreContentConfigData StoreItemData;

	[NotMapped]
	public List<string> GameLevelFilter;

	[NotMapped]
	public MissionFilterConfig MissionFilter;

	[NotMapped]
	public Dictionary<string, int> OwnedItemFilter;

	[NotMapped]
	public Dictionary<string, int> PurchaseFilter;

	[Key]
	[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
	public string StoreItemId { get; set; }

	public string IOSProductID { get; set; }

	public string GoogleProductID { get; set; }

	public string TapTapIntlProductID { get; set; }

	[NotMapped]
	public string ReferenceId { get; set; }

	public bool IsDisableFilterForUI { get; set; }

	[NotMapped]
	public string Name { get; set; }

	[NotMapped]
	public string Icon { get; set; }

	[NotMapped]
	public string Desc { get; set; }

	[NotMapped]
	public string SubDesc { get; set; }

	public int Rarity { get; set; }

	[NotMapped]
	public StoreCategory Category { get; set; }

	[NotMapped]
	public bool DoubleAtFirst { get; set; }

	[NotMapped]
	public Dictionary<string, int> BonusAtFirst { get; set; }

	[Column("Tags")]
	public string TagsConfig { get; set; }

	[NotMapped]
	public List<string> Tags { get; set; }

	public int ValidTime { get; set; }

	public DateTimeOffset KickOffTime { get; set; }

	public int KickOffTimestamp { get; set; }

	public DateTimeOffset ExpireAt { get; set; }

	public int ExpireTimestamp { get; set; }

	[NotMapped]
	public Dictionary<string, int> Content { get; set; }

	[Column("DisplayContent")]
	public string DisplayContentConfig { get; set; }

	[NotMapped]
	public List<List<string>> DisplayContent { get; set; }

	[NotMapped]
	public List<Dictionary<string, float>> OriginPrice { get; set; }

	[Column("Price")]
	public string PriceConfig { get; set; }

	[NotMapped]
	public List<Dictionary<string, float>> Price { get; set; }

	public float Discount { get; set; } = 1f;

	public float InternationalDiscount { get; set; } = 1f;

	[Column("Limit")]
	public int PurchaseLimit { get; set; }

	[Column("LimitPeriod")]
	public PurchaseLimitType PurchaseLimitPeriod { get; set; } = PurchaseLimitType.NoLimit;

	[Column(TypeName = "bit")]
	public bool IsExpo { get; set; } = false;

	public string Substitution { get; set; }

	[Column(TypeName = "bit")]
	public bool IsResident { get; set; } = false;

	public int UserLevelFilter { get; set; }

	public int DungeonLevelFilter { get; set; }

	[Column("GameLevelFilter")]
	public string GameLevelFilterConfig { get; set; }

	[Column("MissionFilter")]
	public string MissionFilterConfig { get; set; }

	[Column("OwnedItemFilter")]
	public string OwnedItemFilterConfig { get; set; }

	[Column("PurchaseFilter")]
	public string PurchaseFilterConfig { get; set; }

	[Column("WeekDayFilter")]
	public string WeekDayFilterConfig { get; set; }

	[NotMapped]
	public List<string> WeekDayFilter { get; set; }

	[NotMapped]
	public Dictionary<string, int> DailyBonus
	{
		get
		{
			Dictionary<string, int> dictionary = new Dictionary<string, int>();
			foreach (KeyValuePair<string, int> item in Content)
			{
				GDEItemData gDEItemData = GDMgr.Get<GDEItemData>(item.Key);
				if (gDEItemData == null || gDEItemData.ItemType != 12)
				{
					continue;
				}
				List<Modifier> list = Item.Effect(_managers, item.Key);
				if (list.Count < 1)
				{
					continue;
				}
				foreach (Modifier item2 in list)
				{
					if (!(item2.ModifierId == "Daily"))
					{
						continue;
					}
					foreach (KeyValuePair<string, object> item3 in item2.PayloadDictionary)
					{
						if (!(item3.Key == "Bonus"))
						{
							continue;
						}
						foreach (KeyValuePair<string, int> item4 in JsonHelper.ToObject<Dictionary<string, int>>(item3.Value.ToString()))
						{
							if (dictionary.ContainsKey(item4.Key))
							{
								dictionary[item4.Key] += item4.Value;
							}
							else
							{
								dictionary.Add(item4.Key, item4.Value);
							}
						}
						break;
					}
					break;
				}
			}
			return dictionary;
		}
	}

	[NotMapped]
	public Dictionary<string, int> InstantBonus => FilterContentByItemType((ItemType itemType) => itemType != ItemType.Leasehold);

	[NotMapped]
	public Dictionary<string, int> LeaseholdItems => FilterContentByItemType((ItemType itemType) => itemType == ItemType.Leasehold);

	[NotMapped]
	public bool IsPassedFilters
	{
		get
		{
			if (IsDisableFilterForUI)
			{
				return true;
			}
			if (UserLevelFilter > 0 && _managers.UserArchiveManager.GetUserLevel() < UserLevelFilter)
			{
				return false;
			}
			if (DungeonLevelFilter > 0 && _managers.UserArchiveManager.GetDungeonLevel() < DungeonLevelFilter)
			{
				return false;
			}
			if (GameLevelFilter != null && GameLevelFilter.Count > 0)
			{
				Dictionary<string, List<string>> levelProgress = _managers.UserArchiveManager.GetLevelProgress();
				if (levelProgress != null)
				{
					List<string> list = new List<string>();
					foreach (List<string> value5 in levelProgress.Values)
					{
						list.AddRange(value5);
					}
					foreach (string item in GameLevelFilter)
					{
						if (!list.Contains(item))
						{
							return false;
						}
					}
				}
			}
			if (MissionFilter != null)
			{
				MissionStats value = _managers.MissionManager.MissionStat.GetValue();
				if (MissionFilter.Completed != null && MissionFilter.Completed.Count > 0)
				{
					if (value.MissionCompleteRecords == null || value.MissionCompleteRecords.Count < 1)
					{
						return false;
					}
					foreach (string item2 in MissionFilter.Completed)
					{
						if ((!value.MissionCompleteRecords.TryGetValue(item2, out var value2) || value2 < 1) && (!value.MissionClaimRecords.TryGetValue(item2, out var value3) || value3 < 1))
						{
							return false;
						}
					}
				}
				if (MissionFilter.Claimed != null && MissionFilter.Claimed.Count > 0)
				{
					if (value.MissionClaimRecords == null || value.MissionClaimRecords.Count < 1)
					{
						return false;
					}
					foreach (string item3 in MissionFilter.Claimed)
					{
						if (!value.MissionClaimRecords.TryGetValue(item3, out var value4) || value4 < 1)
						{
							return false;
						}
					}
				}
			}
			if (OwnedItemFilter != null && OwnedItemFilter.Count > 0)
			{
				foreach (KeyValuePair<string, int> item4 in OwnedItemFilter)
				{
					if (_managers.StockController.GetStock(item4.Key) < item4.Value)
					{
						return false;
					}
				}
			}
			if (PurchaseFilter != null && PurchaseFilter.Count > 0)
			{
				foreach (KeyValuePair<string, int> item5 in PurchaseFilter)
				{
					int purchaseCntAtLimitPeriod = _managers.StoreManager.GetPurchaseCntAtLimitPeriod(item5.Key);
					if (purchaseCntAtLimitPeriod < item5.Value)
					{
						return false;
					}
				}
			}
			if (WeekDayFilter != null && WeekDayFilter.Count > 0)
			{
				DateTimeOffset weeklyRefreshTime = DateTimeHelper.GetWeeklyRefreshTime(DateTimeHelper.Now, DateTimeHelper.TimezoneOffset, DateTimeHelper.RefreshHours);
				DateTimeOffset dailyRefreshTime = DateTimeHelper.GetDailyRefreshTime(DateTimeHelper.Now, DateTimeHelper.TimezoneOffset, DateTimeHelper.RefreshHours);
				int num = (dailyRefreshTime - weeklyRefreshTime).Days + 1;
				if (!WeekDayFilter.Contains(num.ToString()))
				{
					return false;
				}
			}
			return true;
		}
	}

	[NotMapped]
	public bool IsExpired => ExpireTimestamp > 0 && ExpireTimestamp < (int)GameController.Instance.GetServerTime();

	[NotMapped]
	public bool IsKickedOff => KickOffTimestamp == 0 || GameController.Instance.GetServerTime() >= KickOffTimestamp;

	[NotMapped]
	public bool IsSoldOut => PurchaseLimit > 0 && PurchaseLimit <= _managers.StoreManager.GetPurchaseCntAtLimitPeriod(StoreItemId);

	[NotMapped]
	public bool IsFree => Price.Any(delegate(Dictionary<string, float> costDict)
	{
		foreach (float value in costDict.Values)
		{
			if (value > 0f)
			{
				return false;
			}
		}
		return true;
	});

	public static StoreItem Get(GameManagers managers, string storeItemId)
	{
		string key = "StoreItem:" + storeItemId;
		if (managers.CacheData.TryGetValue(key, out var value) && value is StoreItem result)
		{
			return result;
		}
		StoreItem storeItem = new StoreItem(managers, storeItemId);
		managers.CacheData[key] = storeItem;
		return storeItem;
	}

	private Dictionary<string, int> FilterContentByItemType(Func<ItemType, bool> filter)
	{
		Dictionary<string, int> dictionary = new Dictionary<string, int>();
		foreach (KeyValuePair<string, int> item in Content)
		{
			GDEItemData gDEItemData = GDMgr.Get<GDEItemData>(item.Key);
			if (gDEItemData != null && filter((ItemType)gDEItemData.ItemType))
			{
				dictionary.Add(item.Key, item.Value);
			}
		}
		return dictionary;
	}

	public StoreItem(GameManagers managers, string storeItemId)
	{
		//IL_0494: Unknown result type (might be due to invalid IL or missing references)
		//IL_049b: Invalid comparison between Unknown and I4
		//IL_04e4: Unknown result type (might be due to invalid IL or missing references)
		//IL_04ea: Invalid comparison between Unknown and I4
		//IL_0503: Unknown result type (might be due to invalid IL or missing references)
		//IL_0509: Invalid comparison between Unknown and I4
		//IL_050b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0511: Invalid comparison between Unknown and I4
		_managers = managers;
		StoreItemData = GDMgr.Get<GDEStoreContentConfigData>(storeItemId);
		if (StoreItemData == null)
		{
			ILRuntimeDebug.LogError(storeItemId + " Get Config Failed");
		}
		StoreItemId = storeItemId;
		IsDisableFilterForUI = false;
		if (!string.IsNullOrEmpty(StoreItemData.OriginPrice))
		{
			OriginPrice = JsonHelper.ToObject<List<Dictionary<string, float>>>(StoreItemData.OriginPrice);
		}
		else
		{
			OriginPrice = new List<Dictionary<string, float>>();
		}
		Price = OriginPrice;
		if (!string.IsNullOrEmpty(StoreItemData.Price))
		{
			Price = JsonHelper.ToObject<List<Dictionary<string, float>>>(StoreItemData.Price);
		}
		if (HotUpdateProcess.Instance.IsRegionOutCN && StoreItemData.InternationalDiscount > 0f && StoreItemData.InternationalDiscount < 1f)
		{
			InternationalDiscount = StoreItemData.InternationalDiscount;
		}
		Discount = StoreItemData.Discount;
		if (Discount >= 0f && Discount < 1f)
		{
			for (int i = 0; i < Price.Count; i++)
			{
				Dictionary<string, float> dictionary = Price[i];
				string[] array = dictionary.Keys.ToArray();
				for (int j = 0; j < dictionary.Count; j++)
				{
					string key = array[j];
					Price[i][key] *= Discount;
				}
			}
		}
		int rarity = StoreItemData.Rarity;
		int limit = StoreItemData.Limit;
		PurchaseLimitType purchaseLimitPeriod = ((StoreItemData.LimitPeriod <= 0) ? PurchaseLimitType.NoLimit : ((PurchaseLimitType)StoreItemData.LimitPeriod));
		List<List<string>> list = new List<List<string>>();
		if (!string.IsNullOrEmpty(StoreItemData.DisplayContent))
		{
			list = JsonHelper.ToObject<List<List<string>>>(StoreItemData.DisplayContent);
		}
		else if (!string.IsNullOrEmpty(StoreItemData.Content))
		{
			foreach (KeyValuePair<string, int> item in JsonHelper.ToObject<Dictionary<string, int>>(StoreItemData.Content))
			{
				GDEItemData gDEItemData = GDMgr.Get<GDEItemData>(item.Key);
				if (gDEItemData != null)
				{
					list.Add(new List<string> { gDEItemData.Name, gDEItemData.Icon, gDEItemData.PostScript });
				}
			}
		}
		Dictionary<string, int> bonusAtFirst = null;
		if (!string.IsNullOrEmpty(StoreItemData.BonusAtFirst))
		{
			bonusAtFirst = JsonHelper.ToObject<Dictionary<string, int>>(StoreItemData.BonusAtFirst);
		}
		Category = (StoreCategory)StoreItemData.Category;
		Content = JsonHelper.ToObject<Dictionary<string, int>>(StoreItemData.Content);
		Name = StoreItemData.Name;
		Desc = StoreItemData.Desc;
		SubDesc = StoreItemData.SubDesc;
		Icon = StoreItemData.Icon;
		Tags = StoreItemData.Tags;
		Rarity = rarity;
		PurchaseLimit = limit;
		PurchaseLimitPeriod = purchaseLimitPeriod;
		DisplayContent = list;
		DoubleAtFirst = StoreItemData.DoubleAtFirst;
		BonusAtFirst = bonusAtFirst;
		IsExpo = StoreItemData.IsExpo;
		Substitution = StoreItemData.Substitution;
		IsResident = StoreItemData.IsResident;
		IOSProductID = StoreItemData.IOSProductID;
		GoogleProductID = StoreItemData.GoogleProductID;
		TapTapIntlProductID = StoreItemData.TapTapIntlProductID;
		if ((int)Application.platform == 11)
		{
			string channelCode = HotUpdateProcess.ChannelCode;
			string text = channelCode;
			if (text == "TapIntl")
			{
				ReferenceId = TapTapIntlProductID;
			}
			else
			{
				ReferenceId = GoogleProductID;
			}
		}
		else if ((int)Application.platform == 8)
		{
			ReferenceId = IOSProductID;
		}
		else if ((int)Application.platform != 2 && (int)Application.platform != 1)
		{
		}
		int validTime = StoreItemData.ValidTime;
		ValidTime = validTime;
		UserLevelFilter = StoreItemData.UserLevelFilter;
		DungeonLevelFilter = StoreItemData.DungeonLevelFilter;
		if (!string.IsNullOrEmpty(StoreItemData.GameLevelFilter))
		{
			GameLevelFilter = JsonHelper.ToObject<List<string>>(StoreItemData.GameLevelFilter);
		}
		if (!string.IsNullOrEmpty(StoreItemData.MissionFilter))
		{
			MissionFilter = JsonHelper.ToObject<MissionFilterConfig>(StoreItemData.MissionFilter);
		}
		if (!string.IsNullOrEmpty(StoreItemData.OwnedItemFilter))
		{
			OwnedItemFilter = JsonHelper.ToObject<Dictionary<string, int>>(StoreItemData.OwnedItemFilter);
		}
		if (!string.IsNullOrEmpty(StoreItemData.PurchaseFilter))
		{
			PurchaseFilter = JsonHelper.ToObject<Dictionary<string, int>>(StoreItemData.PurchaseFilter);
		}
		WeekDayFilter = StoreItemData.WeekDayFilter;
		if (!string.IsNullOrEmpty(StoreItemData.KickOffAt) && DateTimeHelper.TryParse(StoreItemData.KickOffAt, out var dateTime))
		{
			KickOffTime = dateTime;
		}
		if (!string.IsNullOrEmpty(StoreItemData.ExpireAt) && DateTimeHelper.TryParse(StoreItemData.ExpireAt, out var dateTime2))
		{
			ExpireAt = dateTime2;
		}
	}

	public StoreItem()
	{
	}

	public bool CanRedeem(List<string> costItems, out Dictionary<string, float> costDict)
	{
		costDict = null;
		if (_managers == null)
		{
			return false;
		}
		if (!IsKickedOff || IsExpired || !IsPassedFilters || IsSoldOut)
		{
			return false;
		}
		if (costItems == null || costItems.Count < 1)
		{
			for (int num = Price.Count - 1; num >= 0; num--)
			{
				Dictionary<string, float> dictionary = Price[num].ToDictionary((KeyValuePair<string, float> pair) => pair.Key, (KeyValuePair<string, float> pair) => pair.Value);
				bool flag = true;
				foreach (KeyValuePair<string, float> item in dictionary)
				{
					if (item.Key == "RMB" || (float)_managers.StockController.GetStock(item.Key) >= item.Value)
					{
						continue;
					}
					flag = false;
					break;
				}
				if (flag)
				{
					costDict = dictionary;
					break;
				}
			}
			return costDict != null;
		}
		foreach (Dictionary<string, float> item2 in Price)
		{
			if (item2.Count != costItems.Count || item2.Keys.Any((string itemId) => !costItems.Contains(itemId)))
			{
				continue;
			}
			foreach (KeyValuePair<string, float> item3 in item2)
			{
				if (item3.Key != "RMB" && (float)_managers.StockController.GetStock(item3.Key) < item3.Value)
				{
					return false;
				}
			}
			costDict = item2;
			return true;
		}
		return false;
	}

	public string GetCurrentPriceDisplay(bool additionFormat = true)
	{
		string text;
		if (HotUpdateProcess.Instance.IsRegionOutCN)
		{
			if (string.IsNullOrEmpty(ReferenceId) || !PurchaseManager.Instance.ProductLocalInfoDictionary.TryGetValue(ReferenceId, out var value))
			{
				return "--";
			}
			text = value.FormattedPrice;
		}
		else
		{
			KeyValuePair<string, float> priceItemId = FGUIManager.Instance.GetPriceItemId(this);
			text = $"{GetCurrencySymbol()} {Convert.ToInt32(priceItemId.Value)}";
		}
		if (additionFormat)
		{
			return string.Format(LanguagesManager.GetDesc("CsharpCodeZhTcText956"), text);
		}
		return text;
	}

	public float GetMtgPrice()
	{
		foreach (Dictionary<string, float> item in Price)
		{
			if (item.ContainsKey("MTG"))
			{
				return item["MTG"];
			}
		}
		return 0f;
	}

	public string GetOriginPriceDisplay()
	{
		string arg;
		if (HotUpdateProcess.Instance.IsRegionOutCN)
		{
			if (!string.IsNullOrEmpty(ReferenceId) && PurchaseManager.Instance.ProductLocalInfoDictionary.TryGetValue(ReferenceId, out var value))
			{
				string currencySymbol = GetCurrencySymbol();
				arg = ((!(currencySymbol == "HK$") && !(currencySymbol == "NT$")) ? $"{currencySymbol} {value.Price / InternationalDiscount:F2}" : $"{currencySymbol} {value.Price / InternationalDiscount:F0}");
			}
			else
			{
				arg = "--";
			}
		}
		else
		{
			KeyValuePair<string, float> priceItemId = FGUIManager.Instance.GetPriceItemId(this);
			arg = $"{GetCurrencySymbol()} {Convert.ToInt32(priceItemId.Value)}";
		}
		string desc = LanguagesManager.GetDesc("CsharpCodeZhTcText955");
		return string.Format(desc, arg);
	}

	public string GetCurrencySymbol()
	{
		if (HotUpdateProcess.Instance.IsRegionOutCN)
		{
			if (!string.IsNullOrEmpty(ReferenceId) && PurchaseManager.Instance.ProductLocalInfoDictionary.TryGetValue(ReferenceId, out var value))
			{
				return value.CurrencySymbol;
			}
			return string.Empty;
		}
		return FGUIManager.Instance.GetPriceItemId(this).Key;
	}

	public bool CanRedeemByMtg()
	{
		float mtgPrice = GetMtgPrice();
		if (!(mtgPrice > 0f))
		{
			return false;
		}
		return (float)_managers.StockController.GetStock("MTG") > mtgPrice;
	}

	public string GetCurrencySymbolImageUrl()
	{
		string currencySymbol = GetCurrencySymbol();
		return "ui://PublicResources/" + currencySymbol;
	}

	public string GetIconUrl()
	{
		return "ui://PublicResources/" + Icon;
	}
}
