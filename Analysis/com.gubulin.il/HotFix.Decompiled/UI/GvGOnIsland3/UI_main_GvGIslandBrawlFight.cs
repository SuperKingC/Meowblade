using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Assets.Scripts.UI;
using FairyGUI;
using FairyGUI.Utils;
using GvG3;
using HotFix.Sources.Base.Scripts.Helper;
using HotFix.Sources.Base.Scripts.Utils;
using HotFix.Sources.Base.Sources.Scripts.GvG3.GvG3OnIsland.Model;
using HotFix.Sources.Base.Sources.Scripts.GvG3.GvG3UI.Helper;
using HotFix.Sources.Base.Sources.Scripts.GvG3.GvG3UI.Model.UserProfile;
using HotFix.Sources.Base.Sources.Scripts.GvG3Common.Model;
using HotFix.Sources.Base.Sources.Scripts.GvG3OnIsland.Model;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Helper;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Manager;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Model;
using HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Controller;
using HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Helper;
using Shift.Legion.ClientApi.Protocol;
using Shift.Legion.Common.Helpers;
using Shift.Legion.Common.Services;
using Shift.Legion.GvG.Common.Enums;
using Shift.Legion.GvG.Common.GvGMode3Island;
using Shift.Legion.GvG.Common.Models.GvGMode3;
using Shift.Legion.GvG.Common.Models.GvGMode3.BrawlEvent;
using Shift.Legion.GvGServer.Models.GvGMode3IslandManagerSocket.FinalProgress;
using Shift.Legion.GvGServer.Models.GvGMode3IslandManagerSocket.Mission;
using Shift.Legion.GvGServer.Models.GvGMode3IslandSocket;
using Shift.Legion.GvGServer.Models.IslandManagerSocket;
using UI.GvGBrawlFight;
using UI.GvGChat;
using UI.PublicResources;
using UnityEngine;

namespace UI.GvGOnIsland3;

public class UI_main_GvGIslandBrawlFight : GComponent, IUiController
{
	public class ReplayParam
	{
		public int IslandId;

		public bool IsStreaming;

		public C2S_BrawlEvent_GetInfo.Response EventInfo;

		public C2S_BrawlEvent_GetDetailInfoByIsland.Response DetailInfo;

		public int StepIndex;
	}

	public Controller showTopBanner;

	public Controller isPause;

	public GLoader background;

	public GGraph RayMask;

	public GButton BackBtn;

	public UI_com_BestKill BestKill;

	public UI_com_LeaderboardBrawlFight Leaderboard;

	public UI_com_MyShipBrawlFight MyShipsMenu;

	public UI_com_IslandMenuBrawlFight IslandMenu;

	public UI_com_BrawlFightTopBanner TopBanner;

	public GImage n111;

	public GImage progressBg;

	public GImage progress;

	public GGroup progressBar;

	public GTextField TimeText;

	public GTextField maxTime;

	public GTextField n117;

	public UI_btn_play playBtn;

	public UI_btn_pause pauseBtn;

	public UI_btn_01 backwardBtn;

	public UI_btn_02 forwardBtn;

	public UI_btn_speed changeSpeed;

	public GGroup replayPanelGroup;

	public UI_com_Survivors NpcInfo2;

	public Transition t2;

	public const string URL = "ui://ebc4ciwrlc02q6b";

	public static string Name = "UI_main_GvGIslandBrawlFight";

	public const string REPLAY_PARAM = "ReplayParam";

	private CoroutineQueue BeskKillCoroutineQueue;

	private int _curBestKillUser = -1;

	public List<GvGMode3IslandRankInfo> RankList;

	private string _cacheId;

	private int _speedIndex = 0;

	private int[] _speedValues = new int[3] { 1, 2, 5 };

	private const int ClickJumpTime = 60;

	private float _maxProgressWidth;

	private bool _isCampFight;

	private string _recordUrl;

	private bool _isDisposed;

	private GvG3BrawlFightRecordPlayer _controller;

	private ReplayParam _replayParam;

	private List<GvGMode3CampRankInfo> _campRank;

	private double _myShipScore;

	private bool _forceStop;

	private string _timeFormat;

	private static readonly List<string> ShowUi = new List<string> { UI_main_GvG3Chat.Name };

	private static readonly List<string> HideUi = new List<string> { UI_main_BrawlFightSelectIsland.Name };

	private float _pinchDelta;

	public bool IsCampFight => _isCampFight;

	public static string GetURL()
	{
		return "ui://ebc4ciwrlc02q6b";
	}

	public static UI_main_GvGIslandBrawlFight CreateInstance()
	{
		return (UI_main_GvGIslandBrawlFight)(object)UIPackage.CreateObject("GvGOnIsland3", "main_GvGIslandBrawlFight");
	}

