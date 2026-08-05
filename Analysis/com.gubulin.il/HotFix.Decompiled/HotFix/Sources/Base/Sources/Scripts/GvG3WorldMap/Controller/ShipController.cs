using System;
using System.Collections;
using Assets.Scripts.UI;
using DG.Tweening;
using FairyGUI;
using GvG3;
using HotFix.Sources.Base.Scripts.Helper;
using HotFix.Sources.Base.Sources.Scripts.GvG3.GvG3UI.Helper;
using HotFix.Sources.Base.Sources.Scripts.GvG3.GvG3UI.Model.UserProfile;
using HotFix.Sources.Base.Sources.Scripts.GvG3.GvG3WorldMap.Model;
using HotFix.Sources.Base.Sources.Scripts.GvG3Common.Controller;
using HotFix.Sources.Base.Sources.Scripts.GvG3Common.Model;
using HotFix.Sources.Base.Sources.Scripts.GvG3Common.Model.Talent;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Helper;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Manager;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Model;
using HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Helper;
using HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Manager;
using HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Model;
using Shift.Legion.Common.Helpers;
using Shift.Legion.GvG.Common.Models.GvGMode3;
using Spine.Unity;
using UI.GvGShipOverview;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.Rendering;

namespace HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Controller;

public class ShipController : MonoBehaviour
{
	private class FlightTimersWrapper
	{
		private readonly TransPageController<eTimerState> _flightTimer;

		private readonly TransPageController<eTimerState> _flightAutoBattle;

		private readonly string _clickObjName = $"{eTimerState.selected_available}/{eObjectType.btn_shipReturn}";

		private const string NUMBER_TEXT = "number";

		public FlightTimersWrapper(Transform flightTimerRoot, Transform flightAutoBattleRoot)
		{
			_flightTimer = new TransPageController<eTimerState>(flightTimerRoot, eTimerState.normal);
			_flightAutoBattle = new TransPageController<eTimerState>(flightAutoBattleRoot, eTimerState.normal);
		}

		public void AddOnClick(Action<TouchedObject> action)
		{
			((Component)_flightTimer.Find(_clickObjName)).gameObject.AddOnClick(action);
			((Component)_flightAutoBattle.Find(_clickObjName)).gameObject.AddOnClick(action);
		}

		public void RemoveOnClick(Action<TouchedObject> action)
		{
			((Component)_flightTimer.Find(_clickObjName)).gameObject.RemoveOnClick(action);
			((Component)_flightAutoBattle.Find(_clickObjName)).gameObject.RemoveOnClick(action);
		}

		public TransPageController<eTimerState> CurFlightTimer(ShipStateModel shipModel)
		{
			ShipPlanStatusInfo planStatusInfo = shipModel.PlanStatusInfo;
			return (planStatusInfo != null && planStatusInfo.PlanStatus == 3) ? _flightAutoBattle : _flightTimer;
		}

		public void SetTimerActive(ShipStateModel shipModel)
		{
			ShipPlanStatusInfo planStatusInfo = shipModel.PlanStatusInfo;
			bool flag = planStatusInfo != null && planStatusInfo.PlanStatus == 3;
			_flightAutoBattle.GameObject.SetActive(flag);
			_flightTimer.GameObject.SetActive(!flag);
		}

		public void SetText(ShipStateModel shipModel, string countDownText, string countText)
		{
			ShipPlanStatusInfo planStatusInfo = shipModel.PlanStatusInfo;
			bool flag = planStatusInfo != null && planStatusInfo.PlanStatus == 3;
			TransPageController<eTimerState> transPageController = (flag ? _flightAutoBattle : _flightTimer);
			string text = (flag ? countText : countDownText);
			transPageController.SelectedPageGameObject.SetText(text, "number");
		}
	}

	private enum eTimerState
	{
		normal,
		selected_available,
		selected_returning
	}

	private enum eShipLOD
	{
		Lod0,
		Lod1,
		Lod2
	}

	private enum eUIState
	{
		None,
		Docking,
		Flying
	}

	public class FlyingLine
	{
		public float DistFromStartToLineHead;

		public float DistFromStartToLineTail;

		public Vector3 MoveDirection;

		public Vector3 LineStart;
	}

	private eUIState CurUIState;

	public bool IsLoading;

	public int EntityId;

	public string ShipId;

	public int UserId;

	public int CampId;

	private eShipState State;

	private int StayIslandId;

	private float _avatarScale;

	private WorldStateManager WorldStateManager;

	private Transform RootTrans;

	private Transform ShipTrans;

	private GameObject ShipGameObject;

	private Transform WrapperTrans;

	private Transform IconTrans;

	private Transform SlotTrans;

	private GameObject SlotGameObjects;

	private Animation SlotAnimation;

	private SortingGroup SlotSorting;

	private Transform ShipCampAreaTrans;

	private Transform ShipSkinTrans;

	private Transform AvatarTrans;

	private bool IsFlying;

	private static Quaternion IconGlobalRotation = Quaternion.Euler(Vector3.zero);

	private FlightSchedule LastFlightSchedule;

	private Vector3 AvatarPos_LOD1;

	private Vector3 AvatarPos_LOD2;

	private ShipAnimCacheManager ShipAnimCacheManager;

	private LODController<eShipLOD> LODController;

	private bool IsSelfShip;

	private Action OnFlightStart;

	private Action OnFlightEnd;

	private TransPageController<eTimerState> FlightTimerComp;

