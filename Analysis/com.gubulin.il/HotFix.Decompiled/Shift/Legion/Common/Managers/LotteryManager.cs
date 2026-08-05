using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GameDataEditor;
using GameMaths;
using Shift.Legion.Common.Helpers;
using Shift.Legion.Common.Models;
using Shift.Legion.Common.Sources.Enums;
using Shift.Legion.Helpers;

namespace Shift.Legion.Common.Managers;

public class LotteryManager : Manager
{
	private Dictionary<string, Config<DynamicPrizePoolConfig>> _dynamicPrizePoolConfigDictionary;

	private const string CommonDrawCaseIndex = "__Common";

	private Dictionary<string, List<CardDrawCase>> _drawCasesOfActivity;

	private const string DrawStatKey = "DrawStats";

	private Config<CardDrawConfig> _cardDrawStats;

	private const string PendingLotteryResultKey = "PendingLotteryResult";

	private Config<List<LotteryPendingResult>> _pendingLotteryResult;

	public static Dictionary<string, int> DrawOptionToCnt = new Dictionary<string, int>
	{
		{ "单抽", 1 },
		{ "十连抽", 10 }
	};

	public Dictionary<string, Config<DynamicPrizePoolConfig>> DynamicPrizePoolConfigs
	{
		get
		{
			if (_dynamicPrizePoolConfigDictionary == null)
			{
				_dynamicPrizePoolConfigDictionary = new Dictionary<string, Config<DynamicPrizePoolConfig>>();
				foreach (GDEDynamicPrizePoolData allItem in GDMgr.GetAllItems<GDEDynamicPrizePoolData>())
				{
					bool flag = Managers.UserArchiveManager.Contains(allItem.Key);
					Config<DynamicPrizePoolConfig> config = Managers.UserArchiveManager.GetConfig<DynamicPrizePoolConfig>(allItem.Key);
					if (!flag)
					{
						config.SetValue(new DynamicPrizePoolConfig(allItem));
					}
					_dynamicPrizePoolConfigDictionary.Add(allItem.Key, config);
				}
			}
			return _dynamicPrizePoolConfigDictionary;
		}
	}

	private Dictionary<string, List<CardDrawCase>> DrawCasesOfActivity
	{
		get
		{
			if (_drawCasesOfActivity == null)
			{
				_drawCasesOfActivity = new Dictionary<string, List<CardDrawCase>>();
				foreach (GDELotteryCaseData item in from gdeCaseData in GDMgr.GetAllItems<GDELotteryCaseData>()
					where gdeCaseData.Status > 0
					orderby gdeCaseData.Priority descending
					select gdeCaseData)
				{
					CardDrawCase cardDrawCase = new CardDrawCase(Managers, item);
					string key = (string.IsNullOrEmpty(cardDrawCase.ActivityId) ? "__Common" : cardDrawCase.ActivityId);
					if (!_drawCasesOfActivity.TryGetValue(key, out var value))
					{
						value = new List<CardDrawCase>();
						_drawCasesOfActivity.Add(key, value);
					}
					value.Add(cardDrawCase);
				}
			}
			return _drawCasesOfActivity;
		}
	}

	public Config<CardDrawConfig> CardDrawStats
	{
		get
		{
			if (_cardDrawStats == null)
			{
				UserArchiveManager userArchiveManager = Managers.UserArchiveManager;
				if (userArchiveManager.Contains("DrawStats"))
				{
					_cardDrawStats = userArchiveManager.GetConfig<CardDrawConfig>("DrawStats");
				}
				else
				{
					userArchiveManager.SetConfigValue("DrawStats", new CardDrawConfig());
					_cardDrawStats = userArchiveManager.GetConfig<CardDrawConfig>("DrawStats");
				}
			}
			return _cardDrawStats;
		}
	}

	public Config<List<LotteryPendingResult>> PendingLotteryResult
	{
		get
		{
			if (_pendingLotteryResult == null)
			{
				UserArchiveManager userArchiveManager = Managers.UserArchiveManager;
				if (userArchiveManager.Contains("PendingLotteryResult"))
				{
					_pendingLotteryResult = userArchiveManager.GetConfig<List<LotteryPendingResult>>("PendingLotteryResult");
				}
				else
				{
					userArchiveManager.SetConfigValue("PendingLotteryResult", new List<LotteryPendingResult>());
					_pendingLotteryResult = userArchiveManager.GetConfig<List<LotteryPendingResult>>("PendingLotteryResult");
				}
			}
			return _pendingLotteryResult;
		}
	}

	public LotteryManager(GameManagers managers)
		: base(managers)
	{
	}

	public List<CardDrawCase> GetActivityDrawCases(string activityId)
	{
		if (!DrawCasesOfActivity.TryGetValue("__Common", out var value))
		{
			value = new List<CardDrawCase>();
		}
		if (!DrawCasesOfActivity.TryGetValue(activityId, out var value2))
		{
			return value;
		}
		if (value.Count > 0)
		{
			return (from caseData in value2.Concat(value)
				orderby caseData.Priority descending
				select caseData).ToList();
		}
		return value2;
	}

