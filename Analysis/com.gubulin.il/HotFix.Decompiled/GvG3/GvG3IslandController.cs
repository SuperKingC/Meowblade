using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using GvG3OnIsland;
using HotFix;
using HotFix.Sources.Base.Scripts.Utils;
using HotFix.Sources.Base.Sources.Scripts.GvG3.GvG3Common.Model;
using HotFix.Sources.Base.Sources.Scripts.GvG3.GvG3OnIsland.Model;
using HotFix.Sources.Base.Sources.Scripts.GvG3Common.Model;
using HotFix.Sources.Base.Sources.Scripts.GvG3OnIsland.Model;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Manager;
using HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Helper;
using HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Manager;
using Shift.Legion.Common.Helpers;
using Shift.Legion.Common.Managers;
using Shift.Legion.GvG.Common.GvGMode3Island;
using Shift.Legion.GvG.Common.Models.GvGMode3;
using Shift.Legion.GvGServer.Models.GvGMode3IslandSocket;
using Shift.Legion.GvGServer.Models.IslandManagerSocket;
using UI.GvGOnIsland3;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace GvG3;

public class GvG3IslandController : MonoBehaviour
{
	public enum eZoomLevel
	{
		ZoomLevel1,
		ZoomLevel2
	}

	private const float MaxLoadingTimePerFrame = 0f;

	public static GvG3IslandController Instance;

	public static bool IsInstanceCreated;

	public static GameObject GvGIslandMap;

	public static UI_main_GvGOnIsland3 MainUI;

	public GvGMapInputManager InputManager;

	public bool IsInitialized;

	protected eMapViewLevel MapViewLevel;

	private AudioSource Bgm;

	private bool isBgmPlaying;

	public int UserId;

	private Transform FloorTouchTracker;

	protected Transform CameraTracker;

	private GameObject HoldingZone_FX;

	private Dictionary<string, GameObject> Prefabs;

	private int curLODIndex;

	private float LodChangeCamSize;

	private Queue<GvG3Group> WaitToLoadGroupModel_Queue;

	protected CameraBindingManager CameraBindingManager;

	private KeepConnectionManager KeepConnectionManager;

	protected const int MaxVisibleGroup = 50;

	protected ViewUiPositionHelper _uiPositionHelper;

	private List<EntityKeyInfo> EntityKeys;

	protected List<GvG3Group> List_GvGGroup;

	protected Dictionary<int, GvG3Group> Dict_GvGGroup;

	protected Dictionary<int, int> CampShipCount_Dict;

	private CoroutineQueue RequestQueue;

	public int HoldingScorePerSecond;

	protected int IslandId;

	private int InitMyGroupCount;

	public Action<EntityInfo> OnCreateMyShips = delegate
	{
	};

	public Action<S2C_ChangeGvGMode3BestKill.Request> OnChangeBestKill = delegate
	{
	};

	public Action<S2C_GvGMode3ShipKillSoldiersCount.Request> OnChangeMyShipKillSoldiersCount = delegate
	{
	};

	public Action<S2C_GvGMode3ShipBossDamageRank.Request> OnChangeMyShipBossDamage = delegate
	{
	};

	public Action<string> OnChangeHoldingPercentOnIsland = delegate
	{
	};

	public Action<int> OnChangeHoldingCamp = delegate
	{
	};

	public Action<eZoomLevel> OnChangeZoomLevel = delegate
	{
	};

	public Action<S2C_BroadcastGvGMode3BattleResult.Request> OnGetBattleResult = delegate
	{
	};

	public Action<C2S_GetGvGMode3Island_IslandInfo.Response> OnGetInitIslandInfo = delegate
	{
	};

	public Action<CampShipCount> OnChangeCampShipCount = delegate
	{
	};

	public Action OnIslandStop = delegate
	{
	};

	public Action<int> OnRemoveMyGroups;

	public Action<S2C_ShipCanRetreatTimestamp.Request> OnChangeShipCanRetreatTimestamp;

	public Action OnChangeEvent_火力支援 = delegate
	{
	};

	public Action<S2C_GvGStateChange.Request> OnInsuranceShipJoinFighting = delegate
	{
	};

	protected int VisibleGroupCount;

	private HashSet<int> HoldingGroups;

	protected GvG3Group BossGroup;

	public IEvent_火力支援 Event_火力支援;

	public eZoomLevel ZoomLevel { get; internal set; }

	public bool Is火力支援Active => Event_火力支援 != null && Event_火力支援.StillValid((int)GameController.Instance.GetServerTime()) && Event_火力支援.ActivateByUser == UserId;

	public static void CreateInstance(int islandId)
	{
		//IL_003e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0043: Unknown result type (might be due to invalid IL or missing references)
		if (IsInstanceCreated)
		{
			return;
		}
		IsInstanceCreated = true;
		string prefabName = WorldMapConfigHelper.Configs.TryGetIsland(islandId).Props.GDEData.PrefabName;
		GvGIslandMap = Addressables.InstantiateAsync((object)("GvG/" + prefabName), (Transform)null, false, true).WaitForCompletion();
		Instance = GvGIslandMap.AddComponent<GvG3IslandController>();
		Instance.IslandId = islandId;
		((Object)GvGIslandMap).name = $"GvGIsland_{islandId}";
		Instance.Bgm = GvGIslandMap.AddComponent<AudioSource>();
		if (UiAudioManager.Instance.bgmSwitch)
		{
			AssetsManager.Instance.LoadAsset<AudioClip>("GVG_BGM").Then((Action<AudioClip>)delegate(AudioClip clip)
			{
				Instance.Bgm.clip = clip;
				Instance.Bgm.playOnAwake = false;
				Instance.Bgm.loop = true;
				if (Instance.isBgmPlaying)
				{
					Instance.Bgm.Play();
				}
			});
		}
		SharedMessenger.Broadcast("GVG3_ENTER_ISLAND");
	}