	private FlightTimersWrapper _flightTimers;

	private bool IsPlayingUndockAnim = false;

	private Coroutine DockAnimCoroutine;

	private bool IsUpdatingFlight;

	private int FlightTargetIslandId;

	private double SyncTimeStamp;

	private float TotalTimeToMove;

	private float TotalTravelDistance;

	private float DistanceLeftToTravel;

	private float SyncDistanceTraveled;

	private FlyingLine CurFlyingLine;

	private FlyingLine[] FlyingLines;

	private static readonly string _shipReturnTips = "GvG3ShipReturnTips".ToLanguage();

	private static readonly string _shipReturnAndInterruptPlan = "GvG3InterruptRepeatedAttackTips".ToLanguage();

	private static 危机感知 _config;

	private Coroutine _viewRangeCountDown;

	private Coroutine _isFocusAnim;

	private GameObject _viewRangeAnim;

	private GameObject _earlyWarningAnim;

	private static int CurUserId => GameController.Contexts.gameState.user.value.UserId;

	private bool IsCurUserShip => UserId == CurUserId;

	public void Load(int entityId)
	{
		IsLoading = true;
		WorldStateManager = Singleton<WorldStateManager>.Instance;
		RenderStaticData(entityId);
		RegisterModel(entityId);
		IsLoading = false;
	}

	public void Reload()
	{
		_isFocusAnim = null;
		StopSelfViewRangeAnim();
		RenderState(WorldStateManager.TryGetShip(EntityId));
	}

	public void Unload()
	{
		RemoveDockPosRecord(StayIslandId);
		UnRegisterModel();
		((MonoBehaviour)this).StopAllCoroutines();
		if (IsSelfShip)
		{
			UnloadSelfViewRange();
		}
		ClearData();
	}

	private void ClearData()
	{
		IsFlying = false;
		LODController.Clear();
		LODController = null;
		LastFlightSchedule = null;
		ShipAnimCacheManager?.ClearCache();
		_flightTimers = null;
		if ((Object)(object)ShipCampAreaTrans != (Object)null && (Object)(object)((Component)ShipCampAreaTrans).gameObject != (Object)null)
		{
			Addressables.ReleaseInstance(((Component)ShipCampAreaTrans).gameObject);
			ShipCampAreaTrans = null;
		}
		Object.Destroy((Object)(object)ShipGameObject);
		Object.Destroy((Object)(object)SlotGameObjects);
	}

	private void Awake()
	{
		RootTrans = ((Component)this).transform.Find("Root");
	}

	public void RegisterModel(int entityId)
	{
		ShipStateModel shipStateModel = WorldStateManager.TryGetShip(entityId);
		RenderState(shipStateModel);
		shipStateModel.OnChange = (Action<ShipStateModel>)Delegate.Combine(shipStateModel.OnChange, new Action<ShipStateModel>(RenderState));
		shipStateModel.OnFogAreaChange = (Action<ShipStateModel>)Delegate.Combine(shipStateModel.OnFogAreaChange, new Action<ShipStateModel>(OnShipFogAreaChange));
		shipStateModel.OnChangeSoulGuideCDTimestamp = (Action<ShipStateModel>)Delegate.Combine(shipStateModel.OnChangeSoulGuideCDTimestamp, new Action<ShipStateModel>(RenderVisibility));
		if (IsSelfShip)
		{
			CameraBindingManager cameraBindingManager = GvGWorldMapController.Instance.CameraBindingManager;
			cameraBindingManager.OnChangeSize = (Action<float>)Delegate.Combine(cameraBindingManager.OnChangeSize, new Action<float>(OnCamSizeChange_MyShipLOD));
			RegisterEvent_MyShipReturn(shipStateModel);
		}
		else
		{
			CameraBindingManager cameraBindingManager2 = GvGWorldMapController.Instance.CameraBindingManager;
			cameraBindingManager2.OnChangeSize = (Action<float>)Delegate.Combine(cameraBindingManager2.OnChangeSize, new Action<float>(OnCamSizeChange_OthersShipLOD));
		}
	}

	public void UnRegisterModel()
	{
		ShipStateModel shipStateModel = WorldStateManager.TryGetShip(EntityId);
		shipStateModel.OnChange = (Action<ShipStateModel>)Delegate.Remove(shipStateModel.OnChange, new Action<ShipStateModel>(RenderState));
		shipStateModel.OnFogAreaChange = (Action<ShipStateModel>)Delegate.Remove(shipStateModel.OnFogAreaChange, new Action<ShipStateModel>(OnShipFogAreaChange));
		shipStateModel.OnChangeSoulGuideCDTimestamp = (Action<ShipStateModel>)Delegate.Remove(shipStateModel.OnChangeSoulGuideCDTimestamp, new Action<ShipStateModel>(RenderVisibility));
		if (shipStateModel.UserId == CurUserId)
		{
			CameraBindingManager cameraBindingManager = GvGWorldMapController.Instance.CameraBindingManager;
			cameraBindingManager.OnChangeSize = (Action<float>)Delegate.Remove(cameraBindingManager.OnChangeSize, new Action<float>(OnCamSizeChange_MyShipLOD));
			UnregisterEvent_MyShipReturn(shipStateModel);
		}
		else
		{
			CameraBindingManager cameraBindingManager2 = GvGWorldMapController.Instance.CameraBindingManager;
			cameraBindingManager2.OnChangeSize = (Action<float>)Delegate.Remove(cameraBindingManager2.OnChangeSize, new Action<float>(OnCamSizeChange_OthersShipLOD));
		}
		((Behaviour)this).enabled = false;
	}

