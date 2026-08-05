using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using FairyGUI;
using GameDataEditor;
using Shift.Legion.Common.Enums;
using Shift.Legion.Common.Helpers;
using Shift.Legion.Common.Managers;
using Shift.Legion.Common.Models;
using Shift.Legion.Common.Sources.Enums;
using Spine.Unity;
using UnityEngine;

public class PortalSoldier : MonoBehaviour
{
	public Transform[] PortalToStartPath1;

	public int PortalNum;

	private List<GDESoldierData> _campSoldierDatas;

	private bool _canPlayCastAnimationBefore;

	private string _soldierId;

	private Dictionary<string, float> _soldierWeapons;

	private Config<StockConfig> _stockData;

	private float _x;

	private List<GameObject> _soldierList = new List<GameObject>();

	private bool _stockIsFull;

	public GComponent ui;

	private bool _endOfOffline;

	private bool producing_is_over = true;

	private List<string> _textureList = new List<string>();

	private HashSet<string> _spineSet = new HashSet<string>();

	public string waitMaterial;

	public GameObject soldierOnProducing;

	public GameObject soldierOnDouble;

	public GameObject soldierUnable;

	public bool WaitStartProduct;

	public GameObject runeMissile;

	public GameObject campSlotFinish;

	public GameObject NoticeGameObject;

	private GameObject _productDoubleObject;

	public GTweener producingProgressTweener;

	public Tweener runeMissileMove;

	public Coroutine ShowEquipment;

	public Coroutine PlayEquipmentDisappear;

	public Transition EquipmentDisappear;

	public GTweener ShowProgressBar;

	public Coroutine ProgressBarAppear;

	public Coroutine ProductComplete;

	private int prev_status = 0;

	private Coroutine _Coroutine_UICountDown;

	private bool _producing => GameManagers.Instance.RecruitingCampDataManager.IsProducing(PortalNum);

	public virtual string SoldierId => _soldierId;

	public virtual Dictionary<string, float> SoldierWeapons => _soldierWeapons;

	private float _remainingSetupTime => GameManagers.Instance.RecruitingCampDataManager.GetRemainingTime(PortalNum);

	private float _setupTime => GameManagers.Instance.RecruitingCampDataManager.GetSetupTime(PortalNum);

	private void Awake()
	{
		_soldierList = new List<GameObject>();
		_textureList = new List<string>();
		_spineSet = new HashSet<string>();
		_campSoldierDatas = new List<GDESoldierData>();
		_canPlayCastAnimationBefore = true;
		_soldierWeapons = new Dictionary<string, float>();
		prev_status = 0;
	}

	private void Start()
	{
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		producing_is_over = true;
		_stockIsFull = false;
		WaitStartProduct = false;
		_x = ((Component)this).transform.position.x;
		ui = ((Component)((Component)this).transform.parent.Find("CmapSlotUi")).GetComponent<UIPanel>().ui;
		LoadSoldierInCamp();
		SharedMessenger.AddListener<string, int, (StockInContext, string)>("ON_STOCK_CHANGE", UpdateUiOnSoldierNumChange);
		SharedMessenger.AddListener<string, int, (StockInContext, string)>("ON_STOCK_CHANGE", UpdateUiOnWeaponNumChange);
		GameManagers.Instance.RecruitingCampDataManager.InitWhenUIReady();
		CheckIsStockFull();
	}

	public virtual void CheckIsStockFull()
	{
		int stock = GameManagers.Instance.StockController.GetStock(_soldierId);
		int limit = GameManagers.Instance.StockController.GetLimit(_soldierId);
		if (stock >= limit)
		{
			Show_StockFull();
		}
	}

	public virtual void Show_StockFull()
	{
		((MonoBehaviour)this).StopAllCoroutines();
		producing_is_over = true;
		UI_HideProgressBar();
		StartProduce();
		int limit = GameManagers.Instance.StockController.GetLimit(_soldierId);
		if (_stockData != null && _stockData.GetValue().Stock >= limit)
		{
			ui.GetChild("EquipmentList").alpha = 0f;
			ui.GetChild("ProgressBar").alpha = 0f;
			ui.GetChild("max").alpha = 1f;
			((Component)((Component)this).transform.parent.Find("MagicCircleBlue/TreasureChestGlowRays")).gameObject.SetActive(false);
		}
	}

