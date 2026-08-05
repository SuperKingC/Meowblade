using System.Collections;
using System.Collections.Generic;
using GameDataEditor;
using HotFix.Sources.Base.Scripts.Helper;
using HotFix.Sources.Base.Sources.Scripts.GvG3Common.Manager;
using HotFix.Sources.Base.Sources.Scripts.GvG3Common.Model;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Model;
using HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Helper;
using Shift.Legion.Common.Helpers;
using Shift.Legion.Common.Managers;
using Shift.Legion.Common.Models;
using Shift.Legion.Helpers;

namespace HotFix.Sources.Base.Sources.Scripts.GvG3UI.Helper;

internal static class AmpConfigHelper
{
	private static AmpConfigModel _Configs;

	public static AmpConfigModel Configs => _Configs;

	public static IEnumerator InitCoroutine(string izId)
	{
		if (_Configs == null)
		{
			_Configs = new AmpConfigModel();
			yield return LoadAmplifierModelsCoroutine();
			LoadModifiers();
			LoadDefaultFormulas(izId);
			LoadAmplifiersSource();
		}
	}

	public static void Init()
	{
		if (_Configs != null)
		{
			return;
		}
		_Configs = new AmpConfigModel();
		IEnumerable<GDEGvGAmplifierConfigData> allItems = GDMgr.GetAllItems<GDEGvGAmplifierConfigData>();
		foreach (GDEGvGAmplifierConfigData item in allItems)
		{
			AmplifierModel amplifierModel = new AmplifierModel(item);
			if (amplifierModel.IsAmplifierTemplate)
			{
				_Configs.AmplifierTemplates_Dict.Add(item.Idx, amplifierModel);
			}
			else
			{
				_Configs.NormalAmplifiers_Dict.Add(item.Idx, amplifierModel);
			}
			_Configs.AllAmplifiers_Dict.Add(item.Key, amplifierModel);
		}
	}

	private static IEnumerator LoadAmplifierModelsCoroutine()
	{
		IEnumerable<GDEGvGAmplifierConfigData> configData = GDMgr.GetAllItems<GDEGvGAmplifierConfigData>();
		foreach (GDEGvGAmplifierConfigData data in configData)
		{
			AmplifierModel amplifier = new AmplifierModel(data);
			if (amplifier.IsAmplifierTemplate)
			{
				_Configs.AmplifierTemplates_Dict.Add(data.Idx, amplifier);
			}
			else
			{
				_Configs.NormalAmplifiers_Dict.Add(data.Idx, amplifier);
			}
			_Configs.AllAmplifiers_Dict.Add(data.Key, amplifier);
			if (LoadingHelper.ShouldYield_EnterIZ())
			{
				yield return null;
			}
		}
	}

	private static void LoadModifiers()
	{
		_Configs.Modifiers_List = "GvGAmplifierUsedModifiers".ToConfiguration<List<string>>();
	}

	private static void LoadDefaultFormulas(string izId)
	{
		string configKey = (WorldMapConfigHelper.IsBrawlFightEvent(izId) ? "GvGDefaultShowAmplifiers_VoidBrawl" : "GvGDefaultShowAmplifiers");
		Dictionary<string, string> dictionary = configKey.ToConfiguration<Dictionary<string, string>>();
		if (dictionary == null)
		{
			dictionary = new Dictionary<string, string>();
		}
		_Configs.AlwaysShowFormulasIds_HashSet = new HashSet<string>(dictionary.Keys);
		foreach (KeyValuePair<string, string> item in dictionary)
		{
			string key = item.Key;
			string unlockText = (string.IsNullOrEmpty(item.Value) ? "" : item.Value.ToLanguage());
			AmplifierFormulaModel amplifierFormulaModel = LoadFormulaConfigById(key, unlockText);
			_Configs.AlwaysShowFormulas_List.Add(amplifierFormulaModel);
			_Configs.Formulas_Dict.Add(key, amplifierFormulaModel);
		}
	}

	private static void LoadAmplifiersSource()
	{
		_Configs.AmplifierJumpData_List.AddRange("GvGAmplifierSourceJumpConfig".ToConfiguration<List<GvGAmplifierSourceJumpData>>());
	}

	public static bool CheckIsDefaultShowFormula(string formulaId)
	{
		return Configs.AlwaysShowFormulasIds_HashSet.Contains(formulaId);
	}

	private static AmplifierFormulaModel LoadFormulaConfigById(string formulaId, string unlockText = "")
	{
		GDEFormulaData gDEFormulaData = GDMgr.Get<GDEFormulaData>(formulaId);
		if (gDEFormulaData == null)
		{
			ILRuntimeDebug.LogError("[AmpConfigHelper] LoadFormulaConfigById 找不到 formulaId = " + formulaId + " 的增幅器配方");
			return null;
		}
		string text = "";
		using (Dictionary<string, int>.KeyCollection.Enumerator enumerator = JsonHelper.ToObject<Dictionary<string, int>>(gDEFormulaData.Output).Keys.GetEnumerator())
		{
			if (enumerator.MoveNext())
			{
				string current = enumerator.Current;
				text = current;
			}
		}
		Dictionary<string, int> dictionary = JsonHelper.ToObject<Dictionary<string, int>>(gDEFormulaData.Input);
		Dictionary<string, int> dictionary2 = new Dictionary<string, int>();
		string reelItemId = string.Empty;
		foreach (KeyValuePair<string, int> item in dictionary)
		{
			string key = item.Key;
			if (Singleton<GvGStoreHouseManager>.Instance.IsFormulaScrollItem(key))
			{
				reelItemId = key;
			}
			else
			{
				dictionary2.Add(item.Key, item.Value);
			}
		}
		return new AmplifierFormulaModel
		{
			Data = gDEFormulaData,
			Input_Dict = dictionary2,
			OutputAmpId = text,
			OutputAmplifier = _Configs.TryGetAmplifier(text),
			ReelItemId = reelItemId
		};
	}