	private void RenderStaticData(int entityId)
	{
		//IL_012f: Unknown result type (might be due to invalid IL or missing references)
		ShipStateModel shipStateModel = WorldStateManager.TryGetShip(entityId);
		EntityId = entityId;
		UserId = shipStateModel.UserId;
		ShipId = shipStateModel.ShipId;
		CampId = shipStateModel.CampId;
		IsSelfShip = shipStateModel.UserId == CurUserId;
		CurUIState = eUIState.None;
		LastFlightSchedule = null;
		((Object)((Component)this).gameObject).name = $"{entityId}";
		LODController = new LODController<eShipLOD>();
		ShipConfigModel byShipRaceType = ShipConfigHelper.GetByShipRaceType((int)shipStateModel.ShipRace);
		string miniPrefabNameByCampId = ShipConfigHelper.GetSkinById(byShipRaceType.DefaultSkinId).GetMiniPrefabNameByCampId(CampId);
		string text = $"Ship1_c{CampId}";
		string name = ((shipStateModel.UserId == CurUserId) ? text : miniPrefabNameByCampId);
		ShipTrans = GvGWorldMapController.Instance.InstantiateFromPrefab(name).transform;
		ShipGameObject = ((Component)ShipTrans).gameObject;
		((Component)ShipTrans).gameObject.SetActive(false);
		ShipTrans.SetParent(RootTrans, false);
		ShipTrans.localPosition = Vector3.zero;
		WrapperTrans = ShipTrans.Find("wrapper");
		IconTrans = ShipTrans.Find("wrapper/icon");
		CampPrefabConfigModel campPrefabConfigModel = WorldMapConfigHelper.TryGetCampPrefabConfig(shipStateModel.CampId);
		SlotTrans = GvGWorldMapController.Instance.InstantiateFromPrefab(campPrefabConfigModel.ShipSlotName).transform;
		SlotGameObjects = ((Component)SlotTrans).gameObject;
		((Component)SlotTrans).gameObject.SetActive(false);
		SlotTrans.SetParent(RootTrans, false);
		LODController.AddToLevel(eShipLOD.Lod0, SlotTrans.Find("Content"));
		LODController.AddToLevel(eShipLOD.Lod1, SlotTrans.Find("Content"));
		SlotAnimation = ((Component)SlotTrans).GetComponent<Animation>();
		SlotSorting = ((Component)SlotTrans).GetComponent<SortingGroup>();
		SpriteRenderer shipPortrait = ((Component)IconTrans.Find("avatar/portrait")).GetComponent<SpriteRenderer>();
		SpriteRenderer slotPortrait = ((Component)SlotTrans.Find("Content/portrait")).GetComponent<SpriteRenderer>();
		shipPortrait.sprite = GvGWorldMapController.Instance.DefaultAvatarSprite;
		slotPortrait.sprite = GvGWorldMapController.Instance.DefaultAvatarSprite;
		if (IsSelfShip)
		{
			RenderMyShipStaticData(shipStateModel);
		}
		else
		{
			RenderOthersShipStaticData(shipStateModel);
		}
		int userId = shipStateModel.UserId;
		GvG3ProfileHelper.GetUserProfile(new GvG3UserProfileRequestOptions($"{Singleton<GvGMode3RoomManager>.Instance.ObserverRecord.CurIZId}", userId, null, delegate(Sprite sprite)
		{
			if (userId == UserId && Object.op_Implicit((Object)(object)shipPortrait))
			{
				shipPortrait.sprite = sprite;
				slotPortrait.sprite = sprite;
			}
		}));
	}

	private void RenderState(ShipStateModel shipState)
	{
		if ((Object)(object)this == (Object)null || !shipState.IsInit)
		{
			return;
		}
		int stayIslandId = StayIslandId;
		bool flag = StayIslandId != shipState.StayIslandId;
		State = shipState.State;
		StayIslandId = shipState.StayIslandId;
		SetShipAvatarScale(shipState.ShipIconScale);
		RenderVisibility(shipState);
		UpdateShipSightRange(shipState);
		_flightTimers?.SetTimerActive(shipState);
		bool useAnim = !IsLoading;
		bool isFlying = IsFlying;
		IsFlying = State == eShipState.DuringFlight && shipState.FlightSchedule != null && shipState.FlightSchedule.Route != null && shipState.FlightSchedule.Route.Length != 0;
		if (!isFlying && IsFlying)
		{
			OnFlightStart?.Invoke();
		}
		else if (isFlying && !IsFlying)
		{
			SharedMessenger.Broadcast("GVG3_ON_REACH_ISLAND", StayIslandId);
			OnFlightEnd?.Invoke();
		}
		if (IsFlying)
		{
			if (CurUIState != eUIState.Flying)
			{
				CurUIState = eUIState.Flying;
				UndockShip(useAnim);
			}
			if (LastFlightSchedule != shipState.FlightSchedule)
			{
				LastFlightSchedule = shipState.FlightSchedule;
				SetFlight(shipState.FlightSchedule);
			}
		}
		else
		{
			if (flag && !isFlying && !IsLoading)
			{
				RemoveDockPosRecord(stayIslandId);
			}
			CurUIState = eUIState.Docking;
			DockShip(useAnim);
		}
		((Behaviour)this).enabled = true;
	}

