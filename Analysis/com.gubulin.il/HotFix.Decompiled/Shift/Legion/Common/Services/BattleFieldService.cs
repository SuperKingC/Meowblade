using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Assets.Scripts.Managers;
using Assets.Scripts.UI;
using Entitas;
using FairyGUI;
using GameMaths;
using HotFix.Sources.Base.Scripts.UI;
using Shift.Legion.ClientApi.Models;
using Shift.Legion.ClientApi.Protocol.UserAction;
using Shift.Legion.Common.Enums;
using Shift.Legion.Common.Helpers;
using Shift.Legion.Common.Managers;
using Shift.Legion.Common.Models;
using Shift.Legion.Common.Sources.Enums;
using UI.Battle;
using UI.LegendItemDungeon;
using UI.PvpSelectSoldiers;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Shift.Legion.Common.Services;

public class BattleFieldService : Service, IBattleFieldService, IService, IAnyBattleConfigListener, IAnySubLevelWinnerListener, IAnyBattleWaveTimeLeftListener, IAnySceneLoadedListener, IAnyBattleFieldLevelListener, IAnyFormationUnitsListener, IAnyCurrentFormationListener, IAnyWinnerListener, IAnyBattleFieldSubLevelIndexListener
{
	private GameStateEntity _gameStateEntity;

	private ConfigEntity _eventListenerEntity;

	private readonly IGroup<GameEntity> _group;

	private readonly List<GameEntity> _buffer;

	private BattleConfig _oldRedConfig;

	private BattleConfig _oldBlueConfig;

	private float _oldBattleFieldLength;

	private bool _battleFieldLengthChanged;

	private bool _redTeamFormationChanged;

	private bool _blueTeamFormationChanged;

	private bool _redTeamObstaclesChanged;

	private bool _blueTeamObstaclesChanged;

	private bool _refreshRedUnits;

	private bool _refreshBlueUnits;

	public Chapter Chapter;

	private GameEntity _gameEntity;

	private Action _nextStep;

	public bool LevelSettling;

	private List<string> CapturedLevels = new List<string>();

	private static int GetRankBattleRetryCnt;

	private readonly List<Activity> _activitiesBuffer = new List<Activity>();

	public Level Level { get; set; }

	public string LevelFormationContext
	{
		get
		{
			if (Level == null)
			{
				return ChapterType.StoryMain.ToString();
			}
			Activity levelActivity = GameManagers.Instance.ActivityManager.GetLevelActivity(Level);
			return (levelActivity == null) ? Level.FormationContext : levelActivity.FormationTag;
		}
	}

	public Level CurrentLevel
	{
		get
		{
			Level value = base.Contexts.gameState.battleFieldLevel.value;
			if (!value.HasSubLevels())
			{
				return value;
			}
			if (base.Contexts.gameState.hasBattleFieldSubLevelIndex)
			{
				ChapterManager.Levels.TryGetValue(value.SubLevels[base.Contexts.gameState.battleFieldSubLevelIndex.value], out var level);
				return level;
			}
			ChapterManager.Levels.TryGetValue(value.SubLevels.Last(), out var level2);
			return level2;
		}
	}

	public int CurrentLevelIndex
	{
		get
		{
			Level value = base.Contexts.gameState.battleFieldLevel.value;
			if (!value.HasSubLevels())
			{
				return 0;
			}
			return base.Contexts.gameState.hasBattleFieldSubLevelIndex ? base.Contexts.gameState.battleFieldSubLevelIndex.value : (value.SubLevels.Count - 1);
		}
	}

	public BattleFieldService(Contexts contexts)
		: base(contexts)
	{
		_group = ((Context<GameEntity>)base.Contexts.game).GetGroup(GameMatcher.AiObject);
		_buffer = new List<GameEntity>();
		if (base.Contexts.config.hasBattleConfig)
		{
			_oldRedConfig = base.Contexts.config.battleConfig.Red;
			_oldBlueConfig = base.Contexts.config.battleConfig.Blue;
			_oldBattleFieldLength = base.Contexts.config.battleConfig.BattleFieldLength;
		}
	}

	public override void AddEventsListener()
	{
		base.AddEventsListener();
		_eventListenerEntity = ((Context<ConfigEntity>)base.Contexts.config).CreateEntity();
		_eventListenerEntity.AddAnyBattleConfigListener(this);
		_gameStateEntity = ((Context<GameStateEntity>)base.Contexts.gameState).CreateEntity();
		_gameStateEntity.AddAnyBattleFieldSubLevelIndexListener(this);
		_gameEntity = ((Context<GameEntity>)base.Contexts.game).CreateEntity();
		_gameEntity.AddAnySceneLoadedListener(this);
		_eventListenerEntity.AddAnyCurrentFormationListener(this);
		_eventListenerEntity.AddAnyFormationUnitsListener(this);
		_gameStateEntity.AddAnyBattleFieldLevelListener(this);
		_gameStateEntity.AddAnyBattleWaveTimeLeftListener(this);
		_gameStateEntity.AddAnyWinnerListener(this);
		_gameStateEntity.AddAnySubLevelWinnerListener(this);
	}

	public override void RemoveEventsListener()
	{
		base.RemoveEventsListener();
		_gameEntity.RemoveAnySceneLoadedListener(this);
		((Entity)_gameEntity).Destroy();
		_gameEntity = null;
		_gameStateEntity.RemoveAnyBattleFieldSubLevelIndexListener(this);
		_gameStateEntity.RemoveAnyBattleFieldLevelListener(this);
		_gameStateEntity.RemoveAnyBattleWaveTimeLeftListener(this);
		_gameStateEntity.RemoveAnyWinnerListener(this);
		_gameStateEntity.RemoveAnySubLevelWinnerListener(this);
		((Entity)_gameStateEntity).Destroy();
		_gameStateEntity = null;
		_eventListenerEntity.RemoveAnyBattleConfigListener(this);
		_eventListenerEntity.RemoveAnyCurrentFormationListener(this);
		_eventListenerEntity.RemoveAnyFormationUnitsListener(this);
		((Entity)_eventListenerEntity).Destroy();
		_eventListenerEntity = null;
	}

