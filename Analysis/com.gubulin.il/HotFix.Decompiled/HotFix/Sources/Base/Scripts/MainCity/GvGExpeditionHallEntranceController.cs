using System;
using System.Collections;
using System.Collections.Generic;
using FairyGUI;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Helper;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Manager;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Model;
using Shift.Legion.ClientApi.Models;
using Shift.Legion.Common.Enums;
using Shift.Legion.Common.Managers;
using Shift.Legion.Common.Models;
using Shift.Legion.GvG.Common.Models.GvGMode3;
using Spine.Unity;
using UI;
using UI.GvGExpeditionHall;
using UI.MainCity;
using UnityEngine;

namespace HotFix.Sources.Base.Scripts.MainCity;

public class GvGExpeditionHallEntranceController : MonoBehaviour
{
	private enum eShipDisplayState
	{
		none = 0,
		state_idle = 1,
		state_building = 4,
		state_finished = 5,
		state_waiting = 3,
		state_flying = 2
	}

	private GameObject Background;

	private GameObject BackgroundDisabled;

	private GameObject Decoration;

	private GameObject Mask;

	private GameObject TranslucentMask;

	private GameObject Builders;

	private GameObject FrontWall;

	private GameObject SliderObj;

	private Transform ShipContainer;

	public Building building;

	private ShipAnimCacheManager ShipAnimCacheManager;

	private List<string> buildingSprite;

	private Dictionary<eShipDisplayState, GameObject> ShipUIPages;

	private eShipDisplayState _ShipState;

	private GvGMode3ShipModel LastBuildingShip;

	private GvGMode3ShipModel FirstPendingAcceptanceShip;

	private GvGMode3ShipModel FirstNotLaunchedShip;

	private GvGMode3ShipModel FirstLaunchedShip;

	private SkeletonAnimation ShipAnim;

	private SpriteRenderer Slider;

	private float MaxSliderWidth;

	private eShipDisplayState CurShipState
	{
		get
		{
			return _ShipState;
		}
		set
		{
			if (_ShipState != value)
			{
				if (_ShipState != eShipDisplayState.none)
				{
					ShipUIPages[_ShipState].SetActive(false);
				}
				_ShipState = value;
				if (_ShipState != eShipDisplayState.none)
				{
					ShipUIPages[_ShipState].SetActive(true);
				}
			}
		}
	}

	private void Start()
	{
		//IL_0048: Unknown result type (might be due to invalid IL or missing references)
		if (Version159GvG3BuildingLoad())
		{
			return;
		}
		FrontWall = ((Component)((Component)this).transform.parent.Find("Wall/wall_1")).gameObject;
		Slider = SliderObj.GetComponent<SpriteRenderer>();
		MaxSliderWidth = Slider.size.x;
		ShipAnimCacheManager = new ShipAnimCacheManager();
		buildingSprite = new List<string>();
		ShipUIPages = new Dictionary<eShipDisplayState, GameObject>();
		foreach (eShipDisplayState value in Enum.GetValues(typeof(eShipDisplayState)))
		{
			if (value != eShipDisplayState.none)
			{
				ShipUIPages.Add(value, ((Component)((Component)this).transform.Find($"{value}")).gameObject);
				ShipUIPages[value].SetActive(false);
			}
		}
		SharedMessenger.AddListener<string, BuildingConstructingConfig>("BUILDING_START_UPGRADING", OnAnyConstructionStart);
		SharedMessenger.AddListener<string, int>("BUILDING_UPGRADED", OnAnyConstructionFinished);
		SharedMessenger.AddListener<string, Dictionary<string, object>>("OPEN_UI", OnAnyUIOpened);
		SharedMessenger.AddListener<string>("CLOSE_UI", OnAnyUIClosed);
		UiTagManager.Instance.Register("MainCity.ExpeditionHallEntrance", ((Component)this).gameObject);
		UpdateBuildingState(building.Level, isInit: true);
	}

