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
using Shift.Legion.ClientApi.Protocol;
using Shift.Legion.Common.Helpers;
using Shift.Legion.Common.Managers;
using Shift.Legion.Common.Services;
using Shift.Legion.GvGServer.Models.IslandManagerSocket;
using UI.Legion;
using UnityEngine;

namespace UI.IslandComeAgain;

public class UI_MainIslandPanel : GComponent, IUiController
{
	public Controller Type;

	public Controller State;

	public GGraph Mask;

	public UI_UserInfoDialog UserInfoDialog;

	public UI_MainIslandDialog MainIslandDialog;

	public const string URL = "ui://k2sprg26in7b25";

	public static string Name = "UI_MainIslandPanel";

	private WaitForSeconds perSecond;

	private eShipSummaryState currentState;

	private Dictionary<string, int> fillUpTimestamp = new Dictionary<string, int>();

	private int startFillUpTimestamp;

	private Coroutine updateReplenishCountDown;

	private List<C2S_GetEOIEntitiesInfo> myCampUserInfos;

	private Dictionary<int, int> userKillCnt = new Dictionary<int, int>();

	private List<Ship> userShips = new List<Ship>();

	private int ArriveTime;

	private Island Island;

	private Coroutine TimeCounterCoroutine;

	public MapStateManager MapStateManager { get; private set; }

	public static string GetURL()
	{
		return "ui://k2sprg26in7b25";
	}

	public static UI_MainIslandPanel CreateInstance()
	{
		return (UI_MainIslandPanel)(object)UIPackage.CreateObject("IslandComeAgain", "MainIslandPanel");
	}