	public static void ReleaseInstance()
	{
		if (IsInstanceCreated)
		{
			IsInstanceCreated = false;
			Instance.StopBGM();
			Instance.UnRegisterEventListeners();
			Singleton<CameraService>.Instance.ClearSkybox();
			Instance.CameraBindingManager.OnDestroy();
			SocketManager.Instance.GetConnection(eConType.GvGMode3Island).CloseConnect();
			Addressables.ReleaseInstance(GvGIslandMap);
			GvG3TipsManager.Instance.StopAllTips();
			Instance = null;
		}
	}

	protected virtual void Awake()
	{
		//IL_00b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_0150: Unknown result type (might be due to invalid IL or missing references)
		//IL_0169: Unknown result type (might be due to invalid IL or missing references)
		//IL_0175: Unknown result type (might be due to invalid IL or missing references)
		IsInitialized = false;
		isBgmPlaying = true;
		curLODIndex = -1;
		VisibleGroupCount = 0;
		MapViewLevel = eMapViewLevel.Island;
		LodChangeCamSize = 23.2f;
		UserId = GameController.Contexts.gameState.user.value.UserId;
		RequestQueue = new CoroutineQueue((MonoBehaviour)(object)this);
		Dict_GvGGroup = new Dictionary<int, GvG3Group>();
		List_GvGGroup = new List<GvG3Group>();
		HoldingGroups = new HashSet<int>();
		WaitToLoadGroupModel_Queue = new Queue<GvG3Group>();
		_uiPositionHelper = new ViewUiPositionHelper();
		((Component)this).transform.parent = ((Component)GameController.Instance).gameObject.transform;
		((Component)this).transform.localPosition = Vector3.zero;
		FloorTouchTracker = AddEmptyObject("TouchTracker");
		CameraTracker = AddEmptyObject("CameraTracker");
		Transform obj = ((Component)this).transform.Find("Island/IslandDecoPic/HoldingZone/image/HoldingZone_FX");
		HoldingZone_FX = ((obj != null) ? ((Component)obj).gameObject : null);
		Singleton<CameraService>.Instance.SetSkybox("GvGSkybox");
		InputManager = new GvGMapInputManager();
		InputManager.InitInput(FloorTouchTracker, CameraTracker);
		CameraBindingManager = new CameraBindingManager();
		KeepConnectionManager = new KeepConnectionManager();
		CameraBindingManager.Init(Vector3.zero, 100f, Quaternion.Euler(45f, 0f, 0f));
		SetCamera(Vector3.zero, eZoomLevel.ZoomLevel2);
		RegisterEventListeners();
		InitPrefabs();
	}

	private void RegisterEventListeners()
	{
		GvGMapInputManager inputManager = InputManager;
		inputManager.OnStartDragCamera = (Action)Delegate.Combine(inputManager.OnStartDragCamera, new Action(OnInput_StartDragCamera));
		CameraBindingManager cameraBindingManager = CameraBindingManager;
		cameraBindingManager.OnChangeSize = (Action<float>)Delegate.Combine(cameraBindingManager.OnChangeSize, new Action<float>(OnCameraSizeChange));
		S2C_BroadcastGvGMode3BattleResult.OnPushEvent = (Action<S2C_BroadcastGvGMode3BattleResult.Request>)Delegate.Combine(S2C_BroadcastGvGMode3BattleResult.OnPushEvent, new Action<S2C_BroadcastGvGMode3BattleResult.Request>(OnPushBattleResult));
		S2C_ChangeHoldingCamp.OnPushEvent = (Action<S2C_ChangeHoldingCamp.Request>)Delegate.Combine(S2C_ChangeHoldingCamp.OnPushEvent, new Action<S2C_ChangeHoldingCamp.Request>(OnPushChangeHoldingCamp));
		S2C_GvGStateChange.OnPushEvent = (Action<S2C_GvGStateChange.Request>)Delegate.Combine(S2C_GvGStateChange.OnPushEvent, new Action<S2C_GvGStateChange.Request>(OnPushChangeState));
		S2C_HoldingPercent.OnPushEvent = (Action<S2C_HoldingPercent.Request>)Delegate.Combine(S2C_HoldingPercent.OnPushEvent, new Action<S2C_HoldingPercent.Request>(OnPushChangeHoldingPercent));
		S2C_NewEntityKeyInfo.OnPushEvent = (Action<S2C_NewEntityKeyInfo.Request>)Delegate.Combine(S2C_NewEntityKeyInfo.OnPushEvent, new Action<S2C_NewEntityKeyInfo.Request>(OnPushEntityKeyInfo));
		S2C_GvGMode3IslandStop.OnPushEvent = (Action<S2C_GvGMode3IslandStop.Request>)Delegate.Combine(S2C_GvGMode3IslandStop.OnPushEvent, new Action<S2C_GvGMode3IslandStop.Request>(OnPushIslandStop));
		S2C_GvGMode3ShipDead.OnPushEvent = (Action<S2C_GvGMode3ShipDead.Request>)Delegate.Combine(S2C_GvGMode3ShipDead.OnPushEvent, new Action<S2C_GvGMode3ShipDead.Request>(OnPushShipDead));
		S2C_ChangeGvGMode3BestKill.OnPushEvent = (Action<S2C_ChangeGvGMode3BestKill.Request>)Delegate.Combine(S2C_ChangeGvGMode3BestKill.OnPushEvent, new Action<S2C_ChangeGvGMode3BestKill.Request>(OnPushChangeBestKill));
		S2C_GvGMode3ShipKillSoldiersCount.OnPushEvent = (Action<S2C_GvGMode3ShipKillSoldiersCount.Request>)Delegate.Combine(S2C_GvGMode3ShipKillSoldiersCount.OnPushEvent, new Action<S2C_GvGMode3ShipKillSoldiersCount.Request>(OnPushMyShipKillSoldiersCount));
		S2C_GvGMode3ShipBossDamageRank.OnPushEvent = (Action<S2C_GvGMode3ShipBossDamageRank.Request>)Delegate.Combine(S2C_GvGMode3ShipBossDamageRank.OnPushEvent, new Action<S2C_GvGMode3ShipBossDamageRank.Request>(OnPushMyShipBossDamage));
		S2C_ShipCanRetreatTimestamp.OnPushEvent = (Action<S2C_ShipCanRetreatTimestamp.Request>)Delegate.Combine(S2C_ShipCanRetreatTimestamp.OnPushEvent, new Action<S2C_ShipCanRetreatTimestamp.Request>(OnPushShipCanRetreatTimestamp));
		S2C_Event_火力支援.OnPushEvent = (Action<S2C_Event_火力支援.Request>)Delegate.Combine(S2C_Event_火力支援.OnPushEvent, new Action<S2C_Event_火力支援.Request>(OnPushEvent_火力支援));
	}

