using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FairyGUI;
using GameDataEditor;
using GameMaths;
using HotFix;
using HotFix.Sources.Base.Scripts.Utils;
using Shift.Legion;
using Shift.Legion.ClientApi.Protocol.UserAction;
using Shift.Legion.Common.Helpers;
using Shift.Legion.Common.Managers;
using Shift.Legion.Common.Services;
using Shift.Legion.GvG.Common;
using Shift.Legion.GvG.Common.Model;
using Shift.Legion.GvGServer.Models.Map;
using Shift.Legion.GvGServer.Models.WorldBossSocket;
using Shift.Legion.Helpers;
using UnityEngine;
using UnityEngine.AddressableAssets;

public class GvGWorldController : MonoBehaviour
{
	public static GvGWorldController Instance;

	private AudioSource bgm;

	private bool isBgmPlaying;

	public static bool IsInstanceCreated;

	public bool IsInitialized;

	private static GDEGvGIslandMapConfigData IslandData;

	private Vector3 CamPos_IslandCenter;

	public GvGProcessInfo ProcessInfo;

	public Transform WorldMapSize;

	public Transform AttackSfxContainer;

	public GameObject GvGPrefab_GvGWorld;

	public Texture2D NoiseTexture;

	public Shader AnimMapShader;

	public GameObject GvGPrefab_GvGIsland;

	public GameObject GvGPrefab_GvGGroup;

	public GameObject GvGPrefab_GvGShip;

	public GameObject GvGPrefab_GvGUnit;

	public Transform SeflGroupsListViewPortContent;

	public GameObject _prefab_UserGroup;

	public List<string> FX_CacheName;

	private Dictionary<eGvGRole, Queue<tShipAttr>> GvGWorldInfo;

	private int curFrame = 0;

	public BroadcastGroupInitInfo BossGroupInitInfo;

	public GvGGroup BossGroup;

	public Dictionary<int, GvGGroup> UserGroups;

	private GvGGroup ChooseUserGroup;

	private List<int> GroupIdsWaitToGet;

	public Dictionary<string, GvGGroup> Dict_GvGGroup;

	public Dictionary<int, GvGGroup> Dict_GvGZone;

	public int curLODIndex;

	private float CurCamSize;

	private GvGFrameData FirstGvGFrameDatas;

	private List<GvGFrameData> _GvGFrameDatas;

	private int UserId;

	private long CurTime;

	private long NextServerTime;

	private List<int> EOIList = new List<int>();

	public long BossCurHp;

	public long BossMaxHp;

	private List<GvGGroup> List_GvGGroup;

	private bool IsUserGroupFighting;

	private const int MAX_GET_COUNT = 5;

	public eMapViewLevel MapViewLevel { get; internal set; } = eMapViewLevel.Island;

	public static void CreateInstance()
	{
		//IL_001c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0021: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		//IL_0044: Unknown result type (might be due to invalid IL or missing references)
		//IL_0049: Unknown result type (might be due to invalid IL or missing references)
		if (IsInstanceCreated)
		{
			return;
		}
		IsInstanceCreated = true;
		Texture2D noiseTexture = Addressables.LoadAssetAsync<Texture2D>((object)"GvGAniMapSoldier/AnimMapShaderNoise.asset").WaitForCompletion();
		Shader animMapShader = Addressables.LoadAssetAsync<Shader>((object)"GvGAniMapSoldier/AnimMapShader2").WaitForCompletion();
		GameObject val = Addressables.LoadAssetAsync<GameObject>((object)"GvGWorldMap").WaitForCompletion();
		GameObject val2 = Object.Instantiate<GameObject>(val);
		Instance = val2.AddComponent<GvGWorldController>();
		Instance.bgm = val2.AddComponent<AudioSource>();
		Instance.GvGPrefab_GvGWorld = val;
		Instance.NoiseTexture = noiseTexture;
		Instance.AnimMapShader = animMapShader;
		if (!UiAudioManager.Instance.bgmSwitch)
		{
			return;
		}
		AssetsManager.Instance.LoadAsset<AudioClip>("GVG_BGM").Then((Action<AudioClip>)delegate(AudioClip clip)
		{
			Instance.bgm.clip = clip;
			Instance.bgm.playOnAwake = false;
			Instance.bgm.loop = true;
			if (Instance.isBgmPlaying)
			{
				Instance.bgm.Play();
			}
		});
	}

