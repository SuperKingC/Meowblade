using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Managers;
using GameDataEditor;
using ILRuntime_LitJson;
using Shift.Legion.ClientApi.Protocol.UserAction;
using Shift.Legion.Common.Enums;
using Shift.Legion.Common.Helpers;
using Shift.Legion.Common.Managers;
using Shift.Legion.Helpers;

namespace Shift.Legion.Common.Models;

public struct Modifier
{
	public const int POSITIVE_MOD = 1;

	public const int NEGATIVE_MOD = -1;

	public const int SCOPE_AT_GLOBAL = 1;

	public const int SCOPE_AT_MAIN_CITY = 2;

	public const int SCOPE_AT_MAIN_BATTLE = 3;

	private static List<int> _scopeList;

	private static Dictionary<string, string> _attrIdToNameDictionary;

	public static readonly List<string> EntityAttrModifierList = new List<string>
	{
		"EA01", "EA02", "EA03", "EA04", "EA05", "EA09", "EA08", "EA15", "EA07", "EA06",
		"EA10", "EA11", "EA12", "EA13", "EA14", "EA16", "EA17", "EA18", "EA19", "EA20",
		"EA21", "EA22", "EA23", "EA26", "EA27", "EA28", "EA29"
	};

	private static readonly List<string> _percentConvertProps = new List<string> { "EA04", "EA05", "EA06", "EA07" };

	public const string Health = "EA01";

	public const string Attack = "EA02";

	public const string Defense = "EA03";

	public const string CriticalChance = "EA04";

	public const string CriticalDamageModifier = "EA05";

	public const string HitRate = "EA06";

	public const string EvasionRate = "EA07";

	public const string AttackSpeed = "EA08";

	public const string MoveSpeed = "EA09";

	public const string EvoLevel = "EA10";

	public const string MajorBreakthroughLevel = "EA11";

	public const string HealthPerLevel = "EA12";

	public const string AttackPerLevel = "EA13";

	public const string DefensePerLevel = "EA14";

	public const string AttackDistance = "EA15";

	public const string DamageSettlement = "EA16";

	public const string HurtSettlement = "EA17";

	public const string BaseAttack = "EA18";

	public const string BaseAttackSpeed = "EA19";

	public const string BaseDefense = "EA20";

	public const string BaseMoveSpeed = "EA21";

	public const string BaseHealth = "EA22";

	public const string DamageReflect = "EA23";

	public const string CureSettlement = "EA24";

	public const string RecoverSettlement = "EA25";

	public const string StackDamageSettlement = "EA26";

	public const string StackHurtSettlement = "EA27";

	public const string StackCureSettlement = "EA28";

	public const string StackRecoverSettlement = "EA29";

	public const string StackCooldownReduction = "EA30";

	public const string StackCollisionRadiusReduction = "EA31";

	public const string FireResistance = "EA50";

	public const string IceResistance = "EA51";

	public const string NatureResistance = "EA52";

	public const string ShadowResistance = "EA53";

	public const string HolyResistance = "EA54";

	public const string SpiritResistance = "EA55";

	public const string FireDamage = "EA60";

	public const string IceDamage = "EA61";

	public const string NatureDamage = "EA62";

	public const string ShadowDamage = "EA63";

	public const string HolyDamage = "EA64";

	public const string SpiritDamage = "EA65";

	public const string HonorPoint = "HonorPoint";

	public const string AutoProduceEfficiency = "AutoProduceEfficiency";

	public const string OccupiedProduceEfficiency = "OccupiedProduceEfficiency";

	public const string AttributeBundle = "AttributeBundle";

	public const string LazyWorker = "LazyWorker";

	public const string DiligentWorker = "DiligentWorker";

	public const string LazyWorkerDuration = "LazyWorkerDuration";

	public const string DiligentWorkerDuration = "DiligentWorkerDuration";

	public const string WorkerSpeed = "WorkerSpeed";

