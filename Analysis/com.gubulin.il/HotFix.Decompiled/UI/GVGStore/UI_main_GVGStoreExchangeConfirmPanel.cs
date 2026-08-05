using System;
using System.Collections.Generic;
using FairyGUI;
using FairyGUI.Utils;
using Shift.Legion.Common.Services;

namespace UI.GVGStore;

public class UI_main_GVGStoreExchangeConfirmPanel : GComponent, IUiController
{
	public GGraph Mask;

	public UI_com_ExchangeFormulaConfirmDialog Dialog;

	public Transition ShowDialog;

	public const string URL = "ui://fvc33k3gv6i715";

	public static string Name = "UI_main_GVGStoreExchangeConfirmPanel";

	private List<string> _inputItemIds = new List<string>();

	private List<string> _outputItemIds = new List<string>();

	private Action _confirmExchange;

	public static string GetURL()
	{
		return "ui://fvc33k3gv6i715";
	}

	public static UI_main_GVGStoreExchangeConfirmPanel CreateInstance()
	{
		return (UI_main_GVGStoreExchangeConfirmPanel)(object)UIPackage.CreateObject("GVGStore", "main_GVGStoreExchangeConfirmPanel");
	}

	public static UI_main_GVGStoreExchangeConfirmPanel CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_main_GVGStoreExchangeConfirmPanel).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://fvc33k3gv6i715", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Mask = (GGraph)((GComponent)this).GetChild("Mask");
		Dialog = (UI_com_ExchangeFormulaConfirmDialog)(object)((GComponent)this).GetChild("Dialog");
		ShowDialog = ((GComponent)this).GetTransition("ShowDialog");
	}

	public void BeforeDestroy()
	{
	}

	public void Destroy()
	{
	}

	public void Init(Dictionary<string, object> parameters)
	{
		FGUIManager.SetUiPanelSizeAndXy((GObject)(object)this);
		ReadFormulaData(parameters);
		RenderDialog();
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
		((GObject)Mask).onClick.Add(new EventCallback0(End));
		((GObject)Dialog.Cancel).onClick.Add(new EventCallback0(End));
		((GObject)Dialog.Confirm).onClick.Add(new EventCallback0(ConfirmEvent));
	}

	public void UnregisterUiEventListeners()
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected O, but got Unknown
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Expected O, but got Unknown
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		//IL_0061: Expected O, but got Unknown
		((GObject)Mask).onClick.Remove(new EventCallback0(End));
		((GObject)Dialog.Cancel).onClick.Remove(new EventCallback0(End));
		((GObject)Dialog.Confirm).onClick.Remove(new EventCallback0(ConfirmEvent));
	}

	private void End()
	{
		GameController.Contexts.Service<IUiService>().ClosePanel(Name, reservePackageRes: true);
	}

	private void ReadFormulaData(Dictionary<string, object> parameters)
	{
		_inputItemIds = (parameters.TryGetValue("InputData", out var value) ? (value as List<string>) : new List<string>());
		_outputItemIds = (parameters.TryGetValue("OutputData", out var value2) ? (value2 as List<string>) : new List<string>());
		_confirmExchange = (parameters.TryGetValue("ConfirmExchange", out var value3) ? (value3 as Action) : null);
	}

	private void RenderDialog()
	{
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_0022: Expected O, but got Unknown
		//IL_005a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0064: Expected O, but got Unknown
		Dialog.Input.Items.itemRenderer = new ListItemRenderer(RenderInputItem);
		Dialog.Input.Items.numItems = _inputItemIds.Count;
		Dialog.Output.Items.itemRenderer = new ListItemRenderer(RenderOutputItem);
		Dialog.Output.Items.numItems = _outputItemIds.Count;
	}

	private void RenderInputItem(int index, GObject obj)
	{
		if (obj is UI_com_Material0 uI_com_Material)
		{
			FGUIManager.Instance.SetItemIconAndFrame(uI_com_Material.Icon, _inputItemIds[index], null, "", frameVisible: false);
		}
	}

	private void RenderOutputItem(int index, GObject obj)
	{
		if (obj is UI_com_Material0 uI_com_Material)
		{
			FGUIManager.Instance.SetItemIconAndFrame(uI_com_Material.Icon, _outputItemIds[index], null, "", frameVisible: false);
		}
	}

	private void ConfirmEvent()
	{
		_confirmExchange?.Invoke();
		End();
	}
}
