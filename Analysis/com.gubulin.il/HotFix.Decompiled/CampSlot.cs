using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using DG.Tweening;
using FairyGUI;
using Shift.Legion.Common.Enums;
using Shift.Legion.Common.Helpers;
using Shift.Legion.Common.Managers;
using Shift.Legion.Common.Models;
using Shift.Legion.Common.Sources.Enums;
using UI.PublicResources;
using UnityEngine;

public class CampSlot : PortalSoldier
{
	public enum CampSlotState
	{
		Lock,
		Idle,
		Running,
		StockFull,
		ResourceLack,
		Constructing,
		Ready
	}

	private UI_com_CampSlotNew _slotUi;

	private GameObject _runningSfx;

	private GameObject _idleSfx;

	private GameObject _runeMissile;

	private CampSlotState _slotState;

	private string _soldierId;

	private int _slotIndex;

	private Dictionary<string, float> _soldierWeapons;

	private Coroutine _coroutineUiCountDown;

	private bool _producingIsOver;

	private int _produceIndex;

	public CampController Controller;

	private Transition EquipmentListDisappear => ((GComponent)_slotUi).GetTransition("EquipmentListDisappear");

	private GProgressBar ProgressBar => ((GComponent)_slotUi).GetChild("ProgressBar").asProgress;

	private Controller Status => ((GComponent)_slotUi).GetController("Status");

	private GList EquipmentList => ((GComponent)_slotUi).GetChild("EquipmentList").asList;

	public int ProduceIndex => _produceIndex;

	public override string SoldierId => _soldierId;

	public override Dictionary<string, float> SoldierWeapons => _soldierWeapons;

	public CampSlotState SlotState => _slotState;

	private void Awake()
	{
		SlotUiInit();
		_runningSfx = ((Component)((Component)this).transform.Find("ui_camp_slot_lv6_running")).gameObject;
		_idleSfx = ((Component)((Component)this).transform.Find("ui_camp_slot_lv6_idle")).gameObject;
		_slotIndex = int.Parse(((Object)((Component)((Component)this).transform).gameObject).name.Replace("CampSlotNew", ""));
		_produceIndex = _slotIndex - 1;
		_slotState = CampSlotState.Lock;
		UpdateSlotState();
	}

	private void Start()
	{
		SharedMessenger.AddListener<string, int, (StockInContext, string)>("ON_STOCK_CHANGE", UpdateUiOnSoldierNumChange);
		SharedMessenger.AddListener<int>("CAMP_SLOT_UNLOCK", UpdateSlotOnUnlock);
		SharedMessenger.AddListener<string, int>("BUILDING_UPGRADED", UpdateSlotStateOnRepair);
		SharedMessenger.AddListener<string, BuildingConstructingConfig>("BUILDING_START_UPGRADING", SetSlotUiOnConstructing);
		SharedMessenger.AddListener<string>("BUILDING_CONSTRUCTING_COMPLETE", SetSlotUiOnConstructComplete);
		LoadSoldierInCamp();
	}

	private void OnDestroy()
	{
		((MonoBehaviour)this).StopAllCoroutines();
		SharedMessenger.RemoveListener<string, int, (StockInContext, string)>("ON_STOCK_CHANGE", UpdateUiOnSoldierNumChange);
		SharedMessenger.RemoveListener<int>("CAMP_SLOT_UNLOCK", UpdateSlotOnUnlock);
		SharedMessenger.RemoveListener<string, int>("BUILDING_UPGRADED", UpdateSlotStateOnRepair);
		SharedMessenger.RemoveListener<string, BuildingConstructingConfig>("BUILDING_START_UPGRADING", SetSlotUiOnConstructing);
		SharedMessenger.RemoveListener<string>("BUILDING_CONSTRUCTING_COMPLETE", SetSlotUiOnConstructComplete);
	}

	private bool CheckResourceLack()
	{
		if (_soldierWeapons == null || _soldierWeapons.Count <= 0)
		{
			return true;
		}
		StockController stockController = GameManagers.Instance.StockController;
		foreach (KeyValuePair<string, float> soldierWeapon in _soldierWeapons)
		{
			if ((float)stockController.GetStock(soldierWeapon.Key) < soldierWeapon.Value)
			{
				return true;
			}
		}
		return false;
	}

