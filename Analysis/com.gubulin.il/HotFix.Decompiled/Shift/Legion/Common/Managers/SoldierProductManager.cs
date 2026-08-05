using System.Collections.Generic;
using GameDataEditor;
using Shift.Legion.Common.Helpers;
using Shift.Legion.Common.Models;
using Shift.Legion.Helpers;

namespace Shift.Legion.Common.Managers;

public class SoldierProductManager : Singleton<SoldierProductManager>
{
	public struct WeaponBonusAndDemand
	{
		public Dictionary<string, float> FixBonus;

		public Dictionary<string, float> PercentBonus;

		public Dictionary<string, float> Require;
	}

	private Dictionary<string, Dictionary<int, WeaponBonusAndDemand>> _soldierProductEvoDict = new Dictionary<string, Dictionary<int, WeaponBonusAndDemand>>();

	private Dictionary<string, GDESoldierProductData> _soldierProductsDict = new Dictionary<string, GDESoldierProductData>();

	public override void InitInstance()
	{
		LoadData();
	}

	private void LoadData()
	{
		IEnumerable<GDESoldierProductData> allItems = GDMgr.GetAllItems<GDESoldierProductData>();
		foreach (GDESoldierProductData item in allItems)
		{
			_soldierProductsDict.Add(item.SoldierId, item);
		}
	}

	public GDESoldierProductData GetSoldierProductData(string soldierId)
	{
		return _soldierProductsDict.ContainsKey(soldierId) ? _soldierProductsDict[soldierId] : null;
	}

	public Dictionary<string, float> GetSoldierProductRequirements(string soldierId)
	{
		Dictionary<string, float> dictionary = new Dictionary<string, float>();
		GDESoldierProductData soldierProductData = GetSoldierProductData(soldierId);
		if (soldierProductData != null)
		{
			if (soldierProductData.Number1 > 0)
			{
				dictionary.Add(soldierProductData.Stuff1, soldierProductData.Number1);
			}
			if (soldierProductData.Number2 > 0)
			{
				dictionary.Add(soldierProductData.Stuff2, soldierProductData.Number2);
			}
			if (soldierProductData.Number3 > 0)
			{
				dictionary.Add(soldierProductData.Stuff3, soldierProductData.Number3);
			}
			if (soldierProductData.Number4 > 0)
			{
				dictionary.Add(soldierProductData.Stuff4, soldierProductData.Number4);
			}
			if (soldierProductData.Number5 > 0)
			{
				dictionary.Add(soldierProductData.Stuff5, soldierProductData.Number5);
			}
		}
		return dictionary;
	}

	public List<string> GetSoldierWeaponList(string soldierId)
	{
		List<string> list = new List<string>();
		GDESoldierProductData soldierProductData = GetSoldierProductData(soldierId);
		if (soldierProductData != null)
		{
			if (soldierProductData.Number1 > 0)
			{
				list.Add(soldierProductData.Stuff1);
			}
			if (soldierProductData.Number2 > 0)
			{
				list.Add(soldierProductData.Stuff2);
			}
			if (soldierProductData.Number3 > 0)
			{
				list.Add(soldierProductData.Stuff3);
			}
			if (soldierProductData.Number4 > 0)
			{
				list.Add(soldierProductData.Stuff4);
			}
			if (soldierProductData.Number5 > 0)
			{
				list.Add(soldierProductData.Stuff5);
			}
		}
		return list;
	}

