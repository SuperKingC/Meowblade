using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using GameMaths;
using Shift.Legion.Common.Helpers;
using Shift.Legion.Common.Models;

namespace Shift.Legion.Common.Managers;

public class ModifierManager : Manager
{
	private delegate float Calc(float a, float b);

	private Dictionary<string, Dictionary<string, object>> _globalFixedModifierDictionary = new Dictionary<string, Dictionary<string, object>>();

	private Dictionary<string, Dictionary<string, object>> _globalPercentModifierDictionary = new Dictionary<string, Dictionary<string, object>>();

	private Dictionary<string, Dictionary<string, object>> _mainCityFixedModifierDictionary = new Dictionary<string, Dictionary<string, object>>();

	private Dictionary<string, Dictionary<string, object>> _mainCityPercentModifierDictionary = new Dictionary<string, Dictionary<string, object>>();

	private Dictionary<string, Dictionary<string, object>> _mainBattleFixedModifierDictionary = new Dictionary<string, Dictionary<string, object>>();

	private Dictionary<string, Dictionary<string, object>> _mainBattlePercentModifierDictionary = new Dictionary<string, Dictionary<string, object>>();

	private List<string> _entityAttrModifierList;

	private Dictionary<string, float> _globalFixedEntityAttrBonus;

	private Dictionary<string, float> _globalPercentEntityAttrBonus;

	private Dictionary<string, float> _mainBattleFixedEntityAttrBonus;

	private Dictionary<string, float> _mainBattlePercentEntityAttrBonus;

	private Dictionary<string, Dictionary<string, string>> _leaseholdModifierDictionary;

	public Dictionary<string, Dictionary<string, object>> GlobalFixedModifierDictionary
	{
		get
		{
			return _globalFixedModifierDictionary;
		}
		set
		{
			_globalFixedModifierDictionary = value;
			Flush();
		}
	}

	public Dictionary<string, Dictionary<string, object>> GlobalPercentModifierDictionary
	{
		get
		{
			return _globalPercentModifierDictionary;
		}
		set
		{
			_globalPercentModifierDictionary = value;
			Flush();
		}
	}

	public Dictionary<string, Dictionary<string, object>> MainCityFixedModifierDictionary
	{
		get
		{
			return _mainCityFixedModifierDictionary;
		}
		set
		{
			_mainCityFixedModifierDictionary = value;
			Flush();
		}
	}

	public Dictionary<string, Dictionary<string, object>> MainCityPercentModifierDictionary
	{
		get
		{
			return _mainCityPercentModifierDictionary;
		}
		set
		{
			_mainCityPercentModifierDictionary = value;
			Flush();
		}
	}

	public Dictionary<string, Dictionary<string, object>> MainBattleFixedModifierDictionary
	{
		get
		{
			return _mainBattleFixedModifierDictionary;
		}
		set
		{
			_mainBattleFixedModifierDictionary = value;
			Flush();
		}
	}

	public Dictionary<string, Dictionary<string, object>> MainBattlePercentModifierDictionary
	{
		get
		{
			return _mainBattlePercentModifierDictionary;
		}
		set
		{
			_mainBattlePercentModifierDictionary = value;
			Flush();
		}
	}

	public Dictionary<string, Dictionary<string, string>> LeaseholdModifierDictionary
	{
		get
		{
			return _leaseholdModifierDictionary;
		}
		set
		{
			_leaseholdModifierDictionary = value;
			Flush();
		}
	}

	public ModifierManager(GameManagers managers)
		: base(managers)
	{
	}

	public override Task Init()
	{
		foreach (KeyValuePair<string, int> item in Managers.UserArchiveManager.GetAllTechLevel())
		{
			List<Modifier> techEffects = Managers.TechnologyManager.GetTechEffects(item.Key, item.Value);
			if (techEffects == null)
			{
				continue;
			}
			foreach (Modifier item2 in techEffects)
			{
				if (!(item2.ModifierId == "Bonus") && !(item2.ModifierId == "OfflineYieldTimeLimit") && !(item2.ModifierId == "TimeMachine"))
				{
					ReadFromModifier(item2);
				}
			}
		}
		foreach (KeyValuePair<string, Dictionary<string, object>> item3 in Managers.LeaseholdManager.LeaseholdItemRecords.GetValue())
		{
			string key = item3.Key;
			List<Modifier> list = Item.Effect(Managers, key);
			foreach (Modifier item4 in list)
			{
				string modifierId = item4.ModifierId;
				switch (modifierId)
				{
				case "Bonus":
				case "OfflineYieldTimeLimit":
				case "TimeMachine":
				case "Period":
				case "Daily":
				case "Leasehold":
					continue;
				}
				if (!(modifierId == "ExpireAt"))
				{
					if (!item4.PayloadDictionary.ContainsKey("Context"))
					{
						item4.PayloadDictionary.Add("Context", key);
					}
					ReadFromModifier(item4);
				}
			}
		}
		return null;
	}

