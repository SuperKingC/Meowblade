using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Managers;
using GameDataEditor;
using HotFix.Sources.Base.Sources.Scripts.GvG3.GvG3Common.Model;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Manager;
using ObjectPool;
using Shift.Legion.ClientApi;
using Shift.Legion.ClientApi.Protocol.Modules.LegendItem.Models;
using Shift.Legion.ClientApi.Protocol.UserAction;
using Shift.Legion.Common.Enums;
using Shift.Legion.Common.Helpers;
using Shift.Legion.Common.Managers;
using Shift.Legion.Common.Models.LegendItem;
using Shift.Legion.Common.Sources.Enums;
using Shift.Legion.Helpers;

namespace Shift.Legion.Common.Models;

public class Bonus
{
	public const int TypeBonus = 1;

	public const int TypeUnlock = 2;

	public const int TypeLottery = 3;

	public const int CategoryItem = 0;

	public const int CategorySoldier = 1;

	public const int CategoryTechnology = 2;

	public const int CategoryModifier = 3;

	public const int CategoryProduct = 5;

	public const int CategoryFormation = 6;

	public const int CategoryLegendItem = 7;

	public const int CategoryDefault = 100;

	public readonly int Type;

	public readonly int Category;

	public readonly string Schema;

	public readonly string ItemId;

	public readonly int Qty;

	public readonly List<object> PayloadList;

	public readonly Dictionary<string, object> PayloadDict;

	public readonly byte[] ExtraData;

	public bool IsNewUnlock = false;

	private Action InformsToBroadcast;

	public int IsShining;

	private static readonly ConcurrentDictionary<(string, object, int), Bonus> Bonuses = new ConcurrentDictionary<(string, object, int), Bonus>();

	private bool isChangeStock = true;

	public static Bonus Get(string itemId, object payload, int type = 1, int isShining = 0, byte[] extraData = null)
	{
		return new Bonus(itemId, payload, type, extraData)
		{
			IsShining = isShining,
			isChangeStock = true
		};
	}

	private Bonus(string itemId, object payload, int type = 1, byte[] extraData = null)
	{
		if (type == 0)
		{
			type = 1;
		}
		Type = type;
		ItemId = itemId;
		IsShining = 0;
		Qty = 0;
		PayloadList = null;
		PayloadDict = null;
		ExtraData = extraData;
		if (!(payload is List<string> list))
		{
			if (!(payload is List<int> list2))
			{
				if (!(payload is ArrayList arrayList))
				{
					int result;
					if (payload is Dictionary<string, float> dictionary)
					{
						PayloadDict = new Dictionary<string, object>();
						foreach (KeyValuePair<string, float> item in dictionary)
						{
							PayloadDict.Add(item.Key, item.Value);
						}
					}
					else if (int.TryParse(payload.ToString(), out result))
					{
						Qty = result;
					}
				}
				else
				{
					PayloadList = new List<object>();
					foreach (object item2 in arrayList)
					{
						PayloadList.Add(item2);
					}
				}
			}
			else
			{
				PayloadList = new List<object>();
				foreach (int item3 in list2)
				{
					PayloadList.Add(item3);
				}
			}
		}
		else
		{
			PayloadList = new List<object>();
			foreach (string item4 in list)
			{
				PayloadList.Add(item4);
			}
		}
		Schema = SchemaIndexHelper.GetSchemaById(ItemId);
		switch (Schema)
		{
		case "Item":
		{
			Category = 0;
			GDEItemData gDEItemData3 = GDMgr.Get<GDEItemData>(ItemId);
			if (gDEItemData3 != null)
			{
				IsShining = gDEItemData3.Shining;
			}
			break;
		}
		case "Soldier":
			Category = 1;
			Schema = "Item";
			break;
		case "Modifier":
			Category = 3;
			break;
		case "Technology":
			Category = 2;
			Type = 2;
			break;
		case "Product":
		{
			Category = 5;
			GDEItemData gDEItemData2 = GDMgr.Get<GDEItemData>("I" + ItemId.Substring(1));
			if (gDEItemData2 != null)
			{
				IsShining = gDEItemData2.Shining;
			}
			break;
		}
		case "PrizePoolCombo":
			Type = 3;
			Category = 100;
			break;
		case "PrizePool":
			Category = 100;
			break;
		case "Formation":
			Category = 6;
			break;
		case "LegendItem":
			Category = 7;
			break;
		default:
		{
			Category = 0;
			GDEItemData gDEItemData = GDMgr.Get<GDEItemData>(ItemId);
			if (gDEItemData != null)
			{
				IsShining = gDEItemData.Shining;
			}
			break;
		}
		}
	}

	public string Desc(GameManagers managers)
	{
		switch (Category)
		{
		case 0:
		{
			GDEItemData gDEItemData = GDMgr.Get<GDEItemData>(ItemId);
			if (gDEItemData != null)
			{
				return gDEItemData.PostScript;
			}
			return string.Empty;
		}
		case 1:
			return GDMgr.Get<GDESoldierData>(ItemId).Name;
		case 3:
			if (PayloadDict != null)
			{
				return new Modifier(managers, ItemId, PayloadDict).Desc;
			}
			if (Qty > 0)
			{
				return new Modifier(managers, ItemId, Qty.ToString()).Desc;
			}
			return string.Empty;
		case 2:
		{
			string text = string.Empty;
			int key = managers.UserArchiveManager.GetTechLevel(ItemId) + 1;
			GDETechnologyData gDETechnologyData = GDMgr.Get<GDETechnologyData>(ItemId);
			if (gDETechnologyData != null)
			{
				Dictionary<int, List<Modifier>> dictionary = TechnologyData.Effects(managers, ItemId);
				if (!dictionary.TryGetValue(key, out var value))
				{
					value = dictionary.Values.Last();
				}
				foreach (Modifier item in value)
				{
					text = text + item.Desc + " ";
				}
			}
			if (string.IsNullOrEmpty(text) && gDETechnologyData != null)
			{
				text = gDETechnologyData.GainDescrible;
			}
			return text;
		}
		case 5:
			return GDMgr.Get<GDEItemData>("I" + ItemId.Substring(1))?.PostScript;
		case 100:
			return string.Empty;
		case 6:
			return LanguagesManager.GetDesc("CsharpCodeZhTcText755");
		default:
			return GDMgr.Get<GDEItemData>(ItemId)?.PostScript;
		}
	}

