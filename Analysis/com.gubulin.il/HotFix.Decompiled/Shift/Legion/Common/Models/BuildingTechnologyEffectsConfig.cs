using Shift.Legion.Common.Managers;

namespace Shift.Legion.Common.Models;

public class BuildingTechnologyEffectsConfig
{
	public string BuildingType;

	public GameManagers GameManagers;

	public float BurstThreshold { get; set; } = 0f;

	public float LazyThreshold { get; set; } = 0f;

	public int LazyDuration { get; set; } = 0;

	public int BurstDuration { get; set; } = 0;

	public BuildingTechnologyEffectsConfig(GameManagers gameManagers, string buildingType)
	{
		GameManagers = gameManagers;
		BuildingType = buildingType;
		BurstThreshold = gameManagers.UserArchiveManager.GetBaseDiligentWorkerRate() * (1f + gameManagers.ModifierManager.GetPercentFloatPayload("DiligentWorker")) + gameManagers.ModifierManager.GetFixedFloatPayload("DiligentWorker");
		LazyThreshold = gameManagers.UserArchiveManager.GetBaseLazyWorkerRate() * (1f + gameManagers.ModifierManager.GetPercentFloatPayload("LazyWorker")) + gameManagers.ModifierManager.GetFixedFloatPayload("LazyWorker");
		BurstDuration = (int)(gameManagers.UserArchiveManager.GetBaseDiligentWorkerDuration() * (1f + gameManagers.ModifierManager.GetPercentFloatPayload("DiligentWorkerDuration")) + gameManagers.ModifierManager.GetFixedFloatPayload("DiligentWorkerDuration"));
		LazyDuration = (int)(gameManagers.UserArchiveManager.GetBaseLazyWorkerDuration() * (1f + gameManagers.ModifierManager.GetPercentFloatPayload("LazyWorkerDuration")) + gameManagers.ModifierManager.GetFixedFloatPayload("LazyWorkerDuration"));
	}
}