	public override Task Init()
	{
		return null;
	}

	private List<Dictionary<string, object>> GenerateWeightedBonusDictionary(string prizePoolId, out int totalWeight)
	{
		List<Dictionary<string, object>> list = new List<Dictionary<string, object>>();
		int num = (totalWeight = 0);
		GDEPrizePoolData gDEPrizePoolData = GDMgr.Get<GDEPrizePoolData>(prizePoolId);
		if (gDEPrizePoolData == null)
		{
			return list;
		}
		List<Dictionary<string, object>> list2 = new List<Dictionary<string, object>>();
		if (!string.IsNullOrEmpty(gDEPrizePoolData.BonusConfig))
		{
			list2.Add(new Dictionary<string, object>
			{
				{ "Type", 1 },
				{ "Config", gDEPrizePoolData.BonusConfig }
			});
		}
		if (!string.IsNullOrEmpty(gDEPrizePoolData.UnlockConfig))
		{
			list2.Add(new Dictionary<string, object>
			{
				{ "Type", 2 },
				{ "Config", gDEPrizePoolData.UnlockConfig }
			});
		}
		Dictionary<string, int> dictionary = new Dictionary<string, int>();
		float num2 = 1f;
		switch ((PrizePoolType)gDEPrizePoolData.Type)
		{
		case PrizePoolType.Cards3Of1:
			num2 += Managers.ModifierManager.GetPercentFloatPayload("RareItemCards3Of1");
			break;
		case PrizePoolType.SummonStoneLottery:
			num2 += Managers.ModifierManager.GetPercentFloatPayload("RareItemSummonStoneLottery");
			break;
		}
		if (!string.IsNullOrEmpty(gDEPrizePoolData.Rarity))
		{
			foreach (KeyValuePair<string, int> item in JsonHelper.ToObject<Dictionary<string, int>>(gDEPrizePoolData.Rarity))
			{
				dictionary.Add(item.Key, item.Value);
			}
		}
		foreach (Dictionary<string, object> item2 in list2)
		{
			int num3 = (int)item2["Type"];
			Dictionary<string, List<int>> dictionary2 = JsonHelper.ToObject<Dictionary<string, List<int>>>(item2["Config"] as string);
			foreach (KeyValuePair<string, List<int>> item3 in dictionary2)
			{
				if (!SchemaIndexHelper.IdToSchemaDictionary.ContainsKey(item3.Key))
				{
					continue;
				}
				string value = SchemaIndexHelper.IdToSchemaDictionary[item3.Key].ToString();
				int num4 = (dictionary.ContainsKey(item3.Key) ? dictionary[item3.Key] : (-1));
				int num5 = 0;
				if (item3.Value.Count == 2)
				{
					num5 = item3.Value[1];
				}
				else if (item3.Value.Count == 3)
				{
					num5 = Managers.RandomManager.Int(item3.Value[1], item3.Value[2] + 1);
				}
				int num6 = item3.Value[0];
				if (num6 > 0 && num5 > 0)
				{
					if (num4 > 1)
					{
						num6 = Mathf.CeilToInt(num2 * (float)num6);
					}
					num += num6;
					list.Add(new Dictionary<string, object>
					{
						{ "Weight", num6 },
						{ "Type", num3 },
						{ "Schema", value },
						{ "ItemId", item3.Key },
						{ "Qty", num5 },
						{ "IsShining", num4 }
					});
				}
			}
		}
		totalWeight = num;
		return list;
	}

	private List<KeyValuePair<Bonus, int>> GetLotteryByWeightedBonusList(ref List<Dictionary<string, object>> weightedBonuses, int totalWeight, int extractNum = 1, bool replacement = false, List<string> lotteryRecord = null)
	{
		List<KeyValuePair<Bonus, int>> list = new List<KeyValuePair<Bonus, int>>();
		if (weightedBonuses.Count > 0 && totalWeight > 0 && extractNum > 0)
		{
			if (extractNum >= weightedBonuses.Count && !replacement)
			{
				foreach (Dictionary<string, object> weightedBonuse in weightedBonuses)
				{
					if (!weightedBonuse.TryGetValue("IsShining", out var value))
					{
						value = -1;
					}
					list.AddRange(GenerateBonusInstance(weightedBonuse["ItemId"].ToString(), (int)weightedBonuse["Qty"], (int)weightedBonuse["Type"], replacement: false, lotteryRecord, (int)value));
				}
				weightedBonuses.Clear();
				return list;
			}
			for (int i = 0; i < extractNum; i++)
			{
				int num = 0;
				int num2 = 0;
				int num3 = Managers.RandomManager.Int(0, totalWeight);
				int num4 = -1;
				bool flag = false;
				for (int j = 0; j < weightedBonuses.Count; j++)
				{
					int num5 = (int)weightedBonuses[j]["Weight"];
					num2 += num5;
					if (num3 >= num && num3 < num2)
					{
						List<KeyValuePair<Bonus, int>> list2 = GenerateBonusInstance(weightedBonuses[j]["ItemId"].ToString(), (int)weightedBonuses[j]["Qty"], (int)weightedBonuses[j]["Type"], replacement, lotteryRecord, (int)weightedBonuses[j]["IsShining"]);
						if (list2.Count > 0)
						{
							list.AddRange(list2);
						}
						else
						{
							i--;
							flag = true;
						}
						num4 = j;
						break;
					}
					num = num2;
				}
				if (num4 >= 0 && (!replacement || flag))
				{
					totalWeight -= (int)weightedBonuses[num4]["Weight"];
					weightedBonuses.RemoveAt(num4);
				}
				if (weightedBonuses.Count < 1)
				{
					break;
				}
			}
		}
		return list;
	}