	public Bonus Merge(Bonus another)
	{
		if (CanMerge(this, another))
		{
			return Get(ItemId, Qty + another.Qty, Type);
		}
		return this;
	}

	private void ProcessItemUnlock(GameManagers managers, Dictionary<string, float> claimed, object context = null, bool forceClaim = true, bool broadcastInform = true)
	{
		if (PayloadList == null)
		{
			return;
		}
		foreach (object payload in PayloadList)
		{
			string itemId = payload.ToString();
			Bonus subBonus = Get(itemId, 0, 2);
			subBonus.Claim(managers, claimed, context, forceClaim, broadcastInform);
			if (!broadcastInform)
			{
				InformsToBroadcast = (Action)Delegate.Combine(InformsToBroadcast, (Action)delegate
				{
					subBonus.BroadcastInforms();
				});
			}
		}
	}

	private void ProcessItemAutoProduce(GameManagers managers, Dictionary<string, float> claimed, object context = null, bool forceClaim = true, bool broadcastInform = true)
	{
		if (PayloadDict == null)
		{
			return;
		}
		foreach (KeyValuePair<string, object> item in PayloadDict)
		{
			string key = item.Key;
			float num = Convert.ToSingle(item.Value);
			Action b = managers.UserArchiveManager.InsertAutoProduceBonus(key, num, context?.ToString(), broadcastInform);
			RecordClaimed(claimed, "AutoProduce." + key, num);
			if (!broadcastInform)
			{
				InformsToBroadcast = (Action)Delegate.Combine(InformsToBroadcast, b);
			}
		}
	}

	private void ProcessItemSoldierExp(GameManagers managers, Dictionary<string, float> claimed, object context = null, bool forceClaim = true, bool broadcastInform = true)
	{
		if (context != null)
		{
			string soldierId = ((context is Soldier soldier) ? soldier.Id : context.ToString());
			Action b = managers.SoldierLevelManager.AddExperience(Qty, soldierId, broadcastInform);
			RecordClaimed(claimed, "SoldierExp", Qty);
			if (!broadcastInform)
			{
				InformsToBroadcast = (Action)Delegate.Combine(InformsToBroadcast, b);
			}
		}
	}

	private void ProcessItemUserExp(GameManagers managers, Dictionary<string, float> claimed, object context = null, bool forceClaim = true, bool broadcastInform = true)
	{
		Action b = managers.UserArchiveManager.UserGainExp(Qty, broadcastInform);
		RecordClaimed(claimed, "UserExp", Qty);
		if (!broadcastInform)
		{
			InformsToBroadcast = (Action)Delegate.Combine(InformsToBroadcast, b);
		}
	}

	private void ProcessItemDungeonExp(GameManagers managers, Dictionary<string, float> claimed, object context = null, bool forceClaim = true, bool broadcastInform = true)
	{
		Action b = managers.UserArchiveManager.DungeonGainExp(Qty, broadcastInform);
		RecordClaimed(claimed, "DungeonExp", Qty);
		if (!broadcastInform)
		{
			InformsToBroadcast = (Action)Delegate.Combine(InformsToBroadcast, b);
		}
	}

	private void ProcessItemCollectableResource(GameManagers managers, Dictionary<string, float> claimed, object context = null, bool forceClaim = true, bool broadcastInform = true)
	{
		StockChangeRecord[] array = new StockChangeRecord[Item.CollectableItemList.Count];
		int num = 0;
		foreach (string collectableItem in Item.CollectableItemList)
		{
			array[num++] = new StockChangeRecord
			{
				ItemId = collectableItem,
				Offset = Qty,
				Context = 4,
				ContextValue = collectableItem,
				Type = (forceClaim ? 1 : 0)
			};
			RecordClaimed(claimed, collectableItem, Qty);
		}
		if (isChangeStock)
		{
			managers.StockController.ReadStockChangeRecords(array);
		}
		Action action = delegate
		{
			SharedMessenger.Broadcast("SHOW_TIPS", new List<string> { string.Format("{0}{1}{2}", LanguagesManager.GetDesc("CsharpCodeZhTcText757"), (Qty >= 0) ? "+" : "-", Qty) }, 121, arg3: false);
		};
		if (broadcastInform)
		{
			action();
		}
		else
		{
			InformsToBroadcast = (Action)Delegate.Combine(InformsToBroadcast, action);
		}
	}

	private void ProcessItemBuildingExtraSlot(GameManagers managers, Dictionary<string, float> claimed, object context = null, bool forceClaim = true, bool broadcastInform = true)
	{
		Building value = context as Building;
		string text;
		string buildingName;
		if (value != null)
		{
			text = value.BuildingType;
			buildingName = value.Name;
		}
		else
		{
			if (!(context is string text2) || !managers.BuildingManager.Buildings.TryGetValue(text2, out value))
			{
				return;
			}
			text = text2;
			buildingName = value.Name;
		}
		int newSlots = managers.UserArchiveManager.GetExtraBuildingSlots(text) + Qty;
		managers.UserArchiveManager.SetExtraBuildingSlots(text, newSlots);
		RecordClaimed(claimed, "BuildingExtraSlot." + text, Qty);
		Action action = delegate
		{
			SharedMessenger.Broadcast("SHOW_TIPS", new List<string> { string.Format("{0}{1}{2}", buildingName, LanguagesManager.GetDesc("CsharpCodeZhTcText758"), newSlots) }, 121, arg3: false);
		};
		if (broadcastInform)
		{
			action();
		}
		else
		{
			InformsToBroadcast = (Action)Delegate.Combine(InformsToBroadcast, action);
		}
	}

