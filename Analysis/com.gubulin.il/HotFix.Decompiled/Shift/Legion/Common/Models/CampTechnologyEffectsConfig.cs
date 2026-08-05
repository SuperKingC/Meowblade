using Shift.Legion.Common.Managers;

namespace Shift.Legion.Common.Models;

public class CampTechnologyEffectsConfig : BuildingTechnologyEffectsConfig
{
	public float FreeProdThreshold { get; set; } = 0f;

	public float ProdTimeFix { get; set; } = 0f;

	public float ProdEfficiency { get; set; } = 1f;

	public float CloneSoldierThreshold { get; set; } = 0f;

	public float CostFix { get; set; } = 0f;

	public float CostFactor { get; set; } = 0f;

	public CampTechnologyEffectsConfig(GameManagers gameManagers, string buildingType)
		: base(gameManagers, buildingType)
	{
		ModifierManager modifierManager = gameManagers.ModifierManager;
		string[] subKeys = new string[1] { "BuildingType" + buildingType };
		CostFactor = 1f + modifierManager.GetPercentFloatPayload("ProduceCost", subKeys);
		CostFix = modifierManager.GetFixedFloatPayload("ProduceCost", subKeys);
		CloneSoldierThreshold = 0f * (1f + modifierManager.GetPercentFloatPayload("CloneSoldier", subKeys)) + modifierManager.GetFixedFloatPayload("CloneSoldier", subKeys);
		ProdEfficiency = 1f + modifierManager.GetPercentFloatPayload("ProductionEfficiency", subKeys);
		ProdTimeFix = modifierManager.GetFixedFloatPayload("ProducingTime", subKeys);
		FreeProdThreshold = 0f * (1f + modifierManager.GetPercentFloatPayload("FreeProduceChance", subKeys)) + modifierManager.GetFixedFloatPayload("FreeProduceChance", subKeys);
	}
}
