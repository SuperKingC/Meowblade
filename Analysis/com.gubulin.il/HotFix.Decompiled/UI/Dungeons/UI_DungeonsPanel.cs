using System;
using System.Collections.Generic;
using Assets.Scripts.Managers;
using Assets.Scripts.UI;
using FairyGUI;
using FairyGUI.Utils;
using Shift.Legion.Common.Enums;
using Shift.Legion.Common.Managers;
using Shift.Legion.Common.Models;
using Shift.Legion.Common.Services;
using Shift.Legion.Common.Sources.Enums;
using UI.MonthCard;
using UI.PrinceOfTheDevils;
using UI.SoldierFormationInfo;
using UI.Tips;
using UI.UpGrade;
using UnityEngine;

namespace UI.Dungeons;

public class UI_DungeonsPanel : GComponent, IUiController
{
	public GLoader background;

	public UI_Title Title;

	public GComponent addWorkerBtn;

	public GButton backBtn;

	public GImage n21;

	public GImage n42;

	public GImage n43;

	public GGroup backgroup;

	public GButton dungeonSizeBtn;

	public GGroup sizeGroup;

	public GList buildingList;

	public GGraph levleSFXBack;

	public UI_DungeonLevel levelProgress;

	public GTextField level;

	public GImage n31;

	public UI_soldierFormationInfoBack soldierFormationInfoBack;

	public GImage n37;

	public GGraph totalTextBack;

	public GTextField total;

	public GGroup levelAndNumGroup;

	public GGraph ProgressBarSfxBack;

	public const string URL = "ui://e3srq2g9o7r00";

	public static string Name = "UI_DungeonsPanel";

	private List<Building> buildingsList = new List<Building>();

	private List<string> textureList = new List<string>();

	private List<GProgressBar> progressBarList = new List<GProgressBar>();

	public Dungeon myDungeon;

	private List<Building> canUpBuildings = new List<Building>();

	private int oldLevel;

	private int LegionSizeLimit;

	public static string GetURL()
	{
		return "ui://e3srq2g9o7r00";
	}

	public static UI_DungeonsPanel CreateInstance()
	{
		return (UI_DungeonsPanel)(object)UIPackage.CreateObject("Dungeons", "DungeonsPanel");
	}

