using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Assets.Scripts.UI;
using FairyGUI;
using FairyGUI.Utils;
using HotFix.Sources.Base.Sources.Scripts.GvG3Common.Model.OuterTech;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Manager;
using HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Helper;
using HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Manager;
using Shift.Legion.Common.Helpers;
using Shift.Legion.Common.Services;
using Shift.Legion.GvG.Common.Models.GvGMode3.Mission;
using Shift.Legion.GvGServer.Models.GvGMode3IslandManagerSocket.Mission;
using UI.GvG3Leaderboard;
using UI.GvG3MainStorylineQuest;
using UI.GvG3SplitBluePrint;
using UI.GvG3SupplyDepot;
using UI.GvGBrawlFight;
using UI.GvGExchange3;
using UI.GvGPurification3;
using UI.GvGWorldMap3;
using UnityEngine;

namespace UI.GvGFlagship3;

public class UI_main_GvGFlagshipPanel : GComponent, IUiController
{
	public Controller StoryType;

	public GLoader background;

	public GButton BackBtn;

	public UI_com_Title Title;

	public UI_btn_exchange OEMMissions;

	public UI_btn_purification Purification;

	public UI_btn_DailyReward DailyReward;

	public UI_btn_FoodSupply FoodSupply;

	public UI_btn_Leaderboard LeaderboardBtn;

	public UI_com_TransitionStage TransitionStage;

	public UI_btn_02 Missions;

	public UI_btn_01 FlagShipCannonBtn;

	public UI_btn_RequirementTasks RequirementTasks;

	public UI_btn_SplitBluePrint SplitBlueprint;

	public UI_btn_BrawlFightEntrance brawlFightBtn;

	public GButton HelpBtn;

	public const string URL = "ui://tvr786zldwxt0";

	public static string Name = "UI_main_GvGFlagshipPanel";

	private C2S_BrawlEvent_GetInfo.Response _brawlEventInfo;

	public static string GetURL()
	{
		return "ui://tvr786zldwxt0";
	}

	public static UI_main_GvGFlagshipPanel CreateInstance()
	{
		return (UI_main_GvGFlagshipPanel)(object)UIPackage.CreateObject("GvGFlagship3", "main_GvGFlagshipPanel");
	}

