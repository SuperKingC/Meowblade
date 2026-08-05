using System;
using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.UI;
using GvG3;
using HotFix.Sources.Base.Sources.Scripts.GvG3.GvG3WorldMap.Manager;
using HotFix.Sources.Base.Sources.Scripts.GvG3Common.Model;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Manager;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Model;
using HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Helper;
using HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Manager;
using HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Model;
using Shift.Legion.ClientApi.Models;
using Shift.Legion.ClientApi.Protocol;
using Shift.Legion.Common.Helpers;
using Shift.Legion.Common.Managers;
using Shift.Legion.Common.Models;
using Shift.Legion.Common.Services;
using Shift.Legion.GvG.Common.Enums;
using Shift.Legion.GvG.Common.Models.GvGMode3;
using Shift.Legion.GvGServer.Models.GvGMode3IslandManagerSocket;
using Shift.Legion.GvGServer.Models.GvGMode3IslandManagerSocket.Mission;
using UI.GvGOnIsland3;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Controller;

public class GvGWorldMapController : MonoBehaviour
{
	public static GvGWorldMapController Instance;

	public static bool IsInstanceCreated;

	private static int FocusIslandOnNextInit = -1;

	private bool IsPause;

	private GameObject GvGWorldMap;

	public FlagShipManager FlagShipManager;

	public GvGMapInputManager InputManager;

	public LoaderManager LoaderManager;

	private AreaRenderManager AreaRenderManager;

	public IslandActionManager IslandActionManager;

	public RouteManager RouteManager;

	private CloudsManager CloudsManager;

	public BackgroundManager BackgroundManager;

	public HiddenIslandManager HiddenIslandManager;

	public CameraBindingManager CameraBindingManager;

	private KeepConnectionManager KeepConnectionManager;

	public MockPushManager MockPushManager;

	public Transform CameraTracker;

	private Transform FloorTouchTracker;

	public CrisisDetectManager CrisisDetectManager;

	public Sprite DefaultAvatarSprite;

	public Dictionary<string, GameObject> Prefabs;

	private GameObject _selector;

	private int _currentGroup;

	private Vector3 _lastDefaultCameraPos;

	public bool InitComplete;

	public const int DEFAULT_GROUP = 0;

	public Action<GameObject> OnDeselec = delegate
	{
	};

	public Action<int> OnSelectIsland = delegate
	{
	};

	public Action<int> OnSelectFlagship = delegate
	{
	};

	public Action<List<TouchedObject>> OnClickAny = delegate
	{
	};

	private RaycastHit hit;

	private Ray Ray;

	public static IEnumerator CreateInstance(string _IZConfigId)
	{
		Application.targetFrameRate = 60;
		if (!IsInstanceCreated)
		{
			GameController.Contexts.Service<BaseSceneService>().EnableMainCity(new Dictionary<MainCityEnableCommand, bool>
			{
				{
					MainCityEnableCommand.MonoBehaviour,
					false
				},
				{
					MainCityEnableCommand.Produce,
					true
				}
			});
			if (!GameController.Contexts.gameState.isMainCityInitialized)
			{
				EnterGameToGvG();
			}
			Singleton<GvGMode3RoomManager>.Instance.StopwatchLogInterval("WorldMapController - 关闭Maincity");
			AsyncOperationHandle<GameObject> handler = Addressables.InstantiateAsync((object)"GvG/GvGWorldMap", (Transform)null, false, true);
			yield return handler;
			Singleton<GvGMode3RoomManager>.Instance.StopwatchLogInterval("WorldMapController - 加载完地图prefab");
			Instance = handler.Result.AddComponent<GvGWorldMapController>();
			yield return Instance.Init(_IZConfigId);
			IsInstanceCreated = true;
		}
	}

