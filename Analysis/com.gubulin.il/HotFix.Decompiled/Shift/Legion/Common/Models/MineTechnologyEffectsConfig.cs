using System.Collections.Generic;
using Shift.Legion.Common.Enums;
using Shift.Legion.Common.Managers;

namespace Shift.Legion.Common.Models;

public class MineTechnologyEffectsConfig : WorkshopTechnologyEffectsConfig
{
	public Dictionary<string, int> NormalProductStates { get; set; } = new Dictionary<string, int>();

	public Dictionary<string, int> AddOnProductStates { get; set; } = new Dictionary<string, int>();

	public float BaseExtraProdRate { get; set; } = 0f;

	public float BaseAddOnRate { get; set; } = 0f;

	public float NormalAddOnThreshold { get; set; } = 0f;

	public float TreasureAddOnThreshold { get; set; } = 0f;

	public MineTechnologyEffectsConfig(GameManagers gameManagers, string buildingType)
		: base(gameManagers, buildingType)
	{
		ModifierManager modifierManager = gameManagers.ModifierManager;
		string[] subKeys = new string[1] { "BuildingType" + buildingType };
		WorkShop workShop = gameManagers.BuildingManager.GetBuildingByType(buildingType) as WorkShop;
		BaseAddOnRate = workShop?.AddOnRate ?? 0f;
		BaseExtraProdRate = workShop?.ExtraProdRate ?? 0f;
		TreasureAddOnThreshold = BaseAddOnRate * (1f + modifierManager.GetPercentFloatPayload("TreasureFinder", subKeys)) + modifierManager.GetFixedFloatPayload("TreasureFinder", subKeys);
		NormalAddOnThreshold = BaseExtraProdRate * (1f + modifierManager.GetPercentFloatPayload("StubornWorker", subKeys)) + modifierManager.GetFixedFloatPayload("StubornWorker", subKeys);
		AddOnProductStates = workShop.GetProductStates(false, ProductFilter.AddOn);
		NormalProductStates = workShop.GetProductStates(true, ProductFilter.Normal);
	}
}
