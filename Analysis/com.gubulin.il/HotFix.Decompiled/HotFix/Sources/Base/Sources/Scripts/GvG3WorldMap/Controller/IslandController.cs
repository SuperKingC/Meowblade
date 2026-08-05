using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Assets.Scripts.UI;
using GvG3;
using HotFix.Sources.Base.Scripts.Helper;
using HotFix.Sources.Base.Sources.Scripts.GvG3.GvG3Common.Manager;
using HotFix.Sources.Base.Sources.Scripts.GvG3.GvG3Common.Network.C2S;
using HotFix.Sources.Base.Sources.Scripts.GvG3.GvG3UI.Helper;
using HotFix.Sources.Base.Sources.Scripts.GvG3.GvG3UI.Model.UserProfile;
using HotFix.Sources.Base.Sources.Scripts.GvG3.GvG3WorldMap.Manager;
using HotFix.Sources.Base.Sources.Scripts.GvG3.GvG3WorldMap.Model;
using HotFix.Sources.Base.Sources.Scripts.GvG3Common.Controller;
using HotFix.Sources.Base.Sources.Scripts.GvG3Common.Model;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Manager;
using HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Extensions;
using HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Helper;
using HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Manager;
using HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Model;
using Shift.Legion.Common.Helpers;
using Shift.Legion.GvG.Common.Enums;
using Shift.Legion.GvG.Common.Models;
using Shift.Legion.GvG.Common.Models.GvGMode3;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.Rendering;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Controller;

public class IslandController : MonoBehaviour
{
	private enum eIslandLOD
	{
		Lod1,
		Lod2
	}

	private enum eUserCampId
	{
		Camp1 = 1,
		Camp2,
		Camp3,
		Camp4
	}

	[StructLayout(LayoutKind.Sequential, Size = 1)]
	private struct Constants
	{
		public const string LIST = "List";

		public const string ITEM_ICON = "IslandItemIcon";

		public const string LOD1 = "Lod1";

		public const string LOD2 = "Lod2";

		public const string FILTER_ICONS = "FilterIcons";

		public const int FILTER_ICONS_MAX = 3;
	}

	private class IslandComponentCache
	{
		public Transform CampShipCountTrans;

		public Dictionary<int, int> CampShipCount_Dict;

		public Transform MyCampShipCount;

		public List<(int, int)> LastCampShipCount;

		public Transform CampShipSlotParent;

		public List<EOI_ShipInfoOnIsland> LastShipsForDisplay;

		public List<ShipSlot> CampShipSlots;

		public CoroutineQueue AnimCoroutineQueue;

		public GameObject PlayerCommand;

		public SpriteRenderer PlayerCommandAvatar;

		public int PlayerCommandLastUserId;

		public TransPageController<eUserCampId> PlayerCommandCampPage;

		public TextMesh PlayerCommandRemainingTime;

		public TransPageController<eContribLevel> PlayerCommandPercentLevel_Lod1;

		public TransPageController<eContribLevel> PlayerCommandPercentLevel_Lod2;

		public TransPageController<ePlayerCommandUIState> PlayerCommandState_Lod1;

		public TransPageController<ePlayerCommandUIState> PlayerCommandState_Lod2;

		public float DefaultAvatarSpriteSize;

		public GameObject DetectedResourceGameObject;

		public GameObject ExtraResourceGameObject;

		public Transform FireSupportTrans;

		public GameObject HiddenResourceGameObject;

		public TransPageController<eIslandUIState> IslandStatePage_Lod1;

		public TransPageController<eIslandUIState> IslandStatePage_Lod2;

		public Transform IslandStateTrans;

		public Coroutine LocationSignCoroutine;

		public Transform NamePlateTrans;

		public TransPageController<eIslandCampId> NamePlateCampPage_Lod1;

		public TransPageController<eIslandCampId> NamePlateCampPage_Lod2;

		public TransPageController<eUserCampId> NamePlateUserCountCampPage;

		public Transform NamePlateUserCountText;

		public Transform NamePlateUserCountTrans;

		public GameObject RandomEventGameObject;

		public TextMesh RandomEventRemainingTimeText;

		public TransPageController<eRandomEventUIState> RandomEventStatePage;

		public Transform ShieldTrans;

		public Transform ShieldDamagedFXTrans;

		public float ShieldPointBarSize;

		public Transform ShieldPointBarTrans;

		public Transform ShieldPointFxTrans;

		public Transform ShieldPointCountTrans;

		public Transform ShieldBrokenTrans;

		public TransPageController<eIslandShieldState> ShieldStatePage;

		public FlagShipAttackEvent AttackEvent;

		public Action ShieldPointUpdateStrategy;

		public GameObject TreasureMapGameObject;

		public TextMesh TreasureMapRemainingTimeText;

		public TransPageController<eTreasureMapUIState> TreasureMapStatePage;

		public IslandComponentLodWrapper<Transform> DetectedResourceLod1 { get; } = new IslandComponentLodWrapper<Transform>();

		public IslandComponentLodWrapper<Transform> DetectedResourceLod2 { get; } = new IslandComponentLodWrapper<Transform>();

		public GameObject FilterIconsGameObject { get; set; }

		public IslandComponentLodWrapper<Transform> FilterIconsLod1 { get; } = new IslandComponentLodWrapper<Transform>();

		public IslandComponentLodWrapper<Transform> FilterIconsLod2 { get; } = new IslandComponentLodWrapper<Transform>();

		public GOListController FilterIconsList { get; set; }

		public string CurFilterId { get; set; }

		public List<string> FilterIconsUrl { get; } = new List<string>(3);
	}

	public class ShipSlot
	{
		public int CampId;

		public int UserId;

		public Transform SlotTrans;

		public Coroutine AnimCoroutine;

		public void PlayDockAnim(MonoBehaviour mono)
		{
			if (AnimCoroutine != null)
			{
				mono.StopCoroutine(AnimCoroutine);
			}
			AnimCoroutine = mono.StartCoroutine(_PlayDockAnim());
		}

		public void PlayUndockAnim(MonoBehaviour mono)
		{
			if (AnimCoroutine != null)
			{
				mono.StopCoroutine(AnimCoroutine);
			}
			AnimCoroutine = mono.StartCoroutine(_PlayUndockAnim());
		}

		private IEnumerator _PlayDockAnim()
		{
			SetSlotToTopSortingOrder(SlotTrans);
			((Component)SlotTrans).gameObject.SetActive(true);
			((Component)SlotTrans).GetComponent<Animation>().Play("slot_show");
			yield return (object)new WaitForSeconds(1.3f);
			SetSlotToNormalSortingOrder(SlotTrans);
			AnimCoroutine = null;
		}

		private IEnumerator _PlayUndockAnim()
		{
			SetSlotToTopSortingOrder(SlotTrans);
			((Component)SlotTrans).GetComponent<Animation>().Play("slot_hide");
			yield return (object)new WaitForSeconds(0.3f);
			((Component)SlotTrans).gameObject.SetActive(false);
			AnimCoroutine = null;
		}

		private void SetSlotToNormalSortingOrder(Transform slotTrans)
		{
			((Component)slotTrans).GetComponent<SortingGroup>().sortingOrder = 50;
		}

		private void SetSlotToTopSortingOrder(Transform slotTrans)
		{
			((Component)slotTrans).GetComponent<SortingGroup>().sortingOrder = 51;
		}
	}

	private enum eContribLevel
	{
		Level0,
		Level1,
		Level2
	}

	public class EarlyWarningIcon
	{
		public GameObject Go;

		public Transform Trans;

		public Transform Lod1;

		public Transform Lod2;

		public void Init(GameObject go)
		{
			Go = go;
			Trans = go.transform;
			Lod1 = Trans.Find("Lod1");
			Lod2 = Trans.Find("Lod2");
		}

		public void Refresh(int warning)
		{
			if (warning < 0)
			{
				Go.SetActive(false);
				return;
			}
			Go.SetActive(true);
			int num = warning - 1;
			for (int i = 0; i < Lod1.childCount; i++)
			{
				Transform child = Lod1.GetChild(i);
				((Component)child).gameObject.SetActive(num == i);
			}
			for (int j = 0; j < Lod2.childCount; j++)
			{
				Transform child2 = Lod2.GetChild(j);
				((Component)child2).gameObject.SetActive(num == j);
			}
		}
	}

	public enum eIslandUIState
	{
		Peace,
		Fighting,
		ProtectedPeriod,
		Rebellion,
		Suppress
	}

	private enum eIslandCampId
	{
		Camp0,
		Camp1,
		Camp2,
		Camp3,
		Camp4
	}

	public bool IsLoading;

	public int IslandId;

	public int CampId;

	public IslandConfigData IslandConfig;

	private WorldStateManager WorldStateManager;

	private float NextUpdateTime;

	private const float UpdateInterval = 1f;

	private LODController<eIslandLOD> LODController;

	private int CurrentTimestamp;

	private CustomUniqueEvent<IslandStateModel> UpdateStrategy;

	private Transform RootTrans;

	private Collider Collider;

	private Transform ColliderTrans;

	private Transform CampArea;

	private Transform FogArea;

	private Transform IslandDeco;

	private string PrefabName;

	private Transform IslandPlane;

	private MeshRenderer CampAreaMeshRenderer;

	private SortingGroup ShowOnTopSortingGroup;

	private IslandComponentCache CompCache;

	private Animation _spriteAnim;

	private SelfAdaptionProcessor _adaptionProcessor;

	private const float _ALIGN_TOP_COMPONENT_PER_SIZE = 0.76f;

	private const float _ALIGN_CENTER_COMPONENT_PER_SIZE = 0.52f;

	private int _warningLevel;