	private bool CheckSlotIsLock()
	{
		if (Controller == null)
		{
			return true;
		}
		return Controller.Camp.Slot < _slotIndex;
	}

	private bool CheckStockFull()
	{
		if (string.IsNullOrEmpty(SoldierId))
		{
			return false;
		}
		int stock = GameManagers.Instance.StockController.GetStock(SoldierId);
		int limit = GameManagers.Instance.StockController.GetLimit(SoldierId);
		return stock >= limit;
	}

	private bool CheckSlotConstructing(out CampSlotState slotState)
	{
		slotState = _slotState;
		if (Controller.Camp == null)
		{
			return false;
		}
		if (Controller.Camp.Status == BuildingStatus.Running)
		{
			return false;
		}
		int num = Controller.Camp.SomeLevelSlot(Controller.Camp.NextLevel);
		if (num % 5 != _slotIndex % 5)
		{
			return false;
		}
		if (num == _slotIndex)
		{
			return false;
		}
		slotState = CampSlotState.Constructing;
		return true;
	}

	private bool CheckSlotReady(out CampSlotState slotState)
	{
		slotState = _slotState;
		if (Controller.Camp == null)
		{
			return false;
		}
		if (Controller.Camp.Status == BuildingStatus.Running)
		{
			return false;
		}
		int num = Controller.Camp.SomeLevelSlot(Controller.Camp.NextLevel);
		if (num != _slotIndex)
		{
			return false;
		}
		if (Controller.Camp.Status == BuildingStatus.Ready)
		{
			slotState = CampSlotState.Ready;
		}
		return true;
	}

	public override void LoadSoldierInCamp(bool clear = false)
	{
		UpdateSlotData();
		UpdateSlotState();
	}

	public override void Show_ProducingCountDown(int end_tm, float build_tm)
	{
		_slotState = CampSlotState.Running;
		if (CheckSlotConstructing(out var slotState))
		{
			_slotState = slotState;
		}
		if (CheckSlotReady(out var slotState2))
		{
			_slotState = slotState2;
		}
		UpdateSlotState();
	}

	public override void Show_LackResource()
	{
		_slotState = CampSlotState.ResourceLack;
		if (CheckSlotConstructing(out var slotState))
		{
			_slotState = slotState;
		}
		if (CheckSlotReady(out var slotState2))
		{
			_slotState = slotState2;
		}
		UpdateSlotState();
	}

	public override void Show_StockFull()
	{
		_slotState = CampSlotState.StockFull;
		if (CheckSlotConstructing(out var slotState))
		{
			_slotState = slotState;
		}
		if (CheckSlotReady(out var slotState2))
		{
			_slotState = slotState2;
		}
		UpdateSlotState();
	}

	public override void CheckIsStockFull()
	{
	}

	private void UpdateSlotStateOnRepair(string buildingType, int level)
	{
		if (!(buildingType != Controller.Camp.BuildingType))
		{
			int num = Controller.Camp.SomeLevelSlot(level);
			if (num % 5 == _slotIndex % 5)
			{
				LoadSoldierInCamp();
			}
		}
	}

	private void SetSlotUiOnConstructing(string buildingType, BuildingConstructingConfig info)
	{
		if (!(buildingType != Controller.Camp.BuildingType))
		{
			int num = Controller.Camp.SomeLevelSlot(Controller.Camp.NextLevel);
			if (num % 5 == _slotIndex % 5)
			{
				LoadSoldierInCamp();
				UpdateSlotState();
			}
		}
	}