	public void OnAnyBattleConfig(ConfigEntity entity, BattleConfig red, BattleConfig blue, float battleFieldLength)
	{
		int value = base.Contexts.gameState.battleFieldSubLevelIndex.value;
		_battleFieldLengthChanged = Math.Abs(battleFieldLength - _oldBattleFieldLength) > float.Epsilon;
		_oldBattleFieldLength = battleFieldLength;
		List<BattleConfig_Pos> list = null;
		_refreshRedUnits = red.isRefresh;
		if (red.isRefresh)
		{
			red.isRefresh = false;
			UpdateBattleField(Team.Red, red, _oldRedConfig);
		}
		_refreshBlueUnits = blue.isRefresh;
		if (blue.isRefresh)
		{
			blue.isRefresh = false;
			UpdateBattleField(Team.Blue, blue, _oldBlueConfig);
			_oldBlueConfig = blue;
		}
		if (_refreshRedUnits || _refreshBlueUnits)
		{
			_group.GetEntities(_buffer);
		}
		if (_refreshRedUnits)
		{
			if (_redTeamFormationChanged && ClientBattleFieldLogic.HasSameUnitsBetweenBattleConfig(_oldRedConfig, red))
			{
				ClientBattleFieldLogic.CleanChangeDifferentBattleConfig();
				ClientBattleFieldLogic.ChangeFormat(base.Contexts, _buffer, _oldRedConfig);
				_refreshRedUnits = false;
			}
			else if (_oldRedConfig != null)
			{
				list = ClientBattleFieldLogic.FindDifferentBetweenBattleConfig(_oldRedConfig, red);
			}
			_oldRedConfig = red;
		}
		if (_battleFieldLengthChanged || _redTeamFormationChanged)
		{
			_redTeamFormationChanged = false;
			GameManagers.Instance.Messenger.Broadcast("STAGING_AREA_POSITIONS_CHANGED", 200);
		}
		if (_battleFieldLengthChanged || _blueTeamFormationChanged)
		{
			_blueTeamFormationChanged = false;
		}
		_battleFieldLengthChanged = false;
		if (_redTeamObstaclesChanged || _blueTeamObstaclesChanged)
		{
			ClientBattleFieldLogic.ClearAllObstacles(base.Contexts);
			ClientBattleFieldLogic.CreateObstacles(base.Contexts, Team.Red, red.Obstacles);
			ClientBattleFieldLogic.CreateObstacles(base.Contexts, Team.Blue, blue.Obstacles);
			_redTeamObstaclesChanged = false;
			_blueTeamObstaclesChanged = false;
		}
		if (_refreshRedUnits && _oldRedConfig.BattleMode != BattleMode.MultiWaveAttackMode)
		{
			if (list != null && list.Count > 0)
			{
				ClientBattleFieldLogic.CleanChangeDifferentBattleConfig();
				for (int i = 0; i < list.Count; i++)
				{
					if (list[i].LevelIndex == value)
					{
						ClientBattleFieldLogic.ClearUnitsByPortalId(_buffer, Team.Red, list[i]);
						ClientBattleFieldLogic.ChangeDifferentBattleConfig(base.Contexts, Team.Red, list[i], value);
					}
				}
			}
			else
			{
				ClientBattleFieldLogic.CleanChangeDifferentBattleConfig();
				ClientBattleFieldLogic.ClearUnits(_buffer, Team.Red);
				ClientBattleFieldLogic.Staging(base.Contexts, Team.Red, value);
			}
			_refreshRedUnits = false;
		}
		if (base.Contexts.gameState.isBattleStarted)
		{
			_refreshBlueUnits = false;
		}
		else if (_refreshBlueUnits)
		{
			ClientBattleFieldLogic.ClearUnits(_buffer, Team.Blue);
			ClientBattleFieldLogic.Staging(base.Contexts, Team.Blue, value);
			_refreshBlueUnits = false;
		}
	}

	private void UpdateBattleField(Team team, BattleConfig newConfig, BattleConfig oldConfig)
	{
		if (newConfig == oldConfig)
		{
			return;
		}
		if (!BattleConfig.IsObstaclesEquals(oldConfig, newConfig))
		{
			if (team == Team.Red)
			{
				_redTeamObstaclesChanged = true;
			}
			else
			{
				_blueTeamObstaclesChanged = true;
			}
		}
		if (!BattleConfig.IsFormationEquals(oldConfig, newConfig))
		{
			if (team == Team.Red)
			{
				_redTeamFormationChanged = true;
			}
			else
			{
				_blueTeamFormationChanged = true;
			}
		}
		if (newConfig.BattleMode != BattleMode.MultiWaveAttackMode && (team != Team.Red || !base.Contexts.gameState.isCurrentLevelBattleStarted))
		{
			bool flag = !BattleConfig.IsUnitsEquals(oldConfig, newConfig) || !BattleConfig.IsBossEquals(oldConfig, newConfig);
			if (_redTeamFormationChanged || flag)
			{
				_refreshRedUnits = true;
			}
			else
			{
				_refreshRedUnits = false;
			}
			if (_blueTeamFormationChanged || flag)
			{
				_refreshBlueUnits = true;
			}
			else
			{
				_refreshBlueUnits = false;
			}
		}
	}

	public void ClearBattleConfig()
	{
		_oldRedConfig = null;
		_oldBlueConfig = null;
		_oldBattleFieldLength = 0f;
	}

	public void CheckStoryPlayList(string storyId = null)
	{
		List<string> playingStories = GameManagers.Instance.StoryManager.PlayingStories;
		if (playingStories.Count <= 0)
		{
			_nextStep?.Invoke();
			_nextStep = null;
		}
	}

	public void OnAnyWinner(GameStateEntity entity, Team value)
	{
		if (CurrentLevel.LevelId == "RankBattleFieldLevel")
		{
			GetRankBattleResult();
		}
		else if (!RankDataHelper.IsPvPLevel(CurrentLevel.LevelId))
		{
			GetBattleResult();
		}
	}

	public void OnAnyBattleFieldSubLevelIndex(GameStateEntity entity, int value)
	{
		Level level = Level?.GetSubLevel(value);
		if (level != null)
		{
			if (!string.IsNullOrEmpty(level.Data.MapIdentifier) && level.Data.MapIdentifier != base.Contexts.gameState.battleFieldMapIdentifier.value)
			{
				base.Contexts.gameState.ReplaceBattleFieldMapIdentifier(level.Data.MapIdentifier);
			}
			GameManagers.Instance.Messenger.Broadcast("SUB_LEVEL_CHANGED", level);
		}
	}

	public void OnAnyBattleWaveTimeLeft(GameStateEntity entity, int value)
	{
		if (value == 3)
		{
			if (base.Contexts.gameState.hasReplayMode && base.Contexts.gameState.replayMode.value == 3)
			{
				return;
			}
			string currentBattleId = GameManagers.Instance.UserArchiveManager.GetCurrentBattleId();
			base.Contexts.Service<INetworkService>().SubmitBattleOperation(currentBattleId, base.Contexts.gameState.battleFieldSubLevelIndex.value, null, null);
		}
		if (value != 2)
		{
			return;
		}
		ScriptApi.CreateTimer(base.Contexts, 0.7f, delegate
		{
			if (base.Contexts.gameState.hasBattleWaveTimeLeft && base.Contexts.gameState.battleWaveTimeLeft.value <= 2)
			{
				if (!HasAnyUnitsAlive(Team.Red))
				{
					base.Contexts.gameState.isCameraFollowingUnit = true;
				}
				IGroup<GameEntity> val = ((Context<GameEntity>)base.Contexts.game).GetGroup(GameMatcher.BattleField);
				GameEntity[] entities = val.GetEntities();
				GameEntity[] array = entities;
				foreach (GameEntity gameEntity in array)
				{
					gameEntity.battleField.value.PlaySpawnUnitsAnimation();
				}
			}
		});
	}