	private void OnDestroy()
	{
		SharedMessenger.RemoveListener<string, BuildingConstructingConfig>("BUILDING_START_UPGRADING", OnAnyConstructionStart);
		SharedMessenger.RemoveListener<string, int>("BUILDING_UPGRADED", OnAnyConstructionFinished);
		SharedMessenger.RemoveListener<string, Dictionary<string, object>>("OPEN_UI", OnAnyUIOpened);
		SharedMessenger.RemoveListener<string>("CLOSE_UI", OnAnyUIClosed);
		UiTagManager.Instance.Unregister("MainCity.ExpeditionHallEntrance", ((Component)this).gameObject);
		((MonoBehaviour)this).StopAllCoroutines();
		if (ShipAnimCacheManager != null)
		{
			ShipAnimCacheManager.ClearCache();
		}
	}

	private bool Version159GvG3BuildingLoad()
	{
		string text = Application.version.Replace(".", "");
		if (!text.StartsWith("159"))
		{
			return false;
		}
		LoadComponents();
		LoadBuildingAssets();
		UpdateComponentsState();
		return true;
		void LoadBuildingAssets()
		{
			string backgroundDisabledSpriteName = "room_locked_" + building.BuildingType;
			AssetsManager.Instance.LoadAsset<Sprite>(backgroundDisabledSpriteName).Then((Action<Sprite>)delegate(Sprite asset)
			{
				BackgroundDisabled.GetComponent<SpriteRenderer>().sprite = asset;
				if (!buildingSprite.Contains(backgroundDisabledSpriteName))
				{
					buildingSprite.Add(backgroundDisabledSpriteName);
				}
			});
			string translucentMaskSpriteName = "room_locked_mask_" + building.BuildingType;
			AssetsManager.Instance.LoadAsset<Sprite>(translucentMaskSpriteName).Then((Action<Sprite>)delegate(Sprite asset)
			{
				TranslucentMask.GetComponent<SpriteRenderer>().sprite = asset;
				if (!buildingSprite.Contains(translucentMaskSpriteName))
				{
					buildingSprite.Add(translucentMaskSpriteName);
				}
			});
		}
		void LoadComponents()
		{
			buildingSprite = new List<string>();
			CurShipState = eShipDisplayState.none;
			BackgroundDisabled = ((Component)((Component)this).transform.Find("BackgroundDisabled")).gameObject;
			TranslucentMask = ((Component)((Component)this).transform.Find("TranslucentMask")).gameObject;
			FrontWall = ((Component)((Component)this).transform.parent.Find("Wall/wall_1")).gameObject;
			Background = ((Component)((Component)this).transform.Find("Background")).gameObject;
			Decoration = ((Component)((Component)this).transform.Find("Decoration")).gameObject;
			Mask = ((Component)((Component)this).transform.Find("Mask")).gameObject;
		}
		void UpdateComponentsState()
		{
			BackgroundDisabled.SetActive(true);
			TranslucentMask.SetActive(true);
			FrontWall.SetActive(true);
			Background.SetActive(false);
			Decoration.SetActive(false);
			Mask.SetActive(false);
		}
	}