	private EarlyWarningIcon _earlyWarningIcon;

	private const int FXValidTimeToPlay = 3;

	private GameObject _outlineGo;

	private void Awake()
	{
		RootTrans = ((Component)this).transform.Find("Root");
		ColliderTrans = RootTrans.Find("IslandCollider");
		Collider = ((Component)ColliderTrans).GetComponent<Collider>();
		CampArea = RootTrans.Find("CampArea");
		FogArea = RootTrans.Find("FogArea");
		CampAreaMeshRenderer = ((Component)RootTrans.Find("CampArea/CampArea")).GetComponent<MeshRenderer>();
		UpdateStrategy = new CustomUniqueEvent<IslandStateModel>();
	}

	public void Load(int islandId)
	{
		IsLoading = true;
		CompCache = new IslandComponentCache();
		WorldStateManager = Singleton<WorldStateManager>.Instance;
		RenderStaticData(islandId);
		InitSelfAdaptionProcessor();
		RegisterModel(islandId);
		OnCamSizeChange(GvGWorldMapController.Instance.CameraBindingManager.MainCamera.orthographicSize);
		IsLoading = false;
	}

	public void Reload()
	{
		IslandStateModel islandStateModel = WorldStateManager.TryGetIsland(IslandId);
		RenderState(islandStateModel);
		RenderState_FilterIcons(islandStateModel.CurFilterId);
	}

	public void Unload()
	{
		((Behaviour)this).enabled = false;
		UnRegisterModel();
		StopLocationSign();
		CompCache = null;
		_adaptionProcessor = null;
		LODController = null;
		UpdateStrategy.Clear();
		Object.Destroy((Object)(object)((Component)IslandPlane).gameObject);
		UnloadOutline();
		UnloadEarlyWarning();
	}

	public void RegisterModel(int islandId)
	{
		IslandStateModel islandStateModel = WorldStateManager.TryGetIsland(islandId);
		RenderState(islandStateModel);
		RenderState_FilterIcons(islandStateModel.CurFilterId);
		islandStateModel.OnChange = (Action<IslandStateModel>)Delegate.Combine(islandStateModel.OnChange, new Action<IslandStateModel>(RenderState));
		islandStateModel.OnFogAreaChange = (Action<IslandStateModel>)Delegate.Combine(islandStateModel.OnFogAreaChange, new Action<IslandStateModel>(RenderState_FogArea));
		islandStateModel.OnHideNameAndStateChange = (Action<IslandStateModel>)Delegate.Combine(islandStateModel.OnHideNameAndStateChange, new Action<IslandStateModel>(OnHideNameAndStateChange));
		islandStateModel.OnCameraLocate = (Action<float>)Delegate.Combine(islandStateModel.OnCameraLocate, new Action<float>(ShowLocationSign));
		islandStateModel.OnChangeFlagShipAttackEvent = (Action<IslandStateModel>)Delegate.Combine(islandStateModel.OnChangeFlagShipAttackEvent, new Action<IslandStateModel>(OnChangeFlagShipAttackEvent));
		islandStateModel.OnControllerLoaded?.Invoke(this);
		islandStateModel.OnFilterChange = (Action<string>)Delegate.Combine(islandStateModel.OnFilterChange, new Action<string>(RenderState_FilterIcons));
		CameraBindingManager cameraBindingManager = GvGWorldMapController.Instance.CameraBindingManager;
		cameraBindingManager.OnChangeSize = (Action<float>)Delegate.Combine(cameraBindingManager.OnChangeSize, new Action<float>(OnCamSizeChange));
		islandStateModel.OnHideStateChange = (Action<bool>)Delegate.Combine(islandStateModel.OnHideStateChange, new Action<bool>(OnHideStateChange));
	}

	public void UnRegisterModel()
	{
		IslandStateModel islandStateModel = WorldStateManager.TryGetIsland(IslandId);
		islandStateModel.OnChange = (Action<IslandStateModel>)Delegate.Remove(islandStateModel.OnChange, new Action<IslandStateModel>(RenderState));
		islandStateModel.OnFogAreaChange = (Action<IslandStateModel>)Delegate.Remove(islandStateModel.OnFogAreaChange, new Action<IslandStateModel>(RenderState_FogArea));
		islandStateModel.OnHideNameAndStateChange = (Action<IslandStateModel>)Delegate.Remove(islandStateModel.OnHideNameAndStateChange, new Action<IslandStateModel>(OnHideNameAndStateChange));
		islandStateModel.OnCameraLocate = (Action<float>)Delegate.Remove(islandStateModel.OnCameraLocate, new Action<float>(ShowLocationSign));
		islandStateModel.OnChangeFlagShipAttackEvent = (Action<IslandStateModel>)Delegate.Remove(islandStateModel.OnChangeFlagShipAttackEvent, new Action<IslandStateModel>(OnChangeFlagShipAttackEvent));
		islandStateModel.OnControllerUnloaded?.Invoke(this);
		islandStateModel.OnFilterChange = (Action<string>)Delegate.Remove(islandStateModel.OnFilterChange, new Action<string>(RenderState_FilterIcons));
		CameraBindingManager cameraBindingManager = GvGWorldMapController.Instance.CameraBindingManager;
		cameraBindingManager.OnChangeSize = (Action<float>)Delegate.Remove(cameraBindingManager.OnChangeSize, new Action<float>(OnCamSizeChange));
		islandStateModel.OnHideStateChange = (Action<bool>)Delegate.Remove(islandStateModel.OnHideStateChange, new Action<bool>(OnHideStateChange));
		((Behaviour)this).enabled = false;
	}

	private void RenderStaticData(int islandId)
	{
		//IL_0066: Unknown result type (might be due to invalid IL or missing references)
		//IL_0098: Unknown result type (might be due to invalid IL or missing references)
		//IL_00af: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0132: Unknown result type (might be due to invalid IL or missing references)
		//IL_0149: Unknown result type (might be due to invalid IL or missing references)
		//IL_0160: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_0207: Unknown result type (might be due to invalid IL or missing references)
		IslandId = islandId;
		IslandConfig = WorldMapConfigHelper.Configs.TryGetIsland(IslandId);
		LODController = new LODController<eIslandLOD>();
		int curIZId = Singleton<GvGMode3RoomManager>.Instance.ObserverRecord.CurIZId;
		((Object)((Component)this).gameObject).name = $"{IslandId}";
		((Component)this).transform.localPosition = IslandConfig.Position;
		((Object)Collider).name = eObjectType.Island.ToString();
		ColliderTrans.localScale = IslandConfig.ColliderScale;
		CampArea.localScale = IslandConfig.CampAreaScale;
		FogArea.localScale = IslandConfig.FogAreaScale;
		PrefabName = WorldMapConfigHelper.GetSprite(IslandConfig.Props, curIZId);
		IslandPlane = GvGWorldMapController.Instance.InstantiateFromPrefab(PrefabName).transform;
		IslandPlane.SetParent(RootTrans, false);
		((Object)((Component)IslandPlane).gameObject).name = "IslandPlane";
		IslandPlane.localPosition = Vector3.zero;
		IslandPlane.localScale = IslandConfig.PlaneScale;
		IslandPlane.rotation = IslandConfig.PlaneRotation;
		_spriteAnim = ((Component)IslandPlane.Find("plane/sprite")).GetComponent<Animation>();
		InitEarlyWarning();
		string deco = WorldMapConfigHelper.GetDeco(IslandConfig.Props, curIZId);
		if (deco != null)
		{
			string text = "GvG/IslandDeco/" + deco + ".prefab";
			IslandDeco = Addressables.InstantiateAsync((object)text, (Transform)null, false, true).WaitForCompletion().transform;
			IslandDeco.SetParent(IslandPlane, false);
			((Object)((Component)IslandDeco).gameObject).name = "IslandDeco";
			IslandDeco.localPosition = Vector3.zero;
		}
		Init_NamePlate();
	}

	private void RenderState(IslandStateModel islandState)
	{
		CurrentTimestamp = (int)GameController.Instance.GetServerTime();
		CampId = islandState.CampId;
		CampAreaHelper.SetCampArea(CampId, CampAreaMeshRenderer);
		RenderState_FogArea(islandState);
		RenderState_NamePlate(islandState);
		RenderState_CampShipCount(islandState);
		RenderState_CampShipSlot(islandState);
		RenderState_IslandState(islandState);
		RenderState_FireSupport(islandState);
		RenderState_HiddenResource(islandState);
		RenderState_ExtraResource(islandState);
		RenderState_Shield(islandState);
		RenderState_FlagShipAttackEvent(islandState);
		RenderState_TreasureMap(islandState);
		RenderState_RandomEvent(islandState);
		RenderState_Command(islandState);
		RenderState_DetectedResource(islandState);
		RenderState_HiddenState(islandState);
		CheckShowOnTop(islandState);
		NextUpdateTime = (float)(int)Time.time + 1f;
		((Behaviour)this).enabled = NeedUpdate(islandState);
	}

	public void RenderState_FogArea(IslandStateModel islandState)
	{
		int myCampId = Singleton<WorldStateManager>.Instance.Data.MyCampId;
		bool visibility = islandState.GetVisibility(myCampId);
		visibility &= WorldStateManager.IsOurCampIslandVisible;
		bool flag = WorldStateManager.AdditionalIslandIds.Contains(IslandId);
		bool flag2 = WorldStateManager.BrawlFinalIslandIds.Contains(IslandId);
		((Component)FogArea).gameObject.SetActive(visibility || flag || flag2);
	}

	private void OnHideNameAndStateChange(IslandStateModel islandState)
	{
		RenderState_NamePlate(islandState);
		RenderState_IslandState(islandState);
	}

