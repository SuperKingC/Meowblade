using System.Collections.Generic;
using Entitas;
using Shift.Legion.ClientApi.Protocol;
using Shift.Legion.Common.Enums;
using Shift.Legion.Common.Models;

public sealed class CommandEntity : Entity, IDestroyedEntity
{
	private static readonly CalcOfflineBonusCommand calcOfflineBonusCommandComponent = new CalcOfflineBonusCommand();

	private static readonly ClearAllUnitsCommand clearAllUnitsCommandComponent = new ClearAllUnitsCommand();

	private static readonly CloseLoadingUiCommand closeLoadingUiCommandComponent = new CloseLoadingUiCommand();

	private static readonly DestroyedComponent destroyedComponent = new DestroyedComponent();

	private static readonly EnterGameCommand enterGameCommandComponent = new EnterGameCommand();

	private static readonly ExitReplayCommand exitReplayCommandComponent = new ExitReplayCommand();

	private static readonly PauseReplayCommand pauseReplayCommandComponent = new PauseReplayCommand();

	private static readonly PlayReplayCommand playReplayCommandComponent = new PlayReplayCommand();

	private static readonly RetreatCommand retreatCommandComponent = new RetreatCommand();

	public AddEnterMarkToUnitsCommand addEnterMarkToUnitsCommand => (AddEnterMarkToUnitsCommand)(object)((Entity)this).GetComponent(0);

	public bool hasAddEnterMarkToUnitsCommand => ((Entity)this).HasComponent(0);

	public bool isCalcOfflineBonusCommand
	{
		get
		{
			return ((Entity)this).HasComponent(1);
		}
		set
		{
			if (value == isCalcOfflineBonusCommand)
			{
				return;
			}
			int num = 1;
			if (value)
			{
				Stack<IComponent> componentPool = ((Entity)this).GetComponentPool(num);
				IComponent obj;
				if (componentPool.Count <= 0)
				{
					IComponent val = (IComponent)(object)calcOfflineBonusCommandComponent;
					obj = val;
				}
				else
				{
					obj = componentPool.Pop();
				}
				IComponent val2 = obj;
				((Entity)this).AddComponent(num, val2);
			}
			else
			{
				((Entity)this).RemoveComponent(num);
			}
		}
	}

	public ChangeCurrentFormationUnitCommand changeCurrentFormationUnitCommand => (ChangeCurrentFormationUnitCommand)(object)((Entity)this).GetComponent(2);

	public bool hasChangeCurrentFormationUnitCommand => ((Entity)this).HasComponent(2);

	public bool isClearAllUnitsCommand
	{
		get
		{
			return ((Entity)this).HasComponent(3);
		}
		set
		{
			if (value == isClearAllUnitsCommand)
			{
				return;
			}
			int num = 3;
			if (value)
			{
				Stack<IComponent> componentPool = ((Entity)this).GetComponentPool(num);
				IComponent obj;
				if (componentPool.Count <= 0)
				{
					IComponent val = (IComponent)(object)clearAllUnitsCommandComponent;
					obj = val;
				}
				else
				{
					obj = componentPool.Pop();
				}
				IComponent val2 = obj;
				((Entity)this).AddComponent(num, val2);
			}
			else
			{
				((Entity)this).RemoveComponent(num);
			}
		}
	}

	public bool isCloseLoadingUiCommand
	{
		get
		{
			return ((Entity)this).HasComponent(4);
		}
		set
		{
			if (value == isCloseLoadingUiCommand)
			{
				return;
			}
			int num = 4;
			if (value)
			{
				Stack<IComponent> componentPool = ((Entity)this).GetComponentPool(num);
				IComponent obj;
				if (componentPool.Count <= 0)
				{
					IComponent val = (IComponent)(object)closeLoadingUiCommandComponent;
					obj = val;
				}
				else
				{
					obj = componentPool.Pop();
				}
				IComponent val2 = obj;
				((Entity)this).AddComponent(num, val2);
			}
			else
			{
				((Entity)this).RemoveComponent(num);
			}
		}
	}

