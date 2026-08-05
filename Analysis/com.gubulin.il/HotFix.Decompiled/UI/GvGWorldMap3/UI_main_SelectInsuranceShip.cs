using System;
using System.Collections.Generic;
using FairyGUI;
using FairyGUI.Utils;
using HotFix.Sources.Base.Sources.Scripts.GvG3.GvG3UI.Model.BattlePass;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Helper;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Manager;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Model;
using Shift.Legion.Common.Helpers;
using Shift.Legion.Common.Services;

namespace UI.GvGWorldMap3;

public class UI_main_SelectInsuranceShip : GComponent, IUiController
{
	public class OpenParameters
	{
		public int SelectedIndex;

		public List<GvGInsuranceShip> Ships;

		public Action<GvGInsuranceShip> OnSelect;
	}

	public GGraph back;

	public UI_com_SelectInsuranceShip Dialog;

	public const string URL = "ui://4eq8fgd2eo52b6sdb";

	public static string Name = "UI_main_SelectInsuranceShip";

	private const string OPEN_PARAMETERS = "Parameters";

	private List<GvGInsuranceShip> _ships;

	private Action<GvGInsuranceShip> _onSelect;

	private int _selectedIndex;

	public static string GetURL()
	{
		return "ui://4eq8fgd2eo52b6sdb";
	}

	public static UI_main_SelectInsuranceShip CreateInstance()
	{
		return (UI_main_SelectInsuranceShip)(object)UIPackage.CreateObject("GvGWorldMap3", "main_SelectInsuranceShip");
	}

	public static UI_main_SelectInsuranceShip CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_main_SelectInsuranceShip).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://4eq8fgd2eo52b6sdb", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		back = (GGraph)((GComponent)this).GetChild("back");
		Dialog = (UI_com_SelectInsuranceShip)(object)((GComponent)this).GetChild("Dialog");
	}

	public static void OpenSelectInsuranceShipPanel(OpenParameters parameters)
	{
		GameController.Contexts.Service<IUiService>().OpenPanel(Name, new Dictionary<string, object> { { "Parameters", parameters } });
	}

	private static void End()
	{
		GameController.Contexts.Service<IUiService>().ClosePanel(Name, reservePackageRes: true);
	}

	public void RegisterUiEventListeners()
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected O, but got Unknown
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Expected O, but got Unknown
		((GObject)back).onClick.Set(new EventCallback0(End));
		((GObject)Dialog.Confirm).onClick.Set(new EventCallback0(OnConfirmClick));
	}

	public void UnregisterUiEventListeners()
	{
		((GObject)back).onClick.Clear();
		((GObject)Dialog.Confirm).onClick.Clear();
	}

	public void Init(Dictionary<string, object> parameters)
	{
		FGUIManager.SetUiPanelSizeAndXy((GObject)(object)this, scaleAdaption: true);
		ReadParameters(parameters);
		RenderShips();
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

	private void RenderShips()
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected O, but got Unknown
		Dialog.Ships.itemRenderer = new ListItemRenderer(ShipRenderer);
		Dialog.Ships.numItems = _ships.Count;
		Dialog.Ships.selectedIndex = _selectedIndex;
	}

	private void ShipRenderer(int index, GObject obj)
	{
		if (!(obj is UI_btn_InsuranceShip uI_btn_InsuranceShip))
		{
			throw new Exception("UI_main_SelectInsuranceShip ShipRenderer obj is not UI_btn_InsuranceShip");
		}
		GvGInsuranceShip gvGInsuranceShip = _ships[index];
		((GObject)uI_btn_InsuranceShip.ShipName).text = Singleton<GvGMode3RoomManager>.Instance.ObserverRecord.GetMyShipName(gvGInsuranceShip.ShipId);
		ShipConfigModel byShipRaceType = ShipConfigHelper.GetByShipRaceType(gvGInsuranceShip.ShipRace);
		uI_btn_InsuranceShip.ShipIcon.url = ShipConfigHelper.GetSkinById(byShipRaceType.DefaultSkinId).IconUrl;
	}

	private void ReadParameters(Dictionary<string, object> parameters)
	{
		OpenParameters openParameters = (OpenParameters)parameters["Parameters"];
		_selectedIndex = openParameters.SelectedIndex;
		_ships = openParameters.Ships;
		_onSelect = openParameters.OnSelect;
	}

	private void OnConfirmClick()
	{
		GvGInsuranceShip obj = _ships[Dialog.Ships.selectedIndex];
		_onSelect?.Invoke(obj);
		End();
	}
}