	private void CheckShowOnTop(IslandStateModel islandState)
	{
		if (islandState.IsOnTop == ((Object)(object)ShowOnTopSortingGroup != (Object)null))
		{
			return;
		}
		if (islandState.IsOnTop)
		{
			ShowOnTopSortingGroup = ((Component)IslandPlane).gameObject.GetComponent<SortingGroup>();
			if ((Object)(object)ShowOnTopSortingGroup == (Object)null)
			{
				ShowOnTopSortingGroup = ((Component)IslandPlane).gameObject.AddComponent<SortingGroup>();
			}
			ShowOnTopSortingGroup.sortingLayerName = "UI";
			ShowOnTopSortingGroup.sortingOrder = 2;
			Transform obj = IslandPlane.Find("plane/clouds");
			if (obj != null)
			{
				((Component)obj).gameObject.SetActive(false);
			}
		}
		else
		{
			Object.Destroy((Object)(object)ShowOnTopSortingGroup);
			ShowOnTopSortingGroup = null;
			Transform obj2 = IslandPlane.Find("plane/clouds");
			if (obj2 != null)
			{
				((Component)obj2).gameObject.SetActive(true);
			}
		}
	}

	public bool NeedUpdate(IslandStateModel islandState)
	{
		return !UpdateStrategy.IsEmpty || CompCache.ShieldPointUpdateStrategy != null;
	}

	private void Update()
	{
		CompCache.ShieldPointUpdateStrategy?.Invoke();
		if (!(Time.time < NextUpdateTime))
		{
			IslandStateModel islandStateModel = WorldStateManager.TryGetIsland(IslandId);
			if (islandStateModel != null)
			{
				CurrentTimestamp = (int)GameController.Instance.GetServerTime();
				UpdateStrategy.Invoke(islandStateModel);
				NextUpdateTime = (float)(int)Time.time + 1f;
				((Behaviour)this).enabled = NeedUpdate(islandStateModel);
			}
		}
	}

	private void RenderState_HiddenState(IslandStateModel islandState)
	{
		if (islandState.IsHiddenIsland || islandState.IsSpecialSuppressIsland)
		{
			OnHideStateChange(islandState.IsVisible);
		}
		else
		{
			((Component)RootTrans).gameObject.SetActive(true);
		}
	}

	private eIslandLOD GetLODLevel(float camSize)
	{
		if (camSize < 8.75f)
		{
			return eIslandLOD.Lod1;
		}
		return eIslandLOD.Lod2;
	}

	private void OnCamSizeChange(float size)
	{
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		//IL_003a: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Unknown result type (might be due to invalid IL or missing references)
		//IL_005d: Unknown result type (might be due to invalid IL or missing references)
		eIslandLOD lODLevel = GetLODLevel(size);
		LODController.CurLevel = lODLevel;
		if (lODLevel != eIslandLOD.Lod2)
		{
			return;
		}
		HashSet<GameObject> levelGameObject = LODController.GetLevelGameObject(eIslandLOD.Lod2);
		float num = size / 8.75f;
		Vector3 localScale = Vector3.one * num;
		foreach (GameObject item in levelGameObject)
		{
			item.transform.localScale = localScale;
		}
		ProcessSelfAdaptionOnCameraSizeChange(num);
	}

	private void InitSelfAdaptionProcessor()
	{
		List<SelfAdaption> list = new List<SelfAdaption>();
		list.Add(new SelfAdaption
		{
			AlignType = ComponentAlignType.Top,
			AnchorPoint = 0f,
			PerSize = 0.76f,
			Objects = new List<IslandComponentLodWrapper<Transform>> { CompCache.FilterIconsLod1, CompCache.DetectedResourceLod1 },
			ObjectIsActive = ComponentLodIsActive
		});
		list.Add(new SelfAdaption
		{
			AlignType = ComponentAlignType.Center,
			AnchorPoint = 0f,
			PerSize = 0.52f,
			Objects = new List<IslandComponentLodWrapper<Transform>> { CompCache.FilterIconsLod2, CompCache.DetectedResourceLod2 },
			ObjectIsActive = ComponentLodIsActive
		});
		List<SelfAdaption> selfAdaptionList = list;
		_adaptionProcessor = new SelfAdaptionProcessor(selfAdaptionList);
	}

	private void ProcessSelfAdaption()
	{
		_adaptionProcessor?.ProcessAllSelfAdaption(ComponentAlignType.Top);
		_adaptionProcessor?.ProcessAllSelfAdaption(ComponentAlignType.Center);
	}

	private void ProcessSelfAdaptionOnCameraSizeChange(float scale)
	{
		_adaptionProcessor?.ProcessAllSelfAdaption(ComponentAlignType.Center, scale);
	}

	private static bool ComponentLodIsActive(GameObject gameObject)
	{
		return ((Component)gameObject.transform.parent).gameObject.activeSelf;
	}

	private void OnHideStateChange(bool visible)
	{
		bool flag = visible;
		((Component)RootTrans).gameObject.SetActive(flag);
		if (flag)
		{
			SharedMessenger.Broadcast("ON_GVG3_ShowIslandLine", IslandId);
		}
		else
		{
			SharedMessenger.Broadcast("ON_GVG3_HideIslandLine", IslandId);
		}
	}

	public void Init_CampShipCount()
	{
		CompCache.CampShipCountTrans = IslandPlane.Find("plane/user_count");
		CompCache.CampShipCount_Dict = null;
	}

	private void RenderState_CampShipCount(IslandStateModel islandState)
	{
		bool flag = islandState.CampShipCount != null && islandState.CampShipCount.Count > 0;
		if (flag)
		{
			if ((Object)(object)CompCache.CampShipCountTrans == (Object)null)
			{
				Init_CampShipCount();
			}
			if ((Object)(object)CompCache.CampShipCountTrans != (Object)null && CompCache.LastCampShipCount != islandState.CampShipCount)
			{
				CompCache.LastCampShipCount = islandState.CampShipCount;
				int myCampId = WorldStateManager.Data.MyCampId;
				Dictionary<int, int> dictionary = new Dictionary<int, int>();
				bool flag2 = CompCache.CampShipCount_Dict == null;
				foreach (var (num, num2) in islandState.CampShipCount)
				{
					if (num2 == 0)
					{
						continue;
					}
					dictionary[num] = num2;
					if (flag2 || !CompCache.CampShipCount_Dict.TryGetValue(num, out var value) || value != num2)
					{
						Transform myCampShipCount = UpdateSingleCampShipCount(num, num2, !flag2);
						if (myCampId == num)
						{
							CompCache.MyCampShipCount = myCampShipCount;
							UpdateNamePlateMyCampShipCount(islandState, num2);
						}
					}
				}
				if (!flag2)
				{
					foreach (int key in CompCache.CampShipCount_Dict.Keys)
					{
						if (!dictionary.ContainsKey(key))
						{
							((Component)CompCache.CampShipCountTrans.Find($"camp_{key}")).gameObject.SetActive(false);
							if (myCampId == key)
							{
								CompCache.MyCampShipCount = null;
								UpdateNamePlateMyCampShipCount(islandState, 0);
							}
						}
					}
				}
				CompCache.CampShipCount_Dict = dictionary;
			}
		}
		else
		{
			CompCache.MyCampShipCount = null;
		}
		if ((Object)(object)CompCache.MyCampShipCount != (Object)null)
		{
			bool flag3 = islandState.State == eGvGMode3IslandState.Peace || islandState.State == eGvGMode3IslandState.Suppress;
			((Component)CompCache.NamePlateUserCountTrans).gameObject.SetActive(flag3);
			((Component)CompCache.MyCampShipCount).gameObject.SetActive(!flag3);
		}
		else if (((Component)CompCache.NamePlateUserCountTrans).gameObject.activeSelf)
		{
			((Component)CompCache.NamePlateUserCountTrans).gameObject.SetActive(false);
		}
		if ((Object)(object)CompCache.CampShipCountTrans != (Object)null)
		{
			flag = flag && !islandState.IsOnTop;
			if (((Component)CompCache.CampShipCountTrans).gameObject.activeSelf != flag)
			{
				((Component)CompCache.CampShipCountTrans).gameObject.SetActive(flag);
			}
		}
	}

	private Transform UpdateSingleCampShipCount(int campId, int count, bool useAnim)
	{
		Transform val = CompCache.CampShipCountTrans.Find($"camp_{campId}");
		((Component)val).gameObject.SetActive(true);
		GvGHelper.SetOutlineText(val.Find("count"), $"{count}");
		if (useAnim)
		{
			((Component)val.Find("count_vfx")).GetComponent<Animation>().Play("slot_counter_bounce");
		}
		return val;
	}

	private void UpdateNamePlateMyCampShipCount(IslandStateModel islandState, int count)
	{
		bool flag = count > 0;
		if (flag)
		{
			GvGHelper.SetOutlineText(CompCache.NamePlateUserCountText, $"{count}");
		}
		((Component)CompCache.NamePlateUserCountTrans).gameObject.SetActive(flag);
	}

	private void Init_CampShipSlotParent()
	{
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		//IL_003e: Unknown result type (might be due to invalid IL or missing references)
		CompCache.CampShipSlotParent = new GameObject("CampShipSlotParent").transform;
		CompCache.CampShipSlotParent.SetParent(IslandPlane, false);
		CompCache.CampShipSlotParent.localPosition = Vector3.zero;
		LODController.AddToLevel(eIslandLOD.Lod1, CompCache.CampShipSlotParent);
		CompCache.CampShipSlots = new List<ShipSlot>();
		CompCache.AnimCoroutineQueue = new CoroutineQueue((MonoBehaviour)(object)this);
	}

