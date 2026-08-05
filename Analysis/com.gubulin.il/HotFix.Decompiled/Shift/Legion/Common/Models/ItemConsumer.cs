using System;
using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Managers;
using GameDataEditor;
using Shift.Legion.ClientApi.Protocol.UserAction;
using Shift.Legion.Common.Enums;
using Shift.Legion.Common.Helpers;
using Shift.Legion.Common.Managers;
using Shift.Legion.Common.Sources.Enums;
using Shift.Legion.Helpers;

namespace Shift.Legion.Common.Models;

public class ItemConsumer
{
	public static void UseItem(GameManagers managers, string itemId, object context = null, int repeat = 1)
	{
		int stock = managers.StockController.GetStock(itemId);
		if (stock < repeat)
		{
			repeat = stock;
		}
		if (stock < 1)
		{
			SharedMessenger.Broadcast("SHOW_TIPS", new List<string> { SchemaIndexHelper.GetNameById(managers, itemId) + " " + LanguagesManager.GetDesc("CsharpCodeZhTcText768") }, 121, arg3: false);
			return;
		}
		switch ((ItemType)Item.ItemType(itemId))
		{
		case ItemType.Leasehold:
			LeaseholdItemConsume(managers, itemId, context, repeat);
			break;
		case ItemType.Chest:
		case ItemType.GvGStoreChest:
			ChestItemConsume(managers, itemId, context, repeat);
			break;
		case ItemType.LegendItemChest:
			LegendItemItemConsume(managers, itemId, context, repeat);
			break;
		case ItemType.LotteryChest:
			LotteryChestItemConsume(managers, itemId, context, repeat);
			break;
		case ItemType.TechResetTicket:
			TechResetTicketConsume(managers, itemId, context);
			break;
		case ItemType.SelectChest:
		case ItemType.GvGStoreSelectChest:
			SelectChestConsume(managers, itemId, context, repeat);
			break;
		case ItemType.SoulKey:
			UseSoulKey(managers, itemId, context, repeat);
			break;
		default:
			DefaultItemConsume(managers, itemId, context, repeat);
			break;
		}
	}

	private static void ChestItemConsume(GameManagers managers, string itemId, object context = null, int repeat = 1)
	{
		List<Modifier> list = Item.Effect(managers, itemId);
		if (list.Count <= 0)
		{
			return;
		}
		Dictionary<string, Modifier> dictionary = list.ToDictionary((Modifier modifier) => modifier.ModifierId, (Modifier modifier) => modifier);
		if (dictionary.TryGetValue("Cost", out var value))
		{
			Dictionary<string, int> dictionary2 = new Dictionary<string, int>();
			foreach (KeyValuePair<string, object> item in value.PayloadDictionary)
			{
				string key = item.Key;
				int num = Convert.ToInt32(item.Value) * repeat;
				if (managers.StockController.GetStock(key) < Convert.ToInt32(num))
				{
					SharedMessenger.Broadcast("SHOW_TIPS", new List<string> { string.Format("{0}{1}x{2}", LanguagesManager.GetDesc("CsharpCodeZhTcText769"), GDMgr.Get<GDEItemData>(key)?.Name, num) }, 121, arg3: false);
					return;
				}
				dictionary2.Add(key, num);
			}
			StockChangeRecord[] array = new StockChangeRecord[dictionary2.Count];
			int num2 = 0;
			foreach (KeyValuePair<string, int> item2 in dictionary2)
			{
				array[num2++] = new StockChangeRecord
				{
					ItemId = item2.Key,
					Offset = -item2.Value,
					Context = 16,
					ContextValue = itemId,
					Type = 1
				};
			}
			managers.StockController.ReadStockChangeRecords(array);
		}
		List<Bonus> list2 = new List<Bonus>();
		Dictionary<string, float> dictionary3 = new Dictionary<string, float>();
		if (dictionary.TryGetValue("Bonus", out var value2))
		{
			if (value2.PayloadDictionary.ContainsKey("Context"))
			{
				context = value2.PayloadDictionary["Context"];
				value2.PayloadDictionary.Remove("Context");
			}
			foreach (KeyValuePair<string, object> item3 in value2.PayloadDictionary)
			{
				string key2 = item3.Key;
				object obj = item3.Value;
				object obj2 = obj;
				object obj3 = obj2;
				if (!(obj3 is List<string> list3))
				{
					if (!(obj3 is List<int> list4))
					{
						int result;
						if (obj3 is Dictionary<string, float> dictionary4)
						{
							Dictionary<string, object> dictionary5 = new Dictionary<string, object>();
							foreach (KeyValuePair<string, float> item4 in dictionary4)
							{
								dictionary5.Add(item4.Key, item4.Value * (float)repeat);
							}
							obj = dictionary5;
						}
						else if (int.TryParse(obj.ToString(), out result))
						{
							obj = result * repeat;
						}
					}
					else
					{
						List<int> list5 = new List<int>();
						foreach (int item5 in list4)
						{
							list5.Add(item5 * repeat);
						}
						obj = list5;
					}
				}
				else
				{
					obj = list3;
				}
				Bonus bonus = Bonus.Get(key2, obj);
				bonus.Claim(managers, dictionary3, context, forceClaim: true, broadcastInform: false);
				list2.Add(bonus);
			}
		}
		managers.StockController.ReadStockChangeRecords(new StockChangeRecord[1]
		{
			new StockChangeRecord
			{
				ItemId = itemId,
				Offset = -repeat,
				Context = 17,
				ContextValue = itemId,
				Type = 1
			}
		});
		managers.Messenger.Broadcast("CHEST_CLAIMED", itemId, list2, dictionary3);
	}

