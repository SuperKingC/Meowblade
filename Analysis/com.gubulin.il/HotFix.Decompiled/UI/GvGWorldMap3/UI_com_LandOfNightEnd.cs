using System;
using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Manager;
using HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Controller;
using HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Helper;
using HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Manager;
using Shift.Legion.Common.Helpers;
using Shift.Legion.Common.Services;
using Shift.Legion.GvGServer.Models.GvGMode3IslandManagerSocket.FlagShip;
using UnityEngine;

namespace UI.GvGWorldMap3;

public class UI_com_LandOfNightEnd : GComponent, IFairyComponent
{
	public GImage n34;

	public GImage n36;

	public GImage n37;

	public UI_btn_CampOverview CampOverview;

	public GTextField ZoneName;

	public GTextField n29;

	public GTextField Countdown;

	public GGroup n32;

	public GButton Help;

	public UI_btn_MotherShip FlagShip;

	public const string URL = "ui://4eq8fgd2zit4ad";

	public static string Name = "UI_com_LandOfNightEnd";

	private Window _helpWindow;

	private Coroutine _updateCountdown;

	private readonly WaitForSeconds _perSecond = new WaitForSeconds(1f);

	private bool Activated => Singleton<GvG3FlagShipMissionsManager>.Instance.HasSettlement && !((GObject)this).isDisposed;

	public static string GetURL()
	{
		return "ui://4eq8fgd2zit4ad";
	}

	public static UI_com_LandOfNightEnd CreateInstance()
	{
		return (UI_com_LandOfNightEnd)(object)UIPackage.CreateObject("GvGWorldMap3", "com_LandOfNightEnd");
	}

