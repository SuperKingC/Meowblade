using System;
using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Managers;
using Assets.Scripts.UI;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using FairyGUI;
using FairyGUI.Utils;
using GvG3;
using HotFix.Sources.Base.Scripts.Helper;
using HotFix.Sources.Base.Sources.Scripts.GvG3.GvG3UI.Helper;
using HotFix.Sources.Base.Sources.Scripts.GvG3.GvG3UI.Model.UserProfile;
using HotFix.Sources.Base.Sources.Scripts.GvG3Common.Model;
using HotFix.Sources.Base.Sources.Scripts.GvG3OnIsland.Model;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Helper;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Manager;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Model;
using HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Controller;
using HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Helper;
using HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Manager;
using HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Model;
using HotFix.Sources.Shift.Legion.Shift.Legion.Client.Sources.Extensions;
using Shift.Legion.ClientApi.Protocol;
using Shift.Legion.Common.Helpers;
using Shift.Legion.Common.Managers;
using Shift.Legion.Common.Models;
using Shift.Legion.Common.Services;
using Shift.Legion.GvG.Common.GvGMode3Island;
using Shift.Legion.GvG.Common.Models.GvGMode3;
using Shift.Legion.GvGServer.Models.GvGMode3IslandSocket;
using Shift.Legion.GvGServer.Models.IslandManagerSocket;
using Shift.Legion.Helpers;
using UI.GvGChat;
using UI.GvGIslandBuff;
using UI.GvGLoading;
using UI.MainCity;
using UI.NewbieMission;
using UI.PublicResources;
using UI.Tips;
using UnityEngine;

namespace UI.GvGOnIsland3;

public class UI_main_GvGOnIsland3 : GComponent, IUiController
{
	public class MyShipSoldierCount
	{
		public int Count;

		public int TotalCount;
	}

	private class HoldingPercentTweener
	{
		private Tweener tweener;

		private float LastEndVal;

		private Action<float> OnUpdate;

		public HoldingPercentTweener(float initVal, Action<float> onUpdate)
		{
			LastEndVal = initVal;
			OnUpdate = onUpdate;
			OnUpdate(initVal);
		}

		public void To(float targetVal)
		{
			//IL_0073: Unknown result type (might be due to invalid IL or missing references)
			//IL_007d: Expected O, but got Unknown
			if (tweener != null && TweenExtensions.IsActive((Tween)(object)tweener))
			{
				TweenExtensions.Kill((Tween)(object)tweener, false);
			}
			float val = LastEndVal;
			LastEndVal = targetVal;
			tweener = (Tweener)(object)TweenSettingsExtensions.OnUpdate<TweenerCore<float, float, FloatOptions>>(DOTween.To((DOGetter<float>)(() => val), (DOSetter<float>)delegate(float x)
			{
				val = x;
			}, targetVal, 0.3f), (TweenCallback)delegate
			{
				OnUpdate(val);
			});
		}
	}

	public Controller Mode;

	public Controller RoleMode;

	public GLoader background;

	public GGraph RayMask;

	public GButton BackBtn;

	public GList HoldingPercents;

	public UI_com_BestKill BestKill;

	public UI_com_BossHealthBarBig BossHealthBar;

	public UI_com_NpcInfo NpcInfo;

	public UI_com_Leaderboard Leaderboard;

	public UI_com_MyShipsMenu MyShipsMenu;

	public UI_com_IslandMenu IslandMenu;

	public GImage n91;

	public GTextField n84;

	public GTextField n85;

	public GTextField n86;

	public GGroup n89;

	public GImage n92;

	public GTextField n87;

	public GGroup n90;

	public Transition TimeCounter1Scale;

	public Transition TipsWrapper;

	public const string URL = "ui://ebc4ciwrl44l0";

	public static string Name = "UI_main_GvGOnIsland3";

	private CoroutineQueue BeskKillCoroutineQueue;

	private int CurBestKillUser = -1;

	private bool IsNewBestKillUserAppeared = false;

	private List<EntityInfo> MyShips_List;

	private string CacheId;

	private object IslandId;

	private int CurShipStrategySelectingIndex = -1;

	private int MyCampId = -1;

	private List<int> MyStrategies;

	private long BossMaxHp = 0L;

	private Soldier BossSoldier = null;

	private Dictionary<int, HoldingPercentTweener> HoldingPercentTweener_Dict;

	public List<GvGMode3IslandRankInfo> RankList;

	public List<GvGMode3IslandRankInfo> ExtraRankList;

	private bool _hasBoss;

	private bool _hasRandomEvent;

	private eIslandEvent _randomEventType;

	private bool _curRankingListIsExtra;

	private bool _rankingListDataLoaded;

	private Dictionary<int, MyShipSoldierCount> _myShipSoldierCountDict;

	private bool _isHoldingWithoutInterruption;

	private UICallbackParam<Action> _onCloseBySuccessCallback;

	private float _pinchDelta;

	private bool HasExtraRanking => _hasRandomEvent || _hasBoss;

	public static string GetURL()
	{
		return "ui://ebc4ciwrl44l0";
	}

	public static UI_main_GvGOnIsland3 CreateInstance()
	{
		return (UI_main_GvGOnIsland3)(object)UIPackage.CreateObject("GvGOnIsland3", "main_GvGOnIsland3");
	}