	public const string MapResistance = "MapResistance";

	public const string TreasureFinder = "TreasureFinder";

	public const string StubbornWorker = "StubornWorker";

	public const string ProducingTime = "ProducingTime";

	public const string ProductionEfficiency = "ProductionEfficiency";

	public const string Alchemy = "Alchemy";

	public const string ProduceCost = "ProduceCost";

	public const string FreeProduceChance = "FreeProduceChance";

	public const string SoldierEvoCost = "SoldierEvoCost";

	public const string SoldierBreakthroughCost = "SoldierBreakthroughCost";

	public const string SoldierPotentialUpgradeCost = "SoldierPotentialUpgradeCost";

	public const string BuildingUpgradeCost = "BuildingUpgradeCost";

	public const string ItemUpgradeCost = "ItemUpgradeCost";

	public const string SoldierExpGain = "SoldierExpGain";

	public const string UserExpGain = "UserExpGain";

	public const string DungeonExpGain = "DungeonExpGain";

	public const string LegionSize = "LegionSize";

	public const string SingleProductionAmount = "SingleProductionAmount";

	public const string StockLimit = "StockLimit";

	public const string Bonus = "Bonus";

	public const string OfflineYieldTimeLimit = "OfflineYieldTimeLimit";

	public const string BossDamage = "BossDamage";

	public const string RareItemCards3Of1 = "RareItemCards3Of1";

	public const string RareItemSummonStoneLottery = "RareItemSummonStoneLottery";

	public const string ActivityTicketCost = "ActivityTicketCost";

	public const string CloneSoldier = "CloneSoldier";

	public const string SoldierCost = "SoldierCost";

	public const string BuildEfficiency = "BuildEfficiency";

	public const string Daily = "Daily";

	public const string TimeMachine = "TimeMachine";

	public const string Leasehold = "Leasehold";

	public const string RecycleRebate = "RecycleRebate";

	public const string UnlockMainCityCom = "UnlockMainCityCom";

	public const string UnlockFormationSlots = "UnlockFormationSlots";

	public const string UnlockBuilding = "UnlockBuilding";

	public const string UnlockActivityLevelCase = "UnlockActivityLevelCase";

	public const string IncreaseSoldierStockLimit = "IncreaseSoldierStockLimit";

	public const string IncreaseSoldierQuantityInStock = "IncreaseSoldierQuantityInStock";

	public const string UIParams = "UIParams";

	public const string StoreItem = "StoreItem";

	public const string UseMinChapter = "UseMinChapter";

	public const string UseMinLevel = "UseMinLevel";

	public const string LockText = "LockText";

	public const string UnlockText = "UnlockText";

	public string ModifierId;

	public string Desc;

	public int Scope;

	public Dictionary<string, object> PayloadDictionary;

	public static List<int> ScopeList
	{
		get
		{
			if (_scopeList == null)
			{
				_scopeList = new List<int> { 1, 2, 3 };
			}
			return _scopeList;
		}
	}