	private List<KeyValuePair<Bonus, int>> GetLotteryFromSimplePool(string poolId, int extractNum = 1, bool replacement = false)
	{
		List<KeyValuePair<Bonus, int>> list = new List<KeyValuePair<Bonus, int>>();
		GDESimplePoolData gDESimplePoolData = GDMgr.Get<GDESimplePoolData>(poolId);
		if (gDESimplePoolData == null)
		{
			return list;
		}
		List<string> list2 = JsonHelper.ToObject<List<string>>(gDESimplePoolData.Range);
		Dictionary<string, int> dictionary = new Dictionary<string, int>();
		if (!string.IsNullOrEmpty(gDESimplePoolData.Rarity))
		{
			foreach (KeyValuePair<string, int> item in JsonHelper.ToObject<Dictionary<string, int>>(gDESimplePoolData.Rarity))
			{
				dictionary.Add(item.Key, item.Value);
			}
		}
		if (list2.Count > 0)
		{
			for (int i = 0; i < extractNum; i++)
			{
				string text = list2[Managers.RandomManager.Int(list2.Count)];
				List<KeyValuePair<Bonus, int>> list3 = GenerateBonusInstance(text, 1);
				for (int j = 0; j < list3.Count; j++)
				{
					KeyValuePair<Bonus, int> keyValuePair = list3[j];
					Bonus key = keyValuePair.Key;
					list.Add(new KeyValuePair<Bonus, int>(key, key.IsShining = (dictionary.ContainsKey(key.ItemId) ? dictionary[key.ItemId] : keyValuePair.Value)));
				}
				if (!replacement)
				{
					list2.Remove(text);
					if (list2.Count < 1)
					{
						break;
					}
				}
			}
		}
		return list;
	}

	private List<KeyValuePair<Bonus, int>> GetLotteryFromDynamicPool(string poolId, int extractNum = 1)
	{
		List<KeyValuePair<Bonus, int>> list = new List<KeyValuePair<Bonus, int>>();
		if (!DynamicPrizePoolConfigs.TryGetValue(poolId, out var value))
		{
			return list;
		}
		DynamicPrizePoolConfig value2 = value.GetValue();
		int num = 0;
		List<Dictionary<string, object>> weightedBonuses = new List<Dictionary<string, object>>();
		Dictionary<string, int> dictionary = new Dictionary<string, int>();
		GDEDynamicPrizePoolData gDEDynamicPrizePoolData = GDMgr.Get<GDEDynamicPrizePoolData>(value.Key);
		if (gDEDynamicPrizePoolData == null)
		{
			return list;
		}
		if (!string.IsNullOrEmpty(gDEDynamicPrizePoolData.Rarity))
		{
			foreach (KeyValuePair<string, int> item in JsonHelper.ToObject<Dictionary<string, int>>(gDEDynamicPrizePoolData.Rarity))
			{
				dictionary.Add(item.Key, item.Value);
			}
		}
		foreach (KeyValuePair<string, List<int>> item2 in value2.Content)
		{
			string key = item2.Key;
			List<int> value3 = item2.Value;
			int num2 = value3[0];
			num += num2;
			int num3;
			if (value3.Count == 2)
			{
				num3 = value3[1];
			}
			else
			{
				if (value3.Count != 3)
				{
					continue;
				}
				num3 = Managers.RandomManager.Int(value3[1], value3[2] + 1);
			}
			weightedBonuses.Add(new Dictionary<string, object>
			{
				{ "Weight", num2 },
				{ "Type", 1 },
				{
					"Schema",
					SchemaIndexHelper.GetSchemaById(key)
				},
				{ "ItemId", key },
				{ "Qty", num3 },
				{
					"IsShining",
					dictionary.ContainsKey(key) ? dictionary[key] : (-1)
				}
			});
		}
		list.AddRange(GetLotteryByWeightedBonusList(ref weightedBonuses, num, extractNum, value2.Replacement));
		if (!value2.Replacement)
		{
			List<string> list2 = new List<string>();
			foreach (Dictionary<string, object> item3 in weightedBonuses)
			{
				list2.Add(item3["ItemId"].ToString());
			}
			string[] array = value2.Content.Keys.ToArray();
			foreach (string text in array)
			{
				if (!list2.Contains(text))
				{
					value2.RemoveFromContent(text);
				}
			}
			value.SetValue(value2);
		}
		return list;
	}