	private Dictionary<string, int> ProcessItemCard(GameManagers managers, Dictionary<string, float> claimed, object context = null, bool forceClaim = true, bool broadcastInform = true)
	{
		Dictionary<string, int> dictionary = new Dictionary<string, int>();
		List<Modifier> list = Item.Effect(managers, ItemId);
		if (list == null)
		{
			return dictionary;
		}
		foreach (Modifier item in list)
		{
			if (item.ModifierId != "Bonus")
			{
				continue;
			}
			foreach (KeyValuePair<string, object> item2 in item.PayloadDictionary)
			{
				if (dictionary.ContainsKey(item2.Key))
				{
					dictionary[item2.Key] += Convert.ToInt32(item2.Value) * Qty;
				}
				else
				{
					dictionary.Add(item2.Key, Convert.ToInt32(item2.Value) * Qty);
				}
			}
		}
		return dictionary;
	}

	private void ProcessPotentialLevel(GameManagers managers, Dictionary<string, float> claimed, object context = null, bool forceClaim = true, bool broadcastInform = true)
	{
		if (PayloadDict.Count != 0)
		{
			string soldierId = PayloadDict.First().Key;
			int newPotentialLevel = (int)PayloadDict.First().Value;
			int curPotentialLevel = managers.UserArchiveManager.GetSoldierPotentialLevel(soldierId);
			string text = $"skin{(newPotentialLevel + 2) / 2}";
			if (newPotentialLevel == 9)
			{
				text = "skin6";
			}
			string soldierSkin = managers.UserArchiveManager.GetSoldierSkin(soldierId);
			if (soldierSkin != text)
			{
				managers.UserArchiveManager.SetSoldierSkin(soldierId, text);
			}
			managers.UserArchiveManager.SetSoldierPotentialLevel(soldierId, newPotentialLevel, refundProgress: true);
			Action action = delegate
			{
				managers.Messenger.Broadcast("SOLDIER_SUMMONING", soldierId, newPotentialLevel - curPotentialLevel, new Dictionary<string, int>());
			};
			if (broadcastInform)
			{
				action();
			}
			else
			{
				InformsToBroadcast = (Action)Delegate.Combine(InformsToBroadcast, action);
			}
		}
	}

	private Dictionary<string, int> ProcessItemSummonStone(GameManagers managers, Dictionary<string, float> claimed, object context = null, bool forceClaim = true, bool broadcastInform = true)
	{
		Dictionary<string, int> dictionary = new Dictionary<string, int>();
		List<Modifier> list = Item.Effect(managers, ItemId);
		if (list == null)
		{
			return dictionary;
		}
		List<string> unlockedSoldiers = managers.UserArchiveManager.GetUnlockedSoldiers();
		foreach (Modifier item in list)
		{
			string soldierId = item.ModifierId;
			int curPotentialLevel = managers.UserArchiveManager.GetSoldierPotentialLevel(soldierId);
			int newPotentialLevel = 0;
			if (item.PayloadDictionary.TryGetValue("PotentialLevel", out var value))
			{
				newPotentialLevel = Convert.ToInt32(value);
			}
			int num = Qty;
			if (!unlockedSoldiers.Contains(soldierId))
			{
				IsNewUnlock = true;
				Bonus unlockSoldierBonus = Get(soldierId, new List<int> { 1, newPotentialLevel }, 2);
				unlockSoldierBonus.Claim(managers, claimed, context, forceClaim, broadcastInform);
				int num2 = ConfigDataManager.VolunteersOnSoldierUnlock;
				if (soldierId == "S001" || soldierId == "S002" || soldierId == "S005")
				{
					num2 = 10;
				}
				RecordClaimed(claimed, soldierId, num2);
				curPotentialLevel = newPotentialLevel;
				if (!broadcastInform)
				{
					InformsToBroadcast = (Action)Delegate.Combine(InformsToBroadcast, (Action)delegate
					{
						unlockSoldierBonus.BroadcastInforms();
					});
				}
				num--;
			}
			if (num <= 0)
			{
				continue;
			}
			Dictionary<string, int> convertBonuses;
			if (newPotentialLevel > curPotentialLevel)
			{
				string text = $"skin{(newPotentialLevel + 2) / 2}";
				if (newPotentialLevel == 9)
				{
					text = "skin6";
				}
				string soldierSkin = managers.UserArchiveManager.GetSoldierSkin(soldierId);
				if (soldierSkin != text)
				{
					managers.UserArchiveManager.SetSoldierSkin(soldierId, text);
				}
				managers.UserArchiveManager.SetSoldierPotentialLevel(soldierId, newPotentialLevel, refundProgress: true);
				RecordClaimed(claimed, "PotentialLevel." + soldierId, newPotentialLevel);
				convertBonuses = SearchSummonStoneBonusByPotential(managers, soldierId, curPotentialLevel);
				foreach (KeyValuePair<string, int> item2 in convertBonuses)
				{
					if (dictionary.ContainsKey(item2.Key))
					{
						dictionary[item2.Key] += item2.Value;
					}
					else
					{
						dictionary.Add(item2.Key, item2.Value);
					}
				}
				Action action = delegate
				{
					managers.Messenger.Broadcast("SOLDIER_SUMMONING", soldierId, newPotentialLevel - curPotentialLevel, convertBonuses);
				};
				if (broadcastInform)
				{
					action();
				}
				else
				{
					InformsToBroadcast = (Action)Delegate.Combine(InformsToBroadcast, action);
				}
				num--;
			}
			if (num <= 0)
			{
				continue;
			}
			convertBonuses = SearchSummonStoneBonusByPotential(managers, soldierId, newPotentialLevel);
			Action action2 = delegate
			{
				managers.Messenger.Broadcast("SOLDIER_SUMMONING", soldierId, newPotentialLevel - curPotentialLevel, convertBonuses);
			};
			if (broadcastInform)
			{
				action2();
			}
			else
			{
				InformsToBroadcast = (Action)Delegate.Combine(InformsToBroadcast, action2);
			}
			foreach (KeyValuePair<string, int> item3 in convertBonuses)
			{
				if (dictionary.ContainsKey(item3.Key))
				{
					dictionary[item3.Key] += item3.Value * num;
				}
				else
				{
					dictionary.Add(item3.Key, item3.Value * num);
				}
			}
		}
		return dictionary;
	}