	public static Dictionary<string, string> AttrIdToNameDictionary
	{
		get
		{
			object obj = _attrIdToNameDictionary;
			if (obj == null)
			{
				obj = new Dictionary<string, string>
				{
					{
						"EA01",
						LanguagesManager.GetDesc("CsharpCodeZhTcText771")
					},
					{
						"EA02",
						LanguagesManager.GetDesc("CsharpCodeZhTcText608")
					},
					{
						"EA03",
						LanguagesManager.GetDesc("CsharpCodeZhTcText772")
					},
					{
						"EA04",
						LanguagesManager.GetDesc("CsharpCodeZhTcText773")
					},
					{
						"EA05",
						LanguagesManager.GetDesc("CsharpCodeZhTcText774")
					},
					{
						"EA09",
						LanguagesManager.GetDesc("CsharpCodeZhTcText775")
					},
					{
						"EA08",
						LanguagesManager.GetDesc("CsharpCodeZhTcText776")
					},
					{
						"EA15",
						LanguagesManager.GetDesc("CsharpCodeZhTcText777")
					},
					{
						"EA07",
						LanguagesManager.GetDesc("CsharpCodeZhTcText778")
					},
					{
						"EA06",
						LanguagesManager.GetDesc("CsharpCodeZhTcText779")
					},
					{
						"EA10",
						LanguagesManager.GetDesc("CsharpCodeZhTcText780")
					},
					{
						"EA11",
						LanguagesManager.GetDesc("CsharpCodeZhTcText781")
					},
					{
						"EA12",
						LanguagesManager.GetDesc("CsharpCodeZhTcText782")
					},
					{
						"EA13",
						LanguagesManager.GetDesc("CsharpCodeZhTcText783")
					},
					{
						"EA14",
						LanguagesManager.GetDesc("CsharpCodeZhTcText784")
					},
					{
						"EA16",
						LanguagesManager.GetDesc("CsharpCodeZhTcText785")
					},
					{
						"EA17",
						LanguagesManager.GetDesc("CsharpCodeZhTcText786")
					},
					{
						"EA18",
						LanguagesManager.GetDesc("CsharpCodeZhTcText787")
					},
					{
						"EA19",
						LanguagesManager.GetDesc("CsharpCodeZhTcText788")
					},
					{
						"EA20",
						LanguagesManager.GetDesc("CsharpCodeZhTcText789")
					},
					{
						"EA21",
						LanguagesManager.GetDesc("CsharpCodeZhTcText790")
					},
					{
						"EA22",
						LanguagesManager.GetDesc("CsharpCodeZhTcText791")
					},
					{
						"EA23",
						LanguagesManager.GetDesc("CsharpCodeZhTcText792")
					},
					{
						"EA24",
						LanguagesManager.GetDesc("CsharpCodeZhTcText793")
					},
					{
						"EA25",
						LanguagesManager.GetDesc("CsharpCodeZhTcText794")
					},
					{
						"EA26",
						LanguagesManager.GetDesc("CsharpCodeZhTcText785")
					},
					{
						"EA27",
						LanguagesManager.GetDesc("CsharpCodeZhTcText786")
					},
					{
						"EA28",
						LanguagesManager.GetDesc("CsharpCodeZhTcText793")
					},
					{
						"EA29",
						LanguagesManager.GetDesc("CsharpCodeZhTcText794")
					}
				};
				_attrIdToNameDictionary = (Dictionary<string, string>)obj;
			}
			return (Dictionary<string, string>)obj;
		}
	}

	public static bool IsDRAttr(string modifierId)
	{
		int result;
		switch (modifierId)
		{
		default:
			result = ((modifierId == "EA55") ? 1 : 0);
			break;
		case "EA50":
		case "EA51":
		case "EA52":
		case "EA53":
		case "EA54":
			result = 1;
			break;
		}
		return (byte)result != 0;
	}

	public static string TranslateModifierId(string attribute)
	{
		if (AttrIdToNameDictionary.TryGetValue(attribute, out var value))
		{
			return value;
		}
		return attribute;
	}

	public static KeyValuePair<string, string> TranslateModifierKeyValue(string id, object data)
	{
		string key = TranslateModifierId(id);
		string text = data.ToString();
		bool flag = text.EndsWith("%");
		bool flag2 = text.Contains(".");
		if (!flag)
		{
			if (_percentConvertProps.Contains(id))
			{
				text = $"{NumericParser.Float(text) * 100f:F1}%";
				flag = true;
			}
			else if (flag2)
			{
				text = $"{NumericParser.Float(text):F1}";
			}
		}
		if (!flag2)
		{
			return new KeyValuePair<string, string>(key, text);
		}
		int num;
		for (num = text.Length; num > 0; num--)
		{
			switch (text[num - 1])
			{
			case '.':
				num--;
				break;
			case '%':
			case '0':
				continue;
			}
			break;
		}
		text = text.Substring(0, num);
		if (flag)
		{
			text += "%";
		}
		return new KeyValuePair<string, string>(key, text);
	}

