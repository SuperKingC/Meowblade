using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Managers;
using Assets.Scripts.UI;
using FairyGUI;
using FairyGUI.Utils;
using GvG2;
using GvG2.Common.Models;
using HotFix.Sources.Base.Scripts.Helper;
using Shift.Legion.ClientApi.Models;
using Shift.Legion.ClientApi.Protocol;
using Shift.Legion.Common.Helpers;
using Shift.Legion.Common.Managers;
using Shift.Legion.Common.Services;
using Shift.Legion.GvG.Common.Models;
using Shift.Legion.GvGServer.Models.IslandManagerSocket;
using Shift.Legion.Helpers;
using UI.GvGWorldMapRecord2;
using UI.Tips;
using UnityEngine;

namespace UI.GvGWorldMap2;

public class UI_GvGWorldMap2 : GComponent, IUiController
{
	public Controller PageController;

	public Controller GoToMainIslandReplenish;

	public Controller TimeCounterState;

	public Controller BattleState;

	public GLoader background;

	public UI_mc_cloud01 cloud1;

	public UI_mc_cloud02 cloud2;

	public UI_mc_cloud03 cloud3;

	public UI_mc_cloud04 cloud4;

	public GGraph rayMask;

	public GButton BackBtn;

	public UI_Slider_VertUp Slider;

	public GList HoldingPercents;

	public UI_CampScore CampScore;

	public UI_AddButton AddBtn;

	public UI_MinusButton MinusBtn;

	public UI_MyLegion MyLegion;

	public UI_MsgBtn MsgBtn;

	public UI_BattleLogBtn BattleLogBtn;

	public GGraph n27;

	public GTextField n28;

	public GTextField Time;

	public GTextField n29;

	public GTextField ReplenishTimeText0;

	public GTextField ReplenishTime;

	public GTextField ReplenishTimeText1;

	public GGroup n31;

	public UI_OkBtn Ok;

	public UI_CancelBtn Cancel;

	public GGroup n34;

	public UI_Zoom Zoom;

	public UI_StrategyBtn StrategyBtn;

	public UI_StrategyDialog StrategyDialog;

	public GGraph MainIslandFakeClick;

	public GImage n47;

	public GImage n45;

	public GTextField TimeOnIsland;

	public GGroup TimeCounter2;

	public UI_TimeCounter TimeCounter1;

	public GGroup TimeCounterGroup;

	public GImage n51;

	public GTextField n52;

	public GGroup TipsWrapper;

	public GGroup Tips;

	public GImage n60;

	public GImage n57;

	public GImage n55;

	public GTextField TimeOnMap;

	public GTextField n59;

	public GImage n63;

	public GTextField n62;

	public GGroup n64;

	public UI_BestKill BestKill;

	public GGraph CampPos1;

	public GGraph CampPos2;

	public GGraph CampPos3;

	public GGraph CampPos4;

	public Transition TimeCounter1Scale;

	public Transition TipsWrapper_2;

	public const string URL = "ui://hd2s9kukfdar5x";

	public static string Name = "UI_GvGWorldMap2";

	public Action OnNotUIInput = delegate
	{
	};

	public Action<int> OnSelectStategy = delegate
	{
	};

	public List<int> OwnShipIds;

	private Coroutine TimeCounterCoroutine;

	private int SoldierMaxCount;

	private List<GameObject> Vfx;

	private List<GGraph> VfxGraph;

	private float OriginalBestKillY;

	public bool IsIzOver = false;

	private int CurBestKillUser = -1;

	private bool IsNewBestKillUserAppeared = false;

	public static string GetURL()
	{
		return "ui://hd2s9kukfdar5x";
	}

	public static UI_GvGWorldMap2 CreateInstance()
	{
		return (UI_GvGWorldMap2)(object)UIPackage.CreateObject("GvGWorldMap2", "GvGWorldMap2");
	}

