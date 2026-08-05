using System;
using System.Collections.Generic;
using GameDataEditor;
using Shift.Legion.Common.Helpers;
using Shift.Legion.Common.Managers;
using Shift.Legion.Helpers;

namespace Shift.Legion.Common.Models;

public class SoldierBreakthroughData
{
	public struct BreakthroughBonusAndDemand
	{
		public Dictionary<string, float> FixBonus;

		public Dictionary<string, float> PercentBonus;

		public Dictionary<string, float> Require;
	}

	private const int TotalFieldsForBreakthrough = 17;

	private static Dictionary<string, Dictionary<int, SoldierBreakthroughData>> _soldierBreakthroughDataDictionary;

	private static Dictionary<string, int> _soldierMaxBreakthroughDictionary;

	private static Dictionary<string, Dictionary<int, List<BreakthroughBonusAndDemand>>> _breakthroughDataDictionary;

	public readonly int BreakthroughLevel;

	public readonly int MajorLevel;

	public readonly int MinorLevel;

	public readonly Dictionary<string, float> NextFixBonus;

	public readonly Dictionary<string, float> NextPercentBonus;

	public readonly int NextMajorLevel;

	public readonly int NextMinorLevel;

	public readonly Dictionary<string, float> NextRequire;

	public readonly string SoldierId;

	public readonly Dictionary<string, float> TotalFixBonus;

	public readonly Dictionary<string, float> TotalPercentBonus;

	public static Dictionary<string, Dictionary<int, List<BreakthroughBonusAndDemand>>> BreakthroughDataDictionary
	{
		get
		{
			if (_breakthroughDataDictionary == null)
			{
				_breakthroughDataDictionary = new Dictionary<string, Dictionary<int, List<BreakthroughBonusAndDemand>>>();
				List<string> list = new List<string>();
				IEnumerable<GDEBreakthroughData> allItems = GDMgr.GetAllItems<GDEBreakthroughData>();
				foreach (GDEBreakthroughData item2 in allItems)
				{
					list.Add(item2.Key);
				}
				foreach (string item3 in list)
				{
					GDEBreakthroughData gDEBreakthroughData = GDMgr.Get<GDEBreakthroughData>(item3);
					if (gDEBreakthroughData == null)
					{
						continue;
					}
					object obj = gDEBreakthroughData.GetType().GetProperty("SoldierID")?.GetValue(gDEBreakthroughData);
					object obj2 = gDEBreakthroughData.GetType().GetProperty("BreakthroughLevel")?.GetValue(gDEBreakthroughData);
					if (obj == null || obj2 == null)
					{
						continue;
					}
					string key = obj.ToString();
					int key2 = Convert.ToInt32(obj2) - 1;
					if (!_breakthroughDataDictionary.ContainsKey(key))
					{
						_breakthroughDataDictionary.Add(key, new Dictionary<int, List<BreakthroughBonusAndDemand>>());
					}
					if (!_breakthroughDataDictionary[key].ContainsKey(key2))
					{
						_breakthroughDataDictionary[key].Add(key2, new List<BreakthroughBonusAndDemand>());
					}
					List<BreakthroughBonusAndDemand> list2 = _breakthroughDataDictionary[key][key2];
					for (int i = 0; i < 17; i++)
					{
						string name = $"Property{i + 1}";
						string name2 = $"Demand{i + 1}";
						object value = gDEBreakthroughData.GetType().GetProperty(name).GetValue(gDEBreakthroughData);
						if (gDEBreakthroughData == null || value == null)
						{
							break;
						}
						BreakthroughBonusAndDemand item = new BreakthroughBonusAndDemand
						{
							FixBonus = new Dictionary<string, float>(),
							PercentBonus = new Dictionary<string, float>()
						};
						foreach (KeyValuePair<string, object> item4 in JsonHelper.ToObject<Dictionary<string, object>>(value.ToString()))
						{
							string text = item4.Value.ToString();
							if (!Modifier.EntityAttrModifierList.Contains(item4.Key))
							{
								continue;
							}
							if (text.IndexOf('%') == -1)
							{
								float num = NumericParser.Float(text);
								if (item.FixBonus.ContainsKey(item4.Key))
								{
									item.FixBonus[item4.Key] += num;
								}
								else
								{
									item.FixBonus.Add(item4.Key, num);
								}
							}
							else
							{
								float num = NumericParser.FloatPercent(text);
								if (item.PercentBonus.ContainsKey(item4.Key))
								{
									item.PercentBonus[item4.Key] += num;
								}
								else
								{
									item.PercentBonus.Add(item4.Key, num);
								}
							}
						}
						object value2 = gDEBreakthroughData.GetType().GetProperty(name2).GetValue(gDEBreakthroughData);
						if (value2 != null)
						{
							item.Require = JsonHelper.ToObject<Dictionary<string, float>>(value2.ToString());
						}
						list2.Add(item);
					}
					if (!_soldierMaxBreakthroughDictionary.ContainsKey(key))
					{
						_soldierMaxBreakthroughDictionary.Add(key, 0);
					}
					_soldierMaxBreakthroughDictionary[key] += list2.Count;
				}
			}
			return _breakthroughDataDictionary;
		}
		set
		{
			_breakthroughDataDictionary = value;
		}
	}