	private Dictionary<string, int> ProcessItemBlueprint(GameManagers managers, Dictionary<string, float> claimed, object context = null, bool forceClaim = true, bool broadcastInform = true)
	{
		Dictionary<string, int> result = new Dictionary<string, int>();
		List<Modifier> list = Item.Effect(managers, ItemId);
		if (list == null)
		{
			return result;
		}
		foreach (Modifier item in list)
		{
			if (item.ModifierId != "Bonus")
			{
				continue;
			}
			foreach (KeyValuePair<string, object> item2 in item.PayloadDictionary)
			{
				if (item2.Key == "Unlock")
				{
					foreach (string item3 in (List<string>)item2.Value)
					{
						Bonus bonus = Get(item3, Qty, 2);
						bonus.Claim(managers, claimed, context, forceClaim, broadcastInform);
					}
				}
				else
				{
					Bonus bonus2 = Get(item2.Key, (float)item2.Value * (float)Qty);
					bonus2.Claim(managers, claimed, context, forceClaim, broadcastInform);
				}
			}
		}
		return result;
	}

	private Dictionary<string, int> ProcessItemLeasehold(GameManagers managers, Dictionary<string, float> claimed, object context = null, bool forceClaim = true, bool broadcastInform = true)
	{
		Dictionary<string, int> result = new Dictionary<string, int> { { ItemId, Qty } };
		managers.LeaseholdManager.RegisterLeaseholdItem(ItemId);
		return result;
	}

	private Dictionary<string, int> ProcessUnlockMainCityComItem(GameManagers managers)
	{
		List<Modifier> list = Item.Effect(managers, ItemId);
		if (list.Count <= 0)
		{
			return null;
		}
		if (list.First().ModifierId != "UnlockMainCityCom")
		{
			throw new Exception("ItemId=" + ItemId + " , ModifierId 不为 UnlockMainCityCom");
		}
		return new Dictionary<string, int> { { ItemId, Qty } };
	}

	private Dictionary<string, int> ProcessUnlockFormationSlots(GameManagers managers)
	{
		List<Modifier> list = Item.Effect(managers, ItemId);
		if (list.Count <= 0)
		{
			return null;
		}
		if (list.First().ModifierId != "UnlockFormationSlots")
		{
			throw new Exception("ItemId=" + ItemId + " , ModifierId 不为 UnlockFormationSlots");
		}
		return null;
	}

	private Dictionary<string, int> ProcessUnlockBuilding(GameManagers managers)
	{
		List<Modifier> list = Item.Effect(managers, ItemId);
		if (list.Count <= 0)
		{
			return null;
		}
		if (list.First().ModifierId != "UnlockBuilding")
		{
			throw new Exception("ItemId=" + ItemId + " , ModifierId 不为 UnlockBuilding");
		}
		return null;
	}

	private Dictionary<string, int> ProcessUnlockActivityLevelCase(GameManagers managers)
	{
		List<Modifier> list = Item.Effect(managers, ItemId);
		if (list.Count <= 0)
		{
			return null;
		}
		if (list.First().ModifierId != "UnlockActivityLevelCase")
		{
			throw new Exception("ItemId=" + ItemId + " , ModifierId 不为 UnlockActivityLevelCase");
		}
		return null;
	}

	private Dictionary<string, int> ProcessIncreaseSoldierStockLimit(GameManagers managers)
	{
		List<Modifier> list = Item.Effect(managers, ItemId);
		if (list.Count <= 0)
		{
			return null;
		}
		if (list.First().ModifierId != "IncreaseSoldierStockLimit")
		{
			throw new Exception("ItemId=" + ItemId + " , ModifierId 不为 IncreaseSoldierStockLimit");
		}
		return null;
	}

	private Dictionary<string, int> ProcessIncreaseSoldierQuantityInStock(GameManagers managers)
	{
		List<Modifier> list = Item.Effect(managers, ItemId);
		if (list.Count <= 0)
		{
			return null;
		}
		if (list.First().ModifierId != "IncreaseSoldierQuantityInStock")
		{
			throw new Exception("ItemId=" + ItemId + " , ModifierId 不为 IncreaseSoldierQuantityInStock");
		}
		return null;
	}

	private Dictionary<string, int> UseSoulKey(GameManagers managers)
	{
		GDEItemData gDEItemData = GDMgr.Get<GDEItemData>(ItemId);
		SoulKeyItemEffect soulKeyItemEffect = JsonHelper.ToObject<SoulKeyItemEffect>(gDEItemData.Effect);
		int soldierPotentialLevel = managers.UserArchiveManager.GetSoldierPotentialLevel(soulKeyItemEffect.SoldierId);
		if (soldierPotentialLevel >= soulKeyItemEffect.PotentialLevel)
		{
			managers.StockController.ChangeStock(ItemId, -Qty, StockInContext.GiveBackSoulKey, ItemId);
			foreach (KeyValuePair<string, int> item in soulKeyItemEffect.GiveBack)
			{
				managers.StockController.ChangeStock(item.Key, item.Value * Qty, StockInContext.GiveBackSoulKey, ItemId);
			}
		}
		return null;
	}

