using System;
using System.Collections;
using System.Collections.Generic;
using FairyGUI;
using GvG2.Common.Models;
using HotFix;
using HotFix.Sources.Base.Scripts.Utils;
using Shift.Legion.Common.Helpers;
using Shift.Legion.Common.Managers;
using Shift.Legion.Common.Services;
using Shift.Legion.GvG.Common.Enums;
using Shift.Legion.GvG.Common.GvGMode2Island;
using Shift.Legion.GvG.Common.Model;
using Shift.Legion.GvGServer.Models.GvGMode2IslandSocket;
using Shift.Legion.GvGServer.Models.IslandManagerSocket;
using Shift.Legion.Helpers;
using UI.GvGWorldMap2;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace GvG2;

public class GvGIslandController : MonoBehaviour
{
	public static GvGIslandController Instance;

	public static bool IsInstanceCreated;

	public static GameObject GvGIslandMap;

	public static UI_GvGWorldMap2 MainUI;

	public Texture2D NoiseTexture;

	public Shader AnimMapShader;

	private GvGMapInputManager InputManager;

	private AudioSource Bgm;

	private bool isBgmPlaying;

	public bool IsInitialized;

	private int UserId;

	private Transform FloorTouchTracker;

	private Transform CameraTracker;

	private CameraBindingHandler CamBinder;

	private Dictionary<string, GameObject> Prefabs;

	private int curLODIndex;

	private int ZoomLevel;

	private float LodChangeCamSize;

	private Coroutine DisableDragCoroutine;

	private eMapViewLevel MapViewLevel;

	private int MapPort;

	private int MapPid;

	private List<EntityKeyInfo> EntityKeys;

	private GvG2Group MyGroup;

	private List<GvG2Group> List_GvGGroup;

	public Dictionary<int, GvG2Group> Dict_GvGGroup;

	public CoroutineQueue RequestQueue;

	private CoroutineQueue BeskKillCoroutineQueue;

	public int HoldingScorePerSecond;

	public int IslandId;

	private int IslandScore;

	private int WinnerCamp;

	private bool IsStop;

	public static void CreateInstance(int islandPid, int islandExternalSocketPort, UI_GvGWorldMap2 mainUI, int islandId)
	{
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0055: Unknown result type (might be due to invalid IL or missing references)
		//IL_005a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0069: Unknown result type (might be due to invalid IL or missing references)
		//IL_006e: Unknown result type (might be due to invalid IL or missing references)
		if (IsInstanceCreated)
		{
			return;
		}
		IsInstanceCreated = true;
		MainUI = mainUI;
		GvGIslandMap = Addressables.InstantiateAsync((object)"GvG/IslandBattleField", (Transform)null, false, true).WaitForCompletion();
		Instance = GvGIslandMap.AddComponent<GvGIslandController>();
		Instance.RenderIslandDeco(islandId);
		Texture2D noiseTexture = Addressables.LoadAssetAsync<Texture2D>((object)"GvGAniMapSoldier/AnimMapShaderNoise.asset").WaitForCompletion();
		Shader animMapShader = Addressables.LoadAssetAsync<Shader>((object)"GvGAniMapSoldier/AnimMapShader2").WaitForCompletion();
		Instance.NoiseTexture = noiseTexture;
		Instance.AnimMapShader = animMapShader;
		Instance.Bgm = GvGIslandMap.AddComponent<AudioSource>();
		Instance.ConnectToIsland(islandPid, islandExternalSocketPort);
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
		SharedMessenger.Broadcast("GVG2_ENTER_ISLAND");
	}

	public static void ReleaseInstance()
	{
		if (IsInstanceCreated)
		{
			IsInstanceCreated = false;
			Instance.StopBGM();
			Instance.UnRegisterEventListeners();
			Singleton<CameraService>.Instance.ClearSkybox();
			Singleton<CameraService>.Instance.StopBinding();
			SocketManager.Instance.GetConnection(eConType.GvGMode2Island).CloseConnect();
			Addressables.ReleaseInstance(GvGIslandMap);
			Addressables.Release<Texture2D>(Instance.NoiseTexture);
			Addressables.Release<Shader>(Instance.AnimMapShader);
			GvG2TipsManager.Instance.StopAllTips();
			Instance = null;
		}
	}