	private bool HasAnyUnitsAlive(Team team)
	{
		IGroup<GameEntity> groupOfReplayContexts = base.Contexts.Service<ReplayPlayerService>().GetGroupOfReplayContexts(GameMatcher.AiObject);
		GameEntity[] entities = groupOfReplayContexts.GetEntities();
		GameEntity[] array = entities;
		foreach (GameEntity gameEntity in array)
		{
			if (gameEntity.hasTeam && gameEntity.team.value == team && gameEntity.hasUnitStats && !gameEntity.isDead)
			{
				return true;
			}
		}
		return false;
	}

	public async void OnAnySubLevelWinner(GameStateEntity entity, Team value)
	{
		if (!base.Contexts.gameState.hasReplayMode || base.Contexts.gameState.replayMode.value != 3)
		{
			await GetBattleResultAndShowBattleBonuses();
		}
		ScriptApi.CreateTimer(base.Contexts, 1f, delegate
		{
			base.Contexts.gameState.isShowBattleWaveCountdown = false;
		});
		ScriptApi.CreateTimer(base.Contexts, 2f, delegate
		{
			//IL_0023: Unknown result type (might be due to invalid IL or missing references)
			//IL_0028: Unknown result type (might be due to invalid IL or missing references)
			//IL_0057: Unknown result type (might be due to invalid IL or missing references)
			base.Contexts.gameState.isCameraFollowingUnit = false;
			Vector3 cameraPositionForScene = base.Contexts.Service<ICameraService>().GetCameraPositionForScene("BattleField");
			IGroup<GameEntity> val = ((Context<GameEntity>)base.Contexts.game).GetGroup(GameMatcher.Camera);
			GameEntity[] entities = val.GetEntities();
			GameEntity[] array = entities;
			foreach (GameEntity gameEntity in array)
			{
				gameEntity.ReplaceCameraMoveToPosition(cameraPositionForScene);
				gameEntity.ReplaceCameraMoveToPositionDuration(1f);
				gameEntity.ReplaceCameraMoveToPositionElapsedTime(0f);
			}
		});
	}

	public void OnAnySceneLoaded(GameEntity entity)
	{
		if (entity.sceneName.value != "BattleField")
		{
			return;
		}
		SceneArguments arguments = entity.sceneArguments.value;
		Dictionary<string, object> dic = new Dictionary<string, object>();
		if (arguments.Data.ContainsKey("OpenUiOnReturn"))
		{
			dic.Add("OpenUIOnReturn", arguments.OpenUiOnReturn);
		}
		if (arguments.Data.ContainsKey("WorldMapBtnVisible"))
		{
			dic.Add("WorldMapBtnVisible", arguments.WorldMapBtnVisible);
		}
		if (arguments.ShowLevelStrategyReminder)
		{
			dic.Add("SHOW_LEVEL_STRATEGY_REMINDER", true);
		}
		if (!GameManagers.Instance.UserArchiveManager.GetUndergoingStories().Contains("Story0011") || GameManagers.Instance.UserArchiveManager.GetPlayingStories().Contains("Story0011"))
		{
			base.Contexts.Service<IUiService>().OpenPanel(UI_Battle.Name, dic);
		}
		if (arguments.Data.ContainsKey("OpenUiOnEnter") && !string.IsNullOrWhiteSpace(arguments.OpenUiOnEnter))
		{
			ScriptApi.CreateTimer(base.Contexts, 0.1f, delegate
			{
				base.Contexts.Service<IUiService>().OpenPanel(arguments.OpenUiOnEnter, dic);
			});
		}
		ClientBattleFieldLogic.SetBattleFieldCameraMoveLimit(base.Contexts);
	}

	public void QuickBattle_OnAnyBattleFieldLevel(Level value)
	{
		if (value != null)
		{
			Level = value;
			Chapter = GameManagers.Instance.ChapterManager.GetChapter(Level.ChapterId);
			CapturedLevels.Clear();
			_nextStep = null;
			LevelSettling = false;
		}
	}

	public void OnAnyBattleFieldLevel(GameStateEntity entity, Level value)
	{
		if (value == null)
		{
			return;
		}
		Level = value;
		Chapter = GameManagers.Instance.ChapterManager.GetChapter(Level.ChapterId);
		CapturedLevels.Clear();
		_nextStep = null;
		LevelSettling = false;
		GameStateContext gameState = base.Contexts.gameState;
		gameState.ReplaceBattleFieldMapIdentifier(Level.Data.MapIdentifier);
		gameState.ReplaceBattleFieldLength(Level.Data.Length);
		gameState.isBattleStarted = false;
		gameState.isCurrentLevelBattleStarted = false;
		BattleConfig redTeamBattleConfig = new BattleConfig();
		redTeamBattleConfig.BattleMode = (BattleMode)Level.Data.RedTeamBattleMode;
		if (redTeamBattleConfig.BattleMode == BattleMode.MultiWaveAttackMode)
		{
			Dictionary<string, int> dictionary = new Dictionary<string, int>();
			List<string> unlockedSoldiers = GameManagers.Instance.UserArchiveManager.GetUnlockedSoldiers();
			foreach (string item in unlockedSoldiers)
			{
				dictionary.Add(item, GameManagers.Instance.StockController.GetStock(item));
			}
			redTeamBattleConfig.UnitsPool = dictionary;
		}
		redTeamBattleConfig.Obstacles = BattleFieldLogic.GetObstacles(Team.Red, Level);
		BattleConfig blueTeamBattleConfig = new BattleConfig();
		blueTeamBattleConfig.BattleMode = (BattleMode)Level.Data.BlueTeamBattleMode;
		blueTeamBattleConfig.Obstacles = BattleFieldLogic.GetObstacles(Team.Blue, Level);
		Action action = delegate
		{
			if (string.IsNullOrEmpty(Level.Data.RedFormationId))
			{
				Activity levelActivity = GameManagers.Instance.ActivityManager.GetLevelActivity(Level);
				string context = ((levelActivity == null) ? Level.FormationContext : levelActivity.FormationTag);
				redTeamBattleConfig.FormationId[0] = GameManagers.Instance.UserArchiveManager.GetCurrentFormation(context, Level.BattleMode.ToString());
			}
			BattleFieldLogic.UpdateFormationUnits(GameManagers.Instance, Level, Team.Blue, blueTeamBattleConfig, delegate
			{
				redTeamBattleConfig.isRefresh = true;
				blueTeamBattleConfig.isRefresh = true;
				base.Contexts.config.ReplaceBattleConfig(redTeamBattleConfig, blueTeamBattleConfig, Level.Data.Length);
			});
		};
		if (base.Contexts.config.hasFormationUnits)
		{
			BattleFieldLogic.UpdateFormationUnits(GameManagers.Instance, Level, Team.Red, redTeamBattleConfig, action);
		}
		else
		{
			action();
		}
	}

