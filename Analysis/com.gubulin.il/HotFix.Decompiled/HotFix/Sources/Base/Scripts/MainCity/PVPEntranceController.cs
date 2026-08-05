using System;
using System.Collections;
using System.Collections.Generic;
using HotFix.Sources.Base.Scripts.UI;
using Shift.Legion.Common.Enums;
using Shift.Legion.Common.Models;
using UI;
using UI.MainCity;
using UnityEngine;

namespace HotFix.Sources.Base.Scripts.MainCity;

public class PVPEntranceController : MonoBehaviour
{
	public Building building;

	public bool EntranceEnabled;

	public bool EntranceActive;

	private GameObject Background;

	private GameObject BackgroundDisabled;

	private GameObject Decoration;

	private GameObject Mask;

	private GameObject TranslucentMask;

	private GameObject Builders;

	private List<string> buildingSprite;

	private GameObject pvp_room_1;

	private void OnDestroy()
	{
		((MonoBehaviour)this).StopAllCoroutines();
		SharedMessenger.RemoveListener<string, BuildingConstructingConfig>("BUILDING_START_UPGRADING", OnBuildingUpgrade);
		SharedMessenger.RemoveListener<string, int>("BUILDING_UPGRADED", UpdateEntranceStatus);
		SharedMessenger.RemoveListener<string, Dictionary<string, object>>("OPEN_UI", UpdateEntranceSwitch);
	}

	private void Start()
	{
		buildingSprite = new List<string>();
		SharedMessenger.AddListener<string, BuildingConstructingConfig>("BUILDING_START_UPGRADING", OnBuildingUpgrade);
		SharedMessenger.AddListener<string, int>("BUILDING_UPGRADED", UpdateEntranceStatus);
		SharedMessenger.AddListener<string, Dictionary<string, object>>("OPEN_UI", UpdateEntranceSwitch);
		PVPEntranceStatusInit(building.Level, showSfx: true, isInit: true);
	}

	private void GetBuildingComponent()
	{
		if ((Object)(object)Background == (Object)null)
		{
			Background = ((Component)building.GameObject.transform.Find("Background")).gameObject;
		}
		if ((Object)(object)BackgroundDisabled == (Object)null)
		{
			BackgroundDisabled = ((Component)building.GameObject.transform.Find("BackgroundDisabled")).gameObject;
		}
		if ((Object)(object)Decoration == (Object)null)
		{
			Decoration = ((Component)building.GameObject.transform.Find("Decoration")).gameObject;
		}
		if ((Object)(object)Mask == (Object)null)
		{
			Mask = ((Component)building.GameObject.transform.Find("Mask")).gameObject;
		}
		if ((Object)(object)TranslucentMask == (Object)null)
		{
			TranslucentMask = ((Component)building.GameObject.transform.Find("TranslucentMask")).gameObject;
		}
		if ((Object)(object)pvp_room_1 == (Object)null)
		{
			pvp_room_1 = ((Component)building.GameObject.transform.Find("pvp_room_1")).gameObject;
		}
	}

	public void UpdateEntranceStatus()
	{
		EntranceEnabled = true;
		EntranceActive = UpdateEntranceActive() && RankDataHelper.PvpSeasonIsEnable();
	}

	private IEnumerator UnLoadBuildingSprites()
	{
		yield return (object)new WaitForSeconds(3f);
		BackgroundDisabled.GetComponent<SpriteRenderer>().sprite = null;
		TranslucentMask.GetComponent<SpriteRenderer>().sprite = null;
		for (int i = 0; i < buildingSprite.Count; i++)
		{
			AssetsManager.Instance.UnloadAsset<Sprite>(buildingSprite[i]);
		}
	}