	protected void UnRegisterEventListeners()
	{
		GvGMapInputManager inputManager = InputManager;
		inputManager.OnStartDragCamera = (Action)Delegate.Remove(inputManager.OnStartDragCamera, new Action(OnInput_StartDragCamera));
		CameraBindingManager cameraBindingManager = CameraBindingManager;
		cameraBindingManager.OnChangeSize = (Action<float>)Delegate.Remove(cameraBindingManager.OnChangeSize, new Action<float>(OnCameraSizeChange));
		S2C_BroadcastGvGMode3BattleResult.OnPushEvent = (Action<S2C_BroadcastGvGMode3BattleResult.Request>)Delegate.Remove(S2C_BroadcastGvGMode3BattleResult.OnPushEvent, new Action<S2C_BroadcastGvGMode3BattleResult.Request>(OnPushBattleResult));
		S2C_ChangeHoldingCamp.OnPushEvent = (Action<S2C_ChangeHoldingCamp.Request>)Delegate.Remove(S2C_ChangeHoldingCamp.OnPushEvent, new Action<S2C_ChangeHoldingCamp.Request>(OnPushChangeHoldingCamp));
		S2C_GvGStateChange.OnPushEvent = (Action<S2C_GvGStateChange.Request>)Delegate.Remove(S2C_GvGStateChange.OnPushEvent, new Action<S2C_GvGStateChange.Request>(OnPushChangeState));
		S2C_HoldingPercent.OnPushEvent = (Action<S2C_HoldingPercent.Request>)Delegate.Remove(S2C_HoldingPercent.OnPushEvent, new Action<S2C_HoldingPercent.Request>(OnPushChangeHoldingPercent));
		S2C_NewEntityKeyInfo.OnPushEvent = (Action<S2C_NewEntityKeyInfo.Request>)Delegate.Remove(S2C_NewEntityKeyInfo.OnPushEvent, new Action<S2C_NewEntityKeyInfo.Request>(OnPushEntityKeyInfo));
		S2C_GvGMode3IslandStop.OnPushEvent = (Action<S2C_GvGMode3IslandStop.Request>)Delegate.Remove(S2C_GvGMode3IslandStop.OnPushEvent, new Action<S2C_GvGMode3IslandStop.Request>(OnPushIslandStop));
		S2C_GvGMode3ShipDead.OnPushEvent = (Action<S2C_GvGMode3ShipDead.Request>)Delegate.Remove(S2C_GvGMode3ShipDead.OnPushEvent, new Action<S2C_GvGMode3ShipDead.Request>(OnPushShipDead));
		S2C_ChangeGvGMode3BestKill.OnPushEvent = (Action<S2C_ChangeGvGMode3BestKill.Request>)Delegate.Remove(S2C_ChangeGvGMode3BestKill.OnPushEvent, new Action<S2C_ChangeGvGMode3BestKill.Request>(OnPushChangeBestKill));
		S2C_GvGMode3ShipKillSoldiersCount.OnPushEvent = (Action<S2C_GvGMode3ShipKillSoldiersCount.Request>)Delegate.Remove(S2C_GvGMode3ShipKillSoldiersCount.OnPushEvent, new Action<S2C_GvGMode3ShipKillSoldiersCount.Request>(OnPushMyShipKillSoldiersCount));
		S2C_GvGMode3ShipBossDamageRank.OnPushEvent = (Action<S2C_GvGMode3ShipBossDamageRank.Request>)Delegate.Remove(S2C_GvGMode3ShipBossDamageRank.OnPushEvent, new Action<S2C_GvGMode3ShipBossDamageRank.Request>(OnPushMyShipBossDamage));
		S2C_ShipCanRetreatTimestamp.OnPushEvent = (Action<S2C_ShipCanRetreatTimestamp.Request>)Delegate.Remove(S2C_ShipCanRetreatTimestamp.OnPushEvent, new Action<S2C_ShipCanRetreatTimestamp.Request>(OnPushShipCanRetreatTimestamp));
		S2C_Event_火力支援.OnPushEvent = (Action<S2C_Event_火力支援.Request>)Delegate.Remove(S2C_Event_火力支援.OnPushEvent, new Action<S2C_Event_火力支援.Request>(OnPushEvent_火力支援));
	}