	public void OnAnyFormationUnits(ConfigEntity entity, Dictionary<string, Dictionary<string, List<string>>> value)
	{
		FGUIManager.Instance.OpenIEnumerator(IEnumerator_OnAnyFormationUnits(entity, value));
	}

	private IEnumerator IEnumerator_OnAnyFormationUnits(ConfigEntity entity, Dictionary<string, Dictionary<string, List<string>>> value)
	{
		if (!base.Contexts.config.hasBattleConfig || LevelSettling)
		{
			yield break;
		}
		BattleConfigComponent battleConfig = base.Contexts.config.battleConfig;
		for (int i = 0; i < 20; i++)
		{
			if (battleConfig.Red.IsUnitRefreshed && battleConfig.Blue.IsUnitRefreshed)
			{
				break;
			}
			yield return (object)new WaitForSeconds(0.1f);
		}
		battleConfig.Red = battleConfig.Red.Clone();
		BattleFieldLogic.UpdateFormationUnits(GameManagers.Instance, Level, Team.Red, battleConfig.Red);
		battleConfig.Red.isRefresh = true;
		battleConfig.Blue.isRefresh = false;
		base.Contexts.config.ReplaceBattleConfig(battleConfig.Red, battleConfig.Blue, battleConfig.BattleFieldLength);
	}

	public async void OnAnyCurrentFormation(ConfigEntity entity, Dictionary<string, Dictionary<string, string>> value)
	{
		if (Level == null || !string.IsNullOrEmpty(Level.Data.RedFormationId))
		{
			return;
		}
		Activity activity = GameManagers.Instance.ActivityManager.GetLevelActivity(Level);
		string formationContext = ((activity == null) ? Level.FormationContext : activity.FormationTag);
		for (int i = 0; i < 10; i++)
		{
			if (base.Contexts.config.hasBattleConfig)
			{
				break;
			}
			await Task.Delay(200);
		}
		if (!base.Contexts.config.hasBattleConfig)
		{
			ILRuntimeDebug.LogError("OnAnyCurrentFormation hasBattleConfig is false after delay 2000ms !");
			for (int j = 0; j < 10; j++)
			{
				if (base.Contexts.config.hasBattleConfig)
				{
					break;
				}
				await Task.Delay(200);
			}
		}
		if (!base.Contexts.config.hasBattleConfig)
		{
			ILRuntimeDebug.LogError("OnAnyCurrentFormation hasBattleConfig is false after delay 4000ms !");
		}
		BattleConfigComponent battleConfig = base.Contexts.config.battleConfig;
		battleConfig.Red = battleConfig.Red.Clone();
		battleConfig.Red.SetAllFormationIdAs(GameManagers.Instance.UserArchiveManager.GetCurrentFormation(formationContext, Level.BattleMode.ToString()));
		battleConfig.Red.isRefresh = true;
		battleConfig.Blue.isRefresh = false;
		base.Contexts.config.ReplaceBattleConfig(battleConfig.Red, battleConfig.Blue, battleConfig.BattleFieldLength);
	}

	public void BattleEnd(GetBattleResultResponse getBattleResultResponse)
	{
		if (!LevelSettling)
		{
			LevelSettling = true;
			_nextStep = async delegate
			{
				base.Contexts.Service<IUiService>().CloseAll();
				await ShowBattleBonuses(getBattleResultResponse);
			};
			if (Level.Chapter.Type == ChapterType.StoryMain && !GameManagers.Instance.UserArchiveManager.IsNewGuideMode())
			{
				CheckStoryPlayList();
				return;
			}
			_nextStep?.Invoke();
			_nextStep = null;
		}
	}

	public async Task GetBattleResultAndShowBattleBonuses()
	{
		int sub_levelindex = -1;
		if (base.Contexts.gameState.hasBattleFieldSubLevelIndex)
		{
			sub_levelindex = base.Contexts.gameState.battleFieldSubLevelIndex.value;
		}
		string battleId = GameManagers.Instance.UserArchiveManager.GetCurrentBattleId();
		CustomTaskCompletionSource<bool> taskCompletionSource = new CustomTaskCompletionSource<bool>();
		await ILRequestHelper<GetBattleResultResponse>.RequestAsync(null, () => base.Contexts.Service<INetworkService>().GetBattleResult(-1L, battleId, CurrentLevel.LevelId), async delegate(GetBattleResultResponse response)
		{
			if (!response.Result)
			{
				ILRequestHelper.ShowErrorCode(response.ErrorCode);
				taskCompletionSource.TrySetResult(result: true);
			}
			else
			{
				ResetUnitsBorn(response);
				await ShowBattleBonuses(response, sub_levelindex);
				taskCompletionSource.TrySetResult(result: true);
			}
		});
		await taskCompletionSource.Task;
	}

	private void ResetUnitsBorn(GetBattleResultResponse response)
	{
		if (response.RedTeamDeadStats == null)
		{
			return;
		}
		BattleConfig red = base.Contexts.config.battleConfig.Red;
		if (red.UnitsBorn == null)
		{
			return;
		}
		foreach (KeyValuePair<string, int> redTeamDeadStat in response.RedTeamDeadStats)
		{
			if (red.UnitsBorn.ContainsKey(redTeamDeadStat.Key))
			{
				red.UnitsBorn[redTeamDeadStat.Key] = redTeamDeadStat.Value;
			}
		}
	}