	public CommandDelayComponent commandDelay => (CommandDelayComponent)(object)((Entity)this).GetComponent(5);

	public bool hasCommandDelay => ((Entity)this).HasComponent(5);

	public CommandDestroyedListenerComponent commandDestroyedListener => (CommandDestroyedListenerComponent)(object)((Entity)this).GetComponent(6);

	public bool hasCommandDestroyedListener => ((Entity)this).HasComponent(6);

	public bool isDestroyed
	{
		get
		{
			return ((Entity)this).HasComponent(7);
		}
		set
		{
			if (value == isDestroyed)
			{
				return;
			}
			int num = 7;
			if (value)
			{
				Stack<IComponent> componentPool = ((Entity)this).GetComponentPool(num);
				IComponent obj;
				if (componentPool.Count <= 0)
				{
					IComponent val = (IComponent)(object)destroyedComponent;
					obj = val;
				}
				else
				{
					obj = componentPool.Pop();
				}
				IComponent val2 = obj;
				((Entity)this).AddComponent(num, val2);
			}
			else
			{
				((Entity)this).RemoveComponent(num);
			}
		}
	}

	public bool isEnterGameCommand
	{
		get
		{
			return ((Entity)this).HasComponent(8);
		}
		set
		{
			if (value == isEnterGameCommand)
			{
				return;
			}
			int num = 8;
			if (value)
			{
				Stack<IComponent> componentPool = ((Entity)this).GetComponentPool(num);
				IComponent obj;
				if (componentPool.Count <= 0)
				{
					IComponent val = (IComponent)(object)enterGameCommandComponent;
					obj = val;
				}
				else
				{
					obj = componentPool.Pop();
				}
				IComponent val2 = obj;
				((Entity)this).AddComponent(num, val2);
			}
			else
			{
				((Entity)this).RemoveComponent(num);
			}
		}
	}

	public bool isExitReplayCommand
	{
		get
		{
			return ((Entity)this).HasComponent(9);
		}
		set
		{
			if (value == isExitReplayCommand)
			{
				return;
			}
			int num = 9;
			if (value)
			{
				Stack<IComponent> componentPool = ((Entity)this).GetComponentPool(num);
				IComponent obj;
				if (componentPool.Count <= 0)
				{
					IComponent val = (IComponent)(object)exitReplayCommandComponent;
					obj = val;
				}
				else
				{
					obj = componentPool.Pop();
				}
				IComponent val2 = obj;
				((Entity)this).AddComponent(num, val2);
			}
			else
			{
				((Entity)this).RemoveComponent(num);
			}
		}
	}

	public GameDataLoadedCommand gameDataLoadedCommand => (GameDataLoadedCommand)(object)((Entity)this).GetComponent(10);

	public bool hasGameDataLoadedCommand => ((Entity)this).HasComponent(10);

	public GameUserDataLoadedCommand gameUserDataLoadedCommand => (GameUserDataLoadedCommand)(object)((Entity)this).GetComponent(11);

	public bool hasGameUserDataLoadedCommand => ((Entity)this).HasComponent(11);

	public LoginCompleteCommand loginCompleteCommand => (LoginCompleteCommand)(object)((Entity)this).GetComponent(12);

	public bool hasLoginCompleteCommand => ((Entity)this).HasComponent(12);

	public OpenLoadingUiCommand openLoadingUiCommand => (OpenLoadingUiCommand)(object)((Entity)this).GetComponent(13);

	public bool hasOpenLoadingUiCommand => ((Entity)this).HasComponent(13);

	public OpenSceneCommand openSceneCommand => (OpenSceneCommand)(object)((Entity)this).GetComponent(14);

	public bool hasOpenSceneCommand => ((Entity)this).HasComponent(14);

	public bool isPauseReplayCommand
	{
		get
		{
			return ((Entity)this).HasComponent(15);
		}
		set
		{
			if (value == isPauseReplayCommand)
			{
				return;
			}
			int num = 15;
			if (value)
			{
				Stack<IComponent> componentPool = ((Entity)this).GetComponentPool(num);
				IComponent obj;
				if (componentPool.Count <= 0)
				{
					IComponent val = (IComponent)(object)pauseReplayCommandComponent;
					obj = val;
				}
				else
				{
					obj = componentPool.Pop();
				}
				IComponent val2 = obj;
				((Entity)this).AddComponent(num, val2);
			}
			else
			{
				((Entity)this).RemoveComponent(num);
			}
		}
	}