	private void UpdateShipState(bool forceSyncRecord)
	{
		GameManagers.Instance.UserArchiveManager.GetGvGMode3Record(delegate(GvGMode3Records record)
		{
			GvGMode3ObserverRecord observerRecord = record.ObserverRecord;
			List<GvGMode3ShipModel> ships = observerRecord.Ships;
			List<eShipDisplayState> list = new List<eShipDisplayState>();
			Dictionary<eShipDisplayState, GvGMode3ShipModel> dictionary = new Dictionary<eShipDisplayState, GvGMode3ShipModel>();
			if (ships == null || ships.Count == 0)
			{
				list.Add(eShipDisplayState.state_idle);
			}
			else
			{
				LastBuildingShip = GetLastBuildingShipByTime(ships);
				if (LastBuildingShip != null)
				{
					list.Add(eShipDisplayState.state_building);
				}
				FirstPendingAcceptanceShip = GetFirstPendingAcceptanceShipByTime(ships);
				if (FirstPendingAcceptanceShip != null)
				{
					list.Add(eShipDisplayState.state_finished);
				}
				FirstNotLaunchedShip = GetFirstNotLaunchedShipByIndex(ships);
				if (FirstNotLaunchedShip != null)
				{
					list.Add(eShipDisplayState.state_waiting);
				}
				if (LastBuildingShip == null && FirstPendingAcceptanceShip == null && FirstNotLaunchedShip == null)
				{
					FirstLaunchedShip = ships[0];
					list.Add(eShipDisplayState.state_flying);
				}
			}
			if (list.Count == 0)
			{
				ILRuntimeDebug.LogError("[GvGExpeditionHallEntranceController] UpdateShipState 没有状态！");
			}
			else
			{
				list.Sort();
				eShipDisplayState curShipState = list[list.Count - 1];
				CurShipState = curShipState;
				UpdateCurShipStateAnimation();
			}
		}, forceSyncRecord);
	}

	private GvGMode3ShipModel GetLastBuildingShipByTime(List<GvGMode3ShipModel> ships)
	{
		int num = (int)GameController.Instance.GetServerTime();
		int num2 = -1;
		GvGMode3ShipModel result = null;
		foreach (GvGMode3ShipModel ship in ships)
		{
			if ((ship.PermanentData.ShipBuildState == 2 || ship.PermanentData.ShipBuildState == 3) && ship.PermanentData.TargetBuildCompleteTime > num && num2 < ship.PermanentData.BuildStartTime)
			{
				num2 = ship.PermanentData.BuildStartTime;
				result = ship;
			}
		}
		return result;
	}

	private GvGMode3ShipModel GetFirstPendingAcceptanceShipByTime(List<GvGMode3ShipModel> ships)
	{
		int num = (int)GameController.Instance.GetServerTime();
		int num2 = int.MaxValue;
		GvGMode3ShipModel result = null;
		foreach (GvGMode3ShipModel ship in ships)
		{
			if ((ship.PermanentData.ShipBuildState == 2 || ship.PermanentData.ShipBuildState == 3) && ship.PermanentData.TargetBuildCompleteTime <= num && num2 > ship.PermanentData.TargetBuildCompleteTime)
			{
				num2 = ship.PermanentData.TargetBuildCompleteTime;
				result = ship;
			}
		}
		return result;
	}

	private GvGMode3ShipModel GetFirstNotLaunchedShipByIndex(List<GvGMode3ShipModel> ships)
	{
		GvGMode3ShipModel result = null;
		foreach (GvGMode3ShipModel ship in ships)
		{
			if (!ship.PermanentData.HasLaunch)
			{
				result = ship;
			}
		}
		return result;
	}

	private void UpdateCurShipStateAnimation()
	{
		switch (CurShipState)
		{
		case eShipDisplayState.state_building:
			SetShipAnimation(LastBuildingShip, "jianzaozhong");
			SetShipBuildingTimer(LastBuildingShip);
			break;
		case eShipDisplayState.state_finished:
			SetShipAnimation(FirstPendingAcceptanceShip, "jianzaozhong");
			SetShipBuildingTimer(null);
			break;
		case eShipDisplayState.state_waiting:
			SetShipAnimation(FirstNotLaunchedShip, "jianzaozhong");
			SetShipBuildingTimer(null);
			break;
		case eShipDisplayState.state_flying:
			SetShipAnimation(FirstLaunchedShip, "feixing_lan");
			SetShipBuildingTimer(null);
			break;
		default:
			SetShipAnimation(null, "");
			SetShipBuildingTimer(null);
			break;
		}
	}