	private static void LegendItemItemConsume(GameManagers managers, string itemId, object context = null, int repeat = 1)
	{
		List<Modifier> list = Item.Effect(managers, itemId);
		if (list.Count <= 0)
		{
			return;
		}
		Dictionary<string, Modifier> dictionary = list.ToDictionary((Modifier modifier) => modifier.ModifierId, (Modifier modifier) => modifier);
		if (dictionary.TryGetValue("Cost", out var value))
		{
			Dictionary<string, int> dictionary2 = new Dictionary<string, int>();
			foreach (KeyValuePair<string, object> item in value.PayloadDictionary)
			{
				string key = item.Key;
				int num = Convert.ToInt32(item.Value) * repeat;
				if (managers.StockController.GetStock(key) < Convert.ToInt32(num))
				{
					SharedMessenger.Broadcast("SHOW_TIPS", new List<string> { string.Format("{0}{1}x{2}", LanguagesManager.GetDesc("CsharpCodeZhTcText769"), GDMgr.Get<GDEItemData>(key)?.Name, num) }, 121, arg3: false);
					return;
				}
				dictionary2.Add(key, num);
			}
			StockChangeRecord[] array = new StockChangeRecord[dictionary2.Count];
			int num2 = 0;
			foreach (KeyValuePair<string, int> item2 in dictionary2)
			{
				array[num2++] = new StockChangeRecord
				{
					ItemId = item2.Key,
					Offset = -item2.Value,
					Context = 16,
					ContextValue = itemId,
					Type = 1
				};
			}
			managers.StockController.ReadStockChangeRecords(array);
		}
		List<Bonus> list2 = new List<Bonus>();
		Dictionary<string, float> claimed = new Dictionary<string, float>();
		if (dictionary.TryGetValue("Bonus", out var value2))
		{
			if (value2.PayloadDictionary.ContainsKey("Context"))
			{
				context = value2.PayloadDictionary["Context"];
				value2.PayloadDictionary.Remove("Context");
			}
			foreach (KeyValuePair<string, object> item3 in value2.PayloadDictionary)
			{
				string key2 = item3.Key;
				object obj = item3.Value;
				object obj2 = obj;
				object obj3 = obj2;
				if (!(obj3 is List<string> list3))
				{
					if (!(obj3 is List<int> list4))
					{
						int result;
						if (obj3 is Dictionary<string, float> dictionary3)
						{
							Dictionary<string, object> dictionary4 = new Dictionary<string, object>();
							foreach (KeyValuePair<string, float> item4 in dictionary3)
							{
								dictionary4.Add(item4.Key, item4.Value * (float)repeat);
							}
							obj = dictionary4;
						}
						else if (int.TryParse(obj.ToString(), out result))
						{
							obj = result * repeat;
						}
					}
					else
					{
						List<int> list5 = new List<int>();
						foreach (int item5 in list4)
						{
							list5.Add(item5 * repeat);
						}
						obj = list5;
					}
				}
				else
				{
					obj = list3;
				}
				Bonus bonus = Bonus.Get(key2, obj);
				bonus.Claim(managers, claimed, context, forceClaim: true, broadcastInform: false);
				list2.Add(bonus);
			}
		}
		managers.StockController.ReadStockChangeRecords(new StockChangeRecord[1]
		{
			new StockChangeRecord
			{
				ItemId = itemId,
				Offset = -repeat,
				Context = 17,
				ContextValue = itemId,
				Type = 1
			}
		});
	}