	public bool isPlayReplayCommand
	{
		get
		{
			return ((Entity)this).HasComponent(16);
		}
		set
		{
			if (value == isPlayReplayCommand)
			{
				return;
			}
			int num = 16;
			if (value)
			{
				Stack<IComponent> componentPool = ((Entity)this).GetComponentPool(num);
				IComponent obj;
				if (componentPool.Count <= 0)
				{
					IComponent val = (IComponent)(object)playReplayCommandComponent;
					obj = val;
				}
				else
				{
					obj = componentPool.Pop();
				}
				IComponent val2 = obj;
				((Entity)this).AddComponent(num, val2);
			}
			else
			{
				((Entity)this).RemoveComponent(num);
			}
		}
	}

	public bool isRetreatCommand
	{
		get
		{
			return ((Entity)this).HasComponent(17);
		}
		set
		{
			if (value == isRetreatCommand)
			{
				return;
			}
			int num = 17;
			if (value)
			{
				Stack<IComponent> componentPool = ((Entity)this).GetComponentPool(num);
				IComponent obj;
				if (componentPool.Count <= 0)
				{
					IComponent val = (IComponent)(object)retreatCommandComponent;
					obj = val;
				}
				else
				{
					obj = componentPool.Pop();
				}
				IComponent val2 = obj;
				((Entity)this).AddComponent(num, val2);
			}
			else
			{
				((Entity)this).RemoveComponent(num);
			}
		}
	}

	public StartBattleCommand startBattleCommand => (StartBattleCommand)(object)((Entity)this).GetComponent(18);

	public bool hasStartBattleCommand => ((Entity)this).HasComponent(18);

	public TakeItemsCommand takeItemsCommand => (TakeItemsCommand)(object)((Entity)this).GetComponent(19);

	public bool hasTakeItemsCommand => ((Entity)this).HasComponent(19);

	public UnlockSoldierCommand unlockSoldierCommand => (UnlockSoldierCommand)(object)((Entity)this).GetComponent(20);

	public bool hasUnlockSoldierCommand => ((Entity)this).HasComponent(20);

	public void AddAddEnterMarkToUnitsCommand(Team newTeam, int newPortalId)
	{
		int num = 0;
		AddEnterMarkToUnitsCommand addEnterMarkToUnitsCommand = (AddEnterMarkToUnitsCommand)(object)((Entity)this).CreateComponent(num, typeof(AddEnterMarkToUnitsCommand));
		addEnterMarkToUnitsCommand.team = newTeam;
		addEnterMarkToUnitsCommand.portalId = newPortalId;
		((Entity)this).AddComponent(num, (IComponent)(object)addEnterMarkToUnitsCommand);
	}

	public void ReplaceAddEnterMarkToUnitsCommand(Team newTeam, int newPortalId)
	{
		int num = 0;
		AddEnterMarkToUnitsCommand addEnterMarkToUnitsCommand = (AddEnterMarkToUnitsCommand)(object)((Entity)this).CreateComponent(num, typeof(AddEnterMarkToUnitsCommand));
		addEnterMarkToUnitsCommand.team = newTeam;
		addEnterMarkToUnitsCommand.portalId = newPortalId;
		((Entity)this).ReplaceComponent(num, (IComponent)(object)addEnterMarkToUnitsCommand);
	}

	public void RemoveAddEnterMarkToUnitsCommand()
	{
		((Entity)this).RemoveComponent(0);
	}