	public static string ParseModifiedValue(object val)
	{
		if (string.IsNullOrEmpty(val.ToString()))
		{
			return "";
		}
		return string.Format("{0}{1}", (val.ToString().IndexOf('-') == -1) ? "+" : "", val);
	}

	private static string GetDescription(string template)
	{
		return template;
	}

	private static string GetDescription(GameManagers managers, string template, Dictionary<string, object> dictionary)
	{
		foreach (KeyValuePair<string, object> item in dictionary)
		{
			if (template.IndexOf("{" + item.Key + "}", StringComparison.Ordinal) != -1)
			{
				template = template.Replace("{" + item.Key + "}", SchemaIndexHelper.GetNameById(managers, item.Value.ToString()));
			}
		}
		return template;
	}

	public static bool NeedStackMultipleProcess(string modifierId)
	{
		int result;
		switch (modifierId)
		{
		default:
			result = ((modifierId == "EA29") ? 1 : 0);
			break;
		case "EA26":
		case "EA27":
		case "EA28":
			result = 1;
			break;
		}
		return (byte)result != 0;
	}

	public static bool NeedReverseValeProcess(string modifierId)
	{
		int result;
		switch (modifierId)
		{
		default:
			result = ((modifierId == "EA55") ? 1 : 0);
			break;
		case "EA27":
		case "EA30":
		case "EA31":
		case "EA50":
		case "EA51":
		case "EA52":
		case "EA53":
		case "EA54":
			result = 1;
			break;
		}
		return (byte)result != 0;
	}

	public static bool NeedPercentConvertProcess(string modifierId)
	{
		return _percentConvertProps.Contains(modifierId);
	}

	public T GetPayload<T>()
	{
		return (T)PayloadDictionary["Payload"];
	}

	public Modifier(GameManagers managers, string modifierId, object payload)
	{
		//IL_00f7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fe: Expected O, but got Unknown
		this = default(Modifier);
		GDEModifierData gDEModifierData = GDMgr.Get<GDEModifierData>(modifierId);
		Scope = 1;
		ModifierId = modifierId;
		Desc = gDEModifierData?.Desc ?? string.Empty;
		PayloadDictionary = new Dictionary<string, object>();
		Dictionary<string, object> dictionary = new Dictionary<string, object>();
		string text = payload.ToString();
		if (payload is string && ((string)payload).StartsWith("{"))
		{
			dictionary = JsonHelper.ToObject<Dictionary<string, object>>((string)payload);
		}
		else if (text.StartsWith("{"))
		{
			dictionary = JsonHelper.ToObject<Dictionary<string, object>>(text);
		}
		else if (!(payload is IDictionary))
		{
			dictionary.Add("Payload", payload);
		}
		else
		{
			Dictionary<string, object> dictionary2 = (Dictionary<string, object>)payload;
			foreach (string key in dictionary2.Keys)
			{
				JsonData val = (JsonData)dictionary2[key];
				if (val.IsArray)
				{
					string json = val.ToJson();
					ArrayList value = JsonHelper.ToObject<ArrayList>(json);
					dictionary.Add(key, value);
				}
				else if (val.IsObject)
				{
					string json2 = val.ToJson();
					Dictionary<string, object> value2 = JsonHelper.ToObject<Dictionary<string, object>>(json2);
					dictionary.Add(key, value2);
				}
				else
				{
					dictionary.Add(key, ((object)val).ToString());
				}
			}
		}
		HandleDataWithPayload(managers, dictionary);
	}

	public Modifier(GameManagers managers, string modifierId, Dictionary<string, object> payloadDictionary)
	{
		this = default(Modifier);
		GDEModifierData gDEModifierData = GDMgr.Get<GDEModifierData>(modifierId);
		Scope = 1;
		ModifierId = modifierId;
		Desc = gDEModifierData?.Desc ?? string.Empty;
		PayloadDictionary = new Dictionary<string, object>();
		HandleDataWithPayload(managers, payloadDictionary);
	}

