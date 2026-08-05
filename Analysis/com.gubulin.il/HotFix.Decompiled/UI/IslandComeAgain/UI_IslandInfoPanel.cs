using System;
using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Managers;
using Assets.Scripts.UI;
using FairyGUI;
using FairyGUI.Utils;
using GvG2;
using GvG2.Common.Models;
using Shift.Legion.ClientApi.Protocol;
using Shift.Legion.Common.Helpers;
using Shift.Legion.Common.Services;
using Shift.Legion.GvGServer.Models.IslandManagerSocket;
using UnityEngine;

namespace UI.IslandComeAgain;

public class UI_IslandInfoPanel : GComponent, IUiController
{
	public Controller Type;

	public GGraph Mask;

	public UI_CampShipsInfoDialog CampShipsInfoDialog;

	public UI_IslandInfoDialog IslandInfoDialog;

	public const string URL = "ui://k2sprg26w6333t";

	public static string Name = "UI_IslandInfoPanel";

	private Island Island;

	private MapStateManager MapStateManager;

	private Coroutine TimeCounterCoroutine;

	private int TargetTime;

	private bool PushingFlag;

	private int ArriveTime;

	private int CurUserId;

	public static string GetURL()
	{
		return "ui://k2sprg26w6333t";
	}

	public static UI_IslandInfoPanel CreateInstance()
	{
		return (UI_IslandInfoPanel)(object)UIPackage.CreateObject("IslandComeAgain", "IslandInfoPanel");
	}