	private void SetSlotUiOnConstructComplete(string buildingType)
	{
		//IL_008a: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_0109: Unknown result type (might be due to invalid IL or missing references)
		if (buildingType != Controller.Camp.BuildingType)
		{
			return;
		}
		int num = Controller.Camp.SomeLevelSlot(Controller.Camp.NextLevel);
		if (num % 5 != _slotIndex % 5)
		{
			return;
		}
		LoadSoldierInCamp();
		UpdateSlotState();
		if (num == _slotIndex)
		{
			GameObject val = SpawnManager.Instance.InstantiatePool("workplaceSmoke_2", Vector3.zero);
			if ((Object)(object)val != (Object)null)
			{
				val.transform.eulerAngles = Controller.GetSlotGameObject(num - 1).transform.eulerAngles;
				val.transform.position = Controller.GetSlotPosForLevelUp(num - 1);
				val.AddComponent<HotFix_DestroySelf>().destroyTime = 1f;
				val.transform.localScale = new Vector3(1f, 1f, 1f);
			}
		}
	}

	private void UpdateSlotOnUnlock(int slotIndex)
	{
		if (_slotIndex == slotIndex)
		{
			LoadSoldierInCamp();
		}
	}

	private void UpdateUiOnSoldierNumChange(string itemId, int incr, (StockInContext, string) context)
	{
		if (!(itemId != _soldierId))
		{
			switch (GameManagers.Instance.RecruitingCampDataManager.IsNowProducing[ProduceIndex])
			{
			case 0:
				LoadSoldierInCamp(clear: true);
				break;
			case 1:
				Show_ProducingCountDown(0, 0f);
				break;
			case 2:
				Show_StockFull();
				break;
			case 3:
				Show_LackResource();
				break;
			}
		}
	}

	private void SlotUiInit()
	{
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		UIPanel val = ((Component)((Component)this).transform.Find("CmapSlotUi")).gameObject.AddComponent<UIPanel>();
		val.packageName = "PublicResources";
		val.componentName = "com_CampSlotNew";
		val.container.renderMode = (RenderMode)2;
		val.SetSortingOrder(4, true);
		val.CreateUI();
		_slotUi = (UI_com_CampSlotNew)(object)val.ui;
	}

	private void Producing(long end_tm, float build_tm)
	{
		long num = end_tm - GameController.Instance.GetServerTime();
		if (EquipmentListDisappear.playing)
		{
			EquipmentListDisappear.Stop();
		}
		bool showAni = num >= 2;
		_coroutineUiCountDown = ((MonoBehaviour)this).StartCoroutine(UICountDown(end_tm, build_tm, showAni));
	}

	private IEnumerator UICountDown(long end_tm, float build_tm, bool showAni)
	{
		PlayCampSlotCastAnimationBefore();
		yield return (object)new WaitForSeconds(0.9f);
		if (showAni)
		{
			EquipmentListDisappear.Play();
			yield return (object)new WaitForSeconds(0.4f);
		}
		else
		{
			EquipmentListDisappear.Play();
			EquipmentListDisappear.Stop(true, true);
		}
		long lfet_tm = end_tm - GameController.Instance.GetServerTime();
		ChangeProduceTweener(lfet_tm, build_tm);
		do
		{
			if (lfet_tm < 0)
			{
				lfet_tm = GameManagers.Instance.RecruitingCampDataManager.ProducingEndTime[PortalNum] - GameController.Instance.GetServerTime();
			}
			if (lfet_tm < 0)
			{
				ChangeProduceTweener((long)build_tm, build_tm);
				((GObject)ProgressBar).alpha = 0f;
				break;
			}
			ChangeProduceTweener(lfet_tm, build_tm);
			yield return (object)new WaitForSeconds(0.1f);
			lfet_tm = end_tm - GameController.Instance.GetServerTime();
		}
		while (lfet_tm >= 0);
	}

	public async void PlayCampSlotCastAnimationBefore()
	{
		if (!Object.op_Implicit((Object)(object)_runeMissile) || !_runeMissile.activeSelf)
		{
			if ((Object)(object)_runeMissile == (Object)null)
			{
				_runeMissile = await AddressableHelper.Instance.InstantiateAsync("FX/Prefabs/rune_missile");
				_runeMissile.transform.parent = Controller.Camp.GameObject.transform;
			}
			_runeMissile.GetComponent<ParticleSystem>().Play();
			_runeMissile.transform.localPosition = Controller.Camp.GameObject.transform.Find("summon_stone").localPosition;
			_runeMissile.SetActive(true);
			UiAudioManager.Instance.LoadSoundsForSfx(_runeMissile, "Missile", playLoop: false, 0.1f, limitForScene: true);
			((Tween)ShortcutExtensions.DOLocalMove(_runeMissile.transform, ((Component)this).transform.localPosition, 0.6f, false)).onComplete = (TweenCallback)async delegate
			{
				await Task.Delay(1200);
				_runeMissile.SetActive(false);
			};
		}
	}