	private void RenderState_CampShipSlot(IslandStateModel islandState)
	{
		//IL_036f: Unknown result type (might be due to invalid IL or missing references)
		//IL_03a3: Unknown result type (might be due to invalid IL or missing references)
		bool flag = islandState.ShipsForDisplay != null && islandState.ShipsForDisplay.Count > 0;
		if (flag && CompCache.LastShipsForDisplay != islandState.ShipsForDisplay)
		{
			CompCache.LastShipsForDisplay = islandState.ShipsForDisplay;
			if ((Object)(object)CompCache.CampShipSlotParent == (Object)null)
			{
				Init_CampShipSlotParent();
			}
			int num = Mathf.Max(islandState.ShipsForDisplay.Count, CompCache.CampShipSlots.Count);
			for (int i = 0; i < num; i++)
			{
				if (i >= islandState.ShipsForDisplay.Count)
				{
					CompCache.CampShipSlots[i].PlayUndockAnim((MonoBehaviour)(object)this);
					continue;
				}
				if (i >= CompCache.CampShipSlots.Count)
				{
					Transform transform = GvGWorldMapController.Instance.InstantiateFromPrefab("slot_blue").transform;
					transform.SetParent(CompCache.CampShipSlotParent, false);
					CompCache.CampShipSlots.Add(new ShipSlot
					{
						SlotTrans = transform
					});
				}
				EOI_ShipInfoOnIsland eOI_ShipInfoOnIsland = islandState.ShipsForDisplay[i];
				ShipSlot shipSlot = CompCache.CampShipSlots[i];
				if (shipSlot.CampId != eOI_ShipInfoOnIsland.CampId)
				{
					string shipSlotName = WorldMapConfigHelper.TryGetCampPrefabConfig(eOI_ShipInfoOnIsland.CampId).ShipSlotName;
					Sprite sprite = ((Component)GvGWorldMapController.Instance.GetPrefab(shipSlotName).transform.Find("Content/frame")).GetComponent<SpriteRenderer>().sprite;
					((Component)shipSlot.SlotTrans.Find("Content/frame")).GetComponent<SpriteRenderer>().sprite = sprite;
					shipSlot.CampId = eOI_ShipInfoOnIsland.CampId;
				}
				if (shipSlot.UserId != eOI_ShipInfoOnIsland.UserId)
				{
					SpriteRenderer slotPortrait = ((Component)shipSlot.SlotTrans.Find("Content/portrait")).GetComponent<SpriteRenderer>();
					slotPortrait.sprite = GvGWorldMapController.Instance.DefaultAvatarSprite;
					shipSlot.UserId = eOI_ShipInfoOnIsland.UserId;
					int userId = eOI_ShipInfoOnIsland.UserId;
					GvG3ProfileHelper.GetUserProfile(new GvG3UserProfileRequestOptions($"{Singleton<GvGMode3RoomManager>.Instance.ObserverRecord.CurIZId}", userId, null, delegate(Sprite sprite2)
					{
						if (Object.op_Implicit((Object)(object)slotPortrait) && shipSlot.UserId == userId)
						{
							slotPortrait.sprite = sprite2;
						}
					}));
					shipSlot.PlayDockAnim((MonoBehaviour)(object)this);
				}
				IslandShipDockInRecord shipDockInRecord = WorldStateManager.TryGetIsland(IslandId).ShipDockInRecord;
				Vec3 vec;
				if (eOI_ShipInfoOnIsland.SlotIndex < 0)
				{
					vec = shipDockInRecord.GetShipDockInNewSlotPos(eOI_ShipInfoOnIsland.EntityId, eOI_ShipInfoOnIsland.CampId, out var posIndex);
					eOI_ShipInfoOnIsland.SlotIndex = posIndex;
				}
				else
				{
					vec = shipDockInRecord.GetShipDockInLastSlotPos(eOI_ShipInfoOnIsland.EntityId, eOI_ShipInfoOnIsland.CampId, eOI_ShipInfoOnIsland.SlotIndex);
				}
				shipSlot.SlotTrans.localPosition = new Vector3(vec.x, vec.y, vec.z);
				shipSlot.SlotTrans.Find("Content").localScale = new Vector3(eOI_ShipInfoOnIsland.AvatarScale, 0f, eOI_ShipInfoOnIsland.AvatarScale);
			}
		}
		if ((Object)(object)CompCache.CampShipSlotParent != (Object)null)
		{
			flag = flag && !islandState.IsOnTop;
			if (((Component)CompCache.CampShipSlotParent).gameObject.activeSelf != flag)
			{
				((Component)CompCache.CampShipSlotParent).gameObject.SetActive(flag);
			}
		}
	}

	private void Init_Command()
	{
		//IL_0105: Unknown result type (might be due to invalid IL or missing references)
		IslandComponentCache compCache = CompCache;
		Transform obj = IslandPlane.Find("plane/Command");
		compCache.PlayerCommand = ((obj != null) ? ((Component)obj).gameObject : null);
		if ((Object)(object)CompCache.PlayerCommand == (Object)null)
		{
			throw new Exception($"[IslandController_Command] PlayerCommand == null IslandId={IslandId} PrefabName={PrefabName}");
		}
		Transform val = CompCache.PlayerCommand.transform.Find("Lod1");
		Transform val2 = CompCache.PlayerCommand.transform.Find("Lod2");
		LODController.AddToLevel(eIslandLOD.Lod1, val);
		LODController.AddToLevel(eIslandLOD.Lod2, val2);
		CompCache.PlayerCommandLastUserId = -1;
		CompCache.PlayerCommandCampPage = new TransPageController<eUserCampId>(val.Find("User"), eUserCampId.Camp1);
		CompCache.PlayerCommandAvatar = ((Component)val.Find("User/portrait")).GetComponent<SpriteRenderer>();
		CompCache.DefaultAvatarSpriteSize = CompCache.PlayerCommandAvatar.size.x;
		CompCache.PlayerCommandRemainingTime = ((Component)val.Find("RemainingTime")).GetComponent<TextMesh>();
		CompCache.PlayerCommandPercentLevel_Lod1 = new TransPageController<eContribLevel>(val.Find("PercentLevel"), eContribLevel.Level0);
		CompCache.PlayerCommandPercentLevel_Lod2 = new TransPageController<eContribLevel>(val2.Find("PercentLevel"), eContribLevel.Level0);
		CompCache.PlayerCommandState_Lod1 = new TransPageController<ePlayerCommandUIState>(val.Find("State"), ePlayerCommandUIState.Attack);
		CompCache.PlayerCommandState_Lod2 = new TransPageController<ePlayerCommandUIState>(val2.Find("State"), ePlayerCommandUIState.Attack);
	}

	private bool IsCommandValid(IslandStateModel islandState)
	{
		return islandState.PlayerCommand != null && islandState.PlayerCommand.StillValid(CurrentTimestamp);
	}

	private void RenderState_Command(IslandStateModel islandState)
	{
		bool flag = IsCommandValid(islandState);
		UpdateStrategy.RemoveListener(Update_Command);
		if (flag)
		{
			if ((Object)(object)CompCache.PlayerCommand == (Object)null)
			{
				Init_Command();
			}
			IEvent_PlayerCommand playerCommand = islandState.PlayerCommand;
			CompCache.PlayerCommandPercentLevel_Lod1.SelectedPage = (eContribLevel)playerCommand.ContribLevel;
			CompCache.PlayerCommandPercentLevel_Lod2.SelectedPage = (eContribLevel)playerCommand.ContribLevel;
			CompCache.PlayerCommandState_Lod1.SelectedPage = islandState.PlayerCommandSubType;
			CompCache.PlayerCommandState_Lod2.SelectedPage = islandState.PlayerCommandSubType;
			if (CompCache.PlayerCommandLastUserId != islandState.PlayerCommand.UserId)
			{
				CompCache.PlayerCommandLastUserId = playerCommand.UserId;
				CompCache.PlayerCommandCampPage.SelectedPage = (eUserCampId)playerCommand.CampId;
				CompCache.PlayerCommandAvatar.sprite = null;
				GvG3ProfileHelper.GetUserProfile(new GvG3UserProfileRequestOptions($"{Singleton<GvGMode3RoomManager>.Instance.ObserverRecord.CurIZId}", playerCommand.UserId, null, delegate(Sprite sprite)
				{
					//IL_002c: Unknown result type (might be due to invalid IL or missing references)
					//IL_0047: Unknown result type (might be due to invalid IL or missing references)
					//IL_0052: Unknown result type (might be due to invalid IL or missing references)
					//IL_0057: Unknown result type (might be due to invalid IL or missing references)
					//IL_0068: Unknown result type (might be due to invalid IL or missing references)
					if (Object.op_Implicit((Object)(object)CompCache.PlayerCommandAvatar))
					{
						CompCache.PlayerCommandAvatar.sprite = sprite;
						Vector3 localScale = Vector3.one * (CompCache.DefaultAvatarSpriteSize / CompCache.PlayerCommandAvatar.size.x);
						((Component)CompCache.PlayerCommandAvatar).transform.localScale = localScale;
					}
				}));
			}
			Update_Command(islandState);
			UpdateStrategy.AddListener(Update_Command);
		}
		if ((Object)(object)CompCache.PlayerCommand != (Object)null)
		{
			flag = flag && !islandState.IsOnTop;
			if (CompCache.PlayerCommand.activeSelf != flag)
			{
				CompCache.PlayerCommand.SetActive(flag);
			}
		}
	}

	private void Update_Command(IslandStateModel islandState)
	{
		if (!IsCommandValid(islandState))
		{
			CompCache.PlayerCommand.SetActive(false);
			UpdateStrategy.RemoveListener(Update_Command);
		}
		else
		{
			CompCache.PlayerCommandRemainingTime.text = UiHelper.ParseTime(islandState.PlayerCommand.RemainingTime(CurrentTimestamp));
		}
	}