	private void RenderVisibility(ShipStateModel shipState)
	{
		((Component)RootTrans).gameObject.SetActive(!shipState.IsSoulGuideCoolingDown);
	}

	private void UpdateShipSightRange(ShipStateModel shipState)
	{
		//IL_0061: Unknown result type (might be due to invalid IL or missing references)
		//IL_006c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Unknown result type (might be due to invalid IL or missing references)
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		if (shipState.ShipSightRange > 0f)
		{
			if ((Object)(object)ShipCampAreaTrans == (Object)null)
			{
				ShipCampAreaTrans = Addressables.InstantiateAsync((object)"GvG/ShipFogArea", RootTrans, false, true).WaitForCompletion().transform;
				((Object)ShipCampAreaTrans).name = "ShipFogArea";
			}
			ShipCampAreaTrans.localScale = Vector3.one * shipState.ShipSightRange;
			RenderShipAreaVisible();
			UpdateViewRangeScale(shipState);
		}
	}

	private void OnShipFogAreaChange(ShipStateModel model)
	{
		RenderShipAreaVisible();
	}

	public void RenderShipAreaVisible()
	{
		if (!((Object)(object)ShipCampAreaTrans == (Object)null))
		{
			bool isOurCampIslandVisible = Singleton<WorldStateManager>.Instance.IsOurCampIslandVisible;
			((Component)ShipCampAreaTrans).gameObject.SetActive(isOurCampIslandVisible);
		}
	}

	private void SetShipAvatarScale(float scale)
	{
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_002f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Unknown result type (might be due to invalid IL or missing references)
		_avatarScale = scale;
		SlotTrans.Find("Content").localScale = Vector3.one * scale;
		WrapperTrans.localScale = Vector3.one * scale / 1.4f;
	}

	private void Update()
	{
		if (IsFlying && !IsPlayingUndockAnim)
		{
			double serverRealtimeSeconds = GameController.Instance.GetServerRealtimeSeconds();
			UpdateFlightPos(serverRealtimeSeconds);
		}
		((Behaviour)this).enabled = IsFlying && IsUpdatingFlight;
	}

	private void RenderMyShipStaticData(ShipStateModel shipState)
	{
		//IL_0012: Unknown result type (might be due to invalid IL or missing references)
		//IL_0017: Unknown result type (might be due to invalid IL or missing references)
		//IL_002d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Unknown result type (might be due to invalid IL or missing references)
		AvatarPos_LOD1 = IconTrans.Find("avatar_pos_lod1").localPosition;
		AvatarPos_LOD2 = IconTrans.Find("avatar_pos_lod2").localPosition;
		AvatarTrans = IconTrans.Find("avatar");
		_flightTimers = new FlightTimersWrapper(AvatarTrans.Find("flight_timer"), AvatarTrans.Find("flight_AutoBattle"));
		ShipSkinTrans = IconTrans.Find("spine_lod1");
		LODController.AddToLevel(eShipLOD.Lod0, ((Component)ShipSkinTrans).gameObject);
		LODController.AddToLevel(eShipLOD.Lod1, ((Component)ShipSkinTrans).gameObject);
		LODController.AddToLevel(eShipLOD.Lod2, ((Component)WrapperTrans.Find("arrow_lod2")).gameObject);
		SetShipSpine(shipState);
		OnCamSizeChange_MyShipLOD(GvGWorldMapController.Instance.CameraBindingManager.CamSize);
		InitSelfViewRange();
		RenderMyShipStaticData_MyShipReturn(shipState);
	}

	private void SetShipSpine(ShipStateModel shipState)
	{
		ShipConfigModel byShipRaceType = ShipConfigHelper.GetByShipRaceType((int)shipState.ShipRace);
		ShipAnimCacheManager = new ShipAnimCacheManager();
		ShipAnimCacheManager.GetCache("", byShipRaceType.DefaultSkinId, delegate(SkeletonAnimation animation)
		{
			//IL_0026: Unknown result type (might be due to invalid IL or missing references)
			//IL_0046: Unknown result type (might be due to invalid IL or missing references)
			SpineHelper.SetSkin((ISkeletonAnimation)(object)animation, "skin1");
			((Component)animation).transform.SetParent(ShipSkinTrans, false);
			((Component)animation).transform.localPosition = Vector3.zero;
			((Component)animation).transform.localScale = new Vector3(0.7f, 0.7f, 0.7f);
			animation.AnimationState.SetAnimation(0, "feixing", true);
			MeshRenderer component = ((Component)((Component)animation).transform).GetComponent<MeshRenderer>();
			((Renderer)component).sortingOrder = -3;
		}, isMask: false, isSimpleSpine: true);
	}

	private void RenderOthersShipStaticData(ShipStateModel shipState)
	{
		ShipSkinTrans = IconTrans.Find("sprite_lod1");
		LODController.AddToLevel(eShipLOD.Lod0, ((Component)IconTrans.Find("avatar")).gameObject);
		LODController.AddToLevel(eShipLOD.Lod0, ((Component)ShipSkinTrans).gameObject);
		LODController.AddToLevel(eShipLOD.Lod1, ((Component)ShipSkinTrans).gameObject);
		LODController.AddToLevel(eShipLOD.Lod2, ((Component)IconTrans.Find("sprite_lod2")).gameObject);
		LODController.AddToLevel(eShipLOD.Lod2, ((Component)WrapperTrans.Find("arrow_lod2")).gameObject);
		OnCamSizeChange_OthersShipLOD(GvGWorldMapController.Instance.CameraBindingManager.CamSize);
	}