	public static void ReleaseInstance()
	{
		if (IsInstanceCreated)
		{
			Instance.Destroy();
			Addressables.ReleaseInstance(Instance.GvGWorldMap);
			Instance = null;
			IsInstanceCreated = false;
			GameController.Contexts.Service<BaseSceneService>().EnableMainCity(new Dictionary<MainCityEnableCommand, bool>
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
		}
	}

	public static void EnterGameToGvG()
	{
		ILRequestHelper<EnterGameResponse>.Request(null, () => GameController.Contexts.Service<INetworkService>().EnterGame(), delegate(EnterGameResponse response)
		{
			GameManagers.Instance.UserArchiveManager.SetDailyLoginStats(response.DailyLoginStats);
			GameManagers.Instance.Messenger.Broadcast("ON_DAILY_LOGIN_STATS", response.DailyLoginStats);
			if (response.Result && response.Bonuses != null && response.Bonuses.Count >= 1)
			{
				GameManagers.Instance.StockController.ReadStockChangeRecords(response.StockChangeRecords);
				List<Bonus> list = new List<Bonus>();
				foreach (ModelsBonus bonuse in response.Bonuses)
				{
					list.Add(Bonus.Get(bonuse.ItemId, bonuse.Qty));
				}
				GameController.Contexts.gameState.ReplaceOfflineSeconds(response.OfflineSeconds);
				GameController.Contexts.gameState.ReplaceOfflineBonuses(list);
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
			}
		}, 1f);
		ThinkingDataHelper.Instance.UserEnterGameTrack();
	}

	public IEnumerator Init(string _IZConfigId)
	{
		((Behaviour)this).enabled = false;
		IsPause = false;
		InitComplete = false;
		_currentGroup = -1;
		GvGWorldMap = ((Component)this).gameObject;
		((Object)GvGWorldMap).name = "GvGWorldMap";
		GvGWorldMap.transform.parent = ((Component)GameController.Instance).gameObject.transform;
		GvGWorldMap.transform.localPosition = Vector3.zero;
		FloorTouchTracker = AddEmptyObject("TouchTracker");
		CameraTracker = AddEmptyObject("CameraTracker");
		Singleton<CameraService>.Instance.SetSkybox("GvGSkybox");
		Singleton<GvGMode3RoomManager>.Instance.StopwatchLogInterval("WorldMapController - Skybox");
		string navLineAAKey = "GvG/NavLines_" + _IZConfigId;
		AsyncOperationHandle<GameObject> handler = Addressables.InstantiateAsync((object)navLineAAKey, (Transform)null, false, true);
		yield return handler;
		Singleton<GvGMode3RoomManager>.Instance.StopwatchLogInterval("WorldMapController - 加载完航线");
		GameObject navLines = handler.Result;
		navLines.transform.SetParent(GvGWorldMap.transform, false);
		navLines.transform.localPosition = Vector3.zero;
		((Object)navLines).name = "Lines";
		InitPrefabs();
		Singleton<GvGMode3RoomManager>.Instance.StopwatchLogInterval("WorldMapController - InitPrefabs内部");
		FlagShipManager = new FlagShipManager(GvGWorldMap);
		InputManager = new GvGMapInputManager();
		InputManager.InitInput(FloorTouchTracker, CameraTracker);
		HiddenIslandManager = new HiddenIslandManager(GvGWorldMap);
		if (LoadingHelper.ShouldYield_EnterIZ())
		{
			yield return null;
		}
		LoaderManager = new LoaderManager(GvGWorldMap.transform, (MonoBehaviour)(object)this);
		AreaRenderManager = new AreaRenderManager(GvGWorldMap);
		IslandActionManager = new IslandActionManager();
		CameraBindingManager = new CameraBindingManager();
		KeepConnectionManager = new KeepConnectionManager();
		MockPushManager = new MockPushManager();
		CameraBindingManager.Init(Vector3.zero, 100f, Quaternion.Euler(45f, 0f, 0f));
		RouteManager = new RouteManager(GvGWorldMap);
		if (LoadingHelper.ShouldYield_EnterIZ())
		{
			yield return null;
		}
		CloudsManager = new CloudsManager(GvGWorldMap);
		CrisisDetectManager = new CrisisDetectManager();
		SetCameraOnAwake();
		BackgroundManager = new BackgroundManager(GvGWorldMap, ((Component)CameraBindingManager.MainCamera).transform, CameraBindingManager.MainCamera, 6f);
		IslandLoader islandLoader = LoaderManager.IslandLoader;
		islandLoader.OnLoadingFinished = (Action)Delegate.Combine(islandLoader.OnLoadingFinished, new Action(OnLoadFinished));
		RegisterEventListeners();
		InitComplete = true;
		Singleton<GvGMode3RoomManager>.Instance.StopwatchLogInterval("WorldMapController - 加载完所有Manager");
	}

	private void Destroy()
	{
		Singleton<CameraService>.Instance.ClearSkybox();
		UnRegisterEventListeners();
		FlagShipManager.OnDestroy();
		CloudsManager.OnDestroy();
		BackgroundManager.OnDestroy();
		HiddenIslandManager.OnDestroy();
		LoaderManager.OnDestroy();
		CameraBindingManager.OnDestroy();
		CrisisDetectManager.OnRelease();
		AreaRenderManager.OnDestroy();
		Application.targetFrameRate = UiHelper.FrameRate;
	}

	public void StartUpdate()
	{
		Application.targetFrameRate = 60;
		((Behaviour)this).enabled = true;
	}

	private void OnLoadFinished()
	{
		Singleton<GvGMode3RoomManager>.Instance.StopwatchLogInterval("WorldMapController - 加载完视野岛屿");
		FlagShipManager.LoadFlagShips();
		SharedMessenger.Broadcast("CLOSE_GVGLOADING_UI");
		IslandLoader islandLoader = LoaderManager.IslandLoader;
		islandLoader.OnLoadingFinished = (Action)Delegate.Remove(islandLoader.OnLoadingFinished, new Action(OnLoadFinished));
	}

	private void OnSocketError()
	{
		Pause(hide: false);
	}

	private void OnRoomReconnect()
	{
		Resume();
	}

	private void OnAppPause(bool isPaused)
	{
		if (!isPaused)
		{
			EnterGameToGvG();
		}
	}

	public void SetCamera(Vector3 pos, float size)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_001a: Unknown result type (might be due to invalid IL or missing references)
		CameraTracker.localPosition = pos;
		CameraBindingManager.SetTarget(CameraTracker.position);
		CameraBindingManager.FollowImmediately();
		CameraBindingManager.CamSize = size;
	}

