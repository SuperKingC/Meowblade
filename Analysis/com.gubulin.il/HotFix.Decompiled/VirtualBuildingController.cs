using System.Collections;
using System.Collections.Generic;
using System.Linq;
using FairyGUI;
using Shift.Legion.Common.Enums;
using Shift.Legion.Common.Managers;
using Shift.Legion.Common.Models;
using Spine.Unity;
using UI;
using UnityEngine;

public class VirtualBuildingController : MonoBehaviour
{
	public Building building;

	private void OnDestroy()
	{
		((MonoBehaviour)this).StopAllCoroutines();
		SharedMessenger.RemoveListener<string, BuildingConstructingConfig>("BUILDING_START_UPGRADING", OnBuildingUpgrade);
		SharedMessenger.RemoveListener<string, ActivityStatus>("ACTIVITY_STATUS_CHANGED", UpdateCards);
		SharedMessenger.RemoveListener<string, int>("BUILDING_UPGRADED", SetDrawingBoardOnMI7LevelUp);
	}

	private void Start()
	{
		SharedMessenger.AddListener<string, BuildingConstructingConfig>("BUILDING_START_UPGRADING", OnBuildingUpgrade);
		SharedMessenger.AddListener<string, ActivityStatus>("ACTIVITY_STATUS_CHANGED", UpdateCards);
		SharedMessenger.AddListener<string, int>("BUILDING_UPGRADED", SetDrawingBoardOnMI7LevelUp);
		SetMilitaryIntelligenceDrawingBoard(building.Level);
	}

	private void SetDrawingBoardOnMI7LevelUp(string buildingType, int level)
	{
		Building buildingByType = GameManagers.Instance.BuildingManager.GetBuildingByType(buildingType);
		if (!(buildingByType.Feature != "MilitaryIntelligence7"))
		{
			SetMilitaryIntelligenceDrawingBoard(level);
		}
	}

	public void SetNeutralDungeonTipVisible(bool visible)
	{
		((Component)building.GameObject.transform.Find("Decoration/ui_neutral_quest_bubble")).gameObject.SetActive(visible);
	}

	public void SetMilitaryIntelligenceDrawingBoardNewIcon(bool iconVisible)
	{
		UIPanel component = ((Component)building.GameObject.transform.Find("Decoration/Icon")).gameObject.GetComponent<UIPanel>();
		component.ui.GetChild("newIcon").visible = iconVisible;
	}

	private void SetMilitaryIntelligenceDrawingBoard(int level)
	{
		//IL_00a1: Unknown result type (might be due to invalid IL or missing references)
		if (building.Feature != "MilitaryIntelligence7" || level < 1)
		{
			return;
		}
		UIPanel val = null;
		if ((Object)(object)((Component)building.GameObject.transform.Find("Decoration/Icon")).gameObject.GetComponent<UIPanel>() == (Object)null)
		{
			val = ((Component)building.GameObject.transform.Find("Decoration/Icon")).gameObject.AddComponent<UIPanel>();
			val.packageName = "PublicResources";
			val.componentName = "DrawingBoard";
			val.container.renderMode = (RenderMode)2;
			val.SetSortingOrder(0, true);
			val.sortingOrder = 0;
			val.CreateUI();
		}
		else
		{
			val = ((Component)building.GameObject.transform.Find("Decoration/Icon")).gameObject.GetComponent<UIPanel>();
		}
		List<Activity> activitiesByType = GameManagers.Instance.ActivityManager.GetActivitiesByType(ActivityType.TimeLimitInstance, null, isSort: false);
		val.ui.GetController("PageController").selectedIndex = 0;
		if (activitiesByType != null && activitiesByType.Count > 0)
		{
			string text = "";
			foreach (Activity item in activitiesByType)
			{
				if (item.GetStatus(GameManagers.Instance) == ActivityStatus.Enabled)
				{
					text = item.BonusExhibition.Last();
					val.ui.GetController("PageController").selectedIndex = 1;
					SetMilitaryIntelligenceDrawingBoardNewIcon(item.ActivityProgress(GameManagers.Instance).IsNew);
					break;
				}
			}
			if (!string.IsNullOrWhiteSpace(text))
			{
				((GComponent)val.ui.GetChild("Icon").asButton).GetChild("icon").asLoader.url = "ui://PublicResources/" + text;
			}
			else
			{
				val.ui.GetController("PageController").selectedIndex = 0;
			}
		}
		else
		{
			val.ui.GetController("PageController").selectedIndex = 0;
		}
	}