	private void SetShipAnimation(GvGMode3ShipModel curShip, string animationName)
	{
		if (curShip != null)
		{
			ShipConfigModel byShipRaceType = ShipConfigHelper.GetByShipRaceType(curShip.PermanentData.ShipRace);
			ShipAnimCacheManager.GetCache("", byShipRaceType.DefaultSkinId, delegate(SkeletonAnimation animation)
			{
				//IL_004a: Unknown result type (might be due to invalid IL or missing references)
				//IL_0074: Unknown result type (might be due to invalid IL or missing references)
				SpineHelper.SetSkin((ISkeletonAnimation)(object)animation, "skin1");
				ShipAnim = animation;
				((Component)ShipAnim).transform.SetParent(ShipContainer);
				((Component)ShipAnim).transform.localPosition = Vector3.zero;
				((Component)ShipAnim).transform.localScale = new Vector3(1f, 1f, 1f);
				ShipAnim.AnimationState.SetAnimation(0, animationName, true);
				MeshRenderer component = ((Component)((Component)ShipAnim).transform).GetComponent<MeshRenderer>();
				((Renderer)component).sortingOrder = 1;
			}, isMask: false, isSimpleSpine: true);
			SkeletonAnimation shipAnim = ShipAnim;
			if (shipAnim != null)
			{
				shipAnim.AnimationState.SetAnimation(0, animationName, true);
			}
			((Component)ShipContainer).gameObject.SetActive(true);
		}
		else if ((Object)(object)ShipAnim != (Object)null && (Object)(object)((Component)ShipAnim).gameObject != (Object)null)
		{
			Object.Destroy((Object)(object)((Component)ShipAnim).gameObject);
			((Component)ShipContainer).gameObject.SetActive(false);
			ShipAnim = null;
		}
	}

	private void SetShipBuildingTimer(GvGMode3ShipModel curShip)
	{
		//IL_0077: Unknown result type (might be due to invalid IL or missing references)
		//IL_0081: Expected O, but got Unknown
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0028: Expected O, but got Unknown
		//IL_005b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0066: Expected O, but got Unknown
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_004c: Expected O, but got Unknown
		if (curShip != null)
		{
			ShipBuildingTimer(curShip);
			if (!Timers.inst.Exists(new TimerCallback(ShipBuildingTimer)))
			{
				Timers.inst.Add(1f, 0, new TimerCallback(ShipBuildingTimer), (object)curShip);
			}
			else
			{
				Timers.inst.AddUpdate(new TimerCallback(ShipBuildingTimer), (object)curShip);
			}
		}
		else
		{
			Timers.inst.Remove(new TimerCallback(ShipBuildingTimer));
		}
	}

	private void ShipBuildingTimer(object param)
	{
		//IL_004f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0054: Unknown result type (might be due to invalid IL or missing references)
		//IL_006c: Unknown result type (might be due to invalid IL or missing references)
		GvGMode3ShipModel gvGMode3ShipModel = (GvGMode3ShipModel)param;
		int buildStartTime = gvGMode3ShipModel.PermanentData.BuildStartTime;
		int targetBuildCompleteTime = gvGMode3ShipModel.PermanentData.TargetBuildCompleteTime;
		int num = (int)GameController.Instance.GetServerTime();
		int num2 = targetBuildCompleteTime - buildStartTime;
		int num3 = num - buildStartTime;
		float num4 = Mathf.Min(1f, (float)num3 / (float)num2);
		Vector2 size = Slider.size;
		size.x = num4 * MaxSliderWidth;
		Slider.size = size;
		if (num4 >= 1f)
		{
			UpdateShipState(forceSyncRecord: false);
		}
	}

