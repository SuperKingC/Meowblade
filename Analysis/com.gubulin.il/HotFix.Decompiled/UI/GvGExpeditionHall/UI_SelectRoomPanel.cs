using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Assets.Scripts.UI;
using FairyGUI;
using FairyGUI.Utils;
using HotFix.Sources.Base.Scripts.Helper;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Interface;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Manager;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Model;
using Shift.Legion.ClientApi.Models;
using Shift.Legion.ClientApi.Protocol.UserAction;
using Shift.Legion.Common.Helpers;
using Shift.Legion.Common.Managers;
using Shift.Legion.Common.Services;
using Shift.Legion.GvGServer.Models.Map;
using UI.Tips;

namespace UI.GvGExpeditionHall;

public class UI_SelectRoomPanel : GComponent, IGvGExpeditionPopup
{
	private enum ShipBuildState
	{
		NotPrepared,
		Prepared
	}

	public Controller IsShow;

	public GGraph Mask;

	public UI_com_SelectRoomDialog Dialog;

	public Transition Popup;

	public const string URL = "ui://k19peou7dnvl2y";

	public static string Name = "UI_SelectRoomPanel";

	private GvGExpeditionHallModel Data;

	private UI_GvGExpeditionHallPanel ParentPanel;

	public Action OnStateChange = delegate
	{
	};

	private List<GvGProcessInfo> FilteredRooms;

	private string CurIZName;

	private const float AUTO_REFRESH_DATA_INTERVAL = 5f;

	private const float AUTO_UPDATE_STATE_INTERVAL = 1f;

	public static string GetURL()
	{
		return "ui://k19peou7dnvl2y";
	}

	public static UI_SelectRoomPanel CreateInstance()
	{
		return (UI_SelectRoomPanel)(object)UIPackage.CreateObject("GvGExpeditionHall", "SelectRoomPanel");
	}