	public virtual void Show_LackResource()
	{
		((MonoBehaviour)this).StopAllCoroutines();
		producing_is_over = true;
		UI_HideProgressBar();
		List<bool> soldierIsNotReadyResult = GetSoldierIsNotReadyResult();
		FGUIManager.Instance.SetCampSlotEquipList(this, ui, _soldierId, _soldierWeapons, _textureList, soldierIsNotReadyResult, out waitMaterial);
		Hide_DarkSoldier();
		UI_Show_Equipment();
	}

	public virtual void Show_ProducingCountDown(int end_tm, float build_tm)
	{
		_stockData = GameManagers.Instance.StockController.GetStockConfig(_soldierId);
		if (_stockData != null && _stockData.GetValue().Stock >= GameManagers.Instance.StockController.GetLimit(StockCategory.Soldier))
		{
			_stockIsFull = true;
		}
		else
		{
			_stockIsFull = false;
		}
		List<bool> result = new List<bool> { true };
		FGUIManager.Instance.SetCampSlotEquipList(this, ui, _soldierId, _soldierWeapons, _textureList, result, out waitMaterial);
		if (!((Component)this).gameObject.activeInHierarchy)
		{
		}
		((MonoBehaviour)this).StartCoroutine(CheckingProducingOver(end_tm, build_tm));
	}

	public void OnServersideStockChange()
	{
		if (!string.IsNullOrWhiteSpace(_soldierId))
		{
			_endOfOffline = true;
		}
	}

	public IEnumerator UpdateSlotStatusForOffLine()
	{
		yield return (object)new WaitForFixedUpdate();
		_stockData = GameManagers.Instance.StockController.GetStockConfig(_soldierId);
		if (_stockData != null && _stockData.GetValue().Stock >= GameManagers.Instance.StockController.GetLimit(StockCategory.Soldier))
		{
			_stockIsFull = true;
		}
		else
		{
			_stockIsFull = false;
		}
		List<bool> result = GetSoldierIsNotReadyResult(reset: true);
		if (_stockIsFull || result.Contains(item: false))
		{
			RefreshSlotOnServersideStockChange();
		}
	}

	public virtual void LoadSoldierInCamp(bool clear = false)
	{
		_campSoldierDatas.Clear();
		for (int i = 0; i < 5; i++)
		{
			string text = GameManagers.Instance.RecruitingCampDataManager.ProducingQueue[i];
			if (text.ToLower() == "unlock" || text.ToLower() == "lock")
			{
				text = string.Empty;
			}
			if (string.IsNullOrEmpty(text))
			{
				_campSoldierDatas.Add(null);
			}
			else
			{
				_campSoldierDatas.Add(GDMgr.Get<GDESoldierData>(text));
			}
		}
		string text2 = _campSoldierDatas[PortalNum]?.Key ?? string.Empty;
		if (_soldierId != text2 && clear)
		{
			ClearAllOperations();
		}
		if (!string.IsNullOrEmpty(text2))
		{
			if (_soldierId != text2)
			{
				_stockData = GameManagers.Instance.StockController.GetStockConfig(text2);
				ui.GetChild("EquipmentList").alpha = 0f;
				ui.GetChild("ProgressBar").alpha = 0f;
				ui.GetChild("max").alpha = 0f;
				List<bool> soldierIsNotReadyResult = GetSoldierIsNotReadyResult();
				FGUIManager.Instance.SetCampSlotEquipList(this, ui, text2, _soldierWeapons, _textureList, soldierIsNotReadyResult, out waitMaterial);
				_stockIsFull = _stockData != null && _stockData.GetValue().Stock >= GameManagers.Instance.StockController.GetLimit(StockCategory.Soldier);
				if (!_stockIsFull)
				{
					FGUIManager.Instance.PlayCampSlotCastAnimationBefore(((Component)((Component)this).transform.parent).gameObject, ui, _stockIsFull);
				}
			}
		}
		else
		{
			_stockData = null;
			ui.GetChild("EquipmentList").alpha = 0f;
			ui.GetChild("ProgressBar").alpha = 0f;
			ui.GetChild("max").alpha = 0f;
			((Component)((Component)((Component)this).transform.parent).gameObject.transform.Find("MagicCircleBlue/TreasureChestGlowRays")).gameObject.SetActive(false);
		}
		if (_soldierId != text2)
		{
			_canPlayCastAnimationBefore = true;
			WaitStartProduct = false;
		}
		_soldierId = text2;
		if (!string.IsNullOrEmpty(_soldierId))
		{
			((GObject)ui).data = GameManagers.Instance.StockController.GetStock(_soldierId);
			_soldierWeapons = Singleton<SoldierProductManager>.Instance.GetSoldierProductRequirements(_soldierId);
		}
		else
		{
			_soldierWeapons.Clear();
		}
	}