	public void FocusIslandById(int islandId, float catchupTime = 0.5f, float camSize = 6f, bool showLocationSign = true)
	{
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		IslandConfigData islandConfigData = WorldMapConfigHelper.Configs.TryGetIsland(islandId);
		CameraTracker.localPosition = islandConfigData.Position;
		CameraBindingManager.SetTarget(CameraTracker.position);
		CameraBindingManager.CatchupInTime(catchupTime);
		CameraBindingManager.SetTargetCamSize(camSize);
		CameraBindingManager.CamSize_CatchupInTime(catchupTime);
		if (showLocationSign)
		{
			Singleton<WorldStateManager>.Instance.TryGetIsland(islandId)?.CameraLocateIsland(catchupTime);
		}
	}

	public void FocusShipByEntityId(int entityId, float catchupInTime = 1f)
	{
		ShipController shipController = LoaderManager.GetShipController(entityId);
		if ((Object)(object)shipController != (Object)null)
		{
			CameraBindingManager.SetTarget(((Component)shipController).transform);
			CameraBindingManager.CatchupInTime(catchupInTime);
			shipController.OnClickFocus();
		}
		else
		{
			ILRuntimeDebug.LogError($"[GvGWorldMapController] FocusShipByEntityId 找不到ShipController EntityId={entityId}");
		}
	}

	private void SetCameraOnAwake()
	{
		if (WorldMapConfigHelper.IsLoaded)
		{
			SetIslandGroup(0);
			if (!FocusFlagshipIsland() && !FocusOnNextInitIsland())
			{
				FocusFirstShipIsland();
			}
		}
		void FocusFirstShipIsland()
		{
			//IL_0087: Unknown result type (might be due to invalid IL or missing references)
			//IL_004f: Unknown result type (might be due to invalid IL or missing references)
			GvGMode3ObserverRecord observerRecord = Singleton<GvGMode3RoomManager>.Instance.ObserverRecord;
			GvGMode3ShipTemporaryData temporaryData = observerRecord.Ships[0].TemporaryData;
			int targetIslandId = temporaryData.TargetIslandId;
			if (temporaryData.ShipState != eShipState.NotLaunched && temporaryData.ShipState != eShipState.Rebuilding && targetIslandId != 0)
			{
				SetCamera(WorldMapConfigHelper.Configs.TryGetIsland(targetIslandId).Position, 6f);
			}
			else
			{
				int islandId = WorldMapConfigHelper.Configs.MainIslandsDict[temporaryData.CampId];
				SetCamera(WorldMapConfigHelper.Configs.TryGetIsland(islandId).Position, 6f);
			}
		}
		bool FocusFlagshipIsland()
		{
			//IL_008d: Unknown result type (might be due to invalid IL or missing references)
			int timeStamp = DateTimeHelper.GetTimeStamp(DateTimeHelper.GetDailyRefreshTime(DateTimeHelper.ServerNow, DateTimeHelper.TimezoneOffset, DateTimeHelper.RefreshHours));
			string text = $"LastEnterIZ_{Singleton<GvGMode3RoomManager>.Instance.ObserverRecord.CurIZId}_{GameController.Contexts.gameState.user.value.UserId}";
			int num = PlayerPrefs.GetInt(text);
			if (num >= timeStamp)
			{
				return false;
			}
			int ourFlagShipStayIslandId = Singleton<WorldStateManager>.Instance.Data.OurFlagShipStayIslandId;
			SetCamera(WorldMapConfigHelper.Configs.TryGetIsland(ourFlagShipStayIslandId).Position, 6f);
			PlayerPrefs.SetInt(text, timeStamp);
			return true;
		}
		bool FocusOnNextInitIsland()
		{
			//IL_0021: Unknown result type (might be due to invalid IL or missing references)
			if (FocusIslandOnNextInit == -1)
			{
				return false;
			}
			SetCamera(WorldMapConfigHelper.Configs.TryGetIsland(FocusIslandOnNextInit).Position, 6f);
			FocusIslandOnNextInit = -1;
			return true;
		}
	}

