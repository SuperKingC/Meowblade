using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Assets.Scripts.UI;
using FairyGUI;
using GvG2.Common.Models;
using Shift.Legion;
using Shift.Legion.ClientApi.Protocol.UserAction;
using Shift.Legion.Common.Helpers;
using Shift.Legion.Common.Managers;
using Shift.Legion.Common.Services;
using Shift.Legion.GvGServer.Models.IslandManagerSocket;
using Shift.Legion.Rank.Helpers;
using UI.GvGWorldMap2;
using UI.IslandComeAgain;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace GvG2;

public class GvGWorldMapController : MonoBehaviour
{
	public static GvGWorldMapController Instance;

	public static bool IsInstanceCreated;

	private static GameObject GvGWorldMap;

	public static bool IsBackToMainCamp;

	public bool IsInitialized;

	public bool NeedUpdateView;

	public bool IsReadyToRender;

	public MapDataManager MapDataManager;

	private MapStateManager MapStateManager;

	private GvGMapInputManager InputManager;

	private MapEntryManager MapEntryManager;

	private MapVfxManager MapVfxManager;

	private GvGMapRenderManager GvGMapRenderManager;

	public ShipManager ShipManager;

	private FlightManager FlightManager;

	public CameraBindingHandler CamBinder;

	public Transform CameraTracker;

	private Transform FloorTouchTracker;

	private Transform ShipCollector;

	public static UI_GvGWorldMap2 MainUI;

	public Sprite DefaultAvatarSprite;

	public Dictionary<string, GameObject> Prefabs;

	private RouteManager RouteManager;

	private float CameraSizeBeforeSelectRoute;

	private Vector3 CameraPosBeforeSelectRoute;

	private bool IsPause;

	public static void CreateInstance(UI_GvGWorldMap2 mainUI)
	{
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_0025: Unknown result type (might be due to invalid IL or missing references)
		if (!IsInstanceCreated)
		{
			IsInstanceCreated = true;
			MainUI = mainUI;
			GvGWorldMap = Addressables.InstantiateAsync((object)"GvG2/GvGWorldMap", (Transform)null, false, true).WaitForCompletion();
			Instance = GvGWorldMap.AddComponent<GvGWorldMapController>();
		}
	}

	public static void ReleaseInstance()
	{
		if (IsInstanceCreated)
		{
			IsInstanceCreated = false;
			IsBackToMainCamp = false;
			Instance.UnRegisterEventListeners();
			Singleton<CameraService>.Instance.ClearSkybox();
			Singleton<CameraService>.Instance.StopBinding();
			SocketManager.Instance.GetConnection(eConType.GvGMode2WorldMap).CloseConnect();
			Addressables.ReleaseInstance(GvGWorldMap);
			Instance = null;
		}
	}

	private void Awake()
	{
		//IL_0048: Unknown result type (might be due to invalid IL or missing references)
		//IL_007b: Unknown result type (might be due to invalid IL or missing references)
		IsInitialized = false;
		IsReadyToRender = false;
		((Object)GvGWorldMap).name = "GvGWorldMap";
		GvGWorldMap.transform.parent = ((Component)GameController.Instance).gameObject.transform;
		GvGWorldMap.transform.localPosition = Vector3.zero;
		FloorTouchTracker = AddEmptyObject("TouchTracker");
		CameraTracker = AddEmptyObject("CameraTracker");
		CameraTracker.localPosition = Consts.GVG2_MAP_CENTER;
		Singleton<CameraService>.Instance.SetSkybox("GvGSkybox");
		Singleton<CameraService>.Instance.SwitchToScene("SceneGVG2");
		CamBinder = Singleton<CameraService>.Instance.BindTarget(CameraTracker, 8.64f, 0f);
		InitPrefabs();
		GvGMapRenderManager = new GvGMapRenderManager((MonoBehaviour)(object)this);
		MapDataManager = new MapDataManager(GvGWorldMap, GvGMapRenderManager);
		MapDataManager.OwnShipIds = MainUI.OwnShipIds;
		MapEntryManager = new MapEntryManager(GvGWorldMap, MapDataManager);
		MapVfxManager = new MapVfxManager(MainUI, GvGWorldMap, MapDataManager);
		ShipCollector = AddEmptyObject("Ships");
		ShipManager = new ShipManager(ShipCollector);
		FlightManager = new FlightManager(ShipManager, MapDataManager);
		MapStateManager = new MapStateManager(MapEntryManager, MapVfxManager, MapDataManager, ShipManager, FlightManager, (MonoBehaviour)(object)this);
		InputManager = new GvGMapInputManager();
		InputManager.InitInput(FloorTouchTracker, CameraTracker);
		RouteManager = new RouteManager(GvGWorldMap, MapDataManager);
		RegisterEventListeners();
	}

