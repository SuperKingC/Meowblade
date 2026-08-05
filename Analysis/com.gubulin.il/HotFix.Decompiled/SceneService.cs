using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Assets.Scripts.Managers;
using Entitas;
using GameMaths;
using HotFix.Sources.Base.Scripts.MainCity;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Model;
using Shift.Legion.ClientApi.Models;
using Shift.Legion.ClientApi.Protocol;
using Shift.Legion.ClientApi.Protocol.UserAction;
using Shift.Legion.ClientApi.Sources.Extensions;
using Shift.Legion.Common.Enums;
using Shift.Legion.Common.Helpers;
using Shift.Legion.Common.Managers;
using Shift.Legion.Common.Models;
using Shift.Legion.Common.Services;
using Spine.Unity;
using UI;
using UI.BlackMarketer;
using UI.LegendItemDungeon;
using UI.MainCity;
using UI.MilitaryIntelligence;
using UI.MonthCard;
using UI.RollingMarquee;
using UI.Tips;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class SceneService : BaseSceneService
{
	private GameStateContext _gameState;

	private SceneArguments _lastSceneArguments;

	private GameEntity _lastScene;

	private string _lastSceneName;

	private int _loadingTimeoutTimer = -1;

	private Contexts _contexts;

	private GameStateEntity _eventListener;

	private bool _isStoryEndListenerAdded;

	private bool _isFirstEnterBattleField = true;

	private GameObject _mainCity;

	private bool _EnableMaincity_Monobehaviour = false;

	private bool _enableSyncProduce = false;

	private List<SkeletonAnimation> All_SkeletonAnimation;

	private List<MoltenCoreWorkerController> All_MoltenCoreWorkerController;

	private List<WorkerController> All_WorkerController;

	private Dictionary<string, Dictionary<int, Workbench>> All_Workbench;

	private List<MonoBehaviour> All_MonoBehaviour;

	private bool _firstSyncAfterEnteredMainCity = false;

	private List<string> PreLoad_FX = new List<string> { "FX/Prefabs/explosion_black" };

	private ArrayList List_Hadnler;

	private GameObject mainCity = null;

	public override GameObject MainCityObj => mainCity;

	public SceneService(Contexts contexts)
	{
		_contexts = contexts;
		_gameState = _contexts.gameState;
	}

	public override void Init()
	{
	}

	public override bool get_EnableMaincity_Monobehaviour()
	{
		return _EnableMaincity_Monobehaviour;
	}

	public override bool GetEnableMainCityProduce()
	{
		return _enableSyncProduce;
	}

	public override List<SkeletonAnimation> Get_All_SkeletonAnimation()
	{
		return All_SkeletonAnimation;
	}

	public override List<MoltenCoreWorkerController> Get_All_MoltenCoreWorkerController()
	{
		return All_MoltenCoreWorkerController;
	}

	public override List<WorkerController> Get_All_WorkerController()
	{
		return All_WorkerController;
	}

	public override Dictionary<string, Dictionary<int, Workbench>> Get_All_All_Workbench()
	{
		return All_Workbench;
	}

	public override void EnableMainCity(Dictionary<MainCityEnableCommand, bool> b)
	{
		if (b.TryGetValue(MainCityEnableCommand.Produce, out var value))
		{
			if (value)
			{
				GameManagers.Instance.StockController.NeedGetAllProduceStatus = true;
				GameManagers.Instance.StockController.NeedSyncProduce = true;
			}
			_enableSyncProduce = value;
		}
		if (b.TryGetValue(MainCityEnableCommand.MonoBehaviour, out var value2))
		{
			_EnableMaincity_Monobehaviour = value2;
			ChangeMonoBehaviourEnable(value2);
		}
	}

	private void ChangeMonoBehaviourEnable(bool enable)
	{
		if (All_WorkerController == null)
		{
			All_WorkerController = new List<WorkerController>();
		}
		if (All_Workbench == null)
		{
			All_Workbench = new Dictionary<string, Dictionary<int, Workbench>>();
		}
		if (All_MonoBehaviour == null)
		{
			All_MonoBehaviour = new List<MonoBehaviour>();
		}
		if (All_MoltenCoreWorkerController == null)
		{
			All_MoltenCoreWorkerController = new List<MoltenCoreWorkerController>();
		}
		if (All_SkeletonAnimation == null)
		{
			All_SkeletonAnimation = new List<SkeletonAnimation>();
		}
		foreach (WorkerController item in All_WorkerController)
		{
			((Behaviour)item).enabled = enable;
		}
		foreach (Dictionary<int, Workbench> value in All_Workbench.Values)
		{
			foreach (Workbench value2 in value.Values)
			{
				((Behaviour)value2).enabled = enable;
				if (!enable)
				{
					((MonoBehaviour)value2).StopAllCoroutines();
				}
			}
		}
		foreach (SkeletonAnimation item2 in All_SkeletonAnimation)
		{
			((Behaviour)item2).enabled = enable;
		}
		for (int num = All_MonoBehaviour.Count - 1; num >= 0; num--)
		{
			if ((Object)(object)All_MonoBehaviour[num] == (Object)null)
			{
				All_MonoBehaviour.RemoveAt(num);
			}
			else
			{
				((Behaviour)All_MonoBehaviour[num]).enabled = enable;
			}
		}
	}

	public override bool get_FirstSyncAfterEnteredMainCity()
	{
		return _firstSyncAfterEnteredMainCity;
	}

	public override void SyncedAfterEnteredMainCity()
	{
		_firstSyncAfterEnteredMainCity = true;
	}

	public override void AddMonoBehaviour(MonoBehaviour m)
	{
		if (All_MonoBehaviour == null)
		{
			All_MonoBehaviour = new List<MonoBehaviour>();
		}
		All_MonoBehaviour.Add(m);
	}

	public override void AddWorkerController(WorkerController w)
	{
		if (All_WorkerController == null)
		{
			All_WorkerController = new List<WorkerController>();
		}
		All_WorkerController.Add(w);
	}

	public override void AddMoltenCoreWorker(MoltenCoreWorkerController w)
	{
		if (All_MoltenCoreWorkerController == null)
		{
			All_MoltenCoreWorkerController = new List<MoltenCoreWorkerController>();
		}
		All_MoltenCoreWorkerController.Add(w);
	}

	public override void AddWorkbench(string buildingtype, int workbench_index, Workbench w)
	{
		if (All_Workbench == null)
		{
			All_Workbench = new Dictionary<string, Dictionary<int, Workbench>>();
		}
		if (!All_Workbench.ContainsKey(buildingtype))
		{
			All_Workbench.Add(buildingtype, new Dictionary<int, Workbench>());
		}
		All_Workbench[buildingtype].Add(workbench_index, w);
	}

	public override void AddSkeletonAnimation(SkeletonAnimation s)
	{
		if (All_SkeletonAnimation == null)
		{
			All_SkeletonAnimation = new List<SkeletonAnimation>();
		}
		All_SkeletonAnimation.Add(s);
	}

	public override void Destroy()
	{
		_contexts = null;
		_gameState = null;
		if ((Object)(object)_mainCity != (Object)null)
		{
			Object.Destroy((Object)(object)_mainCity);
			_mainCity = null;
		}
	}

	public override void AddEventsListener()
	{
		_eventListener = ((Context<GameStateEntity>)_gameState).CreateEntity();
		_eventListener.AddAnyLoadingPanelStatusListener(this);
		_eventListener.AddAnyLoadingProgressListener(this);
	}

	public override void RemoveEventsListener()
	{
		_eventListener.RemoveAnyLoadingPanelStatusListener(this);
		_eventListener.RemoveAnyLoadingProgressListener(this);
		((Entity)_eventListener).Destroy();
		RemoveStoryEndListener();
	}

	private void AddStoryEndListener()
	{
		RemoveStoryEndListener();
		SharedMessenger.AddListener<string>("STORY_END", _contexts.Service<IBattleFieldService>().CheckStoryPlayList);
		_isStoryEndListenerAdded = true;
	}

	private void RemoveStoryEndListener()
	{
		if (_isStoryEndListenerAdded)
		{
			SharedMessenger.RemoveListener<string>("STORY_END", _contexts.Service<IBattleFieldService>().CheckStoryPlayList);
			_isStoryEndListenerAdded = false;
		}
	}

	public override GameEntity OpenScene(string sceneName, SceneArguments arguments)
	{
		//IL_009d: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a2: Unknown result type (might be due to invalid IL or missing references)
		if (_gameState.hasLoadingPanelStatus && _gameState.loadingPanelStatus.value != LoadingPanelStatus.Closed)
		{
			return null;
		}
		_lastSceneArguments = arguments;
		_lastSceneName = sceneName;
		_gameState.isLoadingShowAllSoldier = arguments.LoadingShowAllSoldier;
		_gameState.ReplaceLoadingAnimationDirection(arguments.LoadingAnimationDirection);
		GameEntity gameEntity = (_lastScene = ((Context<GameEntity>)_contexts.game).CreateEntity());
		gameEntity.ReplaceSceneName(sceneName);
		gameEntity.ReplaceSceneArguments(arguments);
		if (arguments is SceneBattleFieldArguments sceneBattleFieldArguments)
		{
			gameEntity.ReplacePosition(Vector3.op_Implicit(Vector3.zero));
			gameEntity.ReplaceLevelId(sceneBattleFieldArguments.LevelId);
			gameEntity.ReplaceLevelInst(sceneBattleFieldArguments.LevelInst);
			gameEntity.ReplaceAsset(sceneBattleFieldArguments.Asset);
			gameEntity.ReplaceBattleCost(sceneBattleFieldArguments.BattleCost);
		}
		gameEntity.isSceneLoaded = false;
		gameEntity.isVisible = false;
		return gameEntity;
	}

	public override async void Load()
	{
		TimerEntity entityWithId = _contexts.timer.GetEntityWithId(_loadingTimeoutTimer);
		if (entityWithId != null)
		{
			((Entity)entityWithId).Destroy();
		}
		GameEntity entity = _lastScene;
		if (entity != null && entity.hasSceneArguments && entity.sceneArguments.value.ForceCloseOtherUi)
		{
			GameController.Contexts.Service<IUiService>().CloseAll();
		}
		_gameState.ReplaceLoadingTotal(100);
		_gameState.ReplaceLoadingProgress(0);
		if (entity != null && entity.hasSceneName && entity.sceneName.value == "BattleField")
		{
			bool isFirstEnterBattleField = _isFirstEnterBattleField;
			if (isFirstEnterBattleField)
			{
				_isFirstEnterBattleField = false;
			}
			AddStoryEndListener();
			Level level = ((entity.hasLevelInst && entity.levelInst.value != null) ? entity.levelInst.value : GameManagers.Instance.ChapterManager.GetLevelInstance(entity.levelId.value));
			if (entity.hasSceneArguments)
			{
				level.FromUi = entity.sceneArguments.value.OpenUiOnReturn;
				level.FromUiParams = entity.sceneArguments.value.UiParamsOnReturn;
			}
			int _getFormationInfoCnt = 0;
			while (true)
			{
				GetFormationInfoResponse formationInfoResponse = await GameController.Contexts.Service<INetworkService>().GetFormationInfo(-1L, level.LevelId);
				if (formationInfoResponse.Result)
				{
					Activity activity = await GameManagers.Instance.ActivityManager.GetLevelActivityAsync(level);
					string formationContext = ((activity == null) ? level.FormationContext : activity.FormationTag);
					string subContext = level.BattleMode.ToString();
					if (string.IsNullOrEmpty(formationInfoResponse.FormationId))
					{
						SharedMessenger.Broadcast("SHOW_TIPS", new List<string> { LanguagesManager.GetDesc("CsharpCodeZhTcText721") }, 121, arg3: false);
					}
					else
					{
						GameManagers.Instance.UserArchiveManager.SetCurrentFormation(formationContext, subContext, formationInfoResponse.FormationId, fromServer: true);
					}
					if (formationInfoResponse.UnitsId == null || formationInfoResponse.UnitsId.Count < 1)
					{
						SharedMessenger.Broadcast("SHOW_TIPS", new List<string> { LanguagesManager.GetDesc("CsharpCodeZhTcText722") }, 121, arg3: false);
						break;
					}
					Dictionary<string, string> unitsId = new Dictionary<string, string>();
					for (int i = 0; i < formationInfoResponse.UnitsId.Count; i++)
					{
						unitsId.Add(value: formationInfoResponse.UnitsId[i], key: $"Pos{i}");
					}
					GameManagers.Instance.UserArchiveManager.SetBattleFormation(formationContext, subContext, unitsId);
					break;
				}
				if (_getFormationInfoCnt++ < 3)
				{
					continue;
				}
				SharedMessenger.Broadcast("SHOW_TIPS", new List<string> { LanguagesManager.GetDesc("CsharpCodeZhTcText721") }, 121, arg3: false);
				break;
			}
			_gameState.ReplaceBattleFieldLevel(level);
			_gameState.ReplaceBattleFieldSubLevelIndex(0);
			if (isFirstEnterBattleField && (level.ChapterId == "C1000" || level.ChapterId == "C10000" || level.ChapterId == "C10001" || level.ChapterId == "C1000" || level.ChapterId == "C10002"))
			{
				ThinkingDataHelper.Instance.UserEnterGameTrack();
				FGUIManager.Instance.curLegionSizeLimit = GameController.Contexts.game.dungeon.value.LegionSizeLimit;
			}
		}
		else
		{
			RemoveStoryEndListener();
			if (!_gameState.isMainCityInitialized)
			{
				InitMainCity();
			}
		}
		if (entity != null && entity.hasSceneName && entity.sceneName.value != "BattleField")
		{
			foreach (GameObject go in SpawnManager.Instance.CacheBattleTag)
			{
				if ((Object)(object)go != (Object)null)
				{
					UnitySkeletonAnimator usk = go.GetComponent<UnitySkeletonAnimator>();
					if ((Object)(object)usk != (Object)null)
					{
						usk.OnUnSpawn();
					}
					Object.Destroy((Object)(object)go);
				}
			}
			foreach (List<GameObject> gos in SpawnManager.Instance.PoolObjects.Values)
			{
				foreach (GameObject go2 in gos)
				{
					if ((Object)(object)go2 != (Object)null)
					{
						Object.Destroy((Object)(object)go2);
					}
				}
				gos.Clear();
			}
			SpawnManager.Instance.CacheBattleTag.Clear();
			for (int j = 0; j < GDMgr.WaitToRelease.Count; j++)
			{
				if (GDMgr.WaitToRelease.TryDequeue(out var handler) && ((AsyncOperationHandle)(ref handler.OperactionHandler)).IsValid())
				{
					Addressables.Release(handler.OperactionHandler);
				}
				handler = null;
			}
			Resources.UnloadUnusedAssets();
		}
		if (entity != null && entity.hasSceneName && entity.sceneName.value != "BattleField")
		{
			_loadingTimeoutTimer = ScriptApi.CreateTimer(1.5f, delegate
			{
				_gameState.ReplaceLoadingProgress(100);
			});
		}
	}

	public override void OnSceneLoaded(GameEntity entity)
	{
		//IL_0186: Unknown result type (might be due to invalid IL or missing references)
		//IL_018b: Unknown result type (might be due to invalid IL or missing references)
		if (entity == null || !((Entity)entity).isEnabled || entity.isDestroyable || entity.isDestroyed || _gameState.loadingTotal.value > _gameState.loadingProgress.value || _gameState.loadingPanelStatus.value != LoadingPanelStatus.Showing)
		{
			return;
		}
		entity.isVisible = true;
		entity.isSceneLoaded = true;
		Singleton<CameraService>.Instance.SwitchToScene(_lastSceneName);
		CurrentScene = _lastSceneName;
		IsSceneBattleField = CurrentScene == "BattleField";
		SceneArguments arguments = entity.sceneArguments.value;
		if (entity.sceneName.value == "MainCity.Left" || entity.sceneName.value == "MainCity.Right")
		{
			UnityUiService.Instance.ShowNewbieMissionPanel();
			Throne throne = (Throne)GameManagers.Instance.BuildingManager.GetBuildingByType("15");
			((ThroneController)throne.Controller).SetDirectorStatus(arguments.TimeLineMainCity != "MainCity.LordAppear");
			if (arguments.TimeLineMainCity == "MainCity.LordAppear")
			{
				GameObject mainCityObj = GameController.Contexts.Service<BaseSceneService>().MainCityObj;
				Sprite sprite = Addressables.LoadAssetAsync<Sprite>((object)"bg_r_7_noDevil").WaitForCompletion();
				Transform val = mainCityObj.transform.Find("decoration/bg_r_7");
				if ((Object)(object)val != (Object)null)
				{
					((Component)val).GetComponent<SpriteRenderer>().sprite = sprite;
				}
			}
			if (!string.IsNullOrEmpty(arguments.OpenUiOnReturn))
			{
				Dictionary<string, object> dic = new Dictionary<string, object>();
				if (arguments.UiParamsOnReturn != null)
				{
					foreach (KeyValuePair<string, object> item in arguments.UiParamsOnReturn)
					{
						dic.Add(item.Key, item.Value);
					}
				}
				object activityData;
				if (dic.TryGetValue("Activity", out var value) && value is Activity activity && (activity.CheckOverPeriod(GameManagers.Instance) || (activity.GetStatus(GameManagers.Instance) != ActivityStatus.Enabled && activity.GetStatus(GameManagers.Instance) != ActivityStatus.Settlement)))
				{
					SharedMessenger.Broadcast("SHOW_TIPS", new List<string> { LanguagesManager.GetDesc("CsharpCodeZhTcText727") + activity.Name + LanguagesManager.GetDesc("CsharpCodeZhTcText728") }, 121, arg3: false);
					switch (activity.Type)
					{
					case ActivityType.DefenseInstance:
					case ActivityType.AttackInstance:
					case ActivityType.TimeLimitInstance:
						GameController.Contexts.Service<IUiService>().OpenPanel(UI_MilitaryIntelligencePanel.Name, null);
						break;
					case ActivityType.Lottery:
					case ActivityType.BlackMarket:
					case ActivityType.LegendItemBlackMarket:
						GameController.Contexts.Service<IUiService>().OpenPanel(UI_BlackMarketerPanel.Name, null);
						break;
					case ActivityType.TreasureHunt:
						GameController.Contexts.Service<IUiService>().OpenPanel(UI_LegendItemDungeonPanel.Name, null);
						break;
					}
				}
				else if (dic.TryGetValue("Activity", out activityData))
				{
					Action<CheckActivitiesOverPeriodResponse, bool, bool> callback = null;
					GameManagers.Instance.ActivityManager.CheckActivities(null, new List<ActivityType>
					{
						ActivityType.AttackInstance,
						ActivityType.DefenseInstance,
						ActivityType.TimeLimitInstance,
						ActivityType.TreasureHunt
					}, delegate(CheckActivitiesOverPeriodResponse response, bool hasNewData, bool hasNewActivityRecord)
					{
						Activity activity2 = activityData as Activity;
						if (activity2.Type == ActivityType.TreasureHunt)
						{
							dic.Add("OpenUiOnReturn", UI_MilitaryIntelligencePanel.Name);
						}
						GameController.Contexts.Service<IUiService>().OpenPanel(arguments.OpenUiOnReturn, dic);
						callback?.Invoke(response, hasNewData, hasNewActivityRecord);
					});
				}
				else
				{
					GameController.Contexts.Service<IUiService>().OpenPanel(arguments.OpenUiOnReturn, dic);
				}
			}
			GameController.Contexts.Service<IUiService>().OpenPanel(UI_MainCity.Name, null);
			UnityUiService.Instance.InitDebugInfoPanel();
			MainCityLoaded();
		}
		arguments.LoadedCallback?.Invoke(entity.sceneName.value);
		if (entity.sceneName.value == "BattleField")
		{
			EnableMainCity(new Dictionary<MainCityEnableCommand, bool>
			{
				{
					MainCityEnableCommand.MonoBehaviour,
					false
				},
				{
					MainCityEnableCommand.Produce,
					false
				}
			});
			UnityUiService.Instance.ShowNewbieMissionPanel(isBattleField: true);
		}
		FGUIManager.Instance.BattleAudioManager?.ClearAllAudioDic();
		arguments.TaskCompletionSource?.TrySetResult(result: true);
	}

	private void Load_PreLoad()
	{
		//IL_0032: Unknown result type (might be due to invalid IL or missing references)
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Unknown result type (might be due to invalid IL or missing references)
		if (List_Hadnler == null)
		{
			List_Hadnler = new ArrayList();
		}
		foreach (string item in PreLoad_FX)
		{
			AsyncOperationHandle<GameObject> val = Addressables.LoadAssetAsync<GameObject>((object)item);
			if (val.IsValid())
			{
				List_Hadnler.Add(val);
			}
		}
	}

	private void Unload_Preload()
	{
		//IL_002d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Unknown result type (might be due to invalid IL or missing references)
		//IL_0059: Unknown result type (might be due to invalid IL or missing references)
		if (List_Hadnler == null)
		{
			return;
		}
		for (int num = List_Hadnler.Count - 1; num >= 0; num--)
		{
			AsyncOperationHandle<GameObject> val = (AsyncOperationHandle<GameObject>)List_Hadnler[num];
			if (val.IsValid() && val.IsDone && (Object)(object)val.Result != (Object)null)
			{
				Addressables.Release<GameObject>(val);
			}
		}
		List_Hadnler.Clear();
	}

	public override void Destroy(GameEntity entity)
	{
		if (entity == null || !((Entity)entity).isEnabled)
		{
			return;
		}
		entity.isDestroyable = true;
		ScriptApi.CreateTimer(1f, delegate
		{
			if (entity.sceneName.value == "BattleField")
			{
				_contexts.Service<IBattleFieldService>().Destroy(entity);
			}
			entity.isDestroyed = true;
		});
	}

	public override async void InitMainCity()
	{
		if (_gameState.isMainCityInitialized)
		{
			return;
		}
		while (!SpawnManager.Instance.FinishInit)
		{
			await Task.Delay(100);
		}
		mainCity = null;
		Dictionary<string, GameObject> cache = SpawnManager.Instance.BuildingCache;
		mainCity = Object.Instantiate<GameObject>(cache["Prefabs/Buildings/MainCity"]);
		Transform mainCity_transform = mainCity.transform;
		int child_count = mainCity_transform.childCount;
		for (int i = 0; i < child_count; i++)
		{
			Transform child = mainCity_transform.GetChild(i);
			GameObject child_go = ((Component)child).gameObject;
			if (((Object)child).name == "StockWall" || ((Object)child).name == "TurnWall")
			{
				child_go.AddComponent<HitArea>();
				HitArea _hitArea = child_go.GetComponent<HitArea>();
				_hitArea.hitData.name = "Wall";
			}
			else if (((Object)child).name == "Wall")
			{
				Transform _GenerateSackDown = child.Find("GenerateSackDown");
				Transform _GenerateSackUp = child.Find("GenerateSackUp");
				((Component)_GenerateSackDown).gameObject.AddComponent<SackFlow>();
				((Component)_GenerateSackUp).gameObject.AddComponent<SackFlow>();
				SackFlow _SackFlow_down = ((Component)_GenerateSackDown).gameObject.GetComponent<SackFlow>();
				SackFlow _SackFlow_up = ((Component)_GenerateSackUp).gameObject.GetComponent<SackFlow>();
				_SackFlow_down.bearing = "Down";
				_SackFlow_down.startPoint = _GenerateSackDown;
				_SackFlow_down.timingEnd = -1f;
				_SackFlow_down.timeUpLimit = 8f;
				_SackFlow_down.timeDownLimit = 0f;
				_SackFlow_up.bearing = "Up";
				_SackFlow_up.startPoint = _GenerateSackUp;
				_SackFlow_up.timingEnd = -1f;
				_SackFlow_up.timeUpLimit = 8f;
				_SackFlow_up.timeDownLimit = 0f;
			}
			else if (((Object)child).name == "SpringFestivalEntrance")
			{
				Object.Destroy((Object)(object)((Component)child).gameObject);
			}
			SkeletonAnimation[] mainCitySkes = child_go.GetComponentsInChildren<SkeletonAnimation>();
			SkeletonAnimation[] array = mainCitySkes;
			foreach (SkeletonAnimation ske in array)
			{
				GameController.Contexts.Service<BaseSceneService>().AddSkeletonAnimation(ske);
			}
			Camera miniCamera = GameObject.Find("MiniMapCamera").GetComponent<Camera>();
			RenderTexture rt = miniCamera.targetTexture;
			if (((rt != null) ? ((Object)rt).name : null) == "MiniMap")
			{
				miniCamera.targetTexture = null;
				((Behaviour)miniCamera).enabled = false;
				rt.Release();
			}
		}
		((Component)mainCity_transform.Find("StockWall")).gameObject.AddComponent<HitArea>();
		((Component)mainCity_transform.Find("TurnWall")).gameObject.AddComponent<HitArea>();
		if ((Object)(object)mainCity != (Object)null)
		{
			mainCity.transform.SetParent((Transform)null);
		}
		if (Object.op_Implicit((Object)(object)mainCity.transform.Find("ActivityEntrance")))
		{
			GameObject _ActivityEntrance = ((Component)mainCity.transform.Find("ActivityEntrance")).gameObject;
			ActivityEntranceController __activityEntrance = _ActivityEntrance.AddComponent<ActivityEntranceController>();
			_ActivityEntrance.AddComponent<HitArea>();
			HitArea _hitArea2 = _ActivityEntrance.GetComponent<HitArea>();
			FGUIManager.Instance.activityEntranceController = __activityEntrance;
			_hitArea2.hitData.name = "ActivityEntrance";
			_hitArea2.hitData.id = "21";
			_hitArea2.repairBuildTime = 5f;
		}
		LoadVideoEntrance(mainCity);
		LoadGiftOfLordEntrance(mainCity);
		_mainCity = mainCity;
		foreach (Building building in GameManagers.Instance.BuildingManager.Buildings.Values)
		{
			if (string.IsNullOrEmpty(building.Prefab))
			{
				continue;
			}
			Dictionary<string, object> conf = building.PrefabConfig;
			if (building.BuildingType == "18")
			{
				((PVPEntrance)building).InitBuildingGameObject(_mainCity);
			}
			else
			{
				building.GameObject = Object.Instantiate<GameObject>(cache[building.Prefab]);
				MainCityPrefabData.InitBuildingGameObject(building.GameObject);
				SkeletonAnimation[] skes = building.GameObject.GetComponentsInChildren<SkeletonAnimation>();
				SkeletonAnimation[] array2 = skes;
				foreach (SkeletonAnimation ske2 in array2)
				{
					GameController.Contexts.Service<BaseSceneService>().AddSkeletonAnimation(ske2);
				}
			}
			Vector3 pos = new Vector3(0f, 0f, 0f);
			if (conf.ContainsKey("Position"))
			{
				string[] coords = conf["Position"].ToString().Split(',');
				NumericParser.TryFloat(coords[0], out var posX);
				NumericParser.TryFloat(coords[1], out var posY);
				pos.x = posX;
				pos.y = posY;
				if (coords.Length > 2)
				{
					NumericParser.TryFloat(coords[2], out var posZ);
					pos.z = posZ;
				}
			}
			FGUIManager.Instance.BuildingsTitleInit(building);
			FGUIManager.Instance.BuildingsUpgradeBarInit(building);
			Transform parentTransform;
			if (building.Feature == "Mine" || building.Feature == "WorkShop")
			{
				parentTransform = mainCity.transform.Find("Workshop");
				((WorkShop)building).Controller = building.GameObject.GetComponent<WorkshopController>();
				((WorkshopController)((WorkShop)building).Controller).WorkShop = (WorkShop)building;
				((WorkshopController)((WorkShop)building).Controller).SetWorkbenchNominal();
				FGUIManager.Instance.BuildingsTextFloatingStageInit((WorkShop)building);
				if (building.BuildingType == "12")
				{
					building.GameObject.AddComponent<SkyPortalController>().building = building;
				}
			}
			else if (building.Feature == "Throne")
			{
				parentTransform = mainCity.transform;
				((Throne)building).Controller = building.GameObject.GetComponent<ThroneController>();
			}
			else if (building.Feature == "Camp")
			{
				((Camp)building).Controller = building.GameObject.GetComponent<CampController>();
				((CampController)((Camp)building).Controller).Init((Camp)building);
				parentTransform = mainCity.transform;
				FGUIManager.Instance.CampSlotsUiPanelInint((Camp)building);
			}
			else if (building.Feature == "Storehouse")
			{
				((Storehouse)building).Controller = building.GameObject.GetComponent<StorehouseController>();
				((StorehouseController)((Storehouse)building).Controller).storehouse = (Storehouse)building;
				parentTransform = mainCity.transform;
			}
			else if (building.Feature == "MilitaryIntelligence7")
			{
				((MilitaryIntelligence)building).Controller = building.GameObject.GetComponent<VirtualBuildingController>();
				((VirtualBuildingController)((MilitaryIntelligence)building).Controller).building = (MilitaryIntelligence)building;
				parentTransform = mainCity.transform;
			}
			else if (building.Feature == "BlackMarketer")
			{
				((BlackMarket)building).Controller = building.GameObject.GetComponent<VirtualBuildingController>();
				((VirtualBuildingController)((BlackMarket)building).Controller).building = (BlackMarket)building;
				parentTransform = mainCity.transform;
			}
			else if (building.Feature == "MoltenCore")
			{
				parentTransform = mainCity.transform;
				((MoltenCore)building).Controller = building.GameObject.GetComponent<MoltenCoreController>();
				((MoltenCoreController)((MoltenCore)building).Controller).WorkShop = (MoltenCore)building;
				((MoltenCoreController)((MoltenCore)building).Controller).SetWorkbenchNominal();
			}
			else if (building.Feature == "PVPEntrance")
			{
				((PVPEntrance)building).Controller = building.GameObject.GetComponent<PVPEntranceController>();
				((PVPEntranceController)((PVPEntrance)building).Controller).building = (PVPEntrance)building;
				parentTransform = mainCity.transform;
			}
			else if (building.Feature == "GvGExpeditionHallEntrance")
			{
				((GvGExpeditionHallEntrance)building).Controller = building.GameObject.GetComponent<GvGExpeditionHallEntranceController>();
				((GvGExpeditionHallEntranceController)((GvGExpeditionHallEntrance)building).Controller).building = (GvGExpeditionHallEntrance)building;
				parentTransform = mainCity.transform;
			}
			else
			{
				parentTransform = mainCity.transform;
			}
			building.GameObject.transform.SetParent(parentTransform);
			building.GameObject.transform.localPosition = pos;
			FGUIManager.Instance.LoadBuildings(building, isInit: true);
			if (building.Feature == "Mine" || building.Feature == "WorkShop")
			{
				FGUIManager.Instance.ContinueRepairBuildings(building.ConstructingConfig, building);
				if (building.Feature == "Mine")
				{
					((WorkshopController)((WorkShop)building).Controller).ContinueUpgradeCollection(building.ConstructingConfig);
				}
				else if (building.Feature == "WorkShop")
				{
					((WorkshopController)((WorkShop)building).Controller).ContinueUpgradeWorkshop(building.ConstructingConfig);
				}
			}
			else if (building.Feature == "Camp")
			{
				FGUIManager.Instance.ContinueRepairBuildings(building.ConstructingConfig, building);
				((CampController)((Camp)building).Controller).ContinueUpgrade(building.ConstructingConfig);
			}
			else if (building.Feature == "Storehouse")
			{
				((StorehouseController)((Storehouse)building).Controller).ContinueUpgrade(building.ConstructingConfig);
			}
			else if (building.Feature == "MilitaryIntelligence7")
			{
				((VirtualBuildingController)((MilitaryIntelligence)building).Controller).ContinueUpgrade(building.ConstructingConfig);
			}
			else if (building.Feature == "BlackMarketer")
			{
				((VirtualBuildingController)((BlackMarket)building).Controller).ContinueUpgrade(building.ConstructingConfig);
			}
			else if (building.Feature == "MoltenCore")
			{
				FGUIManager.Instance.ContinueRepairBuildings(building.ConstructingConfig, building);
				((MoltenCoreController)((MoltenCore)building).Controller).ContinueUpgradeMoltenCore(building.ConstructingConfig);
			}
			else if (building.Feature == "PVPEntrance")
			{
				((PVPEntranceController)((PVPEntrance)building).Controller).ContinueUpgrade(building.ConstructingConfig);
			}
			else if (building.Feature == "GvGExpeditionHallEntrance")
			{
				((GvGExpeditionHallEntranceController)((GvGExpeditionHallEntrance)building).Controller).ContinueUpgrade(building.ConstructingConfig);
			}
		}
		FGUIManager.Instance.UpdateBuildingNote();
		OnMainCityInitialized();
		FGUIManager.Instance.SetMainCityPos(mainCity);
		GameManagers.Instance.BuildingManager.RegisterUiObjects();
	}

	private void LoadVideoEntrance(GameObject mainCity)
	{
		Transform val = mainCity.transform.Find("VideoEntrance");
		GameObject entrance;
		if (Object.op_Implicit((Object)(object)val))
		{
			entrance = ((Component)val).gameObject;
			entrance.AddComponent<GvG3VideoEntrance>();
			AddHitArea();
		}
		void AddHitArea()
		{
			entrance.AddComponent<HitArea>();
			HitArea component = entrance.GetComponent<HitArea>();
			component.hitData.name = "VideoEntrance";
			component.hitData.id = "VideoEntrance";
			component.repairBuildTime = 5f;
		}
	}

	private void LoadGiftOfLordEntrance(GameObject mainCity)
	{
		Transform val = mainCity.transform.Find("GiftOfLordEntrance");
		GameObject entrance;
		if (Object.op_Implicit((Object)(object)val))
		{
			entrance = ((Component)val).gameObject;
			entrance.AddComponent<GiftOfLordEntrance>();
			AddHitArea();
		}
		void AddHitArea()
		{
			entrance.AddComponent<HitArea>();
			HitArea component = entrance.GetComponent<HitArea>();
			component.hitData.name = "GiftOfLordEntrance";
			component.hitData.id = "GiftOfLordEntrance";
			component.repairBuildTime = 5f;
		}
	}

	private void OnMainCityInitialized()
	{
		ILRequestHelper<EnterGameResponse>.Request(null, () => GameController.Contexts.Service<INetworkService>().EnterGame(), delegate(EnterGameResponse response)
		{
			GameManagers.Instance.UserArchiveManager.SetDailyLoginStats(response.DailyLoginStats);
			GameManagers.Instance.Messenger.Broadcast("ON_DAILY_LOGIN_STATS", response.DailyLoginStats);
			if (!response.Result || response.Bonuses == null || response.Bonuses.Count < 1)
			{
				GameManagers.Instance.Messenger.Broadcast<List<string>, bool>("BUILDING_NEED_RESUME_PRODUCE", null, arg2: false);
				_gameState.isMainCityInitialized = true;
			}
			else
			{
				GameManagers.Instance.StockController.ReadStockChangeRecords(response.StockChangeRecords);
				List<Bonus> list = new List<Bonus>();
				foreach (ModelsBonus bonuse in response.Bonuses)
				{
					list.Add(Bonus.Get(bonuse.ItemId, bonuse.Qty));
				}
				_gameState.ReplaceOfflineSeconds(response.OfflineSeconds);
				_contexts.gameState.ReplaceOfflineBonuses(list);
				FGUIManager.Instance.GvGMode3OfflineBonusInfo = new GvGMode3OfflineBonusModel
				{
					GvGFetchGapTime = response.GvGFetchGapTime,
					FullItemId = response.FullItemId
				};
				if (response.isNewDay)
				{
					if (GameManagers.Instance.BuildingManager.GetBuildingByType("17") is MoltenCore moltenCore)
					{
						foreach (string key in moltenCore.ProductionConfigs.Keys)
						{
							moltenCore.ProductionConfigs[key].Workers = 0;
							moltenCore.ProductionConfigs[key].ProductList = new List<string>();
						}
					}
					GameManagers.Instance.Messenger.Broadcast("NEW_DAY_LOGIN");
				}
				GameManagers.Instance.Messenger.Broadcast<List<string>, bool>("BUILDING_NEED_RESUME_PRODUCE", null, arg2: false);
				_gameState.isMainCityInitialized = true;
				MsgSecurityClient.SIndex = "hks";
			}
		}, 1f);
		ThinkingDataHelper.Instance.UserEnterGameTrack();
		FGUIManager.Instance.curLegionSizeLimit = _contexts.game.dungeon.value.LegionSizeLimit;
	}

	public override void MainCityLoaded()
	{
		EnableMainCity(new Dictionary<MainCityEnableCommand, bool>
		{
			{
				MainCityEnableCommand.MonoBehaviour,
				true
			},
			{
				MainCityEnableCommand.Produce,
				true
			}
		});
		_firstSyncAfterEnteredMainCity = false;
		LeaseholdManager leaseholdManager = GameManagers.Instance.LeaseholdManager;
		bool canClaimDailyBonus = leaseholdManager.CanClaimDailyBonus("OverlordContract") || leaseholdManager.CanClaimDailyBonus("PrimeContract");
		if (_gameState.isMainCityInitialized)
		{
			GameManagers.Instance.PullData();
			GameController.Contexts.Service<IUiService>().OpenPanel(UI_RollingMarqueePanel.Name, null);
		}
		if (_gameState.hasOfflineSeconds && _gameState.hasOfflineBonuses)
		{
			int seconds = _gameState.offlineSeconds.value;
			List<Bonus> bonuses = _gameState.offlineBonuses.value;
			_gameState.RemoveOfflineSeconds();
			_gameState.RemoveOfflineBonuses();
			if (bonuses == null || bonuses.Count == 0)
			{
				FGUIManager.Instance.MainCityUiTouchable = true;
				if (canClaimDailyBonus && FGUIManager.Instance.IsShowMonthCardFirst)
				{
					GameController.Contexts.Service<IUiService>().OpenPanel(UI_MonthCardPanel.Name, new Dictionary<string, object>
					{
						{
							"Activity",
							FGUIManager.Instance.GetBlackMarketerActivity("UI_MonthCardPanel")
						},
						{ "Status", 1 },
						{ "Order", 998 }
					});
				}
				if (!FGUIManager.Instance.JudgeFreeWorkerNum() && FGUIManager.Instance.IsShowMonthCardOverdueTip)
				{
					FGUIManager.Instance.OpenMonthCardOverdueTipPanel();
					FGUIManager.Instance.IsShowMonthCardOverdueTip = false;
				}
				return;
			}
			FGUIManager.Instance.MainCityUiTouchable = false;
			ScriptApi.CreateTimer(1f, delegate
			{
				GameController.Contexts.Service<IUiService>().OpenPanel(UI_ShowOfflineEarnings.Name, new Dictionary<string, object>
				{
					{ "Bonus", bonuses },
					{ "Time", seconds }
				});
				if (canClaimDailyBonus && FGUIManager.Instance.IsShowMonthCardFirst)
				{
					GameController.Contexts.Service<IUiService>().OpenPanel(UI_MonthCardPanel.Name, new Dictionary<string, object>
					{
						{
							"Activity",
							FGUIManager.Instance.GetBlackMarketerActivity("UI_MonthCardPanel")
						},
						{ "Status", 1 },
						{ "Order", 998 }
					});
				}
				if (!FGUIManager.Instance.JudgeFreeWorkerNum() && FGUIManager.Instance.IsShowMonthCardOverdueTip)
				{
					FGUIManager.Instance.OpenMonthCardOverdueTipPanel();
					FGUIManager.Instance.IsShowMonthCardOverdueTip = false;
				}
			});
		}
		else
		{
			if (!canClaimDailyBonus || !FGUIManager.Instance.IsShowMonthCardFirst)
			{
				return;
			}
			ScriptApi.CreateTimer(1f, delegate
			{
				GameController.Contexts.Service<IUiService>().OpenPanel(UI_MonthCardPanel.Name, new Dictionary<string, object>
				{
					{
						"Activity",
						FGUIManager.Instance.GetBlackMarketerActivity("UI_MonthCardPanel")
					},
					{ "Status", 1 },
					{ "Order", 998 }
				});
				if (!FGUIManager.Instance.JudgeFreeWorkerNum() && FGUIManager.Instance.IsShowMonthCardOverdueTip)
				{
					FGUIManager.Instance.OpenMonthCardOverdueTipPanel();
					FGUIManager.Instance.IsShowMonthCardOverdueTip = false;
				}
			});
		}
	}

	public override void OnAnyLoadingPanelStatus(GameStateEntity entity, LoadingPanelStatus value)
	{
		switch (value)
		{
		case LoadingPanelStatus.Closed:
			break;
		case LoadingPanelStatus.Opening:
			break;
		case LoadingPanelStatus.Showing:
			if (_lastScene != null)
			{
				_lastScene.isVisible = true;
			}
			break;
		case LoadingPanelStatus.Closing:
			break;
		default:
			throw new ArgumentOutOfRangeException("value", value, null);
		}
	}

	public override void OnAnyLoadingProgress(GameStateEntity entity, int value)
	{
		if (_gameState.loadingTotal.value <= value && SpawnManager.Instance.FinishInit)
		{
			TimerEntity entityWithId = _contexts.timer.GetEntityWithId(_loadingTimeoutTimer);
			if (entityWithId != null)
			{
				((Entity)entityWithId).Destroy();
			}
			OnSceneLoaded(_lastScene);
		}
	}
}