	private void Awake()
	{
		//IL_0048: Unknown result type (might be due to invalid IL or missing references)
		//IL_007b: Unknown result type (might be due to invalid IL or missing references)
		IsInitialized = false;
		isBgmPlaying = true;
		((Object)GvGIslandMap).name = "GvGWorldMap";
		GvGIslandMap.transform.parent = ((Component)GameController.Instance).gameObject.transform;
		GvGIslandMap.transform.localPosition = Vector3.zero;
		FloorTouchTracker = AddEmptyObject("TouchTracker");
		CameraTracker = AddEmptyObject("CameraTracker");
		CameraTracker.localPosition = Vector3.zero;
		Singleton<CameraService>.Instance.SetSkybox("GvGSkybox");
		Singleton<CameraService>.Instance.SwitchToScene("SceneGVG2");
		CamBinder = Singleton<CameraService>.Instance.BindTarget(CameraTracker, 57.5f, 0f);
		LodChangeCamSize = 25.5f;
		ZoomLevel = 2;
		MapViewLevel = eMapViewLevel.Island;
		MainUI.SwitchToOnIslandMode();
		MainUI.SetZoomLevel(ZoomLevel);
		InitPrefabs();
		InputManager = new GvGMapInputManager();
		InputManager.InitInput(FloorTouchTracker, CameraTracker);
		UserId = GameController.Contexts.gameState.user.value.UserId;
		RequestQueue = new CoroutineQueue((MonoBehaviour)(object)this);
		BeskKillCoroutineQueue = new CoroutineQueue((MonoBehaviour)(object)this);
		Dict_GvGGroup = new Dictionary<int, GvG2Group>();
		List_GvGGroup = new List<GvG2Group>();
		curLODIndex = -1;
		RegisterEventListeners();
	}

	private void RegisterEventListeners()
	{
		//IL_0042: Unknown result type (might be due to invalid IL or missing references)
		//IL_004c: Expected O, but got Unknown
		UI_GvGWorldMap2 mainUI = MainUI;
		mainUI.OnNotUIInput = (Action)Delegate.Combine(mainUI.OnNotUIInput, new Action(InputManager.UpdateInput));
		((GObject)MainUI.Zoom).onClick.Add(new EventCallback0(OnZoom));
		UI_GvGWorldMap2 mainUI2 = MainUI;
		mainUI2.OnSelectStategy = (Action<int>)Delegate.Combine(mainUI2.OnSelectStategy, new Action<int>(ChangeBattleStrategy));
		CameraBinding cameraBinding = CamBinder.CameraBinding;
		cameraBinding.OnChangeSize = (Action<float>)Delegate.Combine(cameraBinding.OnChangeSize, new Action<float>(OnCameraSizeChange));
		S2C_BroadcastGvGMode2BattleResult.OnPushEvent = (Action<S2C_BroadcastGvGMode2BattleResult.Request>)Delegate.Combine(S2C_BroadcastGvGMode2BattleResult.OnPushEvent, new Action<S2C_BroadcastGvGMode2BattleResult.Request>(OnBattleResult));
		S2C_GvGMode2_ChangeHoldingCamp.OnPushEvent = (Action<S2C_GvGMode2_ChangeHoldingCamp.Request>)Delegate.Combine(S2C_GvGMode2_ChangeHoldingCamp.OnPushEvent, new Action<S2C_GvGMode2_ChangeHoldingCamp.Request>(OnChangeHoldingCamp));
		S2C_GvGMode2StateChange.OnPushEvent = (Action<S2C_GvGMode2StateChange.Request>)Delegate.Combine(S2C_GvGMode2StateChange.OnPushEvent, new Action<S2C_GvGMode2StateChange.Request>(OnChangeState));
		S2C_GvGMode2_HoldingPercent.OnPushEvent = (Action<S2C_GvGMode2_HoldingPercent.Request>)Delegate.Combine(S2C_GvGMode2_HoldingPercent.OnPushEvent, new Action<S2C_GvGMode2_HoldingPercent.Request>(OnChangeHoldingPercent));
		S2C_StartOneGvGMode2Battle.OnPushEvent = (Action<S2C_StartOneGvGMode2Battle.Request>)Delegate.Combine(S2C_StartOneGvGMode2Battle.OnPushEvent, new Action<S2C_StartOneGvGMode2Battle.Request>(OnStartOneGvGMode2Battle));
		S2C_GvGMode2_NewEntityKeyInfo.OnPushEvent = (Action<S2C_GvGMode2_NewEntityKeyInfo.Request>)Delegate.Combine(S2C_GvGMode2_NewEntityKeyInfo.OnPushEvent, new Action<S2C_GvGMode2_NewEntityKeyInfo.Request>(OnEntityKeyInfo));
		S2C_GvGMode2IslandStop.OnPushEvent = (Action<S2C_GvGMode2IslandStop.Request>)Delegate.Combine(S2C_GvGMode2IslandStop.OnPushEvent, new Action<S2C_GvGMode2IslandStop.Request>(OnIslandStop));
		S2C_GvGMode2ShipDead.OnPushEvent = (Action<S2C_GvGMode2ShipDead.Request>)Delegate.Combine(S2C_GvGMode2ShipDead.OnPushEvent, new Action<S2C_GvGMode2ShipDead.Request>(OnShipDead));
		S2C_ChangeBestKill.OnPushEvent = (Action<S2C_ChangeBestKill.Request>)Delegate.Combine(S2C_ChangeBestKill.OnPushEvent, new Action<S2C_ChangeBestKill.Request>(OnChangeBestKill));
	}