	private void Start()
	{
		MapStateManager.StartProcess();
	}

	private void RegisterEventListeners()
	{
		//IL_0017: Unknown result type (might be due to invalid IL or missing references)
		//IL_0021: Expected O, but got Unknown
		//IL_0038: Unknown result type (might be due to invalid IL or missing references)
		//IL_0042: Expected O, but got Unknown
		//IL_0059: Unknown result type (might be due to invalid IL or missing references)
		//IL_0063: Expected O, but got Unknown
		//IL_00a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00af: Expected O, but got Unknown
		//IL_00c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d0: Expected O, but got Unknown
		((GObject)MainUI.AddBtn).onClick.Add(new EventCallback0(OnMinusCamSize));
		((GObject)MainUI.MinusBtn).onClick.Add(new EventCallback0(OnAddCamSize));
		((GObject)MainUI.MyLegion).onClick.Add(new EventCallback0(OpenMyLegion));
		UI_Slider_VertUp slider = MainUI.Slider;
		slider.OnChange = (Action)Delegate.Combine(slider.OnChange, new Action(OnSliderChange));
		((GObject)MainUI.Ok).onClick.Add(new EventCallback1(OnConfirmRoute));
		((GObject)MainUI.Cancel).onClick.Add(new EventCallback0(OnCancelRoute));
		UI_GvGWorldMap2 mainUI = MainUI;
		mainUI.OnNotUIInput = (Action)Delegate.Combine(mainUI.OnNotUIInput, new Action(InputManager.UpdateInput));
		MapStateManager.RegisterEvents();
		MapStateManager mapStateManager = MapStateManager;
		mapStateManager.OnInitCampIsland = (Action<Island>)Delegate.Combine(mapStateManager.OnInitCampIsland, new Action<Island>(OnInitCampIsland));
		MapStateManager mapStateManager2 = MapStateManager;
		mapStateManager2.OnInitCampIslandAndShip = (Action<MapStateManager>)Delegate.Combine(mapStateManager2.OnInitCampIslandAndShip, new Action<MapStateManager>(OnInitCampIslandAndShip));
		GvGMapInputManager inputManager = InputManager;
		inputManager.OnDeselect = (Action<GameObject>)Delegate.Combine(inputManager.OnDeselect, new Action<GameObject>(OnDeselecting));
		GvGMapInputManager inputManager2 = InputManager;
		inputManager2.OnSelectIsland = (Action<GameObject>)Delegate.Combine(inputManager2.OnSelectIsland, new Action<GameObject>(OnSelectIsland));
		GvGMapInputManager inputManager3 = InputManager;
		inputManager3.OnDragCamera = (Action)Delegate.Combine(inputManager3.OnDragCamera, new Action(OnDragCamera));
		CameraBinding cameraBinding = CamBinder.CameraBinding;
		cameraBinding.OnChangeSize = (Action<float>)Delegate.Combine(cameraBinding.OnChangeSize, new Action<float>(OnCameraSizeChange));
		CameraBinding cameraBinding2 = CamBinder.CameraBinding;
		cameraBinding2.OnCatchup = (Action)Delegate.Combine(cameraBinding2.OnCatchup, new Action(OnCameraCatchup));
	}