	private List<KeyValuePair<Bonus, int>> GenerateBonusInstance(string itemId, int qty, int type = 1, bool replacement = false, List<string> lotteryRecord = null, int isShining = -1)
	{
		string schemaById = SchemaIndexHelper.GetSchemaById(itemId);
		List<KeyValuePair<Bonus, int>> result = new List<KeyValuePair<Bonus, int>>();
		switch (schemaById)
		{
		case "PrizePool":
		case "DynamicPrizePool":
		case "SimplePool":
			DoLottery(ref result, new KeyValuePair<string, int>[1]
			{
				new KeyValuePair<string, int>(itemId, qty)
			}, replacement, lotteryRecord);
			break;
		default:
		{
			Bonus bonus = Bonus.Get(itemId, qty, type);
			int value = (bonus.IsShining = ((isShining < 0) ? Item.IsShining(bonus.ItemId) : isShining));
			result.Add(new KeyValuePair<Bonus, int>(bonus, value));
			break;
		}
		}
		return result;
	}

	public Dictionary<int, Dictionary<int, List<Bonus>>> GetLotteryById(string prizeComboId, bool mergeResult = false, bool replacement = false)
	{
		Dictionary<int, Dictionary<int, List<Bonus>>> dictionary = new Dictionary<int, Dictionary<int, List<Bonus>>>();
		List<KeyValuePair<Bonus, int>> result = new List<KeyValuePair<Bonus, int>>();
		GDEPrizePoolComboData gDEPrizePoolComboData = GDMgr.Get<GDEPrizePoolComboData>(prizeComboId);
		if (gDEPrizePoolComboData == null)
		{
			return dictionary;
		}
		DoLottery(ref result, JsonHelper.ToObject<Dictionary<string, int>>(gDEPrizePoolComboData.ComboConfig), replacement);
		Dictionary<int, Dictionary<int, List<string>>> dictionary2 = null;
		if (mergeResult)
		{
			dictionary2 = new Dictionary<int, Dictionary<int, List<string>>>();
		}
		foreach (KeyValuePair<Bonus, int> item in result)
		{
			Bonus key = item.Key;
			if (mergeResult)
			{
				if (!dictionary2.ContainsKey(key.Type))
				{
					dictionary2.Add(key.Type, new Dictionary<int, List<string>>());
					dictionary.Add(key.Type, new Dictionary<int, List<Bonus>>());
				}
				if (!dictionary2[key.Type].ContainsKey(key.Category))
				{
					dictionary2[key.Type].Add(key.Category, new List<string>());
					dictionary[key.Type].Add(key.Category, new List<Bonus>());
				}
				int num = dictionary2[key.Type][key.Category].IndexOf(key.ItemId);
				if (num == -1)
				{
					dictionary2[key.Type][key.Category].Add(key.ItemId);
					dictionary[key.Type][key.Category].Add(key);
				}
				else
				{
					Bonus bonus = dictionary[key.Type][key.Category][num];
					dictionary[key.Type][key.Category][num] = bonus.Merge(key);
				}
			}
			else
			{
				if (!dictionary.ContainsKey(key.Type))
				{
					dictionary.Add(key.Type, new Dictionary<int, List<Bonus>>());
				}
				if (!dictionary[key.Type].ContainsKey(key.Category))
				{
					dictionary[key.Type].Add(key.Category, new List<Bonus>());
				}
				dictionary[key.Type][key.Category].Add(key);
			}
		}
		return dictionary;
	}

	public List<KeyValuePair<Bonus, int>> GetLotteryAsListById(string prizeComboId, bool mergeResult = false, bool replacement = false)
	{
		List<KeyValuePair<Bonus, int>> result = new List<KeyValuePair<Bonus, int>>();
		GDEPrizePoolComboData gDEPrizePoolComboData = GDMgr.Get<GDEPrizePoolComboData>(prizeComboId);
		if (gDEPrizePoolComboData == null)
		{
			return result;
		}
		DoLottery(ref result, JsonHelper.ToObject<Dictionary<string, int>>(gDEPrizePoolComboData.ComboConfig), replacement);
		if (mergeResult)
		{
			Dictionary<int, Dictionary<int, Dictionary<string, int>>> dictionary = new Dictionary<int, Dictionary<int, Dictionary<string, int>>>();
			List<KeyValuePair<Bonus, int>> list = new List<KeyValuePair<Bonus, int>>();
			foreach (KeyValuePair<Bonus, int> item in result)
			{
				Bonus key = item.Key;
				if (!dictionary.ContainsKey(key.Type))
				{
					dictionary.Add(key.Type, new Dictionary<int, Dictionary<string, int>>());
				}
				if (!dictionary[key.Type].ContainsKey(key.Category))
				{
					dictionary[key.Type].Add(key.Category, new Dictionary<string, int>());
				}
				if (!dictionary[key.Type][key.Category].ContainsKey(key.ItemId))
				{
					dictionary[key.Type][key.Category].Add(key.ItemId, list.Count);
					list.Add(new KeyValuePair<Bonus, int>(key, item.Value));
				}
				else
				{
					int index = dictionary[key.Type][key.Category][key.ItemId];
					KeyValuePair<Bonus, int> keyValuePair = list[index];
					list[index] = new KeyValuePair<Bonus, int>(keyValuePair.Key.Merge(key), keyValuePair.Value);
				}
			}
			return list;
		}
		return result;
	}