	private void Init_DetectedResource(IslandResource_勘探强化 rc)
	{
		IslandComponentCache compCache = CompCache;
		Transform obj = IslandPlane.Find("plane/DetectedResource");
		compCache.DetectedResourceGameObject = ((obj != null) ? ((Component)obj).gameObject : null);
		if ((Object)(object)CompCache.DetectedResourceGameObject == (Object)null)
		{
			throw new Exception($"[IslandController_DetectedResource] DetectedResourceGameObject == null IslandId={IslandId} PrefabName={PrefabName}");
		}
		CompCache.DetectedResourceLod1.Value = CompCache.DetectedResourceGameObject.transform.Find("Lod1");
		CompCache.DetectedResourceLod2.Value = CompCache.DetectedResourceGameObject.transform.Find("Lod2");
		((Component)CompCache.DetectedResourceLod1.Value.Find($"bg{rc.Items.Count}")).gameObject.SetActive(true);
		GameObject gameObject = ((Component)CompCache.DetectedResourceLod1.Value.Find("List")).gameObject;
		GameObject prefab = GvGWorldMapController.Instance.GetPrefab("IslandItemIcon");
		GOListController gOListController = gameObject.GetComponent<GOListController>() ?? gameObject.AddComponent<GOListController>();
		gOListController.gap = -0.2f;
		gOListController.itemProvider = prefab;
		gOListController.itemRenderer = renderer;
		gOListController.numItems = rc.Items.Count;
		LODController.AddToLevel(eIslandLOD.Lod1, CompCache.DetectedResourceLod1.Value);
		LODController.AddToLevel(eIslandLOD.Lod2, CompCache.DetectedResourceLod2.Value);
		void renderer(int i, GameObject slot)
		{
			string itemName = rc.Items[i];
			slot.LoadFguiIcon(UiHelper.GetItemIconPath(itemName));
		}
	}

	private void RenderState_DetectedResource(IslandStateModel islandState)
	{
		IslandResource_勘探强化 islandResource = Singleton<GvGTalent勘探强化Manager>.Instance.GetIslandResource(IslandId);
		bool flag = islandResource != null;
		if (flag && (Object)(object)CompCache.DetectedResourceGameObject == (Object)null)
		{
			Init_DetectedResource(islandResource);
		}
		if (!((Object)(object)CompCache.DetectedResourceGameObject == (Object)null))
		{
			flag = flag && !islandState.IsOnTop;
			if (CompCache.DetectedResourceGameObject.activeSelf != flag)
			{
				CompCache.DetectedResourceGameObject.SetActive(flag);
				ProcessSelfAdaption();
			}
		}
	}

	public void OnChangeDetectedResource(GvGTalent勘探强化Manager.eResourceState state)
	{
		switch (state)
		{
		case GvGTalent勘探强化Manager.eResourceState.Init:
			RenderState_DetectedResource(WorldStateManager.TryGetIsland(IslandId));
			CompCache.DetectedResourceGameObject.GetComponent<Animation>().Play("detect_resource_show");
			break;
		case GvGTalent勘探强化Manager.eResourceState.Blink:
			CompCache.DetectedResourceGameObject.GetComponent<Animation>().Play("detect_resource_blink");
			break;
		case GvGTalent勘探强化Manager.eResourceState.Destroy:
			RenderState_DetectedResource(WorldStateManager.TryGetIsland(IslandId));
			break;
		}
	}

	public void InitEarlyWarning()
	{
		_warningLevel = -1;
		CrisisDetectManager crisisDetectManager = GvGWorldMapController.Instance.CrisisDetectManager;
		OnWarningLevelChange(crisisDetectManager.EarlyWarningInfo);
		crisisDetectManager.OnEarlyWarningInfoChange = (Action<C2S_GetEarlyWarningInfo.Response>)Delegate.Combine(crisisDetectManager.OnEarlyWarningInfoChange, new Action<C2S_GetEarlyWarningInfo.Response>(OnWarningLevelChange));
	}

	public void UnloadEarlyWarning()
	{
		if (_earlyWarningIcon != null)
		{
			if (Object.op_Implicit((Object)(object)_earlyWarningIcon.Go))
			{
				Object.Destroy((Object)(object)_earlyWarningIcon.Go);
			}
			_earlyWarningIcon = null;
		}
		CrisisDetectManager crisisDetectManager = GvGWorldMapController.Instance.CrisisDetectManager;
		crisisDetectManager.OnEarlyWarningInfoChange = (Action<C2S_GetEarlyWarningInfo.Response>)Delegate.Remove(crisisDetectManager.OnEarlyWarningInfoChange, new Action<C2S_GetEarlyWarningInfo.Response>(OnWarningLevelChange));
	}

	private void OnWarningLevelChange(C2S_GetEarlyWarningInfo.Response res)
	{
		if (res == null)
		{
			return;
		}
		int dangerLevel = res.GetDangerLevel(IslandId);
		if (_warningLevel == dangerLevel)
		{
			return;
		}
		if (_earlyWarningIcon == null)
		{
			Transform val = IslandPlane.Find("plane/EarlyWarningIcon");
			if (!Object.op_Implicit((Object)(object)val))
			{
				ILRuntimeDebug.LogError("Island Missing Prefab: EarlyWarningIcon");
				return;
			}
			_earlyWarningIcon = new EarlyWarningIcon();
			_earlyWarningIcon.Init(((Component)val).gameObject);
			LODController.AddToLevel(eIslandLOD.Lod1, _earlyWarningIcon.Lod1);
			LODController.AddToLevel(eIslandLOD.Lod2, _earlyWarningIcon.Lod2);
		}
		_warningLevel = dangerLevel;
		_earlyWarningIcon.Refresh(dangerLevel);
	}

	private void Init_ExtraResource()
	{
		IslandComponentCache compCache = CompCache;
		Transform obj = IslandPlane.Find("plane/ExtraResource");
		compCache.ExtraResourceGameObject = ((obj != null) ? ((Component)obj).gameObject : null);
		if ((Object)(object)CompCache.ExtraResourceGameObject == (Object)null)
		{
			throw new Exception($"[IslandController_ExtraResource] ExtraResourceGameObject == null IslandId={IslandId} PrefabName={PrefabName}");
		}
		LODController.AddToLevel(eIslandLOD.Lod1, CompCache.ExtraResourceGameObject.transform.Find("Lod1"));
		LODController.AddToLevel(eIslandLOD.Lod2, CompCache.ExtraResourceGameObject.transform.Find("Lod2"));
	}

	private void RenderState_ExtraResource(IslandStateModel islandState)
	{
		bool is额外发现Active = islandState.Is额外发现Active;
		if (is额外发现Active && (Object)(object)CompCache.ExtraResourceGameObject == (Object)null)
		{
			Init_ExtraResource();
		}
		if ((Object)(object)CompCache.ExtraResourceGameObject != (Object)null)
		{
			is额外发现Active = is额外发现Active && !islandState.IsOnTop;
			if (CompCache.ExtraResourceGameObject.activeSelf != is额外发现Active)
			{
				CompCache.ExtraResourceGameObject.SetActive(is额外发现Active);
			}
		}
	}

	private void Init_FilterIcons()
	{
		InitLod();
		InitFilterIconsList();
	}

	private void InitLod()
	{
		IslandComponentCache compCache = CompCache;
		Transform obj = IslandPlane.Find("plane/FilterIcons");
		compCache.FilterIconsGameObject = ((obj != null) ? ((Component)obj).gameObject : null);
		if ((Object)(object)CompCache.FilterIconsGameObject == (Object)null)
		{
			throw new Exception($"[IslandController_FilterIcons] FilterIconsGameObject == null IslandId={IslandId} PrefabName={PrefabName}");
		}
		CompCache.FilterIconsLod1.Value = CompCache.FilterIconsGameObject.transform.Find("Lod1");
		CompCache.FilterIconsLod2.Value = CompCache.FilterIconsGameObject.transform.Find("Lod2");
		LODController.AddToLevel(eIslandLOD.Lod1, CompCache.FilterIconsLod1.Value);
		LODController.AddToLevel(eIslandLOD.Lod2, CompCache.FilterIconsLod2.Value);
	}

	private void InitFilterIconsList()
	{
		GameObject val = ((Component)CompCache.FilterIconsLod1.Value.Find("List")).gameObject ?? throw new Exception($"[IslandController_FilterIcons] FilterIconsList == null IslandId={IslandId} PrefabName={PrefabName}");
		GameObject prefab = GvGWorldMapController.Instance.GetPrefab("IslandItemIcon");
		CompCache.FilterIconsList = val.GetComponent<GOListController>() ?? val.AddComponent<GOListController>();
		CompCache.FilterIconsList.gap = -0.2f;
		CompCache.FilterIconsList.itemProvider = prefab;
		CompCache.FilterIconsList.itemRenderer = Renderer;
	}

	private void Renderer(int i, GameObject slot)
	{
		string url = CompCache.FilterIconsUrl[i];
		slot.LoadFguiIcon(url);
	}

	private void RenderState_FilterIcons(string filterId)
	{
		bool flag = CanDisplayFilterIcons(filterId);
		if (flag && (Object)(object)CompCache.FilterIconsGameObject == (Object)null)
		{
			Init_FilterIcons();
		}
		bool flag2 = !string.Equals(CompCache.CurFilterId, filterId);
		if (flag2)
		{
			ChangeCurFilterId(filterId);
		}
		bool flag3 = (Object)(object)CompCache.FilterIconsGameObject != (Object)null;
		if (flag3)
		{
			SetIconsActive(flag, CompCache.FilterIconsUrl.Count);
		}
		if (flag3 && flag2 && flag)
		{
			UpdateIcons();
		}
	}

