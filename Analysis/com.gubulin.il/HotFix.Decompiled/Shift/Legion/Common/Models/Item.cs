using System;
using System.Collections.Generic;
using Assets.Scripts.Managers;
using GameDataEditor;
using GameMaths;
using Shift.Legion.ClientApi.Protocol.UserAction;
using Shift.Legion.Common.Helpers;
using Shift.Legion.Common.Managers;
using Shift.Legion.Helpers;

namespace Shift.Legion.Common.Models;

public static class Item
{
	public const string Unlock = "Unlock";

	public const string Money = "Money";

	public const string Gem = "Gem";

	public const string ManPower = "ManPower";

	public const string TechPoint = "TechPoint";

	public const string PotentialLevel = "PotentialLevel";

	public const string SoldierExp = "SoldierExp";

	public const string UserExp = "UserExp";

	public const string DungeonExp = "DungeonExp";

	public const string CollectableResource = "CollectableResource";

	public const string ResourcePortal1 = "ResourcePortal1";

	public const string ResourcePortal2 = "ResourcePortal2";

	public const string ResourcePortal3 = "ResourcePortal3";

	public const string AutoProduce = "AutoProduce";

	public const string Payload = "Payload";

	public const string BuildingExtraSlot = "BuildingExtraSlot";

	public const string BuildingLeaseholdSlot = "BuildingLeaseholdSlot";

	public const string RMB = "RMB";

	public const string MTG = "MTG";

	public const string LegendItem = "LegendItem";

	public const string GvGContributionPoint = "ContributionPoint";

	public const string GvGContributionPointItem = "I65001";

	public const string BLUEPRINT_BOX = "BlueprintBox";

	public const string GVG_STORE_GUARANTEED_BLUEPRINT_EXCHANGE_TICKET = "I62201";

	public const string BLUEPRINT_BOX_ICON_SUFFIX = "Blue";

	public static List<string> OptionalBlueprintSet;

	public const string SpecialBlueprint = "I31108";

	private static List<string> _itemKeys;

	private static List<string> _collectableItemList;

	private static Dictionary<string, List<Modifier>> _cache_Effect;

	public static List<string> ItemKeys
	{
		get
		{
			if (_itemKeys == null)
			{
				_itemKeys = new List<string>();
				IEnumerable<GDEItemData> allItems = GDMgr.GetAllItems<GDEItemData>();
				foreach (GDEItemData item in allItems)
				{
					_itemKeys.Add(item.Key);
				}
			}
			return _itemKeys;
		}
	}

	public static List<string> CollectableItemList
	{
		get
		{
			if (_collectableItemList == null)
			{
				_collectableItemList = new List<string>();
				foreach (string itemKey in ItemKeys)
				{
					GDEItemData gDEItemData = GDMgr.Get<GDEItemData>(itemKey);
					if (gDEItemData.ItemType == 1)
					{
						_collectableItemList.Add(itemKey);
					}
				}
			}
			return _collectableItemList;
		}
	}

	public static int Stock(GameManagers managers, string itemId)
	{
		return managers.StockController.GetStock(itemId);
	}

	public static bool IsCollectableItem(string itemId)
	{
		return CollectableItemList.Contains(itemId);
	}

	public static void Upgrade(GameManagers managers, string itemId)
	{
		if (!CanUpgrade(managers, itemId, out var errMsg))
		{
			SharedMessenger.Broadcast("SHOW_TIPS", new List<string> { errMsg }, 121, arg3: false);
		}
		else
		{
			ConsumeUpgrade(managers, itemId);
			managers.UserArchiveManager.SetItemLevel(itemId, Level(managers, itemId) + 1);
		}
	}

	public static bool CanUpgrade(GameManagers managers, string itemId, out string errMsg)
	{
		errMsg = "";
		if (ItemType(itemId) != 1 && ItemType(itemId) != 2)
		{
			errMsg = LanguagesManager.GetDesc("CsharpCodeZhTcText763");
			return false;
		}
		float percentFloatPayload = managers.ModifierManager.GetPercentFloatPayload("ItemUpgradeCost", new string[1] { itemId });
		Dictionary<string, int> dictionary = EvoRequirement(managers, itemId, Level(managers, itemId), percentFloatPayload);
		if (dictionary == null)
		{
			errMsg = LanguagesManager.GetDesc("CsharpCodeZhTcText764");
			return false;
		}
		foreach (KeyValuePair<string, int> item in dictionary)
		{
			int stock = managers.StockController.GetStock(item.Key);
			if (stock < item.Value)
			{
				errMsg = string.Format("{0}{1} {2}/{3}", LanguagesManager.GetDesc("CsharpCodeZhTcText765"), Name(managers, item.Key), stock, item.Value);
				return false;
			}
		}
		return true;
	}