	private void UnRegisterEventListeners()
	{
		UI_GvGWorldMap2 mainUI = MainUI;
		mainUI.OnNotUIInput = (Action)Delegate.Remove(mainUI.OnNotUIInput, new Action(InputManager.UpdateInput));
		((GObject)MainUI.Zoom).onClick.Clear();
		UI_GvGWorldMap2 mainUI2 = MainUI;
		mainUI2.OnSelectStategy = (Action<int>)Delegate.Remove(mainUI2.OnSelectStategy, new Action<int>(ChangeBattleStrategy));
		CameraBinding cameraBinding = CamBinder.CameraBinding;
		cameraBinding.OnChangeSize = (Action<float>)Delegate.Remove(cameraBinding.OnChangeSize, new Action<float>(OnCameraSizeChange));
		S2C_BroadcastGvGMode2BattleResult.OnPushEvent = (Action<S2C_BroadcastGvGMode2BattleResult.Request>)Delegate.Remove(S2C_BroadcastGvGMode2BattleResult.OnPushEvent, new Action<S2C_BroadcastGvGMode2BattleResult.Request>(OnBattleResult));
		S2C_GvGMode2_ChangeHoldingCamp.OnPushEvent = (Action<S2C_GvGMode2_ChangeHoldingCamp.Request>)Delegate.Remove(S2C_GvGMode2_ChangeHoldingCamp.OnPushEvent, new Action<S2C_GvGMode2_ChangeHoldingCamp.Request>(OnChangeHoldingCamp));
		S2C_GvGMode2StateChange.OnPushEvent = (Action<S2C_GvGMode2StateChange.Request>)Delegate.Remove(S2C_GvGMode2StateChange.OnPushEvent, new Action<S2C_GvGMode2StateChange.Request>(OnChangeState));
		S2C_GvGMode2_HoldingPercent.OnPushEvent = (Action<S2C_GvGMode2_HoldingPercent.Request>)Delegate.Remove(S2C_GvGMode2_HoldingPercent.OnPushEvent, new Action<S2C_GvGMode2_HoldingPercent.Request>(OnChangeHoldingPercent));
		S2C_StartOneGvGMode2Battle.OnPushEvent = (Action<S2C_StartOneGvGMode2Battle.Request>)Delegate.Remove(S2C_StartOneGvGMode2Battle.OnPushEvent, new Action<S2C_StartOneGvGMode2Battle.Request>(OnStartOneGvGMode2Battle));
		S2C_GvGMode2_NewEntityKeyInfo.OnPushEvent = (Action<S2C_GvGMode2_NewEntityKeyInfo.Request>)Delegate.Remove(S2C_GvGMode2_NewEntityKeyInfo.OnPushEvent, new Action<S2C_GvGMode2_NewEntityKeyInfo.Request>(OnEntityKeyInfo));
		S2C_GvGMode2IslandStop.OnPushEvent = (Action<S2C_GvGMode2IslandStop.Request>)Delegate.Remove(S2C_GvGMode2IslandStop.OnPushEvent, new Action<S2C_GvGMode2IslandStop.Request>(OnIslandStop));
		S2C_GvGMode2ShipDead.OnPushEvent = (Action<S2C_GvGMode2ShipDead.Request>)Delegate.Remove(S2C_GvGMode2ShipDead.OnPushEvent, new Action<S2C_GvGMode2ShipDead.Request>(OnShipDead));
		S2C_ChangeBestKill.OnPushEvent = (Action<S2C_ChangeBestKill.Request>)Delegate.Remove(S2C_ChangeBestKill.OnPushEvent, new Action<S2C_ChangeBestKill.Request>(OnChangeBestKill));
	}