	private void DoLottery(ref List<KeyValuePair<Bonus, int>> result, IEnumerable<KeyValuePair<string, int>> prizeComboDict, bool replacement = false, List<string> lotteryRecord = null)
	{
		if (lotteryRecord == null)
		{
			lotteryRecord = new List<string>();
		}
		foreach (KeyValuePair<string, int> item2 in prizeComboDict)
		{
			string key = item2.Key;
			int value = item2.Value;
			switch (SchemaIndexHelper.GetSchemaById(key))
			{
			case "PrizePool":
			{
				int totalWeight;
				List<Dictionary<string, object>> weightedBonuses = GenerateWeightedBonusDictionary(key, out totalWeight);
				List<Dictionary<string, object>> list = new List<Dictionary<string, object>>();
				foreach (Dictionary<string, object> item3 in weightedBonuses)
				{
					string item = item3["ItemId"].ToString();
					if (lotteryRecord.Contains(item))
					{
						list.Add(item3);
					}
				}
				if (list.Count < weightedBonuses.Count)
				{
					foreach (Dictionary<string, object> item4 in list)
					{
						weightedBonuses.Remove(item4);
						totalWeight -= (int)item4["Weight"];
					}
				}
				foreach (KeyValuePair<Bonus, int> lotteryByWeightedBonus in GetLotteryByWeightedBonusList(ref weightedBonuses, totalWeight, value, replacement, lotteryRecord))
				{
					Bonus key5 = lotteryByWeightedBonus.Key;
					if (!lotteryRecord.Contains(key5.ItemId))
					{
						lotteryRecord.Add(key5.ItemId);
					}
					result.Add(new KeyValuePair<Bonus, int>(key5, lotteryByWeightedBonus.Value));
				}
				break;
			}
			case "SimplePool":
				foreach (KeyValuePair<Bonus, int> item5 in GetLotteryFromSimplePool(key, value, replacement))
				{
					Bonus key4 = item5.Key;
					if (!lotteryRecord.Contains(key4.ItemId))
					{
						lotteryRecord.Add(key4.ItemId);
					}
					result.Add(new KeyValuePair<Bonus, int>(key4, item5.Value));
				}
				break;
			case "DynamicPrizePool":
				foreach (KeyValuePair<Bonus, int> item6 in GetLotteryFromDynamicPool(key, value))
				{
					Bonus key3 = item6.Key;
					if (!lotteryRecord.Contains(key3.ItemId))
					{
						lotteryRecord.Add(key3.ItemId);
					}
					result.Add(new KeyValuePair<Bonus, int>(key3, item6.Value));
				}
				break;
			default:
			{
				Bonus key2 = Bonus.Get(key, value);
				result.Add(new KeyValuePair<Bonus, int>(key2, Item.IsShining(key)));
				break;
			}
			}
		}
	}

	public void ClaimLotteryResult(string prizePoolComboId)
	{
		foreach (Dictionary<int, List<Bonus>> value in GetLotteryById(prizePoolComboId).Values)
		{
			foreach (List<Bonus> value2 in value.Values)
			{
				foreach (Bonus item in value2)
				{
					item.Claim(Managers);
				}
			}
		}
	}

	public void StatsDrawCnt(string activityId, string drawType, int incrBy = 1, bool save = true)
	{
		CardDrawConfig value = CardDrawStats.GetValue();
		if (!value.DrawCntStats.ContainsKey(activityId))
		{
			value.DrawCntStats.Add(activityId, new Dictionary<string, int>());
		}
		if (!value.DrawCntStats[activityId].ContainsKey(drawType))
		{
			value.DrawCntStats[activityId].Add(drawType, 0);
		}
		value.DrawCntStats[activityId][drawType] += incrBy;
		if (save)
		{
			CardDrawStats.SetValue(value);
		}
	}