	private async Task ShowBattleBonuses(GetBattleResultResponse getBattleResultResponse, int sub_levelindex = -1)
	{
		Team winner = (Team)getBattleResultResponse.Winner;
		string battleId = GameManagers.Instance.UserArchiveManager.GetCurrentBattleId();
		Activity activityOfLevel = GameManagers.Instance.ActivityManager.GetLevelActivity(Level);
		if (activityOfLevel != null && winner == Team.Red)
		{
			GameManagers.Instance.ChapterManager.StatsInstanceLevel(activityOfLevel.ActivityId, CurrentLevel.LevelId);
		}
		Dictionary<string, object> settleParams = new Dictionary<string, object>();
		int result = ((winner == Team.Red) ? 1 : (-1));
		settleParams.Add("result", result);
		settleParams.Add("stats", GetBattleResultStats(getBattleResultResponse));
		settleParams.Add("deadStats", getBattleResultResponse.RedTeamDeadStats);
		settleParams.Add("BattleId", battleId);
		if (Level.LevelId == UiHelper.StoryMainRetreatLevelId)
		{
			base.Contexts.Service<IUiService>().OpenPanel("UI_GameEndPanelFail", settleParams);
			GameManagers.Instance.Messenger.Broadcast("LEVEL_COMPLETED", battleId, Level, (int)winner, arg4: false);
			UiHelper.StoryMainRetreatLevelId = null;
			return;
		}
		await ILRequestHelper<GetBattleBonusResponse>.RequestAsync(null, () => base.Contexts.Service<INetworkService>().GetBattleBonus(battleId, CurrentLevel.LevelId), delegate(GetBattleBonusResponse response)
		{
			if (!response.Result)
			{
				ILRequestHelper.ShowErrorCode(response.ErrorCode);
			}
			else
			{
				if (result == 1)
				{
					if (Level.BattleMode == BattleMode.MultiWaveAttackMode)
					{
						CapturedLevels.Add(CurrentLevel.LevelId);
						if (Level.HasSubLevels() && CapturedLevels.Count == Level.SubLevels.Count)
						{
							CapturedLevels.Add(Level.LevelId);
						}
					}
					else
					{
						CapturedLevels.Add(Level.LevelId);
					}
				}
				if (getBattleResultResponse.CanBackInTime)
				{
					settleParams.Add("CanBackInTime", getBattleResultResponse.CanBackInTime);
					settleParams.Add("FreeCount", getBattleResultResponse.ContractFreeBackInTimeTimes);
					settleParams.Add("Cost", getBattleResultResponse.BackInTimeCost);
				}
				Dictionary<string, List<Bonus>> dictionary = new Dictionary<string, List<Bonus>>();
				List<Bonus> list = new List<Bonus>();
				if (response.Bonuses != null && response.Bonuses.Count > 0)
				{
					foreach (KeyValuePair<string, BonusList> bonuse in response.Bonuses)
					{
						BonusList value = bonuse.Value;
						if (value != null && value.Value != null && value.Value.Count != 0)
						{
							foreach (ModelsBonus item in value.Value)
							{
								Bonus bonus = Bonus.Get(item.ItemId, item.Qty, item.Type);
								bonus.IsShining = item.IsShining;
								if (Level.BattleMode == BattleMode.MultiWaveAttackMode && bonuse.Key == CurrentLevel.LevelId && CapturedLevels.Contains(bonuse.Key))
								{
									list.Add(bonus);
								}
								else if (Level.BattleMode != BattleMode.MultiWaveAttackMode && CapturedLevels.Contains(bonuse.Key))
								{
									list.Add(bonus);
								}
								if (!dictionary.TryGetValue(bonuse.Key, out var value2))
								{
									value2 = new List<Bonus>();
									dictionary.Add(bonuse.Key, value2);
								}
								value2.Add(bonus);
							}
						}
					}
				}
				List<Bonus> list2 = new List<Bonus>();
				if (response.LotteryBonuses != null && response.LotteryBonuses.Count > 0)
				{
					foreach (KeyValuePair<string, BonusList> lotteryBonuse in response.LotteryBonuses)
					{
						BonusList value3 = lotteryBonuse.Value;
						if (value3 != null && value3.Value != null && value3.Value.Count != 0)
						{
							foreach (ModelsBonus item2 in value3.Value)
							{
								Bonus bonus2 = Bonus.Get(item2.ItemId, item2.Qty, item2.Type);
								bonus2.IsShining = item2.IsShining;
								list2.Add(bonus2);
							}
						}
					}
				}
				settleParams.Add("fixBonuses", dictionary);
				settleParams.Add("lotteryBonuses", list2);
				settleParams.Add("capturedLevels", CapturedLevels);
				if (result == 1 || Level.BattleMode == BattleMode.MultiWaveAttackMode)
				{
					GameStateContext gameState = base.Contexts.gameState;
					BattleProgressStatsComponent battleProgressStats = gameState.battleProgressStats;
					if (result == 1)
					{
						if (!base.Contexts.gameState.hasBattleFieldSubLevelIndex && Level.HasSubLevels())
						{
							battleProgressStats.clearStages = Level.SubLevels.Count;
						}
						else if (sub_levelindex == -1)
						{
							battleProgressStats.clearStages = CurrentLevelIndex + 1;
						}
						else
						{
							battleProgressStats.clearStages = sub_levelindex + 1;
						}
						if (battleProgressStats.bonusRecord == null)
						{
							battleProgressStats.bonusRecord = new List<Bonus>();
						}
						List<(string, int)> list3 = new List<(string, int)>();
						foreach (Bonus item3 in battleProgressStats.bonusRecord)
						{
							list3.Add((item3.ItemId, item3.Type));
						}
						foreach (Bonus item4 in list)
						{
							int num = list3.IndexOf((item4.ItemId, item4.Type));
							if (num == -1)
							{
								list3.Add((item4.ItemId, item4.Type));
								battleProgressStats.bonusRecord.Add(item4);
							}
							else
							{
								battleProgressStats.bonusRecord[num].Merge(item4);
							}
						}
					}
					if (Level.BattleMode == BattleMode.MultiWaveAttackMode && Level.HasSubLevels() && Level.SubLevels.Count > battleProgressStats.clearStages && result == 1)
					{
						List<Bonus> list4 = new List<Bonus>();
						if (response.Bonuses != null)
						{
							foreach (KeyValuePair<string, BonusList> bonuse2 in response.Bonuses)
							{
								if (!(bonuse2.Key != CurrentLevel.LevelId))
								{
									BonusList value4 = bonuse2.Value;
									if (value4 != null && value4.Value != null && value4.Value.Count != 0)
									{
										List<Bonus> list5 = new List<Bonus>();
										foreach (ModelsBonus item5 in value4.Value)
										{
											Bonus bonus3 = Bonus.Get(item5.ItemId, item5.Qty, item5.Type);
											bonus3.IsShining = item5.IsShining;
											list5.Add(bonus3);
										}
										list4.AddRange(list5);
									}
								}
							}
						}
						settleParams.Add("Name", LanguagesManager.GetDesc("CsharpCodeZhTcText803"));
						settleParams.Add("Show", true);
						settleParams.Add("Items", list4);
						base.Contexts.Service<IUiService>().OpenPanel("UI_TakeItems", settleParams);
					}
					else
					{
						settleParams.Add("stages", Level.SubLevels.Count);
						settleParams.Add("clearStages", battleProgressStats.clearStages);
						settleParams.Add("level", Level);
						base.Contexts.Service<IUiService>().OpenPanel("UI_GameEndPanelVictory", settleParams);
					}
					if (Level.BattleMode != BattleMode.MultiWaveAttackMode || result == 1)
					{
						List<string> chapterLevelProgress = GameManagers.Instance.UserArchiveManager.GetChapterLevelProgress(Level.ChapterId);
						bool flag = chapterLevelProgress == null || !chapterLevelProgress.Contains(Level.LevelId);
						if (Level.HasSubLevels())
						{
							foreach (string subLevel in Level.SubLevels)
							{
								ChapterManager.Levels.TryGetValue(subLevel, out var level);
								level.Accomplish(GameManagers.Instance);
							}
						}
						Level.Accomplish(GameManagers.Instance);
						GameManagers.Instance.Messenger.Broadcast("LEVEL_COMPLETED", battleId, CurrentLevel, (int)winner, flag);
						if (Level.HasSubLevels() && battleProgressStats.clearStages >= Level.SubLevels.Count)
						{
							GameManagers.Instance.Messenger.Broadcast("LEVEL_COMPLETED", battleId, Level, (int)winner, flag);
						}
						chapterLevelProgress = GameManagers.Instance.UserArchiveManager.GetChapterLevelProgress(Level.ChapterId);
						if (Chapter.Level_IDs.Count <= chapterLevelProgress.Count)
						{
							GameManagers.Instance.Messenger.Broadcast("CHAPTER_COMPLETE", Level.ChapterId, flag);
						}
					}
					else
					{
						GameManagers.Instance.Messenger.Broadcast("LEVEL_COMPLETED", battleId, Level, (int)winner, arg4: false);
					}
				}
				else
				{
					base.Contexts.Service<IUiService>().OpenPanel("UI_GameEndPanelFail", settleParams);
					GameManagers.Instance.Messenger.Broadcast("LEVEL_COMPLETED", battleId, Level, (int)winner, arg4: false);
				}
			}
		});
	}