	private Dictionary<string, int> ProcessFundCert(GameManagers managers, Dictionary<string, float> claimed, object context, bool forceClaim, bool broadcastInform)
	{
		List<Modifier> list = Item.Effect(managers, ItemId);
		foreach (Modifier item in list)
		{
			if (!(item.ModifierId == "Activity"))
			{
				continue;
			}
			Activity activity = ActivityManager.Activities[item.PayloadDictionary["Payload"].ToString()];
			activity.CheckStatus(managers, out var _, sendEvent: false);
			foreach (KeyValuePair<string, ActivityContentPayload> item2 in activity.ContentPayload(managers))
			{
				string key = item2.Key;
				if (!(item2.Value is MissionSerialActivityPayload missionSerialActivityPayload))
				{
					ILRuntimeDebug.LogError(ItemId + "基金凭证配置错误 " + key);
				}
				else
				{
					missionSerialActivityPayload.Missions(managers);
				}
			}
		}
		return new Dictionary<string, int> { { ItemId, Qty } };
	}

	private Dictionary<string, int> SearchSummonStoneBonusByPotential(GameManagers managers, string searchSoldierId, int searchPotentialLevel)
	{
		foreach (string item in ConfigDataManager.ItemsByType[ItemType.SummonStone])
		{
			List<Modifier> list = Item.Effect(managers, item);
			foreach (Modifier item2 in list)
			{
				if (!(item2.ModifierId == searchSoldierId) || !item2.PayloadDictionary.TryGetValue("PotentialLevel", out var value))
				{
					continue;
				}
				int num = Convert.ToInt32(value);
				if (searchPotentialLevel != num || !item2.PayloadDictionary.TryGetValue("Bonus", out var value2))
				{
					continue;
				}
				Dictionary<string, object> dictionary = (Dictionary<string, object>)value2;
				Dictionary<string, int> dictionary2 = new Dictionary<string, int>();
				foreach (string key in dictionary.Keys)
				{
					dictionary2.Add(key, int.Parse(dictionary[key].ToString()));
				}
				return dictionary2;
			}
		}
		return new Dictionary<string, int>();
	}

	private void ClaimItemBonus(GameManagers managers, Dictionary<string, float> claimed, object context = null, bool forceClaim = true, bool broadcastInform = true)
	{
		switch (ItemId)
		{
		case "PotentialLevel":
			ProcessPotentialLevel(managers, claimed, context, forceClaim, broadcastInform);
			return;
		case "Unlock":
			ProcessItemUnlock(managers, claimed, context, forceClaim, broadcastInform);
			return;
		case "AutoProduce":
			ProcessItemAutoProduce(managers, claimed, context, forceClaim, broadcastInform);
			return;
		case "SoldierExp":
			ProcessItemSoldierExp(managers, claimed, context, forceClaim, broadcastInform);
			return;
		case "UserExp":
			ProcessItemUserExp(managers, claimed, context, forceClaim, broadcastInform);
			return;
		case "DungeonExp":
			ProcessItemDungeonExp(managers, claimed, context, forceClaim, broadcastInform);
			return;
		case "CollectableResource":
			ProcessItemCollectableResource(managers, claimed, context, forceClaim, broadcastInform);
			return;
		case "BuildingExtraSlot":
			ProcessItemBuildingExtraSlot(managers, claimed, context, forceClaim, broadcastInform);
			return;
		}
		Dictionary<string, int> dictionary = null;
		GDEItemData gDEItemData = GDMgr.Get<GDEItemData>(ItemId);
		if (gDEItemData == null)
		{
			return;
		}
		dictionary = (ItemType)Item.ItemType(ItemId) switch
		{
			ItemType.Card => ProcessItemCard(managers, claimed, context, forceClaim, broadcastInform), 
			ItemType.SummonStone => ProcessItemSummonStone(managers, claimed, context, forceClaim, broadcastInform), 
			ItemType.Blueprint => ProcessItemBlueprint(managers, claimed, context, forceClaim, broadcastInform), 
			ItemType.Leasehold => ProcessItemLeasehold(managers, claimed, context, forceClaim, broadcastInform), 
			ItemType.FundCert => ProcessFundCert(managers, claimed, context, forceClaim, broadcastInform), 
			ItemType.UnlockMainCityComItem => ProcessUnlockMainCityComItem(managers), 
			ItemType.UnlockFormationSlot => ProcessUnlockFormationSlots(managers), 
			ItemType.UnlockBuilding => ProcessUnlockBuilding(managers), 
			ItemType.UnlockActivityLevelCase => ProcessUnlockActivityLevelCase(managers), 
			ItemType.IncreaseSoldierStockLimit => ProcessIncreaseSoldierStockLimit(managers), 
			ItemType.IncreaseSoldierQuantityInStock => ProcessIncreaseSoldierQuantityInStock(managers), 
			ItemType.UnLockMissionOf7daysGift => ProcessUnLockMissionOf7Days2Gift(managers), 
			ItemType.GvGStoreAddExchangeableRefreshCount => ProcessGvGStoreRefreshCount(), 
			_ => new Dictionary<string, int> { { ItemId, Qty } }, 
		};
		if (dictionary == null)
		{
			return;
		}
		StockChangeRecord[] array = new StockChangeRecord[dictionary.Count];
		int num = 0;
		int type = (forceClaim ? 1 : 0);
		StockInContext context2 = StockInContext.Bonus;
		if (context is StockInContext stockInContext)
		{
			context2 = stockInContext;
		}
		foreach (KeyValuePair<string, int> bonusKv in dictionary)
		{
			string bonusKey = bonusKv.Key;
			int value = bonusKv.Value;
			array[num++] = new StockChangeRecord
			{
				ItemId = bonusKey,
				Offset = value,
				Context = (int)context2,
				ContextValue = bonusKey,
				Type = type
			};
			if (claimed.ContainsKey(bonusKey))
			{
				claimed[bonusKey] += value;
			}
			else
			{
				claimed.Add(bonusKey, value);
			}
			Action action = delegate
			{
				SharedMessenger.Broadcast("SHOW_TIPS", new List<string> { string.Format("{0}{1}{2}", SchemaIndexHelper.GetNameById(managers, bonusKey), (bonusKv.Value >= 0) ? "+" : "", bonusKv.Value) }, 999, arg3: false);
			};
			if (broadcastInform)
			{
				action();
			}
			else
			{
				InformsToBroadcast = (Action)Delegate.Combine(InformsToBroadcast, action);
			}
		}
		if (isChangeStock)
		{
			managers.StockController.ReadStockChangeRecords(array);
		}
	}

