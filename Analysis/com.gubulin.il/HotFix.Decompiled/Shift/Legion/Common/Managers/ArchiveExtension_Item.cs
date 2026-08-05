using System;
using System.Collections.Generic;
using Assets.Scripts.Managers;
using GameDataEditor;
using Shift.Legion.Common.Helpers;
using Shift.Legion.Common.Models;

namespace Shift.Legion.Common.Managers;

public static class ArchiveExtension_Item
{
	private const string Key = "ITEM_LEVEL";

	private const string MaxLevelKey = "ITEM_MAX_LEVEL";

	private const string UnlockProductKey = "UNLOCK_PRODUCT";

	public static Dictionary<string, int> GetAllItemLevel(this UserArchiveManager manager)
	{
		return manager.GetConfigValue<Dictionary<string, int>>("ITEM_LEVEL");
	}

	internal static void SetAllItemLevel(this UserArchiveManager manager, Dictionary<string, int> value)
	{
		manager.SetConfigValue("ITEM_LEVEL", value);
	}

	public static int GetItemLevel(this UserArchiveManager manager, string itemId)
	{
		return manager.GetValueOfDictConfig<int>("ITEM_LEVEL", itemId);
	}

	public static int GetItemMaxLevel(this UserArchiveManager manager, string itemId)
	{
		return manager.GetValueOfDictConfig<int>("ITEM_MAX_LEVEL", itemId);
	}

	public static bool CheckMaterialLevel(this UserArchiveManager manager, string prodItemId, string materialItemId)
	{
		Dictionary<string, int> allItemLevel = manager.GetAllItemLevel();
		if (allItemLevel.TryGetValue(prodItemId, out var value) && allItemLevel.TryGetValue(materialItemId, out var value2))
		{
			return value2 >= value;
		}
		return true;
	}

	public static Action SetItemLevel(this UserArchiveManager manager, string itemId, int level, bool broadcastInform = true)
	{
		List<string> list = new List<string>();
		if (itemId == "CollectableResource")
		{
			list.AddRange(Item.CollectableItemList);
		}
		else
		{
			list.Add(itemId);
		}
		Action action = delegate
		{
		};
		Dictionary<string, int> allItemLevel = manager.GetAllItemLevel();
		foreach (string checkingItemId in list)
		{
			if (allItemLevel.ContainsKey(checkingItemId))
			{
				allItemLevel[checkingItemId] = level;
			}
			else
			{
				allItemLevel.Add(checkingItemId, level);
			}
			int levelNum = level;
			action = (Action)Delegate.Combine(action, (Action)delegate
			{
				string nameById = SchemaIndexHelper.GetNameById(manager.Managers, checkingItemId);
				string item = ((level <= 1) ? (nameById + LanguagesManager.GetDesc("CsharpCodeZhTcText615")) : string.Format("{0}{1}{2}{3}", nameById, LanguagesManager.GetDesc("CsharpCodeZhTcText811"), levelNum - 1, LanguagesManager.GetDesc("CsharpCodeZhTcText124")));
				SharedMessenger.Broadcast("SHOW_TIPS", new List<string> { item }, 103, arg3: false);
				manager.Managers.Messenger.Broadcast("ITEM_UPGRADE", checkingItemId, levelNum);
			});
		}
		manager.SetAllItemLevel(allItemLevel);
		if (broadcastInform)
		{
			action();
		}
		return action;
	}

	public static void SetItemMaxLevel(this UserArchiveManager manager, string itemId, int maxLevel)
	{
		List<string> list = new List<string>();
		if (itemId == "CollectableResource")
		{
			list.AddRange(Item.CollectableItemList);
		}
		else
		{
			list.Add(itemId);
		}
		foreach (string item in list)
		{
			manager.SetValueOfDictConfig("ITEM_MAX_LEVEL", itemId, maxLevel, acceptInsert: true);
		}
	}

	public static List<string> GetUnlockedProducts(this UserArchiveManager manager)
	{
		return manager.GetConfigValue<List<string>>("UNLOCK_PRODUCT");
	}

	public static Action UnlockProduct(this UserArchiveManager manager, string productId, bool broadcastInform = true)
	{
		string text = GDMgr.Get<GDEProductData>(productId)?.ItemId;
		if (string.IsNullOrEmpty(text))
		{
			return null;
		}
		int itemLevel = manager.GetItemLevel(text);
		if (itemLevel < 1)
		{
			manager.SetItemLevel(text, 1, broadcastInform);
		}
		List<string> unlockedProducts = manager.GetUnlockedProducts();
		if (!unlockedProducts.Contains(productId))
		{
			unlockedProducts.Add(productId);
			manager.SetConfigValue("UNLOCK_PRODUCT", unlockedProducts);
			Action action = delegate
			{
				manager.Managers.Messenger.Broadcast("PRODUCT_UNLOCKED", productId);
			};
			if (broadcastInform)
			{
				action();
			}
			return action;
		}
		return null;
	}

	public static int GetWeaponEvoLevel(this UserArchiveManager manager, string itemId, int specifiedLevel = 0)
	{
		if (Item.ItemType(itemId) != 2)
		{
			return 1;
		}
		int num = ((specifiedLevel > 0) ? specifiedLevel : manager.GetItemLevel(itemId));
		if (num < 1)
		{
			return 1;
		}
		if (num <= 40)
		{
			return (int)Math.Ceiling((float)num / 10f);
		}
		return (int)Math.Ceiling((float)(num - 40) / 20f) + 4;
	}

	public static int GetWeaponSubLevel(this UserArchiveManager manager, string itemId, int specifiedLevel = 0)
	{
		if (Item.ItemType(itemId) != 2)
		{
			return 1;
		}
		int num = ((specifiedLevel > 0) ? specifiedLevel : manager.GetItemLevel(itemId));
		if (num < 1)
		{
			return 1;
		}
		if (num <= 40)
		{
			return (num - 1) % 10;
		}
		return (num - 41) % 20;
	}

	public static int GetWeaponMaxLevel(this UserArchiveManager manager)
	{
		int num = 6;
		if (num < 0)
		{
			num = 0;
		}
		if (num < 5)
		{
			return num * 10;
		}
		return (num - 4) * 20 + 40;
	}
}