	public void AddChangeCurrentFormationUnitCommand(int newPortalId, string newUnitId, string newContext, string newSubContext)
	{
		int num = 2;
		ChangeCurrentFormationUnitCommand changeCurrentFormationUnitCommand = (ChangeCurrentFormationUnitCommand)(object)((Entity)this).CreateComponent(num, typeof(ChangeCurrentFormationUnitCommand));
		changeCurrentFormationUnitCommand.portalId = newPortalId;
		changeCurrentFormationUnitCommand.unitId = newUnitId;
		changeCurrentFormationUnitCommand.context = newContext;
		changeCurrentFormationUnitCommand.subContext = newSubContext;
		((Entity)this).AddComponent(num, (IComponent)(object)changeCurrentFormationUnitCommand);
	}

	public void ReplaceChangeCurrentFormationUnitCommand(int newPortalId, string newUnitId, string newContext, string newSubContext)
	{
		int num = 2;
		ChangeCurrentFormationUnitCommand changeCurrentFormationUnitCommand = (ChangeCurrentFormationUnitCommand)(object)((Entity)this).CreateComponent(num, typeof(ChangeCurrentFormationUnitCommand));
		changeCurrentFormationUnitCommand.portalId = newPortalId;
		changeCurrentFormationUnitCommand.unitId = newUnitId;
		changeCurrentFormationUnitCommand.context = newContext;
		changeCurrentFormationUnitCommand.subContext = newSubContext;
		((Entity)this).ReplaceComponent(num, (IComponent)(object)changeCurrentFormationUnitCommand);
	}

	public void RemoveChangeCurrentFormationUnitCommand()
	{
		((Entity)this).RemoveComponent(2);
	}

	public void AddCommandDelay(float newValue)
	{
		int num = 5;
		CommandDelayComponent commandDelayComponent = (CommandDelayComponent)(object)((Entity)this).CreateComponent(num, typeof(CommandDelayComponent));
		commandDelayComponent.value = newValue;
		((Entity)this).AddComponent(num, (IComponent)(object)commandDelayComponent);
	}

	public void ReplaceCommandDelay(float newValue)
	{
		int num = 5;
		CommandDelayComponent commandDelayComponent = (CommandDelayComponent)(object)((Entity)this).CreateComponent(num, typeof(CommandDelayComponent));
		commandDelayComponent.value = newValue;
		((Entity)this).ReplaceComponent(num, (IComponent)(object)commandDelayComponent);
	}

	public void RemoveCommandDelay()
	{
		((Entity)this).RemoveComponent(5);
	}

	public void AddCommandDestroyedListener(List<ICommandDestroyedListener> newValue)
	{
		int num = 6;
		CommandDestroyedListenerComponent commandDestroyedListenerComponent = (CommandDestroyedListenerComponent)(object)((Entity)this).CreateComponent(num, typeof(CommandDestroyedListenerComponent));
		commandDestroyedListenerComponent.value = newValue;
		((Entity)this).AddComponent(num, (IComponent)(object)commandDestroyedListenerComponent);
	}

	public void ReplaceCommandDestroyedListener(List<ICommandDestroyedListener> newValue)
	{
		int num = 6;
		CommandDestroyedListenerComponent commandDestroyedListenerComponent = (CommandDestroyedListenerComponent)(object)((Entity)this).CreateComponent(num, typeof(CommandDestroyedListenerComponent));
		commandDestroyedListenerComponent.value = newValue;
		((Entity)this).ReplaceComponent(num, (IComponent)(object)commandDestroyedListenerComponent);
	}

	public void RemoveCommandDestroyedListener()
	{
		((Entity)this).RemoveComponent(6);
	}

	public void AddCommandDestroyedListener(ICommandDestroyedListener value)
	{
		List<ICommandDestroyedListener> list = (hasCommandDestroyedListener ? commandDestroyedListener.value : new List<ICommandDestroyedListener>());
		list.Add(value);
		ReplaceCommandDestroyedListener(list);
	}

	public void RemoveCommandDestroyedListener(ICommandDestroyedListener value, bool removeComponentWhenEmpty = true)
	{
		List<ICommandDestroyedListener> value2 = commandDestroyedListener.value;
		value2.Remove(value);
		if (removeComponentWhenEmpty && value2.Count == 0)
		{
			RemoveCommandDestroyedListener();
		}
		else
		{
			ReplaceCommandDestroyedListener(value2);
		}
	}