	private void OnCamSizeChange_MyShipLOD(float camSize)
	{
		//IL_0031: Unknown result type (might be due to invalid IL or missing references)
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		SetShipScale(camSize);
		eShipLOD lODLevel = GetLODLevel(camSize);
		LODController.CurLevel = lODLevel;
		AvatarTrans.localPosition = ((lODLevel == eShipLOD.Lod2) ? AvatarPos_LOD2 : AvatarPos_LOD1);
	}

	private void OnCamSizeChange_OthersShipLOD(float camSize)
	{
		SetShipScale(camSize);
		eShipLOD lODLevel = GetLODLevel(camSize);
		LODController.CurLevel = lODLevel;
	}

	private void SetShipScale(float camSize)
	{
		//IL_0012: Unknown result type (might be due to invalid IL or missing references)
		float num = camSize / 6f;
		ShipTrans.localScale = new Vector3(num, num, num);
	}

	private eShipLOD GetLODLevel(float camSize)
	{
		if (camSize < 6.5f)
		{
			return eShipLOD.Lod0;
		}
		if (camSize < 8.75f)
		{
			return eShipLOD.Lod1;
		}
		return eShipLOD.Lod2;
	}

	private void DockShip(bool useAnim)
	{
		IsPlayingUndockAnim = false;
		if (useAnim)
		{
			if (DockAnimCoroutine != null)
			{
				((MonoBehaviour)this).StopCoroutine(DockAnimCoroutine);
				DockAnimCoroutine = null;
			}
			if (((Component)this).gameObject.activeInHierarchy)
			{
				DockAnimCoroutine = ((MonoBehaviour)this).StartCoroutine(PlayDockAnim());
			}
		}
		else
		{
			SetToDockedState();
		}
	}

	private void UndockShip(bool useAnim)
	{
		IsPlayingUndockAnim = false;
		if (useAnim)
		{
			if (DockAnimCoroutine != null)
			{
				((MonoBehaviour)this).StopCoroutine(DockAnimCoroutine);
				DockAnimCoroutine = null;
			}
			if (((Component)this).gameObject.activeInHierarchy)
			{
				DockAnimCoroutine = ((MonoBehaviour)this).StartCoroutine(PlayUndockAnim());
			}
		}
		else
		{
			SetToUndockedState();
		}
	}

	private void SetToDockedState()
	{
		((Component)ShipTrans).gameObject.SetActive(false);
		if (IsCurUserShip)
		{
			SetPositionToStayIsland();
			((Component)SlotTrans).gameObject.SetActive(true);
			SlotAnimation.Play("slot_show");
			SetSlotToNormalSortingOrder();
		}
		else
		{
			((Component)SlotTrans).gameObject.SetActive(false);
		}
	}

	private void SetToUndockedState()
	{
		((Component)SlotTrans).gameObject.SetActive(false);
		((Component)ShipTrans).gameObject.SetActive(true);
		PlayShipAnim(isShow: true);
		RemoveDockPosRecord(StayIslandId);
	}

	private IEnumerator PlayDockAnim()
	{
		PlayShipAnim(isShow: false);
		yield return (object)new WaitForSeconds(0.3f);
		((Component)ShipTrans).gameObject.SetActive(false);
		if (IsCurUserShip)
		{
			SetPositionToStayIsland();
			SetSlotToTopSortingOrder();
			((Component)SlotTrans).gameObject.SetActive(true);
			SlotAnimation.Play("slot_show");
			yield return (object)new WaitForSeconds(1.3f);
			SetSlotToNormalSortingOrder();
		}
		else
		{
			((Component)SlotTrans).gameObject.SetActive(false);
			SharedMessenger.Broadcast("GVG3_UNLOAD_SHIP_CONTROLLER", EntityId);
		}
		DockAnimCoroutine = null;
	}

	private IEnumerator PlayUndockAnim()
	{
		IsPlayingUndockAnim = true;
		if (IsCurUserShip)
		{
			SetSlotToTopSortingOrder();
			SlotAnimation.Play("slot_hide");
			yield return (object)new WaitForSeconds(0.3f);
			((Component)SlotTrans).gameObject.SetActive(false);
		}
		else
		{
			((Component)SlotTrans).gameObject.SetActive(false);
		}
		RemoveDockPosRecord(StayIslandId);
		((Component)ShipTrans).gameObject.SetActive(true);
		PlayShipAnim(isShow: true);
		DockAnimCoroutine = null;
		IsPlayingUndockAnim = false;
	}

	private void RemoveDockPosRecord(int stayIslandId)
	{
		(WorldStateManager.TryGetIsland(stayIslandId)?.ShipDockInRecord)?.ClearShipDockInRecord(EntityId, CampId);
	}

	private void SetPositionToStayIsland()
	{
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_0065: Unknown result type (might be due to invalid IL or missing references)
		IslandShipDockInRecord islandShipDockInRecord = WorldStateManager.TryGetIsland(StayIslandId)?.ShipDockInRecord;
		if (islandShipDockInRecord != null)
		{
			((Component)this).transform.localPosition = islandShipDockInRecord.IslandPos;
			Vec3 dockInSlotPos = GetDockInSlotPos(islandShipDockInRecord);
			if (dockInSlotPos != null)
			{
				SlotTrans.localPosition = new Vector3(dockInSlotPos.x, dockInSlotPos.y, dockInSlotPos.z);
			}
		}
	}