	public void Flush()
	{
		_globalFixedEntityAttrBonus = null;
		_globalPercentEntityAttrBonus = null;
		_mainBattleFixedEntityAttrBonus = null;
		_mainBattlePercentEntityAttrBonus = null;
	}

	public Dictionary<string, float> GetGlobalFixedEntityAttrBonus()
	{
		if (_globalFixedEntityAttrBonus == null)
		{
			_globalFixedEntityAttrBonus = new Dictionary<string, float>();
			foreach (string entityAttrModifier in Modifier.EntityAttrModifierList)
			{
				if (GlobalFixedModifierDictionary.ContainsKey(entityAttrModifier))
				{
					_globalFixedEntityAttrBonus.Add(entityAttrModifier, (float)GlobalFixedModifierDictionary[entityAttrModifier]["Payload"]);
				}
			}
		}
		return _globalFixedEntityAttrBonus;
	}

	public Dictionary<string, float> GetGlobalPercentEntityAttrBonus()
	{
		if (_globalPercentEntityAttrBonus == null)
		{
			_globalPercentEntityAttrBonus = new Dictionary<string, float>();
			foreach (string entityAttrModifier in Modifier.EntityAttrModifierList)
			{
				if (GlobalPercentModifierDictionary.ContainsKey(entityAttrModifier))
				{
					_globalPercentEntityAttrBonus.Add(entityAttrModifier, (float)GlobalPercentModifierDictionary[entityAttrModifier]["Payload"]);
				}
			}
		}
		return _globalPercentEntityAttrBonus;
	}

	public Dictionary<string, float> GetMainBattleFixedEntityAttrBonus()
	{
		if (_mainBattleFixedEntityAttrBonus == null)
		{
			_mainBattleFixedEntityAttrBonus = new Dictionary<string, float>();
			foreach (string entityAttrModifier in Modifier.EntityAttrModifierList)
			{
				if (MainBattleFixedModifierDictionary.ContainsKey(entityAttrModifier))
				{
					_mainBattleFixedEntityAttrBonus.Add(entityAttrModifier, (float)MainBattleFixedModifierDictionary[entityAttrModifier]["Payload"]);
				}
			}
		}
		return _mainBattleFixedEntityAttrBonus;
	}

	public Dictionary<string, float> GetMainBattlePercentEntityAttrBonus()
	{
		if (_mainBattlePercentEntityAttrBonus == null)
		{
			_mainBattlePercentEntityAttrBonus = new Dictionary<string, float>();
			foreach (string entityAttrModifier in Modifier.EntityAttrModifierList)
			{
				if (MainBattlePercentModifierDictionary.ContainsKey(entityAttrModifier))
				{
					_mainBattlePercentEntityAttrBonus.Add(entityAttrModifier, (float)MainBattlePercentModifierDictionary[entityAttrModifier]["Payload"]);
				}
			}
		}
		return _mainBattlePercentEntityAttrBonus;
	}

	private void ProcessBonusModifier(GameManagers managers, Modifier modifier, int mod)
	{
		object context = null;
		if (modifier.PayloadDictionary.ContainsKey("Context"))
		{
			context = modifier.PayloadDictionary["Context"];
			modifier.PayloadDictionary.Remove("Context");
		}
		foreach (KeyValuePair<string, object> item in modifier.PayloadDictionary)
		{
			object value = item.Value;
			object obj = value;
			if (!(obj is int num))
			{
				if (!(obj is float num2))
				{
					if (!(obj is double num3))
					{
						if (obj is long num4)
						{
							Bonus.Get(item.Key, (float)mod * (float)num4).Claim(managers, null, context);
						}
						else
						{
							Bonus.Get(item.Key, item.Value).Claim(managers, null, context);
						}
					}
					else
					{
						Bonus.Get(item.Key, (float)mod * (float)num3).Claim(managers, null, context);
					}
				}
				else
				{
					Bonus.Get(item.Key, (float)mod * num2).Claim(managers, null, context);
				}
			}
			else
			{
				Bonus.Get(item.Key, mod * num).Claim(managers, null, context);
			}
		}
	}