	public static void ReleaseInstance()
	{
		if (IsInstanceCreated)
		{
			IsInstanceCreated = false;
			GvGTipsManager.Instance.StopAllTips();
			Addressables.ReleaseInstance(Instance.GvGPrefab_GvGWorld);
			Addressables.ReleaseInstance(Instance.GvGPrefab_GvGIsland);
			Addressables.ReleaseInstance(Instance.GvGPrefab_GvGGroup);
			Addressables.ReleaseInstance(Instance.GvGPrefab_GvGShip);
			Addressables.ReleaseInstance(Instance.GvGPrefab_GvGUnit);
			Addressables.Release<Texture2D>(Instance.NoiseTexture);
			Addressables.Release<Shader>(Instance.AnimMapShader);
			Object.Destroy((Object)(object)((Component)Instance).gameObject);
			Instance = null;
		}
	}

	private void Awake()
	{
		//IL_0048: Unknown result type (might be due to invalid IL or missing references)
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_010d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0112: Unknown result type (might be due to invalid IL or missing references)
		//IL_0125: Unknown result type (might be due to invalid IL or missing references)
		//IL_012a: Unknown result type (might be due to invalid IL or missing references)
		//IL_013d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0142: Unknown result type (might be due to invalid IL or missing references)
		//IL_0162: Unknown result type (might be due to invalid IL or missing references)
		//IL_0167: Unknown result type (might be due to invalid IL or missing references)
		//IL_0192: Unknown result type (might be due to invalid IL or missing references)
		IsInitialized = false;
		isBgmPlaying = false;
		IsUserGroupFighting = false;
		((Object)((Component)this).gameObject).name = "GvGWorldMap";
		((Component)this).transform.parent = ((Component)GameController.Instance).gameObject.transform;
		((Component)this).transform.localPosition = Vector3.op_Implicit(CameraService.GvGWorldPos);
		RegisterEventListeners();
		UserId = GameController.Contexts.gameState.user.value.UserId;
		UserGroups = new Dictionary<int, GvGGroup>();
		FX_CacheName = new List<string>();
		Dict_GvGGroup = new Dictionary<string, GvGGroup>();
		Dict_GvGZone = new Dictionary<int, GvGGroup>();
		List_GvGGroup = new List<GvGGroup>();
		EOIList = new List<int>();
		WorldMapSize = ((Component)this).transform.Find("WorldMapSize");
		AttackSfxContainer = ((Component)this).transform.Find("AttackSfxContainer");
		_prefab_UserGroup = ((Component)((Component)this).transform.Find("Canvas/SeflGroupsList/_prefab_UserGroup")).gameObject;
		GvGPrefab_GvGGroup = Addressables.LoadAssetAsync<GameObject>((object)"GvG2/GvGGroup").WaitForCompletion();
		GvGPrefab_GvGShip = Addressables.LoadAssetAsync<GameObject>((object)"GvG2/GvGShip").WaitForCompletion();
		GvGPrefab_GvGUnit = Addressables.LoadAssetAsync<GameObject>((object)"GvGUnit").WaitForCompletion();
		curLODIndex = -1;
		CurCamSize = 25f;
		CamPos_IslandCenter = Consts.GVG_START_CAM_POS;
		Singleton<CameraService>.Instance.SetSkybox("GvGSkybox");
		Singleton<CameraService>.Instance.SwitchToScene("SceneGvGWorld");
		Singleton<CameraService>.Instance.BindTarget(CamPos_IslandCenter, 25f, 0f);
		_ = GvGConfigHelper.GvGConfig;
	}

	private void RegisterEventListeners()
	{
		SharedMessenger.AddListener<float>("ON_CAMERA_SIZE_CHANGE", OnCameraSizeChange);
	}

	private void UnRegisterEventListeners()
	{
		SharedMessenger.RemoveListener<float>("ON_CAMERA_SIZE_CHANGE", OnCameraSizeChange);
	}