	private static void LotteryChestItemConsume(GameManagers managers, string itemId, object context = null, int repeat = 1)
	{
		List<Modifier> list = Item.Effect(managers, itemId);
		if (list.Count <= 0)
		{
			return;
		}
		Dictionary<string, Modifier> dictionary = list.ToDictionary((Modifier modifier) => modifier.ModifierId, (Modifier modifier) => modifier);
		if (dictionary.TryGetValue("Cost", out var value))
		{
			Dictionary<string, int> dictionary2 = new Dictionary<string, int>();
			foreach (KeyValuePair<string, object> item in value.PayloadDictionary)
			{
				string key = item.Key;
				int num = Convert.ToInt32(item.Value) * repeat;
				if (managers.StockController.GetStock(key) < Convert.ToInt32(num))
				{
					SharedMessenger.Broadcast("SHOW_TIPS", new List<string> { string.Format("{0}{1}x{2}", LanguagesManager.GetDesc("CsharpCodeZhTcText769"), GDMgr.Get<GDEItemData>(key)?.Name, num) }, 121, arg3: false);
					return;
				}
				dictionary2.Add(key, num);
			}
			StockChangeRecord[] array = new StockChangeRecord[dictionary2.Count];
			int num2 = 0;
			foreach (KeyValuePair<string, int> item2 in dictionary2)
			{
				array[num2++] = new StockChangeRecord
				{
					ItemId = item2.Key,
					Offset = -item2.Value,
					Context = 16,
					ContextValue = itemId,
					Type = 1
				};
			}
			managers.StockController.ReadStockChangeRecords(array);
		}
		if (dictionary.TryGetValue("Lottery", out var value2) && value2.PayloadDictionary.TryGetValue("LotteryId", out var value3))
		{
			List<KeyValuePair<Bonus, int>> lotteryAsListById = managers.LotteryManager.GetLotteryAsListById(value3.ToString());
			List<BonusConfig> list2 = new List<BonusConfig>();
			foreach (KeyValuePair<Bonus, int> item3 in lotteryAsListById)
			{
				Bonus key2 = item3.Key;
				list2.Add(new BonusConfig
				{
					ItemId = key2.ItemId,
					Qty = key2.Qty,
					Type = key2.Type,
					IsShining = item3.Value
				});
			}
			List<LotteryPendingResult> value4 = managers.LotteryManager.PendingLotteryResult.GetValue();
			value4.Add(new LotteryPendingResult
			{
				From = itemId,
				CreatedAt = DateTimeHelper.Now,
				TotalPick = ((!value2.PayloadDictionary.TryGetValue("TotalPick", out var value5)) ? 1 : Convert.ToInt32(value5)),
				BonusList = list2
			});
			managers.LotteryManager.PendingLotteryResult.SetValue(value4);
		}
		managers.StockController.ReadStockChangeRecords(new StockChangeRecord[1]
		{
			new StockChangeRecord
			{
				ItemId = itemId,
				Offset = -repeat,
				Context = 17,
				ContextValue = itemId,
				Type = 1
			}
		});
	}

	private static void TechResetTicketConsume(GameManagers managers, string itemId, object context = null)
	{
		managers.StockController.ReadStockChangeRecords(new StockChangeRecord[1]
		{
			new StockChangeRecord
			{
				ItemId = itemId,
				Offset = -1,
				Context = 17,
				ContextValue = itemId,
				Type = 1
			}
		});
		managers.TechnologyManager.ResetAllTechnologies();
	}