	public void StatsDrawCost(string activityId, string drawType, IEnumerable<KeyValuePair<string, int>> cost, bool save = true)
	{
		CardDrawConfig value = CardDrawStats.GetValue();
		if (!value.CostStats.ContainsKey(activityId))
		{
			value.CostStats.Add(activityId, new Dictionary<string, Dictionary<string, int>>());
		}
		if (!value.CostStats[activityId].ContainsKey(drawType))
		{
			value.CostStats[activityId].Add(drawType, new Dictionary<string, int>());
		}
		foreach (KeyValuePair<string, int> item in cost)
		{
			if (value.CostStats[activityId][drawType].ContainsKey(item.Key))
			{
				value.CostStats[activityId][drawType][item.Key] += item.Value;
			}
			else
			{
				value.CostStats[activityId][drawType].Add(item.Key, item.Value);
			}
		}
		if (save)
		{
			CardDrawStats.SetValue(value);
		}
	}

	public void StatsLotteryCases(IEnumerable<string> caseIds, int incrBy = 1, bool save = true)
	{
		CardDrawConfig value = CardDrawStats.GetValue();
		foreach (string caseId in caseIds)
		{
			if (value.LotteryCaseStats.ContainsKey(caseId))
			{
				value.LotteryCaseStats[caseId] += incrBy;
			}
			else
			{
				value.LotteryCaseStats.Add(caseId, incrBy);
			}
		}
		if (save)
		{
			CardDrawStats.SetValue(value);
		}
	}

	public void StatsLotteryResult(string activityId, string drawType, IEnumerable<KeyValuePair<string, int>> lotteryResult, bool save = true)
	{
		CardDrawConfig value = CardDrawStats.GetValue();
		if (!value.LotteryResultStats.ContainsKey(activityId))
		{
			value.LotteryResultStats.Add(activityId, new Dictionary<string, Dictionary<string, int>>());
		}
		if (!value.LotteryResultStats[activityId].ContainsKey(drawType))
		{
			value.LotteryResultStats[activityId].Add(drawType, new Dictionary<string, int>());
		}
		foreach (KeyValuePair<string, int> item in lotteryResult)
		{
			if (!value.LotteryResultStats[activityId][drawType].ContainsKey(item.Key))
			{
				value.LotteryResultStats[activityId][drawType].Add(item.Key, 0);
			}
			value.LotteryResultStats[activityId][drawType][item.Key] += item.Value;
		}
		if (save)
		{
			CardDrawStats.SetValue(value);
		}
	}

	public void StatsLotteryCache(string activityId, string drawType, IEnumerable<KeyValuePair<string, int>> lotteryResult, int incrBy = 1, bool save = true)
	{
		if (lotteryResult == null)
		{
			return;
		}
		CardDrawConfig value = CardDrawStats.GetValue();
		foreach (CardDrawCase activityDrawCase in GetActivityDrawCases(activityId))
		{
			string caseId = activityDrawCase.CaseId;
			if (activityDrawCase.CaseType != LotteryCaseType.MinPrizes)
			{
				continue;
			}
			if (!value.LotteryResultCache.TryGetValue(activityId, out var value2))
			{
				value2 = new Dictionary<string, Dictionary<string, Dictionary<string, int>>>();
				value.LotteryResultCache.Add(activityId, value2);
			}
			if (!value2.TryGetValue(drawType, out var value3))
			{
				value3 = new Dictionary<string, Dictionary<string, int>>();
				value2.Add(drawType, value3);
			}
			if (!value3.TryGetValue(caseId, out var value4))
			{
				value4 = new Dictionary<string, int>();
				value3.Add(caseId, value4);
			}
			if (!value.DrawCntCache.TryGetValue(activityId, out var value5))
			{
				value5 = new Dictionary<string, Dictionary<string, int>>();
				value.DrawCntCache.Add(activityId, value5);
			}
			if (!value5.TryGetValue(drawType, out var value6))
			{
				value6 = new Dictionary<string, int>();
				value5.Add(drawType, value6);
			}
			foreach (KeyValuePair<string, int> item in lotteryResult)
			{
				if (value4.ContainsKey(item.Key))
				{
					value4[item.Key] += item.Value;
				}
				else
				{
					value4.Add(item.Key, item.Value);
				}
			}
			if (value6.ContainsKey(caseId))
			{
				value6[caseId] += incrBy;
			}
			else
			{
				value6.Add(caseId, incrBy);
			}
		}
		if (save)
		{
			CardDrawStats.SetValue(value);
		}
	}

	public void Stats(string activityId, string drawType, IEnumerable<string> caseIds, int drawCnt, IEnumerable<KeyValuePair<string, int>> cost, IEnumerable<KeyValuePair<string, int>> lotteryResult)
	{
		StatsDrawCnt(activityId, drawType, drawCnt, save: false);
		StatsDrawCost(activityId, drawType, cost, save: false);
		StatsLotteryResult(activityId, drawType, lotteryResult, save: false);
		StatsLotteryCases(caseIds, drawCnt, save: false);
		StatsLotteryCache(activityId, drawType, lotteryResult, drawCnt, save: false);
		CardDrawStats.Save();
	}

