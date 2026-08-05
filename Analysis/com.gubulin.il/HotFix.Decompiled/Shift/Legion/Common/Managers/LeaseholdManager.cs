using System;
using System.Collections;
using System.Collections.Generic;
using GameDataEditor;
using Shift.Legion.ClientApi.Protocol.UserAction;
using Shift.Legion.Common.Models;
using Shift.Legion.Helpers;

namespace Shift.Legion.Common.Managers;

public class LeaseholdManager : Manager
{
	private const string LeaseholdRecordKey = "LeaseholdRecord";

	private const string DailyBonusRecordKey = "DailyBonusRecord";

	private const string LeaseholdWorkbenchKey = "LeaseholdWorkbench";

	private const string LeaseholdStockKey = "LeaseholdStock";

	private Config<Dictionary<string, Dictionary<string, object>>> _leaseholdItemRecords;

	private Config<Dictionary<string, DateTimeOffset>> _dailyBonusRecords;

	private Config<Dictionary<string, Dictionary<string, int>>> _leaseholdWorkbenchRecords;

	private Config<Dictionary<string, Dictionary<string, int>>> _leaseholdStockRecords;

	public Config<Dictionary<string, Dictionary<string, object>>> LeaseholdItemRecords
	{
		get
		{
			if (_leaseholdItemRecords == null)
			{
				UserArchiveManager userArchiveManager = Managers.UserArchiveManager;
				if (!userArchiveManager.Contains("LeaseholdRecord"))
				{
					userArchiveManager.SetConfigValue("LeaseholdRecord", new Dictionary<string, Dictionary<string, object>>());
				}
				_leaseholdItemRecords = userArchiveManager.GetConfig<Dictionary<string, Dictionary<string, object>>>("LeaseholdRecord");
			}
			return _leaseholdItemRecords;
		}
	}

	public Config<Dictionary<string, DateTimeOffset>> DailyBonusRecords
	{
		get
		{
			if (_dailyBonusRecords == null)
			{
				UserArchiveManager userArchiveManager = Managers.UserArchiveManager;
				if (!userArchiveManager.Contains("DailyBonusRecord"))
				{
					userArchiveManager.SetConfigValue("DailyBonusRecord", new Dictionary<string, DateTimeOffset>());
				}
				_dailyBonusRecords = userArchiveManager.GetConfig<Dictionary<string, DateTimeOffset>>("DailyBonusRecord");
			}
			return _dailyBonusRecords;
		}
	}

	public Config<Dictionary<string, Dictionary<string, int>>> LeaseholdWorkbenchRecords
	{
		get
		{
			if (_leaseholdWorkbenchRecords == null)
			{
				UserArchiveManager userArchiveManager = Managers.UserArchiveManager;
				if (!userArchiveManager.Contains("LeaseholdWorkbench"))
				{
					userArchiveManager.SetConfigValue("LeaseholdWorkbench", new Dictionary<string, Dictionary<string, int>>());
				}
				_leaseholdWorkbenchRecords = userArchiveManager.GetConfig<Dictionary<string, Dictionary<string, int>>>("LeaseholdWorkbench");
			}
			return _leaseholdWorkbenchRecords;
		}
	}

	public Config<Dictionary<string, Dictionary<string, int>>> LeaseholdStockRecords
	{
		get
		{
			if (_leaseholdStockRecords == null)
			{
				UserArchiveManager userArchiveManager = Managers.UserArchiveManager;
				if (!userArchiveManager.Contains("LeaseholdStock"))
				{
					userArchiveManager.SetConfigValue("LeaseholdStock", new Dictionary<string, Dictionary<string, int>>());
				}
				_leaseholdStockRecords = userArchiveManager.GetConfig<Dictionary<string, Dictionary<string, int>>>("LeaseholdStock");
			}
			return _leaseholdStockRecords;
		}
	}

	public LeaseholdManager(GameManagers managers)
		: base(managers)
	{
	}

	public bool CanClaimDailyBonus(string itemId)
	{
		GDEItemData gDEItemData = GDMgr.Get<GDEItemData>(itemId);
		if (gDEItemData == null || gDEItemData.ItemType != 12)
		{
			return false;
		}
		List<Modifier> list = Item.Effect(Managers, itemId);
		if (list.Count < 1)
		{
			return false;
		}
		if (GetLeaseholdItemRemainingTime(itemId) < 0)
		{
			return false;
		}
		Dictionary<string, DateTimeOffset> value = DailyBonusRecords.GetValue();
		if (!value.TryGetValue(itemId, out var value2))
		{
			return false;
		}
		DateTimeOffset dailyRefreshTime = DateTimeHelper.GetDailyRefreshTime(DateTimeHelper.Now, DateTimeHelper.TimezoneOffset, DateTimeHelper.RefreshHours);
		return dailyRefreshTime > value2;
	}

