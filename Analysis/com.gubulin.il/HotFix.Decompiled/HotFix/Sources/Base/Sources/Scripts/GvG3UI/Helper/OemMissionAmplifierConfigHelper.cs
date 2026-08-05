using System;
using System.Collections.Generic;
using GameDataEditor;
using HotFix.Sources.Base.Scripts.Helper;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Model;
using Shift.Legion.Common.Managers;
using Shift.Legion.GvG.Common.Enums;
using Shift.Legion.Helpers;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace HotFix.Sources.Base.Sources.Scripts.GvG3UI.Helper;

internal static class OemMissionAmplifierConfigHelper
{
	private static readonly Dictionary<string, GDEGvGMode3CampMissionData> _oemMissions = new Dictionary<string, GDEGvGMode3CampMissionData>(100);

	private static Dictionary<string, string> _ampFormulaConfig = new Dictionary<string, string>(415);

	private static readonly Dictionary<int, OemMissionAmplifier> MissionAmplifiers = new Dictionary<int, OemMissionAmplifier>(415);

	public const string EMPTY_VALUE = "----";

	private static int _formulaOemTaskMax = -1;

	public static Dictionary<string, GDEGvGMode3CampMissionData> OemMissionConfig
	{
		get
		{
			if (_oemMissions == null || _oemMissions.Count <= 0)
			{
				LoadMissionsData();
			}
			return _oemMissions;
			static void LoadMissionsData()
			{
				foreach (GDEGvGMode3CampMissionData allItem in GDMgr.GetAllItems<GDEGvGMode3CampMissionData>())
				{
					eGvGMode3CampMissionType eGvGMode3CampMissionType = (eGvGMode3CampMissionType)Enum.Parse(typeof(eGvGMode3CampMissionType), allItem.Type);
					if (eGvGMode3CampMissionType == eGvGMode3CampMissionType.OEM || eGvGMode3CampMissionType == eGvGMode3CampMissionType.FormulaOEM)
					{
						_oemMissions.Add(allItem.Key, allItem);
					}
				}
			}
		}
	}

	public static Dictionary<string, string> AmpFormulaConfig
	{
		get
		{
			if (_ampFormulaConfig.Count <= 0)
			{
				LoadAmpFormulaConfig();
			}
			return _ampFormulaConfig;
			static void LoadAmpFormulaConfig()
			{
				//IL_0006: Unknown result type (might be due to invalid IL or missing references)
				//IL_000b: Unknown result type (might be due to invalid IL or missing references)
				TextAsset val = Addressables.LoadAssetAsync<TextAsset>((object)"GvGMode3_AmpFormula.bytes").WaitForCompletion();
				_ampFormulaConfig = new Dictionary<string, string>(JsonHelper.ToObject<Dictionary<string, string>>(val.text));
			}
		}
	}

	public static int FormulaOemTaskMax
	{
		get
		{
			if (_formulaOemTaskMax < 0)
			{
				_formulaOemTaskMax = "GvGFormulaOEMTaskTotalCountLimit".ToConfiguration<int>();
			}
			return _formulaOemTaskMax;
		}
	}

	public static OemMissionAmplifier GetOemMissionAmplifier(int ampIdx)
	{
		if (MissionAmplifiers.TryGetValue(ampIdx, out var value))
		{
			return value;
		}
		AmpFormulaConfig.TryGetValue(ampIdx.ToString(), out var value2);
		MissionAmplifiers.Add(ampIdx, new OemMissionAmplifier(ampIdx, value2));
		return MissionAmplifiers[ampIdx];
	}

	public static float GetAmpForgeHighQualityRate(int ampIdx)
	{
		AmplifierModel amplifierModel = AmpConfigHelper.Configs.TryGetNormalAmplifier(ampIdx);
		string key = amplifierModel.Quality.ToString();
		float value;
		return (!ObserverConfigHelper.DefaultsConfig.AmpForgeHighQualityRate.TryGetValue(key, out value)) ? 0f : value;
	}
}
