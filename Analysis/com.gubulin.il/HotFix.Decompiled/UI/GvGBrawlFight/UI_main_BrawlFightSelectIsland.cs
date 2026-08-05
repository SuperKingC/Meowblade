using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;
using GameDataEditor;
using GvG3;
using HotFix.Sources.Base.Scripts.Helper;
using HotFix.Sources.Base.Sources.Scripts.GvG3.GvG3UI.Helper;
using HotFix.Sources.Base.Sources.Scripts.GvG3.GvG3UI.Interface.Brawl;
using HotFix.Sources.Base.Sources.Scripts.GvG3.GvG3UI.Model.UserProfile;
using HotFix.Sources.Base.Sources.Scripts.GvG3Common.Manager;
using HotFix.Sources.Base.Sources.Scripts.GvG3Common.Model;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Helper;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Manager;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Model;
using HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Controller;
using HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Helper;
using HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Manager;
using HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Model;
using Shift.Legion.ClientApi.Models;
using Shift.Legion.Common.Enums;
using Shift.Legion.Common.Helpers;
using Shift.Legion.Common.Managers;
using Shift.Legion.Common.Models;
using Shift.Legion.Common.Services;
using Shift.Legion.GvG.Common.Enums;
using Shift.Legion.GvG.Common.Models;
using Shift.Legion.GvG.Common.Models.GvGMode3;
using Shift.Legion.GvG.Common.Models.GvGMode3.BrawlEvent;
using Shift.Legion.GvG.Common.Models.GvGMode3.Mission;
using Shift.Legion.GvG.Common.Models.GvGMode3.Mission.BrawlEvent;
using Shift.Legion.GvGServer.Models.GvGMode3IslandManagerSocket.Mission;
using UI.GvGBattleRecord3;
using UI.GvGChat;
using UI.GvGFlagship3;
using UI.GvGOnIsland3;
using UI.GvGWorldMap3;
using UI.PublicResources;
using UnityEngine;

namespace UI.GvGBrawlFight;

public class UI_main_BrawlFightSelectIsland : GComponent, IUiController
{
	public class BuffViewModel
	{
		public GDEItemData Item;

		public int Count;

		public int IncreaseCount;

		public UI_com_buff BuffObj;
	}

	private enum Mode
	{
		Enroll,
		Review
	}

	private class IslandDisplayBinding
	{
		private enum FightState
		{
			NotStart,
			Fighting,
			End
		}

		public readonly int IslandId;

		private UI_main_BrawlFightSelectIsland _parent;

		public UI_com_islandInfoDisplay Display;

		private Vector3 _worldPos;

		private bool _isReview;

		private int _brawFightDuration;

		private bool _refreshBrawlEvent;

		public IslandDisplayBinding(int islandId, UI_main_BrawlFightSelectIsland parent, bool isReview)
		{
			//IL_0027: Unknown result type (might be due to invalid IL or missing references)
			//IL_002c: Unknown result type (might be due to invalid IL or missing references)
			IslandId = islandId;
			_parent = parent;
			_worldPos = WorldMapConfigHelper.Configs.TryGetIsland(IslandId).Position;
			_worldPos.z *= 1.414f;
			_isReview = isReview;
		}

		public void Init()
		{
			Display = UI_com_islandInfoDisplay.CreateInstance();
			UI_com_ShipAvatar uI_com_ShipAvatar = (UI_com_ShipAvatar)(object)Display.Mvp.Avatar;
			((GComponent)uI_com_ShipAvatar.DefaultAvatar).fairyBatching = false;
			((GComponent)uI_com_ShipAvatar.HeadPortrait).fairyBatching = false;
			((GComponent)_parent.infoContainer).AddChild((GObject)(object)Display);
			IslandConfigData islandConfigData = WorldMapConfigHelper.Configs.TryGetIsland(IslandId);
			((GObject)Display.islandName.nameText).text = islandConfigData.Name;
			Display.islandType.SetSelectedIndex((int)(islandConfigData.Props.GetSizeType() - 1));
			if (!_isReview)
			{
				IslandStateModel stateModel = Singleton<WorldStateManager>.Instance.TryGetIsland(IslandId);
				_brawFightDuration = (_parent._islandSignUpDatas.TryGetValue(IslandId, out var value) ? value.ReplayDuration : (-1));
				RefreshState(stateModel);
			}
			else
			{
				ReviewResult reviewResult = _parent._reviewResultLut[IslandId];
				IEvent_Brawl_Icon iconInfo = null;
				if (reviewResult.FirstFinalReward != null)
				{
					iconInfo = new IEvent_Brawl_Icon
					{
						ItemId = reviewResult.FirstFinalReward.ItemId,
						Cnt = reviewResult.FirstFinalReward.cnt
					};
				}
				IEvent_Brawl brawlEvent = new IEvent_Brawl
				{
					WinnerCamp = reviewResult.WinnerCamp,
					IconInfo = iconInfo,
					SubType = reviewResult.MissionSubType
				};
				eRace playerSignUpShipRaceByIslandId = _parent._reviewInfo.GetPlayerSignUpShipRaceByIslandId(IslandId);
				FightState islandState = (reviewResult.HasBattleReplay() ? FightState.End : FightState.NotStart);
				RefreshState(islandState, reviewResult.WinnerCamp, brawlEvent, playerSignUpShipRaceByIslandId, reviewResult.MVPUserId);
			}
			RefreshIslandEnrollCount();
			RefreshPos();
		}

		public void OnDestroy()
		{
		}

		public void Step(int frameCount)
		{
			if (!_isReview && frameCount % 60 == 0)
			{
				IslandStateModel stateModel = Singleton<WorldStateManager>.Instance.TryGetIsland(IslandId);
				RefreshState(stateModel);
			}
		}

		public void RefreshIslandEnrollCount()
		{
			if (Display != null && _parent._islandSignUpDatas.TryGetValue(IslandId, out var value))
			{
				bool flag = value.CurCnt >= value.MaxCnt;
				((GObject)Display.enrollCount.countText).text = $"{value.CurCnt}/{value.MaxCnt}";
				Display.enrollCount.isFull.SetSelectedIndex(flag ? 1 : 0);
			}
		}

		private void RefreshState(IslandStateModel stateModel)
		{
			FightState fightState = GetFightState(_brawFightDuration, _parent._eventInfo);
			IEvent_Brawl brawlEvent = stateModel.BrawlEvent;
			eRace enrollRaceIdOnIsland = _parent._eventInfo.GetEnrollRaceIdOnIsland(IslandId);
			BE_SignUpDataModel_ToProtocol3 value;
			BE_SignUpDataModel_ToProtocol3 bE_SignUpDataModel_ToProtocol = (_parent._islandSignUpDatas.TryGetValue(IslandId, out value) ? value : null);
			int winnerCamp = bE_SignUpDataModel_ToProtocol?.WinnerCampId ?? 0;
			int mvpUserId = bE_SignUpDataModel_ToProtocol?.MVPUserId ?? 0;
			RefreshState(fightState, winnerCamp, brawlEvent, enrollRaceIdOnIsland, mvpUserId);
		}

