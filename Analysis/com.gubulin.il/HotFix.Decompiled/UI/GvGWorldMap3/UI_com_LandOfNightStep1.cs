using System;
using System.Collections.Generic;
using Assets.Scripts.Managers;
using Assets.Scripts.UI;
using FairyGUI;
using FairyGUI.Utils;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Manager;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Model;
using HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Controller;
using HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Helper;
using HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Manager;
using Shift.Legion.Common.Helpers;
using Shift.Legion.Common.Services;
using Shift.Legion.GvGServer.Models.GvGMode3IslandManagerSocket.FlagShip;

namespace UI.GvGWorldMap3;

public class UI_com_LandOfNightStep1 : GComponent, IFairyComponent
{
	public GImage n20;

	public GImage n23;

	public UI_bar_ShadowEnergy1 Progress;

	public UI_btn_CampOverview CampOverview;

	public UI_btn_MotherShip FlagShip;

	public GTextField ShadowEnergy;

	public UI_dec_Text01 n25;

	public GImage n21;

	public GTextField n22;

	public Transition t0;

	public const string URL = "ui://4eq8fgd2c4i79y";

	public static string Name = "UI_com_LandOfNightStep1";

	private bool Activated => !WorldMapConfigHelper.Configs.IsBrawlEvent() && Singleton<GvG3FlagShipMissionsManager>.Instance.IsEternalNight && !((GObject)this).isDisposed && Singleton<WorldStateManager>.Instance.Data.ProgressData.CampStep == 1;

	public static string GetURL()
	{
		return "ui://4eq8fgd2c4i79y";
	}

	public static UI_com_LandOfNightStep1 CreateInstance()
	{
		return (UI_com_LandOfNightStep1)(object)UIPackage.CreateObject("GvGWorldMap3", "com_LandOfNightStep1");
	}

	public static UI_com_LandOfNightStep1 CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_LandOfNightStep1).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://4eq8fgd2c4i79y", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		//IL_0083: Unknown result type (might be due to invalid IL or missing references)
		//IL_008d: Expected O, but got Unknown
		//IL_00af: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b9: Expected O, but got Unknown
		//IL_00c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cf: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		n20 = (GImage)((GComponent)this).GetChild("n20");
		n23 = (GImage)((GComponent)this).GetChild("n23");
		Progress = (UI_bar_ShadowEnergy1)(object)((GComponent)this).GetChild("Progress");
		CampOverview = (UI_btn_CampOverview)(object)((GComponent)this).GetChild("CampOverview");
		FlagShip = (UI_btn_MotherShip)(object)((GComponent)this).GetChild("FlagShip");
		ShadowEnergy = (GTextField)((GComponent)this).GetChild("ShadowEnergy");
		n25 = (UI_dec_Text01)(object)((GComponent)this).GetChild("n25");
		n21 = (GImage)((GComponent)this).GetChild("n21");
		n22 = (GTextField)((GComponent)this).GetChild("n22");
		string id = "ui://4eq8fgd2c4i79y".Replace("ui://", "") + "-" + ((GObject)n22).id;
		((GObject)n22).text = LanguagesManager.GetDesc(id);
		t0 = ((GComponent)this).GetTransition("t0");
	}

	public void Destroy()
	{
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
		((GObject)CampOverview).onClick.Set(new EventCallback0(ShowCampPlayers));
		GvG3FlagShipMissionsManager instance = Singleton<GvG3FlagShipMissionsManager>.Instance;
		instance.OnCampProgressChange = (Action)Delegate.Combine(instance.OnCampProgressChange, new Action(Render));
		GvG3FlagShipMissionsManager instance2 = Singleton<GvG3FlagShipMissionsManager>.Instance;
		instance2.OnFinalProgressInfoChange = (Action)Delegate.Combine(instance2.OnFinalProgressInfoChange, new Action(Render));
		((GObject)FlagShip).onClick.Set(new EventCallback1(FocusIsland));
	}

	public void UnregisterUiEvent()
	{
		((GObject)CampOverview).onClick.Clear();
		GvG3FlagShipMissionsManager instance = Singleton<GvG3FlagShipMissionsManager>.Instance;
		instance.OnCampProgressChange = (Action)Delegate.Remove(instance.OnCampProgressChange, new Action(Render));
		GvG3FlagShipMissionsManager instance2 = Singleton<GvG3FlagShipMissionsManager>.Instance;
		instance2.OnFinalProgressInfoChange = (Action)Delegate.Remove(instance2.OnFinalProgressInfoChange, new Action(Render));
		((GObject)FlagShip).onClick.Clear();
	}

	public void Render()
	{
		if (Activated)
		{
			CampOverview.Camp.selectedIndex = Singleton<WorldStateManager>.Instance.Data.MyCampId;
			CampMainMissionUiModel eternalNightMainMission = Singleton<GvG3FlagShipMissionsManager>.Instance.EternalNightMainMission;
			if (eternalNightMainMission.MainMission != null)
			{
				long num = eternalNightMainMission.MainMission.CheckValues[0];
				long campShadowEnergy = Singleton<GvG3FlagShipMissionsManager>.Instance.FinalProgressInfo.CampShadowEnergy;
				((GProgressBar)Progress).value = (double)campShadowEnergy / (double)num * 100.0;
				((GObject)ShadowEnergy).text = ((int)campShadowEnergy).ShortNumberFormat() + "/" + ((int)num).ShortNumberFormat();
			}
			FlagShip.Camp.selectedIndex = Singleton<WorldStateManager>.Instance.Data.MyCampId;
			((GObject)FlagShip).data = new LocationData
			{
				IslandId = Singleton<WorldStateManager>.Instance.Data.OurFlagShipStayIslandId,
				Type = 3,
				Step = 0
			};
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

	public static bool IsEternalNightMainMissionExist()
	{
		CampMainMissionUiModel eternalNightMainMission = Singleton<GvG3FlagShipMissionsManager>.Instance.EternalNightMainMission;
		return eternalNightMainMission.MainMission != null;
	}
}