	public static UI_MainIslandPanel CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_MainIslandPanel).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://k2sprg26in7b25", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Type = ((GComponent)this).GetController("Type");
		State = ((GComponent)this).GetController("State");
		Mask = (GGraph)((GComponent)this).GetChild("Mask");
		UserInfoDialog = (UI_UserInfoDialog)(object)((GComponent)this).GetChild("UserInfoDialog");
		MainIslandDialog = (UI_MainIslandDialog)(object)((GComponent)this).GetChild("MainIslandDialog");
	}

	public void BeforeDestroy()
	{
		if (TimeCounterCoroutine != null && (Object)(object)GvGWorldMapController.Instance != (Object)null)
		{
			((MonoBehaviour)GvGWorldMapController.Instance).StopCoroutine(TimeCounterCoroutine);
		}
		if (updateReplenishCountDown != null)
		{
			FGUIManager.Instance.CloseIEnumerator(updateReplenishCountDown);
		}
	}

	public void Destroy()
	{
		UiTagManager instance = UiTagManager.Instance;
		instance.Unregister("MainIslandPanel.Close", Mask);
	}

	public void Init(Dictionary<string, object> parameters)
	{
		if (parameters.TryGetValue("Island", out var value))
		{
			Island = (Island)value;
		}
		if (parameters.TryGetValue("MapStateManager", out var value2))
		{
			MapStateManager = (MapStateManager)value2;
		}
		FGUIManager.SetUiPanelSizeAndXy((GObject)(object)this);
		((GObject)MainIslandDialog.IslandName).text = Island.Name + LanguagesManager.GetDesc("CsharpCodeZhTcText311");
		((GObject)MainIslandDialog.n8).text = "/10";
		SetCampInfo();
		SetCurrentPanelType(Singleton<GvGInstanceZone>.Instance.GetShipFillingUpRequest());
		RenderGotoComponent();
	}

	public void OnShow()
	{
		UiTagManager instance = UiTagManager.Instance;
		instance.Register("MainIslandPanel.Close", Mask);
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
		//IL_00c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cc: Expected O, but got Unknown
		((GObject)Mask).onClick.Add(new EventCallback0(End));
		((GObject)MainIslandDialog.ReplenishTroops).onClick.Add(new EventCallback0(OpenReplenishTroopsPanel));
		((GObject)MainIslandDialog.ChangeTroops).onClick.Add(new EventCallback0(OpenChangeTroopsPanel));
		((GObject)MainIslandDialog.LegionTroops).onClick.Add(new EventCallback0(OpenLegionPanel));
		((GObject)MainIslandDialog.CheckUserInfoDetail).onClick.Add(new EventCallback0(ShowUserInfoList));
		((GObject)MainIslandDialog.GoToIsland.Travel).onClick.Add(new EventCallback0(OnGoTo));
		S2C_ChangeShipSummaryStateShipFillingUp.OnPushEvent = (Action<S2C_ChangeShipSummaryStateShipFillingUp.Request>)Delegate.Combine(S2C_ChangeShipSummaryStateShipFillingUp.OnPushEvent, new Action<S2C_ChangeShipSummaryStateShipFillingUp.Request>(SetCurrentPanelType));
		SharedMessenger.AddListener("GVG2_ENTER_ISLAND", End);
		SharedMessenger.AddListener("ON_SOCKET_ERROR", End);
		SharedMessenger.AddListener("ON_GVG2_INSTANCE_END", End);
	}

	public void UnregisterUiEventListeners()
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
		((GObject)Mask).onClick.Remove(new EventCallback0(End));
		((GObject)MainIslandDialog.ReplenishTroops).onClick.Remove(new EventCallback0(OpenReplenishTroopsPanel));
		((GObject)MainIslandDialog.ChangeTroops).onClick.Remove(new EventCallback0(OpenChangeTroopsPanel));
		((GObject)MainIslandDialog.LegionTroops).onClick.Remove(new EventCallback0(OpenLegionPanel));
		((GObject)MainIslandDialog.CheckUserInfoDetail).onClick.Remove(new EventCallback0(ShowUserInfoList));
		((GObject)MainIslandDialog.GoToIsland.Travel).onClick.Clear();
		S2C_ChangeShipSummaryStateShipFillingUp.OnPushEvent = (Action<S2C_ChangeShipSummaryStateShipFillingUp.Request>)Delegate.Remove(S2C_ChangeShipSummaryStateShipFillingUp.OnPushEvent, new Action<S2C_ChangeShipSummaryStateShipFillingUp.Request>(SetCurrentPanelType));
		SharedMessenger.RemoveListener("GVG2_ENTER_ISLAND", End);
		SharedMessenger.RemoveListener("ON_SOCKET_ERROR", End);
		SharedMessenger.RemoveListener("ON_GVG2_INSTANCE_END", End);
	}

	public void End()
	{
		GameController.Contexts.Service<IUiService>().ClosePanel(Name, reservePackageRes: true);
	}

	private void SetCampInfo()
	{
		MainIslandDialog.MainIslandTyoe.selectedIndex = Singleton<GvGInstanceZone>.Instance.CampId - 1;
		myCampUserInfos = Singleton<GvGInstanceZone>.Instance.MyCampUserInfos;
		if (myCampUserInfos != null)
		{
			((GObject)MainIslandDialog.UserNumber).text = $"{myCampUserInfos.Count}";
			for (int i = 0; i < myCampUserInfos.Count; i++)
			{
				for (int j = 0; j < myCampUserInfos[i].ShipEntities.Count; j++)
				{
					int id = myCampUserInfos[i].ShipEntities[j];
					Ship byId = GvGWorldMapController.Instance.ShipManager.GetById(id);
					if (byId != null && byId.Details != null)
					{
						userShips.Add(byId);
					}
				}
			}
		}
		for (int k = 0; k < userShips.Count; k++)
		{
			Ship ship = userShips[k];
			ship.OnUpdateFlightSchedule = (Action<Ship>)Delegate.Combine(ship.OnUpdateFlightSchedule, new Action<Ship>(UpdateUserCurrentState));
		}
	}

	private void SetCurrentPanelType(S2C_ChangeShipSummaryStateShipFillingUp.Request dataRequest)
	{
		//IL_0171: Unknown result type (might be due to invalid IL or missing references)
		//IL_017b: Expected O, but got Unknown
		currentState = (eShipSummaryState)(dataRequest?.ShipSummaryState ?? ((int)Singleton<GvGInstanceZone>.Instance.CurrentState));
		switch (currentState)
		{
		case eShipSummaryState.InCampBase:
		case eShipSummaryState.InCampBaseShipButDead:
		case eShipSummaryState.InCampBaseShipFillUpFinish:
			MainIslandDialog.ReplenishTroops.Type.selectedIndex = 0;
			MainIslandDialog.ChangeTroops.Type.selectedIndex = 0;
			break;
		case eShipSummaryState.InCampBaseShipFillingUp:
			MainIslandDialog.ReplenishTroops.Type.selectedIndex = 1;
			MainIslandDialog.ChangeTroops.Type.selectedIndex = 1;
			break;
		case eShipSummaryState.DuringFlight:
		case eShipSummaryState.Fighting:
		case eShipSummaryState.BackToCampBaseAndShipFillUp:
			MainIslandDialog.ReplenishTroops.Type.selectedIndex = 3;
			MainIslandDialog.ChangeTroops.Type.selectedIndex = 3;
			break;
		default:
			MainIslandDialog.ReplenishTroops.Type.selectedIndex = 2;
			MainIslandDialog.ChangeTroops.Type.selectedIndex = 2;
			break;
		}
		if (currentState == eShipSummaryState.InCampBaseShipFillingUp && dataRequest != null)
		{
			int endFillUpTime = dataRequest.FillUpTimestamp.Values.OrderByDescending((int t) => t).ToArray()[0];
			int startFillUpTime = dataRequest.StartFillUpTimestamp;
			perSecond = new WaitForSeconds(1f);
			updateReplenishCountDown = FGUIManager.Instance.OpenIEnumerator(UpdateFillUpTime(endFillUpTime, startFillUpTime));
		}
	}

	private IEnumerator UpdateFillUpTime(int endFillUpTime, int startFillUpTime)
	{
		for (int remainingTime = endFillUpTime - startFillUpTime; remainingTime > 0; remainingTime = endFillUpTime - (int)GameController.Instance.GetServerTime())
		{
			((GObject)MainIslandDialog.ReplenishTroops.Countdown).text = UiHelper.ParseTime_Foo(remainingTime) ?? "";
			yield return perSecond;
		}
	}

	private void OpenLegionPanel()
	{
		Dictionary<string, object> parameters = new Dictionary<string, object> { { "Style", "Self" } };
		GameController.Contexts.Service<IUiService>().OpenPanel(UI_LegionPanel.Name, parameters);
	}

	private void OpenReplenishTroopsPanel()
	{
		switch (MainIslandDialog.ReplenishTroops.Type.selectedIndex)
		{
		case 2:
			GoToMainIsland(eGotoIslandOperation.ReplenishLegionGroup);
			break;
		case 3:
			if (currentState == eShipSummaryState.DuringFlight || currentState == eShipSummaryState.BackToCampBaseAndShipFillUp)
			{
				List<string> arg = new List<string> { LanguagesManager.GetDesc("CsharpCodeZhTcText312") + LanguagesManager.Comma + LanguagesManager.GetDesc("CsharpCodeZhTcText313") };
				SharedMessenger.Broadcast("SHOW_TIPS", arg, 1, arg3: false);
			}
			if (currentState == eShipSummaryState.Fighting)
			{
				List<string> arg2 = new List<string> { LanguagesManager.GetDesc("CsharpCodeZhTcText314") + LanguagesManager.Comma + LanguagesManager.GetDesc("CsharpCodeZhTcText313") };
				SharedMessenger.Broadcast("SHOW_TIPS", arg2, 1, arg3: false);
			}
			break;
		default:
		{
			Dictionary<string, object> parameters = new Dictionary<string, object> { 
			{
				"ReplenishData",
				Singleton<GvGInstanceZone>.Instance.GetShipFillingUpRequest()
			} };
			GameController.Contexts.Service<IUiService>().OpenPanel(UI_ReplenishTroopsPanel.Name, parameters);
			break;
		}
		}
	}

	private void OpenChangeTroopsPanel()
	{
		switch (MainIslandDialog.ChangeTroops.Type.selectedIndex)
		{
		case 1:
		{
			List<string> arg3 = new List<string> { LanguagesManager.GetDesc("CsharpCodeZhTcText315") + LanguagesManager.Comma + LanguagesManager.GetDesc("CsharpCodeZhTcText313") };
			SharedMessenger.Broadcast("SHOW_TIPS", arg3, 1, arg3: false);
			break;
		}
		case 2:
			GoToMainIsland(eGotoIslandOperation.ChangeLegionGroup);
			break;
		case 3:
			if (currentState == eShipSummaryState.DuringFlight || currentState == eShipSummaryState.BackToCampBaseAndShipFillUp)
			{
				List<string> arg = new List<string> { LanguagesManager.GetDesc("CsharpCodeZhTcText312") + LanguagesManager.Comma + LanguagesManager.GetDesc("CsharpCodeZhTcText313") };
				SharedMessenger.Broadcast("SHOW_TIPS", arg, 1, arg3: false);
			}
			if (currentState == eShipSummaryState.Fighting)
			{
				List<string> arg2 = new List<string> { LanguagesManager.GetDesc("CsharpCodeZhTcText314") + LanguagesManager.Comma + LanguagesManager.GetDesc("CsharpCodeZhTcText313") };
				SharedMessenger.Broadcast("SHOW_TIPS", arg2, 1, arg3: false);
			}
			break;
		default:
		{
			Dictionary<string, object> parameters = new Dictionary<string, object> { 
			{
				"CurrentSoldiersInfo",
				Singleton<GvGInstanceZone>.Instance.CurrentUnitInfo
			} };
			GameController.Contexts.Service<IUiService>().OpenPanel(UI_ChangeTroopsPanel.Name, parameters);
			break;
		}
		}
	}

	private void ShowUserInfoList()
	{
		Type.selectedIndex = ((Type.selectedIndex != 1) ? 1 : 0);
		MainIslandDialog.CheckUserInfoDetail.Type.selectedIndex = Type.selectedIndex;
		if (Type.selectedIndex == 1)
		{
			GetOwnCampKillInfo(Singleton<GvGInstanceZone>.Instance.CampId);
		}
	}

	private void GoToMainIsland(eGotoIslandOperation operation)
	{
		string myCampIslandId = GvGWorldMapController.Instance.GetMyCampIslandId();
		if (GvGWorldMapController.Instance.OnSelectRoute(myCampIslandId, operation))
		{
			End();
		}
	}

	private void GetOwnCampKillInfo(int campId)
	{
		SocketManager.Instance.GetConnection(eConType.GvGMode2WorldMap).Request(new C2S_GetOwnCampKillInfo
		{
			Req = new C2S_GetOwnCampKillInfo.Request
			{
				CampId = campId
			}
		}, delegate(SocketManager.BaseSocketPackageBodyContext context_response)
		{
			C2S_GetOwnCampKillInfo.Response response = (C2S_GetOwnCampKillInfo.Response)context_response.Resp;
			if (response.ErrorCode >= 0)
			{
				userKillCnt = response.GetUserKillInfo();
				RenderUserInfoList();
			}
		});
	}

	private void RenderUserInfoList()
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected O, but got Unknown
		UserInfoDialog.UserInfo.itemRenderer = new ListItemRenderer(RenderUserInfoItem);
		UserInfoDialog.UserInfo.numItems = userShips.Count;
	}

	private void RenderUserInfoItem(int index, GObject obj)
	{
		UI_UserInfo btn = obj as UI_UserInfo;
		if (btn == null)
		{
			return;
		}
		Ship ship = userShips[index];
		int value;
		int num = (userKillCnt.TryGetValue(ship.Details.UserId, out value) ? value : 0);
		((GObject)btn.kills).text = $"{num}";
		((GObject)btn.StateInfo).text = GvGWorldMapController.Instance.GetUserCurrentState(ship.Details);
		ProfileHelper.GetUserProfile($"{ship.Props.CampId}", ship.Details.UserId, delegate(UserProfile profile)
		{
			if (!((GObject)btn).isDisposed)
			{
				((GObject)btn.UserName).text = profile.Name;
			}
		});
		AvatarHelper.GetUserAvatarSprite($"{ship.Props.CampId}", ship.Details.UserId, delegate(Sprite sprite)
		{
			//IL_002d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0037: Expected O, but got Unknown
			if (!((GObject)btn).isDisposed)
			{
				btn.UserAvatar.Avatar.icon.texture = new NTexture((Texture)(object)sprite.texture);
			}
		});
		btn.UserAvatar.Type.selectedIndex = ship.Props.CampId - 1;
	}

	private void RenderGotoComponent()
	{
		Ship myShip = MapStateManager.MyShip;
		eShipSummaryState state = (eShipSummaryState)myShip.Details.State;
		UI_GoToIsland goToIsland = MainIslandDialog.GoToIsland;
		((GObject)goToIsland.Travel.Text).text = LanguagesManager.GetDesc("CsharpCodeZhTcText306");
		ArriveTime = -1;
		if (state == eShipSummaryState.DuringFlight)
		{
			int num = myShip.Details.FlightSchedule.Route[^1];
			if (num == Island.Props.Id)
			{
				ArriveTime = myShip.Details.FlightSchedule.EndTime;
			}
			else
			{
				((GObject)goToIsland.Time).text = LanguagesManager.GetDesc("CsharpCodeZhTcText307");
			}
			((GObject)goToIsland.Travel).grayed = true;
			((GObject)goToIsland.Travel).touchable = false;
		}
		else if (myShip.Details.StayIslandId == Island.Props.Id)
		{
			((GObject)goToIsland.Time).text = "";
			((GObject)goToIsland.Travel).grayed = false;
			((GObject)goToIsland.Travel).touchable = false;
			((GObject)goToIsland.Travel.Text).text = LanguagesManager.GetDesc("CsharpCodeZhTcText308");
		}
		else
		{
			RouteManager.RouteInfo routeInfo = GvGWorldMapController.Instance.GetRouteInfo(Island.Id);
			string text = UiHelper.ParseTime((int)routeInfo.TraveTime);
			((GObject)goToIsland.Time).text = LanguagesManager.GetDesc("CsharpCodeZhTcText310") + " " + text;
			((GObject)goToIsland.Travel).grayed = false;
			((GObject)goToIsland.Travel).touchable = true;
		}
		if (TimeCounterCoroutine == null)
		{
			TimeCounterCoroutine = ((MonoBehaviour)GvGWorldMapController.Instance).StartCoroutine(UpdateTime());
		}
	}

	private IEnumerator UpdateTime()
	{
		while (true)
		{
			int serverTime = (int)GameController.Instance.GetServerTime();
			if (ArriveTime != -1)
			{
				int timeLeft = ArriveTime - serverTime;
				if (timeLeft < 0)
				{
					ArriveTime = -1;
					((GObject)MainIslandDialog.GoToIsland.Travel).grayed = false;
					((GObject)MainIslandDialog.GoToIsland.Travel).touchable = false;
					((GObject)MainIslandDialog.GoToIsland.Travel.Text).text = LanguagesManager.GetDesc("CsharpCodeZhTcText308");
					((GObject)MainIslandDialog.GoToIsland.Time).text = "";
				}
				else
				{
					((GObject)MainIslandDialog.GoToIsland.Time).text = UiHelper.ParseTime(timeLeft);
				}
			}
			yield return (object)new WaitForSeconds(1f);
		}
	}

	public void UpdateUserCurrentState(Ship ship)
	{
		if (((GObject)this).isDisposed || ((GObject)UserInfoDialog).isDisposed || Type.selectedIndex == 0 || ship == null || ship.Details == null)
		{
			return;
		}
		Ship ship2 = (userShips.Where((Ship t) => t.Details.ShipId == ship.Details.ShipId)?.ToList())?[0];
		if (ship2 != null)
		{
			int num = userShips.IndexOf(ship2);
			if (UserInfoDialog.UserInfo.numItems > num && ((GComponent)UserInfoDialog.UserInfo).GetChildAt(num) is UI_UserInfo uI_UserInfo)
			{
				((GObject)uI_UserInfo.StateInfo).text = GvGWorldMapController.Instance.GetUserCurrentState(ship.Details);
			}
		}
	}

	private void OnGoTo()
	{
		if (GvGWorldMapController.Instance.OnSelectRoute(Island.Id))
		{
			End();
		}
	}
}