	public static UI_SelectRoomPanel CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_SelectRoomPanel).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://k19peou7dnvl2y", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		IsShow = ((GComponent)this).GetController("IsShow");
		Mask = (GGraph)((GComponent)this).GetChild("Mask");
		Dialog = (UI_com_SelectRoomDialog)(object)((GComponent)this).GetChild("Dialog");
		Popup = ((GComponent)this).GetTransition("Popup");
	}

	public void Init(GvGExpeditionHallModel data, UI_GvGExpeditionHallPanel parentPanel)
	{
		Data = data;
		ParentPanel = parentPanel;
		UI_SelectCampPanel selectCampPanel = ParentPanel.SelectCampPanel;
		selectCampPanel.OnConfirm = (Action<int>)Delegate.Combine(selectCampPanel.OnConfirm, new Action<int>(OnComfirmSelectCamp));
	}

	public void RegisterUiEventListeners()
	{
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		//IL_001e: Expected O, but got Unknown
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Expected O, but got Unknown
		((GObject)Mask).onClick.Set(new EventCallback0(OnInactivate));
		((GObject)Dialog.CloseBtn).onClick.Set(new EventCallback0(OnInactivate));
	}

	public void UnregisterUiEventListeners()
	{
		((GObject)Mask).onClick.Clear();
		((GObject)Dialog.CloseBtn).onClick.Clear();
		if (ParentPanel != null && ParentPanel.SelectCampPanel != null)
		{
			UI_SelectCampPanel selectCampPanel = ParentPanel.SelectCampPanel;
			selectCampPanel.OnConfirm = (Action<int>)Delegate.Remove(selectCampPanel.OnConfirm, new Action<int>(OnComfirmSelectCamp));
		}
	}

	private void OnClickSinInBtn(Dictionary<string, GvGMode3CampInfo> campInfos)
	{
		ParentPanel.OnOpenSelectCampPanel(campInfos);
	}

	private void OnComfirmSelectCamp(int campId)
	{
		int selectedIndex = Dialog.RoomList.selectedIndex;
		GvGProcessInfo gvGProcessInfo = FilteredRooms[selectedIndex];
		GvGMode3IslandManagerInfo gvGMode3IslandManagerInfo = (GvGMode3IslandManagerInfo)gvGProcessInfo.GetInfo();
		int now = (int)GameController.Instance.GetServerTime();
		int result;
		if (!gvGMode3IslandManagerInfo.IZInfo.CanSignUp(now))
		{
			List<string> arg = new List<string> { "GvGSignUpHasStoppedTips".ToLanguage() };
			SharedMessenger.Broadcast("SHOW_TIPS", arg, ((GObject)this).sortingOrder, arg3: false);
		}
		else if (int.TryParse(gvGProcessInfo.IZId, out result))
		{
			ConfirmSignIn(campId, result, gvGProcessInfo.IZConfigId);
		}
	}

	public void ConfirmSignIn(int campId, int izId, string izConfigId)
	{
		ILRequestHelper<GvGMode3SignUpActionResponse>.Request((EventContext)null, (Func<Task<GvGMode3SignUpActionResponse>>)(() => GameController.Contexts.Service<INetworkService>().GvGMode3SignUpAction(campId, izId, izConfigId, $"{eSignUpAction.SignUp}")), (Action<GvGMode3SignUpActionResponse>)delegate(GvGMode3SignUpActionResponse response)
		{
			if (!response.Result)
			{
				ILRequestHelper.ShowErrorCode(response.ErrorCode);
			}
			else
			{
				Data.SignIn(campId, izId, izConfigId);
				GameManagers.Instance.UserArchiveManager.JoinNewGvGMode3(new GvGMode3SignUpActionRequest
				{
					CampId = campId,
					IZId = izId,
					IZConfigId = izConfigId,
					SignUpAction = $"{eSignUpAction.SignUp}"
				});
				Singleton<GvGMode3RoomManager>.Instance.ObserverRecord = null;
				Singleton<GvGMode3RoomManager>.Instance.GetGSObserverRecord();
				Dialog.RoomList.selectedIndex = -1;
				Update();
				OnStateChange?.Invoke();
			}
		});
	}

	private void OnClickCancelSignInBtn(EventContext context)
	{
		string value = "GvGCancelSignUpWarning".ToLanguage();
		GameController.Contexts.Service<IUiService>().OpenPanel(UI_UniversalConfirmPopup.Name, new Dictionary<string, object>
		{
			{
				"TipTextAlign",
				(object)(AlignType)1
			},
			{ "Content", value },
			{
				"Buttons",
				new Dictionary<string, Action>
				{
					{
						"Confirm",
						delegate
						{
							OnClickConfirmCancelSignIn();
						}
					},
					{ "Cancel", null }
				}
			},
			{ "PageIndex", 0 },
			{ "FontSize", 44 },
			{ "Order", 999999 }
		});
	}

	private void OnClickConfirmCancelSignIn()
	{
		GvGProcessInfo signedInRoom = Data.SignedInRoom;
		GvGMode3IslandManagerInfo gvGMode3IslandManagerInfo = (GvGMode3IslandManagerInfo)signedInRoom.GetInfo();
		int now = (int)GameController.Instance.GetServerTime();
		int result;
		if (!gvGMode3IslandManagerInfo.IZInfo.CanCancelSignUp(now))
		{
			List<string> arg = new List<string> { "GvGCannotCancelSignUpTips".ToLanguage() };
			SharedMessenger.Broadcast("SHOW_TIPS", arg, ((GObject)this).sortingOrder, arg3: false);
		}
		else if (int.TryParse(Data.SignedInRoom.IZId, out result))
		{
			ConfirmCancelSignIn(Data.SignedCampId, result, signedInRoom.IZConfigId);
		}
	}

	public void ConfirmCancelSignIn(int campId, int izId, string izConfigId)
	{
		ILRequestHelper<GvGMode3SignUpActionResponse>.Request((EventContext)null, (Func<Task<GvGMode3SignUpActionResponse>>)(() => GameController.Contexts.Service<INetworkService>().GvGMode3SignUpAction(campId, izId, izConfigId, $"{eSignUpAction.CancelSignUp}")), (Action<GvGMode3SignUpActionResponse>)delegate(GvGMode3SignUpActionResponse response)
		{
			if (!response.Result)
			{
				ILRequestHelper.ShowErrorCode(response.ErrorCode);
			}
			else
			{
				Data.CancelSignIn();
				GameManagers.Instance.UserArchiveManager.CancelGvGMode3();
				Update();
				OnStateChange?.Invoke();
			}
		});
	}

	private void Update()
	{
		GvGIZConfigModel gvGIZConfigModel = Data.IZConfigs[Data.SelectedIZIndex];
		GvGMode3IslandManagerInfo gvGMode3IslandManagerInfo = (GvGMode3IslandManagerInfo)(Data.SignedInRoom?.GetInfo());
		CurIZName = ((gvGMode3IslandManagerInfo == null) ? gvGIZConfigModel.Title : gvGMode3IslandManagerInfo.IZInfo.ShowName);
		if (gvGIZConfigModel.Processes == null)
		{
			return;
		}
		FilteredRooms = new List<GvGProcessInfo>();
		foreach (GvGProcessInfo process in gvGIZConfigModel.Processes)
		{
			if (IsRoomAvailable(process) && (Data.SignedInRoom == null || !(process.IZId == Data.SignedInRoom.IZId)))
			{
				FilteredRooms.Add(process);
			}
		}
		Dialog.IsSigned.selectedIndex = (Data.IsSigned ? 1 : 0);
		if (Data.IsSigned)
		{
			RenderSelectedRoom();
		}
		RenderRoomList();
	}

	private void RenderSelectedRoom()
	{
		//IL_00f9: Unknown result type (might be due to invalid IL or missing references)
		//IL_0103: Expected O, but got Unknown
		UI_btn_SelectedRoom selectedRoom = Dialog.SelectedRoom;
		GvGProcessInfo signedInRoom = Data.SignedInRoom;
		GvGMode3IslandManagerInfo gvGMode3IslandManagerInfo = (GvGMode3IslandManagerInfo)signedInRoom.GetInfo();
		((GObject)selectedRoom.RoomName).text = gvGMode3IslandManagerInfo.IZInfo.ShowName;
		((GObject)selectedRoom.UserCount).text = $"{gvGMode3IslandManagerInfo.UserCount}/{gvGMode3IslandManagerInfo.UserMaxCount}";
		selectedRoom.IsRoomFull.selectedIndex = ((gvGMode3IslandManagerInfo.UserCount == gvGMode3IslandManagerInfo.UserMaxCount) ? 1 : 0);
		((GObject)selectedRoom.StartTime).text = UiHelper.ParseFullTime(gvGMode3IslandManagerInfo.IZInfo.Start);
		selectedRoom.Camp.selectedIndex = Data.SignedCampId;
		((GObject)selectedRoom.CampName).text = gvGMode3IslandManagerInfo.GetCampName(Data.SignedCampId) ?? "";
		SetFirstShipBuildState(selectedRoom);
		((GObject)selectedRoom.CancelSignInBtn).onClick.Set(new EventCallback1(OnClickCancelSignInBtn));
		int num = (int)GameController.Instance.GetServerTime();
		bool flag = gvGMode3IslandManagerInfo.IZInfo.CanCancelSignUp(num);
		((GObject)selectedRoom.CancelSignInBtn).grayed = !flag;
		((GObject)selectedRoom.CancelSignInBtn).touchable = flag;
		((GObject)selectedRoom.TimeToStart).text = ((gvGMode3IslandManagerInfo.IZInfo.Start - num > 0) ? GetStartRoomText(gvGMode3IslandManagerInfo.IZInfo.Start - num) : string.Empty);
	}

	private void SetFirstShipBuildState(UI_btn_SelectedRoom comp)
	{
		ShipBuildState firstShipBuildState = GetFirstShipBuildState();
		comp.ShipState.SetSelectedIndex((int)firstShipBuildState);
	}

	private ShipBuildState GetFirstShipBuildState()
	{
		List<GvGMode3ShipModel> ships = Data.GvGMode3Record.Ships;
		return (ships.Count > 0 && ships[0].PermanentData.ShipBuildState == 0) ? ShipBuildState.Prepared : ShipBuildState.NotPrepared;
	}

	private void RenderRoomList()
	{
		//IL_002f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Expected O, but got Unknown
		GvGIZConfigModel gvGIZConfigModel = Data.IZConfigs[Data.SelectedIZIndex];
		Dialog.RoomList.itemRenderer = (ListItemRenderer)delegate(int i, GObject o)
		{
			RenderRoomItem(i, (UI_RoomItem)(object)o);
		};
		Dialog.RoomList.numItems = FilteredRooms.Count;
	}

	private void RenderRoomItem(int index, UI_RoomItem comp)
	{
		//IL_01fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0207: Expected O, but got Unknown
		GvGProcessInfo gvGProcessInfo = FilteredRooms[index];
		GvGMode3IslandManagerInfo roomInfo = (GvGMode3IslandManagerInfo)gvGProcessInfo.GetInfo();
		int num = (int)GameController.Instance.GetServerTime();
		if (num <= roomInfo.IZInfo.SignUp_Start)
		{
			comp.SignInState.selectedIndex = 0;
			((GObject)comp.StateTime).text = GetStartSignInText(roomInfo.IZInfo.SignUp_Start - num);
		}
		else if (roomInfo.IZInfo.CanSignUp(num))
		{
			if (!roomInfo.IZInfo.IsStarted(num))
			{
				comp.SignInState.selectedIndex = 1;
				((GObject)comp.StateTime).text = GetCloseSignInText(roomInfo.IZInfo.SignUp_Stop - num);
			}
			else
			{
				comp.SignInState.selectedIndex = 2;
				((GObject)comp.StateTime).text = GetCloseSignInText(roomInfo.IZInfo.SignUp_Stop - num);
			}
		}
		else
		{
			comp.SignInState.selectedIndex = 3;
		}
		((GObject)comp.RoomName).text = roomInfo.IZInfo.ShowName;
		((GObject)comp.UserCount).text = $"{roomInfo.UserCount}/{roomInfo.UserMaxCount}";
		comp.IsRoomFull.selectedIndex = ((roomInfo.UserCount == roomInfo.UserMaxCount) ? 1 : 0);
		((GObject)comp.StartTime).text = UiHelper.ParseFullTime(roomInfo.IZInfo.Start);
		((GObject)comp).touchable = !Data.IsSigned;
		((GObject)comp.SignInBtn).onClick.Set((EventCallback0)delegate
		{
			OnClickSinInBtn(roomInfo.CampInfos);
		});
	}

	public void OnActivate()
	{
		Dialog.RoomList.selectedIndex = -1;
		Update();
		StartAutoRefreshData();
		StartAutoUpdateState();
	}

	private void StartAutoUpdateState()
	{
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0017: Expected O, but got Unknown
		//IL_0044: Unknown result type (might be due to invalid IL or missing references)
		//IL_004e: Expected O, but got Unknown
		//IL_0027: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Expected O, but got Unknown
		if (Timers.inst.Exists(new TimerCallback(OnAutoUpdateState)))
		{
			Timers.inst.Remove(new TimerCallback(OnAutoUpdateState));
		}
		Timers.inst.Add(1f, 0, new TimerCallback(OnAutoUpdateState));
	}

	private void StopAutoUpdateState()
	{
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0017: Expected O, but got Unknown
		Timers.inst.Remove(new TimerCallback(OnAutoUpdateState));
	}

	private void OnAutoUpdateState(object param)
	{
		Update();
	}

	private void StartAutoRefreshData()
	{
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0017: Expected O, but got Unknown
		//IL_004c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0056: Expected O, but got Unknown
		//IL_0027: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Expected O, but got Unknown
		if (Timers.inst.Exists(new TimerCallback(OnAutoRefreshData)))
		{
			Timers.inst.Remove(new TimerCallback(OnAutoRefreshData));
		}
		OnAutoRefreshData(null);
		Timers.inst.Add(5f, 0, new TimerCallback(OnAutoRefreshData));
	}

	private void StopAutoRefreshData()
	{
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0017: Expected O, but got Unknown
		Timers.inst.Remove(new TimerCallback(OnAutoRefreshData));
	}

	private void OnAutoRefreshData(object param)
	{
		GvGIZConfigModel gvGIZConfigModel = Data.IZConfigs[Data.SelectedIZIndex];
		gvGIZConfigModel.UpdateRoomsData(Update);
	}

	public void OnInactivate()
	{
		IsShow.selectedIndex = 0;
		StopAutoUpdateState();
		StopAutoRefreshData();
	}

	private bool IsRoomAvailable(GvGProcessInfo room)
	{
		GvGMode3IslandManagerInfo gvGMode3IslandManagerInfo = (GvGMode3IslandManagerInfo)room.GetInfo();
		int num = (int)GameController.Instance.GetServerTime();
		return gvGMode3IslandManagerInfo.IZInfo.Display < num && num < gvGMode3IslandManagerInfo.IZInfo.NotDisplay;
	}

	private string GetStartSignInText(int curRemainingTime)
	{
		if (curRemainingTime <= 0)
		{
			curRemainingTime = 0;
		}
		UI_DataComponent dataComponent = ParentPanel.DataComponent;
		int num = curRemainingTime % 60;
		int num2 = curRemainingTime % 3600 / 60;
		int num3 = curRemainingTime % 86400 / 3600;
		int num4 = curRemainingTime / 86400;
		if (num4 > 0)
		{
			return string.Format(((GObject)dataComponent.ToStartSignIn_Days).text, num4);
		}
		if (num3 > 0)
		{
			return string.Format(((GObject)dataComponent.ToStartSignIn_Hours).text, num3);
		}
		if (num2 > 0)
		{
			return string.Format(((GObject)dataComponent.ToStartSignIn_Minutes).text, num2);
		}
		return string.Format(((GObject)dataComponent.ToStartSignIn_Seconds).text, num);
	}

	private string GetCloseSignInText(int curRemainingTime)
	{
		if (curRemainingTime <= 0)
		{
			curRemainingTime = 0;
		}
		UI_DataComponent dataComponent = ParentPanel.DataComponent;
		int num = curRemainingTime % 60;
		int num2 = curRemainingTime % 3600 / 60;
		int num3 = curRemainingTime % 86400 / 3600;
		int num4 = curRemainingTime / 86400;
		if (num4 > 0)
		{
			return string.Format(((GObject)dataComponent.ToCloseSignIn_Days).text, num4);
		}
		if (num3 > 0)
		{
			return string.Format(((GObject)dataComponent.ToCloseSignIn_Hours).text, num3);
		}
		if (num2 > 0)
		{
			return string.Format(((GObject)dataComponent.ToCloseSignIn_Minutes).text, num2);
		}
		return string.Format(((GObject)dataComponent.ToCloseSignIn_Seconds).text, num);
	}

	private string GetStartRoomText(int curRemainingTime)
	{
		if (curRemainingTime <= 0)
		{
			curRemainingTime = 0;
		}
		UI_DataComponent dataComponent = ParentPanel.DataComponent;
		int num = curRemainingTime % 60;
		int num2 = curRemainingTime % 3600 / 60;
		int num3 = curRemainingTime % 86400 / 3600;
		int num4 = curRemainingTime / 86400;
		if (num4 > 0)
		{
			return string.Format(((GObject)dataComponent.ToStartRoom_Days).text, num4);
		}
		if (num3 > 0)
		{
			return string.Format(((GObject)dataComponent.ToStartRoom_Hours).text, num3);
		}
		if (num2 > 0)
		{
			return string.Format(((GObject)dataComponent.ToStartRoom_Minutes).text, num2);
		}
		return string.Format(((GObject)dataComponent.ToStartRoom_Seconds).text, num);
	}
}