	public bool ClaimDailyBonus(string itemId)
	{
		if (!CanClaimDailyBonus(itemId))
		{
			return false;
		}
		EnsureDailyBonusClaimDate(itemId, DateTimeHelper.GetDailyRefreshTime(DateTimeHelper.Now, DateTimeHelper.TimezoneOffset, DateTimeHelper.RefreshHours));
		List<Modifier> list = Item.Effect(Managers, itemId);
		foreach (Modifier item in list)
		{
			if (!(item.ModifierId == "Daily"))
			{
				continue;
			}
			foreach (string key in item.PayloadDictionary.Keys)
			{
				if (!(key == "Bonus"))
				{
					continue;
				}
				object obj = item.PayloadDictionary[key];
				foreach (object key2 in ((IDictionary)obj).Keys)
				{
					object payload = ((IDictionary)obj)[key2];
					Bonus.Get(key2.ToString(), payload).Claim(Managers);
				}
				break;
			}
			break;
		}
		return true;
	}

	public int GetLeaseholdItemRemainingTime(string itemId)
	{
		Dictionary<string, Dictionary<string, object>> value = LeaseholdItemRecords.GetValue();
		if (!value.TryGetValue(itemId, out var value2))
		{
			return -1;
		}
		if (!value2.TryGetValue("ExpireAt", out var value3) || !DateTimeHelper.TryParse(value3.ToString(), out var dateTime))
		{
			return int.MaxValue;
		}
		return (int)(dateTime.ToUniversalTime() - DateTimeHelper.ServerNow).TotalSeconds;
	}

	public void RegisterLeaseholdItem(string itemId)
	{
		Dictionary<string, Dictionary<string, object>> value = LeaseholdItemRecords.GetValue();
		Dictionary<string, object> dictionary = new Dictionary<string, object>();
		string text = itemId;
		List<Modifier> list = new List<Modifier>();
		GDEItemData gDEItemData = GDMgr.Get<GDEItemData>(itemId);
		if (gDEItemData != null && !string.IsNullOrEmpty(gDEItemData.Effect))
		{
			foreach (KeyValuePair<string, object> item2 in JsonHelper.ToObject<Dictionary<string, object>>(gDEItemData.Effect))
			{
				if (item2.Key == "Sign")
				{
					text = item2.Value.ToString();
					continue;
				}
				Modifier item = new Modifier(Managers, item2.Key, item2.Value);
				list.Add(item);
			}
		}
		DateTimeOffset serverNow = DateTimeHelper.ServerNow;
		DateTimeOffset dateTime = serverNow;
		if (value.ContainsKey(text))
		{
			if (value[text].TryGetValue("ExpireAt", out var value2) && DateTimeHelper.TryParse(value2.ToString(), out dateTime) && dateTime.CompareTo(serverNow) == -1)
			{
				dateTime = serverNow;
			}
			UnregisterLeaseholdItems(text);
		}
		DateTimeOffset dateTimeOffset = default(DateTimeOffset);
		foreach (Modifier item3 in list)
		{
			if (item3.ModifierId == "Period")
			{
				dateTimeOffset = dateTime.AddSeconds(Convert.ToInt32(item3.PayloadDictionary["Payload"]));
				continue;
			}
			if (item3.ModifierId == "ExpireAt")
			{
				dateTimeOffset = DateTimeHelper.Parse(item3.PayloadDictionary["Payload"].ToString(), DateTimeHelper.ServerNow);
				continue;
			}
			if (item3.ModifierId == "Daily")
			{
				EnsureDailyBonusClaimDate(text);
				continue;
			}
			if (item3.ModifierId == "Leasehold")
			{
				RegisterLeaseholdBonus(text, item3.PayloadDictionary);
				continue;
			}
			Managers.ModifierManager.ReadFromModifier(item3);
			dictionary.Add(item3.ModifierId, item3.PayloadDictionary);
		}
		if (dateTimeOffset != default(DateTimeOffset))
		{
			dictionary.Add("ExpireAt", dateTimeOffset);
		}
		value.Add(text, dictionary);
		LeaseholdItemRecords.Save();
		Managers.Messenger.Broadcast("LEASEHOLD_REGISTERD", itemId, dateTimeOffset);
	}

	public void UnregisterLeaseholdItems(string itemId)
	{
		Dictionary<string, Dictionary<string, object>> value = LeaseholdItemRecords.GetValue();
		if (value.TryGetValue(itemId, out var value2))
		{
			value.Remove(itemId);
			LeaseholdItemRecords.Save();
			foreach (KeyValuePair<string, object> item in value2)
			{
				if (item.Key == "ExpireAt" || item.Key == "Period" || item.Key == "Daily" || item.Key == "Leasehold" || item.Key == "Bonus" || item.Key == "")
				{
					continue;
				}
				Modifier modifier;
				if (item.Value is Dictionary<string, object>)
				{
					Dictionary<string, string> dictionary2 = new Dictionary<string, string>();
					foreach (string key in ((Dictionary<string, object>)item.Value).Keys)
					{
						string value3 = ((Dictionary<string, object>)item.Value)[key].ToString();
						dictionary2.Add(key, value3);
					}
					modifier = new Modifier(Managers, item.Key, JsonHelper.ToJson(dictionary2));
				}
				else
				{
					modifier = new Modifier(Managers, item.Key, item.Value.ToString());
				}
				Managers.ModifierManager.ReadFromModifier(modifier, -1);
			}
		}
		CancelDailyBonus(itemId);
		UnregisterLeaseholdBonus(itemId);
		Managers.Messenger.Broadcast("LEASEHOLD_UNREGISTERD", itemId);
	}

