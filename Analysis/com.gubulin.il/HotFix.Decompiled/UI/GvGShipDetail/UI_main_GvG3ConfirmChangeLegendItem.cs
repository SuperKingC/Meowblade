using System;
using System.Collections.Generic;
using FairyGUI;
using FairyGUI.Utils;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Manager;
using Shift.Legion.Common.Helpers;
using Shift.Legion.Common.Services;
using UnityEngine;

namespace UI.GvGShipDetail;

public class UI_main_GvG3ConfirmChangeLegendItem : GComponent, IUiController
{
	public GGraph Mask;

	public UI_com_ConfirmChangeLegendItem PopUp;

	public const string URL = "ui://u6x0b1gnoip461";

	public static string Name = "UI_main_GvG3ConfirmChangeLegendItem";

	private Action _changeLegendItem;

	private readonly string _doNotShowAgain = $"{Singleton<GvGMode3RoomManager>.Instance.ObserverRecord.CurIZId}_{GameController.Contexts.gameState.user.value.UserId}_ShipChangeLegendItemTip";

	public static string GetURL()
	{
		return "ui://u6x0b1gnoip461";
	}

	public static UI_main_GvG3ConfirmChangeLegendItem CreateInstance()
	{
		return (UI_main_GvG3ConfirmChangeLegendItem)(object)UIPackage.CreateObject("GvGShipDetail", "main_GvG3ConfirmChangeLegendItem");
	}

	public static UI_main_GvG3ConfirmChangeLegendItem CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_main_GvG3ConfirmChangeLegendItem).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://u6x0b1gnoip461", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Mask = (GGraph)((GComponent)this).GetChild("Mask");
		PopUp = (UI_com_ConfirmChangeLegendItem)(object)((GComponent)this).GetChild("PopUp");
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
		_changeLegendItem = (parameters.TryGetValue("OpenLegendItemsPanel", out var value) ? (value as Action) : null);
		((GButton)PopUp.DoNotShowAgain).selected = PlayerPrefs.GetInt(_doNotShowAgain, 0) > 0;
	}

	public void OnShow()
	{
	}

	public void RegisterUiEventListeners()
	{
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_0022: Expected O, but got Unknown
		((GObject)PopUp.Confirm).onClick.Set(new EventCallback0(Confirm));
	}

	public void UnregisterUiEventListeners()
	{
		((GObject)PopUp.Confirm).onClick.Clear();
	}

	private void End()
	{
		GameController.Contexts.Service<IUiService>().ClosePanel(Name, reservePackageRes: true);
	}

	private void Confirm()
	{
		if (((GButton)PopUp.DoNotShowAgain).selected)
		{
			PlayerPrefs.SetInt(_doNotShowAgain, 1);
		}
		_changeLegendItem?.Invoke();
		End();
	}
}