	public void UpdateBuildingState(int curLevel, bool isInit = false)
	{
		if (curLevel < 1)
		{
			CurShipState = eShipDisplayState.none;
			string backgroundDisabledSpriteName = "room_locked_" + building.BuildingType;
			AssetsManager.Instance.LoadAsset<Sprite>(backgroundDisabledSpriteName).Then((Action<Sprite>)delegate(Sprite asset)
			{
				BackgroundDisabled.GetComponent<SpriteRenderer>().sprite = asset;
				if (!buildingSprite.Contains(backgroundDisabledSpriteName))
				{
					buildingSprite.Add(backgroundDisabledSpriteName);
				}
			});
			string translucentMaskSpriteName = "room_locked_mask_" + building.BuildingType;
			AssetsManager.Instance.LoadAsset<Sprite>(translucentMaskSpriteName).Then((Action<Sprite>)delegate(Sprite asset)
			{
				TranslucentMask.GetComponent<SpriteRenderer>().sprite = asset;
				if (!buildingSprite.Contains(translucentMaskSpriteName))
				{
					buildingSprite.Add(translucentMaskSpriteName);
				}
			});
			BackgroundDisabled.SetActive(true);
			TranslucentMask.SetActive(true);
			FrontWall.SetActive(true);
			Background.SetActive(false);
			Decoration.SetActive(false);
			Mask.SetActive(false);
			return;
		}
		UpdateShipState(isInit);
		BackgroundDisabled.SetActive(false);
		TranslucentMask.SetActive(false);
		FrontWall.SetActive(false);
		Background.SetActive(true);
		Decoration.SetActive(true);
		string text = "room_unlocked_" + building.BuildingType;
		AssetsManager.Instance.LoadAsset<Sprite>(text).Then((Action<Sprite>)delegate(Sprite asset)
		{
			Background.GetComponent<SpriteRenderer>().sprite = asset;
			if (!isInit)
			{
				FGUIManager.Instance.OpenIEnumerator(UnloadBuildingSpritesCoroutine());
			}
		});
		string text2 = "room_deco_7";
		AssetsManager.Instance.LoadAsset<Sprite>(text2).Then((Action<Sprite>)delegate(Sprite asset)
		{
			Decoration.GetComponent<SpriteRenderer>().sprite = asset;
		});
	}

	private IEnumerator UnloadBuildingSpritesCoroutine()
	{
		yield return (object)new WaitForSeconds(3f);
		BackgroundDisabled.GetComponent<SpriteRenderer>().sprite = null;
		TranslucentMask.GetComponent<SpriteRenderer>().sprite = null;
		for (int i = 0; i < buildingSprite.Count; i++)
		{
			AssetsManager.Instance.UnloadAsset<Sprite>(buildingSprite[i]);
		}
	}

	private void OnAnyUIOpened(string uiName, Dictionary<string, object> parameter)
	{
		if (building.Level >= 1 && !(uiName == UI_MainCity.Name))
		{
		}
	}

	private void OnAnyUIClosed(string uiName)
	{
		if (building.Level >= 1 && uiName == UI_GvGExpeditionHallPanel.Name)
		{
			UpdateShipState(forceSyncRecord: false);
		}
	}

	private void OnAnyConstructionStart(string buildingType, BuildingConstructingConfig info)
	{
		if (building != null && building.BuildingType == buildingType)
		{
			if (building.Level <= 0)
			{
				((Component)this).gameObject.GetComponent<HitArea>().RepairBuild(info.Workers, info.UpgradeRemainingTime);
			}
			((MonoBehaviour)this).StartCoroutine(StartConstructionCoroutine());
			UiAudioManager.Instance.PlaySoundEffect("ConstructionSite");
		}
	}