	public WeaponBonusAndDemand GetSoldierProductEvoInfo(GameManagers managers, string itemId, int itemLevel)
	{
		if (!_soldierProductEvoDict.ContainsKey(itemId))
		{
			_soldierProductEvoDict.Add(itemId, new Dictionary<int, WeaponBonusAndDemand>());
		}
		int weaponEvoLevel = managers.UserArchiveManager.GetWeaponEvoLevel(itemId, itemLevel);
		int weaponSubLevel = managers.UserArchiveManager.GetWeaponSubLevel(itemId, itemLevel);
		if (!_soldierProductEvoDict[itemId].ContainsKey(itemLevel))
		{
			WeaponBonusAndDemand config = new WeaponBonusAndDemand
			{
				FixBonus = new Dictionary<string, float>(),
				PercentBonus = new Dictionary<string, float>(),
				Require = new Dictionary<string, float>()
			};
			_soldierProductEvoDict[itemId].Add(itemLevel, config);
			GDEProductEvoData gDEProductEvoData = GDMgr.Get<GDEProductEvoData>("P" + itemId);
			if (gDEProductEvoData != null)
			{
				object obj = gDEProductEvoData.GetType().GetProperty($"Level{weaponEvoLevel}")?.GetValue(gDEProductEvoData);
				object obj2 = gDEProductEvoData.GetType().GetProperty($"Demand{weaponEvoLevel}")?.GetValue(gDEProductEvoData);
				object obj3 = gDEProductEvoData.GetType().GetProperty($"FragBonus{weaponEvoLevel}")?.GetValue(gDEProductEvoData);
				object obj4 = gDEProductEvoData.GetType().GetProperty($"FragDemand{weaponEvoLevel}")?.GetValue(gDEProductEvoData);
				if (obj != null && obj2 != null && obj3 != null && obj4 != null)
				{
					string text = obj.ToString();
					string text2 = obj2.ToString();
					string text3 = obj3.ToString();
					string text4 = obj4.ToString();
					if (!string.IsNullOrEmpty(text))
					{
						AddEffect(ref config, JsonHelper.ToObject<Dictionary<string, object>>(text));
					}
					if (weaponSubLevel > 0)
					{
						if (!string.IsNullOrEmpty(text3))
						{
							AddEffect(ref config, JsonHelper.ToObject<Dictionary<string, object>>(text3), weaponSubLevel);
						}
						if (!string.IsNullOrEmpty(text4))
						{
							AddDemand(ref config, JsonHelper.ToObject<Dictionary<string, float>>(text4));
						}
					}
					else if (!string.IsNullOrEmpty(text2))
					{
						AddDemand(ref config, JsonHelper.ToObject<Dictionary<string, float>>(text2));
					}
				}
			}
		}
		if (_soldierProductEvoDict[itemId].ContainsKey(itemLevel))
		{
			return _soldierProductEvoDict[itemId][itemLevel];
		}
		return default(WeaponBonusAndDemand);
	}

	private void AddEffect(ref WeaponBonusAndDemand config, Dictionary<string, object> data, int multiplier = 1)
	{
		foreach (KeyValuePair<string, object> datum in data)
		{
			string text = datum.Value.ToString();
			if (Modifier.EntityAttrModifierList.Contains(datum.Key))
			{
				float num;
				object obj;
				if (text.IndexOf('%') == -1)
				{
					num = NumericParser.Float(text) * (float)multiplier;
					obj = config.FixBonus;
				}
				else
				{
					num = NumericParser.FloatPercent(text) * (float)multiplier;
					obj = config.PercentBonus;
				}
				if (((Dictionary<string, float>)obj).ContainsKey(datum.Key))
				{
					((Dictionary<string, float>)obj)[datum.Key] += num;
				}
				else
				{
					((Dictionary<string, float>)obj).Add(datum.Key, num);
				}
			}
		}
	}

	private void AddDemand(ref WeaponBonusAndDemand config, Dictionary<string, float> data)
	{
		foreach (KeyValuePair<string, float> datum in data)
		{
			config.Require.Add(datum.Key, datum.Value);
		}
	}

	public Dictionary<string, string> GetWeaponAttributes(GameManagers managers, string weaponId, int level)
	{
		Dictionary<string, string> dictionary = new Dictionary<string, string>();
		WeaponBonusAndDemand soldierProductEvoInfo = GetSoldierProductEvoInfo(managers, weaponId, level);
		foreach (KeyValuePair<string, float> fixBonu in soldierProductEvoInfo.FixBonus)
		{
			KeyValuePair<string, string> keyValuePair = Modifier.TranslateModifierKeyValue(fixBonu.Key, fixBonu.Value);
			dictionary.Add(keyValuePair.Key, keyValuePair.Value);
		}
		foreach (KeyValuePair<string, float> percentBonu in soldierProductEvoInfo.PercentBonus)
		{
			string data = $"{percentBonu.Value * 100f:F1}%";
			KeyValuePair<string, string> keyValuePair2 = Modifier.TranslateModifierKeyValue(percentBonu.Key, data);
			if (dictionary.ContainsKey(keyValuePair2.Key))
			{
				Dictionary<string, string> dictionary2 = dictionary;
				string key = keyValuePair2.Key;
				dictionary2[key] = dictionary2[key] + "，" + keyValuePair2.Value;
			}
			else
			{
				dictionary.Add(keyValuePair2.Key, keyValuePair2.Value);
			}
		}
		return dictionary;
	}
}