	public static AmplifierFormulaModel TryGetAmplifierFormula(string formulaId)
	{
		if (string.IsNullOrEmpty(formulaId))
		{
			return null;
		}
		if (Configs.Formulas_Dict.TryGetValue(formulaId, out var value))
		{
			return value;
		}
		value = LoadFormulaConfigById(formulaId);
		_Configs.Formulas_Dict.Add(formulaId, value);
		return value;
	}

	public static List<AmplifierModel> FilterAmplifiers(List<AmplifierModel> list, int quality = 0, eRace race = eRace.全种族, string soldierId = null, string modifier = null)
	{
		List<AmplifierModel> list2 = new List<AmplifierModel>();
		foreach (AmplifierModel item in list)
		{
			bool flag = item.Quality == quality || quality == 0;
			flag &= item.AffectedRace == race || item.AffectedRace == eRace.全种族 || race == eRace.全种族;
			flag &= item.AffectedSoldier == soldierId || string.IsNullOrEmpty(item.AffectedSoldier) || string.IsNullOrEmpty(soldierId);
			if (flag & (string.IsNullOrEmpty(modifier) || item.Props.ContainsKey(modifier)))
			{
				list2.Add(item);
			}
		}
		return list2;
	}

	public static List<int> FilterAmplifiers(List<int> list, int quality = 0, eRace race = eRace.全种族, string soldierId = null, string modifier = null)
	{
		List<int> list2 = new List<int>();
		foreach (int item in list)
		{
			AmplifierModel amplifierModel = OemMissionAmplifierConfigHelper.GetOemMissionAmplifier(item).AmplifierModel;
			bool flag = amplifierModel.Quality == quality || quality == 0;
			flag &= amplifierModel.AffectedRace == race || amplifierModel.AffectedRace == eRace.全种族 || race == eRace.全种族;
			flag &= amplifierModel.AffectedSoldier == soldierId || string.IsNullOrEmpty(amplifierModel.AffectedSoldier) || string.IsNullOrEmpty(soldierId);
			if (flag & (string.IsNullOrEmpty(modifier) || amplifierModel.Props.ContainsKey(modifier)))
			{
				list2.Add(item);
			}
		}
		return list2;
	}

	public static List<AmplifierModel> FilterAmplifiersByType(List<AmplifierModel> list, eAmplifierType type)
	{
		List<AmplifierModel> list2 = new List<AmplifierModel>();
		foreach (AmplifierModel item in list)
		{
			if (item.Type == type)
			{
				list2.Add(item);
			}
		}
		return list2;
	}

	public static List<AmplifierModel> FilterAmplifiersBySoldierIds(List<AmplifierModel> list, List<string> soldierIds, out List<AmplifierModel> others)
	{
		others = new List<AmplifierModel>();
		HashSet<string> hashSet = new HashSet<string>(soldierIds);
		HashSet<eRace> hashSet2 = new HashSet<eRace>();
		foreach (string soldierId in soldierIds)
		{
			string faction = GDMgr.Get<GDESoldierData>(soldierId).Faction;
			eRace item = RaceHelper.FactionToRaceEnum(faction);
			if (!hashSet2.Contains(item))
			{
				hashSet2.Add(item);
			}
		}
		List<AmplifierModel> list2 = new List<AmplifierModel>();
		foreach (AmplifierModel item2 in list)
		{
			bool flag = hashSet2.Contains(item2.AffectedRace) || item2.AffectedRace == eRace.全种族;
			if (flag & (hashSet.Contains(item2.AffectedSoldier) || string.IsNullOrEmpty(item2.AffectedSoldier)))
			{
				list2.Add(item2);
			}
			else
			{
				others.Add(item2);
			}
		}
		return list2;
	}

	public static List<AmplifierFormulaModel> FilterFormulaByRarity(List<AmplifierFormulaModel> list, int rarity)
	{
		List<AmplifierFormulaModel> list2 = new List<AmplifierFormulaModel>();
		foreach (AmplifierFormulaModel item in list)
		{
			if (item.Rarity == rarity)
			{
				list2.Add(item);
			}
		}
		return list2;
	}

	public static List<AmplifierFormulaModel> FilterFormulaByOutputType(List<AmplifierFormulaModel> list, eAmplifierType type)
	{
		List<AmplifierFormulaModel> list2 = new List<AmplifierFormulaModel>();
		foreach (AmplifierFormulaModel item in list)
		{
			if (item.OutputAmplifier.Type == type)
			{
				list2.Add(item);
			}
		}
		return list2;
	}
}