	private Vec3 GetDockInSlotPos(IslandShipDockInRecord shipDockInRecord)
	{
		ShipStateModel shipStateModel = WorldStateManager.TryGetShip(EntityId);
		shipStateModel.ShipDockInRecord.UpdateRecord(StayIslandId);
		Vec3 result;
		if (shipStateModel.ShipDockInRecord.SlotIndex >= 0)
		{
			result = shipDockInRecord.GetShipDockInLastSlotPos(EntityId, CampId, shipStateModel.ShipDockInRecord.SlotIndex);
		}
		else
		{
			result = shipDockInRecord.GetShipDockInNewSlotPos(EntityId, CampId, out var posIndex);
			shipStateModel.ShipDockInRecord.SetSlotIndex(posIndex);
		}
		return result;
	}

	private void SetSlotToNormalSortingOrder()
	{
		SlotSorting.sortingOrder = (IsCurUserShip ? 52 : 50);
	}

	private void SetSlotToTopSortingOrder()
	{
		SlotSorting.sortingOrder = (IsCurUserShip ? 52 : 51);
	}

	private void PlayShipAnim(bool isShow)
	{
		float num = (isShow ? (_avatarScale / 1.4f) : 0f);
		TweenSettingsExtensions.SetEase<Tweener>(ShortcutExtensions.DOScale(WrapperTrans, num, 0.07f), (Ease)9);
	}

	private void SetFlight(FlightSchedule flight)
	{
		SetFlight(flight.TimeStamp, flight.EndTime, (float)flight.DistanceTraveled / 1000f, flight.Route);
	}

	public void SetFlight(int syncTimeStamp, int syncEndTime, float syncDistanceTraveled, int[] route)
	{
		//IL_008c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0091: Unknown result type (might be due to invalid IL or missing references)
		//IL_0099: Unknown result type (might be due to invalid IL or missing references)
		//IL_009e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0134: Unknown result type (might be due to invalid IL or missing references)
		TotalTimeToMove = syncEndTime - syncTimeStamp;
		if (TotalTimeToMove <= 0f)
		{
			return;
		}
		if (route == null || route.Length == 0)
		{
			ILRuntimeDebug.LogError("[ShipController] SetFlight 中传入了无效飞空艇");
			return;
		}
		IsUpdatingFlight = true;
		FlyingLines = new FlyingLine[route.Length - 1];
		float num = 0f;
		for (int i = 0; i < FlyingLines.Length; i++)
		{
			NavLineConfigData navLineConfigData = WorldMapConfigHelper.Configs.TryGetNavLine(route[i], route[i + 1]);
			FlyingLine flyingLine = new FlyingLine
			{
				MoveDirection = navLineConfigData.Dir,
				LineStart = navLineConfigData.Start,
				DistFromStartToLineHead = num,
				DistFromStartToLineTail = num + navLineConfigData.Props.Len
			};
			FlyingLines[i] = flyingLine;
			num = flyingLine.DistFromStartToLineTail;
		}
		FlightTargetIslandId = route[^1];
		SyncTimeStamp = syncTimeStamp;
		TotalTravelDistance = num;
		DistanceLeftToTravel = TotalTravelDistance - syncDistanceTraveled;
		SyncDistanceTraveled = syncDistanceTraveled;
		CurFlyingLine = FindCurrentFlyingLine(SyncDistanceTraveled);
		OnChangeDirection(CurFlyingLine.MoveDirection);
		if (syncDistanceTraveled < 2f)
		{
			SharedMessenger.Broadcast("GVG3_ON_DEPART_ISLAND", route[0]);
		}
	}

	public void UpdateFlightPos(double serverRealtime)
	{
		//IL_00da: Unknown result type (might be due to invalid IL or missing references)
		//IL_018e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0193: Unknown result type (might be due to invalid IL or missing references)
		//IL_019e: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_0118: Unknown result type (might be due to invalid IL or missing references)
		//IL_011d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0128: Unknown result type (might be due to invalid IL or missing references)
		//IL_012d: Unknown result type (might be due to invalid IL or missing references)
		if (!IsUpdatingFlight)
		{
			return;
		}
		float usedTime = (float)(serverRealtime - SyncTimeStamp);
		if (usedTime < 0f)
		{
			return;
		}
		if (_flightTimers != null)
		{
			ShipStateModel shipStateModel = WorldStateManager.TryGetShip(EntityId);
			string countDownText = GetTimeLeft();
			string countText = GetPlanAttackCount(shipStateModel);
			_flightTimers.SetText(shipStateModel, countDownText, countText);
		}
		float num = usedTime / TotalTimeToMove;
		float num2 = num * DistanceLeftToTravel;
		float num3 = SyncDistanceTraveled + num2;
		if (num3 > CurFlyingLine.DistFromStartToLineTail)
		{
			CurFlyingLine = FindCurrentFlyingLine(num3);
			OnChangeDirection(CurFlyingLine.MoveDirection);
			if (num3 >= TotalTravelDistance)
			{
				IsUpdatingFlight = false;
				((Component)this).transform.localPosition = (num3 - CurFlyingLine.DistFromStartToLineHead) * CurFlyingLine.MoveDirection + CurFlyingLine.LineStart;
				OnReachTarget(FlightTargetIslandId);
				return;
			}
		}
		if (!((Component)ShipTrans).gameObject.activeInHierarchy)
		{
			((Component)ShipTrans).gameObject.SetActive(true);
		}
		((Component)this).transform.localPosition = (num3 - CurFlyingLine.DistFromStartToLineHead) * CurFlyingLine.MoveDirection + CurFlyingLine.LineStart;
		static string GetPlanAttackCount(ShipStateModel shipState)
		{
			ShipPlanStatusInfo planStatusInfo = shipState.PlanStatusInfo;
			return $"{((planStatusInfo != null) ? new int?(planStatusInfo.AttackedCount + 1) : ((int?)null))}/{shipState.PlanStatusInfo?.PlanAttackCount}";
		}
		string GetTimeLeft()
		{
			float num4 = TotalTimeToMove - usedTime;
			if (num4 < 0f)
			{
				num4 = 0f;
			}
			return UiHelper.ParseTime((int)num4);
		}
	}