	private void ClaimSoldierBonus(GameManagers managers, Dictionary<string, float> claimed, object context = null, bool forceClaim = true, bool broadcastInform = true)
	{
		if (isChangeStock)
		{
			managers.StockController.ReadStockChangeRecords(new StockChangeRecord[1]
			{
				new StockChangeRecord
				{
					ItemId = ItemId,
					Offset = Qty,
					Context = 4,
					ContextValue = ItemId,
					Type = (forceClaim ? 1 : 0)
				}
			});
		}
		RecordClaimed(claimed, ItemId, Qty);
		Action action = delegate
		{
			SharedMessenger.Broadcast("SHOW_TIPS", new List<string> { string.Format("{0}{1}{2}", managers.SoldierManager.Get(ItemId).Name, (Qty >= 0) ? "+" : "-", Qty) }, 121, arg3: false);
		};
		if (broadcastInform)
		{
			action();
		}
		else
		{
			InformsToBroadcast = (Action)Delegate.Combine(InformsToBroadcast, action);
		}
	}

	private Dictionary<string, int> ProcessGvGStoreRefreshCount()
	{
		GDEItemData gDEItemData = GDMgr.Get<GDEItemData>(ItemId);
		if (string.IsNullOrEmpty(gDEItemData?.Effect))
		{
			return null;
		}
		GvGStoreAddExchangeableRefreshCount gvGStoreAddExchangeableRefreshCount = JsonHelper.ToObject<GvGStoreAddExchangeableRefreshCount>(gDEItemData.Effect);
		Singleton<GvG3StoreManager>.Instance.AddRemainingExchangeableRefreshCount(gvGStoreAddExchangeableRefreshCount.AddRefreshCount * Qty);
		return null;
	}

	private Dictionary<string, int> ProcessUnLockMissionOf7Days2Gift(GameManagers managers)
	{
		managers.UserArchiveManager.SetMissionOf7UnLockBonus(value: true);
		return new Dictionary<string, int> { { ItemId, Qty } };
	}

	private void ClaimModifierBonus(GameManagers managers, Dictionary<string, float> claimed, object context = null, bool forceClaim = true, bool broadcastInform = true)
	{
		Modifier modifier = new Modifier(managers, ItemId, Qty.ToString());
		managers.ModifierManager.ReadFromModifier(modifier);
		RecordClaimed(claimed, ItemId, Qty);
		Action action = delegate
		{
			SharedMessenger.Broadcast("SHOW_TIPS", new List<string> { modifier.Desc }, 121, arg3: false);
		};
		if (broadcastInform)
		{
			action();
		}
		else
		{
			InformsToBroadcast = (Action)Delegate.Combine(InformsToBroadcast, action);
		}
	}

	private void ClaimLegendItem(GameManagers managers, Dictionary<string, float> claimed, object context, bool forceClaim, bool broadcastInform)
	{
		if (ExtraData != null)
		{
			Shift.Legion.Common.Models.LegendItem.LegendItem legendItem = new Shift.Legion.Common.Models.LegendItem.LegendItem(managers, ExtraData.Deserialize<Shift.Legion.ClientApi.Protocol.Modules.LegendItem.Models.LegendItem>());
			managers.InventoryManager.ReceiveLegendItem(legendItem);
			RecordClaimed(claimed, $"{legendItem.InstanceId}", Qty);
		}
	}

	private void ClaimItemUnlockBonus(GameManagers managers, Dictionary<string, float> claimed, object context = null, bool forceClaim = true, bool broadcastInform = true)
	{
		List<string> list = new List<string>();
		string itemId = ItemId;
		string text = itemId;
		if (text == "CollectableResource")
		{
			list.AddRange(Item.CollectableItemList);
		}
		else
		{
			list.Add(ItemId);
		}
		foreach (string item in list)
		{
			int num = managers.UserArchiveManager.GetItemLevel(item);
			if (num < 1 && BuildingManager.ProductIDs.Contains("P" + item.Substring(1)))
			{
				managers.UserArchiveManager.UnlockProduct(item);
			}
			int num2 = 0;
			while (num2 < Qty)
			{
				Dictionary<string, int> dictionary = Item.EvoRequirement(managers, item, num);
				if (dictionary == null)
				{
					break;
				}
				num2++;
				num++;
			}
			Action b = managers.UserArchiveManager.SetItemLevel(item, num, broadcastInform);
			if (!broadcastInform)
			{
				InformsToBroadcast = (Action)Delegate.Combine(InformsToBroadcast, b);
			}
			RecordClaimed(claimed, "Unlock." + item, Qty);
		}
	}