	public static UI_main_GvGIslandBrawlFight CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_main_GvGIslandBrawlFight).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://ebc4ciwrlc02q6b", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Expected O, but got Unknown
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Expected O, but got Unknown
		//IL_0063: Unknown result type (might be due to invalid IL or missing references)
		//IL_006d: Expected O, but got Unknown
		//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f1: Expected O, but got Unknown
		//IL_00fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0107: Expected O, but got Unknown
		//IL_0113: Unknown result type (might be due to invalid IL or missing references)
		//IL_011d: Expected O, but got Unknown
		//IL_0129: Unknown result type (might be due to invalid IL or missing references)
		//IL_0133: Expected O, but got Unknown
		//IL_013f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0149: Expected O, but got Unknown
		//IL_0155: Unknown result type (might be due to invalid IL or missing references)
		//IL_015f: Expected O, but got Unknown
		//IL_016b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0175: Expected O, but got Unknown
		//IL_01ef: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f9: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		showTopBanner = ((GComponent)this).GetController("showTopBanner");
		isPause = ((GComponent)this).GetController("isPause");
		background = (GLoader)((GComponent)this).GetChild("background");
		RayMask = (GGraph)((GComponent)this).GetChild("RayMask");
		BackBtn = (GButton)((GComponent)this).GetChild("BackBtn");
		BestKill = (UI_com_BestKill)(object)((GComponent)this).GetChild("BestKill");
		Leaderboard = (UI_com_LeaderboardBrawlFight)(object)((GComponent)this).GetChild("Leaderboard");
		MyShipsMenu = (UI_com_MyShipBrawlFight)(object)((GComponent)this).GetChild("MyShipsMenu");
		IslandMenu = (UI_com_IslandMenuBrawlFight)(object)((GComponent)this).GetChild("IslandMenu");
		TopBanner = (UI_com_BrawlFightTopBanner)(object)((GComponent)this).GetChild("TopBanner");
		n111 = (GImage)((GComponent)this).GetChild("n111");
		progressBg = (GImage)((GComponent)this).GetChild("progressBg");
		progress = (GImage)((GComponent)this).GetChild("progress");
		progressBar = (GGroup)((GComponent)this).GetChild("progressBar");
		TimeText = (GTextField)((GComponent)this).GetChild("TimeText");
		maxTime = (GTextField)((GComponent)this).GetChild("maxTime");
		n117 = (GTextField)((GComponent)this).GetChild("n117");
		playBtn = (UI_btn_play)(object)((GComponent)this).GetChild("playBtn");
		pauseBtn = (UI_btn_pause)(object)((GComponent)this).GetChild("pauseBtn");
		backwardBtn = (UI_btn_01)(object)((GComponent)this).GetChild("backwardBtn");
		forwardBtn = (UI_btn_02)(object)((GComponent)this).GetChild("forwardBtn");
		changeSpeed = (UI_btn_speed)(object)((GComponent)this).GetChild("changeSpeed");
		replayPanelGroup = (GGroup)((GComponent)this).GetChild("replayPanelGroup");
		NpcInfo2 = (UI_com_Survivors)(object)((GComponent)this).GetChild("NpcInfo2");
		t2 = ((GComponent)this).GetTransition("t2");
	}

	public void Init(Dictionary<string, object> parameters)
	{
		//IL_02c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_02cd: Expected O, but got Unknown
		FGUIManager.SetUiPanelSizeAndXy((GObject)(object)this);
		GameController.Contexts.Service<IUiService>().HideUis(ShowUi, uiVisible: true);
		GameController.Contexts.Service<IUiService>().HideUis(HideUi);
		GvGWorldMapController.Instance.Pause();
		ReplayParam replayParam = (ReplayParam)parameters["ReplayParam"];
		_replayParam = replayParam;
		int startPlaySecond = 0;
		if (replayParam.IsStreaming)
		{
			long brawlEventTime = UI_main_BrawlFightEnroll.GetBrawlEventTime();
			int getFightingTimeEnd = replayParam.EventInfo.GetFightingTimeEnd;
			startPlaySecond = (int)(brawlEventTime - getFightingTimeEnd);
			startPlaySecond = Mathf.Min(replayParam.DetailInfo.ReplayDuration, startPlaySecond);
			((GObject)replayPanelGroup).visible = false;
		}
		BeskKillCoroutineQueue = new CoroutineQueue((MonoBehaviour)(object)FGUIManager.Instance);
		RankList = new List<GvGMode3IslandRankInfo>();
		_maxProgressWidth = ((GObject)progress).width;
		((GObject)maxTime).text = "--:--";
		((GObject)TimeText).text = "--:--";
		_timeFormat = "mm':'ss";
		((GObject)progress).width = 0f;
		_isDisposed = false;
		_isCampFight = replayParam.DetailInfo.GetSubType() == eGvGMode3CampMissionSubType.RE_FactionWar;
		_cacheId = $"{Singleton<GvGMode3RoomManager>.Instance.ObserverRecord.CurIZId}";
		((GObject)IslandMenu.IslandName).text = WorldMapConfigHelper.Configs.TryGetIsland(replayParam.IslandId).Name;
		_controller = GvG3BrawlFightRecordPlayer.CreatePlayer();
		RegisterGvGEvent();
		_speedIndex = 1;
		_controller.PlaySpeed = _speedValues[_speedIndex];
		RefreshPlaySpeed();
		GvG3BrawlFightDownload.DownloadRecord(replayParam.DetailInfo.GetReplayName() + ".zip", !_replayParam.IsStreaming, delegate(string localPath)
		{
			if (!string.IsNullOrEmpty(localPath))
			{
				try
				{
					_forceStop = false;
					_recordUrl = localPath;
					_controller.InitRecord(_recordUrl, replayParam.StepIndex);
					_controller.PlayRecord(startPlaySecond);
					_timeFormat = ((_controller.MaxTime >= 3600f) ? "hh':'mm':'ss" : "mm':'ss");
					((GObject)maxTime).text = GetTimeString(_controller.MaxTime);
					RefreshPauseState();
					((MonoBehaviour)FGUIManager.Instance).StartCoroutine(Update());
					return;
				}
				catch (Exception arg)
				{
					ILRuntimeDebug.LogError($"Failed to play record, error: {arg}");
					File.Delete(localPath);
					End();
					return;
				}
			}
			End();
		});
		_myShipScore = 0.0;
		showTopBanner.SetSelectedIndex(1);
		EffectHelper.CoroutineDelay(5f, delegate
		{
			if (!((GObject)this).isDisposed)
			{
				showTopBanner.SetSelectedIndex(0);
			}
		});
		TopBanner.isFfa.SetSelectedIndex((!_isCampFight) ? 1 : 0);
		SetMyCampShipCount(0);
		SetAliveConfigPar(1f);
		NpcInfo2.isFinal.SetSelectedIndex(UI_main_BrawlFightEnroll.IsFinalStep(_replayParam.StepIndex) ? 1 : 0);
		Leaderboard.CampRank.itemRenderer = new ListItemRenderer(RenderCampRank);
		Leaderboard.Type.selectedIndex = 0;
		Leaderboard.isShowSwitchBtn.SetSelectedIndex(_isCampFight ? 1 : 0);
		UpdateMyShipMenu();
	}

	private void RegisterGvGEvent()
	{
		GvG3BrawlFightRecordPlayer controller = _controller;
		controller.OnCreateMyShips = (Action<EntityInfo>)Delegate.Combine(controller.OnCreateMyShips, new Action<EntityInfo>(OnCreateMyShips));
		GvG3BrawlFightRecordPlayer controller2 = _controller;
		controller2.OnChangeBestKill = (Action<S2C_ChangeGvGMode3BestKill.Request>)Delegate.Combine(controller2.OnChangeBestKill, new Action<S2C_ChangeGvGMode3BestKill.Request>(OnChangeBestKill));
		GvG3BrawlFightRecordPlayer controller3 = _controller;
		controller3.OnChangeZoomLevel = (Action<GvG3IslandController.eZoomLevel>)Delegate.Combine(controller3.OnChangeZoomLevel, new Action<GvG3IslandController.eZoomLevel>(OnChangeZoomLevel));
		GvG3BrawlFightRecordPlayer controller4 = _controller;
		controller4.OnIslandStop = (Action)Delegate.Combine(controller4.OnIslandStop, new Action(OnIslandStop));
		GvGMapInputManager inputManager = _controller.InputManager;
		inputManager.OnPinchStart = (Action)Delegate.Combine(inputManager.OnPinchStart, new Action(OnPinchBegin));
		GvGMapInputManager inputManager2 = _controller.InputManager;
		inputManager2.OnPinch = (Action<float>)Delegate.Combine(inputManager2.OnPinch, new Action<float>(OnPinch));
		GvGMapInputManager inputManager3 = _controller.InputManager;
		inputManager3.OnPinchEnd = (Action)Delegate.Combine(inputManager3.OnPinchEnd, new Action(OnPinchEnd));
		GvG3BrawlFightRecordPlayer controller5 = _controller;
		controller5.OnPushIslandRank = (Action<S2C_GvGMode3IslandRank.Request>)Delegate.Combine(controller5.OnPushIslandRank, new Action<S2C_GvGMode3IslandRank.Request>(OnPushIslandRank));
		GvG3BrawlFightRecordPlayer controller6 = _controller;
		controller6.OnPushNotification = (Action<S2C_BrawlReplayNotification.Request>)Delegate.Combine(controller6.OnPushNotification, new Action<S2C_BrawlReplayNotification.Request>(OnPushNotification));
		GvG3BrawlFightRecordPlayer controller7 = _controller;
		controller7.OnGetBattleResult = (Action<S2C_BroadcastGvGMode3BattleResult.Request>)Delegate.Combine(controller7.OnGetBattleResult, new Action<S2C_BroadcastGvGMode3BattleResult.Request>(OnGetBattleResult));
		GvG3BrawlFightRecordPlayer controller8 = _controller;
		controller8.OnChangeCampShipCount = (Action<CampShipCount>)Delegate.Combine(controller8.OnChangeCampShipCount, new Action<CampShipCount>(OnCampShipCountChange));
		GvG3BrawlFightRecordPlayer controller9 = _controller;
		controller9.OnPushMyShipAliveState = (Action<Gvg3GroupBrawlFight>)Delegate.Combine(controller9.OnPushMyShipAliveState, new Action<Gvg3GroupBrawlFight>(OnPushMyShipAliveState));
		GvG3BrawlFightRecordPlayer controller10 = _controller;
		controller10.OnPlayComplete = (Action<BrawlReplay_Result>)Delegate.Combine(controller10.OnPlayComplete, new Action<BrawlReplay_Result>(OnPlayComplete));
	}

	private void UnRegisterGvGEvent()
	{
		GvG3BrawlFightRecordPlayer controller = _controller;
		controller.OnCreateMyShips = (Action<EntityInfo>)Delegate.Remove(controller.OnCreateMyShips, new Action<EntityInfo>(OnCreateMyShips));
		GvG3BrawlFightRecordPlayer controller2 = _controller;
		controller2.OnChangeBestKill = (Action<S2C_ChangeGvGMode3BestKill.Request>)Delegate.Remove(controller2.OnChangeBestKill, new Action<S2C_ChangeGvGMode3BestKill.Request>(OnChangeBestKill));
		GvG3BrawlFightRecordPlayer controller3 = _controller;
		controller3.OnChangeZoomLevel = (Action<GvG3IslandController.eZoomLevel>)Delegate.Remove(controller3.OnChangeZoomLevel, new Action<GvG3IslandController.eZoomLevel>(OnChangeZoomLevel));
		GvG3BrawlFightRecordPlayer controller4 = _controller;
		controller4.OnIslandStop = (Action)Delegate.Remove(controller4.OnIslandStop, new Action(OnIslandStop));
		GvGMapInputManager inputManager = _controller.InputManager;
		inputManager.OnPinchStart = (Action)Delegate.Remove(inputManager.OnPinchStart, new Action(OnPinchBegin));
		GvGMapInputManager inputManager2 = _controller.InputManager;
		inputManager2.OnPinch = (Action<float>)Delegate.Remove(inputManager2.OnPinch, new Action<float>(OnPinch));
		GvGMapInputManager inputManager3 = _controller.InputManager;
		inputManager3.OnPinchEnd = (Action)Delegate.Remove(inputManager3.OnPinchEnd, new Action(OnPinchEnd));
		GvG3BrawlFightRecordPlayer controller5 = _controller;
		controller5.OnPushIslandRank = (Action<S2C_GvGMode3IslandRank.Request>)Delegate.Remove(controller5.OnPushIslandRank, new Action<S2C_GvGMode3IslandRank.Request>(OnPushIslandRank));
		GvG3BrawlFightRecordPlayer controller6 = _controller;
		controller6.OnPushNotification = (Action<S2C_BrawlReplayNotification.Request>)Delegate.Remove(controller6.OnPushNotification, new Action<S2C_BrawlReplayNotification.Request>(OnPushNotification));
		GvG3BrawlFightRecordPlayer controller7 = _controller;
		controller7.OnGetBattleResult = (Action<S2C_BroadcastGvGMode3BattleResult.Request>)Delegate.Remove(controller7.OnGetBattleResult, new Action<S2C_BroadcastGvGMode3BattleResult.Request>(OnGetBattleResult));
		GvG3BrawlFightRecordPlayer controller8 = _controller;
		controller8.OnChangeCampShipCount = (Action<CampShipCount>)Delegate.Remove(controller8.OnChangeCampShipCount, new Action<CampShipCount>(OnCampShipCountChange));
		GvG3BrawlFightRecordPlayer controller9 = _controller;
		controller9.OnPushMyShipAliveState = (Action<Gvg3GroupBrawlFight>)Delegate.Remove(controller9.OnPushMyShipAliveState, new Action<Gvg3GroupBrawlFight>(OnPushMyShipAliveState));
		GvG3BrawlFightRecordPlayer controller10 = _controller;
		controller10.OnPlayComplete = (Action<BrawlReplay_Result>)Delegate.Remove(controller10.OnPlayComplete, new Action<BrawlReplay_Result>(OnPlayComplete));
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
		//IL_008c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0096: Expected O, but got Unknown
		//IL_00ae: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b8: Expected O, but got Unknown
		//IL_00d0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00da: Expected O, but got Unknown
		//IL_00ed: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f7: Expected O, but got Unknown
		//IL_010a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0114: Expected O, but got Unknown
		//IL_0127: Unknown result type (might be due to invalid IL or missing references)
		//IL_0131: Expected O, but got Unknown
		//IL_0144: Unknown result type (might be due to invalid IL or missing references)
		//IL_014e: Expected O, but got Unknown
		//IL_0161: Unknown result type (might be due to invalid IL or missing references)
		//IL_016b: Expected O, but got Unknown
		((GObject)BackBtn).onClick.Add(new EventCallback0(End));
		((GObject)RayMask).onTouchBegin.Add(new EventCallback1(OnDragBegin));
		((GObject)RayMask).onTouchMove.Add(new EventCallback1(OnDrag));
		((GObject)RayMask).onTouchEnd.Add(new EventCallback1(OnDragEnd));
		((GObject)IslandMenu.Zoom).onClick.Add(new EventCallback0(OnClickZoomBtn));
		((GObject)Leaderboard.Switch).onClick.Set(new EventCallback0(ChangeCurRankingList));
		((GObject)Leaderboard.Help).onClick.Set(new EventCallback0(ShowCampaignContributionAccessTip));
		((GObject)changeSpeed).onClick.Set(new EventCallback0(OnClickSetPlaySpeed));
		((GObject)backwardBtn).onClick.Set(new EventCallback0(OnClickJumpBackward));
		((GObject)forwardBtn).onClick.Set(new EventCallback0(OnClickJumpForward));
		((GObject)playBtn).onClick.Set(new EventCallback0(OnClickPause));
		((GObject)pauseBtn).onClick.Set(new EventCallback0(OnClickPause));
		GvGMode3RoomManager instance = Singleton<GvGMode3RoomManager>.Instance;
		instance.OnRoomClose = (Action)Delegate.Combine(instance.OnRoomClose, new Action(ForceClose));
	}

	public void UnregisterUiEventListeners()
	{
		((GObject)BackBtn).onClick.Clear();
		((GObject)RayMask).onTouchBegin.Clear();
		((GObject)RayMask).onTouchMove.Clear();
		((GObject)RayMask).onTouchEnd.Clear();
		((GObject)IslandMenu.Zoom).onClick.Clear();
		((GObject)Leaderboard.Switch).onClick.Clear();
		((GObject)Leaderboard.Help).onClick.Clear();
		((GObject)changeSpeed).onClick.Clear();
		((GObject)backwardBtn).onClick.Clear();
		((GObject)forwardBtn).onClick.Clear();
		((GObject)playBtn).onClick.Clear();
		((GObject)pauseBtn).onClick.Clear();
		GvGMode3RoomManager instance = Singleton<GvGMode3RoomManager>.Instance;
		instance.OnRoomClose = (Action)Delegate.Remove(instance.OnRoomClose, new Action(ForceClose));
	}

	private IEnumerator Update()
	{
		while (!((GObject)this).isDisposed)
		{
			if (_replayParam.IsStreaming && !_forceStop)
			{
				int currentTime = GetCurrentPlaySecond();
				if (currentTime >= 3600)
				{
					_forceStop = true;
					OnClickJumpToSecond(Mathf.FloorToInt(_controller.MaxTime));
				}
			}
			RefreshTime();
			yield return null;
		}
	}

	private void RefreshTime()
	{
		int currentPlaySecond = GetCurrentPlaySecond();
		((GObject)TimeText).text = GetTimeString(currentPlaySecond);
		float num = (float)currentPlaySecond / _controller.MaxTime;
		((GObject)progress).width = num * _maxProgressWidth;
	}

	private int GetCurrentPlaySecond()
	{
		return (int)_controller.CurrentTime;
	}

	private void OnClickSetPlaySpeed()
	{
		_speedIndex = (_speedIndex + 1) % _speedValues.Length;
		int num = _speedValues[_speedIndex];
		_controller.PlaySpeed = num;
		RefreshPlaySpeed();
	}

	private void OnClickJumpBackward()
	{
		int currentPlaySecond = GetCurrentPlaySecond();
		currentPlaySecond -= 60;
		if (currentPlaySecond < 0)
		{
			currentPlaySecond = 0;
		}
		OnClickJumpToSecond(currentPlaySecond);
	}

	private void OnClickJumpForward()
	{
		int currentPlaySecond = GetCurrentPlaySecond();
		currentPlaySecond += 60;
		if ((float)currentPlaySecond > _controller.MaxTime)
		{
			currentPlaySecond = Mathf.FloorToInt(_controller.MaxTime);
		}
		OnClickJumpToSecond(currentPlaySecond);
	}

	private void OnClickPause()
	{
		bool pause = !_controller.IsPause;
		_controller.SetPause(pause);
		RefreshPauseState();
	}

	private void RefreshPauseState()
	{
		isPause.SetSelectedIndex(_controller.IsPause ? 1 : 0);
	}

	private void OnCreateMyShips(EntityInfo info)
	{
		UpdateMyShipMenu();
	}

	private void ChangeCurRankingList()
	{
		if (_isCampFight)
		{
			int selectedIndex = Leaderboard.Type.selectedIndex;
			selectedIndex = 1 - selectedIndex;
			Leaderboard.Type.selectedIndex = selectedIndex;
		}
	}

	private void OnClickZoomBtn()
	{
		if (GvG3IslandController.IsInstanceCreated)
		{
			_controller.SwitchZooming();
		}
	}

	private void OnChangeZoomLevel(GvG3IslandController.eZoomLevel zoomLevel)
	{
		IslandMenu.Zoom.Type.selectedIndex = (int)zoomLevel;
	}

	public void OnDragBegin(EventContext context)
	{
		if (GvG3IslandController.IsInstanceCreated)
		{
			_controller.InputManager.UpdateInput();
		}
		context.CaptureTouch();
	}

	public void OnDrag(EventContext context)
	{
		if (GvG3IslandController.IsInstanceCreated)
		{
			_controller.InputManager.UpdateInput();
		}
	}

	public void OnDragEnd(EventContext context)
	{
		if (GvG3IslandController.IsInstanceCreated)
		{
			_controller.InputManager.UpdateInput();
		}
		context.CaptureTouch();
	}

	private void OnPinchBegin()
	{
	}

	private void OnPinch(float pinchDelta)
	{
		_pinchDelta = pinchDelta;
	}

	private void OnPinchEnd()
	{
		if (GvG3IslandController.IsInstanceCreated)
		{
			GvG3IslandController.eZoomLevel level = ((_pinchDelta > 1f) ? GvG3IslandController.eZoomLevel.ZoomLevel2 : GvG3IslandController.eZoomLevel.ZoomLevel1);
			_controller.SwitchZooming(level);
		}
	}

	private void OnChangeBestKill(S2C_ChangeGvGMode3BestKill.Request req)
	{
		GvGMode3BestKill bestKill = req.BestKill;
		BeskKillCoroutineQueue.AddCoroutine(ProccessBestKill(bestKill.UserId, bestKill.KillCount, bestKill.CampId, bestKill.ShipRace, bestKill.IsLastBestKillIsKilled));
	}

	private void OnPushNotification(S2C_BrawlReplayNotification.Request obj)
	{
		SetAliveConfigPar(obj.AliveConfigPar);
	}

	private void SetAliveConfigPar(float par)
	{
		((GObject)NpcInfo2.Magnification).text = $"x{par:N1}";
		NpcInfo2.Type.SetSelectedIndex((par > 1.01f) ? 1 : 0);
	}

	private void OnPlayComplete(BrawlReplay_Result result)
	{
		UnityUiService.Instance.OpenPanel(UI_com_VictoryPopup.Name, new Dictionary<string, object>
		{
			{
				"WinUser",
				result.WinUserIds[0]
			},
			{ "WinCamp", result.WinCampId },
			{ "ParentUi", this }
		});
	}

	private void OnSelectShipItem()
	{
		EntityInfo info = _controller.MyGroup.Info;
		if (!info.IsDead && info.GvGMode3State != 7)
		{
			_controller.FocusGroupByEntityId(info.EntityId);
		}
	}

	private void OnIslandStop()
	{
		End();
	}

	private void OnPushIslandRank(S2C_GvGMode3IslandRank.Request req)
	{
		UpdateLeaderBoard(req);
	}

	private void UpdateLeaderBoard(S2C_GvGMode3IslandRank.Request req)
	{
		RankList.Clear();
		if (req.InfosNormal != null)
		{
			int count = Mathf.Min(5, req.InfosNormal.Count);
			RankList.AddRange(req.InfosNormal.GetRange(0, count));
			int userId = GameController.Contexts.gameState.user.value.UserId;
			foreach (GvGMode3IslandRankInfo item in req.InfosNormal)
			{
				if (item.UserId == userId)
				{
					_myShipScore = item.Data;
					UpdateMyShipScore();
					break;
				}
			}
		}
		UpdatePlayerRank(RankList);
		UpdateCampRank(req.BrawlCampRank);
	}

	private void OnGetBattleResult(S2C_BroadcastGvGMode3BattleResult.Request req)
	{
		if (req.GvGMode3BattleResults == null)
		{
			return;
		}
		int userId = GameController.Contexts.gameState.user.value.UserId;
		foreach (GvGMode3BattleResult gvGMode3BattleResult in req.GvGMode3BattleResults)
		{
			GvG3Group groupById = _controller.GetGroupById(gvGMode3BattleResult.EntityId);
			if ((Object)(object)groupById == (Object)null)
			{
				continue;
			}
			int campId = groupById.CampId;
			int userId2 = groupById.UserId;
			float num = 0f;
			foreach (ScoreChangeInfo item in gvGMode3BattleResult.ScoreChanged)
			{
				num += item.ChangedScore * item.Par;
			}
			if (userId2 == userId)
			{
				_myShipScore += num;
				UpdateMyShipScore();
			}
			if (_campRank != null)
			{
				bool flag = false;
				foreach (GvGMode3CampRankInfo item2 in _campRank)
				{
					if (item2.CampId == campId)
					{
						item2.RankData += (long)num;
						flag = true;
						break;
					}
				}
				if (flag)
				{
					_campRank.Sort((GvGMode3CampRankInfo a, GvGMode3CampRankInfo b) => -a.RankData.CompareTo(b.RankData));
					for (int num2 = 0; num2 < _campRank.Count; num2++)
					{
						GvGMode3CampRankInfo gvGMode3CampRankInfo = _campRank[num2];
						gvGMode3CampRankInfo.Rank = num2 + 1;
					}
					UpdateCampRank(_campRank);
				}
			}
			if (RankList == null)
			{
				continue;
			}
			bool flag2 = false;
			foreach (GvGMode3IslandRankInfo rank in RankList)
			{
				if (rank.UserId == userId2)
				{
					rank.Data += (long)num;
					flag2 = true;
					break;
				}
			}
			if (flag2)
			{
				RankList.Sort((GvGMode3IslandRankInfo a, GvGMode3IslandRankInfo b) => -a.Data.CompareTo(b.Data));
				UpdatePlayerRank(RankList);
			}
		}
	}

	private void OnCampShipCountChange(CampShipCount campShip)
	{
		SetMyCampShipCount(campShip.Total);
	}

	private void SetMyCampShipCount(int count)
	{
		((GObject)NpcInfo2.SoldierCount1).text = count.ToString();
	}

	private void ShowCampaignContributionAccessTip()
	{
		//IL_001b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0021: Unknown result type (might be due to invalid IL or missing references)
		FairyGUITip.ShowTip<UI_com_CampaignContributionAccess>((GObject)(object)Leaderboard.Help, eFairyGUITipDir.Down, RenderTip);
	}

	private void RenderTip(UI_com_CampaignContributionAccess tip)
	{
		((GObject)tip.Desc).text = "GvGCampaignContributionAccess_BrawlEvent".ToLanguage();
	}

	private void OnPushMyShipAliveState(Gvg3GroupBrawlFight group)
	{
		RenderMyShipItem();
	}

	private void UpdateMyShipMenu()
	{
		RenderMyShipItem();
	}

	private void RenderMyShipItem()
	{
		//IL_015b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0165: Expected O, but got Unknown
		if ((Object)(object)_controller.MyGroup == (Object)null)
		{
			((GObject)MyShipsMenu).visible = false;
			return;
		}
		((GObject)MyShipsMenu).visible = true;
		UI_btn_MyShipBrawlFight slot = MyShipsMenu.myShip;
		EntityInfo entityInfo = _controller.MyGroup.Info;
		((GObject)slot.ShipName).text = Singleton<GvGMode3RoomManager>.Instance.ObserverRecord.GetMyShipName(entityInfo.ShipId);
		UpdateMyShipScore();
		ShipConfigModel byShipRaceType = ShipConfigHelper.GetByShipRaceType(entityInfo.ShipRace);
		slot.ShipSkin.url = ShipConfigHelper.GetSkinById(byShipRaceType.DefaultSkinId).IconUrl;
		if (entityInfo.IsDead)
		{
			slot.State.selectedIndex = 1;
		}
		else if (entityInfo.GvGMode3State == 7)
		{
			slot.State.selectedIndex = 2;
		}
		else
		{
			slot.State.selectedIndex = 0;
		}
		slot.scoreType.SetSelectedIndex(UI_main_BrawlFightEnroll.IsFinalStep(_replayParam.StepIndex) ? 1 : 0);
		((GObject)slot).onClick.Set(new EventCallback0(OnSelectShipItem));
		int num = entityInfo.BattleStrategy;
		if (num < 0)
		{
			num = 0;
		}
		slot.CurStrategyBtn.CampId.SetSelectedIndex(num);
		((GObject)slot.CurStrategyBtn).touchable = false;
		SetSlotVisible();
		void SetSlotVisible()
		{
			bool flag = entityInfo.GvGMode3State == 7 && entityInfo.IsInsuranceShip;
			((GObject)slot).alpha = (flag ? 0f : 1f);
			((GObject)slot).touchable = !flag;
		}
	}

	private void UpdateMyShipScore()
	{
		if ((Object)(object)_controller.MyGroup != (Object)null)
		{
			UI_btn_MyShipBrawlFight myShip = MyShipsMenu.myShip;
			((GObject)myShip.DamageText).text = $"{_myShipScore:N0}";
		}
	}

	public IEnumerator ProccessBestKill(int userId, int killCount, int campId, int shipRace, bool isKilled = false)
	{
		int lastBestKillUser = _curBestKillUser;
		if (_curBestKillUser != userId && _curBestKillUser != -1)
		{
			_curBestKillUser = -1;
			bool isCompleted = false;
			SetBestKillDisappear(isKilled, delegate
			{
				isCompleted = true;
			});
			while (!isCompleted)
			{
				yield return null;
			}
			BestKill.State.selectedIndex = 0;
			yield return (object)new WaitForSeconds(1f);
			((GObject)BestKill.n16).xy = new Vector2(-40f, -124f);
		}
		if (killCount < 5)
		{
			yield break;
		}
		((GObject)BestKill).visible = true;
		bool isCompleted2 = false;
		((GObject)BestKill.n8).alpha = 1f;
		if (lastBestKillUser != userId)
		{
			_curBestKillUser = userId;
			((GObject)BestKill.BestKillNumber.Num).text = $"{killCount}";
			SetBestKillAppear(campId, userId, shipRace, delegate
			{
				isCompleted2 = true;
			});
			while (!isCompleted2)
			{
				yield return null;
			}
		}
		isCompleted2 = false;
		BestKill.State.selectedIndex = 2;
		SetBestKillChangeNum(killCount, delegate
		{
			isCompleted2 = true;
		});
		while (!isCompleted2)
		{
			yield return null;
		}
	}

	public void SetBestKillAppear(int campId, int userId, int shipRace, Action OnComplete = null)
	{
		//IL_0093: Unknown result type (might be due to invalid IL or missing references)
		//IL_009d: Expected O, but got Unknown
		BestKill.Avatar.CampId.selectedIndex = campId;
		((UI_com_ShipSmallIcon)(object)BestKill.ShipSkin).SetShipStyle(shipRace, campId);
		GvG3ProfileHelper.GetUserProfile(new GvG3UserProfileRequestOptions(_cacheId, userId, delegate(UserProfile profile)
		{
			((GObject)BestKill.PlayerName).text = profile.Name;
		}, delegate(Sprite sprite)
		{
			//IL_0021: Unknown result type (might be due to invalid IL or missing references)
			//IL_002b: Expected O, but got Unknown
			BestKill.Avatar.HeadPortrait.icon.texture = new NTexture((Texture)(object)sprite.texture);
		}));
		BestKill.State.selectedIndex = 1;
		BestKill.Appear.Play((PlayCompleteCallback)delegate
		{
			OnComplete?.Invoke();
		});
	}

	public void SetBestKillChangeNum(int num, Action OnComplete = null)
	{
		//IL_005f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0069: Expected O, but got Unknown
		((GObject)BestKill.ChangeVfx).visible = true;
		((GObject)BestKill.BestKillNumber.Num).text = $"{num}";
		BestKill.Change.Play((PlayCompleteCallback)delegate
		{
			OnComplete?.Invoke();
			((GObject)BestKill.ChangeVfx).visible = false;
		});
	}

	public void SetBestKillDisappear(bool isKilled, Action OnComplete = null)
	{
		//IL_008f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0099: Expected O, but got Unknown
		//IL_004a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0054: Expected O, but got Unknown
		if (isKilled)
		{
			((GObject)BestKill.DisappearVfx).visible = true;
			((GObject)BestKill.Disappear2Vfx).visible = false;
			BestKill.DisAppear.Play((PlayCompleteCallback)delegate
			{
				OnComplete?.Invoke();
			});
		}
		else
		{
			((GObject)BestKill.DisappearVfx).visible = false;
			((GObject)BestKill.Disappear2Vfx).visible = true;
			BestKill.DisAppear2.Play((PlayCompleteCallback)delegate
			{
				OnComplete?.Invoke();
			});
		}
		BestKill.State.selectedIndex = 3;
	}

	private void UpdatePlayerRank(List<GvGMode3IslandRankInfo> rankData)
	{
		//IL_0045: Unknown result type (might be due to invalid IL or missing references)
		//IL_004f: Expected O, but got Unknown
		RankList = rankData ?? new List<GvGMode3IslandRankInfo>();
		Leaderboard.isEmpty.SetSelectedIndex((RankList.Count == 0) ? 1 : 0);
		Leaderboard.PlayerRank.itemRenderer = new ListItemRenderer(LeaderboardSlotRenderer);
		Leaderboard.PlayerRank.numItems = RankList.Count;
	}

	private void UpdateCampRank(List<GvGMode3CampRankInfo> campRank)
	{
		if (campRank != null)
		{
			_campRank = campRank;
			Leaderboard.CampRank.numItems = campRank.Count;
		}
	}

	private void RenderCampRank(int index, GObject item)
	{
		GvGMode3CampRankInfo gvGMode3CampRankInfo = _campRank[index];
		UI_btn_CampRankSlot uI_btn_CampRankSlot = (UI_btn_CampRankSlot)(object)item;
		uI_btn_CampRankSlot.CampType.SetSelectedIndex(gvGMode3CampRankInfo.CampId);
		uI_btn_CampRankSlot.ScoreType.SetSelectedIndex(UI_main_BrawlFightEnroll.IsFinalStep(_replayParam.StepIndex) ? 1 : 0);
		((GObject)uI_btn_CampRankSlot.Content).text = gvGMode3CampRankInfo.RankData.ToString();
		((GObject)uI_btn_CampRankSlot.Ranking).text = gvGMode3CampRankInfo.Rank.ToString();
		((GObject)uI_btn_CampRankSlot.PlayerName).text = GetCampName(gvGMode3CampRankInfo.CampId);
		uI_btn_CampRankSlot.TypeController.selectedIndex = ((gvGMode3CampRankInfo.Rank < 4) ? gvGMode3CampRankInfo.Rank : 0);
	}

	private void LeaderboardSlotRenderer(int index, GObject obj)
	{
		GvGMode3IslandRankInfo gvGMode3IslandRankInfo = RankList[index];
		RenderSingleLeaderboardSlot((UI_btn_LeaderboardSlot)(object)obj, index, gvGMode3IslandRankInfo.Data, gvGMode3IslandRankInfo.UserId, gvGMode3IslandRankInfo.CampId);
	}

	private void RenderSingleLeaderboardSlot(UI_btn_LeaderboardSlot slot, int ranking, long rankingData, int userId, int campId)
	{
		ranking++;
		((GObject)slot.Content).text = rankingData.ShortNumberFormat();
		((GObject)slot.Ranking).text = ranking.ToString();
		slot.TypeController.selectedIndex = ((ranking < 4) ? ranking : 0);
		slot.Avatar.CampId.SetSelectedIndex(campId);
		slot.RankingType.selectedIndex = 3;
		slot.ScoreType.SetSelectedIndex(UI_main_BrawlFightEnroll.IsFinalStep(_replayParam.StepIndex) ? 1 : 0);
		slot.Avatar.HeadPortrait.icon.url = GvG3ProfileHelper.DefaultAvatarUrl;
		GvG3ProfileHelper.GetUserProfile(new GvG3UserProfileRequestOptions(_cacheId, userId, delegate(UserProfile profile)
		{
			if (!_isDisposed)
			{
				((GObject)slot.PlayerName).text = profile.Name;
			}
		}, delegate(Sprite sprite)
		{
			//IL_002d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0037: Expected O, but got Unknown
			if (!_isDisposed)
			{
				slot.Avatar.HeadPortrait.icon.texture = new NTexture((Texture)(object)sprite.texture);
			}
		}));
	}

	public void OnShow()
	{
	}

	public void BeforeDestroy()
	{
		_isDisposed = true;
		UnRegisterGvGEvent();
		BeskKillCoroutineQueue.Clear();
		_controller.Release();
	}

	public void OnClickJumpToSecond(int second)
	{
		if (second == 0)
		{
			_forceStop = false;
		}
		_controller.JumpToSecond(second);
		BeskKillCoroutineQueue.Clear();
		((GObject)BestKill).visible = false;
		_curBestKillUser = -1;
		_myShipScore = 0.0;
		EffectHelper.CoroutineDelay(0.1f, delegate
		{
			RenderMyShipItem();
			UpdateMyShipScore();
		});
	}

	public void Destroy()
	{
	}

	public void End()
	{
		GameController.Contexts.Service<IUiService>().HideUis(ShowUi);
		GameController.Contexts.Service<IUiService>().HideUis(HideUi, uiVisible: true);
		UnityUiService.Instance.ClosePanel(Name);
		((MonoBehaviour)FGUIManager.Instance).StartCoroutine(DelayRecover());
	}

	private void ForceClose()
	{
		UnityUiService.Instance.ClosePanel(Name);
		((MonoBehaviour)FGUIManager.Instance).StartCoroutine(DelayRecover());
	}

	private IEnumerator DelayRecover()
	{
		yield return null;
		GvGWorldMapController.Instance.Resume();
	}

	private void RefreshPlaySpeed()
	{
		((GObject)changeSpeed.playSpeedText).text = $"x{_controller.PlaySpeed:N0}";
	}

	public static string GetCampName(int campId)
	{
		return $"GvGMode3CampName{campId}".ToLanguage();
	}

	private string GetTimeString(float time)
	{
		return TimeSpan.FromSeconds(time).ToString(_timeFormat);
	}
}
