using System;
using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;
using HotFix.Sources.Base.Scripts.Helper;
using HotFix.Sources.Base.Sources.Scripts.GvG3.GvG3UI.Helper;
using HotFix.Sources.Base.Sources.Scripts.GvG3.GvG3UI.Interface.Brawl;
using HotFix.Sources.Base.Sources.Scripts.GvG3.GvG3UI.Model.UserProfile;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Helper;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Manager;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Model;
using HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Helper;
using HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Manager;
using HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Model;
using Shift.Legion.Common.Helpers;
using Shift.Legion.Common.Managers;
using Shift.Legion.GvG.Common.Enums;
using Shift.Legion.GvG.Common.Models.GvGMode3.BrawlEvent;
using Shift.Legion.GvG.Common.Models.GvGMode3.Mission;
using Shift.Legion.GvG.Common.Models.GvGMode3.Mission.BrawlEvent;
using Shift.Legion.GvGServer.Models.GvGMode3IslandManagerSocket.Mission;
using UnityEngine;

namespace UI.GvGBrawlFight;

public class UI_main_BrawlFightSelectPosition : GComponent, IUiController
{
	private class ViewModel
	{
		public bool IsSelf;

		public BE_SignUpDataModel_ToProtocol SelfData;

		public BE_SignUpDataModel_ToProtocol2 OtherData;
	}

	private enum SlotMode
	{
		Mode5x5,
		Mode6x6
	}

	private enum DragMode
	{
		Empty,
		Enroll,
		Exchange,
		Relocate,
		Block
	}

	public Controller isDrag;

	public Controller showConfirmBtn;

	public Controller isPreview;

	public Controller hasCondition;

	public GLoader background;

	public GGraph RayMask;

	public GGraph back;

	public GImage n19;

	public GTextField n20;

	public GTextField n22;

	public GGroup n21;

	public GImage n25;

	public GTextField n24;

	public GGroup n26;

	public UI_com_ShipPositions positionList;

	public UI_com_EnrollStatus02 enrollStatus;

	public UI_com_ShipList ShipList;

	public GButton BackBtn;

	public UI_com_dragShipIcon dragShipIcon;

	public UI_dec_04 n23;

	public GButton confirmEnrollBtn;

	public UI_com_conditionGroup condition;

	public Transition t0;

	public const string URL = "ui://hozu168rvb402b";

	public static string Name = "UI_main_BrawlFightSelectPosition";

	public const string ISLAND_ID = "IslandId";

	public const string SHIP_DATAS = "ShipDatas";

	public const string DETAIL_DATA = "DetailData";

	private C2S_BrawlEvent_GetInfo.Response _eventInfo;

	private GvGMode3BrawlEvent_BaseInfo _config;

	private List<UI_com_ShipList.ShipBattleStrategy> _shipDatas;

	private C2S_BrawlEvent_GetDetailInfoByIsland.Response _islandDetailInfo;

	private int _selectIslandId;

	private C2S_BrawlEvent_GetSignUpInfoByIsland.Response _enrollInfo;

	private UI_com_ShipList.ShipBattleStrategy _selectShip;

	private IShipPosition _currentSelectSlot;

	private List<IShipPosition> _currentSlots;

	private List<Rect> _slotRects = new List<Rect>();

	private List<int> _allIndexes = new List<int>();

	private List<ViewModel> _viewModels;

	private UI_com_ShipList.ShipBattleStrategy _pendingShip;

	private string _cacheId;

	private bool _isViewOnly;

	private DragMode _dragMode;

	private int _relocateFormIndex;

	private bool _showCancelBtn;

	private int _slotPerCol;

	private SlotMode _currentMode;

	private bool IsPendingConfirm => _pendingShip != null;

	public static string GetURL()
	{
		return "ui://hozu168rvb402b";
	}

	public static UI_main_BrawlFightSelectPosition CreateInstance()
	{
		return (UI_main_BrawlFightSelectPosition)(object)UIPackage.CreateObject("GvGBrawlFight", "main_BrawlFightSelectPosition");
	}

