using Entitas;

public sealed class CommandMatcher
{
	private static IMatcher<CommandEntity> _matcherAddEnterMarkToUnitsCommand;

	private static IMatcher<CommandEntity> _matcherCalcOfflineBonusCommand;

	private static IMatcher<CommandEntity> _matcherChangeCurrentFormationUnitCommand;

	private static IMatcher<CommandEntity> _matcherClearAllUnitsCommand;

	private static IMatcher<CommandEntity> _matcherCloseLoadingUiCommand;

	private static IMatcher<CommandEntity> _matcherCommandDelay;

	private static IMatcher<CommandEntity> _matcherCommandDestroyedListener;

	private static IMatcher<CommandEntity> _matcherDestroyed;

	private static IMatcher<CommandEntity> _matcherEnterGameCommand;

	private static IMatcher<CommandEntity> _matcherExitReplayCommand;

	private static IMatcher<CommandEntity> _matcherGameDataLoadedCommand;

	private static IMatcher<CommandEntity> _matcherGameUserDataLoadedCommand;

	private static IMatcher<CommandEntity> _matcherLoginCompleteCommand;

	private static IMatcher<CommandEntity> _matcherOpenLoadingUiCommand;

	private static IMatcher<CommandEntity> _matcherOpenSceneCommand;

	private static IMatcher<CommandEntity> _matcherPauseReplayCommand;

	private static IMatcher<CommandEntity> _matcherPlayReplayCommand;

	private static IMatcher<CommandEntity> _matcherRetreatCommand;

	private static IMatcher<CommandEntity> _matcherStartBattleCommand;

	private static IMatcher<CommandEntity> _matcherTakeItemsCommand;

	private static IMatcher<CommandEntity> _matcherUnlockSoldierCommand;

	public static IMatcher<CommandEntity> AddEnterMarkToUnitsCommand
	{
		get
		{
			if (_matcherAddEnterMarkToUnitsCommand == null)
			{
				Matcher<CommandEntity> val = (Matcher<CommandEntity>)(object)Matcher<CommandEntity>.AllOf(new int[1]);
				val.componentNames = CommandComponentsLookup.componentNames;
				_matcherAddEnterMarkToUnitsCommand = (IMatcher<CommandEntity>)(object)val;
			}
			return _matcherAddEnterMarkToUnitsCommand;
		}
	}

	public static IMatcher<CommandEntity> CalcOfflineBonusCommand
	{
		get
		{
			if (_matcherCalcOfflineBonusCommand == null)
			{
				Matcher<CommandEntity> val = (Matcher<CommandEntity>)(object)Matcher<CommandEntity>.AllOf(new int[1] { 1 });
				val.componentNames = CommandComponentsLookup.componentNames;
				_matcherCalcOfflineBonusCommand = (IMatcher<CommandEntity>)(object)val;
			}
			return _matcherCalcOfflineBonusCommand;
		}
	}

	public static IMatcher<CommandEntity> ChangeCurrentFormationUnitCommand
	{
		get
		{
			if (_matcherChangeCurrentFormationUnitCommand == null)
			{
				Matcher<CommandEntity> val = (Matcher<CommandEntity>)(object)Matcher<CommandEntity>.AllOf(new int[1] { 2 });
				val.componentNames = CommandComponentsLookup.componentNames;
				_matcherChangeCurrentFormationUnitCommand = (IMatcher<CommandEntity>)(object)val;
			}
			return _matcherChangeCurrentFormationUnitCommand;
		}
	}

	public static IMatcher<CommandEntity> ClearAllUnitsCommand
	{
		get
		{
			if (_matcherClearAllUnitsCommand == null)
			{
				Matcher<CommandEntity> val = (Matcher<CommandEntity>)(object)Matcher<CommandEntity>.AllOf(new int[1] { 3 });
				val.componentNames = CommandComponentsLookup.componentNames;
				_matcherClearAllUnitsCommand = (IMatcher<CommandEntity>)(object)val;
			}
			return _matcherClearAllUnitsCommand;
		}
	}

	public static IMatcher<CommandEntity> CloseLoadingUiCommand
	{
		get
		{
			if (_matcherCloseLoadingUiCommand == null)
			{
				Matcher<CommandEntity> val = (Matcher<CommandEntity>)(object)Matcher<CommandEntity>.AllOf(new int[1] { 4 });
				val.componentNames = CommandComponentsLookup.componentNames;
				_matcherCloseLoadingUiCommand = (IMatcher<CommandEntity>)(object)val;
			}
			return _matcherCloseLoadingUiCommand;
		}
	}