	private void OnDestroy()
	{
		StopBGM();
		IsInitialized = false;
		UnRegisterEventListeners();
		Singleton<CameraService>.Instance.ClearSkybox();
		Singleton<CameraService>.Instance.StopBinding();
		SocketManager.Instance.GetConnection(eConType.GvGMode1).CloseConnect();
		List<GvGGroup> list = Dict_GvGGroup.Values.ToList();
		for (int i = 0; i < list.Count; i++)
		{
			Object.Destroy((Object)(object)((Component)list[i]).gameObject);
		}
		Dict_GvGGroup.Clear();
		List_GvGGroup.Clear();
		Dict_GvGZone.Clear();
		Dict_GvGGroup = null;
		List_GvGGroup = null;
		Dict_GvGZone = null;
	}

	public void ChangeCameraBinding(eMapViewLevel _MapViewLevel, int EntityId = -1)
	{
		//IL_00fa: Unknown result type (might be due to invalid IL or missing references)
		eMapViewLevel mapViewLevel = MapViewLevel;
		GvGGroup value;
		if (_MapViewLevel == eMapViewLevel.BattleField && EntityId == -1 && UserGroups != null && UserGroups.Count > 0)
		{
			MapViewLevel = _MapViewLevel;
			ChooseUserGroup = UserGroups.Values.First();
		}
		else if (EntityId != -1 && Dict_GvGGroup != null && Dict_GvGGroup.TryGetValue($"{EntityId}", out value))
		{
			MapViewLevel = _MapViewLevel;
			ChooseUserGroup = value;
		}
		else
		{
			MapViewLevel = eMapViewLevel.Island;
			ChooseUserGroup = null;
		}
		switch (MapViewLevel)
		{
		case eMapViewLevel.Island:
			if ((Object)(object)BossGroup != (Object)null)
			{
				Singleton<CameraService>.Instance.BindTarget(((Component)BossGroup).transform, 25f, 1.2f);
			}
			else
			{
				Singleton<CameraService>.Instance.BindTarget(CamPos_IslandCenter, 25f, 1.2f);
			}
			break;
		case eMapViewLevel.BattleField:
			if ((Object)(object)ChooseUserGroup != (Object)null)
			{
				Transform val = ((Component)ChooseUserGroup).transform.Find("GroupCollider/CamTarget");
				Singleton<CameraService>.Instance.BindTarget(((Component)val).transform, 17.5f, 1.2f);
			}
			break;
		}
		if (MapViewLevel != mapViewLevel)
		{
			SharedMessenger.Broadcast("ON_GVG_MAP_VIEW_LEVEL_CHANGE", (int)MapViewLevel);
		}
		UpdateEOI();
	}

	public void ChangeCameraBindingRequest(eMapViewLevel _MapViewLevel, int EntityId = -1)
	{
		ChangeCameraBinding(_MapViewLevel, EntityId);
		C2S_ChangeMapViewLevel c2S_ChangeMapViewLevel = new C2S_ChangeMapViewLevel();
		((C2S_ChangeMapViewLevel.Request)c2S_ChangeMapViewLevel.Req).MapViewLevel = (int)_MapViewLevel;
		((C2S_ChangeMapViewLevel.Request)c2S_ChangeMapViewLevel.Req).TargetId = EntityId;
		SocketManager.Instance.GetConnection(eConType.GvGMode3IslandManager).Request(c2S_ChangeMapViewLevel, delegate(SocketManager.BaseSocketPackageBodyContext context_response)
		{
			C2S_ChangeMapViewLevel.Response response = (C2S_ChangeMapViewLevel.Response)context_response.Resp;
		});
	}