	public void ConnectToIsland(int pid, int port)
	{
		SocketManager.Instance.GetConnection(eConType.GvGMode3Island).StartConnect(HotUpdateProcess.Instance.Configs["SocketHost"], port, pid, delegate
		{
			if (!((Component)this).gameObject.activeInHierarchy)
			{
				ILRuntimeDebug.LogError("[GvGIslandController] gameObject is inactive");
				SentrySdk.AddBreadcrumb("[GvGIslandController] gameObject is inactive");
			}
			((MonoBehaviour)this).StartCoroutine(InitProcess());
		});
	}

	public void SwitchZooming()
	{
		eZoomLevel level = ((ZoomLevel == eZoomLevel.ZoomLevel1) ? eZoomLevel.ZoomLevel2 : eZoomLevel.ZoomLevel1);
		Zoom(level);
	}

	public void SwitchZooming(eZoomLevel level)
	{
		Zoom(level);
	}

	protected virtual void Zoom(eZoomLevel level, bool isImmediate = false)
	{
		//IL_009e: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a3: Unknown result type (might be due to invalid IL or missing references)
		ZoomLevel = level;
		float num = 17.5f;
		switch (ZoomLevel)
		{
		case eZoomLevel.ZoomLevel1:
			num = 17.5f;
			break;
		case eZoomLevel.ZoomLevel2:
			num = 46f;
			break;
		}
		CameraBindingManager.SetTargetCamSize(num);
		if (isImmediate)
		{
			CameraBindingManager.CamSize = num;
		}
		else
		{
			CameraBindingManager.CamSize_CatchupInTime(0.5f);
		}
		if ((Object)(object)CameraTracker != (Object)null && (Object)(object)Instance != (Object)null)
		{
			CameraTracker.position = PosChecker_Island(Instance.ZoomLevel, CameraTracker.position);
		}
		OnChangeZoomLevel?.Invoke(ZoomLevel);
	}