	private void ProcessAttributeBundleModifier(Modifier modifier, ref Dictionary<string, Dictionary<string, object>> fixedModifierDict, ref Dictionary<string, Dictionary<string, object>> percentModifierDict, int mod)
	{
		string text = "";
		if (modifier.PayloadDictionary.ContainsKey("SoldierId"))
		{
			text = modifier.PayloadDictionary["SoldierId"].ToString();
		}
		else if (modifier.PayloadDictionary.ContainsKey("AiType"))
		{
			text = modifier.PayloadDictionary["AiType"].ToString();
		}
		foreach (KeyValuePair<string, object> item in modifier.PayloadDictionary)
		{
			if (item.Key == "SoldierId" || item.Key == "AiType")
			{
				continue;
			}
			string text2 = item.Value.ToString();
			if (text2.Length <= 0)
			{
				continue;
			}
			bool flag;
			object obj;
			float num;
			if (text2.IndexOf('%') == -1)
			{
				flag = false;
				obj = fixedModifierDict;
				num = NumericParser.Float(text2);
			}
			else
			{
				flag = true;
				obj = percentModifierDict;
				num = NumericParser.FloatPercent(text2);
			}
			if (text.Length > 0)
			{
				if (!((Dictionary<string, Dictionary<string, Dictionary<string, object>>>)obj).ContainsKey(text))
				{
					((Dictionary<string, Dictionary<string, Dictionary<string, object>>>)obj).Add(text, new Dictionary<string, Dictionary<string, object>>());
				}
				obj = ((Dictionary<string, Dictionary<string, Dictionary<string, object>>>)obj)[text];
			}
			if (!((Dictionary<string, Dictionary<string, object>>)obj).ContainsKey(item.Key))
			{
				((Dictionary<string, Dictionary<string, object>>)obj).Add(item.Key, new Dictionary<string, object> { { "Payload", 0f } });
			}
			if (Modifier.NeedStackMultipleProcess(item.Key) && flag)
			{
				num += 1f;
				if (mod < 0)
				{
					num = 1f / num;
				}
				((Dictionary<string, Dictionary<string, object>>)obj)[item.Key]["Payload"] = (float)((Dictionary<string, Dictionary<string, object>>)obj)[item.Key]["Payload"] * num;
			}
			else
			{
				((Dictionary<string, Dictionary<string, object>>)obj)[item.Key]["Payload"] = (float)((Dictionary<string, Dictionary<string, object>>)obj)[item.Key]["Payload"] + num * (float)mod;
			}
		}
	}

	private void ProcessBuildingModifier(Modifier modifier, ref Dictionary<string, Dictionary<string, object>> fixedModifierDict, ref Dictionary<string, Dictionary<string, object>> percentModifierDict, int mod)
	{
		if (!modifier.PayloadDictionary.ContainsKey("Payload"))
		{
			return;
		}
		string text = modifier.PayloadDictionary["Payload"].ToString();
		if (text.Length <= 0)
		{
			return;
		}
		List<string> list = new List<string>();
		if (modifier.PayloadDictionary.ContainsKey("WorkShop"))
		{
			string[] array = modifier.PayloadDictionary["WorkShop"].ToString().Split(',');
			foreach (string text2 in array)
			{
				list.Add("WorkShop" + text2);
			}
		}
		else if (modifier.PayloadDictionary.ContainsKey("BuildingType"))
		{
			string[] array2 = modifier.PayloadDictionary["BuildingType"].ToString().Split(',');
			foreach (string text3 in array2)
			{
				list.Add("BuildingType" + text3);
			}
		}
		Dictionary<string, Dictionary<string, object>> dictionary;
		float num;
		if (text.IndexOf('%') == -1)
		{
			dictionary = fixedModifierDict;
			num = NumericParser.Float(text);
		}
		else
		{
			dictionary = percentModifierDict;
			num = NumericParser.FloatPercent(text);
		}
		if (list.Count > 0)
		{
			foreach (string item in list)
			{
				if (!dictionary.ContainsKey(item))
				{
					dictionary.Add(item, new Dictionary<string, object>());
				}
				if (!dictionary[item].ContainsKey(modifier.ModifierId))
				{
					dictionary[item].Add(modifier.ModifierId, new Dictionary<string, object>());
					((Dictionary<string, object>)dictionary[item][modifier.ModifierId]).Add("Payload", 0f);
				}
				((Dictionary<string, object>)dictionary[item][modifier.ModifierId])["Payload"] = (float)((Dictionary<string, object>)dictionary[item][modifier.ModifierId])["Payload"] + num * (float)mod;
			}
			return;
		}
		if (!dictionary.ContainsKey(modifier.ModifierId))
		{
			dictionary.Add(modifier.ModifierId, new Dictionary<string, object>());
			dictionary[modifier.ModifierId].Add("Payload", 0f);
		}
		dictionary[modifier.ModifierId]["Payload"] = (float)dictionary[modifier.ModifierId]["Payload"] + num * (float)mod;
	}

