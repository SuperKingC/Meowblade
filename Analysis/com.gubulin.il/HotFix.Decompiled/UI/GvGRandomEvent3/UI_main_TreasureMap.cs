using System.Collections.Generic;
using FairyGUI;
using FairyGUI.Utils;
using HotFix.Sources.Base.Scripts.Helper;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Manager;
using HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Controller;
using Shift.Legion.Common.Helpers;
using Shift.Legion.Common.Services;
using Shift.Legion.GvGServer.Models.GvGMode3IslandManagerSocket;
using Shift.Legion.Rank.Helpers;

namespace UI.GvGRandomEvent3;

public class UI_main_TreasureMap : GComponent, IUiController
{
	public GGraph Mask;

	public UI_com_TreasureMap PopUp;

	public const string URL = "ui://p4ocf6q0dc6m8";

	public static string Name = "UI_main_TreasureMap";

	private TreasureMapInfo _treasureMapInfo;

	public static string GetURL()
	{
		return "ui://p4ocf6q0dc6m8";
	}

	public static UI_main_TreasureMap CreateInstance()
	{
		return (UI_main_TreasureMap)(object)UIPackage.CreateObject("GvGRandomEvent3", "main_TreasureMap");
	}

	public static UI_main_TreasureMap CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_main_TreasureMap).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://p4ocf6q0dc6m8", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Mask = (GGraph)((GComponent)this).GetChild("Mask");
		PopUp = (UI_com_TreasureMap)(object)((GComponent)this).GetChild("PopUp");
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
		_treasureMapInfo = (parameters.TryGetValue("TreasureMapInfo", out var value) ? (value as TreasureMapInfo) : null);
		List<string> list = "GvG3TreasureMapDesc".ToConfiguration<List<string>>();
		((GObject)PopUp.Desc).text = list.Choose(1)[0].ToLanguage();
		((GObject)PopUp.CancelEvent).visible = _treasureMapInfo?.TreasureMap_MConfigId == "GCM_RANDOM_EVENT_TM_0";
	}

	public void OnShow()
	{
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
		((GObject)Mask).onClick.Set(new EventCallback0(End));
		((GObject)PopUp.Close).onClick.Set(new EventCallback0(End));
		((GObject)PopUp.Location).onClick.Set(new EventCallback0(Confirm));
		((GObject)PopUp.CancelEvent).onClick.Set(new EventCallback0(CancelTreasureMapMission));
	}

	public void UnregisterUiEventListeners()
	{
		((GObject)Mask).onClick.Clear();
		((GObject)PopUp.Close).onClick.Clear();
		((GObject)PopUp.Location).onClick.Clear();
		((GObject)PopUp.CancelEvent).onClick.Clear();
	}

	private void Confirm()
	{
		GvGWorldMapController.Instance.FocusIslandById(_treasureMapInfo.TreasureMap_IslandId);
		End();
	}

	private void CancelTreasureMapMission()
	{
		"GvG3CancelTreasureMapMissionTip".ToLanguage().ToConfirmPopup(OnConfirmClick, OnCancelClick, (AlignType)0, 40, mirrorBtns: true);
		static void OnCancelClick()
		{
		}
		void OnConfirmClick()
		{
			Singleton<GvG3EventMissionManager>.Instance.CancelTreasureMapMission();
			End();
		}
	}

	private void End()
	{
		GameController.Contexts.Service<IUiService>().ClosePanel(Name);
	}
}
