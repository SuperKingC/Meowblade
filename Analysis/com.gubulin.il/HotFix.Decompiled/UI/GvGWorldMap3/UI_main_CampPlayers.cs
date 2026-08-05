using System.Collections.Generic;
using FairyGUI;
using FairyGUI.Utils;
using HotFix.Sources.Base.Scripts.Helper;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Manager;
using HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Helper;
using HotFix.Sources.Shift.Legion.Shift.Legion.Common.Sources.Extensions;
using Shift.Legion.Common.Helpers;
using Shift.Legion.Common.Services;
using Shift.Legion.GvGServer.Models.GvGMode3IslandManagerSocket.FlagShip;
using UI.PublicResources;

namespace UI.GvGWorldMap3;

public class UI_main_CampPlayers : GComponent, IUiController
{
	public GGraph back;

	public UI_com_CampPlayers PopUp;

	public const string URL = "ui://4eq8fgd2qf7c7u";

	public static string Name = "UI_main_CampPlayers";

	private int _myUserId;

	private C2S_GetCampInfo.Response _campInfo;

	public static string GetURL()
	{
		return "ui://4eq8fgd2qf7c7u";
	}

	public static UI_main_CampPlayers CreateInstance()
	{
		return (UI_main_CampPlayers)(object)UIPackage.CreateObject("GvGWorldMap3", "main_CampPlayers");
	}

	public static UI_main_CampPlayers CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_main_CampPlayers).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://4eq8fgd2qf7c7u", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		back = (GGraph)((GComponent)this).GetChild("back");
		PopUp = (UI_com_CampPlayers)(object)((GComponent)this).GetChild("PopUp");
	}

	public void BeforeDestroy()
	{
	}

	public void Destroy()
	{
	}

	public void Init(Dictionary<string, object> parameters)
	{
		FGUIManager.SetUiPanelSizeAndXy((GObject)(object)this, scaleAdaption: true);
		_myUserId = GameController.Contexts.gameState.user.value.UserId;
		_campInfo = (parameters.TryGetValue("CampInfo", out var value) ? (value as C2S_GetCampInfo.Response) : null);
		Render();
	}

	public void OnShow()
	{
	}

	public void RegisterUiEventListeners()
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected O, but got Unknown
		((GObject)back).onClick.Set(new EventCallback0(End));
	}

	public void UnregisterUiEventListeners()
	{
		((GObject)back).onClick.Clear();
	}

	private void End()
	{
		GameController.Contexts.Service<IUiService>().ClosePanel(Name, reservePackageRes: true);
	}

	private void Render()
	{
		//IL_00e5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ef: Expected O, but got Unknown
		if (_campInfo != null)
		{
			((GObject)PopUp.CampName).text = WorldMapConfigHelper.TryGetCampPrefabConfig(Singleton<GvGMode3RoomManager>.Instance.ObserverRecord.ObCampId).CampName.ToLanguage();
			((GObject)PopUp.PlayerNumber).text = _campInfo.CampUserCount.ToString();
			((GObject)PopUp.ShipsNumber).text = _campInfo.CampShipCount.ToString();
			((GObject)PopUp.IslandNumber).text = _campInfo.IslandCount.ToString();
			_campInfo.Users.Sort(SortUserInfo);
			PopUp.Players.SetVirtual();
			PopUp.Players.itemRenderer = new ListItemRenderer(PlayerComRenderer);
			PopUp.Players.numItems = _campInfo.Users.Count;
			PopUp.Camp.selectedIndex = Singleton<GvGMode3RoomManager>.Instance.ObserverRecord.ObCampId;
		}
		void PlayerComRenderer(int index, GObject obj)
		{
			if (obj is UI_com_CampPlayer uI_com_CampPlayer)
			{
				CampUserInfo campUserInfo = _campInfo.Users[index];
				((GObject)uI_com_CampPlayer.ShipNumber).text = campUserInfo.ShipCount.ToString();
				bool hideName = campUserInfo.UserId == GameController.Contexts.gameState.user.value.UserId;
				uI_com_CampPlayer.IsMe.SetSelectedIndex(hideName ? 1 : 0);
				uI_com_CampPlayer.ProfileDisplay.RenderPlayerProfileGvG3(new PlayerProfileParams<UI_com_ProfileDisplayCenter>
				{
					CacheVersion = $"{Singleton<GvGMode3RoomManager>.Instance.ObserverRecord.CurIZId}",
					UserId = campUserInfo.UserId,
					CampId = Singleton<GvGMode3RoomManager>.Instance.ObserverRecord.ObCampId,
					OnProfileLoaded = delegate(UI_com_ProfileDisplayCenter profileUi)
					{
						profileUi.Style.SetSelectedIndex(hideName ? 1 : 0);
					}
				}, campUserInfo.UserId);
			}
		}
	}

	private int SortUserInfo(CampUserInfo a, CampUserInfo b)
	{
		if (a.UserId == _myUserId && b.UserId != _myUserId)
		{
			return -1;
		}
		if (b.UserId == _myUserId && a.UserId != _myUserId)
		{
			return 1;
		}
		return 0;
	}
}