	private void ProcessStockLimitModifier(Modifier modifier, ref Dictionary<string, Dictionary<string, object>> fixedModifierDict, ref Dictionary<string, Dictionary<string, object>> percentModifierDict, int mod)
	{
		if (!modifier.PayloadDictionary.ContainsKey("Payload"))
		{
			return;
		}
		string text = modifier.PayloadDictionary["Payload"].ToString();
		Dictionary<string, object> dictionary;
		if (modifier.PayloadDictionary["Payload"] is IDictionary)
		{
			dictionary = (Dictionary<string, object>)modifier.PayloadDictionary["Payload"];
			text = (dictionary.TryGetValue("Payload", out var value) ? value.ToString() : string.Empty);
		}
		else
		{
			dictionary = modifier.PayloadDictionary;
		}
		float num;
		Dictionary<string, Dictionary<string, object>> dictionary2;
		if (text.IndexOf('%') == -1)
		{
			num = int.Parse(text) * mod;
			dictionary2 = fixedModifierDict;
		}
		else
		{
			num = NumericParser.FloatPercent(text) * (float)mod;
			if (Mathf.Abs(num) < float.Epsilon)
			{
				return;
			}
			dictionary2 = percentModifierDict;
		}
		List<string> list = new List<string>();
		if (dictionary.ContainsKey("Category"))
		{
			string[] array = dictionary["Category"].ToString().Split(',');
			foreach (string text2 in array)
			{
				list.Add("Category" + text2);
			}
		}
		else if (dictionary.ContainsKey("ItemId"))
		{
			string[] array2 = dictionary["ItemId"].ToString().Split(',');
			foreach (string text3 in array2)
			{
				list.Add("Item" + text3);
			}
		}
		if (list.Count > 0)
		{
			foreach (string item in list)
			{
				if (!dictionary2.ContainsKey(item))
				{
					dictionary2.Add(item, new Dictionary<string, object>());
				}
				if (!dictionary2[item].ContainsKey(modifier.ModifierId))
				{
					dictionary2[item].Add(modifier.ModifierId, new Dictionary<string, object>());
					((Dictionary<string, object>)dictionary2[item][modifier.ModifierId]).Add("Payload", 0f);
				}
				((Dictionary<string, object>)dictionary2[item][modifier.ModifierId])["Payload"] = (float)((Dictionary<string, object>)dictionary2[item][modifier.ModifierId])["Payload"] + num;
			}
			return;
		}
		if (!dictionary2.ContainsKey(modifier.ModifierId))
		{
			dictionary2.Add(modifier.ModifierId, new Dictionary<string, object>());
			dictionary2[modifier.ModifierId].Add("Payload", 0f);
		}
		dictionary2[modifier.ModifierId]["Payload"] = (float)dictionary2[modifier.ModifierId]["Payload"] + num;
	}