	public static IMatcher<CommandEntity> CommandDelay
	{
		get
		{
			if (_matcherCommandDelay == null)
			{
				Matcher<CommandEntity> val = (Matcher<CommandEntity>)(object)Matcher<CommandEntity>.AllOf(new int[1] { 5 });
				val.componentNames = CommandComponentsLookup.componentNames;
				_matcherCommandDelay = (IMatcher<CommandEntity>)(object)val;
			}
			return _matcherCommandDelay;
		}
	}

	public static IMatcher<CommandEntity> CommandDestroyedListener
	{
		get
		{
			if (_matcherCommandDestroyedListener == null)
			{
				Matcher<CommandEntity> val = (Matcher<CommandEntity>)(object)Matcher<CommandEntity>.AllOf(new int[1] { 6 });
				val.componentNames = CommandComponentsLookup.componentNames;
				_matcherCommandDestroyedListener = (IMatcher<CommandEntity>)(object)val;
			}
			return _matcherCommandDestroyedListener;
		}
	}

	public static IMatcher<CommandEntity> Destroyed
	{
		get
		{
			if (_matcherDestroyed == null)
			{
				Matcher<CommandEntity> val = (Matcher<CommandEntity>)(object)Matcher<CommandEntity>.AllOf(new int[1] { 7 });
				val.componentNames = CommandComponentsLookup.componentNames;
				_matcherDestroyed = (IMatcher<CommandEntity>)(object)val;
			}
			return _matcherDestroyed;
		}
	}

	public static IMatcher<CommandEntity> EnterGameCommand
	{
		get
		{
			if (_matcherEnterGameCommand == null)
			{
				Matcher<CommandEntity> val = (Matcher<CommandEntity>)(object)Matcher<CommandEntity>.AllOf(new int[1] { 8 });
				val.componentNames = CommandComponentsLookup.componentNames;
				_matcherEnterGameCommand = (IMatcher<CommandEntity>)(object)val;
			}
			return _matcherEnterGameCommand;
		}
	}

	public static IMatcher<CommandEntity> ExitReplayCommand
	{
		get
		{
			if (_matcherExitReplayCommand == null)
			{
				Matcher<CommandEntity> val = (Matcher<CommandEntity>)(object)Matcher<CommandEntity>.AllOf(new int[1] { 9 });
				val.componentNames = CommandComponentsLookup.componentNames;
				_matcherExitReplayCommand = (IMatcher<CommandEntity>)(object)val;
			}
			return _matcherExitReplayCommand;
		}
	}

	public static IMatcher<CommandEntity> GameDataLoadedCommand
	{
		get
		{
			if (_matcherGameDataLoadedCommand == null)
			{
				Matcher<CommandEntity> val = (Matcher<CommandEntity>)(object)Matcher<CommandEntity>.AllOf(new int[1] { 10 });
				val.componentNames = CommandComponentsLookup.componentNames;
				_matcherGameDataLoadedCommand = (IMatcher<CommandEntity>)(object)val;
			}
			return _matcherGameDataLoadedCommand;
		}
	}

	public static IMatcher<CommandEntity> GameUserDataLoadedCommand
	{
		get
		{
			if (_matcherGameUserDataLoadedCommand == null)
			{
				Matcher<CommandEntity> val = (Matcher<CommandEntity>)(object)Matcher<CommandEntity>.AllOf(new int[1] { 11 });
				val.componentNames = CommandComponentsLookup.componentNames;
				_matcherGameUserDataLoadedCommand = (IMatcher<CommandEntity>)(object)val;
			}
			return _matcherGameUserDataLoadedCommand;
		}
	}

	public static IMatcher<CommandEntity> LoginCompleteCommand
	{
		get
		{
			if (_matcherLoginCompleteCommand == null)
			{
				Matcher<CommandEntity> val = (Matcher<CommandEntity>)(object)Matcher<CommandEntity>.AllOf(new int[1] { 12 });
				val.componentNames = CommandComponentsLookup.componentNames;
				_matcherLoginCompleteCommand = (IMatcher<CommandEntity>)(object)val;
			}
			return _matcherLoginCompleteCommand;
		}
	}

	public static IMatcher<CommandEntity> OpenLoadingUiCommand
	{
		get
		{
			if (_matcherOpenLoadingUiCommand == null)
			{
				Matcher<CommandEntity> val = (Matcher<CommandEntity>)(object)Matcher<CommandEntity>.AllOf(new int[1] { 13 });
				val.componentNames = CommandComponentsLookup.componentNames;
				_matcherOpenLoadingUiCommand = (IMatcher<CommandEntity>)(object)val;
			}
			return _matcherOpenLoadingUiCommand;
		}
	}