	private void UnRegisterEventListeners()
	{
		((GObject)MainUI.AddBtn).onClick.Clear();
		((GObject)MainUI.MinusBtn).onClick.Clear();
		((GObject)MainUI.MyLegion).onClick.Clear();
		UI_Slider_VertUp slider = MainUI.Slider;
		slider.OnChange = (Action)Delegate.Remove(slider.OnChange, new Action(OnSliderChange));
		((GObject)MainUI.Ok).onClick.Clear();
		((GObject)MainUI.Cancel).onClick.Clear();
		((GObject)MainUI.MainIslandFakeClick).onClick.Clear();
		UI_GvGWorldMap2 mainUI = MainUI;
		mainUI.OnNotUIInput = (Action)Delegate.Remove(mainUI.OnNotUIInput, new Action(InputManager.UpdateInput));
		MapStateManager.UnRegisterEvents();
		MapStateManager mapStateManager = MapStateManager;
		mapStateManager.OnInitCampIsland = (Action<Island>)Delegate.Remove(mapStateManager.OnInitCampIsland, new Action<Island>(OnInitCampIsland));
		MapStateManager mapStateManager2 = MapStateManager;
		mapStateManager2.OnInitCampIslandAndShip = (Action<MapStateManager>)Delegate.Remove(mapStateManager2.OnInitCampIslandAndShip, new Action<MapStateManager>(OnInitCampIslandAndShip));
		GvGMapInputManager inputManager = InputManager;
		inputManager.OnDeselect = (Action<GameObject>)Delegate.Remove(inputManager.OnDeselect, new Action<GameObject>(OnDeselecting));
		GvGMapInputManager inputManager2 = InputManager;
		inputManager2.OnSelectIsland = (Action<GameObject>)Delegate.Remove(inputManager2.OnSelectIsland, new Action<GameObject>(OnSelectIsland));
		GvGMapInputManager inputManager3 = InputManager;
		inputManager3.OnDragCamera = (Action)Delegate.Remove(inputManager3.OnDragCamera, new Action(OnDragCamera));
		CameraBinding cameraBinding = CamBinder.CameraBinding;
		cameraBinding.OnChangeSize = (Action<float>)Delegate.Remove(cameraBinding.OnChangeSize, new Action<float>(OnCameraSizeChange));
		CameraBinding cameraBinding2 = CamBinder.CameraBinding;
		cameraBinding2.OnCatchup = (Action)Delegate.Remove(cameraBinding2.OnCatchup, new Action(OnCameraCatchup));
		GameObject val = MapDataManager.GetCampIsland(MapStateManager.MyCampId)?.IslandObject;
		if ((Object)(object)val != (Object)null)
		{
			UiTagManager.Instance.Unregister("MyCampIsland", val);
		}
		else
		{
			UiTagManager.Instance.Unregister("MyCampIsland");
		}
		UiTagManager.Instance.Unregister("MyCampIsland.FakeClick", MainUI.MainIslandFakeClick);
	}

	public void PauseInstance()
	{
		//IL_0056: Unknown result type (might be due to invalid IL or missing references)
		IsPause = true;
		Singleton<CameraService>.Instance.SwitchToScene("BattleField");
		CamBinder.CameraBinding.IsPause = true;
		InputManager.Enabled = false;
		((GObject)MainUI).visible = false;
		((Component)this).transform.localPosition = new Vector3(0f, 1000f, 0f);
	}

	public IEnumerator ResumeIsntance()
	{
		CamBinder.CameraBinding.IsPause = false;
		InputManager.Enabled = true;
		((GObject)MainUI).visible = true;
		((Component)this).transform.localPosition = Vector3.zero;
		yield return null;
		IsPause = false;
		NeedUpdateView = true;
	}

	private void OnInitCampIsland(Island myCampIsland)
	{
		//IL_0049: Unknown result type (might be due to invalid IL or missing references)
		//IL_0053: Expected O, but got Unknown
		GameObject islandObject = myCampIsland.IslandObject;
		UiTagManager.Instance.Register("MyCampIsland", islandObject);
		UiTagManager.Instance.Register("MyCampIsland.FakeClick", MainUI.MainIslandFakeClick);
		((GObject)MainUI.MainIslandFakeClick).onClick.Set(new EventCallback0(OnSelectMyCampFakeClick));
	}

	private void OnInitCampIslandAndShip(MapStateManager mapStateManager)
	{
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		if (IsBackToMainCamp)
		{
			GameObject islandObject = mapStateManager.MyCampIsland.IslandObject;
			SetCamera(islandObject.transform.localPosition, 5.4f);
			OpenMainCampPanel(mapStateManager.MyCampIsland);
			IsBackToMainCamp = false;
		}
	}