	public void LaunchModeInit(int defaultIslandId)
	{
		LaunchModeUpdateIslandId(defaultIslandId);
	}

	public void LaunchModeUpdateIslandId(int islandId)
	{
		//IL_005c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0081: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b0: Unknown result type (might be due to invalid IL or missing references)
		IslandConfigData islandConfigData = WorldMapConfigHelper.Configs.TryGetIsland(islandId);
		float num = 0.5f;
		if (_selector == null)
		{
			_selector = InstantiateFromPrefab("selector");
			_selector.transform.SetParent(GvGWorldMap.transform, true);
		}
		_selector.transform.localPosition = islandConfigData.Position;
		_selector.transform.localEulerAngles = new Vector3(90f, 0f, 0f);
		float num2 = islandConfigData.FogAreaScale.x * 0.2f;
		_selector.transform.localScale = new Vector3(num2, num2, 0f);
		GameObject selector = _selector;
		if (selector != null)
		{
			selector.SetActive(false);
		}
		ScriptApi.CreateTimer(num, delegate
		{
			GameObject selector2 = _selector;
			if (selector2 != null)
			{
				selector2.SetActive(true);
			}
		});
		FocusIslandById(islandId, num, 30f);
	}

	public void LaunchModeDestroy()
	{
		GameObject selector = _selector;
		if (selector != null)
		{
			selector.SetActive(false);
		}
	}

	public void EnterIsland(int islandPid, int islandExternalSocketPort, int islandId)
	{
		FocusIslandOnNextInit = islandId;
		GameController.Contexts.Service<IUiService>().OpenPanel(UI_main_GvGOnIsland3.Name, new Dictionary<string, object>
		{
			{ "PId", islandPid },
			{ "Port", islandExternalSocketPort },
			{ "IslandId", islandId }
		});
	}

	public void Test_CheckEnterIsland()
	{
		if (Input.GetKeyDown((KeyCode)32))
		{
			EnterIsland(0, 0, 16);
		}
	}

	public void Test_CheckFlagShipEvent()
	{
		if (Input.GetKeyDown((KeyCode)32))
		{
			S2C_FlagShipState.OnPushEvent(new S2C_FlagShipState.Request
			{
				Info = new FlagShipStateInfo
				{
					ShipTargetIslandId = 16,
					CampId = 1
				}
			});
			long num = (long)(GameController.Instance.GetServerRealtimeSeconds() * 1000.0);
			S2C_AttackEvent.OnPushEvent(new S2C_AttackEvent.Request
			{
				AttackEvent = new FlagShipAttackEvent
				{
					MissileOri = 16,
					MissileDest = 17,
					MissileType = 0,
					StartTimestamp_ms = num,
					EndTimestamp_ms = num + 10000,
					CampId = 1
				}
			});
			Singleton<WorldStateManager>.Instance.TryGetIsland(17).ShieldState = eIslandShieldState.Damaged;
			Singleton<WorldStateManager>.Instance.TryGetIsland(17).OnChange?.Invoke(Singleton<WorldStateManager>.Instance.TryGetIsland(17));
		}
	}

