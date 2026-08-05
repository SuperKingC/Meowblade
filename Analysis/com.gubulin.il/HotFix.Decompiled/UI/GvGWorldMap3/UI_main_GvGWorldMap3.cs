using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Assets.Scripts.Managers;
using Assets.Scripts.UI;
using FairyGUI;
using FairyGUI.Utils;
using GvG3;
using HotFix.Sources.Base.Scripts.Helper;
using HotFix.Sources.Base.Sources.Scripts.GvG3.GvG3Common.Manager;
using HotFix.Sources.Base.Sources.Scripts.GvG3.GvG3UI.UI.GvGTalent.OuterTechStatic;
using HotFix.Sources.Base.Sources.Scripts.GvG3Common.Manager;
using HotFix.Sources.Base.Sources.Scripts.GvG3Common.Model.OuterTech;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Helper;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Manager;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Model;
using HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Controller;
using HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Helper;
using HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Manager;
using HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Model;
using Shift.Legion.ClientApi.Models;
using Shift.Legion.Common.Helpers;
using Shift.Legion.Common.Managers;
using Shift.Legion.Common.Services;
using Shift.Legion.GvG.Common.Models.GvGMode3;
using Shift.Legion.GvGServer.Models.GvGMode3IslandManagerSocket;
using Shift.Legion.GvGServer.Models.GvGMode3IslandManagerSocket.Mission;
using Spine.Unity;
using UI.GvG3Leaderboard;
using UI.GvG3MainStorylineQuest;
using UI.GvG3StoreEntrance;
using UI.GvGAmplifierEntries;
using UI.GvGBattlePass3;
using UI.GvGBattleRecord3;
using UI.GvGBrawlFight;
using UI.GvGChat;
using UI.GvGExpeditionHall;
using UI.GvGFlagship3;
using UI.GvGLoading;
using UI.GvGShipOverview;
using UI.GvGStoreHouse;
using UI.GvGTalent;
using UI.MainCity;
using UI.Tips;
using UnityEngine;
using UnityEngine.Rendering;

namespace UI.GvGWorldMap3;

public class UI_main_GvGWorldMap3 : GComponent, IUiController
{
	public Controller IslandSelect;

	public Controller JumpEffectController;

	public Controller PreventInput;

	public Controller ProgressController;

	public Controller WaitOpenEternalNight;

	public Controller ShowBrawlEventTip;

	public GLoader background;

	public GGraph rayMask;

	public GButton BackBtn;

	public UI_com_SliderVertUp Slider;

	public UI_btn_AddButton AddBtn;

	public UI_btn_MinusButton MinusBtn;

	public UI_btn_Records Records;

	public UI_btn_TechnologyOffTheField TechnologyOffTheField;

	public UI_btn_TechnologyOnTheField Talents;

	public UI_btn_GvGStore ExpeditionStore;

	public UI_btn_MeleeStore MeleeStore;

	public UI_btn_GvGStorehouse GvGStorehouseBtn;

	public UI_btn_Amplifier Amplifier;

	public UI_btn_ExpeditionLeaderboard ExpeditionLeaderboard;

	public UI_btn_BattlePass BattlePass;

	public UI_btn_FlagShipMission FlagShipMission;

	public UI_com_SweepEffect SweepEffect;

	public UI_btn_Operation_Cancel Operation_Cancel;

	public UI_dec_OpertarionShipBG n90;

	public GImage n93;

	public GTextField n92;

	public UI_dec_Text02_Animation n111;

	public UI_com_ShipsInfo ShipsInfo;

	public UI_btn_ShipOverview ShipsOverview;

	public UI_com_RandomEvents IslandEvents;

	public UI_com_OperationDialog OperationDialog;

	public UI_com_SweepOperationDialog SweepOperationDialog;

	public UI_com_ShipPlanOperationDialog ShipPlanOperationDialog;

	public UI_com_IslandFilters IslandFilters;

	public UI_btn_IslandsFilter Filter;

	public UI_btn_TreasureMap CurrentTreasureMap;

	public UI_com_MainStorylineProgress Progress;

	public UI_com_LandOfNightStep1 LandOfEternalNightStep1;

	public UI_com_LandOfNightStep2 LandOfEternalNightStep2;

	public UI_com_LandOfNightEnd LandOfEternalNightEnd;

	public UI_btn_Leaderboard LeaderboardBtn;

	public UI_btn_BestOfToday BestOfToday;

	public GImage n120;

	public GImage n121;

	public GList BrawlFightHoldingPercents;

	public UI_btn_BrawlEventTip BrawlEventTip;

	public UI_btn_brawlfightBuff buffBtn;

	public UI_btn_MotherShip flagShipBtn;

	public GGroup n103;

	public UI_com_WaitOpenEternalNight EternalNightTip;

	public UI_com_JumpEffect JumpEffect;

	public GGraph PreventInputMask;

	public GImage n112;

	public UI_com_IslandCardLoader IslandCard;

	public Transition ShowOperationDialog;

	public Transition ShowSelectShipBg;

	public Transition HideSelectShipBg;

	public Transition DisplaySweepDialog;

	public Transition DisplayShipPlanDialog;

	public const string URL = "ui://4eq8fgd2bqhp0";

	public static string Name = "UI_main_GvGWorldMap3";

	public const string ENTER_GAME = "ENTER_GAME";

	public static Vector2 GvGStorehouseBtnWorldPos;

	private float _currentSliderValue;

	private bool IsOpenedByRecovery;

	public int CurrentIslandId = -1;

	public bool IsIslandStateRegistered = false;

	private readonly Lazy<十六加八TalentEffect> _十六加八Lazy = new Lazy<十六加八TalentEffect>(() => new 十六加八TalentEffect());

	private ShipAnimCacheManager ShipAnimCacheManager;

	private GoWrapper SpineGoWrapper;

	private GoWrapper FxGoWrapper;

	private SkeletonAnimation _fxAnimation;

	private SkeletonAnimation _shipAnimation;

	private Coroutine InitCoroutine;

	public eIslandAction IslandActionType { get; set; }

	public string CurrentShipId => ShipsInfo.CurrentSelectedShipId;

	private 十六加八TalentEffect 十六加八 => _十六加八Lazy.Value;

	public static string GetURL()
	{
		return "ui://4eq8fgd2bqhp0";
	}

	public static UI_main_GvGWorldMap3 CreateInstance()
	{
		return (UI_main_GvGWorldMap3)(object)UIPackage.CreateObject("GvGWorldMap3", "main_GvGWorldMap3");
	}

