using System;
using GameMaths;
using Shift.Legion.Common.Managers;
using Shift.Legion.Common.Models;
using Shift.Legion.Common.Services;

public sealed class BuildingSystem : BaseExecuteSystem
{
	private static int CheckingCycle = 50;

	public BuildingSystem(Contexts contexts)
		: base(contexts)
	{
		CheckingCycle = Mathf.RoundToInt(1f / contexts.Service<ITimeService>().FixedDeltaTime());
	}

	public override void Execute()
	{
		if (_contexts.Service<BaseSceneService>().IsSceneBattleField || !_contexts.gameState.hasUser || !_contexts.gameState.isDataReady || GameManagers.Instance == null || !GameManagers.Instance.Initialized)
		{
			return;
		}
		GameManagers instance = GameManagers.Instance;
		if (instance.BuildingManager.ConstructingBuildings.Count <= 0 || _contexts.input.tick.value % CheckingCycle != 0)
		{
			return;
		}
		DateTimeOffset dateTimeOffset = DateTimeHelper.ParseTimeStamp((int)GameController.Instance.GetServerTime());
		for (int i = 0; i < instance.BuildingManager.ConstructingBuildings.Count; i++)
		{
			Building building = instance.BuildingManager.ConstructingBuildings[i];
			if (building.ConstructingConfig.EndTime <= dateTimeOffset.Ticks || building.ConstructingConfig.EndTime - building.ConstructingConfig.StartTime <= 1)
			{
				building.ConstructingComplete();
			}
		}
	}
}