	private void ParseAttributeBundleData(Dictionary<string, object> dataDict)
	{
		if (dataDict.ContainsKey("Scope"))
		{
			Scope = Convert.ToInt32(dataDict["Scope"]);
		}
		Desc = "";
		foreach (KeyValuePair<string, object> item in dataDict)
		{
			KeyValuePair<string, string> keyValuePair = TranslateModifierKeyValue(item.Key, item.Value);
			Desc = Desc + keyValuePair.Key + ParseModifiedValue(keyValuePair.Value) + ", ";
			PayloadDictionary.Add(item.Key, item.Value.ToString());
		}
		Desc = Desc.TrimEnd(',', ' ');
	}

	private void ParseBonusData(GameManagers managers, Dictionary<string, object> dataDict)
	{
		//IL_0316: Unknown result type (might be due to invalid IL or missing references)
		//IL_0320: Expected O, but got Unknown
		Desc = "";
		foreach (KeyValuePair<string, object> item in dataDict)
		{
			object obj = item.Value;
			switch (item.Key)
			{
			case "Payload":
				if (obj is Dictionary<string, object>)
				{
					ParseBonusData(managers, (Dictionary<string, object>)obj);
					return;
				}
				Desc += SchemaIndexHelper.GetNameById(managers, item.Key);
				break;
			case "AutoProduce":
				if (!(obj is Dictionary<string, int>))
				{
					obj = JsonHelper.ToObject<Dictionary<string, int>>(obj.ToString());
				}
				Desc = Desc + LanguagesManager.GetDesc("CsharpCodeZhTcText802") + ": ";
				foreach (KeyValuePair<string, int> item2 in (Dictionary<string, int>)obj)
				{
					Desc = Desc + SchemaIndexHelper.GetNameById(managers, item2.Key) + ParseModifiedValue(item2.Value) + ", ";
				}
				break;
			case "Unlock":
				Desc = Desc + LanguagesManager.GetDesc("CsharpCodeZhTcText113") + ": ";
				foreach (object item3 in (IEnumerable)(JsonData)obj)
				{
					string nameById = SchemaIndexHelper.GetNameById(managers, item3.ToString());
					Desc += $"{nameById}, ";
				}
				break;
			case "ManPower":
				Desc += LanguagesManager.GetDesc("CsharpCodeZhTcText795");
				break;
			case "Gem":
				Desc += LanguagesManager.GetDesc("CsharpCodeZhTcText796");
				break;
			case "SoldierExp":
				Desc += LanguagesManager.GetDesc("CsharpCodeZhTcText797");
				break;
			case "UserExp":
				Desc += LanguagesManager.GetDesc("CsharpCodeZhTcText798");
				break;
			case "DungeonExp":
				Desc += LanguagesManager.GetDesc("CsharpCodeZhTcText799");
				break;
			case "CollectableResource":
				Desc += LanguagesManager.GetDesc("CsharpCodeZhTcText800");
				break;
			case "ResourcePortal1":
			case "ResourcePortal2":
			case "ResourcePortal3":
				Desc += LanguagesManager.GetDesc("CsharpCodeZhTcText801");
				break;
			default:
				Desc += SchemaIndexHelper.GetNameById(managers, item.Key);
				break;
			}
			if (item.Key != "AutoProduce" && item.Key != "Unlock")
			{
				Desc = Desc + ParseModifiedValue(item.Value) + ", ";
			}
			PayloadDictionary.Add(item.Key, obj);
		}
		Desc = Desc.TrimEnd(',', ' ');
	}

	private void ParseCommonData(GameManagers managers, Dictionary<string, object> dataDict)
	{
		PayloadDictionary = dataDict;
		if (dataDict.TryGetValue("Payload", out var value))
		{
			Desc = (Desc.Contains("{Payload}") ? (GetDescription(managers, Desc, dataDict) ?? "") : (GetDescription(managers, Desc, dataDict) + ParseModifiedValue(value)));
		}
	}