	public void OnEnterIsland(int islandPid, int islandExternalSocketPort, int shipSummaryStayIslandId)
	{
		if (!IsPause)
		{
			ReleaseInstance();
			GvGIslandController.CreateInstance(islandPid, islandExternalSocketPort, MainUI, shipSummaryStayIslandId);
		}
	}

	public void OpenMainCampPanel(Island myMainCampIsland)
	{
		UpdateGvGInstanceZoneInfo();
		Dictionary<string, object> parameters = new Dictionary<string, object>
		{
			{ "Island", myMainCampIsland },
			{ "MapStateManager", MapStateManager }
		};
		GameController.Contexts.Service<IUiService>().OpenPanel(UI_MainIslandPanel.Name, parameters);
	}

	public void SetCamera(Vector3 pos, float size)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		CameraTracker.localPosition = pos;
		MainUI.Slider.Value = size;
	}

	public void SetCamera(Vector3 pos, float size, float catchupTime)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		CameraTracker.localPosition = pos;
		MainUI.Slider.Value = size;
		CamBinder.CatchupTime = catchupTime;
	}

	private void OnAddCamSize()
	{
		MainUI.Slider.Value += 1f;
	}

	private void OnMinusCamSize()
	{
		MainUI.Slider.Value -= 1f;
	}

	private void OnSliderChange()
	{
		CamBinder.TargetSize = MainUI.Slider.Value;
	}

	private void OnCameraSizeChange(float size)
	{
		NeedUpdateView = IsReadyToRender;
		float num = (size - MainUI.Slider.MinValue) / (MainUI.Slider.MaxValue - MainUI.Slider.MinValue);
		MainUI.cloud1.Zoom.Play(1, 0f, num, num, (PlayCompleteCallback)null);
		MainUI.cloud2.Zoom.Play(1, 0f, num, num, (PlayCompleteCallback)null);
		MainUI.cloud3.Zoom.Play(1, 0f, num, num, (PlayCompleteCallback)null);
		MainUI.cloud4.Zoom.Play(1, 0f, num, num, (PlayCompleteCallback)null);
	}

	private void OnDragCamera()
	{
		NeedUpdateView = IsReadyToRender;
	}

	public RouteManager.RouteInfo GetRouteInfo(string id)
	{
		int stayIslandId = MapStateManager.MyShipSummary.StayIslandId;
		return RouteManager.GetRouteInfo($"{stayIslandId}", id);
	}

	public bool OnSelectRoute(string id, eGotoIslandOperation operation = eGotoIslandOperation.Nothing)
	{
		//IL_01c4: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c9: Unknown result type (might be due to invalid IL or missing references)
		//IL_01cf: Unknown result type (might be due to invalid IL or missing references)
		if (MapStateManager.MyShipSummary == null)
		{
			return false;
		}
		if (MapStateManager.MyShipSummary.State == 7)
		{
			List<string> arg = new List<string> { "部队战斗中，无法移动" };
			SharedMessenger.Broadcast("SHOW_TIPS", arg, ((GObject)MainUI).sortingOrder + 1, arg3: false);
			return false;
		}
		if (MapStateManager.MyShipSummary.State == 4 || MapStateManager.MyShipSummary.State == 8)
		{
			List<string> arg2 = new List<string> { "部队飞行中，无法操作" };
			SharedMessenger.Broadcast("SHOW_TIPS", arg2, ((GObject)MainUI).sortingOrder + 1, arg3: false);
			return false;
		}
		if (MapStateManager.MyShipSummary.State == 1)
		{
			List<string> arg3 = new List<string> { "请完成补兵后再操作" };
			SharedMessenger.Broadcast("SHOW_TIPS", arg3, ((GObject)MainUI).sortingOrder + 1, arg3: false);
			return false;
		}
		if (MapStateManager.MyShipSummary.State == 2)
		{
			List<string> arg4 = new List<string> { "部队补兵中，无法移动" };
			SharedMessenger.Broadcast("SHOW_TIPS", arg4, ((GObject)MainUI).sortingOrder + 1, arg3: false);
			return false;
		}
		Singleton<GvGInstanceZone>.Instance.CurrentGotoIslandOperation = operation;
		InputManager.Enabled = false;
		int stayIslandId = MapStateManager.MyShipSummary.StayIslandId;
		RouteManager.ShowRoute($"{stayIslandId}", id);
		CameraSizeBeforeSelectRoute = CamBinder.TargetSize;
		CameraPosBeforeSelectRoute = CameraTracker.localPosition;
		SetCamera(Consts.GVG2_MAP_CENTER, 8.64f, 0.5f);
		((GObject)MainUI.Ok).data = StayCampIsland();
		MainUI.PageController.selectedIndex = 2;
		if (operation == eGotoIslandOperation.ReplenishLegionGroup)
		{
			MainUI.GoToMainIslandReplenish.selectedIndex = 1;
			((GObject)MainUI.ReplenishTimeText0).text = "并消耗";
			((GObject)MainUI.ReplenishTime).text = UiHelper.ParseTime_Foo(Singleton<GvGInstanceZone>.Instance.GetExpectedFillUpTime()) ?? "";
			((GObject)MainUI.ReplenishTimeText1).text = "补兵？";
		}
		else
		{
			((GObject)MainUI.ReplenishTimeText0).text = "";
			((GObject)MainUI.ReplenishTime).text = "";
			((GObject)MainUI.ReplenishTimeText1).text = "";
			MainUI.GoToMainIslandReplenish.selectedIndex = 0;
		}
		((GObject)MainUI.Time).text = UiHelper.ParseTime((int)RouteManager.SelectedRoute.TraveTime);
		return true;
	}

	public bool StayCampIsland()
	{
		int stayIslandId = MapStateManager.MyShipSummary.StayIslandId;
		Island campIsland = MapDataManager.GetCampIsland(MapStateManager.MyCampId);
		if (campIsland == null)
		{
			return false;
		}
		return object.Equals(stayIslandId, campIsland.Props.Id);
	}

	public string GetMyCampIslandId()
	{
		Island campIsland = MapDataManager.GetCampIsland(MapStateManager.MyCampId);
		if (campIsland == null)
		{
			return string.Empty;
		}
		return campIsland.Id;
	}

	public void OnConfirmRoute(EventContext context)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		if ((bool)((GObject)context.sender).data)
		{
			List<string> soldiers = Singleton<GvGInstanceZone>.Instance.CurrentSoldiers;
			string formationId = Singleton<GvGInstanceZone>.Instance.FormationId;
			string shipId = MapStateManager.MyShip.Details.ShipId;
			ILRequestHelper<GvGMode2SyncBattleConfigResponse>.Request((EventContext)null, (Func<Task<GvGMode2SyncBattleConfigResponse>>)(() => GameController.Contexts.Service<INetworkService>().GvGMode2SyncBattleConfig(soldiers, formationId, shipId)), (Action<GvGMode2SyncBattleConfigResponse>)delegate(GvGMode2SyncBattleConfigResponse response)
			{
				if (!response.Result)
				{
					ILRequestHelper.ShowErrorCode(response.ErrorCode);
				}
				else
				{
					ConfirmRoute();
					MapStateManager.UpdateMyShipSummary();
				}
			});
		}
		else
		{
			ConfirmRoute();
		}
	}

	private void ConfirmRoute()
	{
		RouteManager.HideRoute();
		List<int> route = RouteManager.SelectedRoute.Route;
		bool isBackToCampBaseAndShipFillUp = Singleton<GvGInstanceZone>.Instance.CurrentGotoIslandOperation == eGotoIslandOperation.ReplenishLegionGroup;
		MapStateManager.MakeFlightSchedule(route[0], route[route.Count - 1], isBackToCampBaseAndShipFillUp);
		MainUI.PageController.selectedIndex = 1;
		ResetCameraToBeforeSelectRoute();
	}

	private void OnCancelRoute()
	{
		RouteManager.HideRoute();
		MainUI.PageController.selectedIndex = 1;
		ResetCameraToBeforeSelectRoute();
	}

	private void ResetCameraToBeforeSelectRoute()
	{
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		CamBinder.NotifyOnceOnCatchup = true;
		SetCamera(CameraPosBeforeSelectRoute, CameraSizeBeforeSelectRoute, 0.5f);
	}

	private void OnCameraCatchup()
	{
		InputManager.Enabled = true;
		CamBinder.CatchupTime = 0f;
	}

	private void OnDeselecting(GameObject target)
	{
	}

	private void OpenMyLegion()
	{
		if (MapStateManager.MyShipSummary != null)
		{
			UpdateGvGInstanceZoneInfo();
			Dictionary<string, object> parameters = new Dictionary<string, object> { 
			{
				"ShipEntityId",
				MapStateManager.MyShip.Details.EntityId
			} };
			GameController.Contexts.Service<IUiService>().OpenPanel(UI_MyTroopsPanel.Name, parameters);
		}
	}

	private void OnSelectMyCampFakeClick()
	{
		if (MapStateManager.MyCampIsland != null && MapStateManager.MyShipSummary != null)
		{
			Island campIsland = MapDataManager.GetCampIsland(MapStateManager.MyCampId);
			UpdateGvGInstanceZoneInfo();
			Dictionary<string, object> parameters = new Dictionary<string, object>
			{
				{ "Island", campIsland },
				{ "MapStateManager", MapStateManager }
			};
			GameController.Contexts.Service<IUiService>().OpenPanel(UI_MainIslandPanel.Name, parameters);
		}
	}

	private void OnSelectIsland(GameObject target)
	{
		Island islandById = MapDataManager.GetIslandById(((Object)target).name);
		if (MapStateManager.MyCampIsland != null && MapStateManager.MyCampIsland.Id == ((Object)target).name && MapStateManager.MyShipSummary != null)
		{
			OpenMainCampPanel(islandById);
		}
		else if (islandById.Props.Type != IslandType.CampBase)
		{
			IslandSummary islandSummary = islandById.IslandStateManager?.IslandSummary;
			if (islandSummary != null && islandSummary.IslandUIState == eIslandState.Fighting && islandById.DockingManager != null && islandById.DockingManager.HasMyShip())
			{
				OnEnterIsland(islandSummary.Pid, islandSummary.ExternalSocketPort, islandById.Props.Id);
				return;
			}
			Dictionary<string, object> parameters = new Dictionary<string, object>
			{
				{ "Island", islandById },
				{ "MapStateManager", MapStateManager }
			};
			GameController.Contexts.Service<IUiService>().OpenPanel(UI_IslandInfoPanel.Name, parameters);
		}
	}

	public void SetInputEnable(bool flag)
	{
		InputManager.Enabled = flag;
	}

	internal void SetDragEnable(bool flag)
	{
		InputManager.DragEnabled = flag;
	}

	private void Update()
	{
		MapStateManager.CheckState();
		FlightManager.Update();
		if (NeedUpdateView)
		{
			NeedUpdateView = false;
			GvGMapRenderManager.UpdateCheckVisibleObjects();
		}
	}

	public void SetIslandStopInfo(int winnerCampId, int fromIslandId, int islandScore)
	{
		MapStateManager.SetIslandStopInfo(winnerCampId, fromIslandId, islandScore);
	}

	public void HighlightIsland(Island island)
	{
		if (MapEntryManager.IsInitHighLightHidden)
		{
			MapVfxManager.HighlightIsland(island);
		}
	}

	public void ShipBackToCamp()
	{
		MapStateManager.MyShipBackToCamp();
	}

	private void InitPrefabs()
	{
		Transform val = ((Component)this).transform.Find("Prefabs");
		Prefabs = new Dictionary<string, GameObject>();
		for (int i = 0; i < val.childCount; i++)
		{
			Transform child = val.GetChild(i);
			Prefabs.Add(((Object)child).name, ((Component)child).gameObject);
		}
		DefaultAvatarSprite = ((Component)Prefabs["slot_blue"].transform.Find("portrait")).GetComponent<SpriteRenderer>().sprite;
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

	private Transform AddEmptyObject(string name)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Expected O, but got Unknown
		//IL_0024: Unknown result type (might be due to invalid IL or missing references)
		GameObject val = new GameObject(name);
		val.transform.parent = GvGWorldMap.transform;
		val.transform.localScale = Vector3.one;
		return val.transform;
	}

	private IEnumerator MockShips()
	{
		while (true)
		{
			int shipId = ShipManager.CreateFakeShip();
			FlightManager.CreateFakeSchedule(shipId);
			yield return (object)new WaitForSeconds(2f);
		}
	}

	public void UpdateFormationId(string formationId)
	{
		MapStateManager.MyShipSummary.FormationId = formationId;
	}

	public void UpdateMySummaryInfo()
	{
		MapStateManager.MyShipSummary.OldGroupInfo = Singleton<GvGInstanceZone>.Instance.CurrentUnitInfo.Clone();
		MapStateManager.MyShipSummary.GroupInfo = Singleton<GvGInstanceZone>.Instance.CurrentUnitInfo.Clone();
		C2S_GetShipSummaryAndFlightScheduleInfo myShipSummary = MapStateManager.MyShipSummary;
		string formationId = (Singleton<GvGInstanceZone>.Instance.OldFormationId = Singleton<GvGInstanceZone>.Instance.FormationId);
		myShipSummary.FormationId = formationId;
		Singleton<GvGInstanceZone>.Instance.OldUnitInfo = Singleton<GvGInstanceZone>.Instance.CurrentUnitInfo.Clone();
	}

	public void UpdateMySummaryState(int state)
	{
		MapStateManager.MyShipSummary.State = state;
	}

	public void UpdateGvGInstanceZoneInfo()
	{
		if (MapStateManager.MyShipSummary != null)
		{
			Singleton<GvGInstanceZone>.Instance.MyCampUserInfos = MapStateManager.GetCampUsers(MapStateManager.MyCampId);
			Singleton<GvGInstanceZone>.Instance.UpdateCurrentStateInfo(MapStateManager.MyShipSummary, MapStateManager.MyCampId);
		}
	}

	private void UpdateMyLegionInfoOnFillUp()
	{
		MainUI.OnSetShipDetails(MapStateManager.MyShipSummary, MapStateManager.MyCampId);
	}

	public void UpdateShipSummaryStateShipFillingUp(S2C_ChangeShipSummaryStateShipFillingUp.Request dataRequest)
	{
		MapStateManager.MyShipSummary.State = dataRequest.ShipSummaryState;
		MapStateManager.MyShipSummary._jsonFillUpTimestamp = dataRequest.JsonFillUpTimestamp;
		MapStateManager.MyShipSummary._jsonStockInfoBeforeFillUp = dataRequest.JsonStockInfoBeforeFillUp;
		MapStateManager.MyShipSummary.StartFillUpTimestamp = dataRequest.StartFillUpTimestamp;
		MapStateManager.MyShipSummary.GroupInfo = dataRequest.FillUpSoldiers.Clone();
		MapStateManager.MyShipSummary.FillUpTimestamp = new Dictionary<string, int>(dataRequest.FillUpTimestamp);
		MapStateManager.MyShipSummary.OldGroupInfo = dataRequest.StartFillUpSoldiers.Clone();
		MapStateManager.MyShipSummary.StockInfoBeforeFillUp = new Dictionary<string, int>(dataRequest.StockInfoBeforeFillUp);
		UpdateMyLegionInfoOnFillUp();
	}

	public string GetUserCurrentState(C2S_GetShipSummaryAndFlightScheduleInfo details)
	{
		if (details == null)
		{
			return string.Empty;
		}
		string text = "#E5BF73";
		string text2 = MapDataManager.GetIslandById(details.StayIslandId.ToString())?.Name;
		switch (details.State)
		{
		case 0:
		case 1:
		case 2:
		case 3:
			return "[color=" + text + "]驻扎中[/color]" + Environment.NewLine + text2;
		case 4:
		case 8:
		{
			int num = details.FlightSchedule.Route[details.FlightSchedule.Route.Length - 1];
			Island islandById = MapDataManager.GetIslandById(num.ToString());
			string text3 = ((islandById == null) ? string.Empty : islandById.Name);
			return "[color=" + text + "]前往[/color]" + Environment.NewLine + text3;
		}
		case 5:
			return "[color=" + text + "]驻扎中[/color]" + Environment.NewLine + text2;
		case 6:
		case 7:
			return "[color=" + text + "]战斗中[/color]" + Environment.NewLine + text2;
		default:
			return string.Empty;
		}
	}
}
