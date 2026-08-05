using System;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GVGStore;

public class UI_com_FormulaFreeExchange : GComponent
{
	public GImage n2;

	public GImage n7;

	public GImage n8;

	public GImage n1;

	public UI_btn_confirm2 Exchange;

	public UI_com_FormulaFreeExchangeOutput Output;

	public UI_com_FormulaFreeExchangeInput Input;

	public const string URL = "ui://fvc33k3g7nboi";

	public static string Name = "UI_com_FormulaFreeExchange";

	private int _index;

	private Action<int> _eventCallback;

	public static string GetURL()
	{
		return "ui://fvc33k3g7nboi";
	}

	public static UI_com_FormulaFreeExchange CreateInstance()
	{
		return (UI_com_FormulaFreeExchange)(object)UIPackage.CreateObject("GVGStore", "com_FormulaFreeExchange");
	}

	public static UI_com_FormulaFreeExchange CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_FormulaFreeExchange).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://fvc33k3g7nboi", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		//IL_0061: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		n2 = (GImage)((GComponent)this).GetChild("n2");
		n7 = (GImage)((GComponent)this).GetChild("n7");
		n8 = (GImage)((GComponent)this).GetChild("n8");
		n1 = (GImage)((GComponent)this).GetChild("n1");
		Exchange = (UI_btn_confirm2)(object)((GComponent)this).GetChild("Exchange");
		Output = (UI_com_FormulaFreeExchangeOutput)(object)((GComponent)this).GetChild("Output");
		Input = (UI_com_FormulaFreeExchangeInput)(object)((GComponent)this).GetChild("Input");
	}

	public void Init(int index, Action<int> callback0)
	{
		//IL_0021: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Expected O, but got Unknown
		//IL_003e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0048: Expected O, but got Unknown
		_index = index;
		_eventCallback = callback0;
		((GObject)Input).onClick.Set(new EventCallback0(ChangInputState));
		((GObject)Output).onClick.Set(new EventCallback0(ChangeOutputState));
	}

	private void ChangInputState()
	{
		int controllerState = (int)Input.DropDownController.ControllerState;
		DropDownControllerState dropDownControllerState = (DropDownControllerState)(1 - controllerState);
		Input.DropDownController.ControllerState = dropDownControllerState;
		if (dropDownControllerState == DropDownControllerState.Expanded)
		{
			Output.DropDownController.ControllerState = DropDownControllerState.Collapsed;
		}
		_eventCallback?.Invoke(_index);
	}

	private void ChangeOutputState()
	{
		int controllerState = (int)Output.DropDownController.ControllerState;
		DropDownControllerState dropDownControllerState = (DropDownControllerState)(1 - controllerState);
		Output.DropDownController.ControllerState = dropDownControllerState;
		if (dropDownControllerState == DropDownControllerState.Expanded)
		{
			Input.DropDownController.ControllerState = DropDownControllerState.Collapsed;
		}
		_eventCallback?.Invoke(_index);
	}

	public void Collapse()
	{
		Input.DropDownController.ControllerState = DropDownControllerState.Collapsed;
		Output.DropDownController.ControllerState = DropDownControllerState.Collapsed;
	}
}