	public void ConnectToIsland(int pid, int port)
	{
		SocketManager.Instance.GetConnection(eConType.GvGMode2Island).StartConnect(HotUpdateProcess.Instance.Configs["SocketHost"], port, pid, delegate
		{
			((MonoBehaviour)this).StartCoroutine(InitProcess());
		});
	}

	public void BackToMap()
	{
		ReleaseInstance();
		SocketManager.Instance.GetConnection(eConType.GvGMode2WorldMap).Reconnect(delegate
		{
			GvGWorldMapController.CreateInstance(MainUI);
			if (IsStop)
			{
				GvGWorldMapController.Instance.SetIslandStopInfo(WinnerCamp, IslandId, IslandScore);
			}
		});
	}

	private void BackToMainCamp()
	{
		GvGWorldMapController.IsBackToMainCamp = true;
		BackToMap();
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

	public GvG2Group GetGroupById(int e_id)
	{
		if (Dict_GvGGroup.TryGetValue(e_id, out var value))
		{
			return value;
		}
		return null;
	}

	public void OnZoom()
	{
		ZoomLevel = ((ZoomLevel != 1) ? 1 : 2);
		MainUI.SetZoomLevel(ZoomLevel);
		if (DisableDragCoroutine != null)
		{
			((MonoBehaviour)this).StopCoroutine(DisableDragCoroutine);
		}
		DisableDragCoroutine = ((MonoBehaviour)this).StartCoroutine(ZoomInterpolation(0.5f));
	}

	private IEnumerator ZoomInterpolation(float catchupTime)
	{
		CamBinder.CatchupTime = 0f;
		float curSize = CamBinder.TargetSize;
		float targetSize = ((ZoomLevel == 1) ? 17.5f : 57.5f);
		float time = 0f;
		while (time <= catchupTime)
		{
			time += Time.deltaTime;
			float percent = time / catchupTime;
			float ease = 1f - 1f / Mathf.Exp(7f * percent);
			CamBinder.TargetSize = Mathf.Lerp(curSize, targetSize, ease);
			yield return null;
		}
		CamBinder.TargetSize = targetSize;
	}

	public void FocusOn(GvG2Group group)
	{
		if (DisableDragCoroutine != null)
		{
			((MonoBehaviour)this).StopCoroutine(DisableDragCoroutine);
		}
		ZoomLevel = 1;
		MainUI.SetZoomLevel(ZoomLevel);
		CamBinder.CatchupTime = 0.6f;
		CamBinder.TargetSize = 17.5f;
		CamBinder.TargetTransform = group.GroupIcon.transform;
	}

	public void CancelFocusOnDrag()
	{
		//IL_004c: Unknown result type (might be due to invalid IL or missing references)
		GvGMapInputManager inputManager = InputManager;
		inputManager.OnDragCamera = (Action)Delegate.Remove(inputManager.OnDragCamera, new Action(CancelFocusOnDrag));
		CamBinder.CatchupTime = 0f;
		Transform targetTransform = CamBinder.TargetTransform;
		CameraTracker.localPosition = targetTransform.localPosition;
		CamBinder.TargetTransform = ((Component)CameraTracker).transform;
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
		foreach (GvG2Group item in List_GvGGroup)
		{
			item.UpdateMapViewLevel(MapViewLevel);
		}
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

	private IEnumerator InitProcess()
	{
		bool isReady = false;
		GetIslandInfo(delegate
		{
			isReady = true;
		});
		while (!isReady)
		{
			yield return null;
		}
		GetEOIEntities();
		while (EntityKeys == null)
		{
			yield return null;
		}
		yield return GetEntityInfos(EntityKeys.GetRange(0, 1));
		yield return null;
		yield return GetEntityInfos(EntityKeys.GetRange(1, EntityKeys.Count - 1));
	}

	private void GetEOIEntities()
	{
		SocketManager.Instance.GetConnection(eConType.GvGMode2Island).Request(new C2S_GetGvGMode2Island_EOIEntities
		{
			Req = new C2S_GetGvGMode2Island_EOIEntities.Request
			{
				NonStr = ""
			}
		}, delegate(SocketManager.BaseSocketPackageBodyContext context_response)
		{
			C2S_GetGvGMode2Island_EOIEntities.Response response = (C2S_GetGvGMode2Island_EOIEntities.Response)context_response.Resp;
			if (response.ErrorCode < 0)
			{
				ILRuntimeDebug.LogError("请求 C2S_GetGvGMode2Island_EOIEntities 不成功");
			}
			else if (response.Infos == null)
			{
				ILRuntimeDebug.LogError("请求 C2S_GetGvGMode2Island_EOIEntities 返回的 Infos 为 null");
			}
			else
			{
				List<EntityKeyInfo> infos = response.Infos;
				int index = infos.FindIndex((EntityKeyInfo user) => user.UserId == UserId);
				EntityKeyInfo value = infos[0];
				infos[0] = infos[index];
				infos[index] = value;
				EntityKeys = infos;
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
				SocketManager.Instance.GetConnection(eConType.GvGMode2Island).Request(new C2S_GetGvGMode2Island_EntityInfo
				{
					Req = new C2S_GetGvGMode2Island_EntityInfo.Request
					{
						EntityIds = groupList.GetRange(curIndex, getCount)
					}
				}, delegate(SocketManager.BaseSocketPackageBodyContext context_response)
				{
					isReadyToGet = true;
					C2S_GetGvGMode2Island_EntityInfo.Response response = (C2S_GetGvGMode2Island_EntityInfo.Response)context_response.Resp;
					if (response.ErrorCode < 0)
					{
						ILRuntimeDebug.LogError("请求 C2S_GetGvGMode2Island_EntityInfo 不成功");
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

	private void GetIslandInfo(Action onSuccess)
	{
		SocketManager.Instance.GetConnection(eConType.GvGMode2Island).Request(new C2S_GetGvGMode2Island_IslandInfo
		{
			Req = new C2S_GetGvGMode2Island_IslandInfo.Request
			{
				NonStr = ""
			}
		}, delegate(SocketManager.BaseSocketPackageBodyContext context_response)
		{
			C2S_GetGvGMode2Island_IslandInfo.Response response = (C2S_GetGvGMode2Island_IslandInfo.Response)context_response.Resp;
			if (response.ErrorCode < 0)
			{
				ILRuntimeDebug.LogError("请求 C2S_GetGvGMode2Island_IslandInfo 不成功");
			}
			else
			{
				OnInitIslandInfo(response);
				onSuccess();
			}
		});
	}

	public void ChangeBattleStrategy(int targetCampId)
	{
		SocketManager.Instance.GetConnection(eConType.GvGMode2Island).Request(new C2S_ChangeBattleStrategy
		{
			Req = new C2S_ChangeBattleStrategy.Request
			{
				CampId = targetCampId
			}
		}, delegate(SocketManager.BaseSocketPackageBodyContext context_response)
		{
			C2S_ChangeBattleStrategy.Response response = (C2S_ChangeBattleStrategy.Response)context_response.Resp;
			if (response.ErrorCode < 0)
			{
				ILRuntimeDebug.LogError("请求 C2S_ChangeBattleStrategy 不成功");
			}
		});
	}

	private void TryCreateGroup(EntityInfo groupData, bool isSpawn = false)
	{
		//IL_00e5: Unknown result type (might be due to invalid IL or missing references)
		int entityId = groupData.EntityId;
		if (!Dict_GvGGroup.ContainsKey(entityId) && !groupData.IsDead)
		{
			GameObject val = InstantiateFromPrefab("GvGGroup");
			val.transform.SetParent(GvGIslandMap.transform, false);
			((Object)val).name = $"Entity{groupData.EntityId}";
			GvG2Group gvG2Group = val.AddComponent<GvG2Group>();
			Dict_GvGGroup.Add(entityId, gvG2Group);
			List_GvGGroup.Add(gvG2Group);
			gvG2Group.IsCreating = true;
			gvG2Group.EntityId = groupData.EntityId;
			gvG2Group.UserId = groupData.UserId;
			gvG2Group.SetIsCurUser(gvG2Group.UserId == UserId);
			gvG2Group.SetGroupDataToUI(groupData);
			gvG2Group.SetBornPos(new Vector3(groupData.X / 1000f, 0f, groupData.Y / 1000f));
			gvG2Group.SetFormation(groupData.FormationId);
			gvG2Group.SetUnitInfo(groupData.UnitsInfo);
			gvG2Group.SetSpeed(groupData.GroupSpeed / 1000f);
			gvG2Group.SetCampId(groupData.CampId);
			gvG2Group.SetRoleFace(groupData.RoleFace);
			gvG2Group.UpdateMapViewLevel(MapViewLevel);
			gvG2Group.SetState((eGvGMode2State)groupData.GvGMode2State, JsonHelper.ToObject<Dictionary<string, object>>(groupData.GvGMode2StateJson));
			if (groupData.debug_MatrixWidth > 0f)
			{
				gvG2Group.SetDebugMatrixWidth(groupData.debug_MatrixWidth / 1000f);
			}
			if (isSpawn)
			{
				gvG2Group.SetSpawning();
			}
			else
			{
				gvG2Group.SetAppear();
			}
			if (gvG2Group.UserId == UserId)
			{
				MyGroup = gvG2Group;
				MainUI.InitStrategyDialog(groupData.CampId, groupData.BattleStrategy);
			}
		}
	}

	private void OnInitIslandInfo(C2S_GetGvGMode2Island_IslandInfo.Response info)
	{
		Dictionary<int, int> dictionary = JsonHelper.ToObject<Dictionary<int, int>>(info.HoldingPercent);
		if (dictionary != null)
		{
			MainUI.StartIslandStopCounter(info.IslandCloseTimestamp);
			MainUI.OnChangeHoldingPercentOnIsland(dictionary);
			HoldingScorePerSecond = info.HoldingScorePerSecond;
			IslandId = info.IslandConfigId;
			IslandScore = info.IslandScore;
			WinnerCamp = info.WinnerCampId;
			IsStop = info.IsStop;
			OnChangeBestKill(new S2C_ChangeBestKill.Request
			{
				UserId = info.BestKillUserId,
				KillCount = info.BestKillCount,
				CampId = info.BestKillCampId,
				IsKill = false
			});
			if (info.IsStop)
			{
				BackToMap();
			}
		}
	}

	private void OnChangeState(S2C_GvGMode2StateChange.Request req)
	{
		if (Dict_GvGGroup.TryGetValue(req.EntityId, out var value))
		{
			value.SetState((eGvGMode2State)req.State, JsonHelper.ToObject<Dictionary<string, object>>(req.JsonStr));
		}
	}

	private void OnStartOneGvGMode2Battle(S2C_StartOneGvGMode2Battle.Request req)
	{
	}

	private void OnEntityKeyInfo(S2C_GvGMode2_NewEntityKeyInfo.Request req)
	{
		RequestQueue.AddCoroutine(GetEntityInfos(new List<EntityKeyInfo> { req.KeyInfo }));
	}

	private void OnChangeHoldingPercent(S2C_GvGMode2_HoldingPercent.Request req)
	{
		Dictionary<int, int> dictionary = JsonHelper.ToObject<Dictionary<int, int>>(req.HoldingPercent);
		if (dictionary != null)
		{
			MainUI.OnChangeHoldingPercentOnIsland(dictionary);
		}
	}

	private void OnChangeHoldingCamp(S2C_GvGMode2_ChangeHoldingCamp.Request req)
	{
		MainUI.OnChangeHoldingCamp(req.HoldingCamp);
	}

	private void OnBattleResult(S2C_BroadcastGvGMode2BattleResult.Request req)
	{
		//IL_0042: Unknown result type (might be due to invalid IL or missing references)
		//IL_0047: Unknown result type (might be due to invalid IL or missing references)
		//IL_0049: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0050: Unknown result type (might be due to invalid IL or missing references)
		//IL_0076: Unknown result type (might be due to invalid IL or missing references)
		//IL_0065: Unknown result type (might be due to invalid IL or missing references)
		//IL_007b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0119: Unknown result type (might be due to invalid IL or missing references)
		//IL_011b: Unknown result type (might be due to invalid IL or missing references)
		//IL_011d: Unknown result type (might be due to invalid IL or missing references)
		foreach (GvGMode2BattleResult gvGMode2BattleResult in req.GvGMode2BattleResults)
		{
			if (Dict_GvGGroup.TryGetValue(gvGMode2BattleResult.EntityId, out var value))
			{
				Vector3 position = value.AvatarIcon.transform.position;
				Vector2 val = EffectHelper.WorldToFguiPos(position);
				Vector2 val2 = ((MapViewLevel == eMapViewLevel.BattleField) ? new Vector2(0f, -20f) : new Vector2(-40f, 0f));
				double num = ((MapViewLevel == eMapViewLevel.BattleField) ? 1.0 : 0.8);
				string value2 = $"-{gvGMode2BattleResult.SoldierCost}";
				if (value.IsCurUser)
				{
					value2 = $"我-{gvGMode2BattleResult.SoldierCost}";
				}
				else if (value.IsCurUserTarget)
				{
					value2 = $"敌-{gvGMode2BattleResult.SoldierCost}";
				}
				GvG2TipsManager.Instance.PlayTip(new Dictionary<string, object>
				{
					{ "Content", value2 },
					{
						"Pos",
						val + val2
					},
					{ "Scale", num }
				}, Time.time);
				value.SetSoldierNum(gvGMode2BattleResult.SoldierCost, gvGMode2BattleResult.SoldierRemaining);
				if ((Object)(object)MyGroup != (Object)null && value.EntityId == MyGroup.EntityId)
				{
					MainUI.OnUpdateSoldierCount(gvGMode2BattleResult.SoldierRemaining);
				}
			}
		}
	}

	private void OnShipDead(S2C_GvGMode2ShipDead.Request req)
	{
		int entityId = req.EntityId;
		if (Dict_GvGGroup.TryGetValue(entityId, out var value))
		{
			Dict_GvGGroup.Remove(entityId);
			List_GvGGroup.Remove(value);
			if ((Object)(object)MyGroup == (Object)(object)value)
			{
				GameController.Contexts.Service<IUiService>().OpenPanel(UI_IslandFinishPopup.Name, new Dictionary<string, object>
				{
					{ "Type", 0 },
					{
						"Buttons",
						new Dictionary<string, Action>
						{
							{ "OnBackToMap", BackToMainCamp },
							{ "OnWatchMode", MainUI.SetToWatchGameMode }
						}
					}
				});
				MyGroup = null;
			}
			value.SetDead();
		}
	}

	private void OnIslandStop(S2C_GvGMode2IslandStop.Request req)
	{
		if (req.IsStop)
		{
			IslandScore = req.IslandScore;
			WinnerCamp = req.WinnerCamp;
			IsStop = req.IsStop;
			GameController.Contexts.Service<IUiService>().OpenPanel(UI_IslandFinishPopup.Name, new Dictionary<string, object>
			{
				{ "Type", 1 },
				{ "Data", req },
				{
					"Buttons",
					new Dictionary<string, Action> { { "OnBackToMap", BackToMap } }
				}
			});
		}
	}

	private void OnChangeBestKill(S2C_ChangeBestKill.Request req)
	{
		BeskKillCoroutineQueue.AddCoroutine(GvGWorldMapController.MainUI.ProccessBestKill(req.UserId, req.KillCount, req.CampId, req.IsKill));
	}
}