	private void ProcessRecycleRebateModifier(Modifier modifier, ref Dictionary<string, Dictionary<string, object>> fixedModifierDict, ref Dictionary<string, Dictionary<string, object>> percentModifierDict, int mod)
	{
		if (!modifier.PayloadDictionary.ContainsKey("Payload"))
		{
			return;
		}
		string text = modifier.PayloadDictionary["Payload"].ToString();
		float num;
		Dictionary<string, Dictionary<string, object>> dictionary;
		if (text.IndexOf('%') == -1)
		{
			num = NumericParser.Float(text) * (float)mod;
			dictionary = fixedModifierDict;
		}
		else
		{
			num = NumericParser.FloatPercent(text) * (float)mod;
			if (Mathf.Abs(num) < float.Epsilon)
			{
				return;
			}
			dictionary = percentModifierDict;
		}
		if (!dictionary.ContainsKey(modifier.ModifierId))
		{
			dictionary.Add(modifier.ModifierId, new Dictionary<string, object>());
			dictionary[modifier.ModifierId].Add("Payload", 0f);
		}
		dictionary[modifier.ModifierId]["Payload"] = (float)dictionary[modifier.ModifierId]["Payload"] + num;
		Managers.UserArchiveManager.SetConfigValue("RebateRate", Managers.RecycleManager.RebateRate);
	}

	private void ProcessOfflineYieldModifier(Modifier modifier, int mod)
	{
		float offlineYieldTimeLimit = Managers.UserArchiveManager.GetOfflineYieldTimeLimit();
		Managers.UserArchiveManager.SetOfflineYieldTimeLimit(offlineYieldTimeLimit + Convert.ToSingle(modifier.PayloadDictionary["Payload"]) * (float)mod);
	}

	private static void ProcessCommonModifier(Modifier modifier, ref Dictionary<string, Dictionary<string, object>> fixedModifierDict, ref Dictionary<string, Dictionary<string, object>> percentModifierDict, int mod)
	{
		if (!modifier.PayloadDictionary.ContainsKey("Payload"))
		{
			return;
		}
		string text = modifier.PayloadDictionary["Payload"].ToString();
		if (modifier.PayloadDictionary["Payload"] is IDictionary)
		{
			Dictionary<string, object> dictionary = (Dictionary<string, object>)modifier.PayloadDictionary["Payload"];
			text = (dictionary.TryGetValue("Payload", out var value) ? value.ToString() : string.Empty);
		}
		if (text.Length > 0)
		{
			Dictionary<string, Dictionary<string, object>> dictionary2;
			float num;
			if (text.IndexOf('%') == -1)
			{
				dictionary2 = fixedModifierDict;
				num = NumericParser.Float(text);
			}
			else
			{
				dictionary2 = percentModifierDict;
				num = NumericParser.FloatPercent(text);
			}
			if (!dictionary2.ContainsKey(modifier.ModifierId))
			{
				dictionary2.Add(modifier.ModifierId, new Dictionary<string, object>());
				dictionary2[modifier.ModifierId].Add("Payload", 0f);
			}
			dictionary2[modifier.ModifierId]["Payload"] = (float)dictionary2[modifier.ModifierId]["Payload"] + num * (float)mod;
		}
	}

	public void ReadFromModifier(Modifier modifier, int mod = 1)
	{
		Dictionary<string, Dictionary<string, object>> fixedModifierDict;
		Dictionary<string, Dictionary<string, object>> percentModifierDict;
		switch (modifier.Scope)
		{
		case 2:
			fixedModifierDict = MainCityFixedModifierDictionary;
			percentModifierDict = MainCityPercentModifierDictionary;
			break;
		case 3:
			fixedModifierDict = MainBattleFixedModifierDictionary;
			percentModifierDict = MainBattlePercentModifierDictionary;
			break;
		default:
			fixedModifierDict = GlobalFixedModifierDictionary;
			percentModifierDict = GlobalPercentModifierDictionary;
			break;
		}
		switch (modifier.ModifierId)
		{
		case "Bonus":
			ProcessBonusModifier(Managers, modifier, mod);
			break;
		case "AttributeBundle":
			ProcessAttributeBundleModifier(modifier, ref fixedModifierDict, ref percentModifierDict, mod);
			break;
		case "ProductionEfficiency":
		case "ProducingTime":
		case "ProduceCost":
		case "FreeProduceChance":
		case "Alchemy":
		case "StubornWorker":
			ProcessBuildingModifier(modifier, ref fixedModifierDict, ref percentModifierDict, mod);
			break;
		case "StockLimit":
			ProcessStockLimitModifier(modifier, ref fixedModifierDict, ref percentModifierDict, mod);
			break;
		case "RecycleRebate":
			ProcessRecycleRebateModifier(modifier, ref fixedModifierDict, ref percentModifierDict, mod);
			break;
		case "OfflineYieldTimeLimit":
			ProcessOfflineYieldModifier(modifier, mod);
			break;
		default:
			ProcessCommonModifier(modifier, ref fixedModifierDict, ref percentModifierDict, mod);
			break;
		}
		Flush();
	}