	public void ContinueUpgrade(BuildingConstructingConfig constructingStatus)
	{
		if (building.Status == BuildingStatus.Constructing && constructingStatus.UpgradeRemainingTime > 3)
		{
			if (building.Level >= 0)
			{
				((Component)this).gameObject.GetComponent<HitArea>().RepairBuild(constructingStatus.Workers, constructingStatus.UpgradeRemainingTime);
			}
			((MonoBehaviour)this).StartCoroutine(StartConstructionCoroutine());
		}
		else if (building.Status == BuildingStatus.Constructing && constructingStatus.UpgradeRemainingTime <= 3)
		{
			ScriptApi.CreateTimer(2f, delegate
			{
				UpdateBuildingState(1);
				FGUIManager.Instance.SetBuilderIdleStates(building, constructingStatus.Workers);
				FGUIManager.Instance.SetReadyBuildingUpgradeBar(building);
			});
		}
		else if (building.Status == BuildingStatus.Ready)
		{
			ScriptApi.CreateTimer(2f, delegate
			{
				UpdateBuildingState(1);
				FGUIManager.Instance.SetBuilderIdleStates(building, constructingStatus.Workers);
				FGUIManager.Instance.SetReadyBuildingUpgradeBar(building);
			});
		}
	}

	private void OnAnyConstructionFinished(string buildingType, int level)
	{
		if (building != null && building.BuildingType == buildingType)
		{
			UpdateBuildingState(1);
		}
	}

	public IEnumerator StartConstructionCoroutine()
	{
		HitArea hitArea = building.GameObject.GetComponent<HitArea>();
		BuildingConstructingConfig info = building.ConstructingConfig;
		int endTime = (int)GameController.Instance.GetServerTime() + info.UpgradeRemainingTime;
		int remainingTime;
		while (IsNotOver(out remainingTime))
		{
			if (remainingTime <= 1 && !((Component)this).gameObject.GetComponent<HitArea>().haveSmoke)
			{
				GameObject smoke = SpawnManager.Instance.InstantiatePool("buildingSmoke", Vector3.zero);
				if ((Object)(object)smoke != (Object)null && !hitArea.haveSmoke)
				{
					smoke.transform.eulerAngles = building.GameObject.transform.eulerAngles;
					smoke.transform.position = building.GameObject.transform.position;
					smoke.AddComponent<HotFix_DestroySelf>().destroyTime = 1f;
					hitArea.haveSmoke = true;
				}
				UpdateBuildingState(1);
			}
			FGUIManager.Instance.BuildingUpgradeBarRefresh(building, init: false, remainingTime);
			yield return (object)new WaitForSeconds(1f);
		}
		PlayBuildingRepairedSfx();
		FGUIManager.Instance.BuildingUpgradeBarRefresh(building, init: false, 0);
		SetBuilderIdle(hitArea);
		yield return (object)new WaitForSeconds(1f);
		((Component)this).gameObject.GetComponent<HitArea>().isStartRepair = false;
		bool IsNotOver(out int reference)
		{
			reference = endTime - (int)GameController.Instance.GetServerTime();
			return reference > 0;
		}
	}

	private void SetBuilderIdle(HitArea hitArea)
	{
		for (int i = 0; i < 5; i++)
		{
			if (((Component)hitArea.hitData.builders.transform.GetChild(i)).gameObject.activeInHierarchy)
			{
				((Component)hitArea.hitData.builders.transform.GetChild(i)).GetComponent<SkeletonAnimation>().AnimationName = "idle";
			}
		}
		for (int num = hitArea.smokes.Count - 1; num >= 0; num--)
		{
			Object.Destroy((Object)(object)hitArea.smokes[num]);
		}
		hitArea.smokes.Clear();
	}

	private void PlayBuildingRepairedSfx()
	{
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0067: Unknown result type (might be due to invalid IL or missing references)
		//IL_0088: Unknown result type (might be due to invalid IL or missing references)
		HitArea component = building.GameObject.GetComponent<HitArea>();
		if (!component.haveSmoke)
		{
			GameObject val = SpawnManager.Instance.InstantiatePool("buildingSmoke", Vector3.zero);
			if ((Object)(object)val != (Object)null && !component.haveSmoke)
			{
				val.transform.eulerAngles = building.GameObject.transform.eulerAngles;
				val.transform.position = building.GameObject.transform.position;
				val.AddComponent<HotFix_DestroySelf>().destroyTime = 1f;
				component.haveSmoke = true;
			}
			UpdateBuildingState(1);
		}
	}
}