	private void ChangeProduceTweener(long lfet_tm, float total_tm)
	{
		ProgressBar.value = 100f * (1f - (float)lfet_tm / total_tm);
	}

	private void UpdateSlotData()
	{
		if (CheckSlotReady(out var slotState))
		{
			_slotState = slotState;
			return;
		}
		if (CheckSlotIsLock())
		{
			_slotState = CampSlotState.Lock;
			return;
		}
		_soldierId = GameManagers.Instance.RecruitingCampDataManager.ProducingQueue[ProduceIndex];
		if (_soldierId.ToLower() == "unlock" || _soldierId.ToLower() == "lock")
		{
			_soldierId = string.Empty;
		}
		if (string.IsNullOrEmpty(_soldierId))
		{
			_slotState = CampSlotState.Idle;
			return;
		}
		if (CheckSlotConstructing(out var slotState2))
		{
			_slotState = slotState2;
			return;
		}
		if (CheckStockFull())
		{
			_slotState = CampSlotState.StockFull;
			return;
		}
		_soldierWeapons = Singleton<SoldierProductManager>.Instance.GetSoldierProductRequirements(_soldierId);
		RenderWeaponsList();
		if (CheckResourceLack())
		{
			_slotState = CampSlotState.ResourceLack;
		}
		else
		{
			_slotState = CampSlotState.Running;
		}
	}

	private void RenderWeaponsList()
	{
		if (_soldierWeapons == null || _soldierWeapons.Count <= 0)
		{
			return;
		}
		EquipmentList.RemoveChildrenToPool();
		foreach (KeyValuePair<string, float> soldierWeapon in _soldierWeapons)
		{
			GComponent asCom = EquipmentList.AddItemFromPool().asCom;
			if (asCom != null)
			{
				RenderWeapon(asCom, soldierWeapon.Key);
			}
		}
	}

	private void RenderWeapon(GComponent btn, string itemId)
	{
		btn.GetChild("frame").asLoader.url = string.Empty;
		FGUIManager.Instance.SetItemIconAndFrame(btn.GetChild("icon").asLoader, itemId);
	}

	private void UpdateSlotState()
	{
		((MonoBehaviour)this).StopAllCoroutines();
		switch (_slotState)
		{
		case CampSlotState.Ready:
			((GObject)_slotUi).visible = false;
			_runningSfx.SetActive(false);
			_idleSfx.SetActive(true);
			return;
		case CampSlotState.Lock:
			((GObject)_slotUi).visible = false;
			_runningSfx.SetActive(false);
			_idleSfx.SetActive(false);
			return;
		case CampSlotState.Idle:
			((GObject)_slotUi).visible = false;
			_runningSfx.SetActive(false);
			_idleSfx.SetActive(true);
			return;
		}
		((GObject)_slotUi).visible = true;
		_runningSfx.SetActive(true);
		_idleSfx.SetActive(false);
		switch (_slotState)
		{
		case CampSlotState.Constructing:
			Status.selectedIndex = 3;
			break;
		case CampSlotState.Running:
		{
			Status.selectedIndex = 0;
			((GObject)ProgressBar).alpha = 0f;
			long end_tm = GameManagers.Instance.RecruitingCampDataManager.ProducingEndTime[ProduceIndex];
			float build_tm = GameManagers.Instance.RecruitingCampDataManager.ProductTime[ProduceIndex];
			Producing(end_tm, build_tm);
			break;
		}
		case CampSlotState.StockFull:
			Status.selectedIndex = 1;
			break;
		case CampSlotState.ResourceLack:
			Status.selectedIndex = 2;
			break;
		}
	}
}