	public static UI_main_GvGWorldMap3 CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_main_GvGWorldMap3).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://4eq8fgd2bqhp0", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_007b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0085: Expected O, but got Unknown
		//IL_0091: Unknown result type (might be due to invalid IL or missing references)
		//IL_009b: Expected O, but got Unknown
		//IL_00a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b1: Expected O, but got Unknown
		//IL_021d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0227: Expected O, but got Unknown
		//IL_0233: Unknown result type (might be due to invalid IL or missing references)
		//IL_023d: Expected O, but got Unknown
		//IL_03e6: Unknown result type (might be due to invalid IL or missing references)
		//IL_03f0: Expected O, but got Unknown
		//IL_03fc: Unknown result type (might be due to invalid IL or missing references)
		//IL_0406: Expected O, but got Unknown
		//IL_0412: Unknown result type (might be due to invalid IL or missing references)
		//IL_041c: Expected O, but got Unknown
		//IL_046a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0474: Expected O, but got Unknown
		//IL_04ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_04b6: Expected O, but got Unknown
		//IL_04c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_04cc: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		IslandSelect = ((GComponent)this).GetController("IslandSelect");
		JumpEffectController = ((GComponent)this).GetController("JumpEffectController");
		PreventInput = ((GComponent)this).GetController("PreventInput");
		ProgressController = ((GComponent)this).GetController("ProgressController");
		WaitOpenEternalNight = ((GComponent)this).GetController("WaitOpenEternalNight");
		ShowBrawlEventTip = ((GComponent)this).GetController("ShowBrawlEventTip");
		background = (GLoader)((GComponent)this).GetChild("background");
		rayMask = (GGraph)((GComponent)this).GetChild("rayMask");
		BackBtn = (GButton)((GComponent)this).GetChild("BackBtn");
		Slider = (UI_com_SliderVertUp)(object)((GComponent)this).GetChild("Slider");
		AddBtn = (UI_btn_AddButton)(object)((GComponent)this).GetChild("AddBtn");
		MinusBtn = (UI_btn_MinusButton)(object)((GComponent)this).GetChild("MinusBtn");
		Records = (UI_btn_Records)(object)((GComponent)this).GetChild("Records");
		TechnologyOffTheField = (UI_btn_TechnologyOffTheField)(object)((GComponent)this).GetChild("TechnologyOffTheField");
		Talents = (UI_btn_TechnologyOnTheField)(object)((GComponent)this).GetChild("Talents");
		ExpeditionStore = (UI_btn_GvGStore)(object)((GComponent)this).GetChild("ExpeditionStore");
		MeleeStore = (UI_btn_MeleeStore)(object)((GComponent)this).GetChild("MeleeStore");
		GvGStorehouseBtn = (UI_btn_GvGStorehouse)(object)((GComponent)this).GetChild("GvGStorehouseBtn");
		Amplifier = (UI_btn_Amplifier)(object)((GComponent)this).GetChild("Amplifier");
		ExpeditionLeaderboard = (UI_btn_ExpeditionLeaderboard)(object)((GComponent)this).GetChild("ExpeditionLeaderboard");
		BattlePass = (UI_btn_BattlePass)(object)((GComponent)this).GetChild("BattlePass");
		FlagShipMission = (UI_btn_FlagShipMission)(object)((GComponent)this).GetChild("FlagShipMission");
		SweepEffect = (UI_com_SweepEffect)(object)((GComponent)this).GetChild("SweepEffect");
		Operation_Cancel = (UI_btn_Operation_Cancel)(object)((GComponent)this).GetChild("Operation_Cancel");
		n90 = (UI_dec_OpertarionShipBG)(object)((GComponent)this).GetChild("n90");
		n93 = (GImage)((GComponent)this).GetChild("n93");
		n92 = (GTextField)((GComponent)this).GetChild("n92");
		string id = "ui://4eq8fgd2bqhp0".Replace("ui://", "") + "-" + ((GObject)n92).id;
		((GObject)n92).text = LanguagesManager.GetDesc(id);
		n111 = (UI_dec_Text02_Animation)(object)((GComponent)this).GetChild("n111");
		ShipsInfo = (UI_com_ShipsInfo)(object)((GComponent)this).GetChild("ShipsInfo");
		ShipsOverview = (UI_btn_ShipOverview)(object)((GComponent)this).GetChild("ShipsOverview");
		IslandEvents = (UI_com_RandomEvents)(object)((GComponent)this).GetChild("IslandEvents");
		OperationDialog = (UI_com_OperationDialog)(object)((GComponent)this).GetChild("OperationDialog");
		SweepOperationDialog = (UI_com_SweepOperationDialog)(object)((GComponent)this).GetChild("SweepOperationDialog");
		ShipPlanOperationDialog = (UI_com_ShipPlanOperationDialog)(object)((GComponent)this).GetChild("ShipPlanOperationDialog");
		IslandFilters = (UI_com_IslandFilters)(object)((GComponent)this).GetChild("IslandFilters");
		Filter = (UI_btn_IslandsFilter)(object)((GComponent)this).GetChild("Filter");
		CurrentTreasureMap = (UI_btn_TreasureMap)(object)((GComponent)this).GetChild("CurrentTreasureMap");
		Progress = (UI_com_MainStorylineProgress)(object)((GComponent)this).GetChild("Progress");
		LandOfEternalNightStep1 = (UI_com_LandOfNightStep1)(object)((GComponent)this).GetChild("LandOfEternalNightStep1");
		LandOfEternalNightStep2 = (UI_com_LandOfNightStep2)(object)((GComponent)this).GetChild("LandOfEternalNightStep2");
		LandOfEternalNightEnd = (UI_com_LandOfNightEnd)(object)((GComponent)this).GetChild("LandOfEternalNightEnd");
		LeaderboardBtn = (UI_btn_Leaderboard)(object)((GComponent)this).GetChild("LeaderboardBtn");
		BestOfToday = (UI_btn_BestOfToday)(object)((GComponent)this).GetChild("BestOfToday");
		n120 = (GImage)((GComponent)this).GetChild("n120");
		n121 = (GImage)((GComponent)this).GetChild("n121");
		BrawlFightHoldingPercents = (GList)((GComponent)this).GetChild("BrawlFightHoldingPercents");
		BrawlEventTip = (UI_btn_BrawlEventTip)(object)((GComponent)this).GetChild("BrawlEventTip");
		buffBtn = (UI_btn_brawlfightBuff)(object)((GComponent)this).GetChild("buffBtn");
		flagShipBtn = (UI_btn_MotherShip)(object)((GComponent)this).GetChild("flagShipBtn");
		n103 = (GGroup)((GComponent)this).GetChild("n103");
		EternalNightTip = (UI_com_WaitOpenEternalNight)(object)((GComponent)this).GetChild("EternalNightTip");
		JumpEffect = (UI_com_JumpEffect)(object)((GComponent)this).GetChild("JumpEffect");
		PreventInputMask = (GGraph)((GComponent)this).GetChild("PreventInputMask");
		n112 = (GImage)((GComponent)this).GetChild("n112");
		IslandCard = (UI_com_IslandCardLoader)(object)((GComponent)this).GetChild("IslandCard");
		ShowOperationDialog = ((GComponent)this).GetTransition("ShowOperationDialog");
		ShowSelectShipBg = ((GComponent)this).GetTransition("ShowSelectShipBg");
		HideSelectShipBg = ((GComponent)this).GetTransition("HideSelectShipBg");
		DisplaySweepDialog = ((GComponent)this).GetTransition("DisplaySweepDialog");
		DisplayShipPlanDialog = ((GComponent)this).GetTransition("DisplayShipPlanDialog");
	}

	public void Init(Dictionary<string, object> parameters)
	{
		FGUIManager.SetUiPanelSizeAndXy((GObject)(object)this, scaleAdaption: true);
		Slider.Init(0f, 1f, 0f);
		((GObject)CurrentTreasureMap).visible = false;
		((GObject)JumpEffect).displayObject.gameObject.AddComponent<SortingGroup>().sortingLayerName = "UI";
		IsOpenedByRecovery = parameters?.ContainsKey("IsOpenedByRecovery") ?? false;
		Singleton<GvGMode3RoomManager>.Instance.TryConnectToRoom(InitWorldMap);
		Singleton<GvGMode3RoomManager>.Instance.StopwatchLogInterval("开了GvGWorldMap3");
	}

	private void InitWorldMap()
	{
		InitCoroutine = ((MonoBehaviour)FGUIManager.Instance).StartCoroutine(Coroutine());
		IEnumerator Coroutine()
		{
			Singleton<GvGMode3RoomManager>.Instance.StopwatchLogInterval("关闭所有无关界面，开Chat - 开始");
			if (!IsOpenedByRecovery)
			{
				GameController.Contexts.Service<IUiService>().PushBackupAndCloseAllUIs(new List<string>
				{
					Name,
					UI_main_GvG3Chat.Name,
					UI_main_GvGLoadingPanel.Name,
					UI_main_GvGLoading2Panel.Name
				});
				yield return null;
				GameController.Contexts.Service<IUiService>().OpenPanel(UI_main_GvG3Chat.Name, null);
				yield return null;
			}
			Singleton<GvGMode3RoomManager>.Instance.StopwatchLogInterval("关闭所有无关界面，开Chat - 结束");
			string izConfigId = Singleton<GvGMode3RoomManager>.Instance.ObserverRecord.IZConfigId;
			yield return WorldMapConfigHelper.InitCoroutine(izConfigId);
			Singleton<WorldStateManager>.Instance.AfterConfigInit();
			Singleton<GvGMode3RoomManager>.Instance.StopwatchLogInterval("WorldMapConfigHelper 加载结束");
			yield return GvG3FlagShipMissionsConfigHelper.InitCoroutine();
			Singleton<GvGMode3RoomManager>.Instance.StopwatchLogInterval("GvG3FlagShipMissionsConfigHelper 加载结束");
			yield return GvGWorldMapController.CreateInstance(izConfigId);
			SharedMessenger.Broadcast("ON_GVG3_INSTANCE_START");
			ShipsInfo.Init(this);
			UpdateShipsCount();
			RegisterEventOnWorldInit();
			Singleton<GvG3FlagShipMissionsManager>.Instance.Init();
			GvGWorldMapController.Instance.StartUpdate();
			Singleton<GvGMode3RoomManager>.Instance.StopwatchLogInterval("WorldMapController - StartUpdate");
			bool isMissionLoaded = false;
			SharedMessenger.AddListener("ON_SOCKET_RECONNECT", OnReconnect);
			Singleton<GvG3FlagShipMissionsManager>.Instance.GetMissions(0, currentProgress: true, OnGetMissionComplete);
			while (!isMissionLoaded)
			{
				yield return null;
			}
			if (!((GObject)this).isDisposed)
			{
				UpdateProgressUi();
				Singleton<GvGMode3RoomManager>.Instance.StopwatchLogInterval("主界面：渲染了副本进度状态");
				CurrentTreasureMap.Init();
				IslandEvents.Init();
				BattlePass.Init();
				OperationDialog.Init(this);
				OperationDialog.RegisterEvent();
				SweepOperationDialog.Init(PlaySweepEffect);
				ShipPlanOperationDialog.Init(ExitOperationPage);
				InitBrawlFightState(izConfigId);
				yield return null;
				if (!((GObject)this).isDisposed)
				{
					UpdateStoreNotice();
					UpdateBattlePassNotice();
					UpdateRecordsRedDot(Singleton<WorldStateManager>.Instance.Data.WaitToClaimSystemMessageIdsCount > 0);
					UpdateAmplifierRedDot(Singleton<GvGAmplifierManager>.Instance.HasNewAmpFormulas);
					yield return (object)new WaitForSeconds(1f);
					if (!((GObject)this).isDisposed)
					{
						BestOfToday.Init();
						yield return (object)new WaitForSeconds(1f);
						if (!((GObject)this).isDisposed)
						{
							Singleton<GvGTalentsManager>.Instance.GetActiveTalents(UpdateTalentsRedDot);
							yield return (object)new WaitForSeconds(1f);
							if (!((GObject)this).isDisposed && GvGWorldMapController.IsInstanceCreated)
							{
								GvGWorldMapController.Instance.CrisisDetectManager.Init();
								yield return null;
								Singleton<GvGIslandFilterManager>.Instance.InitIslandFilterIcons();
								yield return (object)new WaitForSeconds(1f);
								IslandFilters.RegisterEvents(new EventCallback0(DisplayComponentsOnFilterClose));
								Filter.Render();
							}
						}
					}
				}
			}
			void OnGetMissionComplete()
			{
				isMissionLoaded = true;
				SharedMessenger.RemoveListener("ON_SOCKET_RECONNECT", OnReconnect);
			}
			void OnReconnect()
			{
				Singleton<GvG3FlagShipMissionsManager>.Instance.GetMissions(0, currentProgress: true, OnGetMissionComplete);
			}
		}
	}

	private void UpdateProgressUi()
	{
		Singleton<GvG3FlagShipMissionsManager>.Instance.UpdateModelCurProgress();
		Singleton<GvG3FlagShipMissionsManager>.Instance.TryPlayEternalNightUiTransitions();
		Singleton<GvG3FlagShipMissionsManager>.Instance.TryShowProgressSettlementPanel();
		Progress.Init();
		LandOfEternalNightStep1.Init();
		LandOfEternalNightEnd.Init();
		flagShipBtn.Camp.selectedIndex = Singleton<WorldStateManager>.Instance.Data.MyCampId;
		FlagShipMissionRenderer();
	}

	private void UpdateBattlePassNotice()
	{
		((GObject)BattlePass.RedDot).visible = Singleton<GvG3BattlePassManager>.Instance.HasClaimable;
	}

	private void UpdateStoreNotice()
	{
		((GObject)ExpeditionStore.RedDot).visible = Singleton<GvG3StoreManager>.Instance.HasSoulKeyStoreNotice_Free || Singleton<GvG3StoreManager>.Instance.HasSoulKeyStoreNotice_Paid || Singleton<GvG3StoreManager>.Instance.HasGvGStoreNotice;
		((GObject)ExpeditionStore.NewHiddenStoreTip).visible = Singleton<GvG3StoreManager>.Instance.HasStellarKeyStoreNotice;
	}

	public void OnShow()
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		//IL_001b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		GvGStorehouseBtnWorldPos = ((GObject)GvGStorehouseBtn).LocalToRoot(Vector2.one / 2f, GRoot.inst);
	}

	private void OnClickBackBtn()
	{
		OpenTipPanel("GvGWorldMap3ExitTips".ToLanguage(), ConfirmAct, (AlignType)1);
		void ConfirmAct()
		{
			if (Singleton<GvGMode3RoomManager>.Instance.OnQuickStartReturnMainCity != null)
			{
				EndToMainCity();
			}
			else
			{
				End();
			}
		}
	}

	private void EndByForceStop()
	{
		if (InitCoroutine != null)
		{
			((MonoBehaviour)FGUIManager.Instance).StopCoroutine(InitCoroutine);
		}
		GameController.Contexts.Service<IUiService>().PushBackupAndCloseAllUIs(new List<string>
		{
			UI_main_GvGLoadingPanel.Name,
			UI_main_GvGLoading2Panel.Name,
			UI_UniversalConfirmPopup.Name
		}, toBackupStack: false, closeHidden: true);
		((MonoBehaviour)FGUIManager.Instance).StartCoroutine((Singleton<GvGMode3RoomManager>.Instance.OnQuickStartReturnMainCity != null) ? DelayReturnMainCity() : DelayRecover_ForceStop());
	}

	private void End()
	{
		if (InitCoroutine != null)
		{
			((MonoBehaviour)FGUIManager.Instance).StopCoroutine(InitCoroutine);
		}
		UI_main_GvGLoading2Panel.Open(UI_main_GvGLoading2Panel.eLoadingType.Exit, delegate
		{
			GameController.Contexts.Service<IUiService>().PushBackupAndCloseAllUIs(new List<string>
			{
				UI_main_GvGLoadingPanel.Name,
				UI_main_GvGLoading2Panel.Name,
				UI_UniversalConfirmPopup.Name
			}, toBackupStack: false, closeHidden: true);
			((MonoBehaviour)FGUIManager.Instance).StartCoroutine(DelayRecover());
		});
	}

	private void EndToMainCity()
	{
		if (InitCoroutine != null)
		{
			((MonoBehaviour)FGUIManager.Instance).StopCoroutine(InitCoroutine);
		}
		UI_main_GvGLoading2Panel.Open(UI_main_GvGLoading2Panel.eLoadingType.Exit, delegate
		{
			GameController.Contexts.Service<IUiService>().PushBackupAndCloseAllUIs(new List<string>
			{
				UI_main_GvGLoadingPanel.Name,
				UI_main_GvGLoading2Panel.Name,
				UI_UniversalConfirmPopup.Name
			}, toBackupStack: false, closeHidden: true);
			((MonoBehaviour)FGUIManager.Instance).StartCoroutine(DelayReturnMainCity());
		});
	}

	private void HideBottomRightCornerButtons(bool show)
	{
		int num = (show ? 1 : 0);
		((GObject)Records).alpha = num;
		((GObject)TechnologyOffTheField).alpha = num;
		((GObject)Talents).alpha = num;
		((GObject)ExpeditionStore).alpha = num;
		((GObject)MeleeStore).alpha = num;
		((GObject)GvGStorehouseBtn).alpha = num;
		((GObject)Amplifier).alpha = num;
	}

	public void OpenTipPanel(string content, Action onConfirm, AlignType alignType, Action OnCancel = null)
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
					{ "Confirm", onConfirm },
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

	private void RegisterEventOnWorldInit()
	{
		GvGMode3RoomManager instance = Singleton<GvGMode3RoomManager>.Instance;
		instance.OnRoomClose = (Action)Delegate.Combine(instance.OnRoomClose, new Action(EndByForceStop));
		GvG3FlagShipMissionsManager instance2 = Singleton<GvG3FlagShipMissionsManager>.Instance;
		instance2.OnCampProgressChange = (Action)Delegate.Combine(instance2.OnCampProgressChange, new Action(FlagShipMissionRenderer));
		GvG3FlagShipMissionsManager instance3 = Singleton<GvG3FlagShipMissionsManager>.Instance;
		instance3.OnCampProgressChange = (Action)Delegate.Combine(instance3.OnCampProgressChange, new Action(ShowEternalNightTip));
		GvG3FlagShipMissionsManager instance4 = Singleton<GvG3FlagShipMissionsManager>.Instance;
		instance4.OnCampProgressChange = (Action)Delegate.Combine(instance4.OnCampProgressChange, new Action(ShowLastProgressSettlementPanel));
		Singleton<GvG3FlagShipMissionsManager>.Instance.RegisterSocketEvents();
		SharedMessenger.AddListener("ON_GVG3_ETERNALNIGHT_TRANSITION_PLAYED", FlagShipMissionRenderer);
		GvGMapInputManager inputManager = GvGWorldMapController.Instance.InputManager;
		inputManager.OnPinchStart = (Action)Delegate.Combine(inputManager.OnPinchStart, new Action(OnPinchBegin));
		GvGMapInputManager inputManager2 = GvGWorldMapController.Instance.InputManager;
		inputManager2.OnPinch = (Action<float>)Delegate.Combine(inputManager2.OnPinch, new Action<float>(OnPinch));
		GvGMapInputManager inputManager3 = GvGWorldMapController.Instance.InputManager;
		inputManager3.OnPinchEnd = (Action)Delegate.Combine(inputManager3.OnPinchEnd, new Action(OnPinchEnd));
		CameraBindingManager cameraBindingManager = GvGWorldMapController.Instance.CameraBindingManager;
		cameraBindingManager.OnChangeSize = (Action<float>)Delegate.Combine(cameraBindingManager.OnChangeSize, new Action<float>(OnCameraSizeChange));
		GvGWorldMapController instance5 = GvGWorldMapController.Instance;
		instance5.OnClickAny = (Action<List<TouchedObject>>)Delegate.Combine(instance5.OnClickAny, new Action<List<TouchedObject>>(OnClickAny));
		GvGWorldMapController instance6 = GvGWorldMapController.Instance;
		instance6.OnSelectIsland = (Action<int>)Delegate.Combine(instance6.OnSelectIsland, new Action<int>(OnSelectIsland));
		GvGWorldMapController instance7 = GvGWorldMapController.Instance;
		instance7.OnSelectFlagship = (Action<int>)Delegate.Combine(instance7.OnSelectFlagship, new Action<int>(OnSelectCampFlagship));
		GvGStoreHouseManager instance8 = Singleton<GvGStoreHouseManager>.Instance;
		instance8.OnChange = (Action)Delegate.Combine(instance8.OnChange, new Action(UpdateTalentsRedDot));
		Singleton<GvG3StoreManager>.Instance.RegisterUiEventListeners();
		GvG3StoreManager instance9 = Singleton<GvG3StoreManager>.Instance;
		instance9.OnChangeSoulKeyStoreNotice = (Action)Delegate.Combine(instance9.OnChangeSoulKeyStoreNotice, new Action(UpdateStoreNotice));
		GvG3StoreManager instance10 = Singleton<GvG3StoreManager>.Instance;
		instance10.OnChangeGvGStoreNotice = (Action)Delegate.Combine(instance10.OnChangeGvGStoreNotice, new Action(UpdateStoreNotice));
		GvG3StoreManager instance11 = Singleton<GvG3StoreManager>.Instance;
		instance11.OnChangeStellarKeyStoreNotice = (Action)Delegate.Combine(instance11.OnChangeStellarKeyStoreNotice, new Action(UpdateStoreNotice));
		GvG3BattlePassManager instance12 = Singleton<GvG3BattlePassManager>.Instance;
		instance12.OnChangeHasClaimable = (Action)Delegate.Combine(instance12.OnChangeHasClaimable, new Action(UpdateBattlePassNotice));
		WorldStateManager instance13 = Singleton<WorldStateManager>.Instance;
		instance13.OnBattleResultRedDotChange = (Action<bool>)Delegate.Combine(instance13.OnBattleResultRedDotChange, new Action<bool>(UpdateRecordsRedDot));
		GvGAmplifierManager instance14 = Singleton<GvGAmplifierManager>.Instance;
		instance14.OnUpdateTotalAmpFormulaRedDot = (Action<bool>)Delegate.Combine(instance14.OnUpdateTotalAmpFormulaRedDot, new Action<bool>(UpdateAmplifierRedDot));
		GvG3FlagShipMissionsManager instance15 = Singleton<GvG3FlagShipMissionsManager>.Instance;
		instance15.UpdateMainUiMissionRedDot = (Action<bool>)Delegate.Combine(instance15.UpdateMainUiMissionRedDot, new Action<bool>(UpdateFlagShipMissionRedDot));
		Singleton<GvGStoreHouseManager>.Instance.AddOnRedDotChange(OnUpdateStorehouseRedDot);
		SweepOperationDialog.RegisterEvent();
		ShipPlanOperationDialog.RegisterEvent();
		UI_com_IslandCardLoader.OnClickSweep = (Action)Delegate.Combine(UI_com_IslandCardLoader.OnClickSweep, new Action(OnClickSweepBtn));
		UI_com_IslandCardLoader.OnClickRepeatedAttack = (Action)Delegate.Combine(UI_com_IslandCardLoader.OnClickRepeatedAttack, new Action(OnClickRepeatedAttack));
		UI_com_IslandCardLoader islandCard = IslandCard;
		islandCard.OnIslandAction = (Action<eIslandAction>)Delegate.Combine(islandCard.OnIslandAction, new Action<eIslandAction>(OnChangeOperationMode));
		IslandCard.RegisterEvent();
		GvGMode3RoomManager instance16 = Singleton<GvGMode3RoomManager>.Instance;
		instance16.OnDestroyShip = (Action)Delegate.Combine(instance16.OnDestroyShip, new Action(ShipsInfo.OnShipsCountChange));
		SharedMessenger.AddListener("ON_SHIP_COUNT_LIMIT_CHANGE", UpdateShipsCount);
	}

	private void UnregisterEventOnWorldRelease()
	{
		GvGMode3RoomManager instance = Singleton<GvGMode3RoomManager>.Instance;
		instance.OnRoomClose = (Action)Delegate.Remove(instance.OnRoomClose, new Action(EndByForceStop));
		GvG3FlagShipMissionsManager instance2 = Singleton<GvG3FlagShipMissionsManager>.Instance;
		instance2.OnCampProgressChange = (Action)Delegate.Remove(instance2.OnCampProgressChange, new Action(FlagShipMissionRenderer));
		GvG3FlagShipMissionsManager instance3 = Singleton<GvG3FlagShipMissionsManager>.Instance;
		instance3.OnCampProgressChange = (Action)Delegate.Remove(instance3.OnCampProgressChange, new Action(ShowEternalNightTip));
		GvG3FlagShipMissionsManager instance4 = Singleton<GvG3FlagShipMissionsManager>.Instance;
		instance4.OnCampProgressChange = (Action)Delegate.Remove(instance4.OnCampProgressChange, new Action(ShowLastProgressSettlementPanel));
		Singleton<GvG3FlagShipMissionsManager>.Instance.UnregisterSocketEvents();
		SharedMessenger.RemoveListener("ON_GVG3_ETERNALNIGHT_TRANSITION_PLAYED", FlagShipMissionRenderer);
		if ((Object)(object)GvGWorldMapController.Instance != (Object)null)
		{
			GvGMapInputManager inputManager = GvGWorldMapController.Instance.InputManager;
			inputManager.OnPinchStart = (Action)Delegate.Remove(inputManager.OnPinchStart, new Action(OnPinchBegin));
			GvGMapInputManager inputManager2 = GvGWorldMapController.Instance.InputManager;
			inputManager2.OnPinch = (Action<float>)Delegate.Remove(inputManager2.OnPinch, new Action<float>(OnPinch));
			GvGMapInputManager inputManager3 = GvGWorldMapController.Instance.InputManager;
			inputManager3.OnPinchEnd = (Action)Delegate.Remove(inputManager3.OnPinchEnd, new Action(OnPinchEnd));
			CameraBindingManager cameraBindingManager = GvGWorldMapController.Instance.CameraBindingManager;
			cameraBindingManager.OnChangeSize = (Action<float>)Delegate.Remove(cameraBindingManager.OnChangeSize, new Action<float>(OnCameraSizeChange));
			GvGWorldMapController instance5 = GvGWorldMapController.Instance;
			instance5.OnClickAny = (Action<List<TouchedObject>>)Delegate.Remove(instance5.OnClickAny, new Action<List<TouchedObject>>(OnClickAny));
			GvGWorldMapController instance6 = GvGWorldMapController.Instance;
			instance6.OnSelectIsland = (Action<int>)Delegate.Remove(instance6.OnSelectIsland, new Action<int>(OnSelectIsland));
			GvGWorldMapController instance7 = GvGWorldMapController.Instance;
			instance7.OnSelectFlagship = (Action<int>)Delegate.Remove(instance7.OnSelectFlagship, new Action<int>(OnSelectCampFlagship));
		}
		GvGStoreHouseManager instance8 = Singleton<GvGStoreHouseManager>.Instance;
		instance8.OnChange = (Action)Delegate.Remove(instance8.OnChange, new Action(UpdateTalentsRedDot));
		Singleton<GvG3StoreManager>.Instance.UnregisterUiEventListeners();
		GvG3StoreManager instance9 = Singleton<GvG3StoreManager>.Instance;
		instance9.OnChangeSoulKeyStoreNotice = (Action)Delegate.Remove(instance9.OnChangeSoulKeyStoreNotice, new Action(UpdateStoreNotice));
		GvG3StoreManager instance10 = Singleton<GvG3StoreManager>.Instance;
		instance10.OnChangeGvGStoreNotice = (Action)Delegate.Remove(instance10.OnChangeGvGStoreNotice, new Action(UpdateStoreNotice));
		GvG3StoreManager instance11 = Singleton<GvG3StoreManager>.Instance;
		instance11.OnChangeStellarKeyStoreNotice = (Action)Delegate.Remove(instance11.OnChangeStellarKeyStoreNotice, new Action(UpdateStoreNotice));
		GvG3BattlePassManager instance12 = Singleton<GvG3BattlePassManager>.Instance;
		instance12.OnChangeHasClaimable = (Action)Delegate.Remove(instance12.OnChangeHasClaimable, new Action(UpdateBattlePassNotice));
		WorldStateManager instance13 = Singleton<WorldStateManager>.Instance;
		instance13.OnBattleResultRedDotChange = (Action<bool>)Delegate.Remove(instance13.OnBattleResultRedDotChange, new Action<bool>(UpdateRecordsRedDot));
		GvGAmplifierManager instance14 = Singleton<GvGAmplifierManager>.Instance;
		instance14.OnUpdateTotalAmpFormulaRedDot = (Action<bool>)Delegate.Remove(instance14.OnUpdateTotalAmpFormulaRedDot, new Action<bool>(UpdateAmplifierRedDot));
		GvG3FlagShipMissionsManager instance15 = Singleton<GvG3FlagShipMissionsManager>.Instance;
		instance15.UpdateMainUiMissionRedDot = (Action<bool>)Delegate.Remove(instance15.UpdateMainUiMissionRedDot, new Action<bool>(UpdateFlagShipMissionRedDot));
		Singleton<GvGStoreHouseManager>.Instance.RemoveOnRedDotChange(OnUpdateStorehouseRedDot);
		SweepOperationDialog.UnregisterEvent();
		ShipPlanOperationDialog.UnregisterEvent();
		UI_com_IslandCardLoader.OnClickSweep = (Action)Delegate.Remove(UI_com_IslandCardLoader.OnClickSweep, new Action(OnClickSweepBtn));
		UI_com_IslandCardLoader.OnClickRepeatedAttack = (Action)Delegate.Remove(UI_com_IslandCardLoader.OnClickRepeatedAttack, new Action(OnClickRepeatedAttack));
		if (IslandCard != null)
		{
			UI_com_IslandCardLoader islandCard = IslandCard;
			islandCard.OnIslandAction = (Action<eIslandAction>)Delegate.Remove(islandCard.OnIslandAction, new Action<eIslandAction>(OnChangeOperationMode));
			IslandCard.OnDestroy();
			CloseIslandMenu();
		}
		GvGMode3RoomManager instance16 = Singleton<GvGMode3RoomManager>.Instance;
		instance16.OnDestroyShip = (Action)Delegate.Remove(instance16.OnDestroyShip, new Action(ShipsInfo.OnShipsCountChange));
		SharedMessenger.RemoveListener("ON_SHIP_COUNT_LIMIT_CHANGE", UpdateShipsCount);
		GameManagers.Instance.Messenger.RemoveListener<C2S_BrawlEvent_GetInfo.Response>("BRAWL_EVENT_SIGN_UP_CHANGE", RefreshBrawlEventTip);
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
		//IL_013a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0144: Expected O, but got Unknown
		//IL_0157: Unknown result type (might be due to invalid IL or missing references)
		//IL_0161: Expected O, but got Unknown
		//IL_0174: Unknown result type (might be due to invalid IL or missing references)
		//IL_017e: Expected O, but got Unknown
		//IL_0191: Unknown result type (might be due to invalid IL or missing references)
		//IL_019b: Expected O, but got Unknown
		//IL_01ae: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b8: Expected O, but got Unknown
		//IL_01cb: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d5: Expected O, but got Unknown
		//IL_0252: Unknown result type (might be due to invalid IL or missing references)
		//IL_025c: Expected O, but got Unknown
		//IL_02e6: Unknown result type (might be due to invalid IL or missing references)
		//IL_02f0: Expected O, but got Unknown
		//IL_0303: Unknown result type (might be due to invalid IL or missing references)
		//IL_030d: Expected O, but got Unknown
		//IL_031b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0325: Expected O, but got Unknown
		//IL_0338: Unknown result type (might be due to invalid IL or missing references)
		//IL_0342: Expected O, but got Unknown
		//IL_0355: Unknown result type (might be due to invalid IL or missing references)
		//IL_035f: Expected O, but got Unknown
		//IL_0372: Unknown result type (might be due to invalid IL or missing references)
		//IL_037c: Expected O, but got Unknown
		((GObject)rayMask).onTouchBegin.Add(new EventCallback1(OnDragBegin));
		((GObject)rayMask).onTouchMove.Add(new EventCallback1(OnDrag));
		((GObject)rayMask).onTouchEnd.Add(new EventCallback1(OnDragEnd));
		((GObject)BackBtn).onClick.Add(new EventCallback0(OnClickBackBtn));
		((GObject)ExpeditionStore).onClick.Add(new EventCallback0(EnterGvGStore));
		((GObject)BattlePass).onClick.Add(new EventCallback0(OnClickBattlePass));
		((GObject)Records).onClick.Add(new EventCallback0(OnOpenBattleRecords));
		((GObject)Operation_Cancel).onClick.Add(new EventCallback0(ExitOperationPage));
		((GObject)Amplifier).onClick.Add(new EventCallback1(OnOpenAmplifierEntry));
		((GObject)Talents).onClick.Add(new EventCallback1(OnOpenTalentsEntry));
		IslandSelect.onChanged.Set(new EventCallback0(ShipsInfo.UpdateType));
		((GObject)AddBtn).onClick.Add(new EventCallback0(OnMinusCamSize));
		((GObject)MinusBtn).onClick.Add(new EventCallback0(OnAddCamSize));
		((GObject)GvGStorehouseBtn).onClick.Set(new EventCallback0(OnOpenStoreHouse));
		((GObject)LeaderboardBtn).onClick.Set(new EventCallback0(OnOpenEternalNightLeaderboard));
		((GObject)ExpeditionLeaderboard).onClick.Set(new EventCallback0(OnOpenExpeditionLeaderboard));
		Input.multiTouchEnabled = true;
		UI_com_SliderVertUp slider = Slider;
		slider.OnChange = (Action)Delegate.Combine(slider.OnChange, new Action(OnSliderValueChange));
		Progress.RegisterUiEvent();
		LandOfEternalNightStep1.RegisterUiEvent();
		LandOfEternalNightStep2.RegisterUiEvent();
		LandOfEternalNightEnd.RegisterUiEvent();
		BestOfToday.RegisterUiEvent();
		((GObject)FlagShipMission).onClick.Set(new EventCallback0(OnOpenFlagShipMissions));
		CurrentTreasureMap.RegisterUiEvent();
		IslandEvents.RegisterUiEvent();
		UI_com_RandomEvents islandEvents = IslandEvents;
		islandEvents.CloseIslandDetailUi = (Action)Delegate.Combine(islandEvents.CloseIslandDetailUi, new Action(CloseIslandMenu));
		UI_com_OperationDialog operationDialog = OperationDialog;
		operationDialog.OnConfirmJumping = (Action<OuterTechHelper.Jump努力加餐饭Cost>)Delegate.Combine(operationDialog.OnConfirmJumping, new Action<OuterTechHelper.Jump努力加餐饭Cost>(OnConfirmJump));
		BattlePass.RegisterUiEvent();
		((GObject)EternalNightTip.ContinueProgress).onClick.Set(new EventCallback0(PlayEternalNightTransition));
		((GObject)ShipsOverview).onClick.Set(new EventCallback1(OnOpenShipOverviewPanel));
		Filter.RegisterEvents(new EventCallback0(OnFilterClick));
		((GObject)buffBtn).onClick.Set(new EventCallback0(OnClickBrawlFightBuffs));
		((GObject)flagShipBtn).onClick.Set(new EventCallback1(OnClickMyFlagShip));
		((GObject)BrawlEventTip).onClick.Set(new EventCallback0(OnClickJumpToFligShip));
		Singleton<GvG3EventMissionManager>.Instance.Init();
		SharedMessenger.AddListener<int>("ON_GVG3_ISLAND_ACTION_SUCCESS", OnIslandActionSuccess);
		SharedMessenger.AddListener<bool>("ON_GVG3_CHATPAGE_CHANGE", HideBottomRightCornerButtons);
		SharedMessenger.AddListener<bool>("GVG3_PREVENT_INPUT_CHANGE", ChangePreventInput);
		SharedMessenger.AddListener("GVG3_AUTO_CLOSE_ISLAND_CARD", CloseIslandMenu);
		SharedMessenger.AddListener<int>("GVG3_AUTO_OPEN_ISLAND_CARD", OnSelectIsland);
	}

	public void UnregisterUiEventListeners()
	{
		((GObject)rayMask).onTouchBegin.Clear();
		((GObject)rayMask).onTouchMove.Clear();
		((GObject)rayMask).onTouchEnd.Clear();
		((GObject)BackBtn).onClick.Clear();
		((GObject)ExpeditionStore).onClick.Clear();
		((GObject)BattlePass).onClick.Clear();
		((GObject)Records).onClick.Clear();
		((GObject)Operation_Cancel).onClick.Clear();
		((GObject)Amplifier).onClick.Clear();
		((GObject)Talents).onClick.Clear();
		IslandSelect.onChanged.Clear();
		((GObject)AddBtn).onClick.Clear();
		((GObject)MinusBtn).onClick.Clear();
		((GObject)GvGStorehouseBtn).onClick.Clear();
		((GObject)LeaderboardBtn).onClick.Clear();
		((GObject)ExpeditionLeaderboard).onClick.Clear();
		UI_com_SliderVertUp slider = Slider;
		slider.OnChange = (Action)Delegate.Remove(slider.OnChange, new Action(OnSliderValueChange));
		Progress.UnregisterUiEvent();
		LandOfEternalNightStep2.UnregisterUiEvent();
		LandOfEternalNightStep1.UnregisterUiEvent();
		LandOfEternalNightEnd.UnregisterUiEvent();
		BestOfToday.UnregisterUiEvent();
		((GObject)FlagShipMission).onClick.Clear();
		CurrentTreasureMap.UnregisterUiEvent();
		IslandEvents.UnregisterUiEvent();
		UI_com_RandomEvents islandEvents = IslandEvents;
		islandEvents.CloseIslandDetailUi = (Action)Delegate.Remove(islandEvents.CloseIslandDetailUi, new Action(CloseIslandMenu));
		UI_com_OperationDialog operationDialog = OperationDialog;
		operationDialog.OnConfirmJumping = (Action<OuterTechHelper.Jump努力加餐饭Cost>)Delegate.Remove(operationDialog.OnConfirmJumping, new Action<OuterTechHelper.Jump努力加餐饭Cost>(OnConfirmJump));
		BattlePass.UnregisterUiEvent();
		((GObject)EternalNightTip.ContinueProgress).onClick.Clear();
		((GObject)ShipsOverview).onClick.Clear();
		Filter.UnregisterEvents();
		IslandFilters.UnregisterEvents();
		((GObject)buffBtn).onClick.Clear();
		((GObject)BrawlEventTip).onClick.Clear();
		Singleton<GvG3EventMissionManager>.Instance.Destroy();
		Singleton<GvGTalentsManager>.Instance.Destroy();
		SharedMessenger.RemoveListener<int>("ON_GVG3_ISLAND_ACTION_SUCCESS", OnIslandActionSuccess);
		SharedMessenger.RemoveListener<bool>("ON_GVG3_CHATPAGE_CHANGE", HideBottomRightCornerButtons);
		SharedMessenger.RemoveListener<bool>("GVG3_PREVENT_INPUT_CHANGE", ChangePreventInput);
		SharedMessenger.RemoveListener("GVG3_AUTO_CLOSE_ISLAND_CARD", CloseIslandMenu);
		SharedMessenger.RemoveListener<int>("GVG3_AUTO_OPEN_ISLAND_CARD", OnSelectIsland);
	}

	private void OnConfirmJump(OuterTechHelper.Jump努力加餐饭Cost cost)
	{
		int entityId = ShipsInfo.Data.GetDetailModel(CurrentShipId).EntityId;
		ShipsInfo.LockShip(entityId);
		ShipAnimCacheManagerInit();
		JumpToIsland(entityId, CurrentIslandId, delegate
		{
			if (IslandActionType == eIslandAction.Collect || IslandActionType == eIslandAction.SuppressRebellion)
			{
				OperationDialog.ShowFlightData();
			}
			else
			{
				ExitOperationPage(updateIslandCard: true);
			}
		}, cost);
		void ShipAnimCacheManagerInit()
		{
			//IL_0028: Unknown result type (might be due to invalid IL or missing references)
			//IL_0032: Expected O, but got Unknown
			//IL_0059: Unknown result type (might be due to invalid IL or missing references)
			//IL_0063: Expected O, but got Unknown
			if (ShipAnimCacheManager == null)
			{
				ShipAnimCacheManager = new ShipAnimCacheManager();
			}
			if (SpineGoWrapper == null)
			{
				SpineGoWrapper = new GoWrapper();
				JumpEffect.SpineLoader.SetNativeObject((DisplayObject)(object)SpineGoWrapper);
			}
			if (FxGoWrapper == null)
			{
				FxGoWrapper = new GoWrapper();
				JumpEffect.FxLoader.SetNativeObject((DisplayObject)(object)FxGoWrapper);
			}
		}
	}

	private void OnUpdateStorehouseRedDot()
	{
		((GObject)GvGStorehouseBtn.note).visible = Singleton<GvGStoreHouseManager>.Instance.RedDot.NewTrophy;
	}

	private void OnOpenStoreHouse()
	{
		GameController.Contexts.Service<IUiService>().OpenPanel(UI_main_GvGStoreHousePanel.Name, null);
	}

	private void OnOpenEternalNightLeaderboard()
	{
		GameController.Contexts.Service<IUiService>().OpenPanel(UI_main_GvG3LeaderboardPanel.Name, new Dictionary<string, object> { 
		{
			"UIType",
			UI_main_GvG3LeaderboardPanel.UIType.EternalNight
		} });
	}

	private void OnOpenExpeditionLeaderboard()
	{
		GameController.Contexts.Service<IUiService>().OpenPanel(UI_main_GvG3LeaderboardPanel.Name, new Dictionary<string, object> { 
		{
			"UIType",
			UI_main_GvG3LeaderboardPanel.UIType.Expedition
		} });
	}

	private void OnClickAny(List<TouchedObject> touchedObjects)
	{
		if (touchedObjects.Count > 0 && touchedObjects[0].Type != eObjectType.btn_shipReturn)
		{
			ShipsInfo.CancelSelectShip();
		}
		if (IslandSelect.selectedIndex == 1 && (touchedObjects.Count <= 0 || touchedObjects[0].Type != eObjectType.Island || !(((Object)touchedObjects[0].Target).name == CurrentIslandId.ToString())))
		{
			CloseIslandMenu();
		}
	}

	private void OnSelectIsland(int islanId)
	{
		if (((GObject)this).visible && IslandSelect.selectedIndex != 2 && IslandSelect.selectedIndex != 3 && IslandSelect.selectedIndex != 4)
		{
			ShowIslandMenu(islanId);
		}
	}

	private void OnSelectCampFlagship(int campId)
	{
		if (IslandSelect.selectedIndex != 2 && IslandSelect.selectedIndex != 3 && IslandSelect.selectedIndex != 4 && campId == Singleton<GvGMode3RoomManager>.Instance.ObserverRecord.ObCampId)
		{
			ShowIslandMenu(Singleton<WorldStateManager>.Instance.Data.OurFlagShipStayIslandId);
		}
	}

	private void OnSliderValueChange()
	{
		if (GvGWorldMapController.IsInstanceCreated)
		{
			GvGWorldMapController.Instance.CameraBindingManager.CamSize = Mathf.Exp(5f * (Slider.Value - 1f)) * 24f + 6f;
		}
	}

	private void OnAddCamSize()
	{
		Slider.Value += 0.1f;
	}

	private void OnMinusCamSize()
	{
		Slider.Value -= 0.1f;
	}

	private void OnCameraSizeChange(float size)
	{
		float num = Mathf.Log((size - 6f) / 24f) / 5f + 1f;
		if (num < 0f)
		{
			num = 0f;
		}
		if (num > 1f)
		{
			num = 1f;
		}
		Slider.Value = num;
		Slider.SwallowEvent();
	}

	private void OnOpenAmplifierEntry(EventContext context)
	{
		GameController.Contexts.Service<IUiService>().OpenPanel(UI_GvGAmplifierEntriesPanel.Name, null);
	}

	private void OnOpenTalentsEntry(EventContext context)
	{
		GameController.Contexts.Service<IUiService>().OpenPanel(UI_main_GvGTalentPanel.Name, null);
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

	public void OnClick(EventContext context)
	{
		ShipsInfo.CancelSelectShip();
	}

	private void OnOpenFlagShipMissions()
	{
		GameController.Contexts.Service<IUiService>().OpenPanel(UI_main_FlagShipMissions.Name, null);
	}

	private void OnPinchBegin()
	{
		_currentSliderValue = Slider.Percent;
	}

	private void OnPinch(float pinchDelta)
	{
		Slider.Percent = _currentSliderValue + (pinchDelta - 1f);
	}

	private void OnPinchEnd()
	{
	}

	public void OnNotUIInput()
	{
		GvGWorldMapController.Instance.InputManager.UpdateInput();
	}

	public void ShowIslandMenu(int islandId)
	{
		if (CurrentIslandId == islandId)
		{
			return;
		}
		CloseIslandMenu();
		CurrentIslandId = islandId;
		Singleton<WorldStateManager>.Instance.GetIslandDetail(CurrentIslandId, delegate(IslandStateModel islandState)
		{
			if (CurrentIslandId == islandState.IslandId && !((GObject)this).isDisposed)
			{
				IslandController islandController = GvGWorldMapController.Instance.LoaderManager.GetIslandController(CurrentIslandId);
				islandController.OnSelect();
				IslandCard.RenderIslandCard(islandState);
				islandState.OnDetailChange = (Action<IslandStateModel>)Delegate.Combine(islandState.OnDetailChange, new Action<IslandStateModel>(IslandCard.Update));
				IslandSelect.selectedIndex = 1;
				IsIslandStateRegistered = true;
				islandState.OnChangeEvent = (Action<IslandStateModel>)Delegate.Combine(islandState.OnChangeEvent, new Action<IslandStateModel>(Singleton<GvG3EventMissionManager>.Instance.SyncIslandEvents));
				Singleton<GvG3EventMissionManager>.Instance.CurrentIslandId = CurrentIslandId;
				Singleton<GvG3EventMissionManager>.Instance.UpdateIslandEvents?.Invoke(islandState.IslandEvents);
				islandState.OnPlayerCommandChange = (Action<IslandStateModel>)Delegate.Combine(islandState.OnPlayerCommandChange, new Action<IslandStateModel>(Singleton<GvG3EventMissionManager>.Instance.SyncPlayerCommand));
				Singleton<GvG3EventMissionManager>.Instance.UpdatePlayerCommand?.Invoke(islandState.PlayerCommand);
			}
		});
	}

	public void CloseIslandMenu()
	{
		if (IslandSelect.selectedIndex == 1 && IsIslandStateRegistered)
		{
			IsIslandStateRegistered = false;
			IslandStateModel islandStateModel = Singleton<WorldStateManager>.Instance.TryGetIsland(CurrentIslandId);
			islandStateModel.OnDetailChange = (Action<IslandStateModel>)Delegate.Remove(islandStateModel.OnDetailChange, new Action<IslandStateModel>(IslandCard.Update));
			islandStateModel.OnChangeEvent = (Action<IslandStateModel>)Delegate.Remove(islandStateModel.OnChangeEvent, new Action<IslandStateModel>(Singleton<GvG3EventMissionManager>.Instance.SyncIslandEvents));
			islandStateModel.OnPlayerCommandChange = (Action<IslandStateModel>)Delegate.Remove(islandStateModel.OnPlayerCommandChange, new Action<IslandStateModel>(Singleton<GvG3EventMissionManager>.Instance.SyncPlayerCommand));
			IslandSelect.selectedIndex = 0;
			IslandController islandController = GvGWorldMapController.Instance.LoaderManager.GetIslandController(CurrentIslandId);
			if ((Object)(object)islandController != (Object)null)
			{
				islandController.OnDeselect();
			}
			CurrentIslandId = -1;
			IslandCard.OnClose(islandStateModel);
		}
	}

	private void CloseOperationDialog()
	{
		if (IslandSelect.selectedIndex == 2)
		{
			ShowOperationDialog.PlayReverse();
			OperationDialog.HideDialog();
			ChangeChatUiVisible(chatUiVisible: true);
		}
	}

	private void CloseSweepOperationDialog()
	{
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Expected O, but got Unknown
		if (IslandSelect.selectedIndex == 3)
		{
			GvGWorldMapController.Instance.RouteManager.EraseRoute();
			DisplaySweepDialog.PlayReverse((PlayCompleteCallback)delegate
			{
				SweepOperationDialog.Hide();
			});
			ChangeChatUiVisible(chatUiVisible: true);
		}
	}

	private void CloseShipPlanOperationDialog()
	{
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Expected O, but got Unknown
		if (IslandSelect.selectedIndex == 4)
		{
			GvGWorldMapController.Instance.RouteManager.EraseRoute();
			DisplayShipPlanDialog.PlayReverse((PlayCompleteCallback)delegate
			{
				ShipPlanOperationDialog.Hide();
			});
			ChangeChatUiVisible(chatUiVisible: true);
		}
	}

	private void ExitOperationPage(bool updateIslandCard)
	{
		ExitOperationPage();
		UpdateIslandCardOnExitOperationPage(updateIslandCard);
	}

	private void UpdateIslandCardOnExitOperationPage(bool updateIslandCard)
	{
		if (updateIslandCard)
		{
			IslandStateModel islandStateModel = Singleton<WorldStateManager>.Instance.TryGetIsland(CurrentIslandId);
			IslandCard.Update(islandStateModel);
			Singleton<GvG3EventMissionManager>.Instance.UpdateIslandEvents?.Invoke(islandStateModel.IslandEvents);
		}
	}

	private void ExitOperationPage()
	{
		CloseOperationDialog();
		CloseSweepOperationDialog();
		CloseShipPlanOperationDialog();
		IslandSelect.selectedIndex = 1;
		ShipsInfo.CancelSelectShip();
	}

	private void ChangePreventInput(bool preventInput)
	{
		PreventInput.SetSelectedIndex(preventInput ? 1 : 0);
	}

	private void OnClickSweepBtn()
	{
		//IL_005f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0069: Expected O, but got Unknown
		IslandSelect.selectedIndex = 3;
		GvGWorldMapController.Instance.FocusIslandById(CurrentIslandId, 0.5f, 6f, showLocationSign: false);
		GvGWorldMapController.Instance.RouteManager.ShowNullRoute(CurrentIslandId, CurrentIslandId, displaySelector: false);
		SweepOperationDialog.Display(CurrentIslandId, new EventCallback0(DisplaySweepDialog.Play));
		ChangeChatUiVisible(chatUiVisible: false);
	}

	private void PlaySweepEffect(EventCallback0 callback)
	{
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		//IL_0043: Expected O, but got Unknown
		ChangeAlphaOnPlaySweepEffect();
		((GComponent)(object)SweepEffect).SetTimeout(0.2f).OnComplete(new GTweenCallback(PlaySweepTransition));
		void PlaySweepTransition()
		{
			//IL_002e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0038: Expected O, but got Unknown
			SweepEffect.Sweep.invalidateBatchingEveryFrame = true;
			SweepEffect.Sweep.Play((PlayCompleteCallback)delegate
			{
				((GObject)SweepEffect).alpha = 0f;
				EventCallback0 obj = callback;
				if (obj != null)
				{
					obj.Invoke();
				}
				ChangeAlphaOnPlaySweepEffect(isStart: false);
			});
			((GObject)SweepEffect).alpha = 1f;
		}
	}

	private void ChangeAlphaOnPlaySweepEffect(bool isStart = true, float duration = 0.2f)
	{
		PreventInput.SetSelectedIndex(isStart ? 1 : 0);
		if (isStart)
		{
			DisplaySweepDialog.PlayReverse();
		}
		else
		{
			DisplaySweepDialog.Play();
		}
		int num = ((!isStart) ? 1 : 0);
		((GObject)n111).TweenFade((float)num, duration);
		((GObject)n90).TweenFade((float)num, duration);
		((GObject)ShipsInfo).TweenFade((float)num, duration);
		((GObject)Operation_Cancel).TweenFade((float)num, duration);
	}

	private void OnClickRepeatedAttack()
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		IslandSelect.selectedIndex = 4;
		ShipPlanOperationDialog.Display(CurrentIslandId, new EventCallback0(DisplayShipPlanDialog.Play));
		ChangeChatUiVisible(chatUiVisible: false);
	}

	private void OnChangeOperationMode(eIslandAction islandAction)
	{
		IslandActionType = islandAction;
		IslandSelect.selectedIndex = 2;
		OperationDialog.ShowDialog();
		ChangeChatUiVisible(chatUiVisible: false);
	}

	private void OnIslandActionSuccess(int actionType)
	{
		if (CurrentIslandId != -1 && IslandSelect.selectedIndex == 2 && !OperationDialog.TryIgnoreIslandActionSuccess(actionType))
		{
			ExitOperationPage();
			CloseIslandMenu();
		}
	}

	private void EnterGvGStore()
	{
		GameController.Contexts.Service<IUiService>().OpenPanel(UI_main_GvG3StoreEntrance.Name, null);
	}

	private void OnOpenBattleRecords()
	{
		GameController.Contexts.Service<IUiService>().OpenPanel(UI_main_GvG3BattleRecordsPanel.Name, new Dictionary<string, object>());
	}

	public void OnClickBattlePass()
	{
		GameController.Contexts.Service<IUiService>().OpenPanel(UI_main_GvG3BattlePass.Name, null);
	}

	private void UpdateFlagShipMissionRedDot(bool showRedDot)
	{
		FlagShipMission.RedDot.selectedIndex = (showRedDot ? 1 : 0);
	}

	private void OnFilterClick()
	{
		HideComponentsOnFilterOpen();
		IslandFilters.DisplayFilters();
	}

	private void HideComponentsOnFilterOpen()
	{
		ChangeComponentsOnFilterVisibleChange(display: false);
	}

	private void DisplayComponentsOnFilterClose()
	{
		ChangeComponentsOnFilterVisibleChange(display: true);
	}

	private void ChangeComponentsOnFilterVisibleChange(bool display)
	{
		((GObject)BackBtn).visible = display;
		((GObject)Records).visible = display;
		((GObject)Talents).visible = display;
		((GObject)ExpeditionStore).visible = display;
		((GObject)GvGStorehouseBtn).visible = display;
		((GObject)Amplifier).visible = display;
		((GObject)ExpeditionLeaderboard).visible = display;
		((GObject)BattlePass).visible = display;
		((GObject)FlagShipMission).visible = display;
		((GObject)ShipsOverview).visible = display;
		((GObject)Filter).visible = display;
		CurrentTreasureMap.ChangeAlphaOnFilterVisibleChange(display);
		((GObject)n103).visible = display;
		ShipsInfo.CancelSelectShip();
		ChangeChatUiVisible(display);
	}

	private void ChangeChatUiVisible(bool chatUiVisible)
	{
		if (IslandFilters.State.selectedIndex != 1)
		{
			SharedMessenger.Broadcast("ON_GVG3_MAINUI_OPERATION_MODE", chatUiVisible);
		}
	}

	private void PlayEternalNightTransition()
	{
		WaitOpenEternalNight.selectedIndex = 0;
		Singleton<GvG3FlagShipMissionsManager>.Instance.TryPlayEternalNightUiTransitions(inform: true);
	}

	private void ShowEternalNightTip()
	{
		if (WorldMapConfigHelper.Configs.IsBrawlEvent())
		{
			return;
		}
		CampProgressData progressData = Singleton<WorldStateManager>.Instance.Data.ProgressData;
		if (!progressData.HasSettlement && Singleton<GvG3FlagShipMissionsManager>.Instance.IsEternalNight)
		{
			if (UI_com_LandOfNightStep1.IsEternalNightMainMissionExist())
			{
				OnComplete();
			}
			else
			{
				Singleton<GvG3FlagShipMissionsManager>.Instance.GetMissions(progressData.CampProgress, currentProgress: true, OnComplete);
			}
		}
		void OnComplete()
		{
			LandOfEternalNightStep1.Render();
			LandOfEternalNightStep2.Render();
			bool eternalNightOpen = Singleton<GvG3FlagShipMissionsManager>.Instance.EternalNightOpen;
			int campStep = progressData.CampStep;
			if (!eternalNightOpen && campStep == 1)
			{
				DisplayEternalNightTip(campStep);
			}
			else if (!Singleton<GvG3FlagShipMissionsManager>.Instance.EternalNightBossAppear && campStep == 2)
			{
				DisplayEternalNightTip(campStep);
			}
		}
	}

	private void DisplayEternalNightTip(int step)
	{
		WaitOpenEternalNight.selectedIndex = 1;
		EternalNightTip.Step.selectedIndex = step - 1;
	}

	private void ShowLastProgressSettlementPanel()
	{
		Singleton<GvG3FlagShipMissionsManager>.Instance.TryShowProgressSettlementPanel();
	}

	private void FlagShipMissionRenderer()
	{
		CampProgressData progressData = Singleton<WorldStateManager>.Instance.Data.ProgressData;
		if (progressData.HasSettlement)
		{
			ShowSettlement();
		}
		else if (Singleton<GvG3FlagShipMissionsManager>.Instance.IsEternalNight)
		{
			if (WorldMapConfigHelper.Configs.IsBrawlEvent())
			{
				ShowBrawlFightEternalNight();
			}
			else
			{
				ShowEternalNight();
			}
		}
		else
		{
			ShowWaitEternalNight();
		}
		void ShowBrawlFightEternalNight()
		{
			ProgressController.selectedIndex = 4;
			int campStep = progressData.CampStep;
			FlagShipMission.Step.SetSelectedIndex((campStep == 1) ? 8 : 9);
			FlagShipMission.Progress.SetSelectedIndex(1);
			RefreshBrawlFightEternalNight();
		}
		void ShowEternalNight()
		{
			bool eternalNightOpen = Singleton<GvG3FlagShipMissionsManager>.Instance.EternalNightOpen;
			bool eternalNightBossAppear = Singleton<GvG3FlagShipMissionsManager>.Instance.EternalNightBossAppear;
			if (!eternalNightOpen)
			{
				ProgressController.selectedIndex = 0;
				FlagShipMission.Progress.selectedIndex = 0;
				FlagShipMission.Step.selectedIndex = 4;
			}
			else
			{
				int campStep = progressData.CampStep;
				FlagShipMission.Progress.selectedIndex = 1;
				int num = progressData.CampStep + 4;
				if (campStep == 2 && !eternalNightBossAppear)
				{
					ProgressController.selectedIndex = campStep - 1;
					FlagShipMission.Step.selectedIndex = num - 1;
				}
				else
				{
					ProgressController.selectedIndex = campStep;
					FlagShipMission.Step.selectedIndex = num;
				}
			}
		}
		void ShowSettlement()
		{
			ProgressController.selectedIndex = 3;
			FlagShipMission.Progress.selectedIndex = 1;
			FlagShipMission.Step.selectedIndex = 7;
		}
		void ShowWaitEternalNight()
		{
			ProgressController.selectedIndex = 0;
			FlagShipMission.Progress.selectedIndex = 0;
			if (Singleton<GvG3FlagShipMissionsManager>.Instance.IsWaitEternalNight)
			{
				FlagShipMission.Step.selectedIndex = 4;
			}
			else
			{
				FlagShipMission.Step.selectedIndex = progressData.CampStep - 1;
			}
		}
	}

	private void RefreshBrawlFightEternalNight()
	{
		GvG3LeaderboardModel.Instance.GetData(eLeaderboardType.乱斗永夜阵营获胜榜, eLeaderboardSubType.Total, delegate(GvGMode3LeaderboardData data)
		{
			//IL_0135: Unknown result type (might be due to invalid IL or missing references)
			//IL_013f: Expected O, but got Unknown
			List<GvGMode3PlayerRankInfo> rankList = data.RankList;
			if (rankList.Count < 4)
			{
				rankList = new List<GvGMode3PlayerRankInfo>();
				int i;
				for (i = 1; i <= 4; i++)
				{
					GvGMode3PlayerRankInfo gvGMode3PlayerRankInfo = data.RankList.Find((GvGMode3PlayerRankInfo x) => x.CampId == i);
					if (gvGMode3PlayerRankInfo != null)
					{
						rankList.Add(gvGMode3PlayerRankInfo);
					}
					else
					{
						rankList.Add(new GvGMode3PlayerRankInfo
						{
							CampId = i,
							RankData = 0L
						});
					}
				}
			}
			long maxIslandCount = 1L;
			foreach (GvGMode3PlayerRankInfo item in rankList)
			{
				if (item.RankData >= maxIslandCount)
				{
					maxIslandCount = item.RankData;
				}
			}
			BrawlFightHoldingPercents.itemRenderer = (ListItemRenderer)delegate(int index, GObject item)
			{
				GvGMode3PlayerRankInfo gvGMode3PlayerRankInfo2 = rankList[index];
				UI_com_HoldingPercent uI_com_HoldingPercent = (UI_com_HoldingPercent)(object)item;
				uI_com_HoldingPercent.CampId.SetSelectedIndex(gvGMode3PlayerRankInfo2.CampId);
				string text = gvGMode3PlayerRankInfo2.RankData.ToString();
				((GObject)uI_com_HoldingPercent.islandOccupiedCount).text = text;
				((GObject)uI_com_HoldingPercent.islandOccupiedCount2).text = text;
				bool flag = maxIslandCount == gvGMode3PlayerRankInfo2.RankData;
				uI_com_HoldingPercent.isAdvance.SetSelectedIndex(flag ? 1 : 0);
			};
			BrawlFightHoldingPercents.numItems = rankList.Count;
		});
	}

	private void OnClickBrawlFightBuffs()
	{
		GameController.Contexts.Service<IUiService>().OpenPanel(UI_main_BrawlBuffInfo.Name, new Dictionary<string, object>());
	}

	private void OnClickMyFlagShip(EventContext context)
	{
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0013: Expected O, but got Unknown
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		//IL_004c: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cb: Expected O, but got Unknown
		GObject target = (GObject)context.sender;
		LocationData locationData = new LocationData
		{
			IslandId = Singleton<WorldStateManager>.Instance.Data.OurFlagShipStayIslandId,
			Type = 3,
			Step = 0
		};
		UI_com_Islandlocation uI_com_Islandlocation = FairyGUITip.ShowTip<UI_com_Islandlocation>(target, eFairyGUITipDir.Down);
		uI_com_Islandlocation.Step.selectedIndex = locationData.Step;
		uI_com_Islandlocation.Type.selectedIndex = locationData.Type;
		((GObject)uI_com_Islandlocation.IslandName).text = WorldMapConfigHelper.Configs.TryGetIsland(locationData.IslandId)?.Name;
		((GObject)uI_com_Islandlocation.Positioning).onClick.Set((EventCallback0)delegate
		{
			GvGWorldMapController.Instance.FocusIslandById(locationData.IslandId);
		});
	}

	private void OnClickJumpToFligShip()
	{
		int ourFlagShipStayIslandId = Singleton<WorldStateManager>.Instance.Data.OurFlagShipStayIslandId;
		string shipIdStaySomeIsland = Singleton<GvGMode3RoomManager>.Instance.ObserverRecord.GetShipIdStaySomeIsland(ourFlagShipStayIslandId);
		if (string.IsNullOrEmpty(shipIdStaySomeIsland))
		{
			ILRequestHelper.ShowMessage("GvG3CanNotUseFlagShipTip".ToLanguage());
			GvGWorldMapController.Instance.FocusIslandById(ourFlagShipStayIslandId);
		}
		else
		{
			GameController.Contexts.Service<IUiService>().OpenPanel(UI_main_GvGFlagshipPanel.Name, new Dictionary<string, object>());
		}
	}

	private void UpdateTalentsRedDot()
	{
		if (!((GObject)this).isDisposed)
		{
			int activateNextTalentConsumePoints = Singleton<GvGTalentsManager>.Instance.GetActivateNextTalentConsumePoints();
			activateNextTalentConsumePoints = 十六加八.GetActiveTalentConsumeInt(activateNextTalentConsumePoints);
			int itemCount = Singleton<GvGStoreHouseManager>.Instance.GetItemCount("I32017");
			((GObject)Talents.RedDot).visible = itemCount >= activateNextTalentConsumePoints;
		}
	}

	private void UpdateRecordsRedDot(bool showDot)
	{
		((GObject)Records.RedDot).visible = showDot;
	}

	private void UpdateAmplifierRedDot(bool showDot)
	{
		((GObject)Amplifier.RedDot).visible = showDot;
	}

	private void UpdateShipsCount()
	{
		GvGMode3ObserverRecord observerRecord = Singleton<GvGMode3RoomManager>.Instance.ObserverRecord;
		((GObject)ShipsOverview.ShipsCount).text = $"({observerRecord.Ships.Count}/{observerRecord.ShipCountLimit})";
	}

	private void OnOpenShipOverviewPanel(EventContext context)
	{
		OpenShipOverviewPanel(0);
	}

	public void OpenShipOverviewPanel(int index)
	{
		Dictionary<string, object> parameters = new Dictionary<string, object>
		{
			{ "ReservePackageResOnClose", false },
			{
				"OnClose",
				new UICallbackParam<Action>(UpdateShipsCount)
			},
			{ "Focus", index }
		};
		GameController.Contexts.Service<IUiService>().OpenPanel(UI_GvGShipOverviewPanel.Name, parameters);
	}

	public void JumpToIsland(int shipEntityId, int targetIslandId, Action onFinished = null, OuterTechHelper.Jump努力加餐饭Cost cost = null)
	{
		PreventInput.selectedIndex = 1;
		TransitionHook val = default(TransitionHook);
		TransitionHook val4 = default(TransitionHook);
		Singleton<WorldStateManager>.Instance.ShipJumpToIsland(shipEntityId, targetIslandId, delegate(bool canJump)
		{
			//IL_004a: Unknown result type (might be due to invalid IL or missing references)
			//IL_004f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0051: Expected O, but got Unknown
			//IL_0056: Expected O, but got Unknown
			//IL_0084: Unknown result type (might be due to invalid IL or missing references)
			//IL_0089: Unknown result type (might be due to invalid IL or missing references)
			//IL_008b: Expected O, but got Unknown
			//IL_0090: Expected O, but got Unknown
			if (canJump)
			{
				LoadSpine();
				JumpEffectController.selectedIndex = 1;
				Transition obj = JumpEffect.In;
				TransitionHook obj2 = val;
				if (obj2 == null)
				{
					TransitionHook val2 = delegate
					{
						GvGWorldMapController.Instance.LoaderManager.IslandLoader.OnLoadingFinished = delegate
						{
							JumpEffectController.selectedIndex = 2;
						};
						GvGWorldMapController.Instance.FocusIslandById(targetIslandId, 0f, 6f, showLocationSign: false);
						GvGWorldMapController.Instance.LoaderManager.NeedUpdate = true;
					};
					TransitionHook val3 = val2;
					val = val2;
					obj2 = val3;
				}
				obj.SetHook("EndIn", obj2);
				Transition obj3 = JumpEffect.Out;
				TransitionHook obj4 = val4;
				if (obj4 == null)
				{
					TransitionHook val5 = delegate
					{
						PreventInput.selectedIndex = 0;
						onFinished?.Invoke();
					};
					TransitionHook val3 = val5;
					val4 = val5;
					obj4 = val3;
				}
				obj3.SetHook("EndOut", obj4);
			}
			else
			{
				PreventInput.selectedIndex = 0;
			}
		}, cost);
		void LoadSpine()
		{
			//IL_00bd: Unknown result type (might be due to invalid IL or missing references)
			//IL_013d: Unknown result type (might be due to invalid IL or missing references)
			int shipRace = Singleton<GvGMode3RoomManager>.Instance.ObserverRecord.GetMyShipData(CurrentShipId).TemporaryData.ShipRace;
			ShipConfigModel byShipRaceType = ShipConfigHelper.GetByShipRaceType(shipRace);
			SpineGoWrapper.wrapTarget = ShipAnimCacheManager.GetCache("", byShipRaceType.DefaultSkinId, delegate(SkeletonAnimation animation)
			{
				SpineHelper.SetSkin((ISkeletonAnimation)(object)animation, "skin1");
				animation.AnimationState.SetAnimation(0, "yueqian", false);
			}, isMask: false, isSimpleSpine: true, delegate(SkeletonAnimation animation)
			{
				animation.AnimationState.SetAnimation(0, "yueqian", false);
			});
			SpineGoWrapper.wrapTarget.transform.localScale = new Vector3(100f, 100f, 100f);
			if (FxGoWrapper.wrapTarget == null)
			{
				FxGoWrapper.wrapTarget = ShipAnimCacheManager.GetCache("Fx_qiliu", "Fx_qiliu", delegate(SkeletonAnimation animation)
				{
					SpineHelper.SetSkin((ISkeletonAnimation)(object)animation, "skin1");
					animation.AnimationState.SetAnimation(0, "qiliu", false);
					animation.loop = false;
					_fxAnimation = animation;
				});
				FxGoWrapper.wrapTarget.transform.localScale = new Vector3(100f, 100f, 100f);
			}
			else
			{
				_fxAnimation.AnimationState.SetAnimation(0, "qiliu", false);
			}
		}
	}

	public void BeforeDestroy()
	{
		ExitOperationPage();
		UnregisterEventOnWorldRelease();
		Singleton<GvG3FlagShipMissionsManager>.Instance.ClearData();
		GvGWorldMapController.ReleaseInstance();
		Input.multiTouchEnabled = false;
		ShipsInfo.BeforeDestroy();
		Singleton<GvGMode3RoomManager>.Instance.TryDelayDisconnectRoom();
		OperationDialog.UnregisterEvent();
		OperationDialog.OnDestroy();
		LandOfEternalNightEnd.Destroy();
		LandOfEternalNightStep2.Destroy();
		BestOfToday.Destroy();
		Progress.Destroy();
		LandOfEternalNightStep1.Destroy();
		CurrentTreasureMap.Destroy();
		IslandEvents.Destroy();
		BattlePass.Destroy();
		ShipAnimCacheManager?.ClearCache();
	}

	public void Destroy()
	{
	}

	private IEnumerator DelayRecover_ForceStop()
	{
		yield return null;
		GameController.Contexts.Service<IUiService>().RecoverLastBackup(1);
		GameController.Contexts.Service<IUiService>().OpenPanel(UI_MainCity.Name, null);
		while (!GameController.Contexts.Service<IUiService>().HasShowingUi(UI_MainCity.Name))
		{
			yield return null;
		}
		SharedMessenger.Broadcast("CLOSE_GVGLOADING_UI");
	}

	private IEnumerator DelayRecover()
	{
		yield return null;
		GameController.Contexts.Service<IUiService>().RecoverLastBackup();
		while (!GameController.Contexts.Service<IUiService>().HasShowingUi(UI_GvGExpeditionHallPanel.Name))
		{
			yield return null;
		}
		SharedMessenger.Broadcast("CLOSE_GVGLOADING_UI");
	}

	private IEnumerator DelayReturnMainCity()
	{
		yield return null;
		Singleton<GvGMode3RoomManager>.Instance.OnQuickStartReturnMainCity?.Invoke();
		Singleton<GvGMode3RoomManager>.Instance.OnQuickStartReturnMainCity = null;
		while (!GameController.Contexts.Service<IUiService>().HasShowingUi(UI_MainCity.Name))
		{
			yield return null;
		}
		SharedMessenger.Broadcast("CLOSE_GVGLOADING_UI");
	}

	private void InitBrawlFightState(string izId)
	{
		ShowBrawlEventTip.SetSelectedIndex(0);
		if (WorldMapConfigHelper.IsBrawlFightEvent(izId))
		{
			Task<C2S_BrawlEvent_GetInfo.Response> infoTask = UI_main_BrawlFightEnroll.GetBrawlEventInfo();
			infoTask.GetAwaiter().OnCompleted(delegate
			{
				C2S_BrawlEvent_GetInfo.Response result = infoTask.Result;
				RefreshBrawlEventTip(result);
			});
			GameManagers.Instance.Messenger.AddListener<C2S_BrawlEvent_GetInfo.Response>("BRAWL_EVENT_SIGN_UP_CHANGE", RefreshBrawlEventTip);
		}
	}

	private void RefreshBrawlEventTip(C2S_BrawlEvent_GetInfo.Response response)
	{
		bool flag = false;
		C2S_BrawlEvent_GetInfo.Stage stage = response.GetStage();
		if ((stage == C2S_BrawlEvent_GetInfo.Stage.Enroll || stage == C2S_BrawlEvent_GetInfo.Stage.EnrollFirstDay) && !response.IsAnyShipEnrolled())
		{
			flag = true;
			BrawlEventTip.Type.SetSelectedIndex(0);
		}
		else if (response.HasUnClaimedReward())
		{
			flag = true;
			BrawlEventTip.Type.SetSelectedIndex(1);
		}
		ShowBrawlEventTip.SetSelectedIndex(flag ? 1 : 0);
	}
}
