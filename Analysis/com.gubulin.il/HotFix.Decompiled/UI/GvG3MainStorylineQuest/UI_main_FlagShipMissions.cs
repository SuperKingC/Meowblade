using System;
using System.Collections.Generic;
using Assets.Scripts.UI;
using FairyGUI;
using FairyGUI.Utils;
using HotFix.Sources.Base.Scripts.Helper;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Manager;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Model;
using HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Helper;
using HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Manager;
using Shift.Legion.Common.Helpers;
using Shift.Legion.Common.Managers;
using Shift.Legion.Common.Models;
using Shift.Legion.Common.Services;
using Shift.Legion.Common.Sources.Enums;
using Shift.Legion.GvGServer.Models.GvGMode3IslandManagerSocket;
using UnityEngine;

namespace UI.GvG3MainStorylineQuest;

public class UI_main_FlagShipMissions : GComponent, IUiController
{
	public Controller PageController;

	public Controller Type;

	public Controller StoryType;

	public GLoader background;

	public GButton BackBtn;

	public UI_com_Title Title;

	public GButton Help;

	public UI_com_SideQuests SideQuest;

	public GImage n7;

	public UI_com_MainMissionStep CurrentStep;

	public UI_com_RankingRewards RankingRewards;

	public UI_com_LandOfEternalNightStep LandOfEternalNightSteps;

	public UI_com_CampEnergy CampEnergy;

	public UI_com_WaitNight WaitLandOfNihgt;

	public UI_com_LandOfEternalNightRanks LandOfEternalNightCampRanks;

	public UI_com_CampShadowEnergy LandOfEternalNightMission;

	public GGroup Story1;

	public UI_com_LandOfEternalNightStep2 LandOfEternalNightSteps2;

	public UI_com_CampEnergy2 CampEnergy2;

	public UI_com_BrawlWaitNight WaitLandOfNihgt2;

	public UI_com_LandOfEternalNightRanks2 LandOfEternalNightCampRanks2;

	public GGroup Story2;

	public UI_btn_Page01 LastProgress;

	public UI_btn_Page02 NextProgress;

	public const string URL = "ui://249h3k3dqf7c19";

	public static string Name = "UI_main_FlagShipMissions";

	private bool _isBrawlEvent;

	public static string GetURL()
	{
		return "ui://249h3k3dqf7c19";
	}

	public static UI_main_FlagShipMissions CreateInstance()
	{
		return (UI_main_FlagShipMissions)(object)UIPackage.CreateObject("GvG3MainStorylineQuest", "main_FlagShipMissions");
	}