	private void OnCameraSizeChange(float size)
	{
		CurCamSize = size;
		if (Dict_GvGGroup == null || Dict_GvGGroup.Count == 0)
		{
			return;
		}
		GvGGroup gvGGroup = null;
		foreach (GvGGroup item in List_GvGGroup)
		{
			item.SetUIScale(CurCamSize);
			if ((Object)(object)gvGGroup == (Object)null && ((Behaviour)item).isActiveAndEnabled)
			{
				gvGGroup = item;
			}
		}
		if ((Object)(object)gvGGroup == (Object)null)
		{
			return;
		}
		SpriteRenderer component = gvGGroup.GroupIcon.GetComponent<SpriteRenderer>();
		int num = (((Renderer)component).isVisible ? 1 : 0);
		if (num == curLODIndex)
		{
			return;
		}
		curLODIndex = num;
		SharedMessenger.Broadcast("ON_LOD_CHANGE", num);
		((Component)AttackSfxContainer).gameObject.SetActive(MapViewLevel == eMapViewLevel.BattleField);
		foreach (GvGGroup item2 in List_GvGGroup)
		{
			item2.UpdateMapViewLevel(MapViewLevel);
		}
		if (MapViewLevel == eMapViewLevel.BattleField)
		{
			PlayBGM();
		}
		else
		{
			PauseBGM();
		}
	}

	public void ConnectToIsland(GvGProcessInfo config)
	{
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0055: Unknown result type (might be due to invalid IL or missing references)
		//IL_005a: Unknown result type (might be due to invalid IL or missing references)
		//IL_005f: Unknown result type (might be due to invalid IL or missing references)
		//IL_006a: Unknown result type (might be due to invalid IL or missing references)
		//IL_008a: Unknown result type (might be due to invalid IL or missing references)
		//IL_008f: Unknown result type (might be due to invalid IL or missing references)
		//IL_00be: Unknown result type (might be due to invalid IL or missing references)
		ProcessInfo = config;
		IsInitialized = false;
		IslandData = GDMgr.Get<GDEGvGIslandMapConfigData>(ProcessInfo.MapId);
		CamPos_IslandCenter = ((Component)this).transform.position + new Vector3(IslandData.MapWidth / 2f, 0f, IslandData.MapHeight / 2f);
		Singleton<CameraService>.Instance.BindTarget(CamPos_IslandCenter, 25f, 0f);
		GvGPrefab_GvGIsland = Addressables.LoadAssetAsync<GameObject>((object)IslandData.Image).WaitForCompletion();
		GameObject val = Object.Instantiate<GameObject>(GvGPrefab_GvGIsland, ((Component)this).transform.Find("BattleField/Container/Background"));
		val.transform.localPosition = Vector3.zero;
		int externalSocketPort = ProcessInfo.ExternalSocketPort;
		int pid = ProcessInfo.Pid;
		SocketManager.Instance.GetConnection(eConType.GvGMode1).StartConnect(HotUpdateProcess.Instance.Configs["SocketHost"], externalSocketPort, pid, delegate
		{
			StartGetIslandInfo();
			GetBossHp();
		});
	}

	private void StartGetIslandInfo()
	{
		C2S_GetIslandInfos c2S_GetIslandInfos = new C2S_GetIslandInfos();
		((C2S_GetIslandInfos.Request)c2S_GetIslandInfos.Req).Ids_WaitToGet = new List<int> { -1 };
		SocketManager.Instance.GetConnection(eConType.GvGMode1).Request(c2S_GetIslandInfos, delegate(SocketManager.BaseSocketPackageBodyContext context_response)
		{
			C2S_GetIslandInfos.Response response = context_response.Resp as C2S_GetIslandInfos.Response;
			GroupIdsWaitToGet = response.TotalIds;
			((MonoBehaviour)this).StartCoroutine(Coroutine_GetGroupsInfo());
		});
	}