	public static UI_GvGWorldMap2 CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_GvGWorldMap2).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://hd2s9kukfdar5x", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0059: Unknown result type (might be due to invalid IL or missing references)
		//IL_0063: Expected O, but got Unknown
		//IL_00c7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d1: Expected O, but got Unknown
		//IL_00dd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e7: Expected O, but got Unknown
		//IL_0109: Unknown result type (might be due to invalid IL or missing references)
		//IL_0113: Expected O, but got Unknown
		//IL_01a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ad: Expected O, but got Unknown
		//IL_01b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c3: Expected O, but got Unknown
		//IL_020c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0216: Expected O, but got Unknown
		//IL_025f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0269: Expected O, but got Unknown
		//IL_02b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_02bc: Expected O, but got Unknown
		//IL_0305: Unknown result type (might be due to invalid IL or missing references)
		//IL_030f: Expected O, but got Unknown
		//IL_035a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0364: Expected O, but got Unknown
		//IL_03af: Unknown result type (might be due to invalid IL or missing references)
		//IL_03b9: Expected O, but got Unknown
		//IL_03f1: Unknown result type (might be due to invalid IL or missing references)
		//IL_03fb: Expected O, but got Unknown
		//IL_0449: Unknown result type (might be due to invalid IL or missing references)
		//IL_0453: Expected O, but got Unknown
		//IL_045f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0469: Expected O, but got Unknown
		//IL_0475: Unknown result type (might be due to invalid IL or missing references)
		//IL_047f: Expected O, but got Unknown
		//IL_048b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0495: Expected O, but got Unknown
		//IL_04e0: Unknown result type (might be due to invalid IL or missing references)
		//IL_04ea: Expected O, but got Unknown
		//IL_050c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0516: Expected O, but got Unknown
		//IL_0522: Unknown result type (might be due to invalid IL or missing references)
		//IL_052c: Expected O, but got Unknown
		//IL_0538: Unknown result type (might be due to invalid IL or missing references)
		//IL_0542: Expected O, but got Unknown
		//IL_058d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0597: Expected O, but got Unknown
		//IL_05a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_05ad: Expected O, but got Unknown
		//IL_05b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_05c3: Expected O, but got Unknown
		//IL_05cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_05d9: Expected O, but got Unknown
		//IL_05e5: Unknown result type (might be due to invalid IL or missing references)
		//IL_05ef: Expected O, but got Unknown
		//IL_05fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0605: Expected O, but got Unknown
		//IL_0650: Unknown result type (might be due to invalid IL or missing references)
		//IL_065a: Expected O, but got Unknown
		//IL_06a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_06af: Expected O, but got Unknown
		//IL_06bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_06c5: Expected O, but got Unknown
		//IL_0710: Unknown result type (might be due to invalid IL or missing references)
		//IL_071a: Expected O, but got Unknown
		//IL_073c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0746: Expected O, but got Unknown
		//IL_0752: Unknown result type (might be due to invalid IL or missing references)
		//IL_075c: Expected O, but got Unknown
		//IL_0768: Unknown result type (might be due to invalid IL or missing references)
		//IL_0772: Expected O, but got Unknown
		//IL_077e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0788: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		PageController = ((GComponent)this).GetController("PageController");
		GoToMainIslandReplenish = ((GComponent)this).GetController("GoToMainIslandReplenish");
		TimeCounterState = ((GComponent)this).GetController("TimeCounterState");
		BattleState = ((GComponent)this).GetController("BattleState");
		background = (GLoader)((GComponent)this).GetChild("background");
		cloud1 = (UI_mc_cloud01)(object)((GComponent)this).GetChild("cloud1");
		cloud2 = (UI_mc_cloud02)(object)((GComponent)this).GetChild("cloud2");
		cloud3 = (UI_mc_cloud03)(object)((GComponent)this).GetChild("cloud3");
		cloud4 = (UI_mc_cloud04)(object)((GComponent)this).GetChild("cloud4");
		rayMask = (GGraph)((GComponent)this).GetChild("rayMask");
		BackBtn = (GButton)((GComponent)this).GetChild("BackBtn");
		Slider = (UI_Slider_VertUp)(object)((GComponent)this).GetChild("Slider");
		HoldingPercents = (GList)((GComponent)this).GetChild("HoldingPercents");
		CampScore = (UI_CampScore)(object)((GComponent)this).GetChild("CampScore");
		AddBtn = (UI_AddButton)(object)((GComponent)this).GetChild("AddBtn");
		MinusBtn = (UI_MinusButton)(object)((GComponent)this).GetChild("MinusBtn");
		MyLegion = (UI_MyLegion)(object)((GComponent)this).GetChild("MyLegion");
		MsgBtn = (UI_MsgBtn)(object)((GComponent)this).GetChild("MsgBtn");
		BattleLogBtn = (UI_BattleLogBtn)(object)((GComponent)this).GetChild("BattleLogBtn");
		n27 = (GGraph)((GComponent)this).GetChild("n27");
		n28 = (GTextField)((GComponent)this).GetChild("n28");
		string id = "ui://hd2s9kukfdar5x".Replace("ui://", "") + "-" + ((GObject)n28).id;
		((GObject)n28).text = LanguagesManager.GetDesc(id);
		Time = (GTextField)((GComponent)this).GetChild("Time");
		string id2 = "ui://hd2s9kukfdar5x".Replace("ui://", "") + "-" + ((GObject)Time).id;
		((GObject)Time).text = LanguagesManager.GetDesc(id2);
		n29 = (GTextField)((GComponent)this).GetChild("n29");
		string id3 = "ui://hd2s9kukfdar5x".Replace("ui://", "") + "-" + ((GObject)n29).id;
		((GObject)n29).text = LanguagesManager.GetDesc(id3);
		ReplenishTimeText0 = (GTextField)((GComponent)this).GetChild("ReplenishTimeText0");
		string id4 = "ui://hd2s9kukfdar5x".Replace("ui://", "") + "-" + ((GObject)ReplenishTimeText0).id;
		((GObject)ReplenishTimeText0).text = LanguagesManager.GetDesc(id4);
		ReplenishTime = (GTextField)((GComponent)this).GetChild("ReplenishTime");
		string id5 = "ui://hd2s9kukfdar5x".Replace("ui://", "") + "-" + ((GObject)ReplenishTime).id;
		((GObject)ReplenishTime).text = LanguagesManager.GetDesc(id5);
		ReplenishTimeText1 = (GTextField)((GComponent)this).GetChild("ReplenishTimeText1");
		string id6 = "ui://hd2s9kukfdar5x".Replace("ui://", "") + "-" + ((GObject)ReplenishTimeText1).id;
		((GObject)ReplenishTimeText1).text = LanguagesManager.GetDesc(id6);
		n31 = (GGroup)((GComponent)this).GetChild("n31");
		Ok = (UI_OkBtn)(object)((GComponent)this).GetChild("Ok");
		Cancel = (UI_CancelBtn)(object)((GComponent)this).GetChild("Cancel");
		n34 = (GGroup)((GComponent)this).GetChild("n34");
		Zoom = (UI_Zoom)(object)((GComponent)this).GetChild("Zoom");
		StrategyBtn = (UI_StrategyBtn)(object)((GComponent)this).GetChild("StrategyBtn");
		StrategyDialog = (UI_StrategyDialog)(object)((GComponent)this).GetChild("StrategyDialog");
		MainIslandFakeClick = (GGraph)((GComponent)this).GetChild("MainIslandFakeClick");
		n47 = (GImage)((GComponent)this).GetChild("n47");
		n45 = (GImage)((GComponent)this).GetChild("n45");
		TimeOnIsland = (GTextField)((GComponent)this).GetChild("TimeOnIsland");
		string id7 = "ui://hd2s9kukfdar5x".Replace("ui://", "") + "-" + ((GObject)TimeOnIsland).id;
		((GObject)TimeOnIsland).text = LanguagesManager.GetDesc(id7);
		TimeCounter2 = (GGroup)((GComponent)this).GetChild("TimeCounter2");
		TimeCounter1 = (UI_TimeCounter)(object)((GComponent)this).GetChild("TimeCounter1");
		TimeCounterGroup = (GGroup)((GComponent)this).GetChild("TimeCounterGroup");
		n51 = (GImage)((GComponent)this).GetChild("n51");
		n52 = (GTextField)((GComponent)this).GetChild("n52");
		string id8 = "ui://hd2s9kukfdar5x".Replace("ui://", "") + "-" + ((GObject)n52).id;
		((GObject)n52).text = LanguagesManager.GetDesc(id8);
		TipsWrapper = (GGroup)((GComponent)this).GetChild("TipsWrapper");
		Tips = (GGroup)((GComponent)this).GetChild("Tips");
		n60 = (GImage)((GComponent)this).GetChild("n60");
		n57 = (GImage)((GComponent)this).GetChild("n57");
		n55 = (GImage)((GComponent)this).GetChild("n55");
		TimeOnMap = (GTextField)((GComponent)this).GetChild("TimeOnMap");
		string id9 = "ui://hd2s9kukfdar5x".Replace("ui://", "") + "-" + ((GObject)TimeOnMap).id;
		((GObject)TimeOnMap).text = LanguagesManager.GetDesc(id9);
		n59 = (GTextField)((GComponent)this).GetChild("n59");
		string id10 = "ui://hd2s9kukfdar5x".Replace("ui://", "") + "-" + ((GObject)n59).id;
		((GObject)n59).text = LanguagesManager.GetDesc(id10);
		n63 = (GImage)((GComponent)this).GetChild("n63");
		n62 = (GTextField)((GComponent)this).GetChild("n62");
		string id11 = "ui://hd2s9kukfdar5x".Replace("ui://", "") + "-" + ((GObject)n62).id;
		((GObject)n62).text = LanguagesManager.GetDesc(id11);
		n64 = (GGroup)((GComponent)this).GetChild("n64");
		BestKill = (UI_BestKill)(object)((GComponent)this).GetChild("BestKill");
		CampPos1 = (GGraph)((GComponent)this).GetChild("CampPos1");
		CampPos2 = (GGraph)((GComponent)this).GetChild("CampPos2");
		CampPos3 = (GGraph)((GComponent)this).GetChild("CampPos3");
		CampPos4 = (GGraph)((GComponent)this).GetChild("CampPos4");
		TimeCounter1Scale = ((GComponent)this).GetTransition("TimeCounter1Scale");
		TipsWrapper_2 = ((GComponent)this).GetTransition("TipsWrapper");
	}

	public void Init(Dictionary<string, object> parameters)
	{
		if (parameters.TryGetValue("OwnShipIds", out var value))
		{
			OwnShipIds = (List<int>)value;
		}
		SharedMessenger.Broadcast("ON_GVG2_INSTANCE_START");
		GameController.Contexts.Service<IUiService>().PushBackupAndCloseAllUIs(new List<string>
		{
			Name,
			UI_IslandComeAgainBattleRecordsPanel.Name,
			UI_IslandComeAgainBattleRecordDetailPanel.Name
		});
		FGUIManager.SetUiPanelSizeAndXy((GObject)(object)this);
		Slider.Init(5.4f, 8.64f, 8.64f);
		CampScoreListInit();
		GvGWorldMapController.CreateInstance(this);
		InitBestKill();
	}

	public void SwitchToOnIslandMode()
	{
		PageController.selectedIndex = 4;
		((GObject)StrategyDialog).visible = false;
		InitHoldingCampUI();
	}

	public void SetZoomLevel(int zoomLevel)
	{
		Zoom.Type.selectedIndex = ((zoomLevel == 1) ? 1 : 0);
	}

	public void OnShow()
	{
		UiTagManager instance = UiTagManager.Instance;
		instance.Register("GvGWorldMap2.CampScore", CampScore);
		instance.Register("GvGWorldMap2.MyLegion", MyLegion);
		instance.Register("GvGWorldMap2.HoldingPercents", HoldingPercents);
		instance.Register("GvGWorldMap2.StrategyBtn", StrategyBtn);
	}

	public static void ClosePanel()
	{
		GameController.Contexts.Service<IUiService>().ClosePanel(Name, reservePackageRes: true);
	}

	private void End()
	{
		if ((Object)(object)GvGIslandController.Instance != (Object)null)
		{
			OpenTipPanel(LanguagesManager.GetDesc("IslandComeAgainQuitTip"), delegate
			{
				GvGIslandController.Instance.BackToMap();
			}, (AlignType)1);
		}
		else
		{
			OpenTipPanel(LanguagesManager.GetDesc("IslandComeAgainQuitBattleFieldTip"), ClosePanel, (AlignType)1);
		}
	}

	public void OpenTipPanel(string content, Action OnConfirm, AlignType alignType, Action OnCancel = null)
	{
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		GameController.Contexts.Service<IUiService>().OpenPanel(UI_UniversalConfirmPopup.Name, new Dictionary<string, object>
		{
			{ "TipTextAlign", alignType },
			{ "Content", content },
			{
				"Buttons",
				new Dictionary<string, Action>
				{
					{ "Confirm", OnConfirm },
					{
						"Cancel",
						delegate
						{
							OnCancel?.Invoke();
						}
					}
				}
			},
			{ "PageIndex", 0 },
			{ "FontSize", 33 },
			{ "Order", 999999 }
		});
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
		((GObject)rayMask).onTouchBegin.Add(new EventCallback1(OnDragBegin));
		((GObject)rayMask).onTouchMove.Add(new EventCallback1(OnDrag));
		((GObject)rayMask).onTouchEnd.Add(new EventCallback1(OnDragEnd));
		((GObject)rayMask).onClick.Set(new EventCallback0(OnCloseStrategyDialog));
		((GObject)StrategyBtn).onClick.Set(new EventCallback0(OnOpenStrategyDialog));
		((GObject)BackBtn).onClick.Add(new EventCallback0(End));
		PageController.onChanged.Add(new EventCallback1(OnChangePage));
		((GObject)BattleLogBtn).onClick.Add(new EventCallback0(OpenBattleRecord));
		S2C_ChangeShipSummaryStateShipFillingUp.OnPushEvent = (Action<S2C_ChangeShipSummaryStateShipFillingUp.Request>)Delegate.Combine(S2C_ChangeShipSummaryStateShipFillingUp.OnPushEvent, new Action<S2C_ChangeShipSummaryStateShipFillingUp.Request>(Singleton<GvGInstanceZone>.Instance.UpdateShipSummaryStateShipFillingUp));
		S2C_IZOver.OnPushEvent = (Action<S2C_IZOver.Request>)Delegate.Combine(S2C_IZOver.OnPushEvent, new Action<S2C_IZOver.Request>(Singleton<GvGInstanceZone>.Instance.OpenBattleResultPanel));
		S2C_IZOver.OnPushEvent = (Action<S2C_IZOver.Request>)Delegate.Combine(S2C_IZOver.OnPushEvent, new Action<S2C_IZOver.Request>(OnBattleEnd));
		SharedMessenger.AddListener<SocketManager.SocketConnection>("ON_SOCKET_ERROR_EXT", OnSocketError);
	}

	public void UnregisterUiEventListeners()
	{
		//IL_0079: Unknown result type (might be due to invalid IL or missing references)
		//IL_0083: Expected O, but got Unknown
		//IL_0096: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a0: Expected O, but got Unknown
		((GObject)rayMask).onTouchBegin.Clear();
		((GObject)rayMask).onTouchMove.Clear();
		((GObject)rayMask).onTouchEnd.Clear();
		((GObject)rayMask).onClick.Clear();
		((GObject)StrategyBtn).onClick.Clear();
		((GObject)BackBtn).onClick.Clear();
		PageController.onChanged.Remove(new EventCallback1(OnChangePage));
		((GObject)BattleLogBtn).onClick.Remove(new EventCallback0(OpenBattleRecord));
		S2C_ChangeShipSummaryStateShipFillingUp.OnPushEvent = (Action<S2C_ChangeShipSummaryStateShipFillingUp.Request>)Delegate.Remove(S2C_ChangeShipSummaryStateShipFillingUp.OnPushEvent, new Action<S2C_ChangeShipSummaryStateShipFillingUp.Request>(Singleton<GvGInstanceZone>.Instance.UpdateShipSummaryStateShipFillingUp));
		S2C_IZOver.OnPushEvent = (Action<S2C_IZOver.Request>)Delegate.Remove(S2C_IZOver.OnPushEvent, new Action<S2C_IZOver.Request>(Singleton<GvGInstanceZone>.Instance.OpenBattleResultPanel));
		S2C_IZOver.OnPushEvent = (Action<S2C_IZOver.Request>)Delegate.Remove(S2C_IZOver.OnPushEvent, new Action<S2C_IZOver.Request>(OnBattleEnd));
		SharedMessenger.RemoveListener<SocketManager.SocketConnection>("ON_SOCKET_ERROR_EXT", OnSocketError);
	}

	private void InitBestKill()
	{
		//IL_00c8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d2: Unknown result type (might be due to invalid IL or missing references)
		//IL_0108: Unknown result type (might be due to invalid IL or missing references)
		//IL_0112: Unknown result type (might be due to invalid IL or missing references)
		//IL_0148: Unknown result type (might be due to invalid IL or missing references)
		//IL_0152: Unknown result type (might be due to invalid IL or missing references)
		//IL_0188: Unknown result type (might be due to invalid IL or missing references)
		//IL_0192: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c8: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d2: Unknown result type (might be due to invalid IL or missing references)
		OriginalBestKillY = ((GObject)BestKill).y;
		VfxGraph = new List<GGraph>();
		Vfx = new List<GameObject>();
		((GObject)BestKill.ChangeVfx).visible = false;
		VfxGraph.Add(BestKill.LoopVfx);
		VfxGraph.Add(BestKill.ChangeVfx);
		VfxGraph.Add(BestKill.AppearVfx);
		VfxGraph.Add(BestKill.DisappearVfx);
		VfxGraph.Add(BestKill.Disappear2Vfx);
		Vfx.Add(FGUIManager.Instance.AddTextSpecialEffects(BestKill.LoopVfx, "ui_gvg_bestplayer_loop", Vector3.one * 100f));
		Vfx.Add(FGUIManager.Instance.AddTextSpecialEffects(BestKill.ChangeVfx, "ui_gvg_bestplayer_Change", Vector3.one * 100f));
		Vfx.Add(FGUIManager.Instance.AddTextSpecialEffects(BestKill.AppearVfx, "ui_gvg_bestplayer_appear", Vector3.one * 100f));
		Vfx.Add(FGUIManager.Instance.AddTextSpecialEffects(BestKill.DisappearVfx, "ui_gvg_bestplayer_disappear", Vector3.one * 100f));
		Vfx.Add(FGUIManager.Instance.AddTextSpecialEffects(BestKill.Disappear2Vfx, "ui_gvg_bestplayer_disappear2", Vector3.one * 100f));
	}

	private void OnChangePage(EventContext context)
	{
		BattleState.selectedIndex = 0;
		int selectedIndex = PageController.selectedIndex;
		if (selectedIndex == 1 || selectedIndex == 4)
		{
			((GObject)BestKill).y = OriginalBestKillY;
		}
		else
		{
			((GObject)BestKill).y = -1000f;
		}
	}

	public void OnSetShipDetails(C2S_GetShipSummaryAndFlightScheduleInfo myShipSummary, int myCampId)
	{
		eShipSummaryState state = (eShipSummaryState)myShipSummary.State;
		if (state == eShipSummaryState.DuringFlight)
		{
			((GObject)MyLegion.State).text = LanguagesManager.GetDesc("IslandComeAgainShipFlyingTo");
			int[] route = myShipSummary.FlightSchedule.Route;
			Island islandById = GvGWorldMapController.Instance.MapDataManager.GetIslandById($"{route[^1]}");
			((GObject)MyLegion.StayIslandName).text = islandById.Name;
		}
		else
		{
			((GObject)MyLegion.State).text = LanguagesManager.GetDesc("IslandComeAgainShipStationedAt");
			Island islandById2 = GvGWorldMapController.Instance.MapDataManager.GetIslandById($"{myShipSummary.StayIslandId}");
			((GObject)MyLegion.StayIslandName).text = islandById2.Name;
		}
		UpdateMyLegionSoldierCount(myShipSummary.GroupInfo, myShipSummary.FillUpTimestamp);
		MyLegion.CampId.selectedIndex = myCampId;
		MyLegion.Avatar.CampId.selectedIndex = myCampId;
		AvatarHelper.GetUserAvatarSprite($"{myCampId}", myShipSummary.UserId, delegate(Sprite sprite)
		{
			//IL_002d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0037: Expected O, but got Unknown
			if (!((GObject)MyLegion).isDisposed)
			{
				MyLegion.Avatar.HeadPortrait.icon.texture = new NTexture((Texture)(object)sprite.texture);
			}
		});
	}

	public void OnUpdateSoldierCount(int soldierRemaining)
	{
		((GObject)MyLegion.SoldierCount).text = $"{soldierRemaining}/{SoldierMaxCount}";
	}

	public void OnSetIZState(C2S_GetGvGMode2IZConfig.Response iZState)
	{
		if (TimeCounterCoroutine != null)
		{
			((MonoBehaviour)FGUIManager.Instance).StopCoroutine(TimeCounterCoroutine);
			TimeCounterCoroutine = null;
		}
		TimeCounterCoroutine = ((MonoBehaviour)FGUIManager.Instance).StartCoroutine(TimeCounter(iZState));
		Dictionary<int, int> scores = JsonHelper.ToObject<Dictionary<int, int>>(iZState.CampScore);
		OnChangeCampScore(scores);
	}

	private void UpdateMyLegionSoldierCount(List<ShipSummaryUnitInfo> groupInfo, Dictionary<string, int> fillUpTimestamp)
	{
		int num = 0;
		foreach (ShipSummaryUnitInfo item in groupInfo)
		{
			num += item.CurCnt;
		}
		SoldierMaxCount = 0;
		foreach (ShipSummaryUnitInfo item2 in groupInfo)
		{
			SoldierMaxCount += item2.Total;
		}
		string text = $"{num}/{SoldierMaxCount}";
		if (fillUpTimestamp == null || fillUpTimestamp.Count <= 0)
		{
			((GObject)MyLegion.SoldierCount).text = text;
			return;
		}
		int num2 = fillUpTimestamp.Values.OrderByDescending((int t) => t).ToArray()[0];
		int num3 = (int)GameController.Instance.GetServerTime();
		if (num3 >= num2 - 1)
		{
			((GObject)MyLegion.SoldierCount).text = text;
		}
		else
		{
			FGUIManager.Instance.OpenIEnumerator(ShowMyLegionSoldierCountDelay(text, num2 - num3));
		}
	}

	private IEnumerator ShowMyLegionSoldierCountDelay(string soldierCountText, float delayTime)
	{
		yield return (object)new WaitForSeconds(delayTime);
		if (!((GObject)MyLegion.SoldierCount).isDisposed)
		{
			((GObject)MyLegion.SoldierCount).text = soldierCountText;
		}
	}

	private IEnumerator TimeCounter(C2S_GetGvGMode2IZConfig.Response iZState)
	{
		int targetTime = 0;
		if (iZState.IZProgress == 1)
		{
			targetTime = iZState.IZBeginTimestamp + 60;
		}
		else if (iZState.IZProgress == 2)
		{
			targetTime = iZState.IZEndTimestamp;
		}
		while (targetTime != -1)
		{
			int timeLeft = targetTime - (int)GameController.Instance.GetServerTime();
			if (timeLeft < 0)
			{
				targetTime = -1;
				timeLeft = 0;
			}
			((GObject)TimeOnMap).text = UiHelper.ParseTimeShort(timeLeft);
			yield return null;
		}
	}

	public void StartIslandStopCounter(int islandStopTime)
	{
		if (TimeCounterCoroutine != null)
		{
			((MonoBehaviour)FGUIManager.Instance).StopCoroutine(TimeCounterCoroutine);
			TimeCounterCoroutine = null;
		}
		TimeCounterCoroutine = ((MonoBehaviour)FGUIManager.Instance).StartCoroutine(TimeCounter_OnIsland(islandStopTime));
	}

	private IEnumerator TimeCounter_OnIsland(int targetTime)
	{
		while (targetTime != -1)
		{
			int timeLeft = targetTime - (int)GameController.Instance.GetServerTime();
			if (timeLeft < 0)
			{
				targetTime = -1;
				timeLeft = 0;
			}
			if (timeLeft < 15)
			{
				TimeCounterState.selectedIndex = 2;
			}
			else if (timeLeft < 30)
			{
				TimeCounterState.selectedIndex = 1;
			}
			else
			{
				TimeCounterState.selectedIndex = 0;
			}
			string timeText = UiHelper.ParseTimeShort(timeLeft);
			if (timeText != ((GObject)TimeOnIsland).text)
			{
				((GObject)TimeOnIsland).text = timeText;
				((GObject)TimeCounter1.TimeOnIsland).text = timeText;
				TimeCounter1.TimeCounterHeartBeat.Play();
			}
			yield return null;
		}
	}

	public void OnChangeHoldingPercentOnIsland(Dictionary<int, int> holdingPercent)
	{
		GList holdingPercents = HoldingPercents;
		for (int i = 0; i < holdingPercents.numItems; i++)
		{
			UI_HoldingPercent uI_HoldingPercent = (UI_HoldingPercent)(object)((GComponent)holdingPercents).GetChildAt(i);
			int selectedIndex = uI_HoldingPercent.CampId.selectedIndex;
			if (holdingPercent.TryGetValue(selectedIndex, out var value))
			{
				((GObject)uI_HoldingPercent.HoldingPercent).text = $"{value}%";
			}
		}
	}

	public void OnChangeHoldingCamp(int holdingCamp)
	{
		GList holdingPercents = HoldingPercents;
		for (int i = 0; i < holdingPercents.numItems; i++)
		{
			UI_HoldingPercent uI_HoldingPercent = (UI_HoldingPercent)(object)((GComponent)holdingPercents).GetChildAt(i);
			int selectedIndex = uI_HoldingPercent.CampId.selectedIndex;
			if (selectedIndex == holdingCamp)
			{
				uI_HoldingPercent.State.selectedIndex = 1;
			}
			else
			{
				uI_HoldingPercent.State.selectedIndex = 0;
			}
		}
	}

	private void InitHoldingCampUI()
	{
		GList holdingPercents = HoldingPercents;
		for (int i = 0; i < holdingPercents.numItems; i++)
		{
			UI_HoldingPercent uI_HoldingPercent = (UI_HoldingPercent)(object)((GComponent)holdingPercents).GetChildAt(i);
			((GObject)uI_HoldingPercent.HoldingPercent).text = "0%";
			uI_HoldingPercent.State.selectedIndex = 0;
		}
	}

	private void CampScoreListInit()
	{
		for (int i = 0; i < ((GComponent)CampScore.List).numChildren; i++)
		{
			UI_CampScoreSlot uI_CampScoreSlot = (UI_CampScoreSlot)(object)((GComponent)CampScore.List).GetChildAt(i);
			((GObject)uI_CampScoreSlot.Score).text = "0";
			((GObject)uI_CampScoreSlot.n5).text = "/2000";
		}
	}

	public void OnChangeCampScore(Dictionary<int, int> scores, float tweenTime = 0f)
	{
		//IL_0098: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a2: Expected O, but got Unknown
		//IL_00a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b3: Expected O, but got Unknown
		GList list = CampScore.List;
		for (int i = 0; i < list.numItems; i++)
		{
			UI_CampScoreSlot slot = (UI_CampScoreSlot)(object)((GComponent)list).GetChildAt(i);
			int selectedIndex = slot.CampId.selectedIndex;
			if (!scores.TryGetValue(selectedIndex, out var score))
			{
				continue;
			}
			int num = int.Parse(((GObject)slot.Score).text);
			if (num < score)
			{
				GTween.To((float)num, (float)score, tweenTime).SetEase((EaseType)17).OnUpdate((GTweenCallback1)delegate(GTweener tweener)
				{
					((GObject)slot.Score).text = $"{(int)tweener.value.x}";
				})
					.OnComplete((GTweenCallback1)delegate
					{
						((GObject)slot.Score).text = $"{score}";
					});
			}
		}
	}

	public int RevertCampScoreToPrevious(int campId, int incIslandScore)
	{
		GList list = CampScore.List;
		for (int i = 0; i < list.numItems; i++)
		{
			UI_CampScoreSlot uI_CampScoreSlot = (UI_CampScoreSlot)(object)((GComponent)list).GetChildAt(i);
			if (uI_CampScoreSlot.CampId.selectedIndex == campId)
			{
				int num = int.Parse(((GObject)uI_CampScoreSlot.Score).text);
				((GObject)uI_CampScoreSlot.Score).text = $"{num - incIslandScore}";
				return num;
			}
		}
		return 0;
	}

	public void OnDragBegin(EventContext context)
	{
		OnNotUIInput();
		context.CaptureTouch();
	}

	public void OnDrag(EventContext context)
	{
		OnNotUIInput();
	}

	public void OnDragEnd(EventContext context)
	{
		OnNotUIInput();
		context.CaptureTouch();
	}

	private void OpenBattleRecord()
	{
		Singleton<GvGInstanceZone>.Instance.GetAllBattleRecordSummary(inZone: true, OpenBattleRecordPanel);
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

	public void InitStrategyDialog(int myCampId, int selectedCampId)
	{
		//IL_011c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0126: Expected O, but got Unknown
		//IL_007f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0089: Expected O, but got Unknown
		GList selections = StrategyDialog.Selections;
		int num = 1;
		for (int i = 0; i < selections.numItems - 1; i++)
		{
			UI_StrategySelection slot = (UI_StrategySelection)(object)((GComponent)selections).GetChildAt(i);
			if (num == myCampId)
			{
				num++;
			}
			slot.Type.selectedIndex = num++;
			((GObject)slot).onClick.Set((EventCallback0)delegate
			{
				OnSelectStrategy(slot);
			});
			string campIslandName = MapDataManager.GetCampIslandName(slot.Type.selectedIndex);
			((GObject)slot.StrategyTitle).text = LanguagesManager.GetDesc("IslandComeAgainAdvance_Prefix") + campIslandName;
		}
		UI_StrategySelection lastSlot = (UI_StrategySelection)(object)((GComponent)selections).GetChildAt(selections.numItems - 1);
		lastSlot.Type.selectedIndex = 0;
		((GObject)lastSlot).onClick.Set((EventCallback0)delegate
		{
			OnSelectStrategy(lastSlot);
		});
		((GObject)lastSlot.StrategyTitle).text = LanguagesManager.GetDesc("IslandComeAgainStrategyFree");
		if (selectedCampId == -1)
		{
			selectedCampId = 0;
		}
		StrategyBtn.CampId.selectedIndex = selectedCampId;
	}

	private void OnOpenStrategyDialog()
	{
		((GObject)StrategyDialog).visible = true;
	}

	private void OnCloseStrategyDialog()
	{
		((GObject)StrategyDialog).visible = false;
	}

	private void OnSelectStrategy(UI_StrategySelection selection)
	{
		int num = selection.Type.selectedIndex;
		StrategyBtn.CampId.selectedIndex = num;
		if (num == 0)
		{
			num = -1;
		}
		OnSelectStategy?.Invoke(num);
		OnCloseStrategyDialog();
	}

	public IEnumerator ProccessBestKill(int userId, int killCount, int campId, bool isKilled = false)
	{
		if (CurBestKillUser != userId && CurBestKillUser != -1)
		{
			bool isCompleted = false;
			SetBestKillDisappear(isKilled, delegate
			{
				isCompleted = true;
			});
			while (!isCompleted)
			{
				yield return null;
			}
			yield return (object)new WaitForSeconds(1f);
			if (((GObject)BestKill).isDisposed)
			{
				yield break;
			}
			CurBestKillUser = -1;
			IsNewBestKillUserAppeared = false;
			((GObject)BestKill.n16).xy = new Vector2(-40f, -124f);
		}
		if (killCount < 5)
		{
			yield break;
		}
		bool isCompleted2 = false;
		if (!IsNewBestKillUserAppeared)
		{
			isCompleted2 = false;
			SetBestKillAppear(campId, userId, delegate
			{
				isCompleted2 = true;
			});
			while (!isCompleted2)
			{
				yield return null;
			}
			if (((GObject)BestKill).isDisposed)
			{
				yield break;
			}
			CurBestKillUser = userId;
			IsNewBestKillUserAppeared = true;
		}
		isCompleted2 = false;
		SetBestKillChangeNum(killCount, delegate
		{
			isCompleted2 = true;
		});
		while (!isCompleted2)
		{
			yield return null;
		}
	}

	public void SetBestKillAppear(int campId, int userId, Action OnComplete = null)
	{
		//IL_0096: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a0: Expected O, but got Unknown
		BestKill.Avatar.CampId.selectedIndex = campId;
		AvatarHelper.GetUserAvatarSprite($"{campId}", userId, delegate(Sprite sprite)
		{
			//IL_0037: Unknown result type (might be due to invalid IL or missing references)
			//IL_0041: Expected O, but got Unknown
			if (!((GObject)BestKill).isDisposed)
			{
				BestKill.Avatar.HeadPortrait.icon.texture = new NTexture((Texture)(object)sprite.texture);
			}
		});
		ProfileHelper.GetUserProfile($"{campId}", userId, delegate(UserProfile profile)
		{
			if (!((GObject)BestKill).isDisposed)
			{
				((GObject)BestKill.PlayerName).text = profile.Name;
			}
		});
		BestKill.State.selectedIndex = 1;
		BestKill.Appear.Play((PlayCompleteCallback)delegate
		{
			BestKill.State.selectedIndex = 2;
			OnComplete?.Invoke();
		});
	}

	public void SetBestKillChangeNum(int num, Action OnComplete = null)
	{
		//IL_0070: Unknown result type (might be due to invalid IL or missing references)
		//IL_007a: Expected O, but got Unknown
		if (!((GObject)BestKill).isDisposed)
		{
			((GObject)BestKill.ChangeVfx).visible = true;
			((GObject)BestKill.BestKillNumber.Num).text = $"{num}";
			BestKill.Change.Play((PlayCompleteCallback)delegate
			{
				OnComplete?.Invoke();
				((GObject)BestKill.ChangeVfx).visible = false;
			});
		}
	}

	public void SetBestKillDisappear(bool isKilled, Action OnComplete = null)
	{
		//IL_0096: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a0: Expected O, but got Unknown
		//IL_0051: Unknown result type (might be due to invalid IL or missing references)
		//IL_005b: Expected O, but got Unknown
		if (isKilled)
		{
			((GObject)BestKill.DisappearVfx).visible = true;
			((GObject)BestKill.Disappear2Vfx).visible = false;
			BestKill.DisAppear.Play((PlayCompleteCallback)delegate
			{
				BestKill.State.selectedIndex = 0;
				OnComplete?.Invoke();
			});
		}
		else
		{
			((GObject)BestKill.DisappearVfx).visible = false;
			((GObject)BestKill.Disappear2Vfx).visible = true;
			BestKill.DisAppear2.Play((PlayCompleteCallback)delegate
			{
				BestKill.State.selectedIndex = 0;
				OnComplete?.Invoke();
			});
		}
		BestKill.State.selectedIndex = 3;
	}

	public void SetToWatchGameMode()
	{
		BattleState.selectedIndex = 1;
	}

	public void BeforeDestroy()
	{
		for (int i = 0; i < Vfx.Count; i++)
		{
			UiHelper.DestoryUiSfx(VfxGraph[i], Vfx[i], 0f);
		}
		Singleton<CameraService>.Instance.SwitchToScene("MainCity.Right");
		GvGIslandController.ReleaseInstance();
		GvGWorldMapController.ReleaseInstance();
		if (TimeCounterCoroutine != null)
		{
			((MonoBehaviour)FGUIManager.Instance).StopCoroutine(TimeCounterCoroutine);
		}
	}

	public void Destroy()
	{
		((MonoBehaviour)FGUIManager.Instance).StartCoroutine(DelayRecover());
		UiTagManager instance = UiTagManager.Instance;
		instance.Unregister("GvGWorldMap2.CampScore", CampScore);
		instance.Unregister("GvGWorldMap2.MyLegion", MyLegion);
		instance.Unregister("GvGWorldMap2.HoldingPercents", HoldingPercents);
		instance.Unregister("GvGWorldMap2.StrategyBtn", StrategyBtn);
	}

	private IEnumerator DelayRecover()
	{
		yield return null;
		GameController.Contexts.Service<IUiService>().RecoverLastBackup();
	}

	private void OnBattleEnd(S2C_IZOver.Request request)
	{
		IsIzOver = true;
	}

	private void OnSocketError(SocketManager.SocketConnection connection)
	{
		if (!GameController.Contexts.Service<IUiService>().HasShowingUi(UI_UniversalConfirmPopup.Name))
		{
			HashSet<eConType> hashSet = new HashSet<eConType>
			{
				eConType.GvGMode2Island,
				eConType.GvGMode2WorldMap
			};
			if (hashSet.Contains(connection.Type) && !IsIzOver)
			{
				GameController.Contexts.Service<IUiService>().ShowWaitingAnimation(show: false);
				LanguagesManager.GetDesc("Gvg2SocketErrorExitTip").ToConfirmPopup(OnConfirm, null, (AlignType)0, 40, mirrorBtns: false, needCancelButton: false);
			}
		}
		static void OnConfirm()
		{
			ClosePanel();
		}
	}
}