	public void PVPEntranceStatusInit(int curLevel, bool showSfx = true, bool isInit = false)
	{
		GetBuildingComponent();
		UpdateEntranceStatus();
		if (curLevel < 1)
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
			BackgroundDisabled.SetActive(true);
			TranslucentMask.SetActive(true);
			Background.SetActive(false);
			Decoration.SetActive(false);
			Mask.SetActive(false);
			pvp_room_1.SetActive(false);
			return;
		}
		UpdateEntranceStatus();
		BackgroundDisabled.SetActive(false);
		TranslucentMask.SetActive(false);
		if (EntranceEnabled && !EntranceActive)
		{
			Background.SetActive(true);
			Decoration.SetActive(true);
			Mask.SetActive(false);
			pvp_room_1.SetActive(showSfx);
		}
		else
		{
			Background.SetActive(true);
			Decoration.SetActive(true);
			Mask.SetActive(true);
			pvp_room_1.SetActive(false);
			string text = "room_deco_18_1";
			AssetsManager.Instance.LoadAsset<Sprite>(text).Then((Action<Sprite>)delegate(Sprite asset)
			{
				Mask.GetComponent<SpriteRenderer>().sprite = asset;
			});
		}
		string text2 = "room_unlocked_" + building.BuildingType;
		AssetsManager.Instance.LoadAsset<Sprite>(text2).Then((Action<Sprite>)delegate(Sprite asset)
		{
			Background.GetComponent<SpriteRenderer>().sprite = asset;
			if (!isInit)
			{
				FGUIManager.Instance.OpenIEnumerator(UnLoadBuildingSprites());
			}
		});
		string text3 = "room_deco_18_2";
		AssetsManager.Instance.LoadAsset<Sprite>(text3).Then((Action<Sprite>)delegate(Sprite asset)
		{
			Decoration.GetComponent<SpriteRenderer>().sprite = asset;
		});
	}

	public bool UpdateEntranceEnabled()
	{
		long num = GameController.Instance.GetServerTime() + 28800;
		DateTimeOffset first = DateTimeHelper.ParseTimeStamp((int)num);
		DateTimeOffset second = new DateTimeOffset(first.Year, first.Month, first.Day, 2, 0, 0, TimeSpan.Zero);
		DateTimeOffset second2 = new DateTimeOffset(first.Year, first.Month, first.Day, 10, 0, 0, TimeSpan.Zero);
		bool flag = DateTimeOffset.Compare(first, second) > 0;
		bool flag2 = DateTimeOffset.Compare(first, second2) < 0;
		return flag && flag2;
	}

	public bool UpdateEntranceActive()
	{
		int num = (int)GameController.Instance.GetServerTime();
		int battleEndAtTimestamp = RankDataHelper.RankStartGameInfo.BattleEndAtTimestamp;
		int endAtTimestamp = RankDataHelper.RankStartGameInfo.EndAtTimestamp;
		return num > battleEndAtTimestamp && num < endAtTimestamp;
	}

	private void UpdateEntranceSwitch(string uiName, Dictionary<string, object> parameter)
	{
		if (uiName == UI_MainCity.Name)
		{
			PVPEntranceStatusInit(building.Level, showSfx: true, isInit: true);
		}
	}

	private void UpdateEntranceStatus(string buildingType, int level)
	{
		if (buildingType == building.BuildingType)
		{
			PVPEntranceStatusInit(1);
		}
	}

	public void ContinueUpgrade(BuildingConstructingConfig ConstructingStatus)
	{
		if (building.Status == BuildingStatus.Constructing && ConstructingStatus.UpgradeRemainingTime > 3)
		{
			if (building.Level >= 1)
			{
				((Component)this).gameObject.GetComponent<HitArea>().RepairBuild(ConstructingStatus.Workers, ConstructingStatus.UpgradeRemainingTime);
			}
			((MonoBehaviour)this).StartCoroutine(RepairTiming(ConstructingStatus.UpgradeRemainingTime));
		}
		else if (building.Status == BuildingStatus.Constructing && ConstructingStatus.UpgradeRemainingTime <= 3)
		{
			ScriptApi.CreateTimer(2f, delegate
			{
				PVPEntranceStatusInit(1);
				FGUIManager.Instance.SetBuilderIdleStates(building, ConstructingStatus.Workers);
				FGUIManager.Instance.SetReadyBuildingUpgradeBar(building);
			});
		}
		else if (building.Status == BuildingStatus.Ready)
		{
			ScriptApi.CreateTimer(2f, delegate
			{
				PVPEntranceStatusInit(1);
				FGUIManager.Instance.SetBuilderIdleStates(building, ConstructingStatus.Workers);
				FGUIManager.Instance.SetReadyBuildingUpgradeBar(building);
			});
		}
	}

	private void OnBuildingUpgrade(string buildingType, BuildingConstructingConfig info)
	{
		if (building != null && building.BuildingType == buildingType)
		{
			if (building.Level >= 1)
			{
				((Component)this).gameObject.GetComponent<HitArea>().RepairBuild(info.Workers, info.UpgradeRemainingTime);
			}
			((MonoBehaviour)this).StartCoroutine(RepairTiming(info.UpgradeRemainingTime));
			UiAudioManager.Instance.PlaySoundEffect("ConstructionSite");
		}
	}

	public IEnumerator RepairTiming(int time)
	{
		HitArea hitArea = building.GameObject.GetComponent<HitArea>();
		BuildingConstructingConfig info = building.ConstructingConfig;
		int totalTime = info.UpgradeRemainingTime;
		if (totalTime <= 0)
		{
			PlayPvpEntranceRepairedSfx();
			FGUIManager.Instance.BuildingUpgradeBarRefresh(building, init: false, totalTime);
			yield return (object)new WaitForSeconds(1f);
		}
		while (totalTime >= 0)
		{
			totalTime--;
			if (totalTime <= 1 && !((Component)this).gameObject.GetComponent<HitArea>().haveSmoke)
			{
				GameObject smoke = SpawnManager.Instance.InstantiatePool("buildingSmoke", Vector3.zero);
				if ((Object)(object)smoke != (Object)null && !hitArea.haveSmoke)
				{
					smoke.transform.eulerAngles = building.GameObject.transform.eulerAngles;
					smoke.transform.position = building.GameObject.transform.position;
					smoke.AddComponent<HotFix_DestroySelf>().destroyTime = 1f;
					hitArea.haveSmoke = true;
				}
				PVPEntranceStatusInit(1, showSfx: false);
			}
			FGUIManager.Instance.BuildingUpgradeBarRefresh(building, init: false, totalTime);
			yield return (object)new WaitForSeconds(1f);
		}
		ScriptApi.CreateTimer(1.05f, delegate
		{
			for (int num = hitArea.smokes.Count - 1; num >= 0; num--)
			{
				Object.Destroy((Object)(object)hitArea.smokes[num]);
			}
			hitArea.smokes.Clear();
		});
		((Component)this).gameObject.GetComponent<HitArea>().isStartRepair = false;
	}

	private void PlayPvpEntranceRepairedSfx()
	{
		//IL_002c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_0089: Unknown result type (might be due to invalid IL or missing references)
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
			PVPEntranceStatusInit(1, showSfx: false);
		}
	}
}