	public static UI_DungeonsPanel CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_DungeonsPanel).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://e3srq2g9o7r00", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Expected O, but got Unknown
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		//IL_0061: Expected O, but got Unknown
		//IL_006d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0077: Expected O, but got Unknown
		//IL_0083: Unknown result type (might be due to invalid IL or missing references)
		//IL_008d: Expected O, but got Unknown
		//IL_0099: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a3: Expected O, but got Unknown
		//IL_00af: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b9: Expected O, but got Unknown
		//IL_00c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cf: Expected O, but got Unknown
		//IL_00db: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e5: Expected O, but got Unknown
		//IL_00f1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fb: Expected O, but got Unknown
		//IL_0107: Unknown result type (might be due to invalid IL or missing references)
		//IL_0111: Expected O, but got Unknown
		//IL_0133: Unknown result type (might be due to invalid IL or missing references)
		//IL_013d: Expected O, but got Unknown
		//IL_0186: Unknown result type (might be due to invalid IL or missing references)
		//IL_0190: Expected O, but got Unknown
		//IL_01b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_01bc: Expected O, but got Unknown
		//IL_01c8: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d2: Expected O, but got Unknown
		//IL_01de: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e8: Expected O, but got Unknown
		//IL_0231: Unknown result type (might be due to invalid IL or missing references)
		//IL_023b: Expected O, but got Unknown
		//IL_0247: Unknown result type (might be due to invalid IL or missing references)
		//IL_0251: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		background = (GLoader)((GComponent)this).GetChild("background");
		Title = (UI_Title)(object)((GComponent)this).GetChild("Title");
		addWorkerBtn = (GComponent)((GComponent)this).GetChild("addWorkerBtn");
		backBtn = (GButton)((GComponent)this).GetChild("backBtn");
		n21 = (GImage)((GComponent)this).GetChild("n21");
		n42 = (GImage)((GComponent)this).GetChild("n42");
		n43 = (GImage)((GComponent)this).GetChild("n43");
		backgroup = (GGroup)((GComponent)this).GetChild("backgroup");
		dungeonSizeBtn = (GButton)((GComponent)this).GetChild("dungeonSizeBtn");
		sizeGroup = (GGroup)((GComponent)this).GetChild("sizeGroup");
		buildingList = (GList)((GComponent)this).GetChild("buildingList");
		levleSFXBack = (GGraph)((GComponent)this).GetChild("levleSFXBack");
		levelProgress = (UI_DungeonLevel)(object)((GComponent)this).GetChild("levelProgress");
		level = (GTextField)((GComponent)this).GetChild("level");
		string id = "ui://e3srq2g9o7r00".Replace("ui://", "") + "-" + ((GObject)level).id;
		((GObject)level).text = LanguagesManager.GetDesc(id);
		n31 = (GImage)((GComponent)this).GetChild("n31");
		soldierFormationInfoBack = (UI_soldierFormationInfoBack)(object)((GComponent)this).GetChild("soldierFormationInfoBack");
		n37 = (GImage)((GComponent)this).GetChild("n37");
		totalTextBack = (GGraph)((GComponent)this).GetChild("totalTextBack");
		total = (GTextField)((GComponent)this).GetChild("total");
		string id2 = "ui://e3srq2g9o7r00".Replace("ui://", "") + "-" + ((GObject)total).id;
		((GObject)total).text = LanguagesManager.GetDesc(id2);
		levelAndNumGroup = (GGroup)((GComponent)this).GetChild("levelAndNumGroup");
		ProgressBarSfxBack = (GGraph)((GComponent)this).GetChild("ProgressBarSfxBack");
	}

	public void Init(Dictionary<string, object> parameters)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0053: Unknown result type (might be due to invalid IL or missing references)
		//IL_0058: Unknown result type (might be due to invalid IL or missing references)
		//IL_0080: Unknown result type (might be due to invalid IL or missing references)
		//IL_0085: Unknown result type (might be due to invalid IL or missing references)
		FGUIManager.SetUiPanelSizeAndXy((GObject)(object)this);
		addWorkerBtn.GetChild("CurrentWorkerAmount").asTextField.strokeColor = Color32.op_Implicit(new Color32((byte)0, (byte)0, (byte)0, (byte)153));
		addWorkerBtn.GetChild("separate").asTextField.strokeColor = Color32.op_Implicit(new Color32((byte)0, (byte)0, (byte)0, (byte)153));
		addWorkerBtn.GetChild("AllWorkerAmount").asTextField.strokeColor = Color32.op_Implicit(new Color32((byte)0, (byte)0, (byte)0, (byte)153));
		myDungeon = GameController.Contexts.game.dungeon.value;
		((GObject)this).sortingOrder = 1;
		SetBuildingName();
		UpdateWorkerNum();
		PanelInit();
		UpdateBuildingsDemand(1);
	}

	public void RegisterUiEventListeners()
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected O, but got Unknown
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_003a: Expected O, but got Unknown
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		//IL_0061: Expected O, but got Unknown
		//IL_0082: Unknown result type (might be due to invalid IL or missing references)
		//IL_008c: Expected O, but got Unknown
		//IL_009f: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a9: Expected O, but got Unknown
		//IL_00bc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c6: Expected O, but got Unknown
		//IL_014c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0156: Expected O, but got Unknown
		//IL_0169: Unknown result type (might be due to invalid IL or missing references)
		//IL_0173: Expected O, but got Unknown
		((GObject)backBtn).onClick.Add(new EventCallback0(End));
		((GObject)addWorkerBtn).onClick.Add(new EventCallback0(OpenWorkerOverview));
		addWorkerBtn.GetChild("addButton").onClick.Add(new EventCallback1(WorkerAddClick));
		addWorkerBtn.GetChild("ExclamationMarkBtn").onClick.Add(new EventCallback1(FGUIManager.Instance.OpenExclamationMarkPanel));
		((GObject)dungeonSizeBtn).onClick.Add(new EventCallback0(OpenDevilUi));
		((GObject)soldierFormationInfoBack).onClick.Add(new EventCallback0(OpenSoldierInfoPanel));
		SharedMessenger.AddListener<Building>("WORKERS_ALLOCATION_DISPLAY_CHANGED", UpdateWorkerNum);
		SharedMessenger.AddListener<string>("BUILDING_CONSTRUCTING_COMPLETE", RefreshPanel);
		SharedMessenger.AddListener<string, BuildingConstructingConfig>("BUILDING_START_UPGRADING", RefreshPanelByEvent);
		SharedMessenger.AddListener<Cache_PrinceRedDot>(Cache_PrinceRedDot.ON_PAGE_REDDOT_CHANGE, OnPageRedDotChange);
		SharedMessenger.AddListener("OPEN_WORKER_OVERVIEW_PANEL", OpenWorkerOverview);
		Timers.inst.Add(1f, 0, new TimerCallback(UpdateProgressBar));
		Timers.inst.Add(1f, 0, new TimerCallback(UpdateBuildingsDemand));
	}

	public void UnregisterUiEventListeners()
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected O, but got Unknown
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_003a: Expected O, but got Unknown
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		//IL_0061: Expected O, but got Unknown
		//IL_0082: Unknown result type (might be due to invalid IL or missing references)
		//IL_008c: Expected O, but got Unknown
		//IL_009f: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a9: Expected O, but got Unknown
		//IL_00bc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c6: Expected O, but got Unknown
		//IL_0146: Unknown result type (might be due to invalid IL or missing references)
		//IL_0150: Expected O, but got Unknown
		//IL_015d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0167: Expected O, but got Unknown
		((GObject)backBtn).onClick.Remove(new EventCallback0(End));
		((GObject)addWorkerBtn).onClick.Remove(new EventCallback0(OpenWorkerOverview));
		addWorkerBtn.GetChild("addButton").onClick.Remove(new EventCallback1(WorkerAddClick));
		addWorkerBtn.GetChild("ExclamationMarkBtn").onClick.Remove(new EventCallback1(FGUIManager.Instance.OpenExclamationMarkPanel));
		((GObject)dungeonSizeBtn).onClick.Remove(new EventCallback0(OpenDevilUi));
		((GObject)soldierFormationInfoBack).onClick.Remove(new EventCallback0(OpenSoldierInfoPanel));
		SharedMessenger.RemoveListener<Building>("WORKERS_ALLOCATION_DISPLAY_CHANGED", UpdateWorkerNum);
		SharedMessenger.RemoveListener<string>("BUILDING_CONSTRUCTING_COMPLETE", RefreshPanel);
		SharedMessenger.RemoveListener<string, BuildingConstructingConfig>("BUILDING_START_UPGRADING", RefreshPanelByEvent);
		SharedMessenger.RemoveListener<Cache_PrinceRedDot>(Cache_PrinceRedDot.ON_PAGE_REDDOT_CHANGE, OnPageRedDotChange);
		SharedMessenger.RemoveListener("OPEN_WORKER_OVERVIEW_PANEL", OpenWorkerOverview);
		Timers.inst.Remove(new TimerCallback(UpdateProgressBar));
		Timers.inst.Remove(new TimerCallback(UpdateBuildingsDemand));
	}

	public void BeforeDestroy()
	{
	}

	public void Destroy()
	{
		UiTagManager instance = UiTagManager.Instance;
		instance.Unregister("DungeonPanel.BuildingCard");
		instance.Unregister("DungeonPanel.BuildingRepairBtn");
		instance.Unregister("DungeonPanel.BuildingUpgradeBtn");
		instance.Unregister("DungeonPanel.BuildingAcceptBtn");
		UiAudioManager.Instance.SetMainCityBgmVolume(UiAudioManager.Instance.MaxUiBgmVolume);
	}

	public void OnShow()
	{
		UiAudioManager.Instance.SetMainCityBgmVolume(UiAudioManager.Instance.MiddleBgmVolume);
	}

	public void PlayProgressBarSfx()
	{
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_003d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_0089: Unknown result type (might be due to invalid IL or missing references)
		//IL_008e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0093: Unknown result type (might be due to invalid IL or missing references)
		//IL_0095: Unknown result type (might be due to invalid IL or missing references)
		//IL_0096: Unknown result type (might be due to invalid IL or missing references)
		//IL_009b: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c4: Expected O, but got Unknown
		((GObject)ProgressBarSfxBack).relations.ClearAll();
		Vector2 val = default(Vector2);
		((Vector2)(ref val))._002Ector(((GObject)this).width / 2f, ((GObject)this).height / 2f);
		((GObject)ProgressBarSfxBack).SetXY(val.x, val.y);
		FGUIManager.Instance.AddTextSpecialEffects(ProgressBarSfxBack, "exp_missile_green", new Vector3(80f, 80f, 80f));
		Vector2 val2 = ((GObject)levelProgress.SfxBack).LocalToGlobal(Vector2.zero);
		val2 = ((GObject)this).GlobalToLocal(val2);
		((GObject)ProgressBarSfxBack).TweenMove(val2, 0.44f).SetEase((EaseType)5).OnComplete((GTweenCallback)delegate
		{
			((GObject)ProgressBarSfxBack).AddRelation((GObject)(object)levelProgress.bar, (RelationType)6);
			RefreshPanel("1");
		});
	}

	private void SetBuildingName()
	{
		((GObject)Title.buildingName).text = LanguagesManager.GetDesc("CsharpCodeZhTcText189");
	}

	public void SetTitleRedPoint()
	{
		((GComponent)dungeonSizeBtn).GetChild("redPoint").visible = CacheManager.Instance.Get<Cache_PrinceRedDot>().HasPageRedDot(AchievementCat.Dungeon);
	}

	private void OnPageRedDotChange(Cache_PrinceRedDot cache)
	{
		SetTitleRedPoint();
	}

	private void BuildingItemRender(int index, GObject obj)
	{
		//IL_0245: Unknown result type (might be due to invalid IL or missing references)
		//IL_024a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0270: Unknown result type (might be due to invalid IL or missing references)
		//IL_0275: Unknown result type (might be due to invalid IL or missing references)
		//IL_0dc0: Unknown result type (might be due to invalid IL or missing references)
		//IL_0dca: Expected O, but got Unknown
		//IL_0de7: Unknown result type (might be due to invalid IL or missing references)
		//IL_0df1: Expected O, but got Unknown
		//IL_0e0e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e18: Expected O, but got Unknown
		GComponent asCom = obj.asCom;
		Building building = buildingsList[index];
		asCom.GetChild("title").text = building.Name;
		int count = BuildingManager.GetEvoData(building.BuildingType).Count;
		if (building.Level > 0)
		{
			((GObject)asCom.GetChild("buildingLevel").asTextField).text = LanguagesManager.GetDesc("CsharpCodeZhTcText194") + ":";
			if (building.BuildingType == "14" || building.BuildingType == "16")
			{
				((GObject)asCom.GetChild("cueLevel").asTextField).text = $"{building.Level}/1";
			}
			else
			{
				((GObject)asCom.GetChild("cueLevel").asTextField).text = $"{building.Level}/{count}";
			}
		}
		else
		{
			((GObject)asCom.GetChild("buildingLevel").asTextField).text = LanguagesManager.GetDesc("CsharpCodeZhTcText190");
			((GObject)asCom.GetChild("cueLevel").asTextField).text = "";
		}
		string text = ((building.Status != BuildingStatus.Banned) ? ("Building" + building.BuildingType) : "NotRepair");
		asCom.GetChild("buildingIcon").asLoader.url = "ui://PublicResources/" + text;
		asCom.GetChild("buildingBack").asLoader.url = "ui://PublicResources/kuang_round_stone";
		asCom.GetChild("Left-").visible = false;
		asCom.GetChild("Right-").visible = false;
		((GObject)asCom.GetChild("description").asTextField).text = building.Desc;
		asCom.GetChild("lastSlotIcon").asLoader.color = Color32.op_Implicit(new Color32((byte)80, (byte)40, (byte)10, byte.MaxValue));
		asCom.GetChild("nextSlotIcon").asLoader.color = Color32.op_Implicit(new Color32((byte)80, (byte)40, (byte)10, byte.MaxValue));
		((GObject)asCom.GetChild("LeftContent").asGroup).visible = true;
		((GObject)asCom.GetChild("RightContent").asGroup).visible = true;
		if (building.BuildingType == "10")
		{
			((GObject)asCom.GetChild("lastTitle").asTextField).text = LanguagesManager.GetDesc("CsharpCodeZhTcText191");
			((GObject)asCom.GetChild("nextTitle").asTextField).text = LanguagesManager.GetDesc("CsharpCodeZhTcText191");
			asCom.GetChild("lastSlotIcon").asLoader.url = "ui://PublicResources/出兵位";
			asCom.GetChild("nextSlotIcon").asLoader.url = "ui://PublicResources/出兵位";
			((GObject)asCom.GetChild("lastSlot").asTextField).text = building.SomeLevelSlot(count).ToString();
			((GObject)asCom.GetChild("nextSlot").asTextField).text = building.NextSlot.ToString();
		}
		else if (building.BuildingType == "11")
		{
			((GObject)asCom.GetChild("lastTitle").asTextField).text = LanguagesManager.GetDesc("CsharpCodeZhTcText192");
			((GObject)asCom.GetChild("nextTitle").asTextField).text = LanguagesManager.GetDesc("CsharpCodeZhTcText192");
			asCom.GetChild("lastSlotIcon").asLoader.url = "ui://PublicResources/库存量";
			asCom.GetChild("nextSlotIcon").asLoader.url = "ui://PublicResources/库存量";
			((GObject)asCom.GetChild("lastSlot").asTextField).text = "500%";
			((GObject)asCom.GetChild("nextSlot").asTextField).text = $"{building.NextLevel * 100}%";
		}
		else if (building.Feature == "Mine" || building.Feature == "WorkShop" || building.Feature == "MoltenCore")
		{
			((GObject)asCom.GetChild("lastTitle").asTextField).text = LanguagesManager.GetDesc("CsharpCodeZhTcText193");
			((GObject)asCom.GetChild("nextTitle").asTextField).text = LanguagesManager.GetDesc("CsharpCodeZhTcText193");
			asCom.GetChild("lastSlotIcon").asLoader.url = "ui://PublicResources/工位图标";
			asCom.GetChild("nextSlotIcon").asLoader.url = "ui://PublicResources/工位图标";
			((GObject)asCom.GetChild("lastSlot").asTextField).text = building.SomeLevelSlot(5).ToString();
			((GObject)asCom.GetChild("nextSlot").asTextField).text = building.NextSlot.ToString();
		}
		else if (building.Feature == "BlackMarketer" || building.Feature == "MilitaryIntelligence7" || building.Feature == "GvGExpeditionHallEntrance" || building.Feature == "PVPEntrance")
		{
			((GObject)asCom.GetChild("lastTitle").asTextField).text = "";
			((GObject)asCom.GetChild("nextTitle").asTextField).text = "";
			asCom.GetChild("lastSlotIcon").asLoader.url = "";
			asCom.GetChild("nextSlotIcon").asLoader.url = "";
			((GObject)asCom.GetChild("lastSlot").asTextField).text = "";
			((GObject)asCom.GetChild("nextSlot").asTextField).text = "";
			asCom.GetChild("Left-").visible = true;
			asCom.GetChild("Right-").visible = true;
		}
		else
		{
			((GObject)asCom.GetChild("LeftContent").asGroup).visible = false;
			((GObject)asCom.GetChild("RightContent").asGroup).visible = false;
		}
		if (building.Level >= count)
		{
			((GObject)asCom.GetChild("nextSlotGroup").asGroup).visible = false;
			((GObject)asCom.GetChild("upgradeBtn").asButton).visible = false;
			((GObject)asCom.GetChild("acceptanceBtn").asButton).visible = false;
			((GObject)asCom.GetChild("repairBtn").asButton).visible = false;
			((GObject)asCom.GetChild("maxLevelGroup").asGroup).visible = true;
			asCom.GetChild("Left-").visible = true;
			((GObject)asCom.GetChild("upgradeDemand").asTextField).text = "";
			((GObject)asCom.GetChild("jobSschedule").asProgress).visible = false;
		}
		else
		{
			((GObject)asCom.GetChild("nextSlotGroup").asGroup).visible = true;
			((GObject)asCom.GetChild("maxLevelGroup").asGroup).visible = false;
			((GObject)asCom.GetChild("upgradeDemand").asTextField).text = "";
			if (building.Status == BuildingStatus.Ready || building.Status == BuildingStatus.Constructing)
			{
				((GObject)asCom.GetChild("acceptanceBtn").asButton).visible = true;
				((GObject)asCom.GetChild("upgradeBtn").asButton).visible = false;
				((GObject)asCom.GetChild("repairBtn").asButton).visible = false;
				if (building.Status == BuildingStatus.Constructing)
				{
					BuildingConstructingConfig constructingConfig = building.ConstructingConfig;
					double num = constructingConfig.UpgradeRemainingTime;
					double num2 = building.GetUpgradeTime(constructingConfig.Workers);
					((GObject)asCom.GetChild("jobSschedule").asProgress).visible = true;
					asCom.GetChild("jobSschedule").asProgress.value = (num2 - num) / num2 * 100.0;
					((GObject)((GComponent)asCom.GetChild("jobSschedule").asProgress).GetChild("time").asTextField).text = UiHelper.ParseTime(constructingConfig.UpgradeRemainingTime) ?? "";
					((GObject)asCom.GetChild("acceptanceBtn").asButton).enabled = false;
				}
				else
				{
					((GObject)asCom.GetChild("jobSschedule").asProgress).visible = false;
					((GObject)asCom.GetChild("acceptanceBtn").asButton).enabled = true;
				}
			}
			else
			{
				((GObject)asCom.GetChild("jobSschedule").asProgress).visible = false;
				((GObject)asCom.GetChild("acceptanceBtn").asButton).visible = false;
				if (building.Level == 0)
				{
					((GObject)asCom.GetChild("repairBtn").asButton).visible = true;
					((GObject)asCom.GetChild("upgradeBtn").asButton).visible = false;
					if (building.CanUpgradeForDungeonUI())
					{
						((GObject)asCom.GetChild("repairBtn").asButton).enabled = true;
						((GObject)asCom.GetChild("upgradeDemand").asTextField).text = "";
					}
					else
					{
						((GObject)asCom.GetChild("repairBtn").asButton).enabled = false;
						((GObject)asCom.GetChild("upgradeDemand").asTextField).text = string.Format("{0} {1}", LanguagesManager.GetDesc("CsharpCodeZhTcText50"), GameManagers.Instance.ConfigDataManager.GetUserLevelRequiredForBuildingUpgrade(building.BuildingType, GameManagers.Instance.UserArchiveManager.GetBuildingLevel(building.BuildingType)));
					}
				}
				else
				{
					((GObject)asCom.GetChild("upgradeBtn").asButton).visible = true;
					((GObject)asCom.GetChild("repairBtn").asButton).visible = false;
					if (building.CanUpgradeForDungeonUI())
					{
						((GObject)asCom.GetChild("upgradeBtn").asButton).enabled = true;
						((GObject)asCom.GetChild("upgradeDemand").asTextField).text = "";
					}
					else
					{
						((GObject)asCom.GetChild("upgradeBtn").asButton).enabled = false;
						((GObject)asCom.GetChild("upgradeDemand").asTextField).text = string.Format("{0} {1}", LanguagesManager.GetDesc("CsharpCodeZhTcText50"), GameManagers.Instance.ConfigDataManager.GetUserLevelRequiredForBuildingUpgrade(building.BuildingType, GameManagers.Instance.UserArchiveManager.GetBuildingLevel(building.BuildingType)));
					}
				}
			}
		}
		if (building.Feature == "BlackMarketer" || building.Feature == "MilitaryIntelligence7" || building.Feature == "PVPEntrance")
		{
			if (building.Level >= 1)
			{
				((GObject)asCom.GetChild("upgradeDemand").asTextField).text = "";
				((GObject)asCom.GetChild("maxLevelGroup").asGroup).visible = true;
				((GObject)asCom.GetChild("buttonGroup").asGroup).visible = false;
			}
			else
			{
				((GObject)asCom.GetChild("maxLevelGroup").asGroup).visible = false;
				((GObject)asCom.GetChild("buttonGroup").asGroup).visible = true;
			}
		}
		if (building.Status == BuildingStatus.Banned)
		{
			((GObject)asCom.GetChild("upgradeDemand").asTextField).text = "";
			((GObject)asCom.GetChild("upgradeBtn").asButton).enabled = false;
			((GObject)asCom.GetChild("acceptanceBtn").asButton).enabled = false;
			((GObject)asCom.GetChild("repairBtn").asButton).enabled = false;
		}
		progressBarList.Add(asCom.GetChild("jobSschedule").asProgress);
		((GObject)((GComponent)asCom.GetChild("upgradeBtn").asButton).GetChild("redPoint").asImage).visible = false;
		((GObject)((GComponent)asCom.GetChild("repairBtn").asButton).GetChild("redPoint").asImage).visible = false;
		((GObject)asCom.GetChild("acceptanceBtn").asButton).onClick.Set((EventCallback0)delegate
		{
			CheckAndAccept(building);
		});
		((GObject)asCom.GetChild("upgradeBtn").asButton).onClick.Set((EventCallback0)delegate
		{
			UpgradeAndRepair(building);
		});
		((GObject)asCom.GetChild("repairBtn").asButton).onClick.Set((EventCallback0)delegate
		{
			UpgradeAndRepair(building);
		});
	}

	private void RenderBuildingList()
	{
		//IL_001a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0024: Expected O, but got Unknown
		progressBarList.Clear();
		buildingList.itemRenderer = new ListItemRenderer(BuildingItemRender);
		buildingList.numItems = buildingsList.Count;
		((GComponent)buildingList).EnsureBoundsCorrect();
		UiTagManager instance = UiTagManager.Instance;
		instance.Unregister("DungeonPanel.BuildingCard");
		instance.Unregister("DungeonPanel.BuildingRepairBtn");
		instance.Unregister("DungeonPanel.BuildingUpgradeBtn");
		instance.Unregister("DungeonPanel.BuildingAcceptBtn");
		Dictionary<string, object> dictionary = new Dictionary<string, object>();
		Dictionary<string, object> dictionary2 = new Dictionary<string, object>();
		Dictionary<string, object> dictionary3 = new Dictionary<string, object>();
		Dictionary<string, object> dictionary4 = new Dictionary<string, object>();
		for (int i = 0; i < buildingsList.Count; i++)
		{
			Building building = buildingsList[i];
			GObject childAt = ((GComponent)buildingList).GetChildAt(i);
			if (childAt == null)
			{
				break;
			}
			dictionary.Add(building.BuildingType, childAt);
			dictionary2.Add(building.BuildingType, childAt.asCom.GetChild("repairBtn"));
			dictionary3.Add(building.BuildingType, childAt.asCom.GetChild("upgradeBtn"));
			dictionary4.Add(building.BuildingType, childAt.asCom.GetChild("acceptanceBtn"));
		}
		instance.Register("DungeonPanel.BuildingCard", dictionary);
		instance.Register("DungeonPanel.BuildingRepairBtn", dictionary2);
		instance.Register("DungeonPanel.BuildingUpgradeBtn", dictionary3);
		instance.Register("DungeonPanel.BuildingAcceptBtn", dictionary4);
	}

	private void PanelInit()
	{
		SetTitleRedPoint();
		UpdateDungeonsLevel(isInit: true);
		UpdateSoldierTotalNum(isInit: true);
		SetBuildingCard();
	}

	public void RefreshPanel(string buildingType)
	{
		SetTitleRedPoint();
		UpdateDungeonsLevel();
		UpdateSoldierTotalNum();
		SetBuildingCard();
	}

	public void RefreshPanelByEvent(string buildingType, BuildingConstructingConfig info)
	{
		SetTitleRedPoint();
		UpdateDungeonsLevel(isInit: true);
		UpdateSoldierTotalNum(isInit: true);
		SetBuildingCard();
	}

	public void UpdateWorkerNum(Building building = null)
	{
		//IL_0197: Unknown result type (might be due to invalid IL or missing references)
		//IL_019c: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_013e: Unknown result type (might be due to invalid IL or missing references)
		Dungeon value = GameController.Contexts.game.dungeon.value;
		addWorkerBtn.GetChild("CurrentWorkerAmount").text = $"{Dungeon.GetFreeManPower(GameManagers.Instance)}";
		addWorkerBtn.GetChild("AllWorkerAmount").text = $"{Dungeon.GetTotalManPower(GameManagers.Instance)}";
		if (GameManagers.Instance.LeaseholdManager.GetLeaseholdManPower() > 0)
		{
			addWorkerBtn.GetChild("AllWorkerAmount").asTextField.color = Color32.op_Implicit(new Color32((byte)175, (byte)246, (byte)39, byte.MaxValue));
			addWorkerBtn.GetChild("ExclamationMarkBtn").data = new Dictionary<string, object>
			{
				{
					"Title",
					LanguagesManager.GetDesc("CsharpCodeZhTcText106") + Environment.NewLine + string.Format("{0}：{1}", LanguagesManager.GetDesc("CsharpCodeZhTcText164"), Dungeon.GetTotalManPower(GameManagers.Instance) - GameManagers.Instance.LeaseholdManager.GetLeaseholdManPower())
				},
				{
					"Pos",
					(object)new Vector2(1718f, 88f)
				}
			};
			addWorkerBtn.GetChild("ExclamationMarkBtn").visible = true;
		}
		else
		{
			addWorkerBtn.GetChild("AllWorkerAmount").asTextField.color = Color32.op_Implicit(new Color32((byte)243, (byte)221, (byte)170, byte.MaxValue));
			addWorkerBtn.GetChild("ExclamationMarkBtn").visible = false;
		}
	}

	private void UpdateDungeonsLevel(bool isInit = false)
	{
		//IL_0117: Unknown result type (might be due to invalid IL or missing references)
		//IL_0121: Expected O, but got Unknown
		//IL_0134: Unknown result type (might be due to invalid IL or missing references)
		//IL_013e: Expected O, but got Unknown
		if (isInit)
		{
			oldLevel = GameManagers.Instance.UserArchiveManager.GetDungeonLevel();
		}
		int dungeonLevel = GameManagers.Instance.UserArchiveManager.GetDungeonLevel();
		int dungeonExp = GameManagers.Instance.UserArchiveManager.GetDungeonExp();
		bool flag = dungeonLevel > oldLevel;
		((GObject)level).text = string.Format("{0} {1}", LanguagesManager.GetDesc("CsharpCodeZhTcText194"), dungeonLevel);
		double curLevelExp = GameManagers.Instance.ConfigDataManager.GetDungeonCurLevelExp();
		double curExp = dungeonExp;
		double nextLevelExp = GameManagers.Instance.ConfigDataManager.GetDungeonNextLevelExp();
		double exp = (curExp - curLevelExp) / (nextLevelExp - curLevelExp) * 100.0;
		if (flag)
		{
			oldLevel = dungeonLevel;
			((GProgressBar)levelProgress).TweenValue(100.0, 0.45f);
			((GComponent)(object)this).SetTimeout(0.45f).OnComplete((GTweenCallback)delegate
			{
				//IL_0066: Unknown result type (might be due to invalid IL or missing references)
				((GObject)levelProgress.bar).alpha = 0f;
				((GProgressBar)levelProgress).value = 0.0;
				((GObject)levleSFXBack).displayObject.Dispose();
				FGUIManager.Instance.AddTextSpecialEffects(levleSFXBack, FGUIManager.Instance.uiGreen, Vector3.zero);
			});
			((GComponent)(object)this).SetTimeout(0.45f).OnComplete((GTweenCallback)delegate
			{
				((GObject)levelProgress.bar).alpha = 1f;
				((GProgressBar)levelProgress).TweenValue(exp, 0.45f);
				((GObject)levelProgress.num).text = $"{Convert.ToInt32(curExp - curLevelExp)}/{Convert.ToInt32(nextLevelExp - curLevelExp)}";
			});
		}
		else
		{
			((GProgressBar)levelProgress).TweenValue(exp, 0.45f);
			((GObject)levelProgress.num).text = $"{Convert.ToInt32(curExp - curLevelExp)}/{Convert.ToInt32(nextLevelExp - curLevelExp)}";
		}
	}

	private void UpdateSoldierTotalNum(bool isInit = false)
	{
		//IL_00d6: Unknown result type (might be due to invalid IL or missing references)
		if (isInit)
		{
			LegionSizeLimit = myDungeon.LegionSizeLimit;
		}
		((GObject)total).text = "[size=28][color=#7c4b2a]" + LanguagesManager.GetDesc("CsharpCodeZhTcText195") + "[/color][/size]" + Environment.NewLine + $"[color=#50280a]{myDungeon.LegionSizeLimit}[/color]";
		if (!isInit && myDungeon.LegionSizeLimit > LegionSizeLimit)
		{
			LegionSizeLimit = myDungeon.LegionSizeLimit;
			((GObject)totalTextBack).displayObject.Dispose();
			FGUIManager.Instance.AddTextSpecialEffects(totalTextBack, FGUIManager.Instance.uiGreen, new Vector3(220f, 50f, 50f));
		}
	}

	private void OpenDevilUi()
	{
		Dictionary<string, object> dictionary = new Dictionary<string, object>();
		dictionary.Add("Parent", this);
		dictionary.Add("Index", 1);
		GameController.Contexts.Service<IUiService>().OpenPanel(UI_PrinceOfTheDevilsPanel.Name, dictionary);
	}

	private void WorkerAddClick(EventContext context)
	{
		if (GameManagers.Instance.BuildingManager.GetBuildingByType("16").Level > 0)
		{
			GameController.Contexts.Service<IUiService>().OpenPanel(UI_MonthCardPanel.Name, new Dictionary<string, object>
			{
				{
					"Activity",
					FGUIManager.Instance.GetBlackMarketerActivity("UI_MonthCardPanel")
				},
				{
					"Order",
					((GObject)this).sortingOrder
				},
				{ "Parent", this }
			});
		}
		else
		{
			List<string> arg = new List<string> { LanguagesManager.GetDesc("CsharpCodeZhTcText152") };
			SharedMessenger.Broadcast("SHOW_TIPS", arg, 1, arg3: false);
		}
		context.StopPropagation();
	}

	private void OpenWorkerOverview()
	{
		Dictionary<string, object> dictionary = new Dictionary<string, object>();
		dictionary.Add("Order", ((GObject)this).sortingOrder);
		GameController.Contexts.Service<IUiService>().OpenPanel(UI_WorkersOverviewPanel.Name, dictionary);
	}

	private void CheckAndAccept(Building building)
	{
		Dictionary<string, object> dictionary = new Dictionary<string, object>();
		dictionary.Add("Building", building);
		dictionary.Add("Parent", this);
		GameController.Contexts.Service<IUiService>().OpenPanel(UI_Main_UpGradePanel.Name, dictionary);
	}

	private void UpgradeAndRepair(Building building)
	{
		Dictionary<string, object> dictionary = new Dictionary<string, object>();
		dictionary.Add("Building", GameManagers.Instance.BuildingManager.GetBuildingByType(building.BuildingType));
		dictionary.Add("Parent", this);
		GameController.Contexts.Service<IUiService>().OpenPanel(UI_Main_UpGradePanel.Name, dictionary);
	}

	private void GetBuildingData()
	{
		buildingsList.Clear();
		List<Building> list = new List<Building>();
		List<Building> list2 = new List<Building>();
		canUpBuildings.Clear();
		List<Building> list3 = new List<Building>();
		List<Building> list4 = new List<Building>();
		List<Building> list5 = new List<Building>();
		List<List<Building>> list6 = new List<List<Building>> { list, list2, canUpBuildings, list3, list5, list4 };
		foreach (KeyValuePair<string, Building> building in myDungeon.Buildings)
		{
			string buildingType = building.Value.BuildingType;
			int buildingMaxLevel = GameManagers.Instance.UserArchiveManager.GetBuildingMaxLevel(buildingType);
			if (!(buildingType == "15"))
			{
				if (building.Value.Status == BuildingStatus.Ready)
				{
					list.Add(building.Value);
				}
				else if (building.Value.Status == BuildingStatus.Constructing)
				{
					list2.Add(building.Value);
				}
				else if (building.Value.Status == BuildingStatus.Banned)
				{
					list4.Add(building.Value);
				}
				else if (building.Value.Level == buildingMaxLevel || ((buildingType == "14" || buildingType == "16") && building.Value.Level == 1))
				{
					list5.Add(building.Value);
				}
				else if (building.Value.CanUpgradeForDungeonUI())
				{
					canUpBuildings.Add(building.Value);
				}
				else
				{
					list3.Add(building.Value);
				}
			}
		}
		for (int i = 0; i < list6.Count; i++)
		{
			list6[i].Sort(SortBuildingCard);
		}
		for (int j = 0; j < list6.Count; j++)
		{
			for (int k = 0; k < list6[j].Count; k++)
			{
				buildingsList.Add(list6[j][k]);
			}
		}
	}

	public void SetBuildingCard()
	{
		GetBuildingData();
		RenderBuildingList();
	}

	public int SortBuildingCard(Building a, Building b)
	{
		int buildingLevel = GameManagers.Instance.UserArchiveManager.GetBuildingLevel(a.BuildingType);
		int buildingLevel2 = GameManagers.Instance.UserArchiveManager.GetBuildingLevel(b.BuildingType);
		return GameManagers.Instance.ConfigDataManager.GetUserLevelRequiredForBuildingUpgrade(a.BuildingType, buildingLevel).CompareTo(GameManagers.Instance.ConfigDataManager.GetUserLevelRequiredForBuildingUpgrade(b.BuildingType, buildingLevel2));
	}

	private void UpdateProgressBar(object param)
	{
		for (int i = 0; i < progressBarList.Count; i++)
		{
			if (((GObject)progressBarList[i]).visible)
			{
				BuildingConstructingConfig constructingConfig = buildingsList[i].ConstructingConfig;
				double num = constructingConfig.UpgradeRemainingTime;
				double num2 = buildingsList[i].GetUpgradeTime(constructingConfig.Workers);
				progressBarList[i].TweenValue((num2 - num) / num2 * 100.0, 1f);
				((GObject)((GComponent)progressBarList[i]).GetChild("time").asTextField).text = UiHelper.ParseTime(constructingConfig.UpgradeRemainingTime) ?? "";
			}
		}
	}

	private void UpdateBuildingsDemand(object param)
	{
		if (canUpBuildings.Count == 0)
		{
			return;
		}
		for (int i = 0; i < canUpBuildings.Count; i++)
		{
			int num = buildingsList.IndexOf(canUpBuildings[i]);
			if (num != -1)
			{
				GButton asButton = ((GComponent)buildingList).GetChildAt(num).asCom.GetChild("upgradeBtn").asButton;
				GButton asButton2 = ((GComponent)buildingList).GetChildAt(num).asCom.GetChild("repairBtn").asButton;
				if (canUpBuildings[i].CheckUpgradeResourceRequirement() && canUpBuildings[i].CheckUpgradeStorylineLevelRequirement())
				{
					((GObject)((GComponent)asButton).GetChild("redPoint").asImage).visible = true;
					((GObject)((GComponent)asButton2).GetChild("redPoint").asImage).visible = true;
				}
				else
				{
					((GObject)((GComponent)asButton).GetChild("redPoint").asImage).visible = false;
					((GObject)((GComponent)asButton2).GetChild("redPoint").asImage).visible = false;
				}
			}
		}
	}

	private void OpenSoldierInfoPanel()
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		//IL_0019: Unknown result type (might be due to invalid IL or missing references)
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Unknown result type (might be due to invalid IL or missing references)
		//IL_0036: Unknown result type (might be due to invalid IL or missing references)
		Vector2 val = ((GObject)soldierFormationInfoBack).LocalToGlobal(Vector2.zero);
		val = ((GObject)this).GlobalToLocal(val);
		Dictionary<string, object> dictionary = new Dictionary<string, object>();
		dictionary.Add("DialogPos", val + new Vector2(0f, 110f));
		GameController.Contexts.Service<IUiService>().OpenPanel(UI_SoldierFormationInfoPanel.Name, dictionary);
	}

	public void End()
	{
		GameController.Contexts.Service<IUiService>().ClosePanel(Name);
		for (int i = 0; i < textureList.Count; i++)
		{
			AssetsManager.Instance.UnloadAsset<Texture2D>(textureList[i]);
		}
	}
}