	private void ClaimSoldierUnlockBonus(GameManagers managers, Dictionary<string, float> claimed, object context = null, bool forceClaim = true, bool broadcastInform = true)
	{
		List<string> unlockedSoldiers = managers.UserArchiveManager.GetUnlockedSoldiers();
		if (!unlockedSoldiers.Contains(ItemId))
		{
			IsNewUnlock = true;
			int num = ((PayloadList != null) ? ((PayloadList.Count > 1) ? Convert.ToInt32(PayloadList[1]) : 0) : 0);
			Action b = managers.SoldierManager.Unlock(ItemId, num, -1, broadcastInform);
			RecordClaimed(claimed, "Unlock." + ItemId, num);
			if (!broadcastInform)
			{
				InformsToBroadcast = (Action)Delegate.Combine(InformsToBroadcast, b);
			}
		}
	}

	private void ClaimProductUnlockBonus(GameManagers managers, Dictionary<string, float> claimed, object context = null, bool forceClaim = true, bool broadcastInform = true)
	{
		List<string> unlockedProducts = managers.UserArchiveManager.GetUnlockedProducts();
		if (!unlockedProducts.Contains(ItemId))
		{
			IsNewUnlock = true;
			Action b = managers.UserArchiveManager.UnlockProduct(ItemId, broadcastInform);
			RecordClaimed(claimed, "Unlock." + ItemId, 1f);
			if (!broadcastInform)
			{
				InformsToBroadcast = (Action)Delegate.Combine(InformsToBroadcast, b);
			}
		}
	}

	private void ClaimTechUnlockBonus(GameManagers managers, Dictionary<string, float> claimed, object context = null, bool forceClaim = true, bool broadcastInform = true)
	{
		int num = Qty;
		int techLevel = managers.UserArchiveManager.GetTechLevel(ItemId);
		if (techLevel < 1)
		{
			Action b = managers.TechnologyManager.Upgrade(ItemId, free: true, broadcastInform);
			if (!broadcastInform)
			{
				InformsToBroadcast = (Action)Delegate.Combine(InformsToBroadcast, b);
			}
			RecordClaimed(claimed, "Unlock." + ItemId, 1f);
			num--;
		}
		if (num < 1)
		{
			return;
		}
		Dictionary<string, int> upgradeRequirements = TechnologyData.GetUpgradeRequirements(ItemId, 1);
		if (upgradeRequirements == null)
		{
			return;
		}
		StockChangeRecord[] array = new StockChangeRecord[upgradeRequirements.Count];
		int num2 = 0;
		int techPointCnt = 0;
		foreach (KeyValuePair<string, int> item in upgradeRequirements)
		{
			string reqItemId = item.Key;
			int reqQty = item.Value * num;
			array[num2++] = new StockChangeRecord
			{
				ItemId = reqItemId,
				Offset = reqQty,
				Context = 4,
				ContextValue = ItemId,
				Type = (forceClaim ? 1 : 0)
			};
			RecordClaimed(claimed, reqItemId, reqQty);
			if (reqItemId == "TechPoint")
			{
				techPointCnt += reqQty;
				continue;
			}
			Action action = delegate
			{
				SharedMessenger.Broadcast("SHOW_TIPS", new List<string> { string.Format("{0}{1}{2}", SchemaIndexHelper.GetNameById(managers, reqItemId), (reqQty >= 0) ? "+" : "", reqQty) }, 999, arg3: false);
			};
			if (broadcastInform)
			{
				action();
			}
			else
			{
				InformsToBroadcast = (Action)Delegate.Combine(InformsToBroadcast, action);
			}
		}
		if (isChangeStock)
		{
			managers.StockController.ReadStockChangeRecords(array);
		}
		if (techPointCnt > 0)
		{
			Action action2 = delegate
			{
				SharedMessenger.Broadcast("SHOW_TIPS", new List<string> { string.Format("{0}\r\n{1}{2}+{3}", LanguagesManager.GetDesc("CsharpCodeZhTcText759"), LanguagesManager.GetDesc("CsharpCodeZhTcText760"), SchemaIndexHelper.GetNameById(managers, "TechPoint"), techPointCnt) }, 999, arg3: false);
			};
			if (broadcastInform)
			{
				action2();
			}
			else
			{
				InformsToBroadcast = (Action)Delegate.Combine(InformsToBroadcast, action2);
			}
		}
	}

	private void ClaimFormationUnlockBonus(GameManagers managers, Dictionary<string, float> claimed, object context = null, bool forceClaim = true, bool broadcastInform = true)
	{
		managers.FormationManager.UnlockFormation(ItemId, free: true);
		RecordClaimed(claimed, "Unlock." + ItemId, Qty);
	}

	private void ClaimLotteryBonus(GameManagers managers, Dictionary<string, float> claimed, object context = null, bool forceClaim = true, bool broadcastInform = true)
	{
		for (int i = 0; i < Qty; i++)
		{
			foreach (KeyValuePair<Bonus, int> item in managers.LotteryManager.GetLotteryAsListById(ItemId))
			{
				Bonus lotteryBonus = item.Key;
				Dictionary<string, float> claimedDict = lotteryBonus.Claim(managers, null, context, forceClaim, broadcastInform);
				RecordClaimed(claimed, claimedDict);
				if (!broadcastInform)
				{
					InformsToBroadcast = (Action)Delegate.Combine(InformsToBroadcast, (Action)delegate
					{
						lotteryBonus.BroadcastInforms();
					});
				}
			}
		}
	}