	private void UI_Show_Equipment()
	{
		((Component)((Component)this).transform.parent.Find("MagicCircleBlue/TreasureChestGlowRays")).gameObject.SetActive(true);
		ui.GetChild("EquipmentList").SetScale(0.7f, 0.7f);
		ui.GetChild("EquipmentList").SetXY(-173f, 116f);
		if (!_stockIsFull)
		{
			ui.GetChild("EquipmentList").alpha = 1f;
			return;
		}
		ui.GetChild("EquipmentList").TweenFade(1f, 0.7f);
		ui.GetChild("max").alpha = 1f;
	}

	private IEnumerator CheckingProducingOver(int end_tm, float build_tm)
	{
		if (GameController.Instance.GetServerTime() < end_tm)
		{
			while (!producing_is_over)
			{
				yield return (object)new WaitForEndOfFrame();
			}
		}
		_Coroutine_UICountDown = ((MonoBehaviour)this).StartCoroutine(UICountDown(end_tm, build_tm));
	}

	private IEnumerator UICountDown(int end_tm, float build_tm)
	{
		producing_is_over = false;
		Hide_DarkSoldier();
		yield return (object)new WaitForSeconds(0.9f);
		UI_Show_Equipment();
		yield return (object)new WaitForSeconds(0.7f);
		UI_PlayEquipmentDisappear();
		yield return (object)new WaitForSeconds(0.5f);
		UI_Hide_Equipment();
		StartProduce();
		Dictionary<int, int> dic_endtm = GameManagers.Instance.RecruitingCampDataManager.ProducingEndTime;
		int endtm = dic_endtm[PortalNum];
		long lfet_tm = endtm - GameController.Instance.GetServerTime();
		ChangeProduceTweener(lfet_tm, build_tm);
		UI_ShowProgressBar();
		do
		{
			if (lfet_tm < 0)
			{
				lfet_tm = GameManagers.Instance.RecruitingCampDataManager.ProducingEndTime[PortalNum] - GameController.Instance.GetServerTime();
			}
			if (lfet_tm < 0)
			{
				ChangeProduceTweener((long)build_tm, build_tm);
				break;
			}
			ChangeProduceTweener(lfet_tm, build_tm);
			yield return (object)new WaitForSeconds(0.3f);
			lfet_tm = endtm - GameController.Instance.GetServerTime();
		}
		while (lfet_tm >= 0);
		UI_HideProgressBar();
		yield return (object)new WaitForSeconds(0.5f);
		yield return UI_ProductComplete();
		int index = GameManagers.Instance.UserArchiveManager.GetSoldierPotentialLevel(_soldierId);
		int potentialLevel = (index + 2) / 2;
		soldierOnProducing = GetSoldier();
		SpawnManager.Instance.LoadSoldierSpine(soldierOnProducing, $"{_soldierId}_skin{potentialLevel}").Then((Action<SkeletonDataAsset>)delegate(SkeletonDataAsset asset)
		{
			Hide_DarkSoldier();
			CampSlotSoldierAnimation component = soldierOnProducing.GetComponent<CampSlotSoldierAnimation>();
			component.InitAnimation(asset, _soldierId, _x);
			component.SetSoldierAnimationInfoOnProducting(0f, PortalToStartPath1, null);
			StartToBattle();
			GameManagers.Instance.RecruitingCampDataManager.TryMakeOneRecruiting_WhenFinish(PortalNum);
			producing_is_over = true;
		});
	}

	private void Hide_DarkSoldier()
	{
		if ((Object)(object)soldierUnable != (Object)null)
		{
			soldierUnable.SetActive(false);
		}
	}

	private void UI_Hide_Equipment()
	{
		ui.GetChild("EquipmentList").alpha = 0f;
	}

	private void UI_PlayEquipmentDisappear()
	{
		EquipmentDisappear = ui.GetTransition("EquipmentListDisappear");
		EquipmentDisappear.Play();
	}

	private void UI_ShowProgressBar()
	{
		GProgressBar asProgress = ui.GetChild("ProgressBar").asProgress;
		ShowProgressBar = ((GObject)asProgress).TweenFade(1f, 0.33f);
	}

	private void UI_HideProgressBar()
	{
		GProgressBar asProgress = ui.GetChild("ProgressBar").asProgress;
		((GObject)asProgress).alpha = 0f;
	}