	private static void ConsumeUpgrade(GameManagers managers, string itemId)
	{
		float percentFloatPayload = managers.ModifierManager.GetPercentFloatPayload("ItemUpgradeCost", new string[1] { itemId });
		Dictionary<string, int> dictionary = EvoRequirement(managers, itemId, Level(managers, itemId), percentFloatPayload);
		if (dictionary == null)
		{
			return;
		}
		StockChangeRecord[] array = new StockChangeRecord[dictionary.Count];
		int num = 0;
		foreach (KeyValuePair<string, int> item in dictionary)
		{
			array[num++] = new StockChangeRecord
			{
				ItemId = item.Key,
				Offset = -item.Value,
				Context = 8,
				ContextValue = itemId,
				Type = 1
			};
		}
		managers.StockController.ReadStockChangeRecords(array);
	}

	public static ActionResult Use(GameManagers managers, string itemId, object context = null, int repeat = 1)
	{
		ItemConsumer.UseItem(managers, itemId, context, repeat);
		return new ActionResult
		{
			Result = true
		};
	}

	public static ActionResult UseForSoldier(GameManagers managers, string itemId, Soldier soldier, int repeat = 1)
	{
		if (soldier == null)
		{
			return new ActionResult
			{
				Result = false,
				ResultCode = ActionResultCode.SoldierNotFound
			};
		}
		if (Effect(managers, itemId) == null)
		{
			return new ActionResult
			{
				Result = false,
				ResultCode = ActionResultCode.ItemUseError
			};
		}
		ItemConsumer.UseItem(managers, itemId, soldier, repeat);
		return new ActionResult
		{
			Result = true
		};
	}

	public static int Level(GameManagers managers, string itemId)
	{
		int num = ItemType(itemId);
		if (num == 1 || num == 2)
		{
			return managers.UserArchiveManager.GetItemLevel(itemId);
		}
		return Rarity(itemId);
	}

	public static string Name(GameManagers managers, string itemId)
	{
		GDEItemData gDEItemData = GDMgr.Get<GDEItemData>(itemId);
		if (gDEItemData == null)
		{
			return itemId;
		}
		return gDEItemData.Name;
	}

	public static string Name(string itemId, int level)
	{
		GDEItemData gDEItemData = GDMgr.Get<GDEItemData>(itemId);
		if (gDEItemData == null)
		{
			return itemId;
		}
		return Name(gDEItemData, level);
	}

	public static string Name(GDEItemData data, int level)
	{
		if (data == null)
		{
			return string.Empty;
		}
		return data.Name;
	}

	public static int IsShining(string itemId)
	{
		return GDMgr.Get<GDEItemData>(itemId)?.Shining ?? 0;
	}

	public static int ItemType(string itemId)
	{
		return GDMgr.Get<GDEItemData>(itemId)?.ItemType ?? (-1);
	}

	public static int Rarity(string itemId)
	{
		return GDMgr.Get<GDEItemData>(itemId)?.Rarity ?? 0;
	}

	public static string PostScript(string itemId)
	{
		return GDMgr.Get<GDEItemData>(itemId)?.PostScript ?? string.Empty;
	}

	public static List<string> Tags(string itemId)
	{
		GDEItemData gDEItemData = GDMgr.Get<GDEItemData>(itemId);
		List<string> list = new List<string>();
		if (gDEItemData != null && !string.IsNullOrEmpty(gDEItemData.Tags))
		{
			list.AddRange(gDEItemData.Tags.Split(' '));
		}
		return list;
	}