	public void AddGameDataLoadedCommand(byte[] newData)
	{
		int num = 10;
		GameDataLoadedCommand gameDataLoadedCommand = (GameDataLoadedCommand)(object)((Entity)this).CreateComponent(num, typeof(GameDataLoadedCommand));
		gameDataLoadedCommand.data = newData;
		((Entity)this).AddComponent(num, (IComponent)(object)gameDataLoadedCommand);
	}

	public void ReplaceGameDataLoadedCommand(byte[] newData)
	{
		int num = 10;
		GameDataLoadedCommand gameDataLoadedCommand = (GameDataLoadedCommand)(object)((Entity)this).CreateComponent(num, typeof(GameDataLoadedCommand));
		gameDataLoadedCommand.data = newData;
		((Entity)this).ReplaceComponent(num, (IComponent)(object)gameDataLoadedCommand);
	}

	public void RemoveGameDataLoadedCommand()
	{
		((Entity)this).RemoveComponent(10);
	}

	public void AddGameUserDataLoadedCommand(int newUserId, Dictionary<string, UserData> newData)
	{
		int num = 11;
		GameUserDataLoadedCommand gameUserDataLoadedCommand = (GameUserDataLoadedCommand)(object)((Entity)this).CreateComponent(num, typeof(GameUserDataLoadedCommand));
		gameUserDataLoadedCommand.userId = newUserId;
		gameUserDataLoadedCommand.data = newData;
		((Entity)this).AddComponent(num, (IComponent)(object)gameUserDataLoadedCommand);
	}

	public void ReplaceGameUserDataLoadedCommand(int newUserId, Dictionary<string, UserData> newData)
	{
		int num = 11;
		GameUserDataLoadedCommand gameUserDataLoadedCommand = (GameUserDataLoadedCommand)(object)((Entity)this).CreateComponent(num, typeof(GameUserDataLoadedCommand));
		gameUserDataLoadedCommand.userId = newUserId;
		gameUserDataLoadedCommand.data = newData;
		((Entity)this).ReplaceComponent(num, (IComponent)(object)gameUserDataLoadedCommand);
	}

	public void RemoveGameUserDataLoadedCommand()
	{
		((Entity)this).RemoveComponent(11);
	}

	public void AddLoginCompleteCommand(User newUser)
	{
		int num = 12;
		LoginCompleteCommand loginCompleteCommand = (LoginCompleteCommand)(object)((Entity)this).CreateComponent(num, typeof(LoginCompleteCommand));
		loginCompleteCommand.user = newUser;
		((Entity)this).AddComponent(num, (IComponent)(object)loginCompleteCommand);
	}

	public void ReplaceLoginCompleteCommand(User newUser)
	{
		int num = 12;
		LoginCompleteCommand loginCompleteCommand = (LoginCompleteCommand)(object)((Entity)this).CreateComponent(num, typeof(LoginCompleteCommand));
		loginCompleteCommand.user = newUser;
		((Entity)this).ReplaceComponent(num, (IComponent)(object)loginCompleteCommand);
	}

	public void RemoveLoginCompleteCommand()
	{
		((Entity)this).RemoveComponent(12);
	}

	public void AddOpenLoadingUiCommand(float newMinTime)
	{
		int num = 13;
		OpenLoadingUiCommand openLoadingUiCommand = (OpenLoadingUiCommand)(object)((Entity)this).CreateComponent(num, typeof(OpenLoadingUiCommand));
		openLoadingUiCommand.minTime = newMinTime;
		((Entity)this).AddComponent(num, (IComponent)(object)openLoadingUiCommand);
	}

	public void ReplaceOpenLoadingUiCommand(float newMinTime)
	{
		int num = 13;
		OpenLoadingUiCommand openLoadingUiCommand = (OpenLoadingUiCommand)(object)((Entity)this).CreateComponent(num, typeof(OpenLoadingUiCommand));
		openLoadingUiCommand.minTime = newMinTime;
		((Entity)this).ReplaceComponent(num, (IComponent)(object)openLoadingUiCommand);
	}

