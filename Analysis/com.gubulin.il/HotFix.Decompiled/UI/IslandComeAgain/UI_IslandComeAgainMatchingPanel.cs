using System;
using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Managers;
using Assets.Scripts.UI;
using FairyGUI;
using FairyGUI.Utils;
using GvG2;
using Shift.Legion.ClientApi.Models;
using Shift.Legion.ClientApi.Protocol.UserAction;
using Shift.Legion.Common.Enums;
using Shift.Legion.Common.Helpers;
using Shift.Legion.Common.Managers;
using Shift.Legion.Common.Models;
using Shift.Legion.Common.Services;
using Shift.Legion.Common.Sources.Enums;
using UI.GvGWorldMap2;
using UI.GvGWorldMapRecord2;
using UI.Legion;
using UI.PublicResources;
using UI.RecruitingCamp;
using UI.SpecialActivity;
using UI.Tips;
using UI.UpGrade;
using UnityEngine;

namespace UI.IslandComeAgain;

public class UI_IslandComeAgainMatchingPanel : GComponent, IUiController
{
	public Controller Type;

	public GLoader background;

	public GGraph _mask;

	public GButton backBtn;

	public UI_Title titleCom;

	public GComponent CurrencyAddBtn;

	public GImage n14;

	public GImage n24;

	public GImage n16;

	public GImage n9;

	public GImage n10;

	public GList SoldierList;

	public UI_OpenIslandComeAgainStore OpenStore;

	public GTextField n15;

	public GTextField n17;

	public GTextField n18;

	public GTextField n19;

	public UI_mc_rudder_0 n29;

	public UI_mc_rudder_1 n30;

	public GTextField n20;

	public GTextField n37;

	public UI_MatchingBtn MatchingBtn;

	public GTextField n26;

	public GTextField Tip;

	public GImage n21;

	public GTextField n22;

	public GGroup n50;

	public UI_btn_cancel cancel;

	public UI_ReturnMaincityBtn ReturnBattlefieldBtn;

	public UI_IslandComeAgainSoldiersNotEnoughTip SoldiersNotEnoughTip;

	public UI_Introduction Help;

	public UI_BattleRecordSummary BattleRecord;

	public UI_DailyMissionBtn DailyMission;

	public GTextField n35;

	public GGraph FakeSoldierList;

	public UI_DailyMissionTip DailyMissionTip;

	public Transition t0;

	public const string URL = "ui://k2sprg26p1ft0";

	public static string Name = "UI_IslandComeAgainMatchingPanel";

	public const string WhiteListTestItemId = "WhiteListTestItem_GvGMode2";

	private int GvGRoomOperationTime = 0;

	private Coroutine GvGRoomOperationCoroutine;

	private List<int> ownShipIds = new List<int>();

	private GvGInstanceZone.MatchingInfo CurInfo;

	private WaitForSeconds perSecond = new WaitForSeconds(1f);

	private WaitForSeconds TenSeconds = new WaitForSeconds(10f);

	private Coroutine returnBattlefieldCoroutine;

	private int startTimestamp;

	private UI_ProductionNumFloating NumFloating;

	private string CurrencyItemId = FGUIManager.Instance.IslandComeAgainActivities?[0].ScoreItem;

	private const int SoldiersCnt = 5;

	private const int BestSoldierNum = 50;

	private List<string> currentSoldiers = new List<string>();

	private const int LegendItemsLimit = 2;

	private readonly Color32[] SoldierNameColor = (Color32[])(object)new Color32[6]
	{
		new Color32((byte)143, (byte)204, (byte)82, byte.MaxValue),
		new Color32((byte)48, (byte)178, (byte)242, byte.MaxValue),
		new Color32((byte)204, (byte)102, byte.MaxValue, byte.MaxValue),
		new Color32((byte)242, (byte)127, (byte)12, byte.MaxValue),
		new Color32(byte.MaxValue, byte.MaxValue, (byte)0, byte.MaxValue),
		new Color32((byte)217, (byte)0, (byte)36, byte.MaxValue)
	};

	public void SetControllerPageText()
	{
		if (Type.selectedIndex == 2 || Type.selectedIndex == 3 || Type.selectedIndex == 4 || Type.selectedIndex == 5)
		{
			string id = string.Format("{0}-{1}-{2}", "ui://k2sprg26p1ft0".Replace("ui://", ""), ((GObject)n26).id, Type.selectedIndex);
			((GObject)n26).text = LanguagesManager.GetDesc(id);
		}
	}

	public static string GetURL()
	{
		return "ui://k2sprg26p1ft0";
	}

	public static UI_IslandComeAgainMatchingPanel CreateInstance()
	{
		return (UI_IslandComeAgainMatchingPanel)(object)UIPackage.CreateObject("IslandComeAgain", "IslandComeAgainMatchingPanel");
	}

