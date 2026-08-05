using System.Collections.Generic;
using Entitas;
using Shift.Legion.ClientApi.Protocol;
using Shift.Legion.Common.Enums;
using Shift.Legion.Common.Models;

public class CommandFactory
{
	private static CommandEntity CreateEntity()
	{
		return ((Context<CommandEntity>)Contexts.sharedInstance.command).CreateEntity();
	}

	private static CommandEntity CreateEntity(Contexts contexts)
	{
		return ((Context<CommandEntity>)contexts.command).CreateEntity();
	}

	public static CommandEntity CreateAddEnterMarkToUnitsCommand(Team team, int portalId)
	{
		CommandEntity commandEntity = CreateEntity();
		commandEntity.ReplaceAddEnterMarkToUnitsCommand(team, portalId);
		return commandEntity;
	}

	public static CommandEntity CreateAddEnterMarkToUnitsCommand(Contexts contexts, Team team, int portalId)
	{
		CommandEntity commandEntity = CreateEntity(contexts);
		commandEntity.ReplaceAddEnterMarkToUnitsCommand(team, portalId);
		return commandEntity;
	}

	public static CommandEntity CreateClearAllUnitsCommand()
	{
		CommandEntity commandEntity = CreateEntity();
		commandEntity.isClearAllUnitsCommand = true;
		return commandEntity;
	}

	public static CommandEntity CreateClearAllUnitsCommand(Contexts contexts)
	{
		CommandEntity commandEntity = CreateEntity(contexts);
		commandEntity.isClearAllUnitsCommand = true;
		return commandEntity;
	}

	public static CommandEntity CreateExitReplayCommand()
	{
		CommandEntity commandEntity = CreateEntity();
		commandEntity.isExitReplayCommand = true;
		return commandEntity;
	}

	public static CommandEntity CreateExitReplayCommand(Contexts contexts)
	{
		CommandEntity commandEntity = CreateEntity(contexts);
		commandEntity.isExitReplayCommand = true;
		return commandEntity;
	}

	public static CommandEntity CreatePauseReplayCommand()
	{
		CommandEntity commandEntity = CreateEntity();
		commandEntity.isPauseReplayCommand = true;
		return commandEntity;
	}

	public static CommandEntity CreatePauseReplayCommand(Contexts contexts)
	{
		CommandEntity commandEntity = CreateEntity(contexts);
		commandEntity.isPauseReplayCommand = true;
		return commandEntity;
	}

	public static CommandEntity CreatePlayReplayCommand()
	{
		CommandEntity commandEntity = CreateEntity();
		commandEntity.isPlayReplayCommand = true;
		return commandEntity;
	}

	public static CommandEntity CreatePlayReplayCommand(Contexts contexts)
	{
		CommandEntity commandEntity = CreateEntity(contexts);
		commandEntity.isPlayReplayCommand = true;
		return commandEntity;
	}

	public static CommandEntity CreateRetreatCommand()
	{
		CommandEntity commandEntity = CreateEntity();
		commandEntity.isRetreatCommand = true;
		return commandEntity;
	}

	public static CommandEntity CreateRetreatCommand(Contexts contexts)
	{
		CommandEntity commandEntity = CreateEntity(contexts);
		commandEntity.isRetreatCommand = true;
		return commandEntity;
	}

	public static CommandEntity CreateStartBattleCommand(string value)
	{
		CommandEntity commandEntity = CreateEntity();
		commandEntity.ReplaceStartBattleCommand(value);
		return commandEntity;
	}

	public static CommandEntity CreateStartBattleCommand(Contexts contexts, string value)
	{
		CommandEntity commandEntity = CreateEntity(contexts);
		commandEntity.ReplaceStartBattleCommand(value);
		return commandEntity;
	}

	public static CommandEntity CreateCalcOfflineBonusCommand()
	{
		CommandEntity commandEntity = CreateEntity();
		commandEntity.isCalcOfflineBonusCommand = true;
		return commandEntity;
	}

	public static CommandEntity CreateCalcOfflineBonusCommand(Contexts contexts)
	{
		CommandEntity commandEntity = CreateEntity(contexts);
		commandEntity.isCalcOfflineBonusCommand = true;
		return commandEntity;
	}

	public static CommandEntity CreateChangeCurrentFormationUnitCommand(int portalId, string unitId, string context, string subContext)
	{
		CommandEntity commandEntity = CreateEntity();
		commandEntity.ReplaceChangeCurrentFormationUnitCommand(portalId, unitId, context, subContext);
		return commandEntity;
	}

	public static CommandEntity CreateChangeCurrentFormationUnitCommand(Contexts contexts, int portalId, string unitId, string context, string subContext)
	{
		CommandEntity commandEntity = CreateEntity(contexts);
		commandEntity.ReplaceChangeCurrentFormationUnitCommand(portalId, unitId, context, subContext);
		return commandEntity;
	}

