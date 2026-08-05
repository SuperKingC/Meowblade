using System;
using System.Collections.Generic;
using System.Linq;
using HotFix.Sources.Base.Scripts.Helper;
using HotFix.Sources.Base.Sources.Scripts.GvG3.GvG3UI.Model.BattlePass;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Manager;
using Shift.Legion.Common.Helpers;

namespace HotFix.Sources.Base.Sources.Scripts.GvG3.GvG3UI.Helper;

public static class GvG3InsuranceHelper
{
	private const string GVG3_INSURANCE_ISLAND_CONFIG = "GvG3InsuranceIslandConfig";

	private const string GVG3_INSURANCE_CLONE_NAME = "GvGMode3_Insurance_CloneName";

	private static Dictionary<string, GvG3InsuranceConfig> _insuranceConfigs;

	private static Dictionary<int, int> _insuranceIslands;

	private static string _cloneName;

	public static string TryStripInsuranceSuffix(string shipId, out bool isInsuranceClone)
	{
		if (string.IsNullOrEmpty(shipId))
		{
			isInsuranceClone = false;
			return shipId;
		}
		isInsuranceClone = shipId.Contains("_Insurance");
		return isInsuranceClone ? shipId.Split(new string[1] { "_Insurance" }, StringSplitOptions.None)[0] : shipId;
	}

	public static string GetInsuranceShipName()
	{
		if (_cloneName != null)
		{
			return _cloneName;
		}
		_cloneName = "GvGMode3_Insurance_CloneName".ToLanguage();
		return _cloneName;
	}

	public static int GetInsuranceIslandId(int curProgress)
	{
		InsureInsuranceIslands();
		return FindCurProgressInsuranceIsland(curProgress);
	}

	private static int FindCurProgressInsuranceIsland(int curProgress)
	{
		if (!_insuranceIslands.TryGetValue(curProgress, out var value))
		{
			List<int> list = _insuranceIslands.Values.ToList();
			value = list[list.Count - 1];
			_insuranceIslands[curProgress] = value;
		}
		return value;
	}

	private static void InsureInsuranceIslands()
	{
		if (_insuranceIslands != null)
		{
			return;
		}
		InsureInsuranceConfig();
		_insuranceIslands = new Dictionary<int, int>();
		GvG3InsuranceConfig gvG3InsuranceConfig = _insuranceConfigs[Singleton<GvGMode3RoomManager>.Instance.ObserverRecord.IZConfigId];
		int obCampId = Singleton<GvGMode3RoomManager>.Instance.ObserverRecord.ObCampId;
		foreach (KeyValuePair<string, InsuranceIslandConfig> island in gvG3InsuranceConfig.Islands)
		{
			foreach (InsuranceCondition condition in island.Value.Conditions)
			{
				if (condition.Camp == obCampId)
				{
					_insuranceIslands[condition.Progress] = int.Parse(island.Key);
					break;
				}
			}
		}
	}

	public static bool IsInsuranceIsland(int islandId)
	{
		InsureInsuranceConfig();
		GvG3InsuranceConfig gvG3InsuranceConfig = _insuranceConfigs[Singleton<GvGMode3RoomManager>.Instance.ObserverRecord.IZConfigId];
		return gvG3InsuranceConfig.Islands.ContainsKey(islandId.ToString());
	}

	private static void InsureInsuranceConfig()
	{
		if (_insuranceConfigs == null)
		{
			_insuranceConfigs = "GvG3InsuranceIslandConfig".ToConfiguration<Dictionary<string, GvG3InsuranceConfig>>();
		}
	}
}