	private void Update()
	{
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_005a: Unknown result type (might be due to invalid IL or missing references)
		KeepConnectionManager.Update();
		CameraBindingManager.Update();
		Vector3 position = ((Component)CameraBindingManager.MainCamera).transform.position;
		BackgroundManager.Update();
		LoaderManager.Update();
		AreaRenderManager.UpdateCamPos(position);
		RouteManager.UpdateCamPos(position);
	}

	public void SetIslandGroup(int groupIndex)
	{
		//IL_0048: Unknown result type (might be due to invalid IL or missing references)
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0054: Unknown result type (might be due to invalid IL or missing references)
		//IL_0055: Unknown result type (might be due to invalid IL or missing references)
		//IL_005e: Unknown result type (might be due to invalid IL or missing references)
		//IL_006f: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_009e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0090: Unknown result type (might be due to invalid IL or missing references)
		//IL_0095: Unknown result type (might be due to invalid IL or missing references)
		if (_currentGroup != groupIndex)
		{
			if (_currentGroup == 0)
			{
				_lastDefaultCameraPos = CameraTracker.localPosition;
			}
			_currentGroup = groupIndex;
			Rect viewRect = WorldMapConfigHelper.Configs.GetGroupInfo(groupIndex).ViewRect;
			InputManager.cameraDragRect = viewRect;
			Vector3 lastDefaultCameraPos = default(Vector3);
			((Vector3)(ref lastDefaultCameraPos))._002Ector(((Rect)(ref viewRect)).center.x, 0f, ((Rect)(ref viewRect)).center.y);
			float size = 15f;
			if (groupIndex == 0)
			{
				lastDefaultCameraPos = _lastDefaultCameraPos;
				size = 6f;
			}
			SetCamera(lastDefaultCameraPos, size);
		}
	}

	public void Pause(bool hide = true)
	{
		if (!IsPause)
		{
			IsPause = true;
			((Behaviour)this).enabled = false;
			((Component)((Component)this).transform).gameObject.SetActive(!hide);
			CameraBindingManager.Pause();
			LoaderManager.Pause(hide);
			InputManager.Enabled = false;
		}
	}

	public void Resume()
	{
		if (IsPause)
		{
			IsPause = false;
			((Behaviour)this).enabled = true;
			((Component)((Component)this).transform).gameObject.SetActive(true);
			CameraBindingManager.Resume();
			LoaderManager.Resume();
			InputManager.Enabled = true;
			Singleton<CameraService>.Instance.SetSkybox("GvGSkybox");
		}
	}

	private void InitPrefabs()
	{
		Transform val = ((Component)this).transform.Find("Prefabs");
		((Component)val).gameObject.SetActive(false);
		Prefabs = new Dictionary<string, GameObject>();
		for (int i = 0; i < val.childCount; i++)
		{
			Transform child = val.GetChild(i);
			Prefabs.Add(((Object)child).name, ((Component)child).gameObject);
		}
		DefaultAvatarSprite = ((Component)Prefabs["slot_blue"].transform.Find("Content/portrait")).GetComponent<SpriteRenderer>().sprite;
	}

	public GameObject GetPrefab(string name)
	{
		if (Prefabs.TryGetValue(name, out var value))
		{
			return value;
		}
		ILRuntimeDebug.LogError("场景中找不到预制体 " + name);
		return null;
	}

	public GameObject InstantiateFromPrefab(string name)
	{
		GameObject prefab = GetPrefab(name);
		if ((Object)(object)prefab != (Object)null)
		{
			return Object.Instantiate<GameObject>(prefab);
		}
		return null;
	}

	public GameObject GetIslandPrefabByIslandId(int islandId)
	{
		IslandConfigData islandConfigData = WorldMapConfigHelper.Configs.TryGetIsland(islandId);
		int curIZId = Singleton<GvGMode3RoomManager>.Instance.ObserverRecord.CurIZId;
		string sprite = WorldMapConfigHelper.GetSprite(islandConfigData.Props, curIZId);
		return GetPrefab(sprite);
	}