	public void EnsureDailyBonusClaimDate(string itemId, DateTimeOffset lastClaimDate = default(DateTimeOffset))
	{
		Dictionary<string, DateTimeOffset> value = DailyBonusRecords.GetValue();
		if (value.ContainsKey(itemId))
		{
			value[itemId] = lastClaimDate;
		}
		else
		{
			value.Add(itemId, lastClaimDate);
		}
		DailyBonusRecords.SetValue(value);
	}

	public void CancelDailyBonus(string itemId)
	{
		Dictionary<string, DateTimeOffset> value = DailyBonusRecords.GetValue();
		value.Remove(itemId);
		DailyBonusRecords.Save();
	}

	private void RegisterLeaseholdBonus(string signature, Dictionary<string, object> payload)
	{
		foreach (KeyValuePair<string, object> item in payload)
		{
			string key = item.Key;
			string text = key;
			if (text == "Workbench")
			{
				RegisterLeaseholdWorkbenches(signature, payload);
				continue;
			}
			RegisterLeaseholdStock(signature, payload);
			Managers.StockController.ReadStockChangeRecords(new StockChangeRecord[1]
			{
				new StockChangeRecord
				{
					ItemId = item.Key,
					Offset = Convert.ToInt32(item.Value),
					Context = 20,
					ContextValue = signature,
					Type = 1
				}
			});
		}
	}

	private void UnregisterLeaseholdBonus(string signature)
	{
		Dictionary<string, Dictionary<string, int>> value = LeaseholdStockRecords.GetValue();
		Dictionary<string, Dictionary<string, int>> value2 = LeaseholdWorkbenchRecords.GetValue();
		if (value.TryGetValue(signature, out var value3))
		{
			value.Remove(signature);
			LeaseholdStockRecords.Save();
			StockController stockController = Managers.StockController;
			StockChangeRecord[] array = new StockChangeRecord[value3.Count];
			int num = 0;
			foreach (KeyValuePair<string, int> item in value3)
			{
				string key = item.Key;
				int value4 = item.Value;
				array[num++] = new StockChangeRecord
				{
					ItemId = key,
					Offset = -value4,
					Context = 20,
					ContextValue = signature,
					Type = 1
				};
			}
			Managers.StockController.ReadStockChangeRecords(array);
		}
		if (value2.TryGetValue(signature, out var _))
		{
			value2.Remove(signature);
			LeaseholdWorkbenchRecords.Save();
		}
	}

	private void RegisterLeaseholdWorkbenches(string signature, Dictionary<string, object> payload)
	{
		Dictionary<string, Dictionary<string, int>> value = LeaseholdWorkbenchRecords.GetValue();
		if (!value.ContainsKey(signature))
		{
			value.Add(signature, new Dictionary<string, int>());
		}
		List<string> list = new List<string>();
		if (payload.TryGetValue("Building", out var value2))
		{
			list.AddRange(value2.ToString().Split(','));
		}
		if (list.Count < 1)
		{
			list.AddRange(Managers.BuildingManager.Buildings.Keys);
		}
		int value3 = 1;
		if (payload.TryGetValue("Total", out var value4))
		{
			value3 = Convert.ToInt32(value4);
		}
		foreach (string item in list)
		{
			if (value[signature].ContainsKey(item))
			{
				value[signature][item] = value3;
			}
			else
			{
				value[signature].Add(item, value3);
			}
		}
		LeaseholdWorkbenchRecords.Save();
	}

	private void RegisterLeaseholdStock(string signature, Dictionary<string, object> payload)
	{
		Dictionary<string, Dictionary<string, int>> value = LeaseholdStockRecords.GetValue();
		if (!value.TryGetValue(signature, out var value2))
		{
			value2 = new Dictionary<string, int>();
			value.Add(signature, value2);
		}
		foreach (KeyValuePair<string, object> item in payload)
		{
			string key = item.Key;
			int num = Convert.ToInt32(item.Value);
			if (!value2.TryGetValue(key, out var value3))
			{
				value2.Add(key, num);
			}
			else if (value3 != num)
			{
				value2[key] = num;
			}
		}
		LeaseholdStockRecords.Save();
	}

	public int GetLeaseholdWorkbenchByBuilding(string buildingType)
	{
		int num = 0;
		foreach (Dictionary<string, int> value2 in LeaseholdWorkbenchRecords.GetValue().Values)
		{
			if (value2.TryGetValue(buildingType, out var value))
			{
				num += value;
			}
		}
		return num;
	}

	public int GetLeaseholdManPower()
	{
		Dictionary<string, Dictionary<string, int>> value = LeaseholdStockRecords.GetValue();
		if (value == null)
		{
			return 0;
		}
		int num = 0;
		foreach (Dictionary<string, int> value3 in value.Values)
		{
			if (value3.TryGetValue("ManPower", out var value2))
			{
				num += value2;
			}
		}
		return num;
	}
}
