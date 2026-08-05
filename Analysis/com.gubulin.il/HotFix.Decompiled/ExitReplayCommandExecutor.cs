using System.Collections.Generic;
using System.Linq;
using Shift.Legion.Common.Enums;
using Shift.Legion.Common.Managers;
using Shift.Legion.Common.Models;
using Shift.Legion.Common.Services;

public class ExitReplayCommandExecutor
{
	private readonly Contexts _contexts;

	public ExitReplayCommandExecutor(Contexts contexts)
	{
		_contexts = contexts;
	}

	public void Prepare()
	{
	}

	public void Execute()
	{
		_contexts.Service<ReplayPlayerService>().Stop();
		string value = GameManagers.Instance.UserArchiveManager.GetCurrentLevelId();
		if (string.IsNullOrEmpty(value))
		{
			List<Region> list = WorldMapManager.Regions.Values.ToList();
			foreach (Region item in list)
			{
				RegionStatus regionStatus = item.Status(GameManagers.Instance);
				if (regionStatus != RegionStatus.Locked && regionStatus != RegionStatus.Occupied)
				{
					value = item.CurrentLevelId(GameManagers.Instance);
				}
			}
		}
		CommandFactory.CreateOpenSceneCommand("BattleField", new SceneBattleFieldArguments(new Dictionary<string, object>
		{
			{ "LevelId", value },
			{ "Asset", "Prefabs/BattleField" },
			{ "ForceCloseOtherUi", true },
			{ "TaskCompletionSource", null }
		}));
	}
}