	public static UI_main_GvGFlagshipPanel CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_main_GvGFlagshipPanel).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://tvr786zldwxt0", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Expected O, but got Unknown
		//IL_015a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0164: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		StoryType = ((GComponent)this).GetController("StoryType");
		background = (GLoader)((GComponent)this).GetChild("background");
		BackBtn = (GButton)((GComponent)this).GetChild("BackBtn");
		Title = (UI_com_Title)(object)((GComponent)this).GetChild("Title");
		OEMMissions = (UI_btn_exchange)(object)((GComponent)this).GetChild("OEMMissions");
		Purification = (UI_btn_purification)(object)((GComponent)this).GetChild("Purification");
		DailyReward = (UI_btn_DailyReward)(object)((GComponent)this).GetChild("DailyReward");
		FoodSupply = (UI_btn_FoodSupply)(object)((GComponent)this).GetChild("FoodSupply");
		LeaderboardBtn = (UI_btn_Leaderboard)(object)((GComponent)this).GetChild("LeaderboardBtn");
		TransitionStage = (UI_com_TransitionStage)(object)((GComponent)this).GetChild("TransitionStage");
		Missions = (UI_btn_02)(object)((GComponent)this).GetChild("Missions");
		FlagShipCannonBtn = (UI_btn_01)(object)((GComponent)this).GetChild("FlagShipCannonBtn");
		RequirementTasks = (UI_btn_RequirementTasks)(object)((GComponent)this).GetChild("RequirementTasks");
		SplitBlueprint = (UI_btn_SplitBluePrint)(object)((GComponent)this).GetChild("SplitBlueprint");
		brawlFightBtn = (UI_btn_BrawlFightEntrance)(object)((GComponent)this).GetChild("brawlFightBtn");
		HelpBtn = (GButton)((GComponent)this).GetChild("HelpBtn");
	}

	public void BeforeDestroy()
	{
		Singleton<GvG3SupplyDepotManager>.Instance.Destroy();
	}

	public void Destroy()
	{
	}

	public void Init(Dictionary<string, object> parameters)
	{
		FGUIManager.SetUiPanelSizeAndXy((GObject)(object)this);
		Singleton<GvG3SupplyDepotManager>.Instance.Init();
		Singleton<WorldStateManager>.Instance.Data.PlayerFlagshipInfo.SaveFlagShipMissionsChecked();
		if (parameters != null && parameters.TryGetValue("PlayTransition", out var value))
		{
			PlayTransition(value.ToString());
		}
		bool flag = WorldMapConfigHelper.Configs.IsBrawlEvent();
		StoryType.SetSelectedIndex(flag ? 1 : 0);
		((GObject)RequirementTasks).visible = !flag;
		ReloadBrawlEventInfo();
	}

	private void ReloadBrawlEventInfo()
	{
		_brawlEventInfo = null;
		if (!WorldMapConfigHelper.Configs.IsBrawlEvent())
		{
			return;
		}
		Task<C2S_BrawlEvent_GetInfo.Response> task = UI_main_BrawlFightEnroll.GetBrawlEventInfo();
		task.GetAwaiter().OnCompleted(delegate
		{
			C2S_BrawlEvent_GetInfo.Response result = task.Result;
			if (result.ErrorCode != 0)
			{
				ILRequestHelper.ShowErrorCode(result.ErrorCode);
			}
			else
			{
				_brawlEventInfo = result;
				bool flag = UI_main_BrawlFightEnroll.IsFinalStep(result.StepIdx);
				brawlFightBtn.StepType.SetSelectedIndex(flag ? 1 : 0);
				RefreshBrawlEventRedDot();
				UI_main_BrawlFightEnroll.TryReloadBrawlIslandState(result.MaxHasBeginSignUp);
			}
		});
	}

	public void OnShow()
	{
		Singleton<GvG3SupplyDepotManager>.Instance.GetContributionItemInfo();
		Singleton<GvG3FlagshipReqManager>.Instance.GetSelfOemMissions();
		FlagShipMissionRedDotsInit();
		SetBackgroundCampId();
		SetUiEntranceVisible();
	}

	public void RegisterUiEventListeners()
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected O, but got Unknown
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_003a: Expected O, but got Unknown
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Expected O, but got Unknown
		//IL_006a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0074: Expected O, but got Unknown
		//IL_0087: Unknown result type (might be due to invalid IL or missing references)
		//IL_0091: Expected O, but got Unknown
		//IL_00a4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ae: Expected O, but got Unknown
		//IL_00c1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cb: Expected O, but got Unknown
		//IL_00de: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e8: Expected O, but got Unknown
		//IL_00fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0105: Expected O, but got Unknown
		//IL_0118: Unknown result type (might be due to invalid IL or missing references)
		//IL_0122: Expected O, but got Unknown
		//IL_0135: Unknown result type (might be due to invalid IL or missing references)
		//IL_013f: Expected O, but got Unknown
		//IL_0152: Unknown result type (might be due to invalid IL or missing references)
		//IL_015c: Expected O, but got Unknown
		((GObject)BackBtn).onClick.Add(new EventCallback0(End));
		((GObject)OEMMissions).onClick.Add(new EventCallback0(OpenOEMMissionsUi));
		((GObject)RequirementTasks).onClick.Add(new EventCallback0(OpenFlagshipReqTaskUi));
		((GObject)Purification).onClick.Add(new EventCallback0(OpenPurification));
		((GObject)DailyReward).onClick.Set(new EventCallback0(OpenDailyRewardUi));
		((GObject)FoodSupply).onClick.Set(new EventCallback0(OpenFoodSupply));
		((GObject)LeaderboardBtn).onClick.Set(new EventCallback0(OnOpenLeaderboardPanel));
		((GObject)Missions).onClick.Set(new EventCallback0(OnMissionsClick));
		((GObject)FlagShipCannonBtn).onClick.Set(new EventCallback0(OnClickFlagShipCannonBtn));
		((GObject)SplitBlueprint).onClick.Set(new EventCallback0(OnSplitBlueprintClick));
		((GObject)brawlFightBtn).onClick.Set(new EventCallback0(OnClickOpenBrawlFightEnroll));
		((GObject)HelpBtn).onClick.Set(new EventCallback0(OnClickHelpBtn));
		GvG3SupplyDepotManager instance = Singleton<GvG3SupplyDepotManager>.Instance;
		instance.UpdateUi = (Action)Delegate.Combine(instance.UpdateUi, new Action(UpdateSupplyDepotRedDot));
		GvG3FlagShipMissionsManager instance2 = Singleton<GvG3FlagShipMissionsManager>.Instance;
		instance2.UpdateMainUiMissionRedDot = (Action<bool>)Delegate.Combine(instance2.UpdateMainUiMissionRedDot, new Action<bool>(UpdateFlagShipMissionRedDot));
		GvG3FlagshipReqManager instance3 = Singleton<GvG3FlagshipReqManager>.Instance;
		instance3.UpdateSelfOemMissions = (Action<List<SelfOEMMission_ToProtocol>>)Delegate.Combine(instance3.UpdateSelfOemMissions, new Action<List<SelfOEMMission_ToProtocol>>(UpdateOemMissionsRedDot));
		WorldStateManager instance4 = Singleton<WorldStateManager>.Instance;
		instance4.OnCampProgressChange = (Action)Delegate.Combine(instance4.OnCampProgressChange, new Action(TurnOnFlagShipMissionRedDot));
		GvGMode3RoomManager instance5 = Singleton<GvGMode3RoomManager>.Instance;
		instance5.OnRoomClose = (Action)Delegate.Combine(instance5.OnRoomClose, new Action(ForceClose));
		SharedMessenger.AddListener<string>("CLOSE_UI", OnAnyUiClosed);
	}

	public void UnregisterUiEventListeners()
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected O, but got Unknown
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_003a: Expected O, but got Unknown
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Expected O, but got Unknown
		//IL_006a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0074: Expected O, but got Unknown
		//IL_0087: Unknown result type (might be due to invalid IL or missing references)
		//IL_0091: Expected O, but got Unknown
		//IL_00a4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ae: Expected O, but got Unknown
		//IL_00c1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cb: Expected O, but got Unknown
		((GObject)BackBtn).onClick.Remove(new EventCallback0(End));
		((GObject)OEMMissions).onClick.Remove(new EventCallback0(OpenOEMMissionsUi));
		((GObject)RequirementTasks).onClick.Remove(new EventCallback0(OpenFlagshipReqTaskUi));
		((GObject)Purification).onClick.Remove(new EventCallback0(OpenPurification));
		((GObject)DailyReward).onClick.Remove(new EventCallback0(OpenDailyRewardUi));
		((GObject)FoodSupply).onClick.Remove(new EventCallback0(OpenFoodSupply));
		((GObject)LeaderboardBtn).onClick.Remove(new EventCallback0(OnOpenLeaderboardPanel));
		((GObject)Missions).onClick.Clear();
		((GObject)FlagShipCannonBtn).onClick.Clear();
		((GObject)SplitBlueprint).onClick.Clear();
		((GObject)brawlFightBtn).onClick.Clear();
		GvG3SupplyDepotManager instance = Singleton<GvG3SupplyDepotManager>.Instance;
		instance.UpdateUi = (Action)Delegate.Remove(instance.UpdateUi, new Action(UpdateSupplyDepotRedDot));
		GvG3FlagShipMissionsManager instance2 = Singleton<GvG3FlagShipMissionsManager>.Instance;
		instance2.UpdateMainUiMissionRedDot = (Action<bool>)Delegate.Remove(instance2.UpdateMainUiMissionRedDot, new Action<bool>(UpdateFlagShipMissionRedDot));
		GvG3FlagshipReqManager instance3 = Singleton<GvG3FlagshipReqManager>.Instance;
		instance3.UpdateSelfOemMissions = (Action<List<SelfOEMMission_ToProtocol>>)Delegate.Remove(instance3.UpdateSelfOemMissions, new Action<List<SelfOEMMission_ToProtocol>>(UpdateOemMissionsRedDot));
		WorldStateManager instance4 = Singleton<WorldStateManager>.Instance;
		instance4.OnCampProgressChange = (Action)Delegate.Remove(instance4.OnCampProgressChange, new Action(TurnOnFlagShipMissionRedDot));
		GvGMode3RoomManager instance5 = Singleton<GvGMode3RoomManager>.Instance;
		instance5.OnRoomClose = (Action)Delegate.Remove(instance5.OnRoomClose, new Action(ForceClose));
		SharedMessenger.RemoveListener<string>("CLOSE_UI", OnAnyUiClosed);
	}

	private void End()
	{
		GameController.Contexts.Service<IUiService>().ClosePanel(Name);
	}

	private void ForceClose()
	{
		GameController.Contexts.Service<IUiService>().ClosePanel(Name);
	}

	private void PlayTransition(string transitionName)
	{
		Transition transition = ((GComponent)TransitionStage).GetTransition(transitionName);
		if (transition != null)
		{
			transition.Play();
		}
	}

	private void OnClickHelpBtn()
	{
		UiHelper.OpenHelpPage("阵营旗舰", "远征相关", "阵营旗舰");
	}

	private void OpenOEMMissionsUi()
	{
		GameController.Contexts.Service<IUiService>().OpenPanel(UI_main_GvG3Exchange.Name, new Dictionary<string, object> { { "CheckPageIndex", 1 } });
	}

	private void OpenFlagshipReqTaskUi()
	{
		GameController.Contexts.Service<IUiService>().OpenPanel(UI_main_GvG3Exchange.Name, new Dictionary<string, object> { { "CheckPageIndex", 0 } });
	}

	private void OpenPurification()
	{
		GameController.Contexts.Service<IUiService>().OpenPanel(UI_main_GvG3Purification.Name, null);
	}

	private void OpenDailyRewardUi()
	{
		GameController.Contexts.Service<IUiService>().OpenPanel(UI_main_SupplyDepot.Name, new Dictionary<string, object> { { "FocusPageIndex", 1 } });
	}

	private void OpenFoodSupply()
	{
		GameController.Contexts.Service<IUiService>().OpenPanel(UI_main_SupplyDepot.Name, new Dictionary<string, object> { { "FocusPageIndex", 0 } });
	}

	private void OnOpenLeaderboardPanel()
	{
		GameController.Contexts.Service<IUiService>().OpenPanel(UI_main_GvG3LeaderboardPanel.Name, new Dictionary<string, object> { 
		{
			"UIType",
			UI_main_GvG3LeaderboardPanel.UIType.Expedition
		} });
	}

	private void OnMissionsClick()
	{
		GameController.Contexts.Service<IUiService>().OpenPanel(UI_main_FlagShipMissions.Name, null);
	}

	private static void OnSplitBlueprintClick()
	{
		LegendItemsHelper.OpenLegendItemBlueprintListPanel(delegate
		{
			GameController.Contexts.Service<IUiService>().OpenPanel(UI_main_SplitBlueprint.Name, null);
		});
	}

	private void OnClickOpenBrawlFightEnroll()
	{
		if (_brawlEventInfo != null)
		{
			GameController.Contexts.Service<IUiService>().OpenPanel(UI_main_BrawlFightEnroll.Name, new Dictionary<string, object> { { "GVG_BRAWL_EVENT_INFO", _brawlEventInfo } });
		}
	}

	private void SetUiEntranceVisible()
	{
		((GObject)SplitBlueprint).visible = OuterTechHelper.Is蓝图分解Active;
	}

	private void UpdateSupplyDepotRedDot()
	{
		((GObject)DailyReward.BoxIcon).visible = Singleton<GvG3SupplyDepotManager>.Instance.ContributionItemInfo.DailyRewardShowRedDot();
	}

	private void TurnOnFlagShipMissionRedDot()
	{
		UpdateFlagShipMissionRedDot(showRedDot: true);
	}

	private void UpdateFlagShipMissionRedDot(bool showRedDot)
	{
		((GObject)Missions.BoxIcon).visible = showRedDot;
	}

	private void FlagShipMissionRedDotsInit()
	{
		UI_main_GvGWorldMap3 uI_main_GvGWorldMap = ((UI_main_GvGWorldMap3)(object)GameController.Contexts.Service<IUiService>().GetShowingUi(UI_main_GvGWorldMap3.Name)) ?? throw new NullReferenceException("UI_main_GvGWorldMap3 is null");
		((GObject)Missions.BoxIcon).visible = uI_main_GvGWorldMap.FlagShipMission.RedDot.selectedIndex == 1;
	}

	private void UpdateOemMissionsRedDot(List<SelfOEMMission_ToProtocol> list)
	{
		((GObject)OEMMissions.BoxIcon).visible = list.Any((SelfOEMMission_ToProtocol mission) => mission.UiState == 1 || mission.UiState == 2);
	}

	private void RefreshBrawlEventRedDot()
	{
		((GObject)brawlFightBtn.redNote).visible = !_brawlEventInfo.IsAnyShipEnrolled();
	}

	private void SetBackgroundCampId()
	{
		if (!(background.component is UI_com_background uI_com_background))
		{
			throw new Exception("background component is not UI_com_background");
		}
		uI_com_background.Camp.SetSelectedIndex(Singleton<GvGMode3RoomManager>.Instance.ObserverRecord.ObCampId);
		uI_com_background.n28.Camp.SetSelectedIndex(Singleton<GvGMode3RoomManager>.Instance.ObserverRecord.ObCampId);
		uI_com_background.n29.Camp.SetSelectedIndex(Singleton<GvGMode3RoomManager>.Instance.ObserverRecord.ObCampId);
		uI_com_background.n30.Camp.SetSelectedIndex(Singleton<GvGMode3RoomManager>.Instance.ObserverRecord.ObCampId);
		uI_com_background.n31.Camp.SetSelectedIndex(Singleton<GvGMode3RoomManager>.Instance.ObserverRecord.ObCampId);
		uI_com_background.n32.Camp.SetSelectedIndex(Singleton<GvGMode3RoomManager>.Instance.ObserverRecord.ObCampId);
	}

	public void OnClickFlagShipCannonBtn()
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_0021: Expected O, but got Unknown
		//IL_0038: Unknown result type (might be due to invalid IL or missing references)
		UI_com_FlagShipCannonTip uI_com_FlagShipCannonTip = UI_com_FlagShipCannonTip.CreateInstance_ILRuntime();
		Window val = new Window
		{
			sortingOrder = 3000,
			contentPane = (GComponent)(object)uI_com_FlagShipCannonTip
		};
		GRoot.inst.ShowPopup((GObject)(object)val);
		((GObject)uI_com_FlagShipCannonTip).xy = new Vector2(368f, 580f);
		((GObject)uI_com_FlagShipCannonTip.Level).text = $"{Singleton<WorldStateManager>.Instance.Data.ProgressData.CampProgress}";
	}

	private void OnAnyUiClosed(string uiName)
	{
		if (uiName == UI_main_BrawlFightEnroll.Name)
		{
			ReloadBrawlEventInfo();
		}
	}
}