	public float GetFixedFloatPayload(string modifierId, string[] subKeys = null)
	{
		float num = 0f;
		foreach (int scope in Modifier.ScopeList)
		{
			num += GetFixedFloatPayload(modifierId, scope);
			if (subKeys != null)
			{
				foreach (string subKey in subKeys)
				{
					num += GetFixedFloatPayload(modifierId, scope, subKey);
				}
			}
		}
		return num;
	}

	public float GetFixedFloatPayload(string modifierId, int scopeField)
	{
		float num = 0f;
		Dictionary<string, Dictionary<string, object>> dictionary = scopeField switch
		{
			2 => MainCityFixedModifierDictionary, 
			3 => MainBattleFixedModifierDictionary, 
			_ => GlobalFixedModifierDictionary, 
		};
		if (dictionary.ContainsKey(modifierId))
		{
			num += (float)dictionary[modifierId]["Payload"];
		}
		return num;
	}

	public float GetFixedFloatPayload(string modifierId, int scopeField, string subKey)
	{
		float num = 0f;
		Dictionary<string, object> dictionary;
		switch (scopeField)
		{
		case 2:
			if (!MainCityFixedModifierDictionary.ContainsKey(subKey))
			{
				return num;
			}
			dictionary = MainCityFixedModifierDictionary[subKey];
			break;
		case 3:
			if (!MainBattleFixedModifierDictionary.ContainsKey(subKey))
			{
				return num;
			}
			dictionary = MainBattleFixedModifierDictionary[subKey];
			break;
		default:
			if (!GlobalFixedModifierDictionary.ContainsKey(subKey))
			{
				return num;
			}
			dictionary = GlobalFixedModifierDictionary[subKey];
			break;
		}
		if (dictionary.ContainsKey(modifierId))
		{
			num += (float)((Dictionary<string, object>)dictionary[modifierId])["Payload"];
		}
		return num;
	}

	public float GetPercentFloatPayload(string modifierId, string[] subKeys = null)
	{
		float num = 0f;
		Calc calc = (Modifier.NeedStackMultipleProcess(modifierId) ? ((Calc)((float a, float b) => a * b)) : ((Calc)((float a, float b) => a + b)));
		foreach (int scope in Modifier.ScopeList)
		{
			num = calc(num, GetPercentFloatPayload(modifierId, scope));
			if (subKeys != null)
			{
				foreach (string subKey in subKeys)
				{
					num = calc(num, GetPercentFloatPayload(modifierId, scope, subKey));
				}
			}
		}
		return num;
	}

	public float GetPercentFloatPayload(string modifierId, int scopeField)
	{
		float num = 0f;
		Dictionary<string, Dictionary<string, object>> dictionary = scopeField switch
		{
			2 => MainCityPercentModifierDictionary, 
			3 => MainBattlePercentModifierDictionary, 
			_ => GlobalPercentModifierDictionary, 
		};
		if (dictionary.ContainsKey(modifierId))
		{
			num += (float)dictionary[modifierId]["Payload"];
		}
		return num;
	}

	public float GetPercentFloatPayload(string modifierId, int scopeField, string subKey)
	{
		float num = 0f;
		Dictionary<string, object> dictionary;
		switch (scopeField)
		{
		case 2:
			if (!MainCityPercentModifierDictionary.ContainsKey(subKey))
			{
				return num;
			}
			dictionary = MainCityPercentModifierDictionary[subKey];
			break;
		case 3:
			if (!MainBattlePercentModifierDictionary.ContainsKey(subKey))
			{
				return num;
			}
			dictionary = MainBattlePercentModifierDictionary[subKey];
			break;
		default:
			if (!GlobalPercentModifierDictionary.ContainsKey(subKey))
			{
				return num;
			}
			dictionary = GlobalPercentModifierDictionary[subKey];
			break;
		}
		if (dictionary.ContainsKey(modifierId))
		{
			num += (float)((Dictionary<string, object>)dictionary[modifierId])["Payload"];
		}
		return num;
	}
}