	private IEnumerator UI_ProductComplete()
	{
		ui.GetChild("EquipmentList").alpha = 0f;
		((Component)((Component)this).transform.parent.Find("MagicCircleBlue/TreasureChestGlowRays")).gameObject.SetActive(false);
		yield return SpawnManager.Instance.InstantiatePoolCoroutine("camp_slot_finish", Vector3.one * 20000f, delegate(GameObject go)
		{
			campSlotFinish = go;
		});
		campSlotFinish.AddComponent<HotFix_DestroySelf>().destroyTime = 1f;
		UiAudioManager.Instance.LoadSoundsForSfx(campSlotFinish, "BlastForPack", playLoop: false, 1f, limitForScene: true);
		campSlotFinish.GetComponent<Renderer>().sortingLayerName = "Default";
		campSlotFinish.transform.parent = ((Component)this).transform.parent;
		campSlotFinish.transform.localPosition = new Vector3(0f, 0.05f, 0.5f);
		campSlotFinish.transform.localEulerAngles = new Vector3(-55f, 0f, 0f);
	}

	private void OnDestroy()
	{
		((MonoBehaviour)this).StopAllCoroutines();
		SharedMessenger.RemoveListener<string, int, (StockInContext, string)>("ON_STOCK_CHANGE", UpdateUiOnSoldierNumChange);
	}

	private void StartProduce()
	{
		if (!(_soldierId == ""))
		{
			_canPlayCastAnimationBefore = true;
			WaitStartProduct = false;
			ui.GetChild("EquipmentList").alpha = 0f;
			ui.GetChild("max").alpha = 0f;
			int soldierPotentialLevel = GameManagers.Instance.UserArchiveManager.GetSoldierPotentialLevel(_soldierId);
			int num = (soldierPotentialLevel + 2) / 2;
			if ((Object)(object)soldierUnable == (Object)null)
			{
				soldierUnable = GetSoldier();
			}
			SpawnManager.Instance.LoadSoldierSpine(soldierUnable, $"{_soldierId}_skin{num}").Then((Action<SkeletonDataAsset>)delegate(SkeletonDataAsset asset)
			{
				CreatSoldierOnWaitProductWithDelay(asset);
			});
			SetCampSlotProgressTime();
		}
	}

	private void SetCampSlotProgressTime()
	{
		GProgressBar asProgress = ui.GetChild("ProgressBar").asProgress;
		TextFormat textFormat = ((GComponent)asProgress).GetChild("time").asTextField.textFormat;
		textFormat.size = 35;
		((GComponent)asProgress).GetChild("time").asTextField.textFormat = textFormat;
		asProgress.value = 0.0;
	}

	private void CreatSoldierOnDoubleWithDelay(SkeletonDataAsset asset)
	{
		CampSlotSoldierAnimation component = soldierOnDouble.GetComponent<CampSlotSoldierAnimation>();
		component.InitAnimation(asset, _soldierId, _x);
		component.SetSoldierAnimationInfoOnDouble(0.3f, PortalToStartPath1, null);
	}

	private void CreatSoldierOnWaitProductWithDelay(SkeletonDataAsset asset)
	{
		soldierUnable.SetActive(true);
		CampSlotSoldierAnimation component = soldierUnable.GetComponent<CampSlotSoldierAnimation>();
		component.InitAnimation(asset, _soldierId, _x);
		component.SetSoldierAnimationInfoOnWaitProduct();
		if (!string.IsNullOrWhiteSpace(waitMaterial))
		{
			soldierUnable.SetActive(false);
		}
	}

	private void StartToBattle()
	{
		if (_canPlayCastAnimationBefore && !string.IsNullOrWhiteSpace(_soldierId) && (_soldierId != "Lock" || _soldierId != "Unlock"))
		{
			LoadSoldierInCamp();
			ui.GetChild("EquipmentList").alpha = 0f;
			ui.GetChild("ProgressBar").alpha = 0f;
			ui.GetChild("max").alpha = 0f;
			List<bool> soldierIsNotReadyResult = GetSoldierIsNotReadyResult();
			FGUIManager.Instance.SetCampSlotEquipList(this, ui, _soldierId, _soldierWeapons, _textureList, soldierIsNotReadyResult, out waitMaterial);
			_stockIsFull = _stockData != null && _stockData.GetValue().Stock >= GameManagers.Instance.StockController.GetLimit(StockCategory.Soldier);
			FGUIManager.Instance.PlayCampSlotCastAnimationBefore(((Component)((Component)this).transform.parent).gameObject, ui, _stockIsFull);
		}
	}