	public int GetTotalDrawCnt(string activityId = null, string drawType = null)
	{
		CardDrawConfig value = CardDrawStats.GetValue();
		if (string.IsNullOrEmpty(activityId) && string.IsNullOrEmpty(drawType))
		{
			return value.DrawCntStats.Values.Sum((Dictionary<string, int> cntByType) => cntByType.Values.Sum());
		}
		if (!string.IsNullOrEmpty(activityId) && string.IsNullOrEmpty(drawType))
		{
			if (!value.DrawCntStats.TryGetValue(activityId, out var value2))
			{
				return 0;
			}
			return value2.Values.Sum();
		}
		if (string.IsNullOrEmpty(activityId) && !string.IsNullOrEmpty(drawType))
		{
			return value.DrawCntStats.Values.Where((Dictionary<string, int> cntByType) => cntByType.ContainsKey(drawType)).Sum((Dictionary<string, int> cntByType) => cntByType[drawType]);
		}
		if (!value.DrawCntStats.TryGetValue(activityId, out var value3) || !value3.TryGetValue(drawType, out var value4))
		{
			return 0;
		}
		return value4;
	}

	public Dictionary<string, int> GetTotalDrawCost(string activityId = null, string drawType = null)
	{
		CardDrawConfig value = CardDrawStats.GetValue();
		Dictionary<string, int> dictionary = new Dictionary<string, int>();
		if (string.IsNullOrEmpty(activityId) && string.IsNullOrEmpty(drawType))
		{
			foreach (Dictionary<string, Dictionary<string, int>> value5 in value.CostStats.Values)
			{
				foreach (Dictionary<string, int> value6 in value5.Values)
				{
					foreach (KeyValuePair<string, int> item in value6)
					{
						if (dictionary.ContainsKey(item.Key))
						{
							dictionary[item.Key] += item.Value;
						}
						else
						{
							dictionary.Add(item.Key, item.Value);
						}
					}
				}
			}
		}
		else if (!string.IsNullOrEmpty(activityId) && string.IsNullOrEmpty(drawType))
		{
			if (!value.CostStats.TryGetValue(activityId, out var value2))
			{
				return dictionary;
			}
			foreach (Dictionary<string, int> value7 in value2.Values)
			{
				foreach (KeyValuePair<string, int> item2 in value7)
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
			}
		}
		else
		{
			if (!string.IsNullOrEmpty(activityId) || string.IsNullOrEmpty(drawType))
			{
				if (!value.CostStats.TryGetValue(activityId, out var value3) || !value3.TryGetValue(drawType, out var value4))
				{
					return dictionary;
				}
				return value4;
			}
			foreach (Dictionary<string, int> item3 in from statsByType in value.CostStats.Values
				where statsByType.ContainsKey(drawType)
				select statsByType[drawType])
			{
				foreach (KeyValuePair<string, int> item4 in item3)
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
			}
		}
		return dictionary;
	}

	public Dictionary<string, int> GetTotalLotteryResult(string activityId = null, string drawType = null)
	{
		CardDrawConfig value = CardDrawStats.GetValue();
		Dictionary<string, int> dictionary = new Dictionary<string, int>();
		if (string.IsNullOrEmpty(activityId) && string.IsNullOrEmpty(drawType))
		{
			foreach (Dictionary<string, Dictionary<string, int>> value5 in value.LotteryResultStats.Values)
			{
				foreach (Dictionary<string, int> value6 in value5.Values)
				{
					foreach (KeyValuePair<string, int> item in value6)
					{
						if (dictionary.ContainsKey(item.Key))
						{
							dictionary[item.Key] += item.Value;
						}
						else
						{
							dictionary.Add(item.Key, item.Value);
						}
					}
				}
			}
		}
		else if (!string.IsNullOrEmpty(activityId) && string.IsNullOrEmpty(drawType))
		{
			if (!value.LotteryResultStats.TryGetValue(activityId, out var value2))
			{
				return dictionary;
			}
			foreach (Dictionary<string, int> value7 in value2.Values)
			{
				foreach (KeyValuePair<string, int> item2 in value7)
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
			}
		}
		else
		{
			if (!string.IsNullOrEmpty(activityId) || string.IsNullOrEmpty(drawType))
			{
				if (!value.LotteryResultStats.TryGetValue(activityId, out var value3) || !value3.TryGetValue(drawType, out var value4))
				{
					return dictionary;
				}
				return value4;
			}
			foreach (Dictionary<string, int> item3 in from statsByType in value.LotteryResultStats.Values
				where statsByType.ContainsKey(drawType)
				select statsByType[drawType])
			{
				foreach (KeyValuePair<string, int> item4 in item3)
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
			}
		}
		return dictionary;
	}

	public int GetCaseHitCnt(string caseId)
	{
		CardDrawConfig value = CardDrawStats.GetValue();
		if (!value.LotteryCaseStats.TryGetValue(caseId, out var value2))
		{
			return 0;
		}
		return value2;
	}

