using System;
using System.Collections.Generic;
using GameDataEditor;
using GameMaths;
using HotFix.Sources.Base.Scripts.Helper;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Model;
using HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Model;
using Shift.Legion.Common.Managers;
using Shift.Legion.Helpers;

namespace HotFix.Sources.Base.Sources.Scripts.GvG3UI.Helper;

internal static class ShipConfigHelper
{
	private static Dictionary<int, ShipConfigModel> ShipType_Dict = new Dictionary<int, ShipConfigModel>();

	private static Dictionary<string, ShipSkinConfigModel> Skin_Dict;

	public static ShipConfigModel GetByShipRaceType(int type)
	{
		if (!ShipType_Dict.ContainsKey(type))
		{
			string text = $"GVGSHIP_RACE{type}";
			GDEConfigurationData gDEConfigurationData = GDMgr.Get<GDEConfigurationData>(text);
			if (gDEConfigurationData == null)
			{
				ILRuntimeDebug.LogError("[ShipConfigHelper] GetByShipRaceType 找不到 id:" + text + " 的配置");
				return null;
			}
			ShipConfigModel shipConfigModel = JsonHelper.ToObject<ShipConfigModel>(gDEConfigurationData.Config);
			shipConfigModel.DefaultName = shipConfigModel.DefaultName.ToLanguage();
			ShipType_Dict.Add(type, shipConfigModel);
		}
		return ShipType_Dict[type];
	}

	public static ShipSkinConfigModel GetSkinById(int id)
	{
		if (Skin_Dict == null)
		{
			Skin_Dict = "GVGSHIP_SKINS".ToConfiguration<Dictionary<string, ShipSkinConfigModel>>();
		}
		if (Skin_Dict.TryGetValue($"{id}", out var value))
		{
			return value;
		}
		ILRuntimeDebug.LogError($"[ShipConfigHelper] GetSkinById 找不到皮肤 id={id}");
		return null;
	}

	public static int GetBuildTime(int shipRace, int assignedWorkers = 1, float efficiency = 1f)
	{
		int buildTime = GetByShipRaceType(shipRace).BuildTime;
		float num = Mathf.Min((float)buildTime / Mathf.Pow(1.2f, (float)(assignedWorkers - 1)), (float)(buildTime - (assignedWorkers - 1)));
		int num2 = Mathf.RoundToInt(num * efficiency);
		if (num2 < 0)
		{
			num2 = 0;
		}
		return num2;
	}

	public static string GetCollectingStockModelItemId(string miningConfigStr)
	{
		string key = miningConfigStr.Split('#')[0];
		return GDMgr.Get<GDEProductData>(key).ItemId;
	}

	public static MiningState GetMiningStateByConfigStr(string configStr)
	{
		string[] array = configStr.Split(new string[1] { "##" }, StringSplitOptions.None);
		if (array.Length != 2)
		{
			return MiningState.Mining;
		}
		return (MiningState)int.Parse(array[1]);
	}
}