	public static UI_com_LandOfNightEnd CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_LandOfNightEnd).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://4eq8fgd2zit4ad", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Expected O, but got Unknown
		//IL_006d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0077: Expected O, but got Unknown
		//IL_0083: Unknown result type (might be due to invalid IL or missing references)
		//IL_008d: Expected O, but got Unknown
		//IL_00d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e0: Expected O, but got Unknown
		//IL_00ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f6: Expected O, but got Unknown
		//IL_0102: Unknown result type (might be due to invalid IL or missing references)
		//IL_010c: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		n34 = (GImage)((GComponent)this).GetChild("n34");
		n36 = (GImage)((GComponent)this).GetChild("n36");
		n37 = (GImage)((GComponent)this).GetChild("n37");
		CampOverview = (UI_btn_CampOverview)(object)((GComponent)this).GetChild("CampOverview");
		ZoneName = (GTextField)((GComponent)this).GetChild("ZoneName");
		n29 = (GTextField)((GComponent)this).GetChild("n29");
		string id = "ui://4eq8fgd2zit4ad".Replace("ui://", "") + "-" + ((GObject)n29).id;
		((GObject)n29).text = LanguagesManager.GetDesc(id);
		Countdown = (GTextField)((GComponent)this).GetChild("Countdown");
		n32 = (GGroup)((GComponent)this).GetChild("n32");
		Help = (GButton)((GComponent)this).GetChild("Help");
		FlagShip = (UI_btn_MotherShip)(object)((GComponent)this).GetChild("FlagShip");
	}

	public void Destroy()
	{
		Window helpWindow = _helpWindow;
		if (helpWindow != null)
		{
			((GObject)helpWindow).Dispose();
		}
		if (_updateCountdown != null)
		{
			FGUIManager.Instance.CloseIEnumerator(_updateCountdown);
		}
	}

	public void Init()
	{
		if (Activated)
		{
			Render();
		}
	}

	public void RegisterUiEvent()
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected O, but got Unknown
		//IL_007c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0086: Expected O, but got Unknown
		//IL_0099: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a3: Expected O, but got Unknown
		((GObject)CampOverview).onClick.Set(new EventCallback0(ShowCampPlayers));
		GvG3FlagShipMissionsManager instance = Singleton<GvG3FlagShipMissionsManager>.Instance;
		instance.OnCampProgressChange = (Action)Delegate.Combine(instance.OnCampProgressChange, new Action(Render));
		GvG3FlagShipMissionsManager instance2 = Singleton<GvG3FlagShipMissionsManager>.Instance;
		instance2.OnFinalProgressInfoChange = (Action)Delegate.Combine(instance2.OnFinalProgressInfoChange, new Action(Render));
		((GObject)FlagShip).onClick.Set(new EventCallback1(FocusIsland));
		((GObject)Help).onClick.Set(new EventCallback1(ShowHelpInfo));
	}

	public void UnregisterUiEvent()
	{
		((GObject)CampOverview).onClick.Clear();
		GvG3FlagShipMissionsManager instance = Singleton<GvG3FlagShipMissionsManager>.Instance;
		instance.OnCampProgressChange = (Action)Delegate.Remove(instance.OnCampProgressChange, new Action(Render));
		GvG3FlagShipMissionsManager instance2 = Singleton<GvG3FlagShipMissionsManager>.Instance;
		instance2.OnFinalProgressInfoChange = (Action)Delegate.Remove(instance2.OnFinalProgressInfoChange, new Action(Render));
		((GObject)FlagShip).onClick.Clear();
		((GObject)Help).onClick.Clear();
	}

	private void Render()
	{
		if (Activated)
		{
			CampOverview.Camp.selectedIndex = Singleton<GvGMode3RoomManager>.Instance.ObserverRecord.ObCampId;
			((GObject)ZoneName).text = Singleton<GvGMode3RoomManager>.Instance.CurIzName;
			if (_updateCountdown != null)
			{
				FGUIManager.Instance.CloseIEnumerator(_updateCountdown);
			}
			_updateCountdown = FGUIManager.Instance.OpenIEnumerator(RefreshCountdown());
			((GObject)FlagShip).data = new LocationData
			{
				IslandId = Singleton<WorldStateManager>.Instance.Data.OurFlagShipStayIslandId,
				Type = 3,
				Step = 0
			};
		}
		IEnumerator RefreshCountdown()
		{
			int endTimestamp = Singleton<WorldStateManager>.Instance.Data.IZEndTimestamp;
			while (!((GObject)this).isDisposed)
			{
				((GObject)Countdown).text = Singleton<WorldStateManager>.Instance.Data.ProgressData.GetCountdown(endTimestamp);
				yield return _perSecond;
			}
		}
	}

	private void ShowCampPlayers()
	{
		Singleton<GvG3FlagShipMissionsManager>.Instance.GetCampInfo(ShowCampInfo);
		static void ShowCampInfo(C2S_GetCampInfo.Response response)
		{
			GameController.Contexts.Service<IUiService>().OpenPanel(UI_main_CampPlayers.Name, new Dictionary<string, object> { { "CampInfo", response } });
		}
	}

	private void FocusIsland(EventContext context)
	{
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0013: Expected O, but got Unknown
		//IL_003b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c1: Expected O, but got Unknown
		GObject val = (GObject)context.sender;
		LocationData locationData = (LocationData)val.data;
		if (locationData != null)
		{
			UI_com_Islandlocation uI_com_Islandlocation = FairyGUITip.ShowTip<UI_com_Islandlocation>(val, eFairyGUITipDir.Down);
			uI_com_Islandlocation.Step.selectedIndex = locationData.Step;
			uI_com_Islandlocation.Type.selectedIndex = locationData.Type;
			((GObject)uI_com_Islandlocation.IslandName).text = WorldMapConfigHelper.Configs.TryGetIsland(locationData.IslandId)?.Name;
			((GObject)uI_com_Islandlocation.Positioning).onClick.Set((EventCallback0)delegate
			{
				GvGWorldMapController.Instance.FocusIslandById(locationData.IslandId);
			});
		}
	}

	private void ShowHelpInfo(EventContext context)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Expected O, but got Unknown
		//IL_0031: Unknown result type (might be due to invalid IL or missing references)
		//IL_0036: Unknown result type (might be due to invalid IL or missing references)
		//IL_003e: Unknown result type (might be due to invalid IL or missing references)
		//IL_004f: Expected O, but got Unknown
		GObject val = (GObject)context.sender;
		if (_helpWindow == null)
		{
			GComponent asCom = UIPackage.CreateObject("GvGWorldMap3", "com_HelpInfo").asCom;
			_helpWindow = new Window
			{
				contentPane = asCom,
				sortingOrder = 3000
			};
		}
		GRoot.inst.ShowPopup((GObject)(object)_helpWindow, val);
		((GObject)_helpWindow).SetXY(((GObject)GRoot.inst).width / 2f, ((GObject)GRoot.inst).height / 2f);
	}
}