	private bool TryCreateGroup(BroadcastGroupInitInfo _group_data, bool isGetIslandInfos = false)
	{
		//IL_0150: Unknown result type (might be due to invalid IL or missing references)
		if (Dict_GvGGroup.Count >= 30 && _group_data.UserId != UserId)
		{
			return true;
		}
		string key = _group_data.EntityId.ToString();
		int defenderZoneId = _group_data.DefenderZoneId;
		if (!Dict_GvGGroup.ContainsKey(key) && !_group_data.IsDead)
		{
			GameObject val = Object.Instantiate<GameObject>(Instance.GvGPrefab_GvGGroup, WorldMapSize);
			((Object)val).name = $"Entity{_group_data.EntityId}";
			GvGGroup gvGGroup = val.AddComponent<GvGGroup>();
			Dict_GvGGroup.Add(key, gvGGroup);
			List_GvGGroup.Add(gvGGroup);
			if (defenderZoneId != -1 && !Dict_GvGZone.ContainsKey(defenderZoneId))
			{
				Dict_GvGZone.Add(defenderZoneId, gvGGroup);
			}
			gvGGroup.IsCreating = true;
			gvGGroup.EntityId = _group_data.EntityId;
			gvGGroup.UserId = _group_data.UserId;
			gvGGroup.SetIsBoss(_group_data.IsBoss);
			gvGGroup.SetIsCurUser(gvGGroup.UserId == UserId);
			gvGGroup.SetGroupDataToUI(_group_data);
			gvGGroup.SetBornPos(new Vector3(_group_data.BornX, 0f, _group_data.BornY));
			gvGGroup.SetFormation(_group_data.FormationId);
			gvGGroup.SetUnitInfo(_group_data.UnitsInfo);
			gvGGroup.SetUIScale(CurCamSize);
			gvGGroup.UpdateMapViewLevel(MapViewLevel);
			if (gvGGroup.UserId == UserId)
			{
				UserGroups.Add(gvGGroup.EntityId, gvGGroup);
				ChangeCameraBindingRequest(eMapViewLevel.BattleField, gvGGroup.EntityId);
			}
			else if (_group_data.IsBoss)
			{
				BossGroupInitInfo = _group_data;
				BossGroup = gvGGroup;
				ChangeCameraBinding(eMapViewLevel.Island, BossGroup.EntityId);
			}
			return true;
		}
		return false;
	}

	private void UpdateGroup(string e_id, long _serverTime, BroadcastGroupInfo _group_data, bool isGetIslandInfos = false)
	{
		if (!Dict_GvGGroup.TryGetValue(e_id, out var value))
		{
			return;
		}
		if (_group_data.UpdateInfo.IsDead)
		{
			SetGroupDead(e_id);
			return;
		}
		value.SetRoleFace(_group_data.UpdateInfo.RoleFace);
		if (isGetIslandInfos)
		{
			if (_group_data.MarchingCommandInfo != null)
			{
				value.SetMarchingToFighting(_group_data.MarchingCommandInfo, _serverTime);
			}
		}
		else
		{
			if (value.IsCreating && !_group_data.UpdateInfo.IsFighting)
			{
				value.SetSpawning();
			}
			if (_group_data.MarchingCommandInfo != null)
			{
				value.SetMarching(_group_data.MarchingCommandInfo, _serverTime);
			}
		}
		if (_group_data.FightingCommandInfo != null)
		{
			value.SetFighting(_group_data.FightingCommandInfo, _serverTime);
			if (value.UserId == UserId)
			{
				IsUserGroupFighting = true;
			}
		}
		value.IsCreating = false;
		if (!value.IsBoss && _group_data.MarchingCommandInfo == null && _group_data.FightingCommandInfo == null)
		{
			ILRuntimeDebug.LogError($"BroadcastGroupInfo 同时没有 marching 和 fighting command，ServerTime={_serverTime} IZId={ProcessInfo.IZId} IslandId={ProcessInfo.IslandId} EntityId={value.EntityId}");
		}
	}

	private void SetGroupDead(string e_id)
	{
		if (!Dict_GvGGroup.TryGetValue(e_id, out var value))
		{
			return;
		}
		Dict_GvGGroup.Remove(e_id);
		List_GvGGroup.Remove(value);
		if (value.ZoneId != -1)
		{
			Dict_GvGZone.Remove(value.ZoneId);
		}
		if (value.IsBoss)
		{
			BossGroup = null;
			ChangeCameraBindingRequest(MapViewLevel);
			SharedMessenger.Broadcast("ON_GVG_BOSS_DEAD", IsUserGroupFighting);
		}
		else if (UserGroups.ContainsKey(value.EntityId))
		{
			if ((Object)(object)ChooseUserGroup == (Object)(object)UserGroups[value.EntityId])
			{
				if (MapViewLevel == eMapViewLevel.BattleField && (Object)(object)BossGroup != (Object)null)
				{
					ChangeCameraBinding(eMapViewLevel.BattleField, BossGroup.EntityId);
				}
				else
				{
					ChangeCameraBindingRequest(eMapViewLevel.Island);
				}
			}
			UserGroups.Remove(value.EntityId);
		}
		value.SetDead();
	}