		private void RefreshState(FightState islandState, int winnerCamp, IEvent_Brawl brawlEvent, eRace enrollShipRace, int mvpUserId)
		{
			if ((int)islandState > Display.fightStatus.selectedIndex)
			{
				Display.fightStatus.SetSelectedIndex((int)islandState);
			}
			if (islandState == FightState.End)
			{
				int winnerIndex = Mathf.Max(0, winnerCamp);
				Display.winCampIcon.campType.SetSelectedIndex(winnerIndex);
				if (mvpUserId != 0)
				{
					GLoader userIconLoader = Display.Mvp.Avatar.GetChild("HeadPortrait").asCom.GetChild("icon").asLoader;
					Controller campCtr = Display.Mvp.Avatar.GetController("CampId");
					GvG3ProfileHelper.GetUserProfile(new GvG3UserProfileRequestOptions($"{Singleton<GvGMode3RoomManager>.Instance.ObserverRecord.CurIZId}", mvpUserId, null, delegate(Sprite sprite)
					{
						//IL_0028: Unknown result type (might be due to invalid IL or missing references)
						//IL_0032: Expected O, but got Unknown
						if (!((GObject)Display).isDisposed)
						{
							userIconLoader.texture = new NTexture((Texture)(object)sprite.texture);
							campCtr.SetSelectedIndex(winnerIndex);
						}
					}));
				}
				else
				{
					ILRuntimeDebug.LogError($"乱斗胜利方={winnerIndex}Mvp玩家Id={mvpUserId}");
				}
			}
			bool flag = enrollShipRace != eRace.Invalid;
			Display.hasMyShip.SetSelectedIndex(flag ? 1 : 0);
			if (flag)
			{
				int obCampId = Singleton<GvGMode3RoomManager>.Instance.ObserverRecord.ObCampId;
				ShipConfigModel byShipRaceType = ShipConfigHelper.GetByShipRaceType((int)enrollShipRace);
				Display.myShipIcon.icon.url = ShipConfigHelper.GetSkinById(byShipRaceType.DefaultSkinId).GetMiniIconUrlByCamId(obCampId);
			}
			if (_refreshBrawlEvent)
			{
				return;
			}
			_refreshBrawlEvent = true;
			bool flag2 = !string.IsNullOrEmpty(brawlEvent.IconInfo?.ItemId);
			Display.hasReward.SetSelectedIndex(flag2 ? 1 : 0);
			if (flag2)
			{
				string itemId = brawlEvent.IconInfo.ItemId;
				GDEItemData gDEItemData = GDMgr.Get<GDEItemData>(itemId);
				if (gDEItemData == null)
				{
					ILRuntimeDebug.LogError("ItemConfig is null -- " + brawlEvent.IconInfo.ItemId);
					Display.hasReward.SetSelectedIndex(0);
				}
				else
				{
					Display.rewardGroup.SetUpReward(brawlEvent.IconInfo, gDEItemData);
				}
			}
		}

		private void RefreshPos()
		{
			//IL_000d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0012: Unknown result type (might be due to invalid IL or missing references)
			//IL_0017: Unknown result type (might be due to invalid IL or missing references)
			//IL_0018: Unknown result type (might be due to invalid IL or missing references)
			//IL_0019: Unknown result type (might be due to invalid IL or missing references)
			//IL_001e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0023: Unknown result type (might be due to invalid IL or missing references)
			//IL_002a: Unknown result type (might be due to invalid IL or missing references)
			//IL_002b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0030: Unknown result type (might be due to invalid IL or missing references)
			//IL_0037: Unknown result type (might be due to invalid IL or missing references)
			//IL_003d: Unknown result type (might be due to invalid IL or missing references)
			Vector3 val = _parent._mainCamera.WorldToScreenPoint(_worldPos);
			Vector2 val2 = ScreenToGlobalPos(Vector2.op_Implicit(val));
			Vector2 val3 = ((GObject)_parent).GlobalToLocal(val2);
			((GObject)Display).SetXY(val3.x, val3.y);
		}

		private static FightState GetFightState(int fightDuration, C2S_BrawlEvent_GetInfo.Response eventInfo)
		{
			if (fightDuration <= 0)
			{
				return FightState.NotStart;
			}
			C2S_BrawlEvent_GetInfo.Stage stage = eventInfo.GetStage();
			if (stage != C2S_BrawlEvent_GetInfo.Stage.Fighting)
			{
				return FightState.NotStart;
			}
			long num = UI_main_BrawlFightEnroll.GetBrawlEventTime() - eventInfo.GetFightingTimeEnd;
			return (fightDuration > num) ? FightState.Fighting : FightState.End;
		}
	}

	public Controller showOperationPanel;

	public Controller State;

	public Controller isShowBuff;

	public Controller StepType;

	public Controller isReview;

	public GLoader background;

	public UI_com_islandInfoContainer infoContainer;

	public UI_dec_map_portal_01 n28;

	public UI_dec_map_portal_01 n29;

	public UI_dec_map_portal_02 n30;

	public UI_dec_map_portal_02 n31;

	public GGraph RayMask;

	public UI_com_EnrollStatus enrollStatus;

	public UI_com_ShipList ShipList;

	public UI_com_OperationDialog OperationDialog;

	public GImage n18;

	public GTextField n19;

	public GTextField n20;

	public GGroup n22;

	public GTextField reviewName;

	public GGroup reviewGroup;

	public UI_com_HoldingPercent HoldingPercents;

	public GButton BackBtn;

	public UI_com_03 buffContent;

	public UI_com_SliderVertUp Slider;

	public UI_btn_AddButton AddBtn;

	public UI_btn_MinusButton MinusBtn;

	public GGroup sliderGroup;

	public GImage n24;

	public UI_btn_04 buffBtn;

	public GGraph ScreenFX;

	public Transition t0;

	public const string URL = "ui://hozu168rnt907";

	public static string Name = "UI_main_BrawlFightSelectIsland";

	public const string GVG_BRAWL_EVENT_INFO = "GvGBrawlEventInfo";

	public const string GVG_BRAWL_EVENT_REVIEW = "GvGBrawlEventReview";

	private C2S_BrawlEvent_GetInfo.Response _eventInfo;

	private C2S_BrawlEvent_Review.Response _reviewInfo;

	private C2S_BrawlEvent_GetDetailInfoByIsland.Response _islandDetailInfo;

	private int _selectIslandId;

	private GvGMode3BrawlEvent_BaseInfo _config;

	private List<UI_com_ShipList.ShipBattleStrategy> _shipDatas;

	private List<IslandDisplayBinding> _islandDisplays;

	private Dictionary<int, BE_SignUpDataModel_ToProtocol3> _islandSignUpDatas;

	private List<ReviewResult> _reviewResults;

	private Dictionary<int, ReviewResult> _reviewResultLut;

	private List<ReviewTotal> _reviewTotals;

	private bool _blockIslandClick;

	private Camera _mainCamera;

	private List<int> _visibleIslands;

	private Coroutine _reopenCoroutine;

	private bool _dataReady;

	private List<BuffViewModel> _selfBuffs;

	private List<BuffViewModel> _campBuffs;

	private Mode _pageMode;

	private Vector3 _cameraInitPos;

	private float _cameraInitSize;

	private Vector3 _originPos;

	private float _currentSliderValue;

	private float _sliderAddStep;

	private static readonly List<string> HideUi = new List<string>
	{
		UI_main_BrawlFightEnroll.Name,
		UI_main_GvGFlagshipPanel.Name,
		UI_main_GvG3Chat.Name,
		UI_main_GvGWorldMap3.Name
	};

	public bool IsFinalMode => UI_main_BrawlFightEnroll.IsFinalStep(StepIndex);

	public int StepIndex
	{
		get
		{
			if (_pageMode == Mode.Review)
			{
				return _reviewInfo.StepIdx;
			}
			return _eventInfo.StepIdx;
		}
	}

	private C2S_BrawlEvent_GetInfo.Stage CurrentStage
	{
		get
		{
			if (_pageMode == Mode.Review)
			{
				return C2S_BrawlEvent_GetInfo.Stage.Fighting;
			}
			return _eventInfo.GetStage();
		}
	}