	private FlyingLine FindCurrentFlyingLine(float distanceTraveled)
	{
		FlyingLine[] flyingLines = FlyingLines;
		foreach (FlyingLine flyingLine in flyingLines)
		{
			if (distanceTraveled <= flyingLine.DistFromStartToLineTail)
			{
				return flyingLine;
			}
		}
		return FlyingLines[FlyingLines.Length - 1];
	}

	private void OnReachTarget(int stayIslandId)
	{
		ShipStateModel shipStateModel = WorldStateManager.TryGetShip(EntityId);
		shipStateModel.SyncStayIsland(eShipState.Stay, stayIslandId);
		SharedMessenger.Broadcast("GVG3_ON_REACH_ISLAND", stayIslandId);
	}

	private void OnChangeDirection(Vector3 dir)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_002f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_0090: Unknown result type (might be due to invalid IL or missing references)
		//IL_006e: Unknown result type (might be due to invalid IL or missing references)
		ShipTrans.localRotation = Quaternion.LookRotation(dir, Vector3.up);
		IconTrans.rotation = IconGlobalRotation;
		Quaternion localRotation = ShipTrans.localRotation;
		float y = ((Quaternion)(ref localRotation)).eulerAngles.y;
		if (y > 0f && y < 180f)
		{
			ShipSkinTrans.localScale = new Vector3(-1f, 1f, 1f);
		}
		else
		{
			ShipSkinTrans.localScale = new Vector3(1f, 1f, 1f);
		}
	}

	private void RenderMyShipStaticData_MyShipReturn(ShipStateModel shipState)
	{
		Update_MyShipReturn(shipState);
	}

	private void RegisterEvent_MyShipReturn(ShipStateModel shipState)
	{
		shipState.OnChangeMyShipSelected = (Action<ShipStateModel>)Delegate.Combine(shipState.OnChangeMyShipSelected, new Action<ShipStateModel>(Update_MyShipReturn));
		shipState.OnChangeFlightSchedule = (Action<ShipStateModel>)Delegate.Combine(shipState.OnChangeFlightSchedule, new Action<ShipStateModel>(Update_MyShipReturn));
		_flightTimers.AddOnClick(OnClickShipReturn);
	}

	private void UnregisterEvent_MyShipReturn(ShipStateModel shipState)
	{
		shipState.OnChangeMyShipSelected = (Action<ShipStateModel>)Delegate.Remove(shipState.OnChangeMyShipSelected, new Action<ShipStateModel>(Update_MyShipReturn));
		shipState.OnChangeFlightSchedule = (Action<ShipStateModel>)Delegate.Remove(shipState.OnChangeFlightSchedule, new Action<ShipStateModel>(Update_MyShipReturn));
		_flightTimers.RemoveOnClick(OnClickShipReturn);
	}

	private void OnClickShipReturn(TouchedObject btn)
	{
		GvGWorldMapController.Instance.InputManager.StopPropagation();
		string myShipName = Singleton<GvGMode3RoomManager>.Instance.ObserverRecord.GetMyShipName(ShipId);
		ShipStateModel target = WorldStateManager.TryGetShip(EntityId);
		ShipPlanStatusInfo planStatusInfo = target.PlanStatusInfo;
		string richText = ((planStatusInfo != null && planStatusInfo.PlanStatus == 3) ? _shipReturnAndInterruptPlan : _shipReturnTips);
		HotFix.Sources.Base.Scripts.Helper.StringExtensions.Format(richText, myShipName).ToConfirmPopup(delegate
		{
			if (target == null)
			{
				ILRuntimeDebug.LogError($"[ShipController] OnClickShipReturn EntityId={EntityId} shipStateModel不存在！");
			}
			else if (target.ReturningCDTimestamp > (int)GameController.Instance.GetServerTime())
			{
				"GvG3ShipReturnFailTips".ToShowLanguageTip();
			}
			else
			{
				WorldStateManager.ShipReturnToLastIsland(EntityId, delegate
				{
					"GvG3ShipReturnSuccessTips".ToShowLanguageTip();
				});
			}
		}, null, (AlignType)0);
	}

	private void Update_MyShipReturn(ShipStateModel shipState)
	{
		bool flag = State == eShipState.DuringFlight && shipState.FlightSchedule?.Route != null && shipState.FlightSchedule.Route.Length != 0;
		TransPageController<eTimerState> transPageController = _flightTimers.CurFlightTimer(WorldStateManager.TryGetShip(EntityId));
		if (flag)
		{
			transPageController.SelectedPage = (shipState.FlightSchedule.IsReturning ? eTimerState.selected_returning : (shipState.IsMyShipSelected ? eTimerState.selected_available : eTimerState.normal));
		}
	}

	public void InitSelfViewRange()
	{
		SharedMessenger.AddListener<int>("GVG3_TALENT_ACTIVATED", OnTalentsChange);
		OnFlightStart = (Action)Delegate.Combine(OnFlightStart, new Action(OnFlightChange));
		OnFlightEnd = (Action)Delegate.Combine(OnFlightEnd, new Action(OnFlightChange));
		EnsureInitAnimPrefab();
		RestartViewRangeCountDown();
	}

	private void UnloadSelfViewRange()
	{
		SharedMessenger.RemoveListener<int>("GVG3_TALENT_ACTIVATED", OnTalentsChange);
		OnFlightStart = (Action)Delegate.Remove(OnFlightStart, new Action(OnFlightChange));
		OnFlightEnd = (Action)Delegate.Remove(OnFlightEnd, new Action(OnFlightChange));
		if (Object.op_Implicit((Object)(object)_viewRangeAnim))
		{
			Object.Destroy((Object)(object)_viewRangeAnim);
		}
		if (Object.op_Implicit((Object)(object)_earlyWarningAnim))
		{
			Object.Destroy((Object)(object)_earlyWarningAnim);
		}
	}

	public void OnClickFocus()
	{
		if (_isFocusAnim == null && ((Component)this).gameObject.activeInHierarchy)
		{
			_isFocusAnim = ((MonoBehaviour)this).StartCoroutine(ShowFocusAnim());
		}
		IEnumerator ShowFocusAnim()
		{
			yield return (object)new WaitForSeconds(1f);
			ShowSelfViewRangeAnim();
			RestartViewRangeCountDown();
			_isFocusAnim = null;
		}
	}

	private void OnTalentsChange(int idx)
	{
		if (idx == 428)
		{
			EnsureInitAnimPrefab();
		}
	}

	private void OnFlightChange()
	{
		ShowSelfViewRangeAnim();
		RestartViewRangeCountDown();
	}

	private void EnsureInitAnimPrefab()
	{
		//IL_0021: Unknown result type (might be due to invalid IL or missing references)
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Unknown result type (might be due to invalid IL or missing references)
		//IL_008a: Unknown result type (might be due to invalid IL or missing references)
		//IL_008f: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a9: Unknown result type (might be due to invalid IL or missing references)
		if (!Object.op_Implicit((Object)(object)_viewRangeAnim))
		{
			_viewRangeAnim = Addressables.InstantiateAsync((object)"ViewRangeAnim", RootTrans, false, true).WaitForCompletion();
			_viewRangeAnim.transform.localPosition = Vector3.zero;
		}
		if (WorldStateManager.Data.Talents.HasTalent(eTalent.危机感知))
		{
			if (!Object.op_Implicit((Object)(object)_earlyWarningAnim))
			{
				_earlyWarningAnim = Addressables.InstantiateAsync((object)"EarlyWarningRangeAnim", RootTrans, false, true).WaitForCompletion();
				_viewRangeAnim.transform.localPosition = Vector3.zero;
			}
			if (_config == null)
			{
				_config = TalentEvent.GetConfig<危机感知>();
			}
		}
		UpdateViewRangeScale(WorldStateManager.TryGetShip(EntityId));
	}

	private void UpdateViewRangeScale(ShipStateModel shipState)
	{
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0061: Unknown result type (might be due to invalid IL or missing references)
		//IL_0066: Unknown result type (might be due to invalid IL or missing references)
		if ((Object)(object)_viewRangeAnim != (Object)null)
		{
			_viewRangeAnim.transform.localScale = Vector3.one * shipState.ShipSightRange;
		}
		if ((Object)(object)_earlyWarningAnim != (Object)null)
		{
			_earlyWarningAnim.transform.localScale = shipState.ShipSightRange * _config.ShipSightRatio * Vector3.one;
		}
	}

	private void ShowSelfViewRangeAnim()
	{
		if (!UI_GvGShipOverviewPanel.GetViewRangeLocalConfig())
		{
			return;
		}
		if (Object.op_Implicit((Object)(object)_viewRangeAnim))
		{
			if (!_viewRangeAnim.activeSelf)
			{
				_viewRangeAnim.SetActive(true);
			}
			_viewRangeAnim.GetComponentInChildren<Animation>().Play();
		}
		if (Object.op_Implicit((Object)(object)_earlyWarningAnim))
		{
			if (!_earlyWarningAnim.activeSelf)
			{
				_earlyWarningAnim.SetActive(true);
			}
			_earlyWarningAnim.GetComponentInChildren<Animation>().Play();
		}
	}

	private void StopSelfViewRangeAnim()
	{
		if (Object.op_Implicit((Object)(object)_viewRangeAnim))
		{
			_viewRangeAnim.SetActive(false);
		}
		if (Object.op_Implicit((Object)(object)_earlyWarningAnim))
		{
			_earlyWarningAnim.SetActive(false);
		}
	}

	private void RestartViewRangeCountDown()
	{
		if (_viewRangeCountDown != null)
		{
			((MonoBehaviour)this).StopCoroutine(_viewRangeCountDown);
		}
		if (((Component)this).gameObject.activeInHierarchy)
		{
			_viewRangeCountDown = ((MonoBehaviour)this).StartCoroutine(ShowViewRangeCountDown());
		}
		IEnumerator ShowViewRangeCountDown()
		{
			while (true)
			{
				yield return (object)new WaitForSeconds(60f);
				ShowSelfViewRangeAnim();
			}
		}
	}
}