	public void INTERNAL_RESET(bool showStrategyReminder = false)
	{
		ClearAllGameObject();
		CommandFactory.CreateOpenSceneCommand("BattleField", new SceneBattleFieldArguments(new Dictionary<string, object>
		{
			{ "LevelId", Level.LevelId },
			{ "Asset", "Prefabs/BattleField" },
			{ "ForceCloseOtherUi", false },
			{ "TaskCompletionSource", null },
			{ "SHOW_LEVEL_STRATEGY_REMINDER", showStrategyReminder }
		}));
	}

	public static Dictionary<Team, BattleResultStats> GetBattleResultStats(GetRankBattleResultResponse response)
	{
		Dictionary<Team, BattleResultStats> dictionary = new Dictionary<Team, BattleResultStats>();
		dictionary.Add(Team.Red, new BattleResultStats
		{
			Units = GetUnitsFromBattleResultResponse(response.RedTeamBornRecords),
			UnitsTotal = GetUnitsTotalFromBattleResultResponse(response.RedTeamBornRecords),
			UnitsDead = response.RedTeamDeadStats,
			UnitsDamage = new Dictionary<string, float>(response.RedTeamDamageStats),
			CurrentHp = response.RedTeamHp.Sum((List<float> hp) => hp.Sum()),
			TotalHp = response.RedTeamHpTotal
		});
		dictionary.Add(Team.Blue, new BattleResultStats
		{
			Units = GetUnitsFromBattleResultResponse(response.BlueTeamBornRecords),
			UnitsTotal = GetUnitsTotalFromBattleResultResponse(response.BlueTeamBornRecords),
			UnitsDead = response.BlueTeamDeadStats,
			UnitsDamage = new Dictionary<string, float>(response.BlueTeamDamageStats),
			CurrentHp = response.BlueTeamHp.Sum((List<float> hp) => hp.Sum()),
			TotalHp = response.BlueTeamHpTotal
		});
		return dictionary;
	}

	public void GetRankBattleResult()
	{
		string battleId = GameManagers.Instance.UserArchiveManager.GetCurrentBattleId();
		ILRequestHelper<GetRankBattleResultResponse>.Request(null, () => base.Contexts.Service<INetworkService>().GetRankBattleResult(-1L, battleId), delegate(GetRankBattleResultResponse response)
		{
			if (!response.Result)
			{
				if (response.ErrorCode == 0)
				{
					ILRequestHelper.ShowErrorCode(80000003);
				}
				else
				{
					ILRequestHelper.ShowErrorCode(response.ErrorCode);
				}
				SharedMessenger.Broadcast("PVP_RANK_GET_BATTLE_RESULT_FAILED", response.ErrorCode);
				if (response.ErrorCode == 80032002)
				{
					if (GetRankBattleRetryCnt++ == 5)
					{
						ILRuntimeDebug.LogError($"QuickPlayReplayService GetRankBattle {QuickPlayReplayService.info.BattleId} Failed, ErrorCode={response.ErrorCode}, retryCnt={GetRankBattleRetryCnt}");
					}
					ScriptApi.CreateTimer(3f, delegate
					{
						GetRankBattleResult();
					});
				}
				else
				{
					GetRankBattleRetryCnt = 0;
					ILRuntimeDebug.LogError($"QuickPlayReplayService GetRankBattle {QuickPlayReplayService.info.BattleId} Failed, ErrorCode={response.ErrorCode}");
					RankDataHelper.ReturnLadderPanelOnGetRankBattleResultFailed(battleId);
				}
			}
			else
			{
				GetRankBattleRetryCnt = 0;
				ProcessRankBattleResult(response, battleId);
			}
		}, 1f);
	}

	public void ProcessRankBattleResult(GetRankBattleResultResponse response, string battleId)
	{
		Team winner = (Team)response.Winner;
		GameManagers.Instance.UserArchiveManager.SaveLevelEnemiesHp(Level, winner, response.BlueTeamHp);
		RankDataHelper.SetPvpRankProgressCdFinishAt(((response.TargetUserId == 0) ? (-1 * response.BlueTeamRank) : response.TargetUserId).ToString(), response.CdFinishAt);
		RankDataHelper.SetPvpRankProgressAttackBuffCnt(0);
		int num = ((winner == Team.Red) ? 1 : (-1));
		Dictionary<Team, BattleResultStats> battleResultStats = GetBattleResultStats(response);
		RankDataHelper.UpdateRankBattleReplayResult(battleId, num, battleResultStats);
		Dictionary<string, object> dictionary = new Dictionary<string, object>
		{
			{ "BattleResult", num },
			{ "BattleStats", battleResultStats },
			{ "BattleId", battleId }
		};
		if (num == 1)
		{
			int blueTeamRank = response.BlueTeamRank;
			Dictionary<string, int> topRankUpBonus = RankDataHelper.GetTopRankUpBonus(blueTeamRank);
			if (topRankUpBonus != null)
			{
				dictionary.Add("RankUpBonus", topRankUpBonus);
				string rankUpRewardId = topRankUpBonus.Keys.ToList()?[0];
				int rankUpRewardValue = topRankUpBonus.Values.ToList()[0];
				if (blueTeamRank <= 3 && response.RedTeamRank > 3)
				{
					ThinkingDataHelper.Instance.PvpTopBattleUnlocked();
				}
				ThinkingDataHelper.Instance.PvpBattleCompleted(rankUpRewardId, rankUpRewardValue, blueTeamRank);
			}
			else
			{
				ThinkingDataHelper.Instance.PvpBattleCompleted("", 0, blueTeamRank);
			}
			dictionary.Add("NewRank", blueTeamRank);
			RankDataHelper.LastBattleRankUp = true;
		}
		else
		{
			ThinkingDataHelper.Instance.PvpBattleFailed();
		}
		UI_ShowRankBattleBuff.ShowRankBattleBuffPanel?.End();
		dictionary.Add("Winner", response.Winner);
		if (UI_PvPBattleResultAnimationEffect.PvPBattleResultAnimationCoroutine != null)
		{
			FGUIManager.Instance.CloseIEnumerator(UI_PvPBattleResultAnimationEffect.PvPBattleResultAnimationCoroutine);
		}
		if (UI_PvPBattleResultAnimationEffect.PvPBattleResultAnimationEffectPanel != null)
		{
			UI_PvPBattleResultAnimationEffect.PvPBattleResultAnimationCoroutine = FGUIManager.Instance.OpenIEnumerator(UI_PvPBattleResultAnimationEffect.PvPBattleResultAnimationEffectPanel?.PlayEndEffect(dictionary));
		}
		if (UI_Battle.BattlePanel != null)
		{
			((GObject)UI_Battle.BattlePanel).alpha = 0f;
			((GObject)UI_Battle.BattlePanel).visible = false;
		}
		ClientBattleFieldLogic.UpdateSoldierStockWhenBattleEnd(GameManagers.Instance, response.RedTeamDeadStats);
	}