	private void UpdateUiOnSoldierNumChange(string itemId, int incr, (StockInContext, string) context)
	{
		if (!producing_is_over || itemId != _soldierId)
		{
			return;
		}
		int num = GameManagers.Instance.RecruitingCampDataManager.IsNowProducing[PortalNum];
		switch (num)
		{
		case 0:
			LoadSoldierInCamp(clear: true);
			return;
		case 1:
		{
			LoadSoldierInCamp();
			int end_tm = GameManagers.Instance.RecruitingCampDataManager.ProducingEndTime[PortalNum];
			float build_tm = GameManagers.Instance.RecruitingCampDataManager.ProductTime[PortalNum];
			Show_ProducingCountDown(end_tm, build_tm);
			return;
		}
		case 2:
			if (prev_status != num)
			{
				prev_status = num;
				Show_StockFull();
				return;
			}
			break;
		}
		if (num == 3 && prev_status != num)
		{
			prev_status = num;
			Show_LackResource();
		}
	}

	private void UpdateUiOnWeaponNumChange(string itemId, int incr, (StockInContext, string) context)
	{
		if (producing_is_over && _soldierWeapons.ContainsKey(itemId))
		{
			int num = GameManagers.Instance.RecruitingCampDataManager.IsNowProducing[PortalNum];
			if (num != 3)
			{
			}
		}
	}

	private IEnumerator PlayProductDoubleSfx()
	{
		yield return (object)new WaitForFixedUpdate();
		if ((Object)(object)_productDoubleObject != (Object)null)
		{
			Object.Destroy((Object)(object)_productDoubleObject);
		}
		GameObject campSlotFinish2 = null;
		yield return SpawnManager.Instance.InstantiatePoolCoroutine("camp_slot_finish", Vector3.one * 20000f, delegate(GameObject go)
		{
			campSlotFinish2 = go;
		});
		campSlotFinish2.AddComponent<HotFix_DestroySelf>().destroyTime = 2f;
		UiAudioManager.Instance.LoadSoundsForSfx(campSlotFinish2, "BlastForPack", playLoop: false, 1f, limitForScene: true);
		_productDoubleObject = campSlotFinish2;
		campSlotFinish2.transform.parent = ((Component)this).transform.parent.Find("NotiseSfx");
		campSlotFinish2.transform.localPosition = new Vector3(0f, -0.95f, 0f);
		campSlotFinish2.transform.localEulerAngles = new Vector3(-55f, 0f, 0f);
		int index = GameManagers.Instance.UserArchiveManager.GetSoldierPotentialLevel(_soldierId);
		int potentialLevel = (index + 2) / 2;
		soldierOnDouble = GetSoldier();
		SpawnManager.Instance.LoadSoldierSpine(soldierOnDouble, $"{_soldierId}_skin{potentialLevel}").Then((Action<SkeletonDataAsset>)delegate(SkeletonDataAsset asset)
		{
			CreatSoldierOnDoubleWithDelay(asset);
		});
	}

	private void ClearAllOperations()
	{
		if (ProductComplete != null)
		{
			((MonoBehaviour)FGUIManager.Instance).StopCoroutine(ProductComplete);
		}
		if (ProgressBarAppear != null)
		{
			((MonoBehaviour)FGUIManager.Instance).StopCoroutine(ProgressBarAppear);
		}
		if (ShowProgressBar != null)
		{
			ShowProgressBar.Kill(false);
		}
		if (EquipmentDisappear != null && EquipmentDisappear.playing)
		{
			EquipmentDisappear.Stop();
		}
		if (PlayEquipmentDisappear != null)
		{
			((MonoBehaviour)FGUIManager.Instance).StopCoroutine(PlayEquipmentDisappear);
		}
		if (ShowEquipment != null)
		{
			((MonoBehaviour)FGUIManager.Instance).StopCoroutine(ShowEquipment);
		}
		if (runeMissileMove != null)
		{
			TweenExtensions.Kill((Tween)(object)runeMissileMove, false);
		}
		if (producingProgressTweener != null)
		{
			producingProgressTweener.Kill(false);
		}
		if ((Object)(object)runeMissile != (Object)null)
		{
			Object.Destroy((Object)(object)runeMissile);
		}
		if ((Object)(object)campSlotFinish != (Object)null)
		{
			Object.Destroy((Object)(object)campSlotFinish);
		}
		if ((Object)(object)NoticeGameObject != (Object)null)
		{
			Object.Destroy((Object)(object)NoticeGameObject);
		}
		if ((Object)(object)_productDoubleObject != (Object)null)
		{
			Object.Destroy((Object)(object)_productDoubleObject);
		}
		if ((Object)(object)soldierOnProducing != (Object)null)
		{
			Object.Destroy((Object)(object)soldierOnProducing);
			soldierOnProducing = null;
		}
		if ((Object)(object)soldierOnDouble != (Object)null)
		{
			Object.Destroy((Object)(object)soldierOnDouble);
			soldierOnDouble = null;
		}
		Hide_DarkSoldier();
	}