	public static UI_main_BrawlFightSelectPosition CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_main_BrawlFightSelectPosition).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://hozu168rvb402b", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0059: Unknown result type (might be due to invalid IL or missing references)
		//IL_0063: Expected O, but got Unknown
		//IL_006f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0079: Expected O, but got Unknown
		//IL_0085: Unknown result type (might be due to invalid IL or missing references)
		//IL_008f: Expected O, but got Unknown
		//IL_009b: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a5: Expected O, but got Unknown
		//IL_00b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bb: Expected O, but got Unknown
		//IL_0104: Unknown result type (might be due to invalid IL or missing references)
		//IL_010e: Expected O, but got Unknown
		//IL_0157: Unknown result type (might be due to invalid IL or missing references)
		//IL_0161: Expected O, but got Unknown
		//IL_016d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0177: Expected O, but got Unknown
		//IL_0183: Unknown result type (might be due to invalid IL or missing references)
		//IL_018d: Expected O, but got Unknown
		//IL_01d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e0: Expected O, but got Unknown
		//IL_022e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0238: Expected O, but got Unknown
		//IL_0270: Unknown result type (might be due to invalid IL or missing references)
		//IL_027a: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		isDrag = ((GComponent)this).GetController("isDrag");
		showConfirmBtn = ((GComponent)this).GetController("showConfirmBtn");
		isPreview = ((GComponent)this).GetController("isPreview");
		hasCondition = ((GComponent)this).GetController("hasCondition");
		background = (GLoader)((GComponent)this).GetChild("background");
		RayMask = (GGraph)((GComponent)this).GetChild("RayMask");
		back = (GGraph)((GComponent)this).GetChild("back");
		n19 = (GImage)((GComponent)this).GetChild("n19");
		n20 = (GTextField)((GComponent)this).GetChild("n20");
		string id = "ui://hozu168rvb402b".Replace("ui://", "") + "-" + ((GObject)n20).id;
		((GObject)n20).text = LanguagesManager.GetDesc(id);
		n22 = (GTextField)((GComponent)this).GetChild("n22");
		string id2 = "ui://hozu168rvb402b".Replace("ui://", "") + "-" + ((GObject)n22).id;
		((GObject)n22).text = LanguagesManager.GetDesc(id2);
		n21 = (GGroup)((GComponent)this).GetChild("n21");
		n25 = (GImage)((GComponent)this).GetChild("n25");
		n24 = (GTextField)((GComponent)this).GetChild("n24");
		string id3 = "ui://hozu168rvb402b".Replace("ui://", "") + "-" + ((GObject)n24).id;
		((GObject)n24).text = LanguagesManager.GetDesc(id3);
		n26 = (GGroup)((GComponent)this).GetChild("n26");
		positionList = (UI_com_ShipPositions)(object)((GComponent)this).GetChild("positionList");
		enrollStatus = (UI_com_EnrollStatus02)(object)((GComponent)this).GetChild("enrollStatus");
		ShipList = (UI_com_ShipList)(object)((GComponent)this).GetChild("ShipList");
		BackBtn = (GButton)((GComponent)this).GetChild("BackBtn");
		dragShipIcon = (UI_com_dragShipIcon)(object)((GComponent)this).GetChild("dragShipIcon");
		n23 = (UI_dec_04)(object)((GComponent)this).GetChild("n23");
		confirmEnrollBtn = (GButton)((GComponent)this).GetChild("confirmEnrollBtn");
		condition = (UI_com_conditionGroup)(object)((GComponent)this).GetChild("condition");
		t0 = ((GComponent)this).GetTransition("t0");
	}

	public void RegisterUiEventListeners()
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected O, but got Unknown
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_003a: Expected O, but got Unknown
		//IL_0048: Unknown result type (might be due to invalid IL or missing references)
		//IL_0052: Expected O, but got Unknown
		//IL_006a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0074: Expected O, but got Unknown
		((GObject)BackBtn).onClick.Set(new EventCallback0(End));
		((GObject)confirmEnrollBtn).onClick.Set(new EventCallback0(OnClickConfirmEnroll));
		((GObject)this).onClick.Set(new EventCallback0(OnClickRayMask));
		((GObject)enrollStatus.helpBtn).onClick.Set(new EventCallback0(OnClickHelpBtn));
		UI_com_ShipList shipList = ShipList;
		shipList.onPointerDown = (Action<UI_com_ShipInfo, UI_com_ShipList.ShipBattleStrategy, EventContext>)Delegate.Combine(shipList.onPointerDown, new Action<UI_com_ShipInfo, UI_com_ShipList.ShipBattleStrategy, EventContext>(OnShipPointerDown));
		UI_com_ShipList shipList2 = ShipList;
		shipList2.onPointerMove = (Action<EventContext>)Delegate.Combine(shipList2.onPointerMove, new Action<EventContext>(OnTouchMove));
		UI_com_ShipList shipList3 = ShipList;
		shipList3.onPointerUp = (Action<EventContext>)Delegate.Combine(shipList3.onPointerUp, new Action<EventContext>(OnTouchEnd));
		UI_com_ShipList shipList4 = ShipList;
		shipList4.onClickCancelEnroll = (Action<string>)Delegate.Combine(shipList4.onClickCancelEnroll, new Action<string>(OnShipListCancelEnroll));
		UI_com_ShipList shipList5 = ShipList;
		shipList5.OnClickChangeStrategy = (Action<UI_com_ShipList.ShipBattleStrategy>)Delegate.Combine(shipList5.OnClickChangeStrategy, new Action<UI_com_ShipList.ShipBattleStrategy>(OnClickChangeStrategy));
		GvGMode3RoomManager instance = Singleton<GvGMode3RoomManager>.Instance;
		instance.OnRoomClose = (Action)Delegate.Combine(instance.OnRoomClose, new Action(End));
	}

	public void UnregisterUiEventListeners()
	{
		((GObject)BackBtn).onClick.Clear();
		((GObject)confirmEnrollBtn).onClick.Clear();
		((GObject)this).onClick.Clear();
		((GObject)enrollStatus.helpBtn).onClick.Clear();
		UI_com_ShipList shipList = ShipList;
		shipList.onPointerDown = (Action<UI_com_ShipInfo, UI_com_ShipList.ShipBattleStrategy, EventContext>)Delegate.Remove(shipList.onPointerDown, new Action<UI_com_ShipInfo, UI_com_ShipList.ShipBattleStrategy, EventContext>(OnShipPointerDown));
		UI_com_ShipList shipList2 = ShipList;
		shipList2.onPointerMove = (Action<EventContext>)Delegate.Remove(shipList2.onPointerMove, new Action<EventContext>(OnTouchMove));
		UI_com_ShipList shipList3 = ShipList;
		shipList3.onPointerUp = (Action<EventContext>)Delegate.Remove(shipList3.onPointerUp, new Action<EventContext>(OnTouchEnd));
		UI_com_ShipList shipList4 = ShipList;
		shipList4.onClickCancelEnroll = (Action<string>)Delegate.Remove(shipList4.onClickCancelEnroll, new Action<string>(OnShipListCancelEnroll));
		UI_com_ShipList shipList5 = ShipList;
		shipList5.OnClickChangeStrategy = (Action<UI_com_ShipList.ShipBattleStrategy>)Delegate.Remove(shipList5.OnClickChangeStrategy, new Action<UI_com_ShipList.ShipBattleStrategy>(OnClickChangeStrategy));
		GvGMode3RoomManager instance = Singleton<GvGMode3RoomManager>.Instance;
		instance.OnRoomClose = (Action)Delegate.Remove(instance.OnRoomClose, new Action(End));
	}

	public void Init(Dictionary<string, object> parameters)
	{
		FGUIManager.SetUiPanelSizeAndXy((GObject)(object)this, scaleAdaption: true);
		_eventInfo = (C2S_BrawlEvent_GetInfo.Response)parameters["GvGBrawlEventInfo"];
		_shipDatas = (List<UI_com_ShipList.ShipBattleStrategy>)parameters["ShipDatas"];
		_islandDetailInfo = (C2S_BrawlEvent_GetDetailInfoByIsland.Response)parameters["DetailData"];
		_config = WorldMapConfigHelper.Configs.TryGetBrawlEvent(_eventInfo.StepIdx);
		_selectIslandId = (int)parameters["IslandId"];
		_viewModels = new List<ViewModel>();
		_dragMode = DragMode.Empty;
		_allIndexes = new List<int>();
		_isViewOnly = _eventInfo.GetStage() == C2S_BrawlEvent_GetInfo.Stage.WaitStart;
		_cacheId = $"{Singleton<GvGMode3RoomManager>.Instance.ObserverRecord.CurIZId}";
		_currentMode = ((_islandDetailInfo.CampSignUpCountMax != 25) ? SlotMode.Mode6x6 : SlotMode.Mode5x5);
		_slotPerCol = ((_currentMode == SlotMode.Mode5x5) ? 5 : 6);
		isPreview.SetSelectedIndex(_isViewOnly ? 1 : 0);
		IslandStateModel islandStateModel = Singleton<WorldStateManager>.Instance.TryGetIsland(_selectIslandId);
		string mConfigId = islandStateModel.BrawlEvent.MConfigId;
		ShipList.Init(_eventInfo, _shipDatas, _isViewOnly, mConfigId);
		InitShipSlots();
		GetEnrollInfo();
		RenderPendingShip();
		((GObject)enrollStatus.IslandName).text = WorldMapConfigHelper.Configs.TryGetIsland(_selectIslandId).Name;
		bool flag = _islandDetailInfo.GetSubType() == eGvGMode3CampMissionSubType.RE_FFA;
		enrollStatus.modeType.SetSelectedIndex(flag ? 1 : 0);
		GvGMode3EventMissionConfigModel gvGMode3EventMissionConfigModel = GvG3FlagShipMissionsConfigHelper.EventMissionConfig(_islandDetailInfo.MissionConfigId);
		long ampScoreLimit = gvGMode3EventMissionConfigModel.BrawlSubTypeData.AmpScoreLimit;
		bool flag2 = ampScoreLimit > 0;
		hasCondition.SetSelectedIndex(flag2 ? 1 : 0);
		if (flag2)
		{
			((GObject)condition.ampScore).text = ampScoreLimit.ToString();
		}
		((MonoBehaviour)FGUIManager.Instance).StartCoroutine(UpdateEnrollInfos());
	}

	public void OnShow()
	{
	}

	public void BeforeDestroy()
	{
	}

	public void Destroy()
	{
	}

	private void OnClickConfirmEnroll()
	{
		DoEnroll();
	}

	private void InitShipSlots()
	{
		//IL_00fa: Unknown result type (might be due to invalid IL or missing references)
		//IL_0101: Unknown result type (might be due to invalid IL or missing references)
		//IL_0111: Unknown result type (might be due to invalid IL or missing references)
		_currentSlots = new List<IShipPosition>();
		GGroup val = ((_currentMode == SlotMode.Mode5x5) ? positionList.group5x5 : positionList.group6x6);
		positionList.slotMode.SetSelectedIndex((int)_currentMode);
		GObject[] children = ((GComponent)positionList).GetChildren();
		foreach (GObject val2 in children)
		{
			GGroup val3 = val2.group;
			if (val3 == val)
			{
				if (val2 is UI_com_ShipPositionSlot item)
				{
					_currentSlots.Add(item);
				}
				else if (val2 is UI_com_ShipPositionSlot02 item2)
				{
					_currentSlots.Add(item2);
				}
			}
		}
		int count = _currentSlots.Count;
		Rect item3 = default(Rect);
		for (int j = 0; j < count; j++)
		{
			IShipPosition shipPosition = _currentSlots[j];
			shipPosition.Index = j;
			((Rect)(ref item3))._002Ector(shipPosition.Position, shipPosition.Size);
			_slotRects.Add(item3);
			_allIndexes.Add(j);
		}
	}

	private void RefreshSlot()
	{
		if (((GObject)this).isDisposed)
		{
			return;
		}
		_viewModels.Clear();
		int count = _currentSlots.Count;
		for (int i = 0; i < count; i++)
		{
			_viewModels.Add(null);
		}
		if (_enrollInfo.SignUpDatas != null)
		{
			foreach (BE_SignUpDataModel_ToProtocol2 signUpData in _enrollInfo.SignUpDatas)
			{
				ViewModel value = new ViewModel
				{
					IsSelf = false,
					OtherData = signUpData
				};
				_viewModels[signUpData.ZoneId] = value;
			}
		}
		if (_enrollInfo.SelfSignUpDatas != null && _enrollInfo.SelfSignUpDatas.Count > 0)
		{
			foreach (BE_SignUpDataModel_ToProtocol selfSignUpData in _enrollInfo.SelfSignUpDatas)
			{
				if (selfSignUpData.IslandId == _islandDetailInfo.IslandId)
				{
					ViewModel value2 = new ViewModel
					{
						IsSelf = true,
						SelfData = selfSignUpData
					};
					_viewModels[selfSignUpData.ZoneId] = value2;
				}
			}
		}
		AddPendingShip();
		RenderViewModel();
	}

	private void RenderViewModel()
	{
		int count = _currentSlots.Count;
		for (int i = 0; i < count; i++)
		{
			IShipPosition slot = _currentSlots[i];
			RenderSlot(slot);
		}
	}

	private void RenderSlot(IShipPosition slot)
	{
		//IL_00d0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00da: Expected O, but got Unknown
		//IL_00dd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_010d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0117: Expected O, but got Unknown
		//IL_0136: Unknown result type (might be due to invalid IL or missing references)
		//IL_0140: Expected O, but got Unknown
		//IL_015e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0168: Expected O, but got Unknown
		//IL_03fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0407: Expected O, but got Unknown
		if (slot == null)
		{
			return;
		}
		bool flag = _dragMode != DragMode.Empty;
		int index = slot.Index;
		if (string.IsNullOrEmpty(((GObject)slot.GetSlotName).text))
		{
			slot.GetThis.touchable = !_isViewOnly;
			((GObject)slot.GetSlotName).text = GetSlotName(index);
			slot.GetThis.onClick.Set((EventCallback1)delegate(EventContext x)
			{
				OnClickSlot(x, slot);
			});
			Vector2 startPos = Vector2.zero;
			bool isMove = false;
			slot.GetThis.onTouchBegin.Set((EventCallback1)delegate(EventContext x)
			{
				//IL_0008: Unknown result type (might be due to invalid IL or missing references)
				//IL_000d: Unknown result type (might be due to invalid IL or missing references)
				startPos = x.inputEvent.position;
				isMove = false;
				x.CaptureTouch();
			});
			slot.GetThis.onTouchMove.Set((EventCallback1)delegate(EventContext x)
			{
				//IL_0007: Unknown result type (might be due to invalid IL or missing references)
				//IL_000d: Unknown result type (might be due to invalid IL or missing references)
				//IL_0012: Unknown result type (might be due to invalid IL or missing references)
				//IL_0017: Unknown result type (might be due to invalid IL or missing references)
				Vector2 val = x.inputEvent.position - startPos;
				float magnitude = ((Vector2)(ref val)).magnitude;
				if (magnitude > 10f && !isMove)
				{
					OnSlotPointerDown(x, slot);
					isMove = true;
				}
				OnTouchMove(x);
			});
			slot.GetThis.onTouchEnd.Set(new EventCallback1(OnTouchEnd));
		}
		slot.GetIsDark.SetSelectedIndex(flag ? 1 : 0);
		ViewModel viewModel = _viewModels[index];
		if (viewModel == null)
		{
			int selectedIndex = ((_dragMode == DragMode.Exchange || _dragMode == DragMode.Block) ? 3 : 0);
			slot.GetState.SetSelectedIndex(selectedIndex);
			return;
		}
		if (viewModel.IsSelf)
		{
			slot.GetState.SetSelectedIndex(2);
		}
		else
		{
			slot.GetState.SetSelectedIndex(1);
		}
		int userId;
		int shipRace;
		int num;
		if (viewModel.IsSelf)
		{
			userId = viewModel.SelfData.UserId;
			shipRace = viewModel.SelfData.ShipRace;
			num = viewModel.SelfData.BattleStrategy;
		}
		else
		{
			userId = viewModel.OtherData.UserId;
			shipRace = viewModel.OtherData.ShipRace;
			num = viewModel.OtherData.BattleStrategy;
		}
		bool flag2 = _islandDetailInfo.GetSubType() == eGvGMode3CampMissionSubType.RE_FactionWar || viewModel.IsSelf;
		bool flag3 = !flag2;
		slot.GetAvatar.GetIsHide.SetSelectedIndex(flag3 ? 1 : 0);
		slot.GetAvatar.GetAvatar.HeadPortrait.Type.SetSelectedIndex(flag2 ? 1 : 0);
		slot.GetAvatarSelf.avatar.HeadPortrait.Type.SetSelectedIndex(1);
		ShipConfigModel byShipRaceType = ShipConfigHelper.GetByShipRaceType(shipRace);
		int obCampId = Singleton<GvGMode3RoomManager>.Instance.ObserverRecord.ObCampId;
		string miniIconUrlByCamId = ShipConfigHelper.GetSkinById(byShipRaceType.DefaultSkinId).GetMiniIconUrlByCamId(obCampId);
		slot.GetAvatar.GetIcon.url = miniIconUrlByCamId;
		slot.GetAvatarSelf.Icon.url = miniIconUrlByCamId;
		bool flag4 = _showCancelBtn && viewModel.IsSelf;
		slot.GetIsShowCancelBtn.SetSelectedIndex(flag4 ? 1 : 0);
		bool flag5 = IsPendingConfirm && viewModel.IsSelf;
		slot.GetIsWaitConfirm.SetSelectedIndex(flag5 ? 1 : 0);
		((GObject)slot.GetCancelEnroll).onClick.Set((EventCallback1)delegate(EventContext x)
		{
			x.StopPropagation();
			OnShipListCancelEnroll(viewModel.SelfData.ShipId);
		});
		if (num < 0)
		{
			num = 0;
		}
		slot.GetAvatar.GetStrategy.SetSelectedIndex(num);
		slot.GetAvatarSelf.Strategy.SetSelectedIndex(num);
		GvG3ProfileHelper.GetUserProfile(new GvG3UserProfileRequestOptions(_cacheId, userId, null, delegate(Sprite sprite)
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			NTexture texture = new NTexture((Texture)(object)sprite.texture);
			slot.GetAvatar.GetAvatar.HeadPortrait.icon.texture = texture;
			slot.GetAvatarSelf.avatar.HeadPortrait.icon.texture = texture;
		}));
	}

	private void OnClickSlot(EventContext context, IShipPosition slot)
	{
		int index = slot.Index;
		ViewModel viewModel = _viewModels[index];
		if (viewModel != null && viewModel.IsSelf)
		{
			context.StopPropagation();
			_showCancelBtn = !_showCancelBtn;
			RenderSlot(slot);
		}
	}

	private string GetSlotName(int index)
	{
		int num = index / _slotPerCol;
		int num2 = index % _slotPerCol;
		char c = (char)(65 + num);
		return $"{c}{num2 + 1}";
	}

	private void RenderPendingShip()
	{
		showConfirmBtn.SetSelectedIndex(IsPendingConfirm ? 1 : 0);
	}

	private void OnShipListCancelEnroll(string shipId)
	{
		bool flag = _pendingShip != null && _pendingShip.Ship.ShipId == shipId;
		_showCancelBtn = false;
		if (flag)
		{
			SetPendingShip(null);
			RefreshSlot();
			return;
		}
		OnClickCancelEnroll(shipId, _eventInfo, delegate(C2S_BrawlEvent_Cancel.Response res)
		{
			if (res.CancelIslandId == _selectIslandId)
			{
				_enrollInfo.SignUpDatas = res.SignUpDatas;
				SetPendingShip(null);
				RefreshSlot();
			}
			_enrollInfo.SelfSignUpDatas = res.SelfSignUpDatas;
			ShipList.SingleSelectIndex = -1;
			ShipList.Refresh();
		});
	}

	private void OnClickChangeStrategy(UI_com_ShipList.ShipBattleStrategy shipData)
	{
		UI_com_ShipList.ShipState state = shipData.GetState(_eventInfo);
		if (state != UI_com_ShipList.ShipState.Deployed)
		{
			RefreshSlot();
			return;
		}
		string shipId = shipData.Ship.ShipId;
		BE_SignUpDataModel_ToProtocol bE_SignUpDataModel_ToProtocol = _eventInfo.SelfSignUpDatas.Find((BE_SignUpDataModel_ToProtocol x) => x.ShipId == shipId);
		int islandId = bE_SignUpDataModel_ToProtocol.IslandId;
		OnClickChangeStrategy(shipData, _eventInfo, delegate(C2S_BrawlEvent_SignUp.Response res)
		{
			if (islandId == _selectIslandId)
			{
				_enrollInfo.SignUpDatas = res.SignUpDatas;
			}
			_enrollInfo.SelfSignUpDatas = res.SelfSignUpDatas;
			_eventInfo.SelfSignUpDatas = res.SelfSignUpDatas;
			RefreshSlot();
		});
	}

	private void OnShipPointerDown(UI_com_ShipInfo shipInfo, UI_com_ShipList.ShipBattleStrategy shipData, EventContext context)
	{
		if (_enrollInfo != null && !IsPendingConfirm && !_isViewOnly)
		{
			BE_SignUpDataModel_ToProtocol bE_SignUpDataModel_ToProtocol = _eventInfo.SelfSignUpDatas?.Find((BE_SignUpDataModel_ToProtocol x) => x.IslandId == _selectIslandId);
			bool flag = bE_SignUpDataModel_ToProtocol != null;
			int num = _eventInfo.SelfSignUpDatas?.Count ?? 0;
			bool flag2 = _eventInfo.SelfSignUpDatas?.Find((BE_SignUpDataModel_ToProtocol x) => x.ShipId == shipData.Ship.ShipId) != null;
			bool flag3 = num >= _config.LimitForEachUser && !flag2;
			if (flag && bE_SignUpDataModel_ToProtocol.ShipId == shipData.Ship.ShipId)
			{
				_dragMode = DragMode.Relocate;
				_relocateFormIndex = bE_SignUpDataModel_ToProtocol.ZoneId;
			}
			else if (flag && bE_SignUpDataModel_ToProtocol.ShipId != shipData.Ship.ShipId)
			{
				_dragMode = DragMode.Exchange;
			}
			else if (flag3)
			{
				_dragMode = DragMode.Block;
			}
			else
			{
				_dragMode = DragMode.Enroll;
			}
			OnBeginDrag();
			dragShipIcon.ship.url = shipInfo.Icon.url;
			SetShipPosition(context);
			_selectShip = shipData;
		}
	}

	private void OnSlotPointerDown(EventContext context, IShipPosition slot)
	{
		if (_enrollInfo == null || _isViewOnly)
		{
			return;
		}
		int index = slot.Index;
		ViewModel viewModel = _viewModels[index];
		if (viewModel != null && viewModel.IsSelf)
		{
			_dragMode = DragMode.Relocate;
			_relocateFormIndex = index;
			_selectShip = _shipDatas.Find((UI_com_ShipList.ShipBattleStrategy x) => x.Ship.ShipId == viewModel.SelfData.ShipId);
			OnBeginDrag();
			dragShipIcon.ship.url = ShipConfigHelper.GetSkinById(ShipConfigHelper.GetByShipRaceType(viewModel.SelfData.ShipRace).DefaultSkinId).IconUrl;
			SetShipPosition(context);
		}
	}

	private void OnBeginDrag()
	{
		((GObject)dragShipIcon).visible = true;
		isDrag.SetSelectedIndex(1);
		RenderViewModel();
	}

	private void OnEndDrag()
	{
		((GObject)dragShipIcon).visible = false;
		isDrag.SetSelectedIndex(0);
		RenderViewModel();
	}

	private void OnTouchEnd(EventContext context)
	{
		if (_dragMode == DragMode.Empty)
		{
			return;
		}
		int index;
		if (_currentSelectSlot != null)
		{
			index = _currentSelectSlot.Index;
			Deselect();
			ViewModel viewModel = _viewModels[index];
			if (_dragMode == DragMode.Exchange)
			{
				if (viewModel == null)
				{
					"BrawlFightEnrollShipLimitTip".ToLanguage().ToTip();
				}
				else if (viewModel.IsSelf)
				{
					goto IL_012f;
				}
			}
			else
			{
				if (_dragMode != DragMode.Block)
				{
					if (_dragMode == DragMode.Enroll)
					{
						if (viewModel != null)
						{
							goto IL_0157;
						}
					}
					else if (_dragMode == DragMode.Relocate)
					{
						if (viewModel != null)
						{
							goto IL_0157;
						}
						_viewModels[_relocateFormIndex] = null;
						_relocateFormIndex = -1;
					}
					goto IL_012f;
				}
				if (viewModel == null)
				{
					"BrawlFightEnrollShipLimitTip2".ToLanguage().ToTip();
				}
				else if (viewModel.IsSelf)
				{
					goto IL_012f;
				}
			}
		}
		goto IL_0157;
		IL_0157:
		_dragMode = DragMode.Empty;
		_selectShip = null;
		OnEndDrag();
		return;
		IL_012f:
		SetPendingShip(_selectShip);
		_pendingShip.ZoneId = index;
		AddPendingShip();
		RenderViewModel();
		goto IL_0157;
	}

	private void AddPendingShip()
	{
		if (_pendingShip != null)
		{
			ViewModel value = new ViewModel
			{
				IsSelf = true,
				SelfData = new BE_SignUpDataModel_ToProtocol
				{
					BattleStrategy = _pendingShip.BattleStrategy,
					IslandId = _selectIslandId,
					ShipId = _pendingShip.Ship.ShipId,
					ShipRace = _pendingShip.Ship.PermanentData.ShipRace,
					UserId = GameController.Contexts.gameState.user.value.UserId,
					ZoneId = _pendingShip.ZoneId
				}
			};
			_viewModels[_pendingShip.ZoneId] = value;
		}
	}

	private void OnTouchMove(EventContext context)
	{
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_002d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		//IL_003a: Unknown result type (might be due to invalid IL or missing references)
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		if (_dragMode != DragMode.Empty)
		{
			SetShipPosition(context);
			Vector2 val = ((GObject)dragShipIcon.ship).LocalToGlobal(Vector2.zero);
			Vector2 touchPos = ((GObject)positionList).GlobalToLocal(val);
			RaycastSlot(touchPos, _allIndexes);
		}
	}

	private void SetShipPosition(EventContext context)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		//IL_001b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0021: Unknown result type (might be due to invalid IL or missing references)
		Vector2 position = context.inputEvent.position;
		Vector2 val = ((GObject)this).GlobalToLocal(position);
		((GObject)dragShipIcon).SetXY(val.x, val.y);
		((GObject)dragShipIcon).InvalidateBatchingState();
	}

	private void SetPendingShip(UI_com_ShipList.ShipBattleStrategy ship)
	{
		int num = -1;
		if (_pendingShip != null)
		{
			num = _pendingShip.ZoneId;
			_pendingShip.ZoneId = -1;
		}
		if (ship == null)
		{
			_pendingShip = null;
			ShipList.BlockClick = false;
		}
		else
		{
			_pendingShip = ship;
			_showCancelBtn = true;
			ShipList.SingleSelectIndex = -1;
			ShipList.BlockClick = true;
		}
		ShipList.Refresh();
		RenderPendingShip();
		if (num >= 0)
		{
			IShipPosition slot = _currentSlots[num];
			RenderSlot(slot);
		}
	}

	private void RaycastSlot(Vector2 touchPos, List<int> indexes)
	{
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		//IL_0025: Unknown result type (might be due to invalid IL or missing references)
		IShipPosition shipPosition = null;
		foreach (int index in indexes)
		{
			Rect val = _slotRects[index];
			if (((Rect)(ref val)).Contains(touchPos))
			{
				shipPosition = _currentSlots[index];
				break;
			}
		}
		if (_currentSelectSlot != shipPosition)
		{
			if (_currentSelectSlot != null)
			{
				Deselect();
			}
			if (shipPosition != null)
			{
				Select(shipPosition);
			}
		}
	}

	private void Select(IShipPosition slot)
	{
		_currentSelectSlot = slot;
		_currentSelectSlot.GetIsSelect.SetSelectedIndex(1);
		GObject getThis = _currentSelectSlot.GetThis;
		getThis.parent.SetChildIndex(getThis, 1000);
	}

	private void Deselect()
	{
		_currentSelectSlot.GetIsSelect.SetSelectedIndex(0);
		_currentSelectSlot = null;
	}

	private static void End()
	{
		UnityUiService.Instance.ClosePanel(Name);
	}

	private void DoEnroll()
	{
		if (_pendingShip == null)
		{
			return;
		}
		string shipId = _pendingShip.Ship.ShipId;
		int num = _pendingShip.BattleStrategy;
		int selectIslandId = _selectIslandId;
		int zoneId = _pendingShip.ZoneId;
		IslandStateModel islandStateModel = Singleton<WorldStateManager>.Instance.TryGetIsland(selectIslandId);
		bool flag = islandStateModel.BrawlEvent.GetSubType() == eGvGMode3CampMissionSubType.RE_FFA;
		int obCampId = Singleton<GvGMode3RoomManager>.Instance.ObserverRecord.ObCampId;
		if (!flag && num == obCampId)
		{
			_pendingShip.BattleStrategy = 0;
			num = 0;
			"BrawlFightShipStrategyResetTip".ToLanguage().ToTip();
		}
		SocketManager.Instance.GetConnection(eConType.GvGMode3IslandManager).Request(new C2S_BrawlEvent_SignUp
		{
			Req = new C2S_BrawlEvent_SignUp.Request
			{
				ShipId = shipId,
				IslandId = selectIslandId,
				ZoneId = zoneId,
				BattleStrategy = num
			}
		}, delegate(SocketManager.BaseSocketPackageBodyContext contextResponse)
		{
			C2S_BrawlEvent_SignUp.Response response = (C2S_BrawlEvent_SignUp.Response)contextResponse.Resp;
			_showCancelBtn = false;
			SetPendingShip(null);
			if (response.ErrorCode != 0)
			{
				ILRequestHelper.ShowErrorCode(response.ErrorCode);
			}
			if (response.SignUpDatas != null || response.SelfSignUpDatas != null)
			{
				_enrollInfo.SelfSignUpDatas = response.SelfSignUpDatas;
				_enrollInfo.SignUpDatas = response.SignUpDatas;
				_eventInfo.SelfSignUpDatas = response.SelfSignUpDatas;
				GameManagers.Instance.Messenger.Broadcast("BRAWL_EVENT_SIGN_UP_CHANGE", _eventInfo);
				RefreshSlot();
				ShipList.Refresh();
			}
		});
	}

	private IEnumerator UpdateEnrollInfos()
	{
		WaitForSeconds wait = new WaitForSeconds(5f);
		while (!((GObject)this).isDisposed)
		{
			yield return wait;
			if (!((GObject)this).isDisposed && !IsPendingConfirm)
			{
				GetEnrollInfo();
			}
		}
	}

	private void GetEnrollInfo()
	{
		SocketManager.Instance.GetConnection(eConType.GvGMode3IslandManager).Request(new C2S_BrawlEvent_GetSignUpInfoByIsland
		{
			Req = new C2S_BrawlEvent_GetSignUpInfoByIsland.Request
			{
				IslandId = _selectIslandId
			}
		}, delegate(SocketManager.BaseSocketPackageBodyContext contextResponse)
		{
			C2S_BrawlEvent_GetSignUpInfoByIsland.Response response = (C2S_BrawlEvent_GetSignUpInfoByIsland.Response)contextResponse.Resp;
			if (response.ErrorCode != 0)
			{
				ILRequestHelper.ShowErrorCode(response.ErrorCode);
			}
			else
			{
				_enrollInfo = response;
				RefreshSlot();
			}
		});
	}

	private void OnClickRayMask()
	{
		if (ShipList.SingleSelectIndex >= 0)
		{
			ShipList.SingleSelectIndex = -1;
			ShipList.Refresh();
		}
		else if (ShipList.IsSelectStrategyPanelOpen)
		{
			ShipList.OnClickCloseStrategyPanel();
		}
	}

	private void OnClickHelpBtn()
	{
		IslandStateModel islandStateModel = Singleton<WorldStateManager>.Instance.TryGetIsland(_selectIslandId);
		bool isFinal = UI_main_BrawlFightEnroll.IsFinalStep(_eventInfo.StepIdx);
		UI_main_BrawlIslandBonusPreview.OpenBrawlIslandBonusPreview(new BrawlPreviewBonusParams
		{
			MissionConfigId = islandStateModel.BrawlEvent.MConfigId,
			IslandSubType = _islandDetailInfo.IslandSubType,
			MUID = _islandDetailInfo.MUID,
			IsFinal = isFinal
		});
	}

	public static void OnClickCancelEnroll(string shipId, C2S_BrawlEvent_GetInfo.Response eventInfo, Action<C2S_BrawlEvent_Cancel.Response> onSuccess = null)
	{
		"BrawlEventCancelEnrollTip".ToLanguage().ToConfirmPopup(delegate
		{
			SocketManager.Instance.GetConnection(eConType.GvGMode3IslandManager).Request(new C2S_BrawlEvent_Cancel
			{
				Req = new C2S_BrawlEvent_Cancel.Request
				{
					ShipId = shipId
				}
			}, delegate(SocketManager.BaseSocketPackageBodyContext contextResponse)
			{
				C2S_BrawlEvent_Cancel.Response response = (C2S_BrawlEvent_Cancel.Response)contextResponse.Resp;
				if (response.ErrorCode != 0)
				{
					ILRequestHelper.ShowErrorCode(response.ErrorCode);
				}
				else
				{
					eventInfo.SelfSignUpDatas = response.SelfSignUpDatas;
					GameManagers.Instance.Messenger.Broadcast("BRAWL_EVENT_SIGN_UP_CHANGE", eventInfo);
					onSuccess?.Invoke(response);
				}
			});
		}, null, (AlignType)0);
	}

	public static void OnClickChangeStrategy(UI_com_ShipList.ShipBattleStrategy shipData, C2S_BrawlEvent_GetInfo.Response currentInfo, Action<C2S_BrawlEvent_SignUp.Response> onSuccess = null)
	{
		UI_com_ShipList.ShipState state = shipData.GetState(currentInfo);
		if (state != UI_com_ShipList.ShipState.Deployed)
		{
			return;
		}
		string shipId = shipData.Ship.ShipId;
		BE_SignUpDataModel_ToProtocol bE_SignUpDataModel_ToProtocol = currentInfo.SelfSignUpDatas.Find((BE_SignUpDataModel_ToProtocol x) => x.ShipId == shipId);
		int islandId = bE_SignUpDataModel_ToProtocol.IslandId;
		int zoneId = bE_SignUpDataModel_ToProtocol.ZoneId;
		int battleStrategy = shipData.BattleStrategy;
		SocketManager.Instance.GetConnection(eConType.GvGMode3IslandManager).Request(new C2S_BrawlEvent_SignUp
		{
			Req = new C2S_BrawlEvent_SignUp.Request
			{
				ShipId = shipId,
				IslandId = islandId,
				ZoneId = zoneId,
				BattleStrategy = battleStrategy
			}
		}, delegate(SocketManager.BaseSocketPackageBodyContext contextResponse)
		{
			C2S_BrawlEvent_SignUp.Response response = (C2S_BrawlEvent_SignUp.Response)contextResponse.Resp;
			if (response.ErrorCode != 0)
			{
				ILRequestHelper.ShowErrorCode(response.ErrorCode);
			}
			onSuccess?.Invoke(response);
		});
	}
}