	public void GetBattleResult(bool try_again = true)
	{
		string battleId = GameManagers.Instance.UserArchiveManager.GetCurrentBattleId();
		ILRequestHelper<GetBattleResultResponse>.Request(null, () => base.Contexts.Service<INetworkService>().GetBattleResult(-1L, battleId, CurrentLevel.LevelId), delegate(GetBattleResultResponse response)
		{
			if (!response.Result)
			{
				if (try_again)
				{
					ILRuntimeDebug.LogError(battleId + " response Result is False,Now Try Again");
					ScriptApi.CreateTimer(1f, delegate
					{
						GetBattleResult(try_again: false);
					});
				}
				else
				{
					ILRequestHelper.ShowErrorCode(response.ErrorCode);
				}
			}
			else
			{
				ProcessBattleResult(response, battleId);
			}
		}, 1f);
	}

	public void ProcessBattleResult(GetBattleResultResponse response, string battleId)
	{
		Team winner = (Team)response.Winner;
		GameManagers.Instance.UserArchiveManager.SaveLevelEnemiesHp(Level, winner, response.BlueTeamHp);
		Activity levelActivity = GameManagers.Instance.ActivityManager.GetLevelActivity(Level);
		List<string> soldierIdsNeedSync = new List<string>();
		if (levelActivity != null && levelActivity.Type == ActivityType.TreasureHunt)
		{
			ClientBattleFieldLogic.UpdateSoldierStockWhenTreasureHuntBattleEnd(GameManagers.Instance, response.RedTeamDeadStats);
			soldierIdsNeedSync = new List<string>();
			foreach (KeyValuePair<string, int> curSoldier in LegendItemDungeonUiHelper.CurSoldiers)
			{
				soldierIdsNeedSync.Add(curSoldier.Key);
			}
		}
		else
		{
			if (CurrentLevel.ChapterId != "C1000" && CurrentLevel.ChapterId != "C10000" && CurrentLevel.ChapterId != "C10001" && CurrentLevel.ChapterId != "C1000" && CurrentLevel.ChapterId != "C10002")
			{
				ClientBattleFieldLogic.UpdateSoldierStockWhenBattleEnd(GameManagers.Instance, response.RedTeamDeadStats);
			}
			if (response.RedTeamDeadStats != null)
			{
				soldierIdsNeedSync.AddRange(response.RedTeamDeadStats.Keys.ToList());
			}
		}
		ILRequestHelper<SyncStockResponse>.Request(null, () => GameController.Contexts.Service<INetworkService>().SyncStock(-1L, syncAllStock: false, soldierIdsNeedSync), delegate(SyncStockResponse syncStockResponse)
		{
			if (!syncStockResponse.Result)
			{
				ILRuntimeDebug.LogError("战斗结束，同步士兵库存失败");
				ILRequestHelper.ShowErrorCode(response.ErrorCode);
				return;
			}
			foreach (KeyValuePair<string, int> stock in syncStockResponse.Stocks)
			{
				string key = stock.Key;
				int value = stock.Value;
				GameManagers.Instance.StockController.SetStock(key, value, StockInContext.AutoFill);
			}
		}, 1f);
		GameManagers.Instance.Messenger.Broadcast("BEFORE_LEVEL_COMPLETED", Level, (int)winner);
		ScriptApi.CreateTimer(base.Contexts, 2f, delegate
		{
			BattleEnd(response);
		});
	}

	public void Destroy(GameEntity entity)
	{
		ClearAllGameObject();
		base.Contexts.Service<IBattleFieldService>().ClearBattleConfig();
		if (base.Contexts.config.hasBattleConfig)
		{
			base.Contexts.config.RemoveBattleConfig();
		}
	}

	public void ClearUnits(Team team = Team.None)
	{
		IGroup<GameEntity> val = ((Context<GameEntity>)base.Contexts.game).GetGroup((IMatcher<GameEntity>)(object)((IAnyOfMatcher<GameEntity>)(object)GameMatcher.AllOf(GameMatcher.GameObject)).NoneOf(new IMatcher<GameEntity>[1] { GameMatcher.BuildingUnit }));
		val.GetEntities(_buffer);
		ClientBattleFieldLogic.ClearUnits(_buffer);
	}

	public static string[,] GetUnitsFromBattleResultResponse(List<UnitBornRecord[]> records)
	{
		if (records == null)
		{
			return null;
		}
		int count = records.Count;
		string[,] array = new string[count, 12];
		for (int i = 0; i < count; i++)
		{
			for (int j = 0; j < records[i].Length; j++)
			{
				array[i, j] = records[i][j].UnitId;
			}
		}
		return array;
	}

	public static int[,] GetUnitsTotalFromBattleResultResponse(List<UnitBornRecord[]> records)
	{
		if (records == null)
		{
			return null;
		}
		int count = records.Count;
		int[,] array = new int[count, 12];
		for (int i = 0; i < count; i++)
		{
			for (int j = 0; j < records[i].Length; j++)
			{
				array[i, j] = records[i][j].Born;
			}
		}
		return array;
	}