	private void RefreshSlotOnServersideStockChange()
	{
		_campSoldierDatas.Clear();
		for (int i = 0; i < 5; i++)
		{
			string text = GameManagers.Instance.RecruitingCampDataManager.ProducingQueue[i];
			if (text.ToLower() == "unlock" || text.ToLower() == "lock")
			{
				text = string.Empty;
			}
			if (string.IsNullOrEmpty(text))
			{
				_campSoldierDatas.Add(null);
			}
			else
			{
				_campSoldierDatas.Add(GDMgr.Get<GDESoldierData>(text));
			}
		}
		string key = _campSoldierDatas[PortalNum].Key;
		ClearAllOperations();
		if (!string.IsNullOrEmpty(key))
		{
			_stockData = GameManagers.Instance.StockController.GetStockConfig(key);
			ui.GetChild("EquipmentList").alpha = 0f;
			ui.GetChild("ProgressBar").alpha = 0f;
			ui.GetChild("max").alpha = 0f;
			List<bool> soldierIsNotReadyResult = GetSoldierIsNotReadyResult(reset: true);
			FGUIManager.Instance.SetCampSlotEquipList(this, ui, key, _soldierWeapons, _textureList, soldierIsNotReadyResult, out waitMaterial);
			_stockIsFull = _stockData != null && _stockData.GetValue().Stock >= GameManagers.Instance.StockController.GetLimit(StockCategory.Soldier);
			if (!_stockIsFull)
			{
				FGUIManager.Instance.PlayCampSlotCastAnimationBefore(((Component)((Component)this).transform.parent).gameObject, ui, _stockIsFull);
			}
		}
		else
		{
			_stockData = null;
			ui.GetChild("EquipmentList").alpha = 0f;
			ui.GetChild("ProgressBar").alpha = 0f;
			ui.GetChild("max").alpha = 0f;
			((Component)((Component)((Component)this).transform.parent).gameObject.transform.Find("MagicCircleBlue/TreasureChestGlowRays")).gameObject.SetActive(false);
		}
		_canPlayCastAnimationBefore = true;
		WaitStartProduct = false;
		_soldierId = key;
		if (!string.IsNullOrEmpty(_soldierId))
		{
			((GObject)ui).data = GameManagers.Instance.StockController.GetStock(_soldierId);
			_soldierWeapons = Singleton<SoldierProductManager>.Instance.GetSoldierProductRequirements(_soldierId);
		}
		else
		{
			_soldierWeapons.Clear();
		}
	}

	private List<bool> GetSoldierIsNotReadyResult(bool reset = false)
	{
		List<bool> list = new List<bool>();
		StockController stockController = GameManagers.Instance.StockController;
		foreach (KeyValuePair<string, float> soldierWeapon in _soldierWeapons)
		{
			list.Add((float)stockController.GetStock(soldierWeapon.Key) >= soldierWeapon.Value);
		}
		if (_producing && _remainingSetupTime > 0.0333333f && !reset)
		{
			for (int i = 0; i < list.Count; i++)
			{
				list[i] = true;
			}
		}
		return list;
	}

	private GameObject GetSoldier()
	{
		//IL_003a: Unknown result type (might be due to invalid IL or missing references)
		GameObject val = Object.Instantiate<GameObject>(Resources.Load<GameObject>("CampSlotSoldier"), ((Component)this).transform.parent);
		val.AddComponent<CampSlotSoldierAnimation>();
		val.transform.localPosition = new Vector3(-0.06f, 0f, 0f);
		val.SetActive(false);
		return val;
	}

	private void ChangeProduceTweener(long lfet_tm, float total_tm)
	{
		GProgressBar asProgress = ui.GetChild("ProgressBar").asProgress;
		asProgress.value = 100f * (1f - (float)lfet_tm / total_tm);
		((GComponent)asProgress).GetChild("time").text = $"{Convert.ToInt32(lfet_tm)}S";
	}
}