	public static IMatcher<CommandEntity> OpenSceneCommand
	{
		get
		{
			if (_matcherOpenSceneCommand == null)
			{
				Matcher<CommandEntity> val = (Matcher<CommandEntity>)(object)Matcher<CommandEntity>.AllOf(new int[1] { 14 });
				val.componentNames = CommandComponentsLookup.componentNames;
				_matcherOpenSceneCommand = (IMatcher<CommandEntity>)(object)val;
			}
			return _matcherOpenSceneCommand;
		}
	}

	public static IMatcher<CommandEntity> PauseReplayCommand
	{
		get
		{
			if (_matcherPauseReplayCommand == null)
			{
				Matcher<CommandEntity> val = (Matcher<CommandEntity>)(object)Matcher<CommandEntity>.AllOf(new int[1] { 15 });
				val.componentNames = CommandComponentsLookup.componentNames;
				_matcherPauseReplayCommand = (IMatcher<CommandEntity>)(object)val;
			}
			return _matcherPauseReplayCommand;
		}
	}

	public static IMatcher<CommandEntity> PlayReplayCommand
	{
		get
		{
			if (_matcherPlayReplayCommand == null)
			{
				Matcher<CommandEntity> val = (Matcher<CommandEntity>)(object)Matcher<CommandEntity>.AllOf(new int[1] { 16 });
				val.componentNames = CommandComponentsLookup.componentNames;
				_matcherPlayReplayCommand = (IMatcher<CommandEntity>)(object)val;
			}
			return _matcherPlayReplayCommand;
		}
	}

	public static IMatcher<CommandEntity> RetreatCommand
	{
		get
		{
			if (_matcherRetreatCommand == null)
			{
				Matcher<CommandEntity> val = (Matcher<CommandEntity>)(object)Matcher<CommandEntity>.AllOf(new int[1] { 17 });
				val.componentNames = CommandComponentsLookup.componentNames;
				_matcherRetreatCommand = (IMatcher<CommandEntity>)(object)val;
			}
			return _matcherRetreatCommand;
		}
	}

	public static IMatcher<CommandEntity> StartBattleCommand
	{
		get
		{
			if (_matcherStartBattleCommand == null)
			{
				Matcher<CommandEntity> val = (Matcher<CommandEntity>)(object)Matcher<CommandEntity>.AllOf(new int[1] { 18 });
				val.componentNames = CommandComponentsLookup.componentNames;
				_matcherStartBattleCommand = (IMatcher<CommandEntity>)(object)val;
			}
			return _matcherStartBattleCommand;
		}
	}

	public static IMatcher<CommandEntity> TakeItemsCommand
	{
		get
		{
			if (_matcherTakeItemsCommand == null)
			{
				Matcher<CommandEntity> val = (Matcher<CommandEntity>)(object)Matcher<CommandEntity>.AllOf(new int[1] { 19 });
				val.componentNames = CommandComponentsLookup.componentNames;
				_matcherTakeItemsCommand = (IMatcher<CommandEntity>)(object)val;
			}
			return _matcherTakeItemsCommand;
		}
	}

	public static IMatcher<CommandEntity> UnlockSoldierCommand
	{
		get
		{
			if (_matcherUnlockSoldierCommand == null)
			{
				Matcher<CommandEntity> val = (Matcher<CommandEntity>)(object)Matcher<CommandEntity>.AllOf(new int[1] { 20 });
				val.componentNames = CommandComponentsLookup.componentNames;
				_matcherUnlockSoldierCommand = (IMatcher<CommandEntity>)(object)val;
			}
			return _matcherUnlockSoldierCommand;
		}
	}

	public static IAllOfMatcher<CommandEntity> AllOf(params int[] indices)
	{
		return Matcher<CommandEntity>.AllOf(indices);
	}

	public static IAllOfMatcher<CommandEntity> AllOf(params IMatcher<CommandEntity>[] matchers)
	{
		return Matcher<CommandEntity>.AllOf(matchers);
	}

	public static IAnyOfMatcher<CommandEntity> AnyOf(params int[] indices)
	{
		return Matcher<CommandEntity>.AnyOf(indices);
	}

	public static IAnyOfMatcher<CommandEntity> AnyOf(params IMatcher<CommandEntity>[] matchers)
	{
		return Matcher<CommandEntity>.AnyOf(matchers);
	}
}