	public static string GetURL()
	{
		return "ui://hozu168rnt907";
	}

	public static UI_main_BrawlFightSelectIsland CreateInstance()
	{
		return (UI_main_BrawlFightSelectIsland)(object)UIPackage.CreateObject("GvGBrawlFight", "main_BrawlFightSelectIsland");
	}

	public static UI_main_BrawlFightSelectIsland CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_main_BrawlFightSelectIsland).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://hozu168rnt907", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_006a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0074: Expected O, but got Unknown
		//IL_00ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f8: Expected O, but got Unknown
		//IL_0146: Unknown result type (might be due to invalid IL or missing references)
		//IL_0150: Expected O, but got Unknown
		//IL_015c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0166: Expected O, but got Unknown
		//IL_01af: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b9: Expected O, but got Unknown
		//IL_0202: Unknown result type (might be due to invalid IL or missing references)
		//IL_020c: Expected O, but got Unknown
		//IL_0218: Unknown result type (might be due to invalid IL or missing references)
		//IL_0222: Expected O, but got Unknown
		//IL_026b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0275: Expected O, but got Unknown
		//IL_0297: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a1: Expected O, but got Unknown
		//IL_0305: Unknown result type (might be due to invalid IL or missing references)
		//IL_030f: Expected O, but got Unknown
		//IL_031b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0325: Expected O, but got Unknown
		//IL_0347: Unknown result type (might be due to invalid IL or missing references)
		//IL_0351: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		showOperationPanel = ((GComponent)this).GetController("showOperationPanel");
		State = ((GComponent)this).GetController("State");
		isShowBuff = ((GComponent)this).GetController("isShowBuff");
		StepType = ((GComponent)this).GetController("StepType");
		isReview = ((GComponent)this).GetController("isReview");
		background = (GLoader)((GComponent)this).GetChild("background");
		infoContainer = (UI_com_islandInfoContainer)(object)((GComponent)this).GetChild("infoContainer");
		n28 = (UI_dec_map_portal_01)(object)((GComponent)this).GetChild("n28");
		n29 = (UI_dec_map_portal_01)(object)((GComponent)this).GetChild("n29");
		n30 = (UI_dec_map_portal_02)(object)((GComponent)this).GetChild("n30");
		n31 = (UI_dec_map_portal_02)(object)((GComponent)this).GetChild("n31");
		RayMask = (GGraph)((GComponent)this).GetChild("RayMask");
		enrollStatus = (UI_com_EnrollStatus)(object)((GComponent)this).GetChild("enrollStatus");
		ShipList = (UI_com_ShipList)(object)((GComponent)this).GetChild("ShipList");
		OperationDialog = (UI_com_OperationDialog)(object)((GComponent)this).GetChild("OperationDialog");
		n18 = (GImage)((GComponent)this).GetChild("n18");
		n19 = (GTextField)((GComponent)this).GetChild("n19");
		string id = "ui://hozu168rnt907".Replace("ui://", "") + "-" + ((GObject)n19).id;
		((GObject)n19).text = LanguagesManager.GetDesc(id);
		n20 = (GTextField)((GComponent)this).GetChild("n20");
		string id2 = "ui://hozu168rnt907".Replace("ui://", "") + "-" + ((GObject)n20).id;
		((GObject)n20).text = LanguagesManager.GetDesc(id2);
		n22 = (GGroup)((GComponent)this).GetChild("n22");
		reviewName = (GTextField)((GComponent)this).GetChild("reviewName");
		string id3 = "ui://hozu168rnt907".Replace("ui://", "") + "-" + ((GObject)reviewName).id;
		((GObject)reviewName).text = LanguagesManager.GetDesc(id3);
		reviewGroup = (GGroup)((GComponent)this).GetChild("reviewGroup");
		HoldingPercents = (UI_com_HoldingPercent)(object)((GComponent)this).GetChild("HoldingPercents");
		BackBtn = (GButton)((GComponent)this).GetChild("BackBtn");
		buffContent = (UI_com_03)(object)((GComponent)this).GetChild("buffContent");
		Slider = (UI_com_SliderVertUp)(object)((GComponent)this).GetChild("Slider");
		AddBtn = (UI_btn_AddButton)(object)((GComponent)this).GetChild("AddBtn");
		MinusBtn = (UI_btn_MinusButton)(object)((GComponent)this).GetChild("MinusBtn");
		sliderGroup = (GGroup)((GComponent)this).GetChild("sliderGroup");
		n24 = (GImage)((GComponent)this).GetChild("n24");
		buffBtn = (UI_btn_04)(object)((GComponent)this).GetChild("buffBtn");
		ScreenFX = (GGraph)((GComponent)this).GetChild("ScreenFX");
		t0 = ((GComponent)this).GetTransition("t0");
	}

	public void RegisterUiEventListeners()
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected O, but got Unknown
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Expected O, but got Unknown
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		//IL_0061: Expected O, but got Unknown
		//IL_0079: Unknown result type (might be due to invalid IL or missing references)
		//IL_0083: Expected O, but got Unknown
		//IL_009b: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a5: Expected O, but got Unknown
		//IL_00b8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c2: Expected O, but got Unknown
		//IL_00d5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00df: Expected O, but got Unknown
		//IL_00f2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fc: Expected O, but got Unknown
		//IL_010f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0119: Expected O, but got Unknown
		//IL_017a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0184: Expected O, but got Unknown
		//IL_0197: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a1: Expected O, but got Unknown
		((GObject)BackBtn).onClick.Set(new EventCallback0(End));
		((GObject)OperationDialog.enrollBtn).onClick.Set(new EventCallback0(OnClickGoEnroll));
		((GObject)OperationDialog.enterBtn).onClick.Set(new EventCallback0(OnClickGoStreaming));
		((GObject)OperationDialog.CheckRecords).onClick.Set(new EventCallback0(OnClickShowBattleLog));
		((GObject)OperationDialog.helpBtn).onClick.Set(new EventCallback0(OnClickHelpBtn));
		((GObject)RayMask).onTouchBegin.Set(new EventCallback1(OnDragBegin));
		((GObject)RayMask).onTouchMove.Set(new EventCallback1(OnDrag));
		((GObject)RayMask).onTouchEnd.Set(new EventCallback1(OnDragEnd));
		((GObject)RayMask).onClick.Set(new EventCallback1(OnClickRayMask));
		UI_com_ShipList shipList = ShipList;
		shipList.onClickCancelEnroll = (Action<string>)Delegate.Combine(shipList.onClickCancelEnroll, new Action<string>(OnClickCancelEnroll));
		UI_com_ShipList shipList2 = ShipList;
		shipList2.OnClickChangeStrategy = (Action<UI_com_ShipList.ShipBattleStrategy>)Delegate.Combine(shipList2.OnClickChangeStrategy, new Action<UI_com_ShipList.ShipBattleStrategy>(OnClickChangeStrategy));
		((GObject)AddBtn).onClick.Set(new EventCallback0(OnClickAddBtn));
		((GObject)MinusBtn).onClick.Set(new EventCallback0(OnClickMinusBtn));
		UI_com_SliderVertUp slider = Slider;
		slider.OnChange = (Action)Delegate.Combine(slider.OnChange, new Action(OnSliderValueChange));
		SharedMessenger.AddListener<string>("CLOSE_UI", OnUiClose);
		GvGMode3RoomManager instance = Singleton<GvGMode3RoomManager>.Instance;
		instance.OnRoomClose = (Action)Delegate.Combine(instance.OnRoomClose, new Action(ForceClose));
	}

	public void UnregisterUiEventListeners()
	{
		((GObject)BackBtn).onClick.Clear();
		((GObject)OperationDialog.enrollBtn).onClick.Clear();
		((GObject)OperationDialog.enterBtn).onClick.Clear();
		((GObject)OperationDialog.CheckRecords).onClick.Clear();
		((GObject)OperationDialog.helpBtn).onClick.Clear();
		((GObject)RayMask).onTouchBegin.Clear();
		((GObject)RayMask).onTouchMove.Clear();
		((GObject)RayMask).onTouchEnd.Clear();
		((GObject)RayMask).onClick.Clear();
		UI_com_ShipList shipList = ShipList;
		shipList.onClickCancelEnroll = (Action<string>)Delegate.Remove(shipList.onClickCancelEnroll, new Action<string>(OnClickCancelEnroll));
		UI_com_ShipList shipList2 = ShipList;
		shipList2.OnClickChangeStrategy = (Action<UI_com_ShipList.ShipBattleStrategy>)Delegate.Remove(shipList2.OnClickChangeStrategy, new Action<UI_com_ShipList.ShipBattleStrategy>(OnClickChangeStrategy));
		((GObject)AddBtn).onClick.Clear();
		((GObject)MinusBtn).onClick.Clear();
		UI_com_SliderVertUp slider = Slider;
		slider.OnChange = (Action)Delegate.Remove(slider.OnChange, new Action(OnSliderValueChange));
		SharedMessenger.RemoveListener<string>("CLOSE_UI", OnUiClose);
		GvGMode3RoomManager instance = Singleton<GvGMode3RoomManager>.Instance;
		instance.OnRoomClose = (Action)Delegate.Remove(instance.OnRoomClose, new Action(ForceClose));
		if ((Object)(object)GvGWorldMapController.Instance != (Object)null)
		{
			GvGWorldMapController instance2 = GvGWorldMapController.Instance;
			instance2.OnSelectIsland = (Action<int>)Delegate.Remove(instance2.OnSelectIsland, new Action<int>(OnSelectIsland));
			GvGMapInputManager inputManager = GvGWorldMapController.Instance.InputManager;
			inputManager.OnPinchStart = (Action)Delegate.Remove(inputManager.OnPinchStart, new Action(OnPinchBegin));
			GvGMapInputManager inputManager2 = GvGWorldMapController.Instance.InputManager;
			inputManager2.OnPinch = (Action<float>)Delegate.Remove(inputManager2.OnPinch, new Action<float>(OnPinch));
			GvGMapInputManager inputManager3 = GvGWorldMapController.Instance.InputManager;
			inputManager3.OnPinchEnd = (Action)Delegate.Remove(inputManager3.OnPinchEnd, new Action(OnPinchEnd));
		}
	}

	private IEnumerator WaitWorldMapControllerInit()
	{
		while (!((GObject)this).isDisposed && ((Object)(object)GvGWorldMapController.Instance == (Object)null || !GvGWorldMapController.Instance.InitComplete))
		{
			yield return null;
		}
		GvGWorldMapController instance = GvGWorldMapController.Instance;
		instance.OnSelectIsland = (Action<int>)Delegate.Combine(instance.OnSelectIsland, new Action<int>(OnSelectIsland));
		GvGMapInputManager inputManager = GvGWorldMapController.Instance.InputManager;
		inputManager.OnPinchStart = (Action)Delegate.Combine(inputManager.OnPinchStart, new Action(OnPinchBegin));
		GvGMapInputManager inputManager2 = GvGWorldMapController.Instance.InputManager;
		inputManager2.OnPinch = (Action<float>)Delegate.Combine(inputManager2.OnPinch, new Action<float>(OnPinch));
		GvGMapInputManager inputManager3 = GvGWorldMapController.Instance.InputManager;
		inputManager3.OnPinchEnd = (Action)Delegate.Combine(inputManager3.OnPinchEnd, new Action(OnPinchEnd));
		_mainCamera = GvGWorldMapController.Instance.CameraBindingManager.MainCamera;
		bool isFinal = IsFinalMode;
		GvGWorldMapController.Instance.InputManager.DisablePinch = !isFinal;
		GvGWorldMapController.Instance.SetIslandGroup(StepIndex);
		GvGWorldMapController.Instance.BackgroundManager.ChangeSpace(_config.SpaceBg);
		InitIslandDisplay();
	}

	public void Init(Dictionary<string, object> parameters)
	{
		FGUIManager.SetUiPanelSizeAndXy((GObject)(object)this, scaleAdaption: true);
		_islandDisplays = new List<IslandDisplayBinding>();
		_islandSignUpDatas = new Dictionary<int, BE_SignUpDataModel_ToProtocol3>();
		_selfBuffs = new List<BuffViewModel>();
		_campBuffs = new List<BuffViewModel>();
		_reviewResultLut = new Dictionary<int, ReviewResult>();
		_eventInfo = (C2S_BrawlEvent_GetInfo.Response)parameters["GvGBrawlEventInfo"];
		if (_eventInfo == null)
		{
			UnityUiService.Instance.ClosePanel(Name);
			return;
		}
		_reviewInfo = (parameters.TryGetValue("GvGBrawlEventReview", out var value) ? ((C2S_BrawlEvent_Review.Response)value) : null);
		_pageMode = ((_reviewInfo != null) ? Mode.Review : Mode.Enroll);
		_config = WorldMapConfigHelper.Configs.TryGetBrawlEvent(StepIndex);
		_visibleIslands = _config.EffectIslandIds;
		float num = (IsFinalMode ? 25f : 15f);
		float num2 = 6f;
		_sliderAddStep = (num - num2) / 10f;
		Slider.Init(num2, num, num);
		bool isFinalMode = IsFinalMode;
		if (isFinalMode)
		{
			Singleton<WorldStateManager>.Instance.SetMyCampIslandVisible(isVisible: false);
		}
		Singleton<WorldStateManager>.Instance.SetAdditionalVisibleIslands(_visibleIslands);
		Singleton<WorldStateManager>.Instance.SetIslandHideNameAndState(_visibleIslands, hide: true);
		UnityUiService.Instance.HideUis(HideUi);
		t0.invalidateBatchingEveryFrame = true;
		StepType.SetSelectedIndex(isFinalMode ? 1 : 0);
		InitShipList();
		RefreshEnrollStatus();
		C2S_BrawlEvent_GetInfo.Stage currentStage = CurrentStage;
		State.SetSelectedIndex((int)currentStage);
		bool flag = _pageMode == Mode.Review;
		isReview.SetSelectedIndex(flag ? 1 : 0);
		if (flag)
		{
			int num3 = UI_main_BrawlFightEnroll.WhatDayIsToday();
			((GObject)reviewName).text = HotFix.Sources.Base.Scripts.Helper.StringExtensions.Format("BrawlEventReviewName".ToLanguage(), GvGMode3BrawlEvent_BaseInfo.GetBrawlFightSettleTimeStr(num3 - 1));
		}
		bool flag2 = UI_main_BrawlFightEnroll.IsFinalStepOne(StepIndex);
		flag2 = flag2 && (currentStage == C2S_BrawlEvent_GetInfo.Stage.Enroll || currentStage == C2S_BrawlEvent_GetInfo.Stage.EnrollFirstDay || currentStage == C2S_BrawlEvent_GetInfo.Stage.Enrolled);
		infoContainer.showCenterText.SetSelectedIndex(flag2 ? 1 : 0);
		RefreshBrawlFightBuff();
		RefreshWinnerOverView();
		((MonoBehaviour)FGUIManager.Instance).StartCoroutine(WaitWorldMapControllerInit());
	}

	private void InitIslandDisplay()
	{
		//IL_0102: Unknown result type (might be due to invalid IL or missing references)
		//IL_010c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0111: Unknown result type (might be due to invalid IL or missing references)
		//IL_011e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0123: Unknown result type (might be due to invalid IL or missing references)
		//IL_0128: Unknown result type (might be due to invalid IL or missing references)
		//IL_013e: Unknown result type (might be due to invalid IL or missing references)
		bool flag = _pageMode == Mode.Enroll;
		if (flag)
		{
			RefreshAllIslandEnrollCount();
		}
		else
		{
			int obCampId = Singleton<GvGMode3RoomManager>.Instance.ObserverRecord.ObCampId;
			foreach (ReviewResult reviewResult in _reviewResults)
			{
				_islandSignUpDatas[reviewResult.IslandId] = new BE_SignUpDataModel_ToProtocol3
				{
					IslandId = reviewResult.IslandId,
					CurCnt = reviewResult.GetCampSignUpCount(obCampId),
					MaxCnt = reviewResult.SignUpCountMax
				};
			}
		}
		foreach (int visibleIsland in _visibleIslands)
		{
			IslandDisplayBinding item = new IslandDisplayBinding(visibleIsland, this, !flag);
			_islandDisplays.Add(item);
		}
		_originPos = new Vector3((float)Screen.width, (float)Screen.height) * 0.5f;
		_cameraInitPos = _mainCamera.ScreenToWorldPoint(_originPos);
		_cameraInitSize = 15f;
		((GObject)infoContainer).position = Vector3.zero;
		((MonoBehaviour)FGUIManager.Instance).StartCoroutine(Update());
	}

	private void RefreshAllIslandEnrollCount()
	{
		if (_eventInfo.AllIslandDatas == null)
		{
			return;
		}
		foreach (BE_SignUpDataModel_ToProtocol3 allIslandData in _eventInfo.AllIslandDatas)
		{
			_islandSignUpDatas[allIslandData.IslandId] = allIslandData;
		}
	}

	private bool CheckConditionBrawlFight(ShipStateModel model)
	{
		if (!model.State.IsInWorld())
		{
			return false;
		}
		if (model.GroupSoldiersTotalSum <= 0)
		{
			return false;
		}
		return true;
	}

	private IEnumerator Update()
	{
		yield return null;
		bool isFirstInit = true;
		while (!((GObject)this).isDisposed)
		{
			if (((GObject)this).visible)
			{
				int frameCount = Time.frameCount;
				if (frameCount % 60 == 0)
				{
					if (_pageMode == Mode.Enroll && _eventInfo.GetStage() == C2S_BrawlEvent_GetInfo.Stage.Fighting)
					{
						RefreshWinnerIslandCountOnFighting();
					}
					if (State.selectedIndex == 3 && CurrentStage == C2S_BrawlEvent_GetInfo.Stage.Fighting)
					{
						State.SetSelectedIndex((int)CurrentStage);
					}
				}
				if (isFirstInit)
				{
					isFirstInit = false;
					float cameraSize = _mainCamera.orthographicSize;
					_mainCamera.orthographicSize = 15f;
					foreach (IslandDisplayBinding item in _islandDisplays)
					{
						item.Init();
					}
					Vector2 pos = ((GObject)infoContainer).GlobalToLocal(Vector2.op_Implicit(_originPos));
					((GObject)infoContainer.textInfo).position = Vector2.op_Implicit(pos);
					((GObject)infoContainer.textInfo).scale = Vector2.one * 1.6666666f;
					((GComponent)infoContainer).SetChildIndex((GObject)(object)infoContainer.textInfo, ((GComponent)infoContainer).numChildren - 1);
					_mainCamera.orthographicSize = cameraSize;
				}
				foreach (IslandDisplayBinding item2 in _islandDisplays)
				{
					item2.Step(frameCount);
				}
				UpdateDisplayPos();
			}
			yield return null;
		}
	}

	private void UpdateDisplayPos()
	{
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0012: Unknown result type (might be due to invalid IL or missing references)
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_002d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Unknown result type (might be due to invalid IL or missing references)
		//IL_0043: Unknown result type (might be due to invalid IL or missing references)
		//IL_0045: Unknown result type (might be due to invalid IL or missing references)
		//IL_0051: Unknown result type (might be due to invalid IL or missing references)
		//IL_0056: Unknown result type (might be due to invalid IL or missing references)
		//IL_005b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0062: Unknown result type (might be due to invalid IL or missing references)
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_007a: Unknown result type (might be due to invalid IL or missing references)
		//IL_007b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0080: Unknown result type (might be due to invalid IL or missing references)
		//IL_0085: Unknown result type (might be due to invalid IL or missing references)
		Vector3 val = _mainCamera.WorldToScreenPoint(_cameraInitPos);
		float num = _cameraInitSize / _mainCamera.orthographicSize;
		Vector3 val2 = val - _originPos;
		val2.y *= -1f;
		val2 += _originPos * (1f - num);
		((GObject)infoContainer).scale = Vector2.one * num;
		((GObject)infoContainer).position = Vector2.op_Implicit(((GObject)this).GlobalToLocal(Vector2.op_Implicit(val2)));
	}

	private void RefreshWinnerIslandCountOnFighting()
	{
		if (_eventInfo.AllIslandDatas == null)
		{
			return;
		}
		long num = UI_main_BrawlFightEnroll.GetBrawlEventTime() - _eventInfo.GetFightingTimeEnd;
		int num2 = 0;
		int num3 = 0;
		int obCampId = Singleton<GvGMode3RoomManager>.Instance.ObserverRecord.ObCampId;
		foreach (BE_SignUpDataModel_ToProtocol3 allIslandData in _eventInfo.AllIslandDatas)
		{
			if (allIslandData.WinnerCampId == obCampId && allIslandData.ReplayDuration <= num)
			{
				num2++;
			}
			num3 += allIslandData.CurCnt;
		}
		SetWinnerOverviewDisplay(num2, num3);
	}

	public void OnShow()
	{
	}

	public void BeforeDestroy()
	{
	}

	public void Destroy()
	{
		foreach (IslandDisplayBinding islandDisplay in _islandDisplays)
		{
			islandDisplay.OnDestroy();
		}
	}

	private void OnSelectIsland(int obj)
	{
		_blockIslandClick = true;
		((MonoBehaviour)FGUIManager.Instance).StartCoroutine(BlockIslandClick());
		if (obj != _selectIslandId && _visibleIslands.Contains(obj))
		{
			_selectIslandId = obj;
			CloseOperationPanel();
			RefreshOperationDialog();
		}
	}

	private void CloseOperationPanel()
	{
		if (_reopenCoroutine != null)
		{
			((MonoBehaviour)FGUIManager.Instance).StopCoroutine(_reopenCoroutine);
		}
		showOperationPanel.SetSelectedIndex(0);
	}

	private IEnumerator BlockIslandClick()
	{
		yield return (object)new WaitForSeconds(0.5f);
		_blockIslandClick = false;
	}

	private IEnumerator ReopenOperationPanel()
	{
		yield return (object)new WaitForSeconds(0.4f);
		_reopenCoroutine = null;
		if (_dataReady)
		{
			showOperationPanel.SetSelectedIndex(1);
		}
	}

	private void RefreshIslandBinding()
	{
		foreach (IslandDisplayBinding islandDisplay in _islandDisplays)
		{
			islandDisplay.RefreshIslandEnrollCount();
		}
	}

	private void RefreshBrawlFightBuff()
	{
		//IL_010e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0118: Expected O, but got Unknown
		//IL_0146: Unknown result type (might be due to invalid IL or missing references)
		//IL_0150: Expected O, but got Unknown
		bool isFinalMode = IsFinalMode;
		((GObject)buffBtn).visible = _pageMode == Mode.Enroll && isFinalMode;
		if (!((GObject)buffBtn).visible)
		{
			return;
		}
		_selfBuffs.Clear();
		_campBuffs.Clear();
		foreach (string item3 in ConfigDataManager.ItemsByType[ItemType.GvGMultiBattleBuff])
		{
			int itemCount = Singleton<GvGStoreHouseManager>.Instance.GetItemCount(item3);
			GDEItemData gDEItemData = GDMgr.Get<GDEItemData>(item3);
			BuffViewModel item = new BuffViewModel
			{
				Item = gDEItemData,
				Count = itemCount
			};
			eMultiBattleBuffType multiBattleBuffType = gDEItemData.GetMultiBattleBuffType();
			if (multiBattleBuffType.IsPlayerBuff())
			{
				_selfBuffs.Add(item);
			}
			else if (multiBattleBuffType.IsCampBuff())
			{
				_campBuffs.Add(item);
			}
		}
		buffContent.listSelf.itemRenderer = (ListItemRenderer)delegate(int index, GObject val)
		{
			BuffViewModel buffData = _selfBuffs[index];
			UI_com_buff item2 = (UI_com_buff)(object)val;
			RenderBuffItem(item2, buffData);
		};
		buffContent.listSelf.numItems = _selfBuffs.Count;
		buffContent.listCamp.itemRenderer = (ListItemRenderer)delegate(int index, GObject val)
		{
			BuffViewModel buffData = _campBuffs[index];
			UI_com_buff item2 = (UI_com_buff)(object)val;
			RenderBuffItem(item2, buffData);
		};
		buffContent.listCamp.numItems = _campBuffs.Count;
	}

	public static void RenderBuffItem(UI_com_buff item, BuffViewModel buffData)
	{
		//IL_00c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cc: Expected O, but got Unknown
		buffData.BuffObj = item;
		((GObject)item.rewardCount).text = $"Lv{buffData.Count}";
		item.itemIcon.url = buffData.Item.Icon.ToPublicResourcesRgbIcon();
		bool flag = buffData.Item.GetMultiBattleBuffType().IsCampBuff();
		item.showMode.SetSelectedIndex(1);
		item.effectRange.SetSelectedIndex(flag ? 1 : 0);
		item.isDeactivate.SetSelectedIndex((buffData.Count <= 0) ? 1 : 0);
		((GObject)item).onClick.Set((EventCallback0)delegate
		{
			//IL_0034: Unknown result type (might be due to invalid IL or missing references)
			buffData.Item.Key.DisplayItemTip(hideCheckBtn: true, new ItemTipParams
			{
				ItemCount = buffData.Count,
				SkillPopupPos = new Vector2(960f, 665f)
			});
		});
	}

	private void RefreshOperationDialog()
	{
		if (_selectIslandId > 0)
		{
			_dataReady = false;
			_reopenCoroutine = ((MonoBehaviour)FGUIManager.Instance).StartCoroutine(ReopenOperationPanel());
			int selectIslandId = _selectIslandId;
			if (_pageMode == Mode.Enroll)
			{
				LoadIslandDetailInfoFromServer(selectIslandId);
			}
			else
			{
				LoadIslandDetailInfoFromCache(selectIslandId);
			}
			IslandConfigData islandConfigData = WorldMapConfigHelper.Configs.TryGetIsland(selectIslandId);
			IslandStateModel islandStateModel = Singleton<WorldStateManager>.Instance.TryGetIsland(selectIslandId);
			if (islandStateModel.BrawlEvent != null)
			{
				((GObject)OperationDialog.islandName).text = islandConfigData.Name;
				C2S_BrawlEvent_GetInfo.Stage currentStage = CurrentStage;
				bool flag = currentStage >= C2S_BrawlEvent_GetInfo.Stage.EnrollFirstDay && currentStage <= C2S_BrawlEvent_GetInfo.Stage.WaitStart;
				OperationDialog.State.SetSelectedIndex((!flag) ? 1 : 0);
				int obCampId = Singleton<GvGMode3RoomManager>.Instance.ObserverRecord.ObCampId;
				OperationDialog.campType.SetSelectedIndex(obCampId);
			}
		}
	}

	private void LoadIslandDetailInfoFromServer(int islandId)
	{
		SocketManager.Instance.GetConnection(eConType.GvGMode3IslandManager).Request(new C2S_BrawlEvent_GetDetailInfoByIsland
		{
			Req = new C2S_BrawlEvent_GetDetailInfoByIsland.Request
			{
				IslandId = islandId
			}
		}, delegate(SocketManager.BaseSocketPackageBodyContext contextResponse)
		{
			C2S_BrawlEvent_GetDetailInfoByIsland.Response response = (C2S_BrawlEvent_GetDetailInfoByIsland.Response)contextResponse.Resp;
			if (response.ErrorCode != 0)
			{
				ILRequestHelper.ShowErrorCode(response.ErrorCode);
			}
			else
			{
				response.MissionConfigId = Singleton<WorldStateManager>.Instance.TryGetIsland(islandId).BrawlEvent.MConfigId;
				OnIslandDetailLoadComplete(islandId, response);
			}
		});
	}

	private void LoadIslandDetailInfoFromCache(int islandId)
	{
		ReviewResult reviewResult = _reviewResults.Find((ReviewResult r) => r.IslandId == islandId);
		int obCampId = Singleton<GvGMode3RoomManager>.Instance.ObserverRecord.ObCampId;
		List<BrawlEventRankRewardsConfig_ToProtocol> finalRewards = null;
		if (reviewResult.FirstFinalReward != null)
		{
			finalRewards = new List<BrawlEventRankRewardsConfig_ToProtocol>
			{
				new BrawlEventRankRewardsConfig_ToProtocol
				{
					Rewards = new List<RItem> { reviewResult.FirstFinalReward }
				}
			};
		}
		eRace playerSignUpShipRaceByIslandId = _reviewInfo.GetPlayerSignUpShipRaceByIslandId(islandId);
		C2S_BrawlEvent_GetDetailInfoByIsland.Response res = new C2S_BrawlEvent_GetDetailInfoByIsland.Response
		{
			IslandId = islandId,
			CampSignUpCountNow = reviewResult.GetCampSignUpCount(obCampId),
			CampSignUpCountMax = reviewResult.SignUpCountMax,
			SignUpShipRace = (int)playerSignUpShipRaceByIslandId,
			IslandSubType = reviewResult.MissionSubType,
			HasSignUpOnThisIsland = (playerSignUpShipRaceByIslandId > eRace.Invalid),
			MUID = reviewResult.MUID,
			ReplayDuration = reviewResult.ReplayDuration,
			FinalRewards = finalRewards,
			MissionConfigId = reviewResult.MConfigId
		};
		OnIslandDetailLoadComplete(islandId, res);
	}

	private void OnIslandDetailLoadComplete(int islandId, C2S_BrawlEvent_GetDetailInfoByIsland.Response res)
	{
		_dataReady = true;
		if (_reopenCoroutine == null)
		{
			showOperationPanel.SetSelectedIndex(1);
		}
		_islandDetailInfo = res;
		_eventInfo.UpdateAllIslandDatas(islandId, res.CampSignUpCountNow, res.CampSignUpCountMax);
		RefreshIslandBinding();
		showOperationPanel.SetSelectedIndex(1);
		OperationDialog.hasMyShip.SetSelectedIndex(res.HasSignUpOnThisIsland ? 1 : 0);
		if (res.HasSignUpOnThisIsland)
		{
			OperationDialog.hasMyShipIcon.Icon.url = UI_com_ShipList.GetShipIconUrlByRace(res.SignUpShipRace);
		}
		int campSignUpCountMax = res.CampSignUpCountMax;
		int campSignUpCountNow = res.CampSignUpCountNow;
		string text = $"{campSignUpCountNow}/{campSignUpCountMax}";
		((GObject)OperationDialog.shipCount).text = text;
		List<BrawlEventRankRewardsConfig_ToProtocol> finalRewards = res.FinalRewards;
		bool flag = finalRewards != null && finalRewards.Count > 0;
		OperationDialog.hasAward.SetSelectedIndex(flag ? 1 : 0);
		if (flag)
		{
			RItem upReward = res.FinalRewards[0].Rewards[0];
			OperationDialog.rewardGroup.SetUpReward(upReward);
		}
		GvGMode3EventMissionConfigModel gvGMode3EventMissionConfigModel = GvG3FlagShipMissionsConfigHelper.EventMissionConfig(res.MissionConfigId);
		long ampScoreLimit = gvGMode3EventMissionConfigModel.BrawlSubTypeData.AmpScoreLimit;
		bool flag2 = ampScoreLimit > 0;
		OperationDialog.hasCondition.SetSelectedIndex(flag2 ? 1 : 0);
		if (flag2)
		{
			((GObject)OperationDialog.condition.ampScore).text = ampScoreLimit.ToString();
		}
		((GObject)OperationDialog.enterBtn).grayed = !res.HasBattleReplay();
		eGvGMode3CampMissionSubType subType = res.GetSubType();
		OperationDialog.modeType.SetSelectedIndex((subType != eGvGMode3CampMissionSubType.RE_FactionWar) ? 1 : 0);
	}

	private void OnUiClose(string uiName)
	{
		if (!(uiName == UI_main_BrawlFightSelectPosition.Name))
		{
			return;
		}
		Task<C2S_BrawlEvent_GetInfo.Response> task = UI_main_BrawlFightEnroll.GetBrawlEventInfo();
		task.GetAwaiter().OnCompleted(delegate
		{
			if (task.Result != null)
			{
				C2S_BrawlEvent_GetInfo.Response result = task.Result;
				_eventInfo.SelfSignUpDatas = result.SelfSignUpDatas;
				_eventInfo.AllIslandDatas = result.AllIslandDatas;
				_eventInfo.ClaimedInfos = result.ClaimedInfos;
				RefreshAllIslandEnrollCount();
			}
			ShipList.SingleSelectIndex = -1;
			ShipList.Refresh();
			int selectIslandId = _selectIslandId;
			_selectIslandId = -1;
			OnSelectIsland(selectIslandId);
			RefreshEnrollStatus();
			RefreshIslandBinding();
		});
		ShipList.SingleSelectIndex = -1;
		ShipList.Refresh();
		OnSelectIsland(_selectIslandId);
		RefreshEnrollStatus();
		RefreshOperationDialog();
	}

	private void InitShipList()
	{
		C2S_BrawlEvent_GetInfo.Stage currentStage = CurrentStage;
		bool viewOnly = currentStage == C2S_BrawlEvent_GetInfo.Stage.WaitStart || currentStage == C2S_BrawlEvent_GetInfo.Stage.Fighting;
		_shipDatas = new List<UI_com_ShipList.ShipBattleStrategy>();
		if (_pageMode == Mode.Review)
		{
			_reviewResults = _reviewInfo.ReviewResults;
			_reviewTotals = _reviewInfo.ReviewTotals;
			foreach (ReviewResult reviewResult in _reviewResults)
			{
				_reviewResultLut[reviewResult.IslandId] = reviewResult;
			}
			if (_reviewInfo.SignUpDatas != null)
			{
				foreach (BE_SignUpDataModel_ToProtocol signUpData in _reviewInfo.SignUpDatas)
				{
					GvGMode3ShipModel ship = new GvGMode3ShipModel
					{
						ShipId = signUpData.ShipId,
						PermanentData = new GvGMode3ShipPermanentData
						{
							ShipRace = signUpData.ShipRace,
							ShipName = signUpData.ShipName
						}
					};
					UI_com_ShipList.ShipBattleStrategy item = new UI_com_ShipList.ShipBattleStrategy
					{
						Ship = ship,
						BattleStrategy = signUpData.BattleStrategy,
						Enable = true
					};
					_shipDatas.Add(item);
				}
			}
			C2S_BrawlEvent_GetInfo.Response eventInfo = new C2S_BrawlEvent_GetInfo.Response
			{
				StepIdx = _reviewInfo.StepIdx,
				SelfSignUpDatas = _reviewInfo.SignUpDatas
			};
			ShipList.Init(eventInfo, _shipDatas, viewOnly: true);
			return;
		}
		List<GvGMode3ShipModel> ships = Singleton<GvGMode3RoomManager>.Instance.ObserverRecord.Ships;
		foreach (GvGMode3ShipModel ship2 in ships)
		{
			int entityId = ship2.TemporaryData.EntityId;
			ShipStateModel shipStateModel = Singleton<WorldStateManager>.Instance.TryGetShip(entityId);
			if (shipStateModel != null)
			{
				bool enable = CheckConditionBrawlFight(shipStateModel);
				int battleStrategy = (_eventInfo.SelfSignUpDatas?.Find((BE_SignUpDataModel_ToProtocol x) => x.ShipId == ship2.ShipId))?.BattleStrategy ?? 0;
				Singleton<GvGAmplifierManager>.Instance.GetShipAmplifiers(ship2.ShipId);
				_shipDatas.Add(new UI_com_ShipList.ShipBattleStrategy
				{
					Ship = ship2,
					BattleStrategy = battleStrategy,
					Enable = enable
				});
			}
		}
		ShipList.Init(_eventInfo, _shipDatas, viewOnly);
	}

	private void RefreshEnrollStatus()
	{
		if (_pageMode == Mode.Enroll)
		{
			UI_main_BrawlFightEnroll.RefreshEnrollStatus(enrollStatus, _eventInfo, _config);
			return;
		}
		int selfShipCount = _reviewInfo.SignUpDatas?.Count ?? 0;
		UI_main_BrawlFightEnroll.RefreshEnrollStatus(enrollStatus, selfShipCount, _config);
	}

	private void RefreshWinnerOverView()
	{
		if (_pageMode == Mode.Review)
		{
			int myCamp = Singleton<GvGMode3RoomManager>.Instance.ObserverRecord.ObCampId;
			ReviewTotal reviewTotal = _reviewTotals?.Find((ReviewTotal x) => x.CampId == myCamp);
			if (reviewTotal == null)
			{
				SetWinnerOverviewDisplay(0, 0);
			}
			else
			{
				SetWinnerOverviewDisplay(reviewTotal.WinnerIsland, reviewTotal.FightingShipCount);
			}
		}
		else
		{
			RefreshWinnerIslandCountOnFighting();
		}
	}

	private void SetWinnerOverviewDisplay(int islandCount, int shipCount)
	{
		int obCampId = Singleton<GvGMode3RoomManager>.Instance.ObserverRecord.ObCampId;
		HoldingPercents.CampId.SetSelectedIndex(obCampId);
		((GObject)HoldingPercents.islandOccupiedCount).text = $"{islandCount}";
		((GObject)HoldingPercents.ShipCount).text = $"{shipCount}";
	}

	public void OnDragBegin(EventContext context)
	{
		GvGWorldMapController.Instance.InputManager.UpdateInput();
		context.CaptureTouch();
	}

	public void OnDrag(EventContext context)
	{
		GvGWorldMapController.Instance.InputManager.UpdateInput();
	}

	public void OnDragEnd(EventContext context)
	{
		GvGWorldMapController.Instance.InputManager.UpdateInput();
		context.CaptureTouch();
	}

	private void OnClickRayMask(EventContext context)
	{
		//IL_0031: Unknown result type (might be due to invalid IL or missing references)
		//IL_0036: Unknown result type (might be due to invalid IL or missing references)
		//IL_003b: Unknown result type (might be due to invalid IL or missing references)
		//IL_003e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0044: Unknown result type (might be due to invalid IL or missing references)
		//IL_0050: Unknown result type (might be due to invalid IL or missing references)
		if (infoContainer.showCenterText.selectedIndex == 1)
		{
			UI_btn_exit closeBtn = infoContainer.textInfo.closeBtn;
			Vector2 val = ((GObject)closeBtn).GlobalToLocal(context.inputEvent.position);
			Rect val2 = default(Rect);
			((Rect)(ref val2))._002Ector(Vector2.zero, ((GObject)closeBtn).size);
			if (((Rect)(ref val2)).Contains(val))
			{
				OnClickCloseFinalOneTip();
				return;
			}
		}
		if (ShipList.SingleSelectIndex >= 0)
		{
			ShipList.SingleSelectIndex = -1;
			ShipList.Refresh();
		}
		else if (ShipList.IsSelectStrategyPanelOpen)
		{
			ShipList.OnClickCloseStrategyPanel();
		}
		else if (_selectIslandId > 0 && !_blockIslandClick)
		{
			_selectIslandId = -1;
			CloseOperationPanel();
		}
		else if (isShowBuff.selectedIndex == 1)
		{
			isShowBuff.SetSelectedIndex(0);
		}
	}

	private void OnClickShowBattleLog()
	{
		GameController.Contexts.Service<IUiService>().OpenPanel(UI_main_IslandBattleRecordPanel.Name, new Dictionary<string, object> { { "IslandId", _selectIslandId } });
	}

	private void OnClickHelpBtn()
	{
		IslandStateModel islandStateModel = Singleton<WorldStateManager>.Instance.TryGetIsland(_selectIslandId);
		bool isFinalMode = IsFinalMode;
		UI_main_BrawlIslandBonusPreview.OpenBrawlIslandBonusPreview(new BrawlPreviewBonusParams
		{
			MissionConfigId = islandStateModel.BrawlEvent.MConfigId,
			IslandSubType = _islandDetailInfo.IslandSubType,
			MUID = _islandDetailInfo.MUID,
			IsFinal = isFinalMode
		});
	}

	private void OnClickGoEnroll()
	{
		UnityUiService.Instance.OpenPanel(UI_main_BrawlFightSelectPosition.Name, new Dictionary<string, object>
		{
			{ "GvGBrawlEventInfo", _eventInfo },
			{ "IslandId", _selectIslandId },
			{ "ShipDatas", _shipDatas },
			{ "DetailData", _islandDetailInfo }
		});
	}

	private void OnClickGoStreaming()
	{
		if (!_islandDetailInfo.HasBattleReplay())
		{
			"BrawlFightBattleReplayEmptyTip".ToLanguage().ToTip();
			return;
		}
		bool isStreaming = false;
		if (_pageMode == Mode.Enroll)
		{
			isStreaming = CurrentStage == C2S_BrawlEvent_GetInfo.Stage.Fighting;
		}
		UI_main_GvGIslandBrawlFight.ReplayParam value = new UI_main_GvGIslandBrawlFight.ReplayParam
		{
			IslandId = _selectIslandId,
			IsStreaming = isStreaming,
			DetailInfo = _islandDetailInfo,
			EventInfo = _eventInfo,
			StepIndex = ((_pageMode == Mode.Enroll) ? _eventInfo.StepIdx : _reviewInfo.StepIdx)
		};
		UnityUiService.Instance.OpenPanel(UI_main_GvGIslandBrawlFight.Name, new Dictionary<string, object> { { "ReplayParam", value } });
	}

	private void OnClickCancelEnroll(string shipId)
	{
		CloseOperationPanel();
		UI_main_BrawlFightSelectPosition.OnClickCancelEnroll(shipId, _eventInfo, delegate(C2S_BrawlEvent_Cancel.Response res)
		{
			if (_islandSignUpDatas.TryGetValue(res.CancelIslandId, out var value))
			{
				value.CurCnt = res.SignUpDatas?.Count ?? 0;
			}
			ShipList.SingleSelectIndex = -1;
			RefreshEnrollStatus();
			ShipList.Refresh();
			RefreshIslandBinding();
		});
	}

	private void OnClickChangeStrategy(UI_com_ShipList.ShipBattleStrategy shipData)
	{
		UI_main_BrawlFightSelectPosition.OnClickChangeStrategy(shipData, _eventInfo, delegate(C2S_BrawlEvent_SignUp.Response res)
		{
			_eventInfo.SelfSignUpDatas = res.SelfSignUpDatas;
			ShipList.SingleSelectIndex = -1;
			ShipList.Refresh();
		});
	}

	private void OnSliderValueChange()
	{
		if (GvGWorldMapController.IsInstanceCreated)
		{
			GvGWorldMapController.Instance.CameraBindingManager.CamSize = Slider.Value;
		}
	}

	private void OnClickAddBtn()
	{
		Slider.Value -= _sliderAddStep;
	}

	private void OnClickMinusBtn()
	{
		Slider.Value += _sliderAddStep;
	}

	private void OnPinchBegin()
	{
		_currentSliderValue = Slider.Percent;
	}

	private void OnClickCloseFinalOneTip()
	{
		infoContainer.showCenterText.SetSelectedIndex(0);
	}

	private void OnPinch(float pinchDelta)
	{
		if (IsFinalMode)
		{
			Slider.Percent = _currentSliderValue + (pinchDelta - 1f);
		}
	}

	private void OnPinchEnd()
	{
	}

	private void End()
	{
		GvGWorldMapController.Instance.SetIslandGroup(0);
		GvGWorldMapController.Instance.InputManager.DisablePinch = false;
		if (IsFinalMode)
		{
			Singleton<WorldStateManager>.Instance.SetMyCampIslandVisible(isVisible: true);
		}
		Singleton<WorldStateManager>.Instance.SetAdditionalVisibleIslands(null);
		Singleton<WorldStateManager>.Instance.SetIslandHideNameAndState(_visibleIslands, hide: false);
		GvGWorldMapController.Instance.BackgroundManager.ChangeSpace();
		UnityUiService.Instance.ClosePanel(Name);
		UnityUiService.Instance.HideUis(HideUi, uiVisible: true);
	}

	private void ForceClose()
	{
		GvGWorldMapController.Instance.SetIslandGroup(0);
		GvGWorldMapController.Instance.InputManager.DisablePinch = false;
		if (IsFinalMode)
		{
			Singleton<WorldStateManager>.Instance.SetMyCampIslandVisible(isVisible: true);
		}
		Singleton<WorldStateManager>.Instance.SetAdditionalVisibleIslands(null);
		Singleton<WorldStateManager>.Instance.SetIslandHideNameAndState(_visibleIslands, hide: false);
		GvGWorldMapController.Instance.BackgroundManager.ChangeSpace();
		UnityUiService.Instance.ClosePanel(Name);
		UnityUiService.Instance.HideUis(HideUi, uiVisible: true);
	}

	public static Vector2 ScreenToGlobalPos(Vector2 screenPos)
	{
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_0016: Unknown result type (might be due to invalid IL or missing references)
		//IL_0019: Unknown result type (might be due to invalid IL or missing references)
		screenPos.y = (float)Screen.height - screenPos.y;
		return screenPos;
	}
}