	public static CommandEntity CreateCloseLoadingUiCommand()
	{
		CommandEntity commandEntity = CreateEntity();
		commandEntity.isCloseLoadingUiCommand = true;
		return commandEntity;
	}

	public static CommandEntity CreateCloseLoadingUiCommand(Contexts contexts)
	{
		CommandEntity commandEntity = CreateEntity(contexts);
		commandEntity.isCloseLoadingUiCommand = true;
		return commandEntity;
	}

	public static CommandEntity CreateEnterGameCommand()
	{
		CommandEntity commandEntity = CreateEntity();
		commandEntity.isEnterGameCommand = true;
		return commandEntity;
	}

	public static CommandEntity CreateEnterGameCommand(Contexts contexts)
	{
		CommandEntity commandEntity = CreateEntity(contexts);
		commandEntity.isEnterGameCommand = true;
		return commandEntity;
	}

	public static CommandEntity CreateGameDataLoadedCommand(byte[] data)
	{
		CommandEntity commandEntity = CreateEntity();
		commandEntity.ReplaceGameDataLoadedCommand(data);
		return commandEntity;
	}

	public static CommandEntity CreateGameDataLoadedCommand(Contexts contexts, byte[] data)
	{
		CommandEntity commandEntity = CreateEntity(contexts);
		commandEntity.ReplaceGameDataLoadedCommand(data);
		return commandEntity;
	}

	public static CommandEntity CreateGameUserDataLoadedCommand(int userId, Dictionary<string, UserData> data)
	{
		CommandEntity commandEntity = CreateEntity();
		commandEntity.ReplaceGameUserDataLoadedCommand(userId, data);
		return commandEntity;
	}

	public static CommandEntity CreateGameUserDataLoadedCommand(Contexts contexts, int userId, Dictionary<string, UserData> data)
	{
		CommandEntity commandEntity = CreateEntity(contexts);
		commandEntity.ReplaceGameUserDataLoadedCommand(userId, data);
		return commandEntity;
	}

	public static CommandEntity CreateLoginCompleteCommand(User user)
	{
		CommandEntity commandEntity = CreateEntity();
		commandEntity.ReplaceLoginCompleteCommand(user);
		return commandEntity;
	}

	public static CommandEntity CreateLoginCompleteCommand(Contexts contexts, User user)
	{
		CommandEntity commandEntity = CreateEntity(contexts);
		commandEntity.ReplaceLoginCompleteCommand(user);
		return commandEntity;
	}

	public static CommandEntity CreateOpenLoadingUiCommand(float minTime)
	{
		CommandEntity commandEntity = CreateEntity();
		commandEntity.ReplaceOpenLoadingUiCommand(minTime);
		return commandEntity;
	}

	public static CommandEntity CreateOpenLoadingUiCommand(Contexts contexts, float minTime)
	{
		CommandEntity commandEntity = CreateEntity(contexts);
		commandEntity.ReplaceOpenLoadingUiCommand(minTime);
		return commandEntity;
	}

	public static CommandEntity CreateOpenSceneCommand(string scene, SceneArguments arguments)
	{
		CommandEntity commandEntity = CreateEntity();
		commandEntity.ReplaceOpenSceneCommand(scene, arguments);
		return commandEntity;
	}

	public static CommandEntity CreateOpenSceneCommand(Contexts contexts, string scene, SceneArguments arguments)
	{
		CommandEntity commandEntity = CreateEntity(contexts);
		commandEntity.ReplaceOpenSceneCommand(scene, arguments);
		return commandEntity;
	}

	public static CommandEntity CreateTakeItemsCommand(List<Bonus> items)
	{
		CommandEntity commandEntity = CreateEntity();
		commandEntity.ReplaceTakeItemsCommand(items);
		return commandEntity;
	}

	public static CommandEntity CreateTakeItemsCommand(Contexts contexts, List<Bonus> items)
	{
		CommandEntity commandEntity = CreateEntity(contexts);
		commandEntity.ReplaceTakeItemsCommand(items);
		return commandEntity;
	}

	public static CommandEntity CreateUnlockSoldierCommand(string soldierId, List<string> unlockedProduct)
	{
		CommandEntity commandEntity = CreateEntity();
		commandEntity.ReplaceUnlockSoldierCommand(soldierId, unlockedProduct);
		return commandEntity;
	}

	public static CommandEntity CreateUnlockSoldierCommand(Contexts contexts, string soldierId, List<string> unlockedProduct)
	{
		CommandEntity commandEntity = CreateEntity(contexts);
		commandEntity.ReplaceUnlockSoldierCommand(soldierId, unlockedProduct);
		return commandEntity;
	}
}