	public static UI_main_GvGOnIsland3 CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_main_GvGOnIsland3).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://ebc4ciwrl44l0", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_0079: Unknown result type (might be due to invalid IL or missing references)
		//IL_0083: Expected O, but got Unknown
		//IL_0113: Unknown result type (might be due to invalid IL or missing references)
		//IL_011d: Expected O, but got Unknown
		//IL_0129: Unknown result type (might be due to invalid IL or missing references)
		//IL_0133: Expected O, but got Unknown
		//IL_017c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0186: Expected O, but got Unknown
		//IL_01cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d9: Expected O, but got Unknown
		//IL_0222: Unknown result type (might be due to invalid IL or missing references)
		//IL_022c: Expected O, but got Unknown
		//IL_0238: Unknown result type (might be due to invalid IL or missing references)
		//IL_0242: Expected O, but got Unknown
		//IL_024e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0258: Expected O, but got Unknown
		//IL_02a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ab: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Mode = ((GComponent)this).GetController("Mode");
		RoleMode = ((GComponent)this).GetController("RoleMode");
		background = (GLoader)((GComponent)this).GetChild("background");
		RayMask = (GGraph)((GComponent)this).GetChild("RayMask");
		BackBtn = (GButton)((GComponent)this).GetChild("BackBtn");
		HoldingPercents = (GList)((GComponent)this).GetChild("HoldingPercents");
		BestKill = (UI_com_BestKill)(object)((GComponent)this).GetChild("BestKill");
		BossHealthBar = (UI_com_BossHealthBarBig)(object)((GComponent)this).GetChild("BossHealthBar");
		NpcInfo = (UI_com_NpcInfo)(object)((GComponent)this).GetChild("NpcInfo");
		Leaderboard = (UI_com_Leaderboard)(object)((GComponent)this).GetChild("Leaderboard");
		MyShipsMenu = (UI_com_MyShipsMenu)(object)((GComponent)this).GetChild("MyShipsMenu");
		IslandMenu = (UI_com_IslandMenu)(object)((GComponent)this).GetChild("IslandMenu");
		n91 = (GImage)((GComponent)this).GetChild("n91");
		n84 = (GTextField)((GComponent)this).GetChild("n84");
		string id = "ui://ebc4ciwrl44l0".Replace("ui://", "") + "-" + ((GObject)n84).id;
		((GObject)n84).text = LanguagesManager.GetDesc(id);
		n85 = (GTextField)((GComponent)this).GetChild("n85");
		string id2 = "ui://ebc4ciwrl44l0".Replace("ui://", "") + "-" + ((GObject)n85).id;
		((GObject)n85).text = LanguagesManager.GetDesc(id2);
		n86 = (GTextField)((GComponent)this).GetChild("n86");
		string id3 = "ui://ebc4ciwrl44l0".Replace("ui://", "") + "-" + ((GObject)n86).id;
		((GObject)n86).text = LanguagesManager.GetDesc(id3);
		n89 = (GGroup)((GComponent)this).GetChild("n89");
		n92 = (GImage)((GComponent)this).GetChild("n92");
		n87 = (GTextField)((GComponent)this).GetChild("n87");
		string id4 = "ui://ebc4ciwrl44l0".Replace("ui://", "") + "-" + ((GObject)n87).id;
		((GObject)n87).text = LanguagesManager.GetDesc(id4);
		n90 = (GGroup)((GComponent)this).GetChild("n90");
		TimeCounter1Scale = ((GComponent)this).GetTransition("TimeCounter1Scale");
		TipsWrapper = ((GComponent)this).GetTransition("TipsWrapper");
	}

	private List<GvGMode3IslandRankInfo> GetCurRankingList()
	{
		if (!HasExtraRanking)
		{
			return RankList;
		}
		return _curRankingListIsExtra ? ExtraRankList : RankList;
	}

	public void Init(Dictionary<string, object> parameters)
	{
		//IL_0162: Unknown result type (might be due to invalid IL or missing references)
		//IL_016c: Expected O, but got Unknown
		FGUIManager.SetUiPanelSizeAndXy((GObject)(object)this);
		object value;
		int pid = (parameters.TryGetValue("PId", out value) ? ((int)value) : 0);
		object value2;
		int port = (parameters.TryGetValue("Port", out value2) ? ((int)value2) : 0);
		if (!parameters.TryGetValue("IslandId", out var islandId))
		{
			End();
			return;
		}
		if (!parameters.ContainsKey("IsOpenedByRecovery"))
		{
			GameController.Contexts.Service<IUiService>().PushBackupAndHideAllUIs(new List<string>
			{
				Name,
				UI_main_GvG3Chat.Name,
				UI_NewbieMissionPanel.Name
			});
			GvGWorldMapController.Instance.Pause();
		}
		CacheId = $"{Singleton<GvGMode3RoomManager>.Instance.ObserverRecord.CurIZId}";
		IslandId = islandId;
		CurShipStrategySelectingIndex = -1;
		BeskKillCoroutineQueue = new CoroutineQueue((MonoBehaviour)(object)FGUIManager.Instance);
		MyShips_List = new List<EntityInfo>();
		_myShipSoldierCountDict = new Dictionary<int, MyShipSoldierCount>();
		RankList = new List<GvGMode3IslandRankInfo>();
		ExtraRankList = new List<GvGMode3IslandRankInfo>();
		HoldingPercentTweener_Dict = new Dictionary<int, HoldingPercentTweener>();
		MyShipsMenu.List.itemRenderer = (ListItemRenderer)delegate(int i, GObject o)
		{
			RenderMyShipItem(i, (UI_btn_MyShipSlot)(object)o);
		};
		Singleton<GvGMode3RoomManager>.Instance.TryConnectToRoom(delegate
		{
			GvG3IslandController.CreateInstance((int)islandId);
			RegisterGvGEvent();
			if (pid > 0 && port > 0)
			{
				GvG3IslandController.Instance.ConnectToIsland(pid, port);
			}
			MyCampId = Singleton<GvGMode3RoomManager>.Instance.ObserverRecord.ObCampId;
			MyStrategies = new List<int>();
			for (int i = 0; i < WorldMapConfigHelper.Configs.CampIds.Count + 1; i++)
			{
				if (i != MyCampId)
				{
					MyStrategies.Add(i);
				}
			}
		});
	}

	public void RegisterGvGEvent()
	{
		GvG3IslandController instance = GvG3IslandController.Instance;
		instance.OnGetInitIslandInfo = (Action<C2S_GetGvGMode3Island_IslandInfo.Response>)Delegate.Combine(instance.OnGetInitIslandInfo, new Action<C2S_GetGvGMode3Island_IslandInfo.Response>(OnGetInitIslandInfo));
		GvG3IslandController instance2 = GvG3IslandController.Instance;
		instance2.OnChangeCampShipCount = (Action<CampShipCount>)Delegate.Combine(instance2.OnChangeCampShipCount, new Action<CampShipCount>(OnChangeCampShipCount));
		GvG3IslandController instance3 = GvG3IslandController.Instance;
		instance3.OnGetBattleResult = (Action<S2C_BroadcastGvGMode3BattleResult.Request>)Delegate.Combine(instance3.OnGetBattleResult, new Action<S2C_BroadcastGvGMode3BattleResult.Request>(OnGetBattleResult));
		GvG3IslandController instance4 = GvG3IslandController.Instance;
		instance4.OnCreateMyShips = (Action<EntityInfo>)Delegate.Combine(instance4.OnCreateMyShips, new Action<EntityInfo>(OnCreateMyShips));
		GvG3IslandController instance5 = GvG3IslandController.Instance;
		instance5.OnChangeBestKill = (Action<S2C_ChangeGvGMode3BestKill.Request>)Delegate.Combine(instance5.OnChangeBestKill, new Action<S2C_ChangeGvGMode3BestKill.Request>(OnChangeBestKill));
		GvG3IslandController instance6 = GvG3IslandController.Instance;
		instance6.OnChangeMyShipKillSoldiersCount = (Action<S2C_GvGMode3ShipKillSoldiersCount.Request>)Delegate.Combine(instance6.OnChangeMyShipKillSoldiersCount, new Action<S2C_GvGMode3ShipKillSoldiersCount.Request>(OnChangeMyShipKillSoldiersCount));
		GvG3IslandController instance7 = GvG3IslandController.Instance;
		instance7.OnChangeMyShipBossDamage = (Action<S2C_GvGMode3ShipBossDamageRank.Request>)Delegate.Combine(instance7.OnChangeMyShipBossDamage, new Action<S2C_GvGMode3ShipBossDamageRank.Request>(OnChangeMyShipBossDamage));
		GvG3IslandController instance8 = GvG3IslandController.Instance;
		instance8.OnChangeHoldingPercentOnIsland = (Action<string>)Delegate.Combine(instance8.OnChangeHoldingPercentOnIsland, new Action<string>(OnChangeHoldingPercentOnIsland));
		GvG3IslandController instance9 = GvG3IslandController.Instance;
		instance9.OnChangeHoldingCamp = (Action<int>)Delegate.Combine(instance9.OnChangeHoldingCamp, new Action<int>(OnChangeHoldingCamp));
		GvG3IslandController instance10 = GvG3IslandController.Instance;
		instance10.OnChangeZoomLevel = (Action<GvG3IslandController.eZoomLevel>)Delegate.Combine(instance10.OnChangeZoomLevel, new Action<GvG3IslandController.eZoomLevel>(OnChangeZoomLevel));
		GvG3IslandController instance11 = GvG3IslandController.Instance;
		instance11.OnIslandStop = (Action)Delegate.Combine(instance11.OnIslandStop, new Action(OnIslandStop));
		GvG3IslandController instance12 = GvG3IslandController.Instance;
		instance12.OnRemoveMyGroups = (Action<int>)Delegate.Combine(instance12.OnRemoveMyGroups, new Action<int>(OnRemoveMyShips));
		GvG3IslandController instance13 = GvG3IslandController.Instance;
		instance13.OnChangeShipCanRetreatTimestamp = (Action<S2C_ShipCanRetreatTimestamp.Request>)Delegate.Combine(instance13.OnChangeShipCanRetreatTimestamp, new Action<S2C_ShipCanRetreatTimestamp.Request>(OnChangeShipCanRetreatTimestamp));
		GvG3IslandController instance14 = GvG3IslandController.Instance;
		instance14.OnInsuranceShipJoinFighting = (Action<S2C_GvGStateChange.Request>)Delegate.Combine(instance14.OnInsuranceShipJoinFighting, new Action<S2C_GvGStateChange.Request>(OnInsuranceShipJoinFighting));
		GvGMapInputManager inputManager = GvG3IslandController.Instance.InputManager;
		inputManager.OnPinchStart = (Action)Delegate.Combine(inputManager.OnPinchStart, new Action(OnPinchBegin));
		GvGMapInputManager inputManager2 = GvG3IslandController.Instance.InputManager;
		inputManager2.OnPinch = (Action<float>)Delegate.Combine(inputManager2.OnPinch, new Action<float>(OnPinch));
		GvGMapInputManager inputManager3 = GvG3IslandController.Instance.InputManager;
		inputManager3.OnPinchEnd = (Action)Delegate.Combine(inputManager3.OnPinchEnd, new Action(OnPinchEnd));
		GvGMode3RoomManager instance15 = Singleton<GvGMode3RoomManager>.Instance;
		instance15.OnRoomClose = (Action)Delegate.Combine(instance15.OnRoomClose, new Action(EndByForceStop));
		S2C_GvGMode3IslandRank.OnPushEvent = (Action<S2C_GvGMode3IslandRank.Request>)Delegate.Combine(S2C_GvGMode3IslandRank.OnPushEvent, new Action<S2C_GvGMode3IslandRank.Request>(OnPushIslandRank));
	}

	public void UnRegisterGvGEvent()
	{
		GvG3IslandController instance = GvG3IslandController.Instance;
		instance.OnGetInitIslandInfo = (Action<C2S_GetGvGMode3Island_IslandInfo.Response>)Delegate.Remove(instance.OnGetInitIslandInfo, new Action<C2S_GetGvGMode3Island_IslandInfo.Response>(OnGetInitIslandInfo));
		GvG3IslandController instance2 = GvG3IslandController.Instance;
		instance2.OnChangeCampShipCount = (Action<CampShipCount>)Delegate.Remove(instance2.OnChangeCampShipCount, new Action<CampShipCount>(OnChangeCampShipCount));
		GvG3IslandController instance3 = GvG3IslandController.Instance;
		instance3.OnGetBattleResult = (Action<S2C_BroadcastGvGMode3BattleResult.Request>)Delegate.Remove(instance3.OnGetBattleResult, new Action<S2C_BroadcastGvGMode3BattleResult.Request>(OnGetBattleResult));
		GvG3IslandController instance4 = GvG3IslandController.Instance;
		instance4.OnCreateMyShips = (Action<EntityInfo>)Delegate.Remove(instance4.OnCreateMyShips, new Action<EntityInfo>(OnCreateMyShips));
		GvG3IslandController instance5 = GvG3IslandController.Instance;
		instance5.OnChangeBestKill = (Action<S2C_ChangeGvGMode3BestKill.Request>)Delegate.Remove(instance5.OnChangeBestKill, new Action<S2C_ChangeGvGMode3BestKill.Request>(OnChangeBestKill));
		GvG3IslandController instance6 = GvG3IslandController.Instance;
		instance6.OnChangeMyShipKillSoldiersCount = (Action<S2C_GvGMode3ShipKillSoldiersCount.Request>)Delegate.Remove(instance6.OnChangeMyShipKillSoldiersCount, new Action<S2C_GvGMode3ShipKillSoldiersCount.Request>(OnChangeMyShipKillSoldiersCount));
		GvG3IslandController instance7 = GvG3IslandController.Instance;
		instance7.OnChangeMyShipBossDamage = (Action<S2C_GvGMode3ShipBossDamageRank.Request>)Delegate.Remove(instance7.OnChangeMyShipBossDamage, new Action<S2C_GvGMode3ShipBossDamageRank.Request>(OnChangeMyShipBossDamage));
		GvG3IslandController instance8 = GvG3IslandController.Instance;
		instance8.OnChangeHoldingPercentOnIsland = (Action<string>)Delegate.Remove(instance8.OnChangeHoldingPercentOnIsland, new Action<string>(OnChangeHoldingPercentOnIsland));
		GvG3IslandController instance9 = GvG3IslandController.Instance;
		instance9.OnChangeHoldingCamp = (Action<int>)Delegate.Remove(instance9.OnChangeHoldingCamp, new Action<int>(OnChangeHoldingCamp));
		GvG3IslandController instance10 = GvG3IslandController.Instance;
		instance10.OnChangeZoomLevel = (Action<GvG3IslandController.eZoomLevel>)Delegate.Remove(instance10.OnChangeZoomLevel, new Action<GvG3IslandController.eZoomLevel>(OnChangeZoomLevel));
		GvG3IslandController instance11 = GvG3IslandController.Instance;
		instance11.OnIslandStop = (Action)Delegate.Remove(instance11.OnIslandStop, new Action(OnIslandStop));
		GvG3IslandController instance12 = GvG3IslandController.Instance;
		instance12.OnRemoveMyGroups = (Action<int>)Delegate.Remove(instance12.OnRemoveMyGroups, new Action<int>(OnRemoveMyShips));
		GvG3IslandController instance13 = GvG3IslandController.Instance;
		instance13.OnChangeShipCanRetreatTimestamp = (Action<S2C_ShipCanRetreatTimestamp.Request>)Delegate.Remove(instance13.OnChangeShipCanRetreatTimestamp, new Action<S2C_ShipCanRetreatTimestamp.Request>(OnChangeShipCanRetreatTimestamp));
		GvG3IslandController instance14 = GvG3IslandController.Instance;
		instance14.OnInsuranceShipJoinFighting = (Action<S2C_GvGStateChange.Request>)Delegate.Remove(instance14.OnInsuranceShipJoinFighting, new Action<S2C_GvGStateChange.Request>(OnInsuranceShipJoinFighting));
		GvGMapInputManager inputManager = GvG3IslandController.Instance.InputManager;
		inputManager.OnPinchStart = (Action)Delegate.Remove(inputManager.OnPinchStart, new Action(OnPinchBegin));
		GvGMapInputManager inputManager2 = GvG3IslandController.Instance.InputManager;
		inputManager2.OnPinch = (Action<float>)Delegate.Remove(inputManager2.OnPinch, new Action<float>(OnPinch));
		GvGMapInputManager inputManager3 = GvG3IslandController.Instance.InputManager;
		inputManager3.OnPinchEnd = (Action)Delegate.Remove(inputManager3.OnPinchEnd, new Action(OnPinchEnd));
		GvGMode3RoomManager instance15 = Singleton<GvGMode3RoomManager>.Instance;
		instance15.OnRoomClose = (Action)Delegate.Remove(instance15.OnRoomClose, new Action(EndByForceStop));
		S2C_GvGMode3IslandRank.OnPushEvent = (Action<S2C_GvGMode3IslandRank.Request>)Delegate.Remove(S2C_GvGMode3IslandRank.OnPushEvent, new Action<S2C_GvGMode3IslandRank.Request>(OnPushIslandRank));
	}

	public void RegisterUiEventListeners()
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected O, but got Unknown
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_003a: Expected O, but got Unknown
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		//IL_005c: Expected O, but got Unknown
		//IL_006f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0079: Expected O, but got Unknown
		//IL_008c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0096: Expected O, but got Unknown
		//IL_00a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b3: Expected O, but got Unknown
		//IL_00cb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d5: Expected O, but got Unknown
		//IL_00ed: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f7: Expected O, but got Unknown
		//IL_010f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0119: Expected O, but got Unknown
		//IL_0131: Unknown result type (might be due to invalid IL or missing references)
		//IL_013b: Expected O, but got Unknown
		((GObject)BackBtn).onClick.Add(new EventCallback0(End));
		((GObject)RayMask).onClick.Add(new EventCallback0(OnClickEmpty));
		MyShipsMenu.DisplayMode.onChanged.Set(new EventCallback1(OnChangeDisplayMode));
		((GObject)RayMask).onTouchBegin.Add(new EventCallback1(OnDragBegin));
		((GObject)RayMask).onTouchMove.Add(new EventCallback1(OnDrag));
		((GObject)RayMask).onTouchEnd.Add(new EventCallback1(OnDragEnd));
		((GObject)IslandMenu.Zoom).onClick.Add(new EventCallback0(OnClickZoomBtn));
		((GObject)IslandMenu.CheckIslandBuff).onClick.Add(new EventCallback0(OnCheckIslandBuff));
		((GObject)Leaderboard.Switch).onClick.Set(new EventCallback0(ChangeCurRankingList));
		((GObject)Leaderboard.Help).onClick.Set(new EventCallback0(ShowCampaignContributionAccessTip));
		SharedMessenger.AddListener<UICallbackParam<Action>>("ON_ClOSE_UI_main_GvGOnIsland3", OnCloseByEvent);
	}

	public void UnregisterUiEventListeners()
	{
		((GObject)BackBtn).onClick.Clear();
		((GObject)RayMask).onClick.Clear();
		MyShipsMenu.DisplayMode.onChanged.Clear();
		((GObject)RayMask).onTouchBegin.Clear();
		((GObject)RayMask).onTouchMove.Clear();
		((GObject)RayMask).onTouchEnd.Clear();
		((GObject)IslandMenu.Zoom).onClick.Clear();
		((GObject)IslandMenu.CheckIslandBuff).onClick.Clear();
		((GObject)Leaderboard.Switch).onClick.Clear();
		((GObject)Leaderboard.Help).onClick.Clear();
		SharedMessenger.RemoveListener<UICallbackParam<Action>>("ON_ClOSE_UI_main_GvGOnIsland3", OnCloseByEvent);
	}

	private void OnCheckIslandBuff()
	{
		GameController.Contexts.Service<IUiService>().OpenPanel(UI_main_IslandBuffPanel.Name, new Dictionary<string, object>
		{
			{ "CurIslandId", IslandId },
			{ "ParentUIName", Name }
		});
	}

	private void OnGetInitIslandInfo(C2S_GetGvGMode3Island_IslandInfo.Response res)
	{
		UpdateIslandInfoDisplay(res);
		UpdateBooleanValues(res);
		UpdateRankingDisplay(res);
		UpdateTopPanelInfo(res.BossHp, res.NPCSoldierCount);
	}

	private void UpdateIslandInfoDisplay(C2S_GetGvGMode3Island_IslandInfo.Response res)
	{
		int islandOriginalCamp = res.IslandOriginalCamp;
		RoleMode.selectedIndex = ((islandOriginalCamp != MyCampId) ? 1 : 2);
		((GObject)IslandMenu.IslandName).text = WorldMapConfigHelper.Configs.TryGetIsland(res.IslandId)?.Name;
	}

	private void UpdateBooleanValues(C2S_GetGvGMode3Island_IslandInfo.Response res)
	{
		_hasBoss = !string.IsNullOrEmpty(res.BossSoldierId);
		_hasRandomEvent = !string.IsNullOrEmpty(res.HasREEvent);
		if (_hasRandomEvent)
		{
			IslandStateModel islandStateModel = Singleton<WorldStateManager>.Instance.TryGetIsland((int)IslandId);
			IIslandEvent islandEvent = islandStateModel.IslandEvents.Find((IIslandEvent xx) => xx.EventType.IsBattleRandomEvent());
			_randomEventType = islandEvent.EventType;
		}
		else
		{
			_randomEventType = eIslandEvent.NotInit;
		}
		_curRankingListIsExtra = HasExtraRanking;
		_rankingListDataLoaded = true;
		DisplayBossInfo(res);
	}

	private void DisplayBossInfo(C2S_GetGvGMode3Island_IslandInfo.Response res)
	{
		if (_hasBoss)
		{
			BossMaxHp = res.BossMaxHp;
			BossSoldier = GameManagers.Instance.SoldierManager.Get(res.BossSoldierId);
			((GObject)BossHealthBar.BossName).text = BossSoldier.Name;
			((GProgressBar)BossHealthBar.HealthBar).max = BossMaxHp;
			BossHealthBar.BossIcon.Icon.url = BossSoldier.GetGvG3SoldierIconUrl();
		}
	}

	private void UpdateRankingDisplay(C2S_GetGvGMode3Island_IslandInfo.Response res)
	{
		Leaderboard.HasExtraRanking.SetSelectedIndex(HasExtraRanking ? 1 : 0);
		List<GvGMode3IslandRankInfo> extraRanking = GetExtraRanking(res);
		UpdateLeaderboard(res.NormalRankData, extraRanking);
	}

	private List<GvGMode3IslandRankInfo> GetExtraRanking(C2S_GetGvGMode3Island_IslandInfo.Response res)
	{
		if (_hasRandomEvent)
		{
			return res.RERankData;
		}
		return string.IsNullOrEmpty(res.BossSoldierId) ? null : res.BossDamageRankData;
	}

	private void OnChangeCampShipCount(CampShipCount campShipCount)
	{
		for (int i = 0; i < HoldingPercents.numItems; i++)
		{
			UI_com_HoldingPercent uI_com_HoldingPercent = (UI_com_HoldingPercent)(object)((GComponent)HoldingPercents).GetChildAt(i);
			int selectedIndex = uI_com_HoldingPercent.CampId.selectedIndex;
			if (selectedIndex == campShipCount.CampId)
			{
				((GObject)uI_com_HoldingPercent.ShipCount).text = $"{campShipCount.ShipCount}";
				break;
			}
		}
	}

	private void OnCreateMyShips(EntityInfo info)
	{
		int num = MyShips_List.FindIndex((EntityInfo ship) => ship.EntityId == info.EntityId);
		MyShipSoldierCount myShipSoldierCount = new MyShipSoldierCount
		{
			Count = 0,
			TotalCount = 0
		};
		foreach (UnitInfo_Protocol item in info.UnitsInfo)
		{
			myShipSoldierCount.Count += item.Total;
			myShipSoldierCount.TotalCount += item.InitTotal;
		}
		if (num == -1)
		{
			MyShips_List.Add(info);
			_myShipSoldierCountDict.Add(info.EntityId, myShipSoldierCount);
		}
		else
		{
			MyShips_List[num] = info;
			_myShipSoldierCountDict[info.EntityId] = myShipSoldierCount;
		}
		UpdateMyShipMenu();
		CheckForTimerUpdate();
	}

	private void OnChangeMyShipKillSoldiersCount(S2C_GvGMode3ShipKillSoldiersCount.Request req)
	{
		EntityInfo entityInfo = MyShips_List.Find((EntityInfo ship) => ship.EntityId == req.EntityId);
		if (entityInfo != null)
		{
			entityInfo.KillSoldiersCount = req.KillCount;
		}
		UpdateMyShipMenu();
	}

	private void OnChangeMyShipBossDamage(S2C_GvGMode3ShipBossDamageRank.Request req)
	{
		EntityInfo entityInfo = MyShips_List.Find((EntityInfo ship) => ship.EntityId == req.EntityId);
		if (entityInfo != null)
		{
			entityInfo.BossDamage = req.Damage;
		}
		UpdateMyShipMenu();
	}

	private void OnRemoveMyShips(int entityId)
	{
		EntityInfo entityInfo = MyShips_List.Find((EntityInfo ship) => ship.EntityId == entityId);
		if (entityInfo != null)
		{
			entityInfo.IsDead = true;
		}
		UpdateMyShipMenu();
	}

	private void OnChangeShipCanRetreatTimestamp(S2C_ShipCanRetreatTimestamp.Request req)
	{
		EntityInfo entityInfo = MyShips_List.Find((EntityInfo ship) => ship.EntityId == req.EntityId);
		if (entityInfo != null)
		{
			entityInfo.CanRetreatTimestamp = req.Timestamp;
		}
		UpdateMyShipMenu();
		CheckForTimerUpdate();
	}

	private void OnInsuranceShipJoinFighting(S2C_GvGStateChange.Request req)
	{
		UpdateMyShipMenu();
	}

	private void OnChangeDisplayMode(EventContext context)
	{
		UpdateMyShipMenu();
	}

	private void ChangeCurRankingList()
	{
		//IL_0031: Unknown result type (might be due to invalid IL or missing references)
		//IL_003b: Expected O, but got Unknown
		if (HasExtraRanking)
		{
			_curRankingListIsExtra = !_curRankingListIsExtra;
			Leaderboard.List.itemRenderer = new ListItemRenderer(LeaderboardSlotRenderer);
			Leaderboard.List.numItems = GetCurRankingList().Count;
			SetLeaderboardType();
		}
	}

	private void OnClickZoomBtn()
	{
		if (GvG3IslandController.IsInstanceCreated)
		{
			GvG3IslandController.Instance.SwitchZooming();
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
			GvG3IslandController.Instance.InputManager.UpdateInput();
		}
		context.CaptureTouch();
	}

	public void OnDrag(EventContext context)
	{
		if (GvG3IslandController.IsInstanceCreated)
		{
			GvG3IslandController.Instance.InputManager.UpdateInput();
		}
	}

	public void OnDragEnd(EventContext context)
	{
		if (GvG3IslandController.IsInstanceCreated)
		{
			GvG3IslandController.Instance.InputManager.UpdateInput();
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
			GvG3IslandController.Instance.SwitchZooming(level);
		}
	}

	public void OnChangeHoldingPercentOnIsland(string json)
	{
		Dictionary<int, int> dictionary = JsonHelper.ToObject<Dictionary<int, int>>(json);
		if (dictionary == null)
		{
			return;
		}
		for (int i = 0; i < HoldingPercents.numItems; i++)
		{
			UI_com_HoldingPercent slot = (UI_com_HoldingPercent)(object)((GComponent)HoldingPercents).GetChildAt(i);
			int selectedIndex = slot.CampId.selectedIndex;
			if (!dictionary.TryGetValue(selectedIndex, out var value))
			{
				value = 0;
			}
			float num = (float)value / 10f;
			if (!HoldingPercentTweener_Dict.ContainsKey(selectedIndex))
			{
				HoldingPercentTweener_Dict.Add(selectedIndex, new HoldingPercentTweener(num, delegate(float val)
				{
					if (!((GObject)slot).isDisposed)
					{
						((GObject)slot.HoldingPercent).text = $"{val:F1}%";
					}
				}));
			}
			else
			{
				HoldingPercentTweener_Dict[selectedIndex].To(num);
			}
		}
	}

	public void OnChangeHoldingCamp(int holdingCamp)
	{
		GList holdingPercents = HoldingPercents;
		_isHoldingWithoutInterruption = holdingCamp == MyCampId;
		for (int i = 0; i < holdingPercents.numItems; i++)
		{
			UI_com_HoldingPercent uI_com_HoldingPercent = (UI_com_HoldingPercent)(object)((GComponent)holdingPercents).GetChildAt(i);
			int selectedIndex = uI_com_HoldingPercent.CampId.selectedIndex;
			if (selectedIndex == holdingCamp)
			{
				uI_com_HoldingPercent.State.selectedIndex = 1;
			}
			else
			{
				uI_com_HoldingPercent.State.selectedIndex = 0;
			}
		}
		UpdateMyShipMenu();
		CheckForTimerUpdate();
	}

	private void OnChangeBestKill(S2C_ChangeGvGMode3BestKill.Request req)
	{
		GvGMode3BestKill bestKill = req.BestKill;
		BeskKillCoroutineQueue.AddCoroutine(ProccessBestKill(bestKill.UserId, bestKill.KillCount, bestKill.CampId, bestKill.ShipRace, bestKill.IsLastBestKillIsKilled));
	}

	private void OnOpenStrategyPanel(EventContext context, int index)
	{
		context.StopPropagation();
		CurShipStrategySelectingIndex = ((CurShipStrategySelectingIndex == index) ? (-1) : index);
		UpdateMyShipMenu();
	}

	private void OnGetBattleResult(S2C_BroadcastGvGMode3BattleResult.Request req)
	{
		UpdateTopPanelInfo(req.BossHp, req.NPCSoldierCount);
		UpdateMyShipSoldierCount(req.GvGMode3BattleResults);
	}

	private void UpdateMyShipSoldierCount(List<GvGMode3BattleResult> battleResults)
	{
		bool flag = false;
		foreach (GvGMode3BattleResult battleResult in battleResults)
		{
			if (_myShipSoldierCountDict.TryGetValue(battleResult.EntityId, out var value))
			{
				value.Count = battleResult.SoldierRemaining;
				flag = true;
			}
		}
		if (flag)
		{
			UpdateMyShipMenu();
		}
	}

	private void OnClickStrategyMenu(EventContext context)
	{
		context.StopPropagation();
	}

	private void OnSelectShipItem(int index)
	{
		EntityInfo entityInfo = MyShips_List[index];
		if (!entityInfo.IsDead && entityInfo.GvGMode3State != 7)
		{
			MyShipsMenu.List.selectedIndex = index;
			GvG3IslandController.Instance.FocusGroupByEntityId(entityInfo.EntityId);
		}
	}

	private void OnClickEmpty()
	{
		CurShipStrategySelectingIndex = -1;
		UpdateMyShipMenu();
	}

	private void OnIslandStop()
	{
		End();
	}

	private void OnPushIslandRank(S2C_GvGMode3IslandRank.Request req)
	{
		if (_rankingListDataLoaded)
		{
			UpdateRankingDisplay(req);
		}
	}

	private void UpdateRankingDisplay(S2C_GvGMode3IslandRank.Request req)
	{
		List<GvGMode3IslandRankInfo> extraRanking = GetExtraRanking(req);
		UpdateLeaderboard(req.InfosNormal, extraRanking);
	}

	private List<GvGMode3IslandRankInfo> GetExtraRanking(S2C_GvGMode3IslandRank.Request req)
	{
		if (_hasRandomEvent)
		{
			return req.InfosRE;
		}
		return req.InfosBossDamage;
	}

	private void OnClickRetreatBtn(int entityId, UI_btn_Retreat retreatBtn)
	{
		OpenTipPanel("GvGOnIsland3RetreatTips".ToLanguage(), delegate
		{
			GvG3IslandController.Instance.RetreatShip(entityId, delegate
			{
				((GObject)retreatBtn).enabled = false;
			});
		}, (AlignType)1);
	}

	private void ShowCampaignContributionAccessTip()
	{
		//IL_001b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0021: Unknown result type (might be due to invalid IL or missing references)
		FairyGUITip.ShowTip<UI_com_CampaignContributionAccess>((GObject)(object)Leaderboard.Help, eFairyGUITipDir.Down, RenderTip);
	}

	private void RenderTip(UI_com_CampaignContributionAccess tip)
	{
		if (_curRankingListIsExtra)
		{
			if (_randomEventType == eIslandEvent.RandomEvent_NPCEvent)
			{
				((GObject)tip.Desc).text = "GvGCampaignContributionAccess_RE_NPCEvent".ToLanguage();
				return;
			}
			if (_randomEventType == eIslandEvent.RandomEvent_BossEvent)
			{
				((GObject)tip.Desc).text = "GvGCampaignContributionAccess_RE_BossEvent".ToLanguage();
				return;
			}
		}
		((GObject)tip.Desc).text = "GvGCampaignContributionAccess".ToLanguage();
	}

	private void CheckForTimerUpdate()
	{
		//IL_008a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0094: Expected O, but got Unknown
		//IL_004c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0056: Expected O, but got Unknown
		//IL_00a4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ae: Expected O, but got Unknown
		//IL_006f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0079: Expected O, but got Unknown
		if (_isHoldingWithoutInterruption && MyShips_List.Find((EntityInfo ship) => !ship.IsDead && ship.CanRetreatTimestamp > 0) != null)
		{
			if (!Timers.inst.Exists(new TimerCallback(UpdateMyShipMenu)))
			{
				Timers.inst.Add(1f, 0, new TimerCallback(UpdateMyShipMenu));
			}
		}
		else if (Timers.inst.Exists(new TimerCallback(UpdateMyShipMenu)))
		{
			Timers.inst.Remove(new TimerCallback(UpdateMyShipMenu));
		}
	}

	private void UpdateMyShipMenu(object param = null)
	{
		MyShipsMenu.List.numItems = MyShips_List.Count;
		((GComponent)MyShipsMenu.List).EnsureBoundsCorrect();
	}

	private void RenderMyShipItem(int index, UI_btn_MyShipSlot slot)
	{
		//IL_0214: Unknown result type (might be due to invalid IL or missing references)
		//IL_021e: Expected O, but got Unknown
		//IL_02be: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c8: Expected O, but got Unknown
		//IL_030f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0319: Expected O, but got Unknown
		//IL_0350: Unknown result type (might be due to invalid IL or missing references)
		//IL_035a: Expected O, but got Unknown
		//IL_03b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_03c3: Expected O, but got Unknown
		EntityInfo entityInfo = MyShips_List[index];
		MyShipSoldierCount myShipSoldierCount = _myShipSoldierCountDict[entityInfo.EntityId];
		((GObject)slot.ShipName).text = (entityInfo.IsInsuranceShip ? GvG3InsuranceHelper.GetInsuranceShipName() : Singleton<GvGMode3RoomManager>.Instance.ObserverRecord.GetMyShipName(entityInfo.ShipId));
		((GObject)slot.SoldierCountText).text = $"{myShipSoldierCount.Count}/{myShipSoldierCount.TotalCount}";
		((GObject)slot.KillCountText).text = $"{entityInfo.KillSoldiersCount}";
		((GObject)slot.DamageText).text = $"{entityInfo.BossDamage}";
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
		if (entityInfo.CanRetreatTimestamp > 0 && _isHoldingWithoutInterruption)
		{
			slot.ActionMode.selectedIndex = 1;
			((GObject)slot.RetreatBtn).enabled = (int)GameController.Instance.GetServerTime() >= entityInfo.CanRetreatTimestamp;
			((GObject)slot.RetreatBtn).onClick.Set((EventCallback0)delegate
			{
				OnClickRetreatBtn(entityInfo.EntityId, slot.RetreatBtn);
			});
		}
		else
		{
			slot.ActionMode.selectedIndex = 0;
		}
		slot.DisplayMode.selectedIndex = ((slot.State.selectedIndex == 0) ? MyShipsMenu.DisplayMode.selectedIndex : 0);
		slot.IsShowDamage.selectedIndex = (_hasBoss ? 1 : 0);
		slot.IsSelectStrategy.selectedIndex = ((CurShipStrategySelectingIndex == index) ? 1 : 0);
		((GObject)slot).onClick.Set((EventCallback0)delegate
		{
			OnSelectShipItem(index);
		});
		int num = entityInfo.BattleStrategy;
		if (num < 0)
		{
			num = 0;
		}
		slot.CurStrategyBtn.CampId.SetSelectedIndex(num);
		((GObject)slot.CurStrategyBtn).onClick.Set((EventCallback1)delegate(EventContext ec)
		{
			OnOpenStrategyPanel(ec, index);
		});
		((GObject)slot.CurStrategyBtn).touchable = !entityInfo.IsInsuranceShip;
		slot.StrategyMenu.List.itemRenderer = new ListItemRenderer(RenderStrategyMenuListItem);
		slot.StrategyMenu.List.numItems = MyStrategies.Count;
		slot.StrategyMenu.List.selectedIndex = GetStrategyIndex(entityInfo.BattleStrategy);
		((GObject)slot.StrategyMenu).onClick.Set(new EventCallback1(OnClickStrategyMenu));
		SetSlotVisible();
		void OnSelectStrategy(int selectIndex)
		{
			int entityId = MyShips_List[CurShipStrategySelectingIndex].EntityId;
			int strategy = MyStrategies[selectIndex];
			GvG3IslandController.Instance.ChangeBattleStrategy(entityId, strategy, delegate
			{
				MyShips_List[CurShipStrategySelectingIndex].BattleStrategy = strategy;
				CurShipStrategySelectingIndex = -1;
				UpdateMyShipMenu();
			});
		}
		void RenderStrategyMenuListItem(int itemIndex, GObject itemObject)
		{
			//IL_0058: Unknown result type (might be due to invalid IL or missing references)
			//IL_0062: Expected O, but got Unknown
			if (itemObject is UI_btn_StrategySelection uI_btn_StrategySelection)
			{
				uI_btn_StrategySelection.Type.SetSelectedIndex(MyStrategies[itemIndex]);
				((GObject)uI_btn_StrategySelection).onClick.Set((EventCallback0)delegate
				{
					OnSelectStrategy(itemIndex);
				});
			}
		}
		void SetSlotVisible()
		{
			bool flag = entityInfo.GvGMode3State == 7 && entityInfo.IsInsuranceShip;
			slot.IsHidden.SetSelectedIndex(flag ? 1 : 0);
			((GObject)slot).alpha = (flag ? 0f : 1f);
			((GObject)slot).touchable = !flag;
		}
	}

	private void UpdateTopPanelInfo(long bossHp, int npcSoldierCount)
	{
		if (BossSoldier != null && bossHp > 0)
		{
			Mode.selectedIndex = 1;
			((GProgressBar)BossHealthBar.HealthBar).value = bossHp;
			((GObject)BossHealthBar.HpText).text = $"{bossHp}/{BossMaxHp}";
		}
		else if (npcSoldierCount > 0)
		{
			Mode.selectedIndex = 2;
			((GObject)NpcInfo.SoldierCount).text = $"{npcSoldierCount}";
		}
		else
		{
			Mode.selectedIndex = 3;
		}
	}

	public IEnumerator ProccessBestKill(int userId, int killCount, int campId, int shipRace, bool isKilled = false)
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
			SetBestKillAppear(campId, userId, shipRace, delegate
			{
				isCompleted2 = true;
			});
			while (!isCompleted2)
			{
				yield return null;
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

	public void SetBestKillAppear(int campId, int userId, int shipRace, Action OnComplete = null)
	{
		//IL_009d: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a7: Expected O, but got Unknown
		BestKill.Avatar.CampId.selectedIndex = campId;
		((UI_com_ShipSmallIcon)(object)BestKill.ShipSkin).SetShipStyle(shipRace, campId);
		GvG3ProfileHelper.GetUserProfile(new GvG3UserProfileRequestOptions($"{campId}", userId, delegate(UserProfile profile)
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
			BestKill.State.selectedIndex = 2;
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

	private void UpdateLeaderboard(List<GvGMode3IslandRankInfo> rankData, List<GvGMode3IslandRankInfo> extraRankData)
	{
		//IL_0033: Unknown result type (might be due to invalid IL or missing references)
		//IL_003d: Expected O, but got Unknown
		RankList = rankData ?? new List<GvGMode3IslandRankInfo>();
		ExtraRankList = extraRankData ?? new List<GvGMode3IslandRankInfo>();
		Leaderboard.List.itemRenderer = new ListItemRenderer(LeaderboardSlotRenderer);
		Leaderboard.List.numItems = GetCurRankingList().Count;
		SetLeaderboardType();
	}

	private void SetLeaderboardType()
	{
		if (_hasBoss)
		{
			Leaderboard.Type.selectedIndex = (_curRankingListIsExtra ? 3 : 0);
		}
		if (_hasRandomEvent)
		{
			Leaderboard.Type.selectedIndex = (_curRankingListIsExtra ? ((BossSoldier != null) ? 1 : 2) : 0);
		}
		bool visible = !_curRankingListIsExtra || _randomEventType == eIslandEvent.RandomEvent_NPCEvent || _randomEventType == eIslandEvent.RandomEvent_BossEvent;
		((GObject)Leaderboard.Help).visible = visible;
	}

	private void LeaderboardSlotRenderer(int index, GObject obj)
	{
		GvGMode3IslandRankInfo gvGMode3IslandRankInfo = GetCurRankingList()[index];
		RenderSingleLeaderboardSlot((UI_btn_LeaderboardSlot)(object)obj, index, gvGMode3IslandRankInfo.Data, gvGMode3IslandRankInfo.UserId, gvGMode3IslandRankInfo.CampId);
	}

	private void RenderSingleLeaderboardSlot(UI_btn_LeaderboardSlot slot, int ranking, long rankingData, int userId, int campId)
	{
		ranking++;
		((GObject)slot.Content).text = rankingData.ShortNumberFormat();
		((GObject)slot.Ranking).text = ranking.ToString();
		slot.TypeController.selectedIndex = ((ranking < 4) ? ranking : 0);
		slot.Avatar.CampId.SetSelectedIndex(campId);
		if (_curRankingListIsExtra)
		{
			slot.RankingType.selectedIndex = ((BossSoldier != null) ? 1 : 2);
		}
		else
		{
			slot.RankingType.selectedIndex = 0;
		}
		slot.Avatar.HeadPortrait.icon.url = GvG3ProfileHelper.DefaultAvatarUrl;
		GvG3ProfileHelper.GetUserProfile(new GvG3UserProfileRequestOptions(CacheId, userId, delegate(UserProfile profile)
		{
			((GObject)slot.PlayerName).text = profile.Name;
		}, delegate(Sprite sprite)
		{
			//IL_001c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0026: Expected O, but got Unknown
			slot.Avatar.HeadPortrait.icon.texture = new NTexture((Texture)(object)sprite.texture);
		}));
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

	public void OnShow()
	{
	}

	public void BeforeDestroy()
	{
		UnRegisterGvGEvent();
		BeskKillCoroutineQueue.Clear();
		GvG3IslandController.ReleaseInstance();
		Singleton<GvGMode3RoomManager>.Instance.TryDelayDisconnectRoom();
	}

	public void Destroy()
	{
	}

	private void OnCloseByEvent(UICallbackParam<Action> callback)
	{
		_onCloseBySuccessCallback = callback;
		End();
	}

	public void End()
	{
		GameController.Contexts.Service<IUiService>().PushBackupAndCloseAllUIs(new List<string>
		{
			UI_main_GvG3Chat.Name,
			UI_main_GvGLoadingPanel.Name,
			UI_main_GvGLoading2Panel.Name,
			UI_UniversalConfirmPopup.Name
		}, toBackupStack: false);
		((MonoBehaviour)FGUIManager.Instance).StartCoroutine(DelayRecover());
	}

	private void EndByForceStop()
	{
		GameController.Contexts.Service<IUiService>().PushBackupAndCloseAllUIs(new List<string>
		{
			UI_main_GvGLoadingPanel.Name,
			UI_main_GvGLoading2Panel.Name,
			UI_UniversalConfirmPopup.Name
		}, toBackupStack: false, closeHidden: true);
		((MonoBehaviour)FGUIManager.Instance).StartCoroutine((Singleton<GvGMode3RoomManager>.Instance.OnQuickStartReturnMainCity != null) ? DelayReturnMainCity() : DelayRecover_ForceStop());
	}

	private IEnumerator DelayRecover_ForceStop()
	{
		yield return null;
		GameController.Contexts.Service<IUiService>().RecoverLastBackup(2);
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
		GameController.Contexts.Service<IUiService>().RecoverLastHiddenUIs();
		GvGWorldMapController.Instance.Resume();
		yield return null;
		_onCloseBySuccessCallback?.Callback?.Invoke();
		_onCloseBySuccessCallback = null;
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

	private int GetStrategyIndex(int strategy)
	{
		for (int i = 0; i < MyStrategies.Count; i++)
		{
			if (MyStrategies[i] == strategy)
			{
				return i;
			}
		}
		return 0;
	}
}