	public static Dictionary<string, int> OriginEvoRequirement(GameManagers managers, string itemId, int currentLevel)
	{
		if (ItemType(itemId) != 2)
		{
			return null;
		}
		ProductEvoData evoData = ProductEvoData.GetEvoData(itemId);
		if (evoData == null)
		{
			return null;
		}
		int specifiedLevel = currentLevel + 1;
		int weaponEvoLevel = managers.UserArchiveManager.GetWeaponEvoLevel(itemId, specifiedLevel);
		Dictionary<int, Dictionary<string, int>> dictionary = ((managers.UserArchiveManager.GetWeaponSubLevel(itemId, specifiedLevel) == 0) ? evoData.EvoRequire : evoData.FragEvoRequire);
		Dictionary<string, int> value;
		return (!dictionary.TryGetValue(weaponEvoLevel, out value)) ? null : value;
	}

	public static Dictionary<string, int> EvoRequirement(GameManagers managers, string itemId, int level, float upgradeCostModifier = 0f)
	{
		if (ItemType(itemId) != 2)
		{
			return null;
		}
		Dictionary<string, int> dictionary = OriginEvoRequirement(managers, itemId, level);
		if (dictionary == null)
		{
			return null;
		}
		float num = upgradeCostModifier;
		Dictionary<string, int> dictionary2;
		if (Math.Abs(num) > float.Epsilon)
		{
			dictionary2 = new Dictionary<string, int>();
			num += 1f;
			foreach (KeyValuePair<string, int> item in dictionary)
			{
				dictionary2.Add(item.Key, Mathf.RoundToInt((float)item.Value * num));
			}
		}
		else
		{
			dictionary2 = dictionary;
		}
		return dictionary2;
	}

	public static Dictionary<string, string> GetItemBonus(GameManagers managers, string itemId)
	{
		return Singleton<SoldierProductManager>.Instance.GetWeaponAttributes(managers, itemId, Level(managers, itemId));
	}

	public static Dictionary<string, string> GetNextLevelItemBonus(GameManagers managers, string itemId)
	{
		return Singleton<SoldierProductManager>.Instance.GetWeaponAttributes(managers, itemId, Level(managers, itemId) + 1);
	}

	public static Dictionary<string, int> ChestRequirements(GameManagers managers, string itemId)
	{
		if (ItemType(itemId) != 11 && ItemType(itemId) != 16 && ItemType(itemId) != 29)
		{
			return null;
		}
		Dictionary<string, int> dictionary = null;
		List<Modifier> list = Effect(managers, itemId);
		if (list != null)
		{
			foreach (Modifier item in list)
			{
				if (!(item.ModifierId == "Cost"))
				{
					continue;
				}
				dictionary = new Dictionary<string, int>();
				Dictionary<string, object> payloadDictionary = item.PayloadDictionary;
				foreach (string key in payloadDictionary.Keys)
				{
					string s = payloadDictionary[key].ToString();
					dictionary.Add(key, int.Parse(s));
				}
				break;
			}
		}
		return dictionary;
	}

	public static List<Modifier> Effect(GameManagers managers, string itemId)
	{
		GDEItemData gDEItemData = GDMgr.Get<GDEItemData>(itemId);
		if (gDEItemData != null && !string.IsNullOrEmpty(gDEItemData.Effect))
		{
			List<Modifier> list = new List<Modifier>();
			foreach (KeyValuePair<string, object> item2 in JsonHelper.ToObject<Dictionary<string, object>>(gDEItemData.Effect))
			{
				Modifier item = new Modifier(managers, item2.Key, item2.Value);
				list.Add(item);
			}
			return list;
		}
		return null;
	}

	public static void DisplayItemTip(this string itemId, bool hideCheckBtn = true, ItemTipParams parameters = null)
	{
		ItemTipViewer itemTipViewer = new ItemTipViewer(itemId, hideCheckBtn);
		itemTipViewer.DisplayItemTip(parameters);
	}

	public static Dictionary<string, SoliderUnlockEffect> GetSoldierUnlock(this GDEItemData itemData)
	{
		if (itemData.ItemType == 10)
		{
			return JsonHelper.ToObject<Dictionary<string, SoliderUnlockEffect>>(itemData.Effect);
		}
		ILRuntimeDebug.LogError("GetSoldierUnlock only support SummonStone item type: " + itemData.Key);
		return null;
	}
}