	private static void SelectChestConsume(GameManagers managers, string itemId, object context = null, int repeat = 1)
	{
		if (context == null)
		{
			return;
		}
		int num = 1;
		Dictionary<string, int> dictionary = new Dictionary<string, int>();
		Dictionary<string, int> dictionary2 = new Dictionary<string, int>();
		List<Modifier> list = Item.Effect(managers, itemId);
		foreach (Modifier item in list)
		{
			if (item.ModifierId == "Items")
			{
				foreach (KeyValuePair<string, object> item2 in item.PayloadDictionary)
				{
					dictionary.Add(item2.Key, Convert.ToInt32(item2.Value));
				}
			}
			else if (item.ModifierId == "TotalPick")
			{
				num = Convert.ToInt32(item.PayloadDictionary["Payload"]);
			}
			else
			{
				if (!(item.ModifierId == "Cost"))
				{
					continue;
				}
				foreach (KeyValuePair<string, object> item3 in item.PayloadDictionary)
				{
					dictionary2.Add(item3.Key, Convert.ToInt32(item3.Value));
				}
			}
		}
		if (num < 1 || dictionary.Count < 1)
		{
			GDEItemData gDEItemData = GDMgr.Get<GDEItemData>(itemId);
			return;
		}
		List<int> list2 = null;
		list2 = ((!(context is string text)) ? (context as List<int>) : (from i in text.Split(',')
			select Convert.ToInt32(i)).ToList());
		if (list2 == null || list2.Count < 1)
		{
			return;
		}
		foreach (KeyValuePair<string, int> item4 in dictionary2)
		{
			if (item4.Value > managers.StockController.GetStock(item4.Key))
			{
				return;
			}
		}
		StockChangeRecord[] array = new StockChangeRecord[dictionary2.Count + 1];
		int num2 = 0;
		foreach (KeyValuePair<string, int> item5 in dictionary2)
		{
			array[num2++] = new StockChangeRecord
			{
				ItemId = item5.Key,
				Offset = -item5.Value,
				Context = 17,
				ContextValue = itemId,
				Type = 1
			};
		}
		array[dictionary2.Count] = new StockChangeRecord
		{
			ItemId = itemId,
			Offset = -repeat,
			Context = 17,
			ContextValue = itemId,
			Type = 1
		};
		managers.StockController.ReadStockChangeRecords(array);
		List<string> list3 = dictionary.Keys.ToList();
		foreach (int item6 in list2)
		{
			if (item6 < list3.Count)
			{
				string text2 = list3[item6];
				int num3 = dictionary[text2] * repeat;
				Bonus.Get(text2, num3).Claim(managers);
			}
		}
	}

	private static void DefaultItemConsume(GameManagers managers, string itemId, object context = null, int repeat = 1)
	{
		List<Modifier> list = Item.Effect(managers, itemId);
		if (list.Count <= 0)
		{
			return;
		}
		managers.StockController.ReadStockChangeRecords(new StockChangeRecord[1]
		{
			new StockChangeRecord
			{
				ItemId = itemId,
				Offset = -repeat,
				Context = 17,
				ContextValue = itemId,
				Type = 1
			}
		});
		foreach (Modifier item in list)
		{
			if (repeat > 1)
			{
				string modifierId = item.ModifierId;
				string text = modifierId;
				if (!(text == "Bonus"))
				{
					if (text == "TimeMachine" && item.PayloadDictionary.TryGetValue("Time", out var value) && int.TryParse(value.ToString(), out var result))
					{
						item.PayloadDictionary["Time"] = result * repeat;
					}
				}
				else
				{
					string[] array = item.PayloadDictionary.Keys.ToArray();
					foreach (string key in array)
					{
						object obj = item.PayloadDictionary[key];
						if (int.TryParse(obj.ToString(), out var result2))
						{
							item.PayloadDictionary[key] = result2 * repeat;
						}
					}
				}
			}
			item.PayloadDictionary.Add("Context", context);
			managers.ModifierManager.ReadFromModifier(item);
		}
	}

	private static void LeaseholdItemConsume(GameManagers managers, string itemId, object context = null, int repeat = 1)
	{
		List<Modifier> list = Item.Effect(managers, itemId);
		if (list.Count <= 0)
		{
			return;
		}
		foreach (Modifier item in list)
		{
			if (item.ModifierId == "Period")
			{
				int num = Convert.ToInt32(item.PayloadDictionary["Payload"]);
				item.PayloadDictionary["Payload"] = num * repeat;
				break;
			}
		}
		managers.LeaseholdManager.RegisterLeaseholdItem(itemId);
	}

	private static void UseSoulKey(GameManagers managers, string itemId, object context = null, int repeat = 1)
	{
		GDEItemData gDEItemData = GDMgr.Get<GDEItemData>(itemId);
		SoulKeyItemEffect soulKeyItemEffect = JsonHelper.ToObject<SoulKeyItemEffect>(gDEItemData.Effect);
		int soldierPotentialLevel = managers.UserArchiveManager.GetSoldierPotentialLevel(soulKeyItemEffect.SoldierId);
		if (soldierPotentialLevel < soulKeyItemEffect.PotentialLevel)
		{
			return;
		}
		managers.StockController.IncrStock(itemId, -repeat, StockInContext.GiveBackSoulKey, itemId);
		foreach (KeyValuePair<string, int> item in soulKeyItemEffect.GiveBack)
		{
			managers.StockController.IncrStock(item.Key, item.Value * repeat, StockInContext.GiveBackSoulKey, itemId);
		}
	}
}