	private void HandleDataWithPayload(GameManagers managers, Dictionary<string, object> payload)
	{
		switch (ModifierId)
		{
		case "AttributeBundle":
			ParseAttributeBundleData(payload);
			break;
		case "Bonus":
			ParseBonusData(managers, payload);
			break;
		case "UnlockMainCityCom":
		{
			if (payload != null && payload.TryGetValue("Component", out var value3))
			{
				string[] array2 = value3.ToString().Split(',');
				foreach (string componentName in array2)
				{
					managers.UserArchiveManager.UnlockMainCityCom(componentName);
				}
			}
			break;
		}
		case "UnlockFormationSlots":
		{
			if (payload == null || !payload.TryGetValue("Slots", out var value7))
			{
				break;
			}
			int num2 = int.Parse(value7.ToString());
			string text2 = ChapterType.StoryMain.ToString();
			string text3 = BattleMode.RushMode.ToString();
			List<string> list2 = managers.UserArchiveManager.GetBattleFormation(text2, text3).Values.ToList();
			for (int j = 0; j < num2; j++)
			{
				if (list2[j] == "Lock")
				{
					managers.FormationUnitsManager.ChangeFormationUnit(text2, text3, j, "Unlock");
				}
			}
			break;
		}
		case "UnlockBuilding":
		{
			if (payload != null && payload.TryGetValue("BuildingType", out var value2))
			{
				string type = value2.ToString();
				managers.BuildingManager.GetBuildingByType(type)?.FinishUpgradeForUseItem();
			}
			break;
		}
		case "UnlockActivityLevelCase":
		{
			if (payload == null || !payload.TryGetValue("ActivityId", out var value4))
			{
				break;
			}
			string text = value4.ToString();
			if (string.IsNullOrEmpty(text))
			{
				break;
			}
			managers.UserArchiveManager.SetExcludeLevelCaseActivities(text);
			{
				foreach (Activity item in GameManagers.Instance.ActivityManager.GetActivitiesByType(ActivityType.Lottery))
				{
					if (item.ContentType != ActivityContentType.NewbieGACHA)
					{
						continue;
					}
					item.CheckStatus(managers, out var _, sendEvent: false);
					break;
				}
				break;
			}
		}
		case "IncreaseSoldierStockLimit":
			if (payload != null)
			{
				payload.TryGetValue("LimitIncrement", out var value5);
				payload.TryGetValue("ExpiredTime", out var value6);
				int timeStamp = DateTimeHelper.GetTimeStamp(DateTime.Parse(value6?.ToString()));
				if (value5 != null)
				{
					managers.UserArchiveManager.SetIslandComeAgainSoldierStockLimitIncrease(Convert.ToInt32(value5), timeStamp);
				}
			}
			break;
		case "IncreaseSoldierQuantityInStock":
		{
			if (payload == null || !payload.TryGetValue("IncreaseStock", out var value) || managers.UserArchiveManager.GetIslandComeAgainSoldierStockIncreased())
			{
				break;
			}
			int offset = int.Parse(value.ToString());
			List<string> list = managers.StockController.GetOwnedSoldiers(onlyUnlocked: true).Keys.ToList();
			StockChangeRecord[] array = new StockChangeRecord[list.Count];
			int num = 0;
			foreach (string item2 in list)
			{
				array[num++] = new StockChangeRecord
				{
					ItemId = item2,
					Offset = offset,
					Context = 110,
					ContextValue = item2,
					Type = 1
				};
			}
			managers.StockController.ReadStockChangeRecords(array);
			managers.UserArchiveManager.SetIslandComeAgainSoldierStockIncreased();
			break;
		}
		default:
			ParseCommonData(managers, payload);
			break;
		}
	}
}