	private void SetCamera(Vector3 pos, eZoomLevel level)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_001a: Unknown result type (might be due to invalid IL or missing references)
		CameraTracker.localPosition = pos;
		CameraBindingManager.SetTarget(CameraTracker.position);
		CameraBindingManager.FollowImmediately();
		Zoom(level, isImmediate: true);
	}

	public void FocusGroupByEntityId(int entityId)
	{
		if (Dict_GvGGroup.TryGetValue(entityId, out var value))
		{
			FocusGroup(value);
		}
	}

	private void FocusGroup(GvG3Group group)
	{
		CameraBindingManager.SetTarget(group.GroupIcon.transform);
		CameraBindingManager.CatchupInTime(0.7f);
		Zoom(eZoomLevel.ZoomLevel1);
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

	private void OnCameraSizeChange(float size)
	{
		int num = ((!(size < LodChangeCamSize)) ? 1 : 0);
		MapViewLevel = ((num == 0) ? eMapViewLevel.BattleField : eMapViewLevel.Island);
		if (Dict_GvGGroup == null || Dict_GvGGroup.Count == 0 || num == curLODIndex)
		{
			return;
		}
		curLODIndex = num;
		SharedMessenger.Broadcast("ON_LOD_CHANGE", num);
		foreach (GvG3Group item in List_GvGGroup)
		{
			item.UpdateMapViewLevel(MapViewLevel);
		}
	}

	private void PlayBGM()
	{
		if (!Bgm.isPlaying)
		{
			Bgm.Play();
		}
		isBgmPlaying = true;
	}

	private void PauseBGM()
	{
		if (Bgm.isPlaying)
		{
			Bgm.Pause();
		}
		isBgmPlaying = false;
	}

	public void StopBGM()
	{
		if (Bgm.isPlaying)
		{
			Bgm.Stop();
		}
		isBgmPlaying = false;
	}

	protected virtual void CheckIslandHoldingEffectOnGroupStateChange(int entityId, eGvGMode3FightingState state)
	{
		if (state == eGvGMode3FightingState.Holding)
		{
			HoldingGroups.Add(entityId);
		}
		else if (HoldingGroups.Contains(entityId))
		{
			HoldingGroups.Remove(entityId);
		}
		HoldingZone_FX.SetActive(HoldingGroups.Count > 0);
	}

	private Transform AddEmptyObject(string name)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Expected O, but got Unknown
		//IL_0024: Unknown result type (might be due to invalid IL or missing references)
		GameObject val = new GameObject(name);
		val.transform.parent = GvGIslandMap.transform;
		val.transform.localScale = Vector3.one;
		return val.transform;
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

	private void RenderIslandDeco(int islandId)
	{
		Transform val = GvGIslandMap.transform.Find("Island");
		Transform val2 = val.Find("MainIsland");
		Transform val3 = val.Find("IslandDecoPic");
		Transform val4 = val.Find("DecoIsland");
		Random.InitState(islandId);
		int num = Random.Range(0, val2.childCount);
		for (int i = 0; i < val2.childCount; i++)
		{
			((Component)val2.GetChild(i)).gameObject.SetActive(i == num);
		}
		num = Random.Range(0, val3.childCount);
		for (int j = 0; j < val3.childCount; j++)
		{
			((Component)val3.GetChild(j)).gameObject.SetActive(j == num);
		}
		num = Random.Range(0, val4.childCount);
		for (int k = 0; k < val4.childCount; k++)
		{
			((Component)val4.GetChild(k)).gameObject.SetActive(k == num);
		}
	}

	protected virtual void Update()
	{
		KeepConnectionManager.Update();
		CameraBindingManager.Update();
		float num = Time.realtimeSinceStartup + 0f;
		while (WaitToLoadGroupModel_Queue.Count > 0)
		{
			GvG3Group gvG3Group = WaitToLoadGroupModel_Queue.Peek();
			if (gvG3Group.IsDead || !MoveNextRecursive(gvG3Group.LoadingCoroutine))
			{
				WaitToLoadGroupModel_Queue.Dequeue();
			}
			if (Time.realtimeSinceStartup > num)
			{
				break;
			}
		}
	}

	private bool MoveNextRecursive(IEnumerator enumerator)
	{
		if (enumerator.Current is IEnumerator && MoveNextRecursive((IEnumerator)enumerator.Current))
		{
			return true;
		}
		return enumerator.MoveNext();
	}

	public virtual Vector3 PosChecker_Island(eZoomLevel zoomLevel, Vector3 cur)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_00be: Unknown result type (might be due to invalid IL or missing references)
		float num = cur.x;
		float num2 = cur.z;
		float num3 = 0f;
		float num4 = 39f;
		float num5 = -157f;
		float num6 = -42f;
		switch (zoomLevel)
		{
		case eZoomLevel.ZoomLevel1:
			num3 = -40f;
			num4 = 40f;
			num5 = -50f;
			num6 = 50f;
			break;
		case eZoomLevel.ZoomLevel2:
			num3 = 0f;
			num4 = 0f;
			num5 = 0f;
			num6 = 0f;
			break;
		}
		if (num < num3)
		{
			num = num3;
		}
		if (num > num4)
		{
			num = num4;
		}
		if (num2 < num5)
		{
			num2 = num5;
		}
		if (num2 > num6)
		{
			num2 = num6;
		}
		Vector3 result = default(Vector3);
		((Vector3)(ref result))._002Ector(num, cur.y, num2);
		return result;
	}

	private IEnumerator InitProcess()
	{
		BossGroup = null;
		GetEOIEntities();
		while (EntityKeys == null)
		{
			yield return null;
		}
		CampShipCount_Dict = new Dictionary<int, int>();
		InitShipCount(EntityKeys);
		yield return GetEntityInfos(EntityKeys.GetRange(0, InitMyGroupCount));
		GetIslandInfo();
		yield return GetEntityInfos(EntityKeys.GetRange(1, EntityKeys.Count - 1));
	}

	protected void InitShipCount(List<EntityKeyInfo> entityKeys)
	{
		foreach (EntityKeyInfo entityKey in entityKeys)
		{
			if (!CampShipCount_Dict.ContainsKey(entityKey.CampId))
			{
				CampShipCount_Dict.Add(entityKey.CampId, 1);
			}
			else
			{
				CampShipCount_Dict[entityKey.CampId]++;
			}
		}
		int total = CampShipCount_Dict.Values.Sum();
		foreach (KeyValuePair<int, int> item in CampShipCount_Dict)
		{
			OnChangeCampShipCount?.Invoke(new CampShipCount
			{
				CampId = item.Key,
				ShipCount = item.Value,
				Total = total
			});
		}
	}

	private void GetEOIEntities()
	{
		SocketManager.Instance.GetConnection(eConType.GvGMode3Island).Request(new C2S_GetGvGMode3Island_EOIEntities
		{
			Req = new C2S_GetGvGMode3Island_EOIEntities.Request
			{
				NonStr = ""
			}
		}, delegate(SocketManager.BaseSocketPackageBodyContext context_response)
		{
			C2S_GetGvGMode3Island_EOIEntities.Response response = (C2S_GetGvGMode3Island_EOIEntities.Response)context_response.Resp;
			if (response.ErrorCode < 0)
			{
				ILRequestHelper.ShowErrorCode(response.ErrorCode);
			}
			else if (response.Infos == null)
			{
				ILRuntimeDebug.LogError("请求 C2S_GetGvGMode2Island_EOIEntities 返回的 Infos 为 null");
			}
			else
			{
				SwapMyGroupToFront(response.Infos);
				EntityKeys = response.Infos;
			}
		});
	}

	private IEnumerator GetEntityInfos(List<EntityKeyInfo> waitToGetInfo)
	{
		int MAX_GET_COUNT = 5;
		List<int> groupList = new List<int>();
		foreach (EntityKeyInfo inf in waitToGetInfo)
		{
			groupList.Add(inf.EntityId);
		}
		int curIndex = 0;
		bool isReadyToGet = true;
		while (curIndex < groupList.Count)
		{
			if (isReadyToGet)
			{
				isReadyToGet = false;
				int getCount = Mathf.Min(MAX_GET_COUNT, groupList.Count - curIndex);
				SocketManager.Instance.GetConnection(eConType.GvGMode3Island).Request(new C2S_GetGvGMode3Island_EntityInfo
				{
					Req = new C2S_GetGvGMode3Island_EntityInfo.Request
					{
						EntityIds = groupList.GetRange(curIndex, getCount)
					}
				}, delegate(SocketManager.BaseSocketPackageBodyContext context_response)
				{
					isReadyToGet = true;
					C2S_GetGvGMode3Island_EntityInfo.Response response = (C2S_GetGvGMode3Island_EntityInfo.Response)context_response.Resp;
					if (response.ErrorCode < 0)
					{
						ILRequestHelper.ShowErrorCode(response.ErrorCode);
					}
					else if (response.Entities == null)
					{
						ILRuntimeDebug.LogError("请求 C2S_GetGvGMode2Island_EntityInfo 返回的 Entities 为 null");
					}
					else
					{
						foreach (EntityInfo entity in response.Entities)
						{
							TryCreateGroup(entity);
						}
						curIndex += getCount;
					}
				});
			}
			yield return null;
		}
	}

	private void GetIslandInfo()
	{
		SocketManager.Instance.GetConnection(eConType.GvGMode3Island).Request(new C2S_GetGvGMode3Island_IslandInfo
		{
			Req = new C2S_GetGvGMode3Island_IslandInfo.Request
			{
				NonStr = ""
			}
		}, delegate(SocketManager.BaseSocketPackageBodyContext context_response)
		{
			C2S_GetGvGMode3Island_IslandInfo.Response response = (C2S_GetGvGMode3Island_IslandInfo.Response)context_response.Resp;
			if (response.ErrorCode < 0)
			{
				ILRequestHelper.ShowErrorCode(response.ErrorCode);
			}
			else
			{
				if (response.NormalRankData == null)
				{
					response.NormalRankData = new List<GvGMode3IslandRankInfo>();
				}
				OnInitIslandInfo(response);
			}
		});
	}

	public void ChangeBattleStrategy(int shipEntityId, int targetCampId, Action onSuccess)
	{
		SocketManager.Instance.GetConnection(eConType.GvGMode3Island).Request(new C2S_ChangeGvGMode3BattleStrategy
		{
			Req = new C2S_ChangeGvGMode3BattleStrategy.Request
			{
				ShipEntityId = shipEntityId,
				CampId = targetCampId
			}
		}, delegate(SocketManager.BaseSocketPackageBodyContext context_response)
		{
			C2S_ChangeGvGMode3BattleStrategy.Response response = (C2S_ChangeGvGMode3BattleStrategy.Response)context_response.Resp;
			if (response.ErrorCode < 0)
			{
				ILRequestHelper.ShowErrorCode(response.ErrorCode);
			}
			else
			{
				onSuccess();
			}
		});
	}

	public void RetreatShip(int shipEntityId, Action onSuccess = null)
	{
		SocketManager.Instance.GetConnection(eConType.GvGMode3Island).Request(new C2S_ShipRetreat
		{
			Req = new C2S_ShipRetreat.Request
			{
				ShipEntityId = shipEntityId
			}
		}, delegate(SocketManager.BaseSocketPackageBodyContext context_response)
		{
			C2S_ShipRetreat.Response response = (C2S_ShipRetreat.Response)context_response.Resp;
			if (response.ErrorCode < 0)
			{
				ILRequestHelper.ShowErrorCode(response.ErrorCode);
			}
			else
			{
				onSuccess?.Invoke();
			}
		});
	}

	protected virtual void TryCreateGroup(EntityInfo groupData, bool isSpawn = false)
	{
		//IL_00dc: Unknown result type (might be due to invalid IL or missing references)
		int entityId = groupData.EntityId;
		if (!Dict_GvGGroup.ContainsKey(entityId) && !groupData.IsDead)
		{
			GameObject val = InstantiateFromPrefab("GvGGroup");
			val.transform.SetParent(GvGIslandMap.transform, false);
			((Object)val).name = $"Entity{groupData.EntityId}";
			GvG3Group gvG3Group = val.AddComponent<GvG3Group>();
			gvG3Group.IsCreating = true;
			gvG3Group.EntityId = groupData.EntityId;
			gvG3Group.UserId = groupData.UserId;
			gvG3Group.GvGRole = (eGvG3Role)groupData.GvGRole;
			gvG3Group.SetIsCurUser(gvG3Group.UserId == UserId);
			gvG3Group.SetGroupDataToUI(groupData, IslandId);
			gvG3Group.SetBornPos(new Vector3(groupData.X / 1000f, 0f, groupData.Y / 1000f));
			gvG3Group.SetFormation(groupData.FormationId);
			gvG3Group.SetUnitInfo(groupData.UnitsInfo);
			gvG3Group.SetSpeed(groupData.GroupSpeed / 1000f);
			gvG3Group.SetCampId(groupData.CampId);
			gvG3Group.SetRoleFace(groupData.RoleFace);
			gvG3Group.UpdateMapViewLevel(MapViewLevel);
			gvG3Group.SetState((eGvGMode3FightingState)groupData.GvGMode3State, groupData.X, groupData.Y, groupData.RoleFace, groupData.GvGMode3StateData, groupData.HoldingScorePerSecond);
			if (groupData.debug_MatrixWidth > 0f)
			{
				gvG3Group.SetDebugMatrixWidth(groupData.debug_MatrixWidth / 1000f);
			}
			if (isSpawn)
			{
				gvG3Group.SetSpawning();
			}
			else
			{
				gvG3Group.SetAppear();
			}
			if (gvG3Group.UserId == UserId)
			{
				OnCreateMyShips?.Invoke(groupData);
			}
			if (gvG3Group.IsBossGroup)
			{
				BossGroup = gvG3Group;
			}
			AddGroup(gvG3Group);
			CheckIslandHoldingEffectOnGroupStateChange(entityId, (eGvGMode3FightingState)groupData.GvGMode3State);
		}
	}

	private void OnInitIslandInfo(C2S_GetGvGMode3Island_IslandInfo.Response info)
	{
		OnGetInitIslandInfo?.Invoke(info);
		OnChangeHoldingPercentOnIsland?.Invoke(info.HoldingPercent);
		OnChangeHoldingCamp?.Invoke(info.HoldingCamp);
		HoldingScorePerSecond = 1;
		OnPushChangeBestKill(new S2C_ChangeGvGMode3BestKill.Request
		{
			BestKill = info.BestKill
		});
		if (info.isSystemPaused)
		{
			OnIslandStop?.Invoke();
		}
		Event_火力支援 = info.Event_火力支援;
		OnChangeEvent_火力支援?.Invoke();
		if (Event_火力支援 == null)
		{
		}
	}

	protected void OnPushChangeState(S2C_GvGStateChange.Request req)
	{
		int entityId = req.EntityId;
		if (Dict_GvGGroup.TryGetValue(entityId, out var value))
		{
			eGvGMode3FightingState state = (eGvGMode3FightingState)req.State;
			value.SetState(state, req.X, req.Y, req.RoleFace, req.Data, req.HoldingScorePerSecond);
			CheckIslandHoldingEffectOnGroupStateChange(entityId, state);
			if (state == eGvGMode3FightingState.Fighting && req.IsInsuranceShip)
			{
				OnInsuranceShipJoinFighting?.Invoke(req);
			}
		}
	}

	private void OnPushEntityKeyInfo(S2C_NewEntityKeyInfo.Request req)
	{
		int campId = req.KeyInfo.CampId;
		if (!CampShipCount_Dict.ContainsKey(campId))
		{
			CampShipCount_Dict.Add(campId, 1);
		}
		else
		{
			CampShipCount_Dict[campId]++;
		}
		int total = CampShipCount_Dict.Values.Sum();
		OnChangeCampShipCount?.Invoke(new CampShipCount
		{
			CampId = campId,
			ShipCount = CampShipCount_Dict[campId],
			Total = total
		});
		RequestQueue.AddCoroutine(GetEntityInfos(new List<EntityKeyInfo> { req.KeyInfo }));
	}

	private void OnPushChangeHoldingPercent(S2C_HoldingPercent.Request req)
	{
		OnChangeHoldingPercentOnIsland?.Invoke(req.HoldingPercent);
	}

	private void OnPushChangeHoldingCamp(S2C_ChangeHoldingCamp.Request req)
	{
		OnChangeHoldingCamp?.Invoke(req.HoldingCamp);
	}

	protected void OnPushBattleResult(S2C_BroadcastGvGMode3BattleResult.Request req)
	{
		OnGetBattleResult?.Invoke(req);
		foreach (GvGMode3BattleResult gvGMode3BattleResult in req.GvGMode3BattleResults)
		{
			GvG3GroupForEach(gvGMode3BattleResult);
		}
	}

	private void GvG3GroupForEach(GvGMode3BattleResult info)
	{
		if (Dict_GvGGroup.TryGetValue(info.EntityId, out var value))
		{
			PlayTip(GenerateTips(info, value));
			SetGroupSoldierRemaining(info.EntityId, info.SoldierRemaining);
		}
	}

	protected void SetGroupSoldierRemaining(int entityId, int remainCount)
	{
		if (Dict_GvGGroup.TryGetValue(entityId, out var value))
		{
			value.SetSoldierNum(remainCount);
		}
	}

	protected virtual List<GvG3PlayTipParam> GenerateTips(GvGMode3BattleResult info, GvG3Group group)
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_0019: Unknown result type (might be due to invalid IL or missing references)
		//IL_001a: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0204: Unknown result type (might be due to invalid IL or missing references)
		//IL_0211: Unknown result type (might be due to invalid IL or missing references)
		//IL_0216: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fe: Unknown result type (might be due to invalid IL or missing references)
		//IL_010b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0110: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d0: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d5: Unknown result type (might be due to invalid IL or missing references)
		List<GvG3PlayTipParam> list = new List<GvG3PlayTipParam>(3);
		Vector3 position = group.AvatarIcon.transform.position;
		Vector2 val = EffectHelper.WorldToFguiPos(position);
		double num = ((MapViewLevel == eMapViewLevel.BattleField) ? 1.0 : 0.8);
		int obCampId = Singleton<GvGMode3RoomManager>.Instance.ObserverRecord.ObCampId;
		string value = $"-{info.SoldierCost}";
		int num2 = 0;
		bool flag = false;
		string value2 = $"+{info.机械降神Increase}";
		int num3 = 0;
		bool flag2 = false;
		if (group.IsCurUser)
		{
			num2 = 0;
			num3 = 0;
			if ((Object)(object)BossGroup != (Object)null && info.BossDamage >= 0)
			{
				list.Add(new GvG3PlayTipParam
				{
					Param = new Dictionary<string, object>
					{
						{
							"Content",
							$"{info.BossDamage}"
						},
						{
							"Pos",
							val + _uiPositionHelper.DamageUiOffset(MapViewLevel)
						},
						{ "Type", 1 },
						{
							"Scale",
							num * 1.2000000476837158
						}
					},
					ShowTime = Time.time
				});
			}
		}
		else if (group.IsCurUserTarget)
		{
			num2 = 2;
			flag = true;
			num3 = 2;
		}
		else if (group.IsAlly(obCampId))
		{
			num2 = 1;
			num3 = 1;
			flag2 = true;
		}
		else if (group.OtherEnemy(obCampId))
		{
			num2 = 3;
			num3 = 3;
		}
		else if (group.IsBossGroup)
		{
			num2 = 4;
			flag = true;
		}
		if (info.SoldierCost > 0)
		{
			list.Add(new GvG3PlayTipParam
			{
				Param = new Dictionary<string, object>
				{
					{ "Content", value },
					{
						"Pos",
						val + _uiPositionHelper.SoldierCostOffset(MapViewLevel)
					},
					{ "Type", 2 },
					{ "Scale", num },
					{ "UseStrong", flag },
					{ "CostUiType", num2 }
				},
				ShowTime = Time.time
			});
		}
		if (info.机械降神Increase > 0)
		{
			list.Add(new GvG3PlayTipParam
			{
				Param = new Dictionary<string, object>
				{
					{ "Content", value2 },
					{
						"Pos",
						val + _uiPositionHelper.机械降神IncreaseOffset(MapViewLevel)
					},
					{ "Type", 3 },
					{ "Scale", num },
					{ "UseStrong", flag2 },
					{ "机械降神IncreaseUiType", num3 }
				},
				ShowTime = Time.time + 0.25f
			});
		}
		return list;
	}

	protected void PlayTip(List<GvG3PlayTipParam> playParams)
	{
		foreach (GvG3PlayTipParam playParam in playParams)
		{
			GvG3TipsManager.Instance.PlayTip(playParam.Param, playParam.ShowTime);
		}
	}

	protected virtual void OnPushShipDead(S2C_GvGMode3ShipDead.Request req)
	{
		GvG3Group gvG3Group = RemoveGroupById(req.EntityId);
		if ((Object)(object)gvG3Group != (Object)null && gvG3Group.IsBossGroup)
		{
			BossGroup = null;
		}
		gvG3Group?.SetDead();
	}

	private void OnPushIslandStop(S2C_GvGMode3IslandStop.Request req)
	{
		if (req.IsStop)
		{
			OnIslandStop?.Invoke();
		}
	}

	protected void OnPushChangeBestKill(S2C_ChangeGvGMode3BestKill.Request req)
	{
		OnChangeBestKill?.Invoke(req);
	}

	private void OnPushMyShipKillSoldiersCount(S2C_GvGMode3ShipKillSoldiersCount.Request req)
	{
		OnChangeMyShipKillSoldiersCount?.Invoke(req);
	}

	private void OnPushMyShipBossDamage(S2C_GvGMode3ShipBossDamageRank.Request req)
	{
		OnChangeMyShipBossDamage?.Invoke(req);
	}

	private void OnPushShipCanRetreatTimestamp(S2C_ShipCanRetreatTimestamp.Request req)
	{
		OnChangeShipCanRetreatTimestamp?.Invoke(req);
	}

	private void OnPushEvent_火力支援(S2C_Event_火力支援.Request req)
	{
		Event_火力支援 = req.Event_火力支援;
		OnChangeEvent_火力支援?.Invoke();
		if (Event_火力支援 == null)
		{
		}
	}

	protected void AddGroup(GvG3Group group)
	{
		Dict_GvGGroup.Add(group.EntityId, group);
		WaitToLoadGroupModel_Queue.Enqueue(group);
		if (group.UserId == UserId || group.IsBossGroup)
		{
			List_GvGGroup.Insert(0, group);
			group.IsVisibleByPriority = true;
			VisibleGroupCount++;
			return;
		}
		List_GvGGroup.Add(group);
		if (VisibleGroupCount < 50)
		{
			group.IsVisibleByPriority = true;
			VisibleGroupCount++;
		}
	}

	protected GvG3Group RemoveGroupById(int entityId)
	{
		if (!Dict_GvGGroup.TryGetValue(entityId, out var value))
		{
			return null;
		}
		RemoveGroup(value);
		return value;
	}

	private void RemoveGroup(GvG3Group group)
	{
		Dict_GvGGroup.Remove(group.EntityId);
		int num = List_GvGGroup.IndexOf(group);
		List_GvGGroup.RemoveAt(num);
		int campId = group.CampId;
		if (CampShipCount_Dict.ContainsKey(campId))
		{
			CampShipCount_Dict[campId]--;
			int total = CampShipCount_Dict.Values.Sum();
			OnChangeCampShipCount?.Invoke(new CampShipCount
			{
				CampId = campId,
				ShipCount = CampShipCount_Dict[campId],
				Total = total
			});
		}
		if (num <= VisibleGroupCount)
		{
			group.IsVisibleByPriority = false;
			VisibleGroupCount--;
		}
		if (VisibleGroupCount < Math.Min(50, List_GvGGroup.Count))
		{
			List_GvGGroup[VisibleGroupCount].IsVisibleByPriority = true;
			VisibleGroupCount++;
		}
		if (group.UserId == UserId)
		{
			OnRemoveMyGroups?.Invoke(group.EntityId);
		}
	}

	public GvG3Group GetGroupById(int e_id)
	{
		if (Dict_GvGGroup.TryGetValue(e_id, out var value))
		{
			return value;
		}
		return null;
	}

	public IEnumerator GetGroupById_WaitUntilSpwan(int e_id, Action<GvG3Group> callback)
	{
		int maxWaitCount = 50;
		GvG3Group group = GetGroupById(e_id);
		while ((Object)(object)group == (Object)null)
		{
			yield return (object)new WaitForSeconds(0.1f);
			int num = maxWaitCount - 1;
			maxWaitCount = num;
			if (num < 0)
			{
				yield break;
			}
			group = GetGroupById(e_id);
		}
		callback(group);
	}

	private void SwapMyGroupToFront(List<EntityKeyInfo> list)
	{
		int num = 0;
		for (int i = 0; i < list.Count; i++)
		{
			if (list[i].UserId == UserId)
			{
				EntityKeyInfo value = list[i];
				list[i] = list[num];
				list[num] = value;
				num++;
			}
		}
		InitMyGroupCount = num;
	}
}