	private void UpdateGroupDetail(string e_id, long _serverTime, BroadcastGroupDetailInfo _detail_data)
	{
		if (Dict_GvGGroup.TryGetValue(e_id, out var value) && value.LastUpdateDetailServerTime < _serverTime)
		{
			value.LastUpdateDetailServerTime = _serverTime;
			value.UpdateSoldiersDetail(_detail_data);
		}
	}

	private void GetBossHp()
	{
		SocketManager.Instance.GetConnection(eConType.GvGMode1).Request(new C2S_GetBossHp
		{
			Req = new C2S_GetBossHp.Request
			{
				Non = -1
			}
		}, delegate(SocketManager.BaseSocketPackageBodyContext context_response)
		{
			C2S_GetBossHp.Response response = (C2S_GetBossHp.Response)context_response.Resp;
			BossCurHp = response.BossCurHp;
			BossMaxHp = response.BossMaxHp;
			SharedMessenger.Broadcast("ON_GVG_BOSS_HP_CHANGE", new BossHealth
			{
				CurHp = BossCurHp,
				MaxHp = BossMaxHp
			});
		});
	}

	public void UpdateBossHp(S2C_BroadcastBossHp.Request res)
	{
		BossCurHp = res.BossCurHp;
		BossMaxHp = res.BossMaxHp;
		SharedMessenger.Broadcast("ON_GVG_BOSS_HP_CHANGE", new BossHealth
		{
			CurHp = BossCurHp,
			MaxHp = BossMaxHp
		});
		if (res.IsDead && (Object)(object)BossGroup != (Object)null)
		{
			SetGroupDead(BossGroup.EntityId.ToString());
		}
	}

	public void UpdateBattleDamageInfo(S2C_BroadcastBattleDamageInfo.Request res)
	{
		//IL_007b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0080: Unknown result type (might be due to invalid IL or missing references)
		//IL_0082: Unknown result type (might be due to invalid IL or missing references)
		//IL_0084: Unknown result type (might be due to invalid IL or missing references)
		//IL_0089: Unknown result type (might be due to invalid IL or missing references)
		//IL_00af: Unknown result type (might be due to invalid IL or missing references)
		//IL_009e: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00da: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00df: Unknown result type (might be due to invalid IL or missing references)
		//IL_0131: Unknown result type (might be due to invalid IL or missing references)
		//IL_0133: Unknown result type (might be due to invalid IL or missing references)
		//IL_0135: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_01aa: Unknown result type (might be due to invalid IL or missing references)
		if (res == null && res.DamageInfos == null)
		{
			return;
		}
		SharedMessenger.Broadcast("ON_GVG_BROADCAST_DAMAGE", res);
		foreach (DamageInfo damageInfo in res.DamageInfos)
		{
			string key = damageInfo.EntityId.ToString();
			if (Dict_GvGGroup != null && Dict_GvGGroup.TryGetValue(key, out var value))
			{
				Vector3 position = value.AvatarIcon.transform.position;
				Vector2 val = EffectHelper.WorldToFguiPos(position);
				Vector2 val2 = ((MapViewLevel == eMapViewLevel.BattleField) ? new Vector2(0f, 0f) : new Vector2(-10f, 115f));
				Vector2 val3 = ((MapViewLevel == eMapViewLevel.BattleField) ? new Vector2(0f, -20f) : new Vector2(0f, 30f));
				double num = ((MapViewLevel == eMapViewLevel.BattleField) ? 1.0 : 0.8);
				GvGTipsManager.Instance.PlayTip(new Dictionary<string, object>
				{
					{
						"Content",
						$"{damageInfo.Damage}"
					},
					{
						"Pos",
						val + val2
					},
					{ "Type", 1 },
					{ "Scale", num }
				}, Time.time);
				GvGTipsManager.Instance.PlayTip(new Dictionary<string, object>
				{
					{
						"Content",
						$"-{damageInfo.SoldierCost}"
					},
					{
						"Pos",
						val + val3
					},
					{ "Type", 2 },
					{ "Scale", num }
				}, Time.time + 0.2f);
			}
		}
	}