	public static Dictionary<Team, BattleResultStats> GetBattleResultStats(GetBattleResultResponse response)
	{
		Dictionary<Team, BattleResultStats> dictionary = new Dictionary<Team, BattleResultStats>();
		if (response.RedTeamDeadStats != null && response.RedTeamDeadStats != null && response.RedTeamHp != null)
		{
			dictionary.Add(Team.Red, new BattleResultStats
			{
				Units = GetUnitsFromBattleResultResponse(response.RedTeamBornRecords),
				UnitsTotal = GetUnitsTotalFromBattleResultResponse(response.RedTeamBornRecords),
				UnitsDead = response.RedTeamDeadStats,
				UnitsDamage = new Dictionary<string, float>(response.RedTeamDamageStats),
				CurrentHp = response.RedTeamHp.Sum((List<float> hp) => hp.Sum()),
				TotalHp = response.RedTeamHpTotal
			});
		}
		if (response.BlueTeamDeadStats != null && response.BlueTeamDeadStats != null && response.BlueTeamHp != null)
		{
			dictionary.Add(Team.Blue, new BattleResultStats
			{
				Units = GetUnitsFromBattleResultResponse(response.BlueTeamBornRecords),
				UnitsTotal = GetUnitsTotalFromBattleResultResponse(response.BlueTeamBornRecords),
				UnitsDead = response.BlueTeamDeadStats,
				UnitsDamage = new Dictionary<string, float>(response.BlueTeamDamageStats),
				CurrentHp = response.BlueTeamHp.Sum((List<float> hp) => hp.Sum()),
				TotalHp = response.BlueTeamHpTotal
			});
		}
		return dictionary;
	}

	public static Dictionary<Team, BattleResultStats> GetGvGBattleResultStats(GetGvGBattleResultResponse response)
	{
		Dictionary<Team, BattleResultStats> dictionary = new Dictionary<Team, BattleResultStats>();
		dictionary.Add(Team.Red, new BattleResultStats
		{
			Units = GetUnitsFromBattleResultResponse(response.RedTeamBornRecords),
			UnitsTotal = GetUnitsTotalFromBattleResultResponse(response.RedTeamBornRecords),
			UnitsDead = response.RedTeamDeadStats,
			UnitsDamage = new Dictionary<string, float>(response.RedTeamDamageStats),
			CurrentHp = response.RedTeamHp.Sum((List<float> hp) => hp.Sum()),
			TotalHp = response.RedTeamHpTotal
		});
		dictionary.Add(Team.Blue, new BattleResultStats
		{
			Units = GetUnitsFromBattleResultResponse(response.BlueTeamBornRecords),
			UnitsTotal = GetUnitsTotalFromBattleResultResponse(response.BlueTeamBornRecords),
			UnitsDead = response.BlueTeamDeadStats,
			UnitsDamage = new Dictionary<string, float>(response.BlueTeamDamageStats),
			CurrentHp = response.BlueTeamHp.Sum((List<float> hp) => hp.Sum()),
			TotalHp = response.BlueTeamHpTotal
		});
		return dictionary;
	}

	public void ClearAllGameObject()
	{
		GameManagers.Instance.Messenger.Broadcast("DESTROY_BATTLE_CONTEXTS");
		_group.GetEntities(_buffer);
		ClientBattleFieldLogic.ClearUnits(_buffer);
		ClientBattleFieldLogic.ClearAllObstacles(base.Contexts);
		IGroup<GameEntity> val = ((Context<GameEntity>)base.Contexts.game).GetGroup(GameMatcher.GameObject);
		GameEntity[] entities = val.GetEntities();
		GameEntity[] array = entities;
		foreach (GameEntity gameEntity in array)
		{
			gameEntity.isDestroyable = true;
		}
		FGUIManager.Instance.BattleAudioManager?.AllAudioClipsRelease();
		foreach (Dictionary<string, Queue<GameObject>> value in UnityGameObjectPool.GetInstance().GetCache().Values)
		{
			foreach (Queue<GameObject> value2 in value.Values)
			{
				foreach (GameObject item in value2)
				{
					if (Object.op_Implicit((Object)(object)item))
					{
						Addressables.ReleaseInstance(item);
					}
				}
			}
		}
		GameController.Contexts.Service<ReplayPlayerService>().Stop();
		PlayFrameService.GetInstance().PlayFrameServiceDestroy();
	}

	private async void ClearAllGameObjectWhenLoadingUiIsShowing()
	{
		while (base.Contexts.gameState.loadingPanelStatus.value != LoadingPanelStatus.Showing)
		{
			await Task.Delay(1);
		}
		ClearAllGameObject();
	}

	public void EnterNextLevel()
	{
		ClearAllGameObjectWhenLoadingUiIsShowing();
		if (Chapter == null || (Chapter.Type != ChapterType.StoryMain && Chapter.Type != ChapterType.StorySub))
		{
			CommandFactory.CreateOpenSceneCommand("MainCity.Right", new SceneArguments(new Dictionary<string, object>
			{
				{ "ForceCloseOtherUi", true },
				{ "TaskCompletionSource", null },
				{
					"LoadingAnimationDirection",
					LoadingAnimationDirection.Left
				},
				{ "OpenUiOnReturn", Level.FromUi },
				{ "UiParamsOnReturn", Level.FromUiParams }
			}));
			return;
		}
		string nextLevelIdOfLevel = ChapterManager.GetNextLevelIdOfLevel(Level);
		if (nextLevelIdOfLevel == null)
		{
			switch (Chapter.Type)
			{
			case ChapterType.StoryMain:
				base.Contexts.Service<IUiService>().OpenPanel("UI_WorldMapPanel", new Dictionary<string, object> { { "Region", Chapter.Region } });
				break;
			case ChapterType.RepeatableInstance:
			case ChapterType.RepeatableInstanceOffensive:
			case ChapterType.RepeatableInstanceDefensive:
			case ChapterType.RepeatableInstancePortal:
			{
				ActivityManager activityManager = GameManagers.Instance.ActivityManager;
				if (activityManager.GetActivitiesByType(ActivityType.DefenseInstance, _activitiesBuffer).Count >= 1 || activityManager.GetActivitiesByType(ActivityType.AttackInstance, _activitiesBuffer).Count >= 1 || activityManager.GetActivitiesByType(ActivityType.TimeLimitInstance, _activitiesBuffer).Count >= 1)
				{
					CommandFactory.CreateOpenSceneCommand("MainCity.Right", new SceneArguments(new Dictionary<string, object>
					{
						{ "ForceCloseOtherUi", true },
						{ "TaskCompletionSource", null },
						{
							"LoadingAnimationDirection",
							LoadingAnimationDirection.Left
						},
						{ "OpenUiOnReturn", Level.FromUi },
						{ "UiParamsOnReturn", Level.FromUiParams }
					}));
				}
				break;
			}
			case ChapterType.StorySub:
			case ChapterType.Challenge:
			case ChapterType.StoryTransition:
			case ChapterType.RepeatableInstanceTransition:
				break;
			}
		}
		else
		{
			CommandFactory.CreateOpenSceneCommand("BattleField", new SceneBattleFieldArguments(new Dictionary<string, object>
			{
				{ "LevelId", nextLevelIdOfLevel },
				{ "Asset", "Prefabs/BattleField" },
				{ "ForceCloseOtherUi", false },
				{ "TaskCompletionSource", null }
			}));
		}
	}
}