	public static UI_main_FlagShipMissions CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_main_FlagShipMissions).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://249h3k3dqf7c19", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0048: Unknown result type (might be due to invalid IL or missing references)
		//IL_0052: Expected O, but got Unknown
		//IL_005e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0068: Expected O, but got Unknown
		//IL_008a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0094: Expected O, but got Unknown
		//IL_00b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c0: Expected O, but got Unknown
		//IL_0166: Unknown result type (might be due to invalid IL or missing references)
		//IL_0170: Expected O, but got Unknown
		//IL_01d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_01de: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		PageController = ((GComponent)this).GetController("PageController");
		Type = ((GComponent)this).GetController("Type");
		StoryType = ((GComponent)this).GetController("StoryType");
		background = (GLoader)((GComponent)this).GetChild("background");
		BackBtn = (GButton)((GComponent)this).GetChild("BackBtn");
		Title = (UI_com_Title)(object)((GComponent)this).GetChild("Title");
		Help = (GButton)((GComponent)this).GetChild("Help");
		SideQuest = (UI_com_SideQuests)(object)((GComponent)this).GetChild("SideQuest");
		n7 = (GImage)((GComponent)this).GetChild("n7");
		CurrentStep = (UI_com_MainMissionStep)(object)((GComponent)this).GetChild("CurrentStep");
		RankingRewards = (UI_com_RankingRewards)(object)((GComponent)this).GetChild("RankingRewards");
		LandOfEternalNightSteps = (UI_com_LandOfEternalNightStep)(object)((GComponent)this).GetChild("LandOfEternalNightSteps");
		CampEnergy = (UI_com_CampEnergy)(object)((GComponent)this).GetChild("CampEnergy");
		WaitLandOfNihgt = (UI_com_WaitNight)(object)((GComponent)this).GetChild("WaitLandOfNihgt");
		LandOfEternalNightCampRanks = (UI_com_LandOfEternalNightRanks)(object)((GComponent)this).GetChild("LandOfEternalNightCampRanks");
		LandOfEternalNightMission = (UI_com_CampShadowEnergy)(object)((GComponent)this).GetChild("LandOfEternalNightMission");
		Story1 = (GGroup)((GComponent)this).GetChild("Story1");
		LandOfEternalNightSteps2 = (UI_com_LandOfEternalNightStep2)(object)((GComponent)this).GetChild("LandOfEternalNightSteps2");
		CampEnergy2 = (UI_com_CampEnergy2)(object)((GComponent)this).GetChild("CampEnergy2");
		WaitLandOfNihgt2 = (UI_com_BrawlWaitNight)(object)((GComponent)this).GetChild("WaitLandOfNihgt2");
		LandOfEternalNightCampRanks2 = (UI_com_LandOfEternalNightRanks2)(object)((GComponent)this).GetChild("LandOfEternalNightCampRanks2");
		Story2 = (GGroup)((GComponent)this).GetChild("Story2");
		LastProgress = (UI_btn_Page01)(object)((GComponent)this).GetChild("LastProgress");
		NextProgress = (UI_btn_Page02)(object)((GComponent)this).GetChild("NextProgress");
	}

	public void BeforeDestroy()
	{
		if (!_isBrawlEvent)
		{
			CampEnergy.Destroy();
			LandOfEternalNightSteps.Destroy();
			WaitLandOfNihgt.Destroy();
			LandOfEternalNightCampRanks.Destroy();
		}
		else
		{
			CampEnergy2.Destroy();
			LandOfEternalNightSteps2.Destroy();
			WaitLandOfNihgt2.Destroy();
			LandOfEternalNightCampRanks2.Destroy();
		}
		RankingRewards.Destroy();
		SideQuest.Destroy();
		CurrentStep.Destroy();
		LandOfEternalNightMission.Destroy();
	}

	public void Destroy()
	{
	}

	public void Init(Dictionary<string, object> parameters)
	{
		FGUIManager.SetUiPanelSizeAndXy((GObject)(object)this);
		_isBrawlEvent = WorldMapConfigHelper.Configs.IsBrawlEvent();
		StoryType.SetSelectedIndex(_isBrawlEvent ? 1 : 0);
		if (!_isBrawlEvent)
		{
			CampEnergy.Init();
			LandOfEternalNightSteps.Init();
			WaitLandOfNihgt.Init();
			LandOfEternalNightCampRanks.Init();
		}
		else
		{
			CampEnergy2.Init();
			LandOfEternalNightSteps2.Init();
			WaitLandOfNihgt2.Init();
			LandOfEternalNightCampRanks2.Init();
		}
		RankingRewards.Init();
		CurrentStep.Init();
		LandOfEternalNightMission.Init();
		SideQuest.Init();
	}

	public void OnShow()
	{
		UpdateUiData(0, currentProgress: true);
	}

	public void RegisterUiEventListeners()
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected O, but got Unknown
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_003a: Expected O, but got Unknown
		//IL_0107: Unknown result type (might be due to invalid IL or missing references)
		//IL_0111: Expected O, but got Unknown
		//IL_0135: Unknown result type (might be due to invalid IL or missing references)
		//IL_013f: Expected O, but got Unknown
		((GObject)BackBtn).onClick.Set(new EventCallback0(End));
		((GObject)Help).onClick.Set(new EventCallback0(OnHelpClick));
		if (!WorldMapConfigHelper.Configs.IsBrawlEvent())
		{
			CampEnergy.RegisterUiEvent();
			LandOfEternalNightSteps.RegisterUiEvent();
			WaitLandOfNihgt.RegisterUiEvent();
			LandOfEternalNightCampRanks.RegisterUiEvent();
		}
		else
		{
			CampEnergy2.RegisterUiEvent();
			LandOfEternalNightSteps2.RegisterUiEvent();
			WaitLandOfNihgt2.RegisterUiEvent();
			LandOfEternalNightCampRanks2.RegisterUiEvent();
		}
		RankingRewards.RegisterUiEvent();
		SideQuest.RegisterUiEvent();
		CurrentStep.RegisterUiEvent();
		LandOfEternalNightMission.RegisterUiEvent();
		((GObject)LastProgress).data = -1;
		((GObject)LastProgress).onClick.Set(new EventCallback1(ChangeCheckProgress));
		((GObject)NextProgress).data = 1;
		((GObject)NextProgress).onClick.Set(new EventCallback1(ChangeCheckProgress));
		UI_com_MainMissionStep currentStep = CurrentStep;
		currentStep.CloseMainUi = (Action)Delegate.Combine(currentStep.CloseMainUi, new Action(End));
		GvG3FlagShipMissionsManager instance = Singleton<GvG3FlagShipMissionsManager>.Instance;
		instance.RenderPage = (Action<CampProgressRedDot>)Delegate.Combine(instance.RenderPage, new Action<CampProgressRedDot>(UpdatePage));
		WorldStateManager instance2 = Singleton<WorldStateManager>.Instance;
		instance2.OnGainPointsThroughMission = (Action<ContributionPointsChanged>)Delegate.Combine(instance2.OnGainPointsThroughMission, new Action<ContributionPointsChanged>(OnPointsChange));
		SharedMessenger.AddListener("ON_GVG3_ETERNALNIGHT_TRANSITION_PLAYED", UpdateUiOnUserCheckBossAppear);
		SharedMessenger.AddListener<string, int, (StockInContext, string)>("ON_STOCK_CHANGE", OnStockChange);
	}

	public void UnregisterUiEventListeners()
	{
		((GObject)BackBtn).onClick.Clear();
		((GObject)Help).onClick.Clear();
		if (!_isBrawlEvent)
		{
			CampEnergy.UnregisterUiEvent();
			LandOfEternalNightSteps.UnregisterUiEvent();
			WaitLandOfNihgt.UnregisterUiEvent();
			LandOfEternalNightCampRanks.UnregisterUiEvent();
		}
		else
		{
			CampEnergy2.UnregisterUiEvent();
			LandOfEternalNightSteps2.UnregisterUiEvent();
			WaitLandOfNihgt2.UnregisterUiEvent();
			LandOfEternalNightCampRanks2.UnregisterUiEvent();
		}
		RankingRewards.UnregisterUiEvent();
		CurrentStep.UnregisterUiEvent();
		SideQuest.UnregisterUiEvent();
		LandOfEternalNightMission.UnregisterUiEvent();
		((GObject)LastProgress).onClick.Clear();
		((GObject)NextProgress).onClick.Clear();
		UI_com_MainMissionStep currentStep = CurrentStep;
		currentStep.CloseMainUi = (Action)Delegate.Remove(currentStep.CloseMainUi, new Action(End));
		GvG3FlagShipMissionsManager instance = Singleton<GvG3FlagShipMissionsManager>.Instance;
		instance.RenderPage = (Action<CampProgressRedDot>)Delegate.Remove(instance.RenderPage, new Action<CampProgressRedDot>(UpdatePage));
		WorldStateManager instance2 = Singleton<WorldStateManager>.Instance;
		instance2.OnGainPointsThroughMission = (Action<ContributionPointsChanged>)Delegate.Remove(instance2.OnGainPointsThroughMission, new Action<ContributionPointsChanged>(OnPointsChange));
		SharedMessenger.RemoveListener("ON_GVG3_ETERNALNIGHT_TRANSITION_PLAYED", UpdateUiOnUserCheckBossAppear);
		SharedMessenger.RemoveListener<string, int, (StockInContext, string)>("ON_STOCK_CHANGE", OnStockChange);
	}

	private void End()
	{
		GameController.Contexts.Service<IUiService>().ClosePanel(Name);
	}

	private void OnHelpClick()
	{
		UiHelper.OpenHelpPage("旗舰任务", "远征相关", "旗舰任务");
	}

	private void ChangeCheckProgress(EventContext context)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		int progress = (int)((GObject)context.sender).data;
		UpdateUiData(progress);
	}

	private void UpdateUiOnUserCheckBossAppear()
	{
		UpdateUiData(0, currentProgress: true);
	}

	private void UpdateUiData(int progress = 0, bool currentProgress = false)
	{
		Singleton<GvG3FlagShipMissionsManager>.Instance.GetMissions(progress, currentProgress);
		if (Singleton<GvG3FlagShipMissionsManager>.Instance.IsWaitEternalNight)
		{
			if (!_isBrawlEvent)
			{
				WaitLandOfNihgt.Render();
			}
			else
			{
				WaitLandOfNihgt2.Render();
			}
		}
		else if (Singleton<GvG3FlagShipMissionsManager>.Instance.IsEternalNightProgress)
		{
			if (!_isBrawlEvent)
			{
				Singleton<GvG3FlagShipMissionsManager>.Instance.GetFinalProgressRank();
				LandOfEternalNightMission.Render();
			}
		}
		else
		{
			Singleton<GvG3FlagShipMissionsManager>.Instance.GetCampEnergy();
		}
	}

	private void UpdatePage(CampProgressRedDot redDotData)
	{
		bool flag = !Singleton<GvG3FlagShipMissionsManager>.Instance.EternalNightOpen && Singleton<GvG3FlagShipMissionsManager>.Instance.IsEternalNight && !Singleton<GvG3FlagShipMissionsManager>.Instance.HasSettlement;
		int campProgress = Singleton<WorldStateManager>.Instance.Data.ProgressData.CampProgress;
		int num = (flag ? (campProgress - 1) : campProgress);
		int campProgress2 = redDotData.CampProgress;
		if (num == 1)
		{
			PageController.selectedIndex = 3;
		}
		else if (campProgress2 <= 1)
		{
			PageController.selectedIndex = 0;
		}
		else if (campProgress2 >= num)
		{
			PageController.selectedIndex = 2;
		}
		else
		{
			PageController.selectedIndex = 1;
		}
		((GObject)LastProgress.RedDot).visible = redDotData.HasLastProgressRedDot();
		((GObject)NextProgress.RedDot).visible = redDotData.HasNextProgressRedDot();
		SetPanelType();
	}

	private void SetPanelType()
	{
		bool isEternalNightProgress = Singleton<GvG3FlagShipMissionsManager>.Instance.IsEternalNightProgress;
		bool isWaitEternalNightProgress = Singleton<GvG3FlagShipMissionsManager>.Instance.IsWaitEternalNightProgress;
		if (Singleton<GvG3FlagShipMissionsManager>.Instance.HasSettlement && isEternalNightProgress)
		{
			Type.selectedIndex = 2;
		}
		else if (isWaitEternalNightProgress)
		{
			Type.selectedIndex = 1;
		}
		else if (isEternalNightProgress)
		{
			Type.selectedIndex = 2;
		}
		else
		{
			Type.selectedIndex = 0;
		}
	}

	private void OnStockChange(string itemId, int incr, (StockInContext, string) contextTuple)
	{
		if (incr > 0 && CanShow())
		{
			FGUIManager.Instance.ItemIdReplace(ref itemId);
			ILRequestHelper.ShowMessage($"{Item.Name(GameManagers.Instance, itemId)}+{incr}");
		}
		bool CanShow()
		{
			StockInContext item = contextTuple.Item1;
			return item == StockInContext.GvGMode3Mission_CampMain || item == StockInContext.GvGMode3Mission_CampSide || item == StockInContext.GvGMode3CampMainMissionBonusByRank;
		}
	}

	private void OnPointsChange(ContributionPointsChanged pointsChanged)
	{
		string.Format("{0}+{1}", Item.Name(GameManagers.Instance, "I65001"), Mathf.RoundToInt(pointsChanged.ChangedValue)).ToTip();
	}
}