	private bool CanDisplayFilterIcons(string filterId)
	{
		if (string.IsNullOrEmpty(filterId))
		{
			return false;
		}
		IslandStateModel model = WorldStateManager.TryGetIsland(IslandId);
		return Singleton<GvGIslandFilterManager>.Instance.CanDisplayFilterIcons(filterId, model);
	}

	private void ChangeCurFilterId(string filterId)
	{
		CompCache.CurFilterId = filterId;
		CompCache.FilterIconsUrl.Clear();
		CompCache.FilterIconsUrl.AddRange(GetUrl(filterId));
	}

	private static List<string> GetUrl(string filterId)
	{
		return Singleton<GvGIslandFilterManager>.Instance.GetIslandFilterIconUrls(filterId);
	}

	private void SetIconsActive(bool isActive, int bgType)
	{
		if (CompCache.FilterIconsGameObject.activeSelf != isActive)
		{
			CompCache.FilterIconsGameObject.SetActive(isActive);
			UpdateIconsBackground(isActive, bgType);
			ProcessSelfAdaption();
		}
	}

	private void UpdateIconsBackground(bool isActive, int bgType)
	{
		if (bgType > 0 && bgType <= 3)
		{
			for (int i = 1; i <= 3; i++)
			{
				string text = $"bg{i}";
				bool active = i == bgType && isActive;
				((Component)CompCache.FilterIconsLod1.Value.Find(text)).gameObject.SetActive(active);
			}
		}
	}

	private void UpdateIcons()
	{
		CompCache.FilterIconsList.numItems = CompCache.FilterIconsUrl.Count;
	}

	public void Init_FireSupport()
	{
		CompCache.FireSupportTrans = IslandPlane.Find("plane/FireSupport");
		if ((Object)(object)CompCache.FireSupportTrans == (Object)null)
		{
			throw new Exception($"[IslandController_FireSupport] FireSupportTrans == null IslandId={IslandId} PrefabName={PrefabName}");
		}
		Transform trans = CompCache.FireSupportTrans.Find("Lod1");
		Transform trans2 = CompCache.FireSupportTrans.Find("Lod2");
		LODController.AddToLevel(eIslandLOD.Lod1, trans);
		LODController.AddToLevel(eIslandLOD.Lod2, trans2);
	}

	private void RenderState_FireSupport(IslandStateModel islandState)
	{
		bool is火力支援Active = islandState.Is火力支援Active;
		if (is火力支援Active && (Object)(object)CompCache.FireSupportTrans == (Object)null)
		{
			Init_FireSupport();
		}
		if (!((Object)(object)CompCache.FireSupportTrans != (Object)null))
		{
			return;
		}
		is火力支援Active = is火力支援Active && !islandState.IsOnTop;
		if (((Component)CompCache.FireSupportTrans).gameObject.activeSelf == is火力支援Active)
		{
			return;
		}
		((Component)CompCache.FireSupportTrans).gameObject.SetActive(is火力支援Active);
		if (is火力支援Active)
		{
			int num = islandState.Event_火力支援.ActivateTimestamp + 3;
			if (islandState.Event_火力支援.ActivateTimestamp != islandState.Last火力支援ActivateTimestamp && num >= (int)GameController.Instance.GetServerTime())
			{
				islandState.Event_火力支援.ActivateTimestamp = islandState.Last火力支援ActivateTimestamp;
				((Component)CompCache.FireSupportTrans.Find("FX")).GetComponent<ParticleSystem>().Play();
			}
		}
	}

	private void Init_HiddenResource()
	{
		IslandComponentCache compCache = CompCache;
		Transform obj = IslandPlane.Find("plane/HiddenResource");
		compCache.HiddenResourceGameObject = ((obj != null) ? ((Component)obj).gameObject : null);
		if ((Object)(object)CompCache.HiddenResourceGameObject == (Object)null)
		{
			throw new Exception($"[IslandController_HiddenResource] HiddenResourceGameObject == null IslandId={IslandId} PrefabName={PrefabName}");
		}
		LODController.AddToLevel(eIslandLOD.Lod1, CompCache.HiddenResourceGameObject.transform.Find("Lod1"));
		LODController.AddToLevel(eIslandLOD.Lod2, CompCache.HiddenResourceGameObject.transform.Find("Lod2"));
	}

	private void RenderState_HiddenResource(IslandStateModel islandState)
	{
		bool isShowHiddenResource = islandState.IsShowHiddenResource;
		if (isShowHiddenResource && (Object)(object)CompCache.HiddenResourceGameObject == (Object)null)
		{
			Init_HiddenResource();
		}
		if ((Object)(object)CompCache.HiddenResourceGameObject != (Object)null)
		{
			isShowHiddenResource = isShowHiddenResource && !islandState.IsOnTop;
			if (CompCache.HiddenResourceGameObject.activeSelf != isShowHiddenResource)
			{
				CompCache.HiddenResourceGameObject.SetActive(isShowHiddenResource);
			}
		}
	}

	public void Init_IslandState()
	{
		CompCache.IslandStateTrans = IslandPlane.Find("plane/IslandState");
		if ((Object)(object)CompCache.IslandStateTrans == (Object)null)
		{
			throw new Exception($"[IslandController_IslandState] IslandStateTrans == null IslandId={IslandId} PrefabName={PrefabName}");
		}
		Transform val = CompCache.IslandStateTrans.Find("Lod1");
		Transform val2 = CompCache.IslandStateTrans.Find("Lod2");
		LODController.AddToLevel(eIslandLOD.Lod1, val);
		LODController.AddToLevel(eIslandLOD.Lod2, val2);
		CompCache.IslandStatePage_Lod1 = new TransPageController<eIslandUIState>(val, eIslandUIState.Peace);
		CompCache.IslandStatePage_Lod2 = new TransPageController<eIslandUIState>(val2, eIslandUIState.Peace);
	}

	private void RenderState_IslandState(IslandStateModel islandState)
	{
		eIslandUIState eIslandUIState = eIslandUIState.Peace;
		UpdateStrategy.RemoveListener(Update_IslandState);
		if (islandState.State == eGvGMode3IslandState.Peace)
		{
			if (GameController.Instance.GetServerRealtimeSeconds() < (double)islandState.ProtectedPeriodTimestamp)
			{
				eIslandUIState = eIslandUIState.ProtectedPeriod;
				UpdateStrategy.AddListener(Update_IslandState);
			}
			else
			{
				eIslandUIState = eIslandUIState.Peace;
			}
		}
		if (islandState.State == eGvGMode3IslandState.Fighting)
		{
			eIslandUIState = eIslandUIState.Fighting;
		}
		else if (islandState.GetNpcStatus() == eGvGMode3IslandNPCStatus.Rebellion)
		{
			eIslandUIState = eIslandUIState.Rebellion;
		}
		else if (islandState.State == eGvGMode3IslandState.Suppress)
		{
			eIslandUIState = eIslandUIState.Suppress;
		}
		if (WorldMapConfigHelper.Configs.IsBrawlEvent() && WorldStateManager.BrawlFinalIslandIds.Contains(islandState.IslandId))
		{
			eIslandUIState = eIslandUIState.Peace;
		}
		bool flag = eIslandUIState != eIslandUIState.Peace;
		flag &= !islandState.HideNameAndState;
		if (flag)
		{
			if ((Object)(object)CompCache.IslandStateTrans == (Object)null)
			{
				Init_IslandState();
			}
			CompCache.IslandStatePage_Lod1.SelectedPage = eIslandUIState;
			CompCache.IslandStatePage_Lod2.SelectedPage = eIslandUIState;
		}
		if ((Object)(object)CompCache.IslandStateTrans != (Object)null)
		{
			flag = flag && !islandState.IsOnTop;
			if (((Component)CompCache.IslandStateTrans).gameObject.activeSelf != flag)
			{
				((Component)CompCache.IslandStateTrans).gameObject.SetActive(flag);
			}
		}
	}

	private void Update_IslandState(IslandStateModel islandState)
	{
		if (GameController.Instance.GetServerRealtimeSeconds() >= (double)islandState.ProtectedPeriodTimestamp)
		{
			CompCache.IslandStatePage_Lod1.SelectedPage = eIslandUIState.Peace;
			CompCache.IslandStatePage_Lod2.SelectedPage = eIslandUIState.Peace;
			UpdateStrategy.RemoveListener(Update_IslandState);
		}
	}

	private void ShowLocationSign(float catchupTime)
	{
		StopLocationSign();
		Transform val = IslandPlane.Find("plane/LocationSign");
		if ((Object)(object)val == (Object)null)
		{
			throw new Exception($"[IslandController_LocationSign] trans == null IslandId={IslandId} PrefabName={PrefabName}");
		}
		((Component)val).gameObject.SetActive(true);
		if (((Component)this).gameObject.activeInHierarchy)
		{
			CompCache.LocationSignCoroutine = ((MonoBehaviour)this).StartCoroutine(PlayLocationAni(catchupTime));
		}
	}

	private void StopLocationSign()
	{
		if (CompCache.LocationSignCoroutine != null)
		{
			((MonoBehaviour)this).StopCoroutine(CompCache.LocationSignCoroutine);
			CompCache.LocationSignCoroutine = null;
		}
	}

	private IEnumerator PlayLocationAni(float catchupTime)
	{
		yield return (object)new WaitForSeconds(2f + catchupTime);
		((Component)IslandPlane.Find("plane/LocationSign")).gameObject.SetActive(false);
		CompCache.LocationSignCoroutine = null;
	}