	public static UI_IslandInfoPanel CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_IslandInfoPanel).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://k2sprg26w6333t", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Type = ((GComponent)this).GetController("Type");
		Mask = (GGraph)((GComponent)this).GetChild("Mask");
		CampShipsInfoDialog = (UI_CampShipsInfoDialog)(object)((GComponent)this).GetChild("CampShipsInfoDialog");
		IslandInfoDialog = (UI_IslandInfoDialog)(object)((GComponent)this).GetChild("IslandInfoDialog");
	}

	public void Init(Dictionary<string, object> parameters)
	{
		CurUserId = GameController.Contexts.gameState.user.value.UserId;
		FGUIManager.SetUiPanelSizeAndXy((GObject)(object)this);
		if (parameters.TryGetValue("Island", out var value))
		{
			Island = (Island)value;
		}
		if (parameters.TryGetValue("MapStateManager", out var value2))
		{
			MapStateManager = (MapStateManager)value2;
		}
		UI_IslandInfoDialog islandInfoDialog = IslandInfoDialog;
		((GObject)islandInfoDialog.IslandName).text = Island.Name;
		if (Island.Props.Sprite == "i_small")
		{
			islandInfoDialog.IslandType.selectedIndex = 0;
		}
		else if (Island.Props.Sprite == "i_big")
		{
			islandInfoDialog.IslandType.selectedIndex = 1;
		}
		PushingFlag = false;
		Island island = Island;
		island.OnChangeState = (Action)Delegate.Combine(island.OnChangeState, new Action(Render));
		Render();
	}

	public void RegisterUiEventListeners()
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected O, but got Unknown
		//IL_003a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0044: Expected O, but got Unknown
		//IL_0073: Unknown result type (might be due to invalid IL or missing references)
		//IL_007d: Expected O, but got Unknown
		((GObject)Mask).onClick.Add(new EventCallback0(End));
		((GObject)IslandInfoDialog.GoToIsland.Travel).onClick.Add(new EventCallback0(GoTo));
		SharedMessenger.AddListener<bool>("ISLAND_COME_AGAIN_LEGION_CHANGE_CONFIRM", OnTroopsChangeConfirm);
		((GObject)IslandInfoDialog.CheckUserInfoDetail).onClick.Add(new EventCallback0(ShowCampShipsInfo));
		S2C_IslandCampSummary.OnPushEvent = (Action<S2C_IslandCampSummary.Request>)Delegate.Combine(S2C_IslandCampSummary.OnPushEvent, new Action<S2C_IslandCampSummary.Request>(OnPushIslandCampSummary));
		SharedMessenger.AddListener("GVG2_ENTER_ISLAND", End);
		SharedMessenger.AddListener("ON_SOCKET_ERROR", End);
		SharedMessenger.AddListener("ON_GVG2_INSTANCE_END", End);
	}

	public void UnregisterUiEventListeners()
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected O, but got Unknown
		//IL_003a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0044: Expected O, but got Unknown
		((GObject)Mask).onClick.Remove(new EventCallback0(End));
		((GObject)IslandInfoDialog.GoToIsland.Travel).onClick.Remove(new EventCallback0(GoTo));
		SharedMessenger.RemoveListener<bool>("ISLAND_COME_AGAIN_LEGION_CHANGE_CONFIRM", OnTroopsChangeConfirm);
		((GObject)IslandInfoDialog.CheckUserInfoDetail).onClick.Clear();
		S2C_IslandCampSummary.OnPushEvent = (Action<S2C_IslandCampSummary.Request>)Delegate.Remove(S2C_IslandCampSummary.OnPushEvent, new Action<S2C_IslandCampSummary.Request>(OnPushIslandCampSummary));
		SharedMessenger.RemoveListener("GVG2_ENTER_ISLAND", End);
		SharedMessenger.RemoveListener("ON_SOCKET_ERROR", End);
		SharedMessenger.RemoveListener("ON_GVG2_INSTANCE_END", End);
	}

	private void ShowCampShipsInfo()
	{
		if (Island.DockingManager != null)
		{
			Type.selectedIndex = ((Type.selectedIndex != 1) ? 1 : 0);
			IslandInfoDialog.CheckUserInfoDetail.Type.selectedIndex = Type.selectedIndex;
			if (Type.selectedIndex == 1)
			{
				RenderCampShipsInfoDialog();
				DockingManagerBase dockingManager = Island.DockingManager;
				dockingManager.OnChangeShips = (Action)Delegate.Combine(dockingManager.OnChangeShips, new Action(RenderCampShipsInfoDialog));
			}
			else
			{
				DockingManagerBase dockingManager2 = Island.DockingManager;
				dockingManager2.OnChangeShips = (Action)Delegate.Remove(dockingManager2.OnChangeShips, new Action(RenderCampShipsInfoDialog));
			}
		}
	}

	private void RenderCampShipsInfoDialog()
	{
		if (((GObject)this).isDisposed)
		{
			return;
		}
		List<Ship> dockingShips = Island.DockingManager.GetDockingShips();
		UI_CampShipsInfoDialog campShipsInfoDialog = CampShipsInfoDialog;
		Dictionary<int, List<Ship>> dictionary = new Dictionary<int, List<Ship>>();
		foreach (Ship item in dockingShips)
		{
			if (!dictionary.TryGetValue(item.Props.CampId, out var value))
			{
				value = new List<Ship>();
				dictionary.Add(item.Props.CampId, value);
			}
			value.Add(item);
		}
		campShipsInfoDialog.CampList.RemoveChildrenToPool();
		foreach (KeyValuePair<int, List<Ship>> item2 in dictionary)
		{
			GObject val = campShipsInfoDialog.CampList.AddItemFromPool();
			CampListRenderer(item2.Key, item2.Value, (UI_CampShipsSlot)(object)val);
		}
	}

	private void CampListRenderer(int campId, List<Ship> ships, UI_CampShipsSlot slot)
	{
		//IL_0089: Unknown result type (might be due to invalid IL or missing references)
		//IL_0093: Expected O, but got Unknown
		((GObject)slot.ShipCount).text = $"{ships.Count}";
		slot.CampId.selectedIndex = campId;
		((GObject)slot.CampTitle).text = MapDataManager.GetCampIslandName(campId) + LanguagesManager.GetDesc("CsharpCodeZhTcText309") + "：";
		((GObject)slot.ToggleBtn).onClick.Set((EventCallback0)delegate
		{
			slot.IsExpand.selectedIndex = ((slot.IsExpand.selectedIndex != 1) ? 1 : 0);
			((GObject)slot).height = ((slot.IsExpand.selectedIndex == 0) ? ((GObject)slot.TitleBack).height : ((GObject)slot.ShipList).height);
		});
		slot.ShipList.RemoveChildrenToPool();
		foreach (Ship ship in ships)
		{
			GObject val = slot.ShipList.AddItemFromPool();
			ShipRenderer(ship, (UI_ShipAvatar)(object)val);
		}
		slot.ShipList.ResizeToFit(ships.Count);
	}

	private void ShipRenderer(Ship ship, UI_ShipAvatar slot)
	{
		slot.IsMe.selectedIndex = ((ship.Props.UserId == CurUserId) ? 1 : 0);
		slot.CampId.selectedIndex = ship.Props.CampId;
		ProfileHelper.GetUserProfile($"{ship.Props.CampId}", ship.Details.UserId, delegate(UserProfile profile)
		{
			((GObject)slot.UserName).text = profile.Name;
		});
		AvatarHelper.GetUserAvatarSprite($"{ship.Props.CampId}", ship.Details.UserId, delegate(Sprite sprite)
		{
			//IL_0017: Unknown result type (might be due to invalid IL or missing references)
			//IL_0021: Expected O, but got Unknown
			slot.HeadPortrait.icon.texture = new NTexture((Texture)(object)sprite.texture);
		});
	}

	private void RenderGotoComponent()
	{
		Ship myShip = MapStateManager.MyShip;
		eShipSummaryState state = (eShipSummaryState)myShip.Details.State;
		UI_GoToIsland goToIsland = IslandInfoDialog.GoToIsland;
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
	}

	private void Render()
	{
		UI_IslandInfoDialog islandInfoDialog = IslandInfoDialog;
		TargetTime = -1;
		if (Island.IslandStateManager != null && Island.IslandStateManager.IslandSummary != null)
		{
			IslandSummary islandSummary = Island.IslandStateManager.IslandSummary;
			islandInfoDialog.IslandState.selectedIndex = (int)islandSummary.IslandUIState;
			islandInfoDialog.SetControllerPageText();
			((GObject)islandInfoDialog.Score).text = $"+{islandSummary.IslandScore}";
			if (islandSummary.IslandUIState == eIslandState.Peace)
			{
				AllowPushIslandCampSummary(flag: false);
			}
			if (islandSummary.IslandUIState == eIslandState.WaitingFight)
			{
				TargetTime = islandSummary.IslandAllowFightingTimestamp;
				AllowPushIslandCampSummary(flag: false);
			}
			else if (islandSummary.IslandUIState == eIslandState.Fighting)
			{
				TargetTime = islandSummary.IslandCloseTimestamp;
				AllowPushIslandCampSummary(flag: true);
			}
		}
		if (islandInfoDialog.IslandState.selectedIndex == 0 || islandInfoDialog.IslandState.selectedIndex == 1)
		{
			for (int i = 1; i < 5; i++)
			{
				RenderCampNumText(i, "0");
			}
			if (Island.DockingManager != null)
			{
				if (Island.Props.Type == IslandType.Moon)
				{
					MoonDockingManager moonDockingManager = (MoonDockingManager)Island.DockingManager;
					foreach (KeyValuePair<int, MoonDockingManager.SlotCounter> counter in moonDockingManager.Counters)
					{
						RenderCampNumText(counter.Key, $"{counter.Value.Count}");
					}
				}
				else if (Island.Props.Type == IslandType.Star)
				{
					StarDockingManager starDockingManager = (StarDockingManager)Island.DockingManager;
					foreach (KeyValuePair<int, StarDockingManager.SlotCounter> counter2 in starDockingManager.Counters)
					{
						RenderCampNumText(counter2.Key, $"{counter2.Value.Count}");
					}
				}
			}
		}
		RenderGotoComponent();
		if (TimeCounterCoroutine == null)
		{
			TimeCounterCoroutine = ((MonoBehaviour)GvGWorldMapController.Instance).StartCoroutine(UpdateTime());
		}
	}

	private void RenderCampNumText(int campId, string text)
	{
		((GComponent)IslandInfoDialog).GetChild($"Camp{campId}").text = text;
	}

	private void RenderCampsHoldingPercents(List<IslandCampSummary> camps)
	{
		foreach (IslandCampSummary camp in camps)
		{
			RenderCampNumText(camp.CampId, $"{camp.HoldingPercent}%");
		}
	}

	private IEnumerator UpdateTime()
	{
		while (true)
		{
			int serverTime = (int)GameController.Instance.GetServerTime();
			if (TargetTime != -1)
			{
				int timeLeft = TargetTime - serverTime;
				if (timeLeft < 0)
				{
					TargetTime = -1;
					timeLeft = 0;
				}
				((GObject)IslandInfoDialog.Time).text = UiHelper.ParseTime(timeLeft);
			}
			if (ArriveTime != -1)
			{
				int timeLeft2 = ArriveTime - serverTime;
				if (timeLeft2 < 0)
				{
					ArriveTime = -1;
					((GObject)IslandInfoDialog.GoToIsland.Travel).grayed = false;
					((GObject)IslandInfoDialog.GoToIsland.Travel).touchable = false;
					((GObject)IslandInfoDialog.GoToIsland.Travel.Text).text = LanguagesManager.GetDesc("CsharpCodeZhTcText308");
					((GObject)IslandInfoDialog.GoToIsland.Time).text = "";
				}
				else
				{
					((GObject)IslandInfoDialog.GoToIsland.Time).text = UiHelper.ParseTime(timeLeft2);
				}
			}
			yield return (object)new WaitForSeconds(1f);
		}
	}

	private void AllowPushIslandCampSummary(bool flag)
	{
		if (flag != PushingFlag)
		{
			PushingFlag = flag;
			int islandId = (PushingFlag ? Island.Props.Id : (-1));
			MapStateManager.AllowPushIslandCampSummary(islandId);
		}
	}

	private void OnPushIslandCampSummary(S2C_IslandCampSummary.Request req)
	{
		if (!((GObject)this).isDisposed && req.CampSummaries != null)
		{
			RenderCampsHoldingPercents(req.CampSummaries);
		}
	}

	private void OnGoTo()
	{
		if (GvGWorldMapController.Instance.OnSelectRoute(Island.Id))
		{
			End();
		}
	}

	private void OnTroopsChangeConfirm(bool confirm)
	{
		if (confirm)
		{
			OnGoTo();
		}
		else
		{
			End();
		}
	}

	private void GoTo()
	{
		if (GvGWorldMapController.Instance.StayCampIsland() && Singleton<GvGInstanceZone>.Instance.CanShowLegionChange())
		{
			((GObject)this).alpha = 0f;
			GameController.Contexts.Service<IUiService>().OpenPanel(UI_TroopsChangeConfirmPanel.Name, null);
		}
		else
		{
			OnGoTo();
		}
	}

	public void End()
	{
		GameController.Contexts.Service<IUiService>().ClosePanel(Name, reservePackageRes: true);
	}

	public void BeforeDestroy()
	{
		Island island = Island;
		island.OnChangeState = (Action)Delegate.Remove(island.OnChangeState, new Action(Render));
		if ((Object)(object)GvGWorldMapController.Instance != (Object)null)
		{
			AllowPushIslandCampSummary(flag: false);
			if (TimeCounterCoroutine != null)
			{
				((MonoBehaviour)GvGWorldMapController.Instance).StopCoroutine(TimeCounterCoroutine);
			}
		}
	}

	public void Destroy()
	{
	}

	public void OnShow()
	{
	}
}