	private void UpdateCards(string activityId, ActivityStatus newStatus)
	{
		SetMilitaryIntelligenceDrawingBoard(building.Level);
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
			PlayBuildingRepairedSfx();
			FGUIManager.Instance.BuildingUpgradeBarRefresh(building, init: false, totalTime);
			yield return (object)new WaitForSeconds(1f);
		}
		while (totalTime > 0)
		{
			totalTime--;
			if (totalTime <= 1 && !((Component)this).gameObject.GetComponent<HitArea>().haveSmoke)
			{
				ScriptApi.CreateTimer(1.95f, delegate
				{
					//IL_000b: Unknown result type (might be due to invalid IL or missing references)
					//IL_0051: Unknown result type (might be due to invalid IL or missing references)
					//IL_0077: Unknown result type (might be due to invalid IL or missing references)
					GameObject val = SpawnManager.Instance.InstantiatePool("buildingSmoke", Vector3.zero);
					if ((Object)(object)val != (Object)null && !hitArea.haveSmoke)
					{
						val.transform.eulerAngles = building.GameObject.transform.eulerAngles;
						val.transform.position = building.GameObject.transform.position;
						val.AddComponent<HotFix_DestroySelf>().destroyTime = 1f;
						hitArea.haveSmoke = true;
					}
				});
			}
			FGUIManager.Instance.BuildingUpgradeBarRefresh(building, init: false, totalTime);
			yield return (object)new WaitForSeconds(1f);
		}
		for (int i = 0; i < 5; i++)
		{
			if (((Component)hitArea.hitData.builders.transform.GetChild(i)).gameObject.activeInHierarchy)
			{
				((Component)hitArea.hitData.builders.transform.GetChild(i)).GetComponent<SkeletonAnimation>().AnimationName = "idle";
			}
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
		bool needShowBuilders = building.Level >= 1;
		ScriptApi.CreateTimer(0.4f, delegate
		{
			FGUIManager.Instance.LoadBuildings(building, isInit: false, 1);
			if (needShowBuilders)
			{
				((Component)this).gameObject.GetComponent<HitArea>().hitData.builders.SetActive(true);
			}
		});
	}

	private void PlayBuildingRepairedSfx()
	{
		HitArea hitArea = building.GameObject.GetComponent<HitArea>();
		if (hitArea.haveSmoke)
		{
			return;
		}
		ScriptApi.CreateTimer(0.95f, delegate
		{
			//IL_000b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0051: Unknown result type (might be due to invalid IL or missing references)
			//IL_0077: Unknown result type (might be due to invalid IL or missing references)
			GameObject val = SpawnManager.Instance.InstantiatePool("buildingSmoke", Vector3.zero);
			if ((Object)(object)val != (Object)null && !hitArea.haveSmoke)
			{
				val.transform.eulerAngles = building.GameObject.transform.eulerAngles;
				val.transform.position = building.GameObject.transform.position;
				val.AddComponent<HotFix_DestroySelf>().destroyTime = 1f;
				hitArea.haveSmoke = true;
			}
		});
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
				FGUIManager.Instance.LoadBuildings(building, isInit: false, 1);
				FGUIManager.Instance.SetBuilderIdleStates(building, ConstructingStatus.Workers);
				FGUIManager.Instance.SetReadyBuildingUpgradeBar(building);
			});
		}
		else if (building.Status == BuildingStatus.Ready)
		{
			ScriptApi.CreateTimer(2f, delegate
			{
				FGUIManager.Instance.LoadBuildings(building, isInit: false, 1);
				FGUIManager.Instance.SetBuilderIdleStates(building, ConstructingStatus.Workers);
				FGUIManager.Instance.SetReadyBuildingUpgradeBar(building);
			});
		}
	}
}