	private void Init_NamePlate()
	{
		CompCache.NamePlateTrans = IslandPlane.Find("plane/NamePlate");
		if (!((Object)(object)CompCache.NamePlateTrans == (Object)null))
		{
			((Component)CompCache.NamePlateTrans).gameObject.SetActive(true);
			Transform val = CompCache.NamePlateTrans.Find("Lod1");
			Transform val2 = CompCache.NamePlateTrans.Find("Lod2");
			CompCache.NamePlateUserCountTrans = val.Find("UserCount");
			CompCache.NamePlateUserCountText = val.Find("UserCount/Count");
			CompCache.NamePlateUserCountCampPage = new TransPageController<eUserCampId>(CompCache.NamePlateUserCountTrans, (eUserCampId)WorldStateManager.Data.MyCampId);
			((Component)CompCache.NamePlateUserCountTrans).gameObject.SetActive(false);
			CompCache.NamePlateCampPage_Lod1 = new TransPageController<eIslandCampId>(val, eIslandCampId.Camp0);
			CompCache.NamePlateCampPage_Lod2 = new TransPageController<eIslandCampId>(val2, eIslandCampId.Camp0);
			LODController.AddToLevel(eIslandLOD.Lod1, val);
			LODController.AddToLevel(eIslandLOD.Lod2, val2);
			GvGHelper.SetOutlineText(val.Find("Name"), IslandConfig.Name);
			GvGHelper.SetOutlineText(val2.Find("Name"), IslandConfig.Name);
		}
	}

	private void RenderState_NamePlate(IslandStateModel islandState)
	{
		if (!((Object)(object)CompCache.NamePlateTrans == (Object)null))
		{
			eIslandCampId campId = (eIslandCampId)CampId;
			CompCache.NamePlateCampPage_Lod1.SelectedPage = campId;
			CompCache.NamePlateCampPage_Lod2.SelectedPage = campId;
			((Component)CompCache.NamePlateTrans).gameObject.SetActive(!islandState.HideNameAndState);
		}
	}

	private void Init_RandomEvent()
	{
		IslandComponentCache compCache = CompCache;
		Transform obj = IslandPlane.Find("plane/RandomEvent");
		compCache.RandomEventGameObject = ((obj != null) ? ((Component)obj).gameObject : null);
		if ((Object)(object)CompCache.RandomEventGameObject == (Object)null)
		{
			throw new Exception($"[IslandController_RandomEvent] RandomEventGameObject == null IslandId={IslandId} PrefabName={PrefabName}");
		}
		Transform val = CompCache.RandomEventGameObject.transform.Find("Lod1");
		Transform trans = CompCache.RandomEventGameObject.transform.Find("Lod2");
		LODController.AddToLevel(eIslandLOD.Lod1, val);
		LODController.AddToLevel(eIslandLOD.Lod2, trans);
		CompCache.RandomEventRemainingTimeText = ((Component)val.Find("RemainingTime")).GetComponent<TextMesh>();
		CompCache.RandomEventStatePage = new TransPageController<eRandomEventUIState>(val.Find("State"), eRandomEventUIState.Battle);
	}

	private bool Is伟大航路Valid(IslandStateModel islandState)
	{
		return islandState.Event_伟大航路 != null && islandState.Event_伟大航路.StillValid(CurrentTimestamp);
	}

	private bool IsRandomEventValid(IslandStateModel islandState)
	{
		return islandState.RandomEvent != null && islandState.RandomEvent.StillValid(CurrentTimestamp);
	}

	private void RenderState_RandomEvent(IslandStateModel islandState)
	{
		bool flag = Is伟大航路Valid(islandState);
		bool flag2 = IsRandomEventValid(islandState);
		bool flag3 = flag || flag2;
		UpdateStrategy.RemoveListener(Update_伟大航路);
		UpdateStrategy.RemoveListener(Update_RandomEvent);
		if (flag3)
		{
			if ((Object)(object)CompCache.RandomEventGameObject == (Object)null)
			{
				Init_RandomEvent();
			}
			if (flag)
			{
				flag3 = true;
				Update_伟大航路(islandState);
				UpdateStrategy.AddListener(Update_伟大航路);
				CompCache.RandomEventStatePage.SelectedPage = eRandomEventUIState.HiddenIsland;
			}
			else if (flag2)
			{
				flag3 = true;
				if (islandState.RandomEvent.HasTimeLimit())
				{
					Update_RandomEvent(islandState);
					UpdateStrategy.AddListener(Update_RandomEvent);
				}
				else
				{
					CompCache.RandomEventRemainingTimeText.text = string.Empty;
				}
				CompCache.RandomEventStatePage.SelectedPage = islandState.RandomEventSubType;
				RenderEventIcon(islandState.RandomEvent.IconIdx);
				RenderEventFrameIcon(CompCache.RandomEventStatePage.SelectedPage);
			}
		}
		if ((Object)(object)CompCache.RandomEventGameObject != (Object)null)
		{
			flag3 = flag3 && !islandState.IsOnTop;
			if (CompCache.RandomEventGameObject.activeSelf != flag3)
			{
				CompCache.RandomEventGameObject.SetActive(flag3);
			}
		}
	}

	private void RenderEventIcon(int iconIdx)
	{
		string url = $"EventIcon_{iconIdx}".ToPublicResourceIcon();
		CompCache.RandomEventStatePage.SelectedPageTrans.Find("Icon").LoadFguiIcon(url);
	}

	private void RenderEventFrameIcon(eRandomEventUIState uiState)
	{
		if (uiState == eRandomEventUIState.NPCDialog || uiState == eRandomEventUIState.NPCShop)
		{
			SpriteRenderer component = ((Component)CompCache.RandomEventStatePage.SelectedPageTrans.Find("Frame")).GetComponent<SpriteRenderer>();
			if (!((Object)(object)component == (Object)null) && !((Object)(object)component.sprite != (Object)null))
			{
				component.LoadFguiIcon("EventFrame".ToPublicResourceIcon());
			}
		}
	}

	private void Update_伟大航路(IslandStateModel islandState)
	{
		if (!Is伟大航路Valid(islandState))
		{
			CompCache.RandomEventGameObject.SetActive(false);
			UpdateStrategy.RemoveListener(Update_伟大航路);
		}
		else
		{
			CompCache.RandomEventRemainingTimeText.text = UiHelper.ParseTime(islandState.Event_伟大航路.RemainingTime(CurrentTimestamp));
		}
	}

	private void Update_RandomEvent(IslandStateModel islandState)
	{
		if (!IsRandomEventValid(islandState))
		{
			CompCache.RandomEventGameObject.SetActive(false);
			UpdateStrategy.RemoveListener(Update_RandomEvent);
		}
		else
		{
			CompCache.RandomEventRemainingTimeText.text = UiHelper.ParseTime(islandState.RandomEvent.RemainingTime(CurrentTimestamp));
		}
	}

	public void OnSelect()
	{
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		if (!Object.op_Implicit((Object)(object)_outlineGo))
		{
			string text = "Outline/Outline_" + PrefabName + ".prefab";
			Transform val = IslandPlane.Find("plane");
			AsyncOperationHandle<GameObject> val2 = Addressables.LoadAssetAsync<GameObject>((object)text);
			val2.WaitForCompletion();
			_outlineGo = Object.Instantiate<GameObject>(val2.Result, val);
		}
		_outlineGo.SetActive(true);
		if (Object.op_Implicit((Object)(object)_spriteAnim))
		{
			Animation componentInChildren = _outlineGo.GetComponentInChildren<Animation>();
			string name = ((Object)componentInChildren.clip).name;
			AnimationState val3 = componentInChildren[name];
			if (typeof(AnimationState).GetProperty("time") == null)
			{
				componentInChildren.Play(name);
				_spriteAnim.Play(name);
			}
			else
			{
				val3.time = _spriteAnim[name].time;
			}
		}
	}

	public void OnDeselect()
	{
		if ((Object)(object)_outlineGo != (Object)null)
		{
			_outlineGo.SetActive(false);
		}
	}

	public void UnloadOutline()
	{
		if (Object.op_Implicit((Object)(object)_outlineGo))
		{
			Object.Destroy((Object)(object)_outlineGo);
		}
	}

	public void Init_Shield()
	{
		//IL_00a8: Unknown result type (might be due to invalid IL or missing references)
		CompCache.ShieldTrans = IslandPlane.Find("plane/Shield");
		if ((Object)(object)CompCache.ShieldTrans == (Object)null)
		{
			throw new Exception($"[IslandController_Shield] ShieldTrans == null IslandId={IslandId} PrefabName={PrefabName}");
		}
		CompCache.ShieldDamagedFXTrans = CompCache.ShieldTrans.Find("Damaged/FX");
		CompCache.ShieldPointBarTrans = CompCache.ShieldTrans.Find("Damaged/HP/bar");
		CompCache.ShieldPointBarSize = ((Component)CompCache.ShieldPointBarTrans).GetComponent<SpriteRenderer>().size.x;
		CompCache.ShieldPointFxTrans = CompCache.ShieldTrans.Find("Damaged/HP/fx");
		CompCache.ShieldPointCountTrans = CompCache.ShieldTrans.Find("Damaged/HP/Count");
		CompCache.ShieldBrokenTrans = CompCache.ShieldTrans.Find("Broken");
		CompCache.ShieldStatePage = new TransPageController<eIslandShieldState>(CompCache.ShieldTrans, eIslandShieldState.NoShield);
	}

