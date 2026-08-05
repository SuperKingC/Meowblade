using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GVGStore;

public class UI_com_ExchangeFormulaConfirmDialog : GComponent
{
	public GImage back;

	public UI_btn_confirm3 Confirm;

	public UI_btn_Cancel Cancel;

	public GTextField Tip;

	public GImage n31;

	public UI_com_FormulaFreeExchangeInputItems Input;

	public UI_com_FormulaFreeExchangeInputItems Output;

	public const string URL = "ui://fvc33k3gv6i713";

	public static string Name = "UI_com_ExchangeFormulaConfirmDialog";

	public static string GetURL()
	{
		return "ui://fvc33k3gv6i713";
	}

	public static UI_com_ExchangeFormulaConfirmDialog CreateInstance()
	{
		return (UI_com_ExchangeFormulaConfirmDialog)(object)UIPackage.CreateObject("GVGStore", "com_ExchangeFormulaConfirmDialog");
	}

	public static UI_com_ExchangeFormulaConfirmDialog CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_ExchangeFormulaConfirmDialog).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://fvc33k3gv6i713", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		//IL_0061: Expected O, but got Unknown
		//IL_00aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b4: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		back = (GImage)((GComponent)this).GetChild("back");
		Confirm = (UI_btn_confirm3)(object)((GComponent)this).GetChild("Confirm");
		Cancel = (UI_btn_Cancel)(object)((GComponent)this).GetChild("Cancel");
		Tip = (GTextField)((GComponent)this).GetChild("Tip");
		string id = "ui://fvc33k3gv6i713".Replace("ui://", "") + "-" + ((GObject)Tip).id;
		((GObject)Tip).text = LanguagesManager.GetDesc(id);
		n31 = (GImage)((GComponent)this).GetChild("n31");
		Input = (UI_com_FormulaFreeExchangeInputItems)(object)((GComponent)this).GetChild("Input");
		Output = (UI_com_FormulaFreeExchangeInputItems)(object)((GComponent)this).GetChild("Output");
	}
}