	private IEnumerator Coroutine_GetGroupsInfo()
	{
		if (Dict_GvGGroup == null)
		{
			yield break;
		}
		new List<int>();
		List<int> Ids_WaitToGet;
		if (GroupIdsWaitToGet.Count < 5)
		{
			Ids_WaitToGet = GroupIdsWaitToGet.ToList();
			GroupIdsWaitToGet.Clear();
		}
		else
		{
			Ids_WaitToGet = GroupIdsWaitToGet.Take(5).ToList();
			GroupIdsWaitToGet.RemoveRange(0, 5);
		}
		if (Ids_WaitToGet.Count == 0)
		{
			IsInitialized = true;
			yield break;
		}
		SocketManager.Instance.GetConnection(eConType.GvGMode1).Request(new C2S_GetIslandInfos
		{
			Req = new C2S_GetIslandInfos.Request
			{
				Ids_WaitToGet = Ids_WaitToGet
			}
		}, delegate(SocketManager.BaseSocketPackageBodyContext context_response)
		{
			C2S_GetIslandInfos.Response response = context_response.Resp as C2S_GetIslandInfos.Response;
			if (response.InitInfos != null)
			{
				foreach (BroadcastGroupInitInfo initInfo in response.InitInfos)
				{
					if (Dict_GvGGroup == null)
					{
						return;
					}
					TryCreateGroup(initInfo, isGetIslandInfos: true);
				}
			}
			if (response.GroupInfos != null)
			{
				foreach (BroadcastGroupInfo groupInfo in response.GroupInfos)
				{
					if (Dict_GvGGroup == null)
					{
						return;
					}
					string text = groupInfo.EntityId.ToString();
					UpdateGroup(groupInfo.EntityId.ToString(), response.LastUpdateTime, groupInfo, isGetIslandInfos: true);
				}
			}
			((MonoBehaviour)this).StartCoroutine(Coroutine_GetGroupsInfo());
		});
	}

	public IEnumerator CreateGroups(long _lastUpdateTime, List<BroadcastGroupInitInfo> _infos, List<BroadcastGroupInfo> _updateInfo)
	{
		if (_infos != null)
		{
			foreach (BroadcastGroupInitInfo _init_data in _infos)
			{
				TryCreateGroup(_init_data);
				yield return null;
			}
		}
		if (_updateInfo == null)
		{
			yield break;
		}
		foreach (BroadcastGroupInfo _group_data in _updateInfo)
		{
			string e_id = _group_data.EntityId.ToString();
			UpdateGroup(e_id, _lastUpdateTime, _group_data);
			if (_group_data.DetailInfo != null && !_group_data.UpdateInfo.IsDead)
			{
				UpdateGroupDetail(e_id, _lastUpdateTime, _group_data.DetailInfo);
			}
			yield return null;
		}
	}

	public IEnumerator UpdateGroups(long _lastUpdateTime, List<BroadcastGroupInfo> _infos)
	{
		if (_infos == null)
		{
			yield break;
		}
		for (int i = 0; i < _infos.Count; i++)
		{
			BroadcastGroupInfo _info = _infos[i];
			string e_id = _info.EntityId.ToString();
			UpdateGroup(e_id, _lastUpdateTime, _info);
			if (_info.DetailInfo != null && !_info.UpdateInfo.IsDead)
			{
				UpdateGroupDetail(e_id, _lastUpdateTime, _info.DetailInfo);
			}
			yield return null;
		}
	}

	internal void UpdateEntitiesDeath(S2C_BroadcastEntitiesDead.Request req)
	{
		List<int> ids = req.Ids;
		if (ids == null)
		{
			ILRuntimeDebug.LogError("S2C_BroadcastEntitiesDead.Request.Ids 为null");
			return;
		}
		foreach (int item in ids)
		{
			string groupDead = item.ToString();
			SetGroupDead(groupDead);
		}
	}