	public Dictionary<string, float> Claim(GameManagers managers, Dictionary<string, float> claimed = null, object context = null, bool forceClaim = true, bool broadcastInform = true, bool _isChangeStock = true)
	{
		isChangeStock = _isChangeStock;
		if (claimed == null)
		{
			claimed = new Dictionary<string, float>();
		}
		if (ItemId == null)
		{
			return claimed;
		}
		switch (Type)
		{
		case 1:
			switch (Category)
			{
			case 0:
				ClaimItemBonus(managers, claimed, context, forceClaim, broadcastInform);
				break;
			case 1:
				ClaimSoldierBonus(managers, claimed, context, forceClaim, broadcastInform);
				break;
			case 3:
				ClaimModifierBonus(managers, claimed, context, forceClaim, broadcastInform);
				break;
			case 7:
				ClaimLegendItem(managers, claimed, context, forceClaim, broadcastInform);
				break;
			}
			break;
		case 2:
			switch (Category)
			{
			case 0:
				ClaimItemUnlockBonus(managers, claimed, context, forceClaim, broadcastInform);
				break;
			case 1:
				ClaimSoldierUnlockBonus(managers, claimed, context, forceClaim, broadcastInform);
				break;
			case 5:
				ClaimProductUnlockBonus(managers, claimed, context, forceClaim, broadcastInform);
				break;
			case 2:
				ClaimTechUnlockBonus(managers, claimed, context, forceClaim, broadcastInform);
				break;
			case 6:
				ClaimFormationUnlockBonus(managers, claimed, context, forceClaim, broadcastInform);
				break;
			}
			break;
		case 3:
			ClaimLotteryBonus(managers, claimed, context, forceClaim, broadcastInform);
			break;
		}
		return claimed;
	}

	private void RecordByContext(object context)
	{
	}

	public bool HasNewUnlock(GameManagers managers)
	{
		if (Type == 1)
		{
			if (Category == 0)
			{
				switch ((ItemType)Item.ItemType(ItemId))
				{
				case ItemType.Card:
				{
					List<Modifier> list2 = Item.Effect(managers, ItemId);
					if (list2 == null)
					{
						break;
					}
					List<string> unlockedSoldiers2 = managers.UserArchiveManager.GetUnlockedSoldiers();
					foreach (Modifier item in list2)
					{
						if (item.ModifierId != "Bonus")
						{
							continue;
						}
						foreach (KeyValuePair<string, object> item2 in item.PayloadDictionary)
						{
							if (!unlockedSoldiers2.Contains(item2.Key))
							{
								return true;
							}
						}
					}
					break;
				}
				case ItemType.SummonStone:
				{
					List<Modifier> list = Item.Effect(managers, ItemId);
					if (list == null)
					{
						break;
					}
					List<string> unlockedSoldiers = managers.UserArchiveManager.GetUnlockedSoldiers();
					foreach (Modifier item3 in list)
					{
						string modifierId = item3.ModifierId;
						if (!unlockedSoldiers.Contains(modifierId))
						{
							return true;
						}
					}
					break;
				}
				}
			}
		}
		else
		{
			switch (Category)
			{
			case 1:
			{
				List<string> unlockedSoldiers3 = managers.UserArchiveManager.GetUnlockedSoldiers();
				return !unlockedSoldiers3.Contains(ItemId);
			}
			case 5:
			{
				List<string> unlockedProducts = managers.UserArchiveManager.GetUnlockedProducts();
				return !unlockedProducts.Contains(ItemId);
			}
			}
		}
		return false;
	}

	public void BroadcastInforms()
	{
		if (InformsToBroadcast != null)
		{
			InformsToBroadcast();
			InformsToBroadcast = null;
		}
	}

	public static Bonus Merge(Bonus bonusA, Bonus bonusB)
	{
		if (CanMerge(bonusA, bonusB))
		{
			return Get(bonusA.ItemId, bonusA.Qty + bonusB.Qty, bonusA.Type);
		}
		return bonusA;
	}

	public static bool CanMerge(Bonus bonusA, Bonus bonusB)
	{
		return bonusA.ItemId == bonusB.ItemId && bonusA.Type == bonusB.Type;
	}

	private static void RecordClaimed(Dictionary<string, float> claimed, Dictionary<string, float> claimedDict)
	{
		if (claimedDict == null)
		{
			return;
		}
		foreach (KeyValuePair<string, float> item in claimedDict)
		{
			RecordClaimed(claimed, item.Key, item.Value);
		}
	}

	private static void RecordClaimed(Dictionary<string, float> claimed, string key, float val)
	{
		if (claimed.ContainsKey(key))
		{
			claimed[key] += val;
		}
		else
		{
			claimed.Add(key, val);
		}
	}

	public static List<Bonus> MergeBonuses(List<Bonus> bonuses, List<Bonus> mergedBonuses = null)
	{
		if (mergedBonuses == null)
		{
			mergedBonuses = new List<Bonus>();
		}
		PooledList<(string, int)> val = ObjectPool<PooledList<(string, int)>>.Spawn((Func<PooledList<(string, int)>>)(() => new PooledList<(string, int)>()));
		foreach (Bonus bonuse in bonuses)
		{
			MergeBonuses((List<(string, int)>)(object)val, mergedBonuses, bonuse);
		}
		val.UnSpawn();
		return mergedBonuses;
	}

	public static List<Bonus> MergeBonuses(Dictionary<string, List<Bonus>> bonuses, List<Bonus> mergedBonuses = null)
	{
		if (mergedBonuses == null)
		{
			mergedBonuses = new List<Bonus>();
		}
		PooledList<(string, int)> val = ObjectPool<PooledList<(string, int)>>.Spawn((Func<PooledList<(string, int)>>)(() => new PooledList<(string, int)>()));
		foreach (KeyValuePair<string, List<Bonus>> bonuse in bonuses)
		{
			foreach (Bonus item in bonuse.Value)
			{
				MergeBonuses((List<(string, int)>)(object)val, mergedBonuses, item);
			}
		}
		val.UnSpawn();
		return mergedBonuses;
	}

	private static void MergeBonuses(List<(string, int)> indexes, List<Bonus> mergedBonuses, Bonus bonus)
	{
		int num = indexes.IndexOf((bonus.ItemId, bonus.Type));
		if (num == -1)
		{
			indexes.Add((bonus.ItemId, bonus.Type));
			mergedBonuses.Add(bonus);
		}
		else
		{
			mergedBonuses[num] = mergedBonuses[num].Merge(bonus);
		}
	}
}
