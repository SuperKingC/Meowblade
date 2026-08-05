using Shift.Legion.Common.Managers;

namespace Shift.Legion.Common.Models;

public class MoltenCoreTechnologyEffectsConfig : WorkshopTechnologyEffectsConfig
{
	public MoltenCoreTechnologyEffectsConfig(GameManagers gameManagers, string buildingType)
		: base(gameManagers, buildingType)
	{
		ModifierManager modifierManager = gameManagers.ModifierManager;
		string[] subKeys = new string[1] { "BuildingType" + buildingType };
		base.CostFactor = 1f + modifierManager.GetPercentFloatPayload("ProduceCost", subKeys);
		base.CostFix = modifierManager.GetFixedFloatPayload("ProduceCost", subKeys);
		base.ProductionFactor = 1f + modifierManager.GetPercentFloatPayload("SingleProductionAmount", subKeys);
		base.ProductionFix = modifierManager.GetFixedFloatPayload("SingleProductionAmount", subKeys);
		base.ProductionEfficiency = 1f + modifierManager.GetPercentFloatPayload("ProductionEfficiency", subKeys);
		base.ProdTimeFix = modifierManager.GetFixedFloatPayload("ProducingTime", subKeys);
	}
}