	private Transform AddEmptyObject(string name)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Expected O, but got Unknown
		//IL_0025: Unknown result type (might be due to invalid IL or missing references)
		GameObject val = new GameObject(name);
		val.transform.parent = GvGWorldMap.transform;
		val.transform.localScale = Vector3.one;
		return val.transform;
	}

	private void RegisterEventListeners()
	{
		InputManager.AddOnClick(eObjectType.Island, OnInput_SelectIslandWithRayTest);
		InputManager.AddOnClick(eObjectType.Flagship, OnInput_SelectFlagship);
		InputManager.AddOnClickAny(OnInput_ClickAny);
		GvGMapInputManager inputManager = InputManager;
		inputManager.OnStartDragCamera = (Action)Delegate.Combine(inputManager.OnStartDragCamera, new Action(OnInput_StartDragCamera));
		CameraBindingManager cameraBindingManager = CameraBindingManager;
		cameraBindingManager.OnChangeSize = (Action<float>)Delegate.Combine(cameraBindingManager.OnChangeSize, new Action<float>(OnCameraBinder_SizeChange));
		GvGMode3RoomManager instance = Singleton<GvGMode3RoomManager>.Instance;
		instance.OnRoomReconnect = (Action)Delegate.Combine(instance.OnRoomReconnect, new Action(OnRoomReconnect));
		SharedMessenger.AddListener("ON_SOCKET_ERROR", OnSocketError);
		SharedMessenger.AddListener<bool>("APP_PAUSE", OnAppPause);
	}

	private void UnRegisterEventListeners()
	{
		InputManager.RemoveOnClick(eObjectType.Island, OnInput_SelectIslandWithRayTest);
		InputManager.RemoveOnClick(eObjectType.Flagship, OnInput_SelectFlagship);
		InputManager.RemoveOnClickAny(OnInput_ClickAny);
		GvGMapInputManager inputManager = InputManager;
		inputManager.OnStartDragCamera = (Action)Delegate.Remove(inputManager.OnStartDragCamera, new Action(OnInput_StartDragCamera));
		CameraBindingManager cameraBindingManager = CameraBindingManager;
		cameraBindingManager.OnChangeSize = (Action<float>)Delegate.Remove(cameraBindingManager.OnChangeSize, new Action<float>(OnCameraBinder_SizeChange));
		GvGMode3RoomManager instance = Singleton<GvGMode3RoomManager>.Instance;
		instance.OnRoomReconnect = (Action)Delegate.Remove(instance.OnRoomReconnect, new Action(OnRoomReconnect));
		SharedMessenger.RemoveListener("ON_SOCKET_ERROR", OnSocketError);
		SharedMessenger.RemoveListener<bool>("APP_PAUSE", OnAppPause);
	}

	private void OnCameraBinder_SizeChange(float size)
	{
		AreaRenderManager.OnCamSizeChange(size);
		RouteManager.OnCamSizeChange(size);
	}

	private void OnInput_SelectIsland(TouchedObject touchedObject)
	{
		GameObject target = touchedObject.Target;
		int obj = int.Parse(((Object)target).name);
		OnSelectIsland?.Invoke(obj);
	}

	private void OnInput_SelectFlagship(TouchedObject touchedObject)
	{
		GameObject target = touchedObject.Target;
		int obj = int.Parse(((Object)target).name);
		OnSelectFlagship?.Invoke(obj);
	}

	private void OnInput_StartDragCamera()
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		if (!CameraBindingManager.IsCurrentTarget(CameraTracker))
		{
			CameraTracker.position = CameraBindingManager.ViewCenter;
			CameraBindingManager.SetTarget(CameraTracker);
			CameraBindingManager.FollowImmediately();
		}
	}

	private void OnInput_ClickAny(List<TouchedObject> touchedObjects)
	{
		OnClickAny?.Invoke(touchedObjects);
	}

	private void OnInput_SelectIslandWithRayTest(TouchedObject touchedObject)
	{
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0024: Unknown result type (might be due to invalid IL or missing references)
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		//IL_0076: Unknown result type (might be due to invalid IL or missing references)
		//IL_007b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0080: Unknown result type (might be due to invalid IL or missing references)
		//IL_0082: Unknown result type (might be due to invalid IL or missing references)
		string text = eObjectType.FogOfWar.ToString();
		GameObject target = touchedObject.Target;
		Ray = new Ray(target.transform.position, Vector3.down);
		RaycastHit[] array = Physics.RaycastAll(Ray, 10f);
		for (int i = 0; i < array.Length; i++)
		{
			RaycastHit val = array[i];
			if (((Object)((RaycastHit)(ref val)).collider).name == text)
			{
				Color val2 = AreaRenderManager.SampleColorFromFogOfWar(((RaycastHit)(ref val)).textureCoord);
				if (val2.a >= 0.19f)
				{
					OnInput_SelectIsland(touchedObject);
				}
				break;
			}
		}
	}
}