	public static UI_IslandComeAgainMatchingPanel CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_IslandComeAgainMatchingPanel).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://k2sprg26p1ft0", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Expected O, but got Unknown
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		//IL_005c: Expected O, but got Unknown
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0088: Expected O, but got Unknown
		//IL_0094: Unknown result type (might be due to invalid IL or missing references)
		//IL_009e: Expected O, but got Unknown
		//IL_00aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b4: Expected O, but got Unknown
		//IL_00c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ca: Expected O, but got Unknown
		//IL_00d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e0: Expected O, but got Unknown
		//IL_00ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f6: Expected O, but got Unknown
		//IL_0102: Unknown result type (might be due to invalid IL or missing references)
		//IL_010c: Expected O, but got Unknown
		//IL_012e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0138: Expected O, but got Unknown
		//IL_0181: Unknown result type (might be due to invalid IL or missing references)
		//IL_018b: Expected O, but got Unknown
		//IL_01d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_01de: Expected O, but got Unknown
		//IL_0227: Unknown result type (might be due to invalid IL or missing references)
		//IL_0231: Expected O, but got Unknown
		//IL_02a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b0: Expected O, but got Unknown
		//IL_02fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0305: Expected O, but got Unknown
		//IL_0366: Unknown result type (might be due to invalid IL or missing references)
		//IL_0370: Expected O, but got Unknown
		//IL_03bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_03c5: Expected O, but got Unknown
		//IL_03d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_03db: Expected O, but got Unknown
		//IL_03e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_03f1: Expected O, but got Unknown
		//IL_043c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0446: Expected O, but got Unknown
		//IL_04d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_04e0: Expected O, but got Unknown
		//IL_052b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0535: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Type = ((GComponent)this).GetController("Type");
		background = (GLoader)((GComponent)this).GetChild("background");
		_mask = (GGraph)((GComponent)this).GetChild("_mask");
		backBtn = (GButton)((GComponent)this).GetChild("backBtn");
		titleCom = (UI_Title)(object)((GComponent)this).GetChild("titleCom");
		CurrencyAddBtn = (GComponent)((GComponent)this).GetChild("CurrencyAddBtn");
		n14 = (GImage)((GComponent)this).GetChild("n14");
		n24 = (GImage)((GComponent)this).GetChild("n24");
		n16 = (GImage)((GComponent)this).GetChild("n16");
		n9 = (GImage)((GComponent)this).GetChild("n9");
		n10 = (GImage)((GComponent)this).GetChild("n10");
		SoldierList = (GList)((GComponent)this).GetChild("SoldierList");
		OpenStore = (UI_OpenIslandComeAgainStore)(object)((GComponent)this).GetChild("OpenStore");
		n15 = (GTextField)((GComponent)this).GetChild("n15");
		string id = "ui://k2sprg26p1ft0".Replace("ui://", "") + "-" + ((GObject)n15).id;
		((GObject)n15).text = LanguagesManager.GetDesc(id);
		n17 = (GTextField)((GComponent)this).GetChild("n17");
		string id2 = "ui://k2sprg26p1ft0".Replace("ui://", "") + "-" + ((GObject)n17).id;
		((GObject)n17).text = LanguagesManager.GetDesc(id2);
		n18 = (GTextField)((GComponent)this).GetChild("n18");
		string id3 = "ui://k2sprg26p1ft0".Replace("ui://", "") + "-" + ((GObject)n18).id;
		((GObject)n18).text = LanguagesManager.GetDesc(id3);
		n19 = (GTextField)((GComponent)this).GetChild("n19");
		string id4 = "ui://k2sprg26p1ft0".Replace("ui://", "") + "-" + ((GObject)n19).id;
		((GObject)n19).text = LanguagesManager.GetDesc(id4);
		n29 = (UI_mc_rudder_0)(object)((GComponent)this).GetChild("n29");
		n30 = (UI_mc_rudder_1)(object)((GComponent)this).GetChild("n30");
		n20 = (GTextField)((GComponent)this).GetChild("n20");
		string id5 = "ui://k2sprg26p1ft0".Replace("ui://", "") + "-" + ((GObject)n20).id;
		((GObject)n20).text = LanguagesManager.GetDesc(id5);
		n37 = (GTextField)((GComponent)this).GetChild("n37");
		string id6 = "ui://k2sprg26p1ft0".Replace("ui://", "") + "-" + ((GObject)n37).id;
		((GObject)n37).text = LanguagesManager.GetDesc(id6);
		MatchingBtn = (UI_MatchingBtn)(object)((GComponent)this).GetChild("MatchingBtn");
		n26 = (GTextField)((GComponent)this).GetChild("n26");
		string id7 = "ui://k2sprg26p1ft0".Replace("ui://", "") + "-" + ((GObject)n26).id;
		((GObject)n26).text = LanguagesManager.GetDesc(id7);
		Tip = (GTextField)((GComponent)this).GetChild("Tip");
		n21 = (GImage)((GComponent)this).GetChild("n21");
		n22 = (GTextField)((GComponent)this).GetChild("n22");
		string id8 = "ui://k2sprg26p1ft0".Replace("ui://", "") + "-" + ((GObject)n22).id;
		((GObject)n22).text = LanguagesManager.GetDesc(id8);
		n50 = (GGroup)((GComponent)this).GetChild("n50");
		cancel = (UI_btn_cancel)(object)((GComponent)this).GetChild("cancel");
		ReturnBattlefieldBtn = (UI_ReturnMaincityBtn)(object)((GComponent)this).GetChild("ReturnBattlefieldBtn");
		SoldiersNotEnoughTip = (UI_IslandComeAgainSoldiersNotEnoughTip)(object)((GComponent)this).GetChild("SoldiersNotEnoughTip");
		Help = (UI_Introduction)(object)((GComponent)this).GetChild("Help");
		BattleRecord = (UI_BattleRecordSummary)(object)((GComponent)this).GetChild("BattleRecord");
		DailyMission = (UI_DailyMissionBtn)(object)((GComponent)this).GetChild("DailyMission");
		n35 = (GTextField)((GComponent)this).GetChild("n35");
		string id9 = "ui://k2sprg26p1ft0".Replace("ui://", "") + "-" + ((GObject)n35).id;
		((GObject)n35).text = LanguagesManager.GetDesc(id9);
		FakeSoldierList = (GGraph)((GComponent)this).GetChild("FakeSoldierList");
		DailyMissionTip = (UI_DailyMissionTip)(object)((GComponent)this).GetChild("DailyMissionTip");
		t0 = ((GComponent)this).GetTransition("t0");
	}

	public void BeforeDestroy()
	{
		CloseThisPanel();
		Singleton<GvGInstanceZone>.Instance.UpdateLocalBattleRecord();
	}

	public void Destroy()
	{
		UiTagManager instance = UiTagManager.Instance;
		instance.Unregister("MatchingPanel.SoldierList", SoldierList);
		instance.Unregister("MatchingPanel.FakeSoldierList", FakeSoldierList);
	}

	public void Init(Dictionary<string, object> parameters)
	{
		FGUIManager.SetUiPanelSizeAndXy((GObject)(object)this);
		ShowCurrency();
		PanelNameSet();
		List<string> selectSoldiersList = GameLocalDataManager.LoadIslandComeAgainSoldiers();
		UpdateSelectSoldiersList(selectSoldiersList);
		GvGInstanceZone instance = Singleton<GvGInstanceZone>.Instance;
		instance.UpdatePanelEvent = (Action<GvGInstanceZone.MatchingInfo>)Delegate.Combine(instance.UpdatePanelEvent, new Action<GvGInstanceZone.MatchingInfo>(UpdateMatchInfo));
		UpdateMatchInfo(new GvGInstanceZone.MatchingInfo
		{
			matchState = GvGInstanceZone.MatchState.NotInit
		});
		Singleton<GvGInstanceZone>.Instance.InquireInitInfo();
	}

	public void OnShow()
	{
		UiTagManager instance = UiTagManager.Instance;
		instance.Register("MatchingPanel.SoldierList", SoldierList);
		instance.Register("MatchingPanel.FakeSoldierList", FakeSoldierList);
		Singleton<GvGInstanceZone>.Instance.ClearLocalBattleRecord();
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
		//IL_016a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0174: Expected O, but got Unknown
		//IL_018c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0196: Expected O, but got Unknown
		((GObject)backBtn).onClick.Add(new EventCallback0(ForceLeave));
		((GObject)OpenStore).onClick.Add(new EventCallback0(OpenStoreEvent));
		((GObject)MatchingBtn).onClick.Add(new EventCallback0(MatchingEvent));
		((GObject)BattleRecord).onClick.Add(new EventCallback0(OpenBattleRecord));
		((GObject)ReturnBattlefieldBtn).onClick.Add(new EventCallback0(BackBattleField));
		((GObject)cancel).onClick.Add(new EventCallback0(CancelGvGRoomOperation));
		((GObject)SoldierList).onClick.Add(new EventCallback0(OpenLegionPanel));
		((GObject)Help).onClick.Add(new EventCallback0(OpenHelpPanel));
		DynamicIslandComeAgainActivity dynamicIslandComeAgainActivity = FGUIManager.Instance.IslandComeAgainActivities?[0];
		if (dynamicIslandComeAgainActivity.DailyMissions != null && dynamicIslandComeAgainActivity.DailyMissions.Count > 0)
		{
			SharedMessenger.AddListener<Cache_IslandComeAgainDailyMissionRedDot>(Cache_IslandComeAgainDailyMissionRedDot.ON_REDDOT_CHANGE, OnDailyMissionRedDot);
			((GObject)DailyMission).visible = true;
			((GObject)DailyMission.RedDot).visible = false;
			((GObject)DailyMission).onClick.Add(new EventCallback0(OnClickDailyMission));
			((GObject)DailyMissionTip.mask).onClick.Add(new EventCallback0(OnClickDailyMissionTipMask));
			CacheManager.Instance.Get<Cache_IslandComeAgainDailyMissionRedDot>().ForceUpdate();
		}
		else
		{
			((GObject)DailyMission).visible = false;
		}
		SharedMessenger.AddListener<string, int, (StockInContext, string)>("ON_STOCK_CHANGE", OnStockChange);
		SharedMessenger.AddListener<List<string>>("UPDATE_ISLAND_COME_AGAIN_SOLDIERS", UpdateSelectSoldiersList);
		SharedMessenger.AddListener<List<int>>("ISLAND_COME_AGAIN_BACK_BATTLEFIELD", UpdateOwnShipIds);
		SharedMessenger.AddListener<bool>("APP_FOCUS", OnApplicationFocus);
		SharedMessenger.AddListener<bool>("APP_PAUSE", OnApplicationFocus);
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
		//IL_00de: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e8: Expected O, but got Unknown
		//IL_00fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0105: Expected O, but got Unknown
		//IL_011d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0127: Expected O, but got Unknown
		((GObject)backBtn).onClick.Remove(new EventCallback0(ForceLeave));
		((GObject)OpenStore).onClick.Remove(new EventCallback0(OpenStoreEvent));
		((GObject)MatchingBtn).onClick.Remove(new EventCallback0(MatchingEvent));
		((GObject)BattleRecord).onClick.Remove(new EventCallback0(OpenBattleRecord));
		((GObject)ReturnBattlefieldBtn).onClick.Remove(new EventCallback0(BackBattleField));
		((GObject)cancel).onClick.Remove(new EventCallback0(CancelGvGRoomOperation));
		((GObject)SoldierList).onClick.Remove(new EventCallback0(OpenLegionPanel));
		((GObject)Help).onClick.Remove(new EventCallback0(OpenHelpPanel));
		((GObject)DailyMission).onClick.Remove(new EventCallback0(OnClickDailyMission));
		((GObject)DailyMissionTip.mask).onClick.Remove(new EventCallback0(OnClickDailyMissionTipMask));
		SharedMessenger.RemoveListener<Cache_IslandComeAgainDailyMissionRedDot>(Cache_IslandComeAgainDailyMissionRedDot.ON_REDDOT_CHANGE, OnDailyMissionRedDot);
		SharedMessenger.RemoveListener<string, int, (StockInContext, string)>("ON_STOCK_CHANGE", OnStockChange);
		SharedMessenger.RemoveListener<List<string>>("UPDATE_ISLAND_COME_AGAIN_SOLDIERS", UpdateSelectSoldiersList);
		SharedMessenger.RemoveListener<List<int>>("ISLAND_COME_AGAIN_BACK_BATTLEFIELD", UpdateOwnShipIds);
		SharedMessenger.RemoveListener<bool>("APP_FOCUS", OnApplicationFocus);
		SharedMessenger.RemoveListener<bool>("APP_PAUSE", OnApplicationFocus);
	}

	public void End()
	{
		GameController.Contexts.Service<IUiService>().ClosePanel(Name);
	}

	private void OnClickDailyMission()
	{
		((GObject)DailyMissionTip).alpha = 1f;
		((GObject)DailyMissionTip).visible = true;
		DailyMissionTip.RefreshPanel();
	}

	private void OnClickDailyMissionTipMask()
	{
		((GObject)DailyMissionTip).visible = false;
	}

	private void OpenHelpPanel()
	{
		GameController.Contexts.Service<IUiService>().OpenPanel(UI_IslandComeAgainHelpPanel.Name, null);
	}

	private void OpenStoreEvent()
	{
		GameController.Contexts.Service<IUiService>().OpenPanel(UI_IslandComeAgainLotteryPanel.Name, null);
	}

	private void ForceLeave()
	{
		if (Type.selectedIndex == 0 || Type.selectedIndex == 1 || Type.selectedIndex == 4 || Type.selectedIndex == 6)
		{
			StopGvGRoomOperation();
		}
		else
		{
			CancelMatchAndExit();
		}
	}

	private void MatchingEvent()
	{
		//IL_00e5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ef: Expected O, but got Unknown
		//IL_0107: Unknown result type (might be due to invalid IL or missing references)
		//IL_0111: Expected O, but got Unknown
		//IL_0129: Unknown result type (might be due to invalid IL or missing references)
		//IL_0133: Expected O, but got Unknown
		DynamicIslandComeAgainActivity dynamicIslandComeAgainActivity = FGUIManager.Instance.IslandComeAgainActivities?[0];
		for (int i = 0; i < dynamicIslandComeAgainActivity.LevelCase.Count; i++)
		{
			string levelId = dynamicIslandComeAgainActivity.LevelCase[i];
			Level levelInstance = GameManagers.Instance.ChapterManager.GetLevelInstance(levelId);
			if (levelInstance != null && !GameManagers.Instance.UserArchiveManager.IsLevelCompleted(levelId))
			{
				List<string> arg = new List<string> { LanguagesManager.GetDesc("CsharpCodeZhTcText299") + levelInstance.Name };
				SharedMessenger.Broadcast("SHOW_TIPS", arg, 1, arg3: false);
				return;
			}
		}
		if (!CheckSoldierIsEnough())
		{
			((GObject)SoldiersNotEnoughTip.GoToCamp).onClick.Set(new EventCallback0(GoToCamp));
			((GObject)SoldiersNotEnoughTip.MatchBtn).onClick.Set(new EventCallback0(StillMatch));
			((GObject)SoldiersNotEnoughTip.CloseBtn).onClick.Set(new EventCallback0(CloseSoldiersNotEnoughTip));
			((GObject)SoldiersNotEnoughTip).visible = true;
		}
		else
		{
			StartGvGRoomOperation();
		}
	}

	private void StillMatch()
	{
		StartGvGRoomOperation();
		CloseSoldiersNotEnoughTip();
	}

	private bool CheckSoldierIsEnough()
	{
		for (int i = 0; i < currentSoldiers.Count; i++)
		{
			string text = currentSoldiers[i];
			int stock = GameManagers.Instance.StockController.GetStock(text);
			int soldierLevel = GameManagers.Instance.UserArchiveManager.GetSoldierLevel(text);
			int num = Singleton<SoldierFormationManager>.Instance.GetSoldierFormationNumber(text, soldierLevel) * 5;
			if (stock < num)
			{
				return false;
			}
		}
		return true;
	}

	private void GoToCamp()
	{
		Building buildingByType = GameManagers.Instance.BuildingManager.GetBuildingByType("10");
		if (buildingByType.Status == BuildingStatus.Banned)
		{
			List<string> arg = new List<string>
			{
				LanguagesManager.GetDesc("CsharpCodeZhTcText21"),
				LanguagesManager.GetDesc("CsharpCodeZhTcText22")
			};
			SharedMessenger.Broadcast("SHOW_TIPS", arg, 120, arg3: false);
			CloseSoldiersNotEnoughTip();
			return;
		}
		Dictionary<string, object> dictionary = new Dictionary<string, object>();
		string text = "";
		if (buildingByType.Status == BuildingStatus.Ready)
		{
			dictionary.Add("Parent", this);
			dictionary.Add("Building", buildingByType);
			text = UI_UpGradePanel.Name;
		}
		else if (buildingByType.Level == 0)
		{
			dictionary.Add("Building", buildingByType);
			dictionary.Add("Parent", this);
			text = UI_UpGradePanel.Name;
		}
		else
		{
			text = UI_RecruitingCamp.Name;
		}
		CommandFactory.CreateOpenSceneCommand("MainCity.Right", new SceneArguments(new Dictionary<string, object>
		{
			{ "ForceCloseOtherUi", true },
			{ "TaskCompletionSource", null },
			{
				"LoadingAnimationDirection",
				LoadingAnimationDirection.Left
			},
			{ "OpenUiOnReturn", text },
			{ "UiParamsOnReturn", dictionary }
		}));
	}

	private void CloseSoldiersNotEnoughTip()
	{
		((GObject)SoldiersNotEnoughTip).visible = false;
	}

	private void OpenBattleRecord()
	{
		Singleton<GvGInstanceZone>.Instance.GetAllBattleRecordSummary(inZone: false, OpenBattleRecordPanel);
	}

	private void OpenBattleRecordPanel(List<UserIslandEntityBattleRecordSummary> summaries)
	{
		GameController.Contexts.Service<IUiService>().OpenPanel(UI_IslandComeAgainBattleRecordsPanel.Name, new Dictionary<string, object>
		{
			{ "BattleRecordSummary", summaries },
			{
				"IsInZone",
				Singleton<GvGInstanceZone>.Instance.IsInZone
			}
		});
	}

	private void OpenLegionPanel()
	{
		DynamicIslandComeAgainActivity dynamicIslandComeAgainActivity = FGUIManager.Instance.IslandComeAgainActivities?[0];
		for (int i = 0; i < dynamicIslandComeAgainActivity.LevelCase.Count; i++)
		{
			string text = dynamicIslandComeAgainActivity.LevelCase[i];
			Chapter chapter = GameManagers.Instance.ChapterManager.GetChapter(text);
			if (chapter != null && !GameManagers.Instance.UserArchiveManager.IsLevelCompleted(text))
			{
				List<string> arg = new List<string> { LanguagesManager.GetDesc("CsharpCodeZhTcText299") + chapter.Name };
				SharedMessenger.Broadcast("SHOW_TIPS", arg, 1, arg3: false);
				return;
			}
		}
		if (Type.selectedIndex == 4)
		{
			List<string> arg2 = new List<string> { LanguagesManager.GetDesc("CsharpCodeZhTcText297") };
			SharedMessenger.Broadcast("SHOW_TIPS", arg2, 1, arg3: false);
			return;
		}
		Dictionary<string, object> parameters = new Dictionary<string, object>
		{
			{ "Style", "10" },
			{ "Spine", null },
			{ "SaveIslandComeAgainSoldiers", true },
			{ "OnlyUnlocked", 1 }
		};
		GameController.Contexts.Service<IUiService>().OpenPanel(UI_LegionPanel.Name, parameters);
	}

	private void OnApplicationFocus(bool b)
	{
		if (CurInfo.matchState == GvGInstanceZone.MatchState.InQueues || CurInfo.matchState == GvGInstanceZone.MatchState.StartMatching || CurInfo.matchState == GvGInstanceZone.MatchState.InRoom)
		{
			Singleton<GvGInstanceZone>.Instance.TryCancelMatch();
		}
	}

	private void UpdateOwnShipIds(List<int> _ownShipIds)
	{
		ownShipIds = _ownShipIds;
	}

	private void CancelGvGRoomOperation()
	{
		Singleton<GvGInstanceZone>.Instance.CancelMatch(GvGInstanceZone.MatchState.CancelMatch);
	}

	private void CancelMatchAndExit()
	{
		GameController.Contexts.Service<IUiService>().OpenPanel(UI_UniversalConfirmPopup.Name, new Dictionary<string, object>
		{
			{
				"Content",
				LanguagesManager.GetDesc("CsharpCodeZhTcText300") + LanguagesManager.Comma + LanguagesManager.GetDesc("CsharpCodeZhTcText301")
			},
			{
				"Buttons",
				new Dictionary<string, Action>
				{
					{
						"Confirm",
						delegate
						{
							Singleton<GvGInstanceZone>.Instance.CancelMatch();
						}
					},
					{ "Cancel", null }
				}
			},
			{ "PageIndex", 0 },
			{ "ClickSound", "Confirm" },
			{
				"Order",
				((GObject)this).sortingOrder
			}
		});
	}

	public void StopGvGRoomOperation()
	{
		End();
	}

	private void CloseThisPanel()
	{
		GvGInstanceZone instance = Singleton<GvGInstanceZone>.Instance;
		instance.UpdatePanelEvent = (Action<GvGInstanceZone.MatchingInfo>)Delegate.Remove(instance.UpdatePanelEvent, new Action<GvGInstanceZone.MatchingInfo>(UpdateMatchInfo));
		if (GvGRoomOperationCoroutine != null)
		{
			FGUIManager.Instance.CloseIEnumerator(GvGRoomOperationCoroutine);
		}
		if (returnBattlefieldCoroutine != null)
		{
			FGUIManager.Instance.CloseIEnumerator(returnBattlefieldCoroutine);
		}
		if (GameController.Contexts.Service<IUiService>().HasShowingUi(UI_SpecialActivityPanel.Name))
		{
			GameController.Contexts.Service<IUiService>().ClosePanel(UI_SpecialActivityPanel.Name);
		}
	}

	private void EnterBattleField()
	{
		End();
	}

	private void BackBattleField()
	{
		End();
		Singleton<GvGInstanceZone>.Instance.ClearData();
		GameController.Contexts.Service<IUiService>().OpenPanel(UI_GvGWorldMap2.Name, new Dictionary<string, object>
		{
			{ "ReservePackageResOnClose", true },
			{ "OwnShipIds", ownShipIds }
		});
	}

	private void StartGvGRoomOperation()
	{
		CurInfo.matchState = GvGInstanceZone.MatchState.StartMatching;
		Singleton<GvGInstanceZone>.Instance.StartMatch(StartMatchTime, StartMatchTimeFailed);
	}

	private void StartMatchTime()
	{
		if (GvGRoomOperationCoroutine == null)
		{
			GvGRoomOperationTime = 0;
			GvGRoomOperationCoroutine = FGUIManager.Instance.OpenIEnumerator(UpdateGvGRoomOperationState());
			Type.selectedIndex = 2;
			SetControllerPageText();
			((GObject)Tip).text = LanguagesManager.GetDesc("CsharpCodeZhTcText302") + "1" + LanguagesManager.GetDesc("CsharpCodeZhTcText92");
		}
	}

	private void StartMatchTimeFailed(int errorCode)
	{
		if (errorCode == 813104117)
		{
			Type.selectedIndex = 6;
			SetControllerPageText();
			if (GvGRoomOperationCoroutine != null)
			{
				FGUIManager.Instance.CloseIEnumerator(GvGRoomOperationCoroutine);
				GvGRoomOperationCoroutine = null;
			}
		}
	}

	private IEnumerator UpdateGvGRoomOperationState()
	{
		while (true)
		{
			if (GvGRoomOperationTime >= 30)
			{
				GvGRoomOperationTime += 10;
				yield return TenSeconds;
			}
			else
			{
				GvGRoomOperationTime++;
				yield return perSecond;
			}
		}
	}

	private void UpdateMatchInfo(GvGInstanceZone.MatchingInfo info)
	{
		CurInfo = info;
		if (info.matchState == GvGInstanceZone.MatchState.NotInit)
		{
			return;
		}
		if (info.matchState == GvGInstanceZone.MatchState.BanMatching)
		{
			Type.selectedIndex = 6;
			SetControllerPageText();
			if (GvGRoomOperationCoroutine != null)
			{
				FGUIManager.Instance.CloseIEnumerator(GvGRoomOperationCoroutine);
				GvGRoomOperationCoroutine = null;
			}
		}
		else if (info.matchState == GvGInstanceZone.MatchState.SetInit)
		{
			StartMatchTime();
		}
		else if (info.matchState == GvGInstanceZone.MatchState.CancelMatchAndExit)
		{
			StopGvGRoomOperation();
		}
		else if (info.matchState == GvGInstanceZone.MatchState.CancelMatch)
		{
			Type.selectedIndex = 1;
			SetControllerPageText();
			if (GvGRoomOperationCoroutine != null)
			{
				FGUIManager.Instance.CloseIEnumerator(GvGRoomOperationCoroutine);
				GvGRoomOperationCoroutine = null;
			}
		}
		else if (info.matchState == GvGInstanceZone.MatchState.InBattlefield)
		{
			Type.selectedIndex = 4;
			SetControllerPageText();
			startTimestamp = info.info;
			returnBattlefieldCoroutine = FGUIManager.Instance.OpenIEnumerator(UpdateGvGRoomOperationReturnBattlefield());
		}
		else if (info.matchState == GvGInstanceZone.MatchState.StartBattle)
		{
			EnterBattleField();
		}
		else if (info.matchState == GvGInstanceZone.MatchState.Lock)
		{
			Type.selectedIndex = 5;
			SetControllerPageText();
			UpdateMatchInfoText(info);
		}
		else
		{
			Type.selectedIndex = ((GvGRoomOperationTime <= 3) ? 2 : 3);
			SetControllerPageText();
			UpdateMatchInfoText(info);
		}
	}

	private void UpdateMatchInfoText(GvGInstanceZone.MatchingInfo info)
	{
		if (GvGRoomOperationTime >= 30)
		{
			if (info.matchState == GvGInstanceZone.MatchState.InRoom || info.matchState == GvGInstanceZone.MatchState.Lock)
			{
				((GObject)Tip).text = info.infoText;
			}
			else if (info.matchState == GvGInstanceZone.MatchState.InQueues)
			{
				float num = info.info;
				int num2 = Mathf.CeilToInt(num / 40f * 5f / 60f);
				((GObject)Tip).text = string.Format("{0}：<{1}{2}", LanguagesManager.GetDesc("CsharpCodeZhTcText303"), num2, LanguagesManager.GetDesc("CsharpCodeZhTcText304"));
			}
		}
		else
		{
			((GObject)Tip).text = string.Format("{0}{1}{2}", LanguagesManager.GetDesc("CsharpCodeZhTcText302"), GvGRoomOperationTime, LanguagesManager.GetDesc("CsharpCodeZhTcText92"));
		}
	}

	private IEnumerator UpdateGvGRoomOperationReturnBattlefield()
	{
		while (Type.selectedIndex == 4)
		{
			int currentTime = (int)GameController.Instance.GetServerTime() - startTimestamp;
			((GObject)Tip).text = LanguagesManager.GetDesc("CsharpCodeZhTcText302") + UiHelper.ParseTime_Foo(currentTime);
			yield return perSecond;
		}
	}

	private void PanelNameSet()
	{
		TextFormat textFormat = ((GComponent)titleCom).GetChild("buildingName").asTextField.textFormat;
		textFormat.font = "ui://kt6rg65orytnv47b";
		textFormat.size = 48;
		((GComponent)titleCom).GetChild("buildingName").asTextField.textFormat = textFormat;
		((GComponent)titleCom).GetChild("buildingName").text = LanguagesManager.GetDesc("CsharpCodeZhTcText298");
	}

	private void ShowCurrency()
	{
		UpdateCurrency();
		CurrencyAddBtn.GetChild("addButton").visible = false;
		CurrencyAddBtn.GetChild("diamond").asLoader.url = "ui://PublicResources/" + UiHelper.GetIcon(CurrencyItemId);
	}

	public void UpdateCurrency()
	{
		int stock = GameManagers.Instance.StockController.GetStock(CurrencyItemId);
		((GObject)CurrencyAddBtn.GetChild("num").asTextField).text = GameManagers.Instance.StockController.GetStock(CurrencyItemId).ToString();
		int num = ((CurrencyAddBtn.GetChild("num").data != null) ? ((int)CurrencyAddBtn.GetChild("num").data) : stock);
		if (num != stock && stock > num)
		{
			int num2 = stock - num;
			if (NumFloating == null)
			{
				NumFloating = UI_ProductionNumFloating.CreateInstance_ILRuntime();
			}
			if (!((GObject)NumFloating).onStage)
			{
				FGUIManager.Instance.AddNumFloatingForCouponBtn(NumFloating, CurrencyAddBtn, stock - num);
			}
			else
			{
				((GObject)NumFloating.Title).text = $"+{(int)((GObject)NumFloating.Title).data + num2}";
				((GObject)NumFloating.Title).data = (int)((GObject)NumFloating.Title).data + num2;
			}
		}
		CurrencyAddBtn.GetChild("num").data = stock;
	}

	private void OnDailyMissionRedDot(Cache_IslandComeAgainDailyMissionRedDot cache)
	{
		((GObject)DailyMission.RedDot).visible = cache.IsShowRedDot;
	}

	private void OnStockChange(string itemId, int incr, (StockInContext, string) context)
	{
		//IL_0058: Unknown result type (might be due to invalid IL or missing references)
		if (itemId == CurrencyItemId)
		{
			UpdateCurrency();
			CurrencyAddBtn.GetChild("textSFXBack").displayObject.Dispose();
			FGUIManager.Instance.AddTextSpecialEffects(CurrencyAddBtn.GetChild("textSFXBack").asGraph, FGUIManager.Instance.uiGreen, Vector3.zero, "Default", 0.5f, delegate(GameObject uiGreen)
			{
				uiGreen.AddComponent<HotFix_DestroySelf>().destroyTime = 0.5f;
			});
		}
		UpdateSoldierNum(itemId);
	}

	private void UpdateSelectSoldiersList(List<string> selectSoldiersList)
	{
		currentSoldiers = selectSoldiersList;
		Singleton<GvGInstanceZone>.Instance.CurrentSoldiers = new List<string>(currentSoldiers);
		if (currentSoldiers != null && currentSoldiers.Count >= 5)
		{
			Type.selectedIndex = (Singleton<GvGInstanceZone>.Instance.CanContinueInquire() ? 1 : 6);
			SetControllerPageText();
		}
		SoldierList.RemoveChildrenToPool();
		for (int i = 0; i < 5; i++)
		{
			UI_QueueListItem soldierItem = SoldierList.AddItemFromPool() as UI_QueueListItem;
			if (i < currentSoldiers.Count)
			{
				string soldierId = currentSoldiers[i];
				RenderSelectSoldier(soldierId, soldierItem);
			}
			else
			{
				RenderSelectSoldier("", soldierItem);
			}
		}
	}

	private void UpdateSoldierNum(string itemId)
	{
		if (!currentSoldiers.Contains(itemId))
		{
			return;
		}
		int num = currentSoldiers.IndexOf(itemId);
		if (((GComponent)SoldierList).GetChildAt(num) is UI_QueueListItem uI_QueueListItem)
		{
			Soldier soldier = GameManagers.Instance.SoldierManager.Get(itemId);
			int stock = GameManagers.Instance.StockController.GetStock(itemId);
			int soldierFormationNumber = Singleton<SoldierFormationManager>.Instance.GetSoldierFormationNumber(itemId, soldier.Level);
			int num2 = soldierFormationNumber * 50;
			bool flag = stock >= num2;
			((GObject)uI_QueueListItem.Amount_t).text = $"{stock}";
			uI_QueueListItem.NumStatus.selectedIndex = (flag ? 1 : 0);
			if (!flag)
			{
				((GObject)uI_QueueListItem.BestAmount).text = string.Format("{0}{1}", LanguagesManager.GetDesc("CsharpCodeZhTcText305"), num2);
			}
		}
	}

	private void RenderSelectSoldier(string soldierId, UI_QueueListItem soldierItem)
	{
		//IL_021f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0224: Unknown result type (might be due to invalid IL or missing references)
		if (string.IsNullOrEmpty(soldierId))
		{
			soldierItem.Type.selectedIndex = 0;
			return;
		}
		Soldier soldier = GameManagers.Instance.SoldierManager.Get(soldierId);
		int num = (soldier.PotentialLevel + 2) / 2;
		string iconFrameBorderSoldier = UiHelper.GetIconFrameBorderSoldier(soldier.PotentialLevel);
		int stock = GameManagers.Instance.StockController.GetStock(soldierId);
		int soldierFormationNumber = Singleton<SoldierFormationManager>.Instance.GetSoldierFormationNumber(soldierId, soldier.Level);
		int num2 = soldierFormationNumber * 50;
		bool flag = stock >= num2;
		soldierItem.Type.selectedIndex = 1;
		soldierItem.IconLoader.IconLoader.url = "ui://PublicResources/" + UiHelper.GetIconPath(soldierId);
		((GObject)soldierItem.Level_t).text = $"{soldier.Level}";
		soldierItem.lvFrame.url = UiHelper.GetLevelFrameBorderSoldier(soldier.PotentialLevel);
		FGUIManager.Instance.SetAlightSoulStoneForSoldierIcon(soldierItem.SoulStoneLevel, soldier.PotentialLevel, soldier.PotentialProgress);
		soldierItem.FrameLoader.url = "ui://PublicResources/" + iconFrameBorderSoldier;
		UiHelper.LoadSoldierIconFrameMaterial(soldierItem.FrameLoader, soldier.PotentialLevel);
		((GObject)soldierItem.Amount_t).text = $"{stock}";
		soldierItem.NumStatus.selectedIndex = (flag ? 1 : 0);
		if (!flag)
		{
			((GObject)soldierItem.BestAmount).text = string.Format("{0}{1}", LanguagesManager.GetDesc("CsharpCodeZhTcText305"), num2);
		}
		((GComponent)soldierItem.racePicture).GetController("Type").selectedIndex = FGUIManager.Instance.GetRaceIcon(soldier.Faction);
		string text = "Name_t";
		if (num >= 5)
		{
			text = "Name_Max";
			soldierItem.Level.selectedIndex = 1;
		}
		else
		{
			soldierItem.Level.selectedIndex = 0;
		}
		((GComponent)soldierItem).GetChild(text).text = soldier.Name;
		((GComponent)soldierItem).GetChild(text).asTextField.color = Color32.op_Implicit(SoldierNameColor[num - 1]);
		RenderLegendItems(soldierItem, soldier.Id);
	}

	private void RenderLegendItems(UI_QueueListItem soldierItem, string soldierId)
	{
		((GObject)soldierItem.LegendItems).visible = false;
		if (LegendItemsHelper.SoldiersEquippedItems == null || !LegendItemsHelper.SoldiersEquippedItems.ContainsKey(soldierId))
		{
			return;
		}
		for (int i = 0; i < 2; i++)
		{
			((GComponent)soldierItem).GetChild($"legendItem{i}").visible = false;
		}
		int num = 0;
		for (int j = 0; j < LegendItemsHelper.SoldiersEquippedItems[soldierId].Length; j++)
		{
			if (num >= 2)
			{
				break;
			}
			GButton asButton = ((GComponent)soldierItem).GetChild($"legendItem{num}").asButton;
			if (!LegendItemsHelper.GetSoldierItemSlotState(soldierId, j))
			{
				((GObject)asButton).visible = false;
				continue;
			}
			long num2 = LegendItemsHelper.SoldiersEquippedItems[soldierId][j];
			((GObject)asButton).visible = true;
			if (num2 == 0)
			{
				((GObject)asButton).visible = false;
				continue;
			}
			UiHelper.RenderLegendItem(asButton, LegendItemsHelper.GetLegendItemUi(num2), UiHelper.TextColorType.Light, null, 2);
			num++;
		}
		switch (num)
		{
		case 1:
			((GComponent)soldierItem).GetController("LegendItemNum").selectedIndex = 0;
			((GComponent)soldierItem).GetChild("n47").visible = false;
			break;
		case 2:
			((GComponent)soldierItem).GetController("LegendItemNum").selectedIndex = 1;
			((GComponent)soldierItem).GetChild("n47").visible = true;
			break;
		}
		bool flag = false;
		for (int k = 0; k < 2; k++)
		{
			GButton asButton2 = ((GComponent)soldierItem).GetChild($"legendItem{k}").asButton;
			if (((GObject)asButton2).visible)
			{
				break;
			}
			if (k == 1)
			{
				flag = true;
			}
		}
		((GObject)soldierItem.LegendItems).visible = !flag;
	}
}