	public void RemoveOpenLoadingUiCommand()
	{
		((Entity)this).RemoveComponent(13);
	}

	public void AddOpenSceneCommand(string newScene, SceneArguments newArguments)
	{
		int num = 14;
		OpenSceneCommand openSceneCommand = (OpenSceneCommand)(object)((Entity)this).CreateComponent(num, typeof(OpenSceneCommand));
		openSceneCommand.scene = newScene;
		openSceneCommand.arguments = newArguments;
		((Entity)this).AddComponent(num, (IComponent)(object)openSceneCommand);
	}

	public void ReplaceOpenSceneCommand(string newScene, SceneArguments newArguments)
	{
		int num = 14;
		OpenSceneCommand openSceneCommand = (OpenSceneCommand)(object)((Entity)this).CreateComponent(num, typeof(OpenSceneCommand));
		openSceneCommand.scene = newScene;
		openSceneCommand.arguments = newArguments;
		((Entity)this).ReplaceComponent(num, (IComponent)(object)openSceneCommand);
	}

	public void RemoveOpenSceneCommand()
	{
		((Entity)this).RemoveComponent(14);
	}

	public void AddStartBattleCommand(string newValue)
	{
		int num = 18;
		StartBattleCommand startBattleCommand = (StartBattleCommand)(object)((Entity)this).CreateComponent(num, typeof(StartBattleCommand));
		startBattleCommand.value = newValue;
		((Entity)this).AddComponent(num, (IComponent)(object)startBattleCommand);
	}

	public void ReplaceStartBattleCommand(string newValue)
	{
		int num = 18;
		StartBattleCommand startBattleCommand = (StartBattleCommand)(object)((Entity)this).CreateComponent(num, typeof(StartBattleCommand));
		startBattleCommand.value = newValue;
		((Entity)this).ReplaceComponent(num, (IComponent)(object)startBattleCommand);
	}

	public void RemoveStartBattleCommand()
	{
		((Entity)this).RemoveComponent(18);
	}

	public void AddTakeItemsCommand(List<Bonus> newItems)
	{
		int num = 19;
		TakeItemsCommand takeItemsCommand = (TakeItemsCommand)(object)((Entity)this).CreateComponent(num, typeof(TakeItemsCommand));
		takeItemsCommand.items = newItems;
		((Entity)this).AddComponent(num, (IComponent)(object)takeItemsCommand);
	}

	public void ReplaceTakeItemsCommand(List<Bonus> newItems)
	{
		int num = 19;
		TakeItemsCommand takeItemsCommand = (TakeItemsCommand)(object)((Entity)this).CreateComponent(num, typeof(TakeItemsCommand));
		takeItemsCommand.items = newItems;
		((Entity)this).ReplaceComponent(num, (IComponent)(object)takeItemsCommand);
	}

	public void RemoveTakeItemsCommand()
	{
		((Entity)this).RemoveComponent(19);
	}

	public void AddUnlockSoldierCommand(string newSoldierId, List<string> newUnlockedProduct)
	{
		int num = 20;
		UnlockSoldierCommand unlockSoldierCommand = (UnlockSoldierCommand)(object)((Entity)this).CreateComponent(num, typeof(UnlockSoldierCommand));
		unlockSoldierCommand.soldierId = newSoldierId;
		unlockSoldierCommand.unlockedProduct = newUnlockedProduct;
		((Entity)this).AddComponent(num, (IComponent)(object)unlockSoldierCommand);
	}

	public void ReplaceUnlockSoldierCommand(string newSoldierId, List<string> newUnlockedProduct)
	{
		int num = 20;
		UnlockSoldierCommand unlockSoldierCommand = (UnlockSoldierCommand)(object)((Entity)this).CreateComponent(num, typeof(UnlockSoldierCommand));
		unlockSoldierCommand.soldierId = newSoldierId;
		unlockSoldierCommand.unlockedProduct = newUnlockedProduct;
		((Entity)this).ReplaceComponent(num, (IComponent)(object)unlockSoldierCommand);
	}

	public void RemoveUnlockSoldierCommand()
	{
		((Entity)this).RemoveComponent(20);
	}
}