	public static Dictionary<string, int> SoldierMaxBreakthroughDictionary
	{
		get
		{
			if (_soldierMaxBreakthroughDictionary == null)
			{
				_soldierMaxBreakthroughDictionary = new Dictionary<string, int>();
				Dictionary<string, Dictionary<int, List<BreakthroughBonusAndDemand>>> breakthroughDataDictionary = BreakthroughDataDictionary;
			}
			return _soldierMaxBreakthroughDictionary;
		}
	}

	public SoldierBreakthroughData(string soldierId, int breakthroughLevel)
	{
		SoldierId = soldierId;
		BreakthroughLevel = breakthroughLevel;
		if (!SoldierMaxBreakthroughDictionary.ContainsKey(soldierId) || breakthroughLevel > SoldierMaxBreakthroughDictionary[soldierId])
		{
			return;
		}
		TotalFixBonus = new Dictionary<string, float>();
		TotalPercentBonus = new Dictionary<string, float>();
		SoldierBreakthroughData breakthroughData = GetBreakthroughData(soldierId, breakthroughLevel - 1);
		if (breakthroughData != null)
		{
			foreach (KeyValuePair<string, float> totalFixBonu in breakthroughData.TotalFixBonus)
			{
				TotalFixBonus.Add(totalFixBonu.Key, totalFixBonu.Value);
			}
			foreach (KeyValuePair<string, float> nextFixBonu in breakthroughData.NextFixBonus)
			{
				if (TotalFixBonus.ContainsKey(nextFixBonu.Key))
				{
					TotalFixBonus[nextFixBonu.Key] += nextFixBonu.Value;
				}
				else
				{
					TotalFixBonus.Add(nextFixBonu.Key, nextFixBonu.Value);
				}
			}
			foreach (KeyValuePair<string, float> totalPercentBonu in breakthroughData.TotalPercentBonus)
			{
				TotalPercentBonus.Add(totalPercentBonu.Key, totalPercentBonu.Value);
			}
			foreach (KeyValuePair<string, float> nextPercentBonu in breakthroughData.NextPercentBonus)
			{
				if (TotalPercentBonus.ContainsKey(nextPercentBonu.Key))
				{
					TotalPercentBonus[nextPercentBonu.Key] += nextPercentBonu.Value;
				}
				else
				{
					TotalPercentBonus.Add(nextPercentBonu.Key, nextPercentBonu.Value);
				}
			}
		}
		MajorLevel = 0;
		if (TotalFixBonus.TryGetValue("EA11", out var value))
		{
			MajorLevel += (int)value;
		}
		NextMajorLevel = MajorLevel + 1;
		if (!BreakthroughDataDictionary.ContainsKey(soldierId))
		{
			return;
		}
		MinorLevel = breakthroughLevel;
		for (int i = 0; i < MajorLevel && BreakthroughDataDictionary[soldierId].ContainsKey(i); i++)
		{
			MinorLevel -= BreakthroughDataDictionary[soldierId][i].Count;
		}
		if (BreakthroughDataDictionary[soldierId].TryGetValue(MajorLevel, out var value2) && value2.Count > MinorLevel)
		{
			BreakthroughBonusAndDemand breakthroughBonusAndDemand = value2[MinorLevel];
			NextFixBonus = breakthroughBonusAndDemand.FixBonus;
			NextPercentBonus = breakthroughBonusAndDemand.PercentBonus;
			NextRequire = breakthroughBonusAndDemand.Require;
			if (MinorLevel + 1 == value2.Count)
			{
				NextMinorLevel = 0;
			}
			else
			{
				NextMinorLevel = MinorLevel + 1;
			}
		}
	}

	public static SoldierBreakthroughData GetBreakthroughData(string soldierId, int breakthroughLevel)
	{
		if (breakthroughLevel < 0)
		{
			return null;
		}
		if (!SoldierMaxBreakthroughDictionary.ContainsKey(soldierId) || breakthroughLevel > SoldierMaxBreakthroughDictionary[soldierId])
		{
			return null;
		}
		if (_soldierBreakthroughDataDictionary == null)
		{
			_soldierBreakthroughDataDictionary = new Dictionary<string, Dictionary<int, SoldierBreakthroughData>>();
		}
		if (!_soldierBreakthroughDataDictionary.ContainsKey(soldierId))
		{
			_soldierBreakthroughDataDictionary.Add(soldierId, new Dictionary<int, SoldierBreakthroughData>());
		}
		if (!_soldierBreakthroughDataDictionary[soldierId].ContainsKey(breakthroughLevel))
		{
			SoldierBreakthroughData value = new SoldierBreakthroughData(soldierId, breakthroughLevel);
			_soldierBreakthroughDataDictionary[soldierId].Add(breakthroughLevel, value);
		}
		return _soldierBreakthroughDataDictionary[soldierId][breakthroughLevel];
	}

	public static List<BreakthroughBonusAndDemand> GetMinorInfoListForCurrentMajorLevel(string soldierId, int majorLevel)
	{
		if (!_breakthroughDataDictionary.TryGetValue(soldierId, out var value) || !value.TryGetValue(majorLevel, out var value2))
		{
			return null;
		}
		return value2;
	}
}