	private void RenderState_Shield(IslandStateModel islandState)
	{
		//IL_0087: Unknown result type (might be due to invalid IL or missing references)
		//IL_008c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0094: Unknown result type (might be due to invalid IL or missing references)
		//IL_0099: Unknown result type (might be due to invalid IL or missing references)
		//IL_009b: Unknown result type (might be due to invalid IL or missing references)
		//IL_009d: Unknown result type (might be due to invalid IL or missing references)
		//IL_009f: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d6: Unknown result type (might be due to invalid IL or missing references)
		bool flag = islandState.ShieldState != eIslandShieldState.NoShield && islandState.ShieldState != eIslandShieldState.Invalid;
		if (flag)
		{
			if ((Object)(object)CompCache.ShieldTrans == (Object)null)
			{
				Init_Shield();
			}
			if (islandState.ShieldState != eIslandShieldState.Damaged)
			{
				CompCache.ShieldStatePage.SelectedPage = islandState.ShieldState;
			}
			if (islandState.ShieldState == eIslandShieldState.Broken)
			{
				Vector3 position = WorldMapConfigHelper.Configs.TryGetIsland(islandState.AttackerIslandId).Position;
				Vector3 localPosition = ((Component)this).transform.localPosition;
				Vector3 val = position - localPosition;
				Quaternion val2 = Quaternion.LookRotation(val, Vector3.up);
				CompCache.ShieldBrokenTrans.localRotation = Quaternion.Euler(0f, 0f, 0f - ((Quaternion)(ref val2)).eulerAngles.y);
			}
		}
		if ((Object)(object)CompCache.ShieldTrans != (Object)null)
		{
			((Component)CompCache.ShieldTrans).gameObject.SetActive(flag);
		}
	}

	private void RenderState_FlagShipAttackEvent(IslandStateModel islandState)
	{
		//IL_00c7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00dc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e1: Unknown result type (might be due to invalid IL or missing references)
		//IL_0107: Unknown result type (might be due to invalid IL or missing references)
		//IL_010c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0111: Unknown result type (might be due to invalid IL or missing references)
		//IL_0114: Unknown result type (might be due to invalid IL or missing references)
		//IL_0119: Unknown result type (might be due to invalid IL or missing references)
		//IL_011b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0120: Unknown result type (might be due to invalid IL or missing references)
		//IL_0122: Unknown result type (might be due to invalid IL or missing references)
		//IL_0127: Unknown result type (might be due to invalid IL or missing references)
		//IL_012f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0134: Unknown result type (might be due to invalid IL or missing references)
		//IL_0136: Unknown result type (might be due to invalid IL or missing references)
		//IL_0138: Unknown result type (might be due to invalid IL or missing references)
		//IL_013a: Unknown result type (might be due to invalid IL or missing references)
		//IL_013f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0141: Unknown result type (might be due to invalid IL or missing references)
		//IL_0143: Unknown result type (might be due to invalid IL or missing references)
		//IL_0148: Unknown result type (might be due to invalid IL or missing references)
		//IL_014d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0166: Unknown result type (might be due to invalid IL or missing references)
		//IL_0171: Unknown result type (might be due to invalid IL or missing references)
		double num = GameController.Instance.GetServerRealtimeSeconds() * 1000.0;
		CompCache.AttackEvent = islandState.AttackEventFromFlagShip;
		CompCache.ShieldPointUpdateStrategy = null;
		if (CompCache.AttackEvent != null && num <= (double)CompCache.AttackEvent.EndTimestamp_ms)
		{
			if ((Object)(object)CompCache.ShieldTrans == (Object)null)
			{
				Init_Shield();
			}
			IslandConfigData islandConfigData = WorldMapConfigHelper.Configs.TryGetIsland(CompCache.AttackEvent.MissileOri);
			Transform transform = GvGWorldMapController.Instance.GetIslandPrefabByIslandId(CompCache.AttackEvent.MissileOri).transform;
			Vector3 val = transform.InverseTransformPoint(transform.Find("plane/FlagShipSign").position) * islandConfigData.Props.S;
			Transform transform2 = GvGWorldMapController.Instance.GetPrefab("FlagShip").transform;
			Vector3 val2 = transform2.InverseTransformPoint(transform2.Find("Shoot/Beam").position);
			Vector3 val3 = islandConfigData.Position + val + val2;
			Vector3 localPosition = ((Component)this).transform.localPosition;
			Vector3 val4 = val3 - localPosition;
			Quaternion val5 = Quaternion.LookRotation(val4, Vector3.up);
			CompCache.ShieldDamagedFXTrans.localRotation = Quaternion.Euler(0f, 0f, 0f - ((Quaternion)(ref val5)).eulerAngles.y);
			((Component)CompCache.ShieldDamagedFXTrans).gameObject.SetActive(true);
			if (CompCache.AttackEvent.MissileType == 0)
			{
				CompCache.ShieldPointUpdateStrategy = UpdateShieldPoint_Laser;
			}
			CompCache.ShieldPointUpdateStrategy();
			CompCache.ShieldStatePage.SelectedPage = eIslandShieldState.Damaged;
		}
		else if ((Object)(object)CompCache.ShieldTrans != (Object)null)
		{
			StopFlagShipAttackEvent();
		}
	}

	private void StopFlagShipAttackEvent()
	{
		CompCache.AttackEvent = null;
		CompCache.ShieldPointUpdateStrategy = null;
		((Component)CompCache.ShieldDamagedFXTrans).gameObject.SetActive(false);
	}

	private void UpdateShieldPoint_Laser()
	{
		//IL_010d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0123: Unknown result type (might be due to invalid IL or missing references)
		//IL_008e: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bc: Unknown result type (might be due to invalid IL or missing references)
		long num = (long)(GameController.Instance.GetServerRealtimeSeconds() * 1000.0);
		long num2 = CompCache.AttackEvent.EndTimestamp_ms - CompCache.AttackEvent.StartTimestamp_ms;
		long num3 = CompCache.AttackEvent.EndTimestamp_ms - num;
		if (num3 > 0)
		{
			float num4 = (float)((double)num3 / (double)num2);
			if (num4 > 1f)
			{
				num4 = 1f;
			}
			CompCache.ShieldPointBarTrans.localScale = new Vector3(num4, 1f, 1f);
			CompCache.ShieldPointFxTrans.localPosition = new Vector3(num4 * CompCache.ShieldPointBarSize, 0f, 0f);
			GvGHelper.SetOutlineText(CompCache.ShieldPointCountTrans, $"{num4 * 100f:F2}%");
		}
		else
		{
			CompCache.ShieldPointBarTrans.localScale = new Vector3(0f, 1f, 1f);
			CompCache.ShieldPointFxTrans.localPosition = Vector3.zero;
			GvGHelper.SetOutlineText(CompCache.ShieldPointCountTrans, $"{0:F2}%");
			StopFlagShipAttackEvent();
		}
	}

	private void OnChangeFlagShipAttackEvent(IslandStateModel islandState)
	{
		RenderState_FlagShipAttackEvent(islandState);
		((Behaviour)this).enabled = true;
	}

	private void Init_TreasureMap()
	{
		IslandComponentCache compCache = CompCache;
		Transform obj = IslandPlane.Find("plane/TreasureMap");
		compCache.TreasureMapGameObject = ((obj != null) ? ((Component)obj).gameObject : null);
		if ((Object)(object)CompCache.TreasureMapGameObject == (Object)null)
		{
			throw new Exception($"[IslandController_TreasureMap] TreasureMapGameObject == null IslandId={IslandId} PrefabName={PrefabName}");
		}
		Transform val = CompCache.TreasureMapGameObject.transform.Find("Lod1");
		Transform trans = CompCache.TreasureMapGameObject.transform.Find("Lod2");
		LODController.AddToLevel(eIslandLOD.Lod1, val);
		LODController.AddToLevel(eIslandLOD.Lod2, trans);
		CompCache.TreasureMapRemainingTimeText = ((Component)val.Find("RemainingTime")).GetComponent<TextMesh>();
		CompCache.TreasureMapStatePage = new TransPageController<eTreasureMapUIState>(val.Find("State"), eTreasureMapUIState.FindIslandBase);
	}

	private bool IsTreasureMapValid(IslandStateModel islandState)
	{
		return islandState.TreasureMapEvent != null && islandState.TreasureMapEvent.StillValid(CurrentTimestamp);
	}

	private void RenderState_TreasureMap(IslandStateModel islandState)
	{
		bool flag = IsTreasureMapValid(islandState);
		UpdateStrategy.RemoveListener(Update_TreasureMap);
		if (flag)
		{
			if ((Object)(object)CompCache.TreasureMapGameObject == (Object)null)
			{
				Init_TreasureMap();
			}
			IIslandEvent treasureMapEvent = islandState.TreasureMapEvent;
			if (islandState.TreasureMapEventSubType == eTreasureMapUIState.Base || !treasureMapEvent.HasTimeLimit())
			{
				CompCache.TreasureMapRemainingTimeText.text = string.Empty;
			}
			else
			{
				Update_TreasureMap(islandState);
				UpdateStrategy.AddListener(Update_TreasureMap);
			}
			CompCache.TreasureMapStatePage.SelectedPage = islandState.TreasureMapEventSubType;
		}
		if ((Object)(object)CompCache.TreasureMapGameObject != (Object)null)
		{
			flag = flag && !islandState.IsOnTop;
			if (CompCache.TreasureMapGameObject.activeSelf != flag)
			{
				CompCache.TreasureMapGameObject.SetActive(flag);
			}
		}
	}

	private void Update_TreasureMap(IslandStateModel islandState)
	{
		if (!IsTreasureMapValid(islandState))
		{
			CompCache.TreasureMapGameObject.SetActive(false);
			UpdateStrategy.RemoveListener(Update_TreasureMap);
		}
		else
		{
			CompCache.TreasureMapRemainingTimeText.text = UiHelper.ParseTime(islandState.TreasureMapEvent.RemainingTime(CurrentTimestamp));
		}
	}
}