	public Dictionary<string, int> GetCaseLotteryResultCache(string caseId, string activityId = null, string drawType = null)
	{
		CardDrawConfig value = CardDrawStats.GetValue();
		Dictionary<string, int> dictionary = new Dictionary<string, int>();
		if (string.IsNullOrEmpty(activityId) && string.IsNullOrEmpty(drawType))
		{
			foreach (Dictionary<string, Dictionary<string, Dictionary<string, int>>> value7 in value.LotteryResultCache.Values)
			{
				foreach (Dictionary<string, Dictionary<string, int>> value8 in value7.Values)
				{
					if (!value8.TryGetValue(caseId, out var value2))
					{
						continue;
					}
					foreach (KeyValuePair<string, int> item in value2)
					{
						if (dictionary.ContainsKey(item.Key))
						{
							dictionary[item.Key] += item.Value;
						}
						else
						{
							dictionary.Add(item.Key, item.Value);
						}
					}
				}
			}
		}
		else if (!string.IsNullOrEmpty(activityId) && string.IsNullOrEmpty(drawType))
		{
			if (!value.LotteryResultCache.TryGetValue(activityId, out var value3))
			{
				return dictionary;
			}
			foreach (Dictionary<string, int> item2 in from statsByCase in value3.Values
				where statsByCase.ContainsKey(caseId)
				select statsByCase[caseId])
			{
				foreach (KeyValuePair<string, int> item3 in item2)
				{
					if (dictionary.ContainsKey(item3.Key))
					{
						dictionary[item3.Key] += item3.Value;
					}
					else
					{
						dictionary.Add(item3.Key, item3.Value);
					}
				}
			}
		}
		else
		{
			if (!string.IsNullOrEmpty(activityId) || string.IsNullOrEmpty(drawType))
			{
				if (!value.LotteryResultCache.TryGetValue(activityId, out var value4) || !value4.TryGetValue(drawType, out var value5) || !value5.TryGetValue(caseId, out var value6))
				{
					return dictionary;
				}
				return value6;
			}
			foreach (Dictionary<string, int> item4 in from statsByType in value.LotteryResultCache.Values
				where statsByType.ContainsKey(drawType)
				select statsByType[drawType] into statsByCase
				where statsByCase.ContainsKey(caseId)
				select statsByCase[caseId])
			{
				foreach (KeyValuePair<string, int> item5 in item4)
				{
					if (dictionary.ContainsKey(item5.Key))
					{
						dictionary[item5.Key] += item5.Value;
					}
					else
					{
						dictionary.Add(item5.Key, item5.Value);
					}
				}
			}
		}
		return dictionary;
	}

	public int GetCaseDrawCntCache(string caseId, string activityId = null, string drawType = null)
	{
		CardDrawConfig value = CardDrawStats.GetValue();
		if (string.IsNullOrEmpty(activityId) && string.IsNullOrEmpty(drawType))
		{
			return value.DrawCntCache.Values.Sum((Dictionary<string, Dictionary<string, int>> cntByType) => (from cntByCase in cntByType.Values
				where cntByCase.ContainsKey(caseId)
				select cntByCase[caseId]).Sum());
		}
		if (!string.IsNullOrEmpty(activityId) && string.IsNullOrEmpty(drawType))
		{
			if (!value.DrawCntCache.TryGetValue(activityId, out var value2))
			{
				return 0;
			}
			return (from cntByCase in value2.Values
				where cntByCase.ContainsKey(caseId)
				select cntByCase[caseId]).Sum();
		}
		if (string.IsNullOrEmpty(activityId) && !string.IsNullOrEmpty(drawType))
		{
			return (from cntByType in value.DrawCntCache.Values
				where cntByType.ContainsKey(drawType)
				select cntByType[drawType] into cntByCase
				where cntByCase.ContainsKey(caseId)
				select cntByCase[caseId]).Sum();
		}
		if (!value.DrawCntCache.TryGetValue(activityId, out var value3) || !value3.TryGetValue(drawType, out var value4) || !value4.TryGetValue(caseId, out var value5))
		{
			return 0;
		}
		return value5;
	}

	public void ResetCaseLotteryCache(string caseId)
	{
		CardDrawConfig value = CardDrawStats.GetValue();
		foreach (Dictionary<string, Dictionary<string, int>> value3 in value.DrawCntCache.Values)
		{
			foreach (Dictionary<string, int> value4 in value3.Values)
			{
				if (value4.ContainsKey(caseId))
				{
					value4[caseId] = 0;
				}
			}
		}
		foreach (Dictionary<string, Dictionary<string, Dictionary<string, int>>> value5 in value.LotteryResultCache.Values)
		{
			foreach (Dictionary<string, Dictionary<string, int>> value6 in value5.Values)
			{
				if (value6.TryGetValue(caseId, out var value2))
				{
					value2.Clear();
				}
			}
		}
		CardDrawStats.Save();
	}
}