	public void StartBattle(string formationId, List<string> soldierIds, Action onSuccess = null, Action<int> onError = null)
	{
		WBInfo _BossInfo = JsonHelper.ToObject<WBInfo>(ProcessInfo.Info);
		if (ProcessInfo.BossInfo == null)
		{
			ILRuntimeDebug.LogError("GvGWorldController.StartBattle: (WBInfo)BossInfo is null");
		}
		ILRequestHelper<GvGWorldBossStartBattleResponse>.Request((EventContext)null, (Func<Task<GvGWorldBossStartBattleResponse>>)(() => GameController.Contexts.Service<INetworkService>().GvGWorldBossStartBattle(_BossInfo.WBId, formationId, soldierIds, ProcessInfo.IZId)), (Action<GvGWorldBossStartBattleResponse>)delegate(GvGWorldBossStartBattleResponse response)
		{
			if (!response.Result)
			{
				ILRequestHelper.ShowErrorCode(response.ErrorCode);
				onError?.Invoke(response.ErrorCode);
			}
			else
			{
				onSuccess?.Invoke();
				int num = 0;
				StockChangeRecord[] array = new StockChangeRecord[response.Cost.Count];
				foreach (KeyValuePair<string, int> item in response.Cost)
				{
					GDESoldierData gDESoldierData = GDMgr.Get<GDESoldierData>(item.Key);
					if (gDESoldierData != null && gDESoldierData.IsPlayer)
					{
						array[num++] = new StockChangeRecord
						{
							ItemId = item.Key,
							Offset = -item.Value,
							Context = 102,
							ContextValue = ""
						};
					}
				}
				GameManagers.Instance.StockController.ReadStockChangeRecords(array);
			}
		});
	}

	public void OnBattleResult(S2C_BattleResult.Request req)
	{
		GvGTipsManager.Instance.StopAllTips();
		SharedMessenger.Broadcast("ON_GVG_BATTLE_END", req);
		ILRequestHelper<GvGWorldBossGetBattleResultListResponse>.Request((EventContext)null, (Func<Task<GvGWorldBossGetBattleResultListResponse>>)(() => GameController.Contexts.Service<INetworkService>().GvGWorldBossGetBattleResultList()), (Action<GvGWorldBossGetBattleResultListResponse>)delegate(GvGWorldBossGetBattleResultListResponse response)
		{
			if (!response.Result)
			{
				ILRequestHelper.ShowMessage("GvGWorldBossGetBattleResultList 请求失败！");
			}
			else
			{
				ArchiveExtension_WorldBossRecord.Model model = JsonHelper.ToObject<ArchiveExtension_WorldBossRecord.Model>(response.Model);
				GameManagers.Instance.UserArchiveManager.SetWorldBossRecordModel(model);
				SharedMessenger.Broadcast("ON_GVG_BATTLE_RESULT", model);
			}
		});
	}

	private void UpdateEOI()
	{
		if (EOIList == null)
		{
			return;
		}
		foreach (int eOI in EOIList)
		{
			if (Dict_GvGGroup.TryGetValue(eOI.ToString(), out var value) && value.HasAniMapSoldier())
			{
				value.UpdateMapViewLevel(MapViewLevel);
			}
		}
	}

	public void UpdateEOIList(List<BroadcastGroupInitInfo> _EOIList_InitInfo)
	{
		EOIList = _EOIList_InitInfo.Select((BroadcastGroupInitInfo _initInfo) => _initInfo.EntityId).ToList();
		foreach (BroadcastGroupInitInfo item in _EOIList_InitInfo)
		{
			if (!Dict_GvGGroup.TryGetValue(item.EntityId.ToString(), out var _))
			{
				bool flag = TryCreateGroup(item);
				break;
			}
		}
	}

	private void PlayBGM()
	{
		if (!bgm.isPlaying)
		{
			bgm.Play();
		}
		isBgmPlaying = true;
	}

	private void PauseBGM()
	{
		if (bgm.isPlaying)
		{
			bgm.Pause();
		}
		isBgmPlaying = false;
	}

	public void StopBGM()
	{
		if (bgm.isPlaying)
		{
			bgm.Stop();
		}
		isBgmPlaying = false;
	}
}
