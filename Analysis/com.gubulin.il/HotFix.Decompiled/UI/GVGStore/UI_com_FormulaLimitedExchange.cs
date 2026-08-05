using FairyGUI;
using FairyGUI.Utils;

namespace UI.GVGStore;

public class UI_com_FormulaLimitedExchange : GComponent
{
	public GImage n5;

	public GImage n6;

	public GImage n7;

	public GImage n1;

	public GList Input;

	public GList Output;

	public UI_btn_confirm2 Exchange;

	public const string URL = "ui://fvc33k3g7nbof";

	public static string Name = "UI_com_FormulaLimitedExchange";

	public static string GetURL()
	{
		return "ui://fvc33k3g7nbof";
	}

	public static UI_com_FormulaLimitedExchange CreateInstance()
	{
		return (UI_com_FormulaLimitedExchange)(object)UIPackage.CreateObject("GVGStore", "com_FormulaLimitedExchange");
	}

	public static UI_com_FormulaLimitedExchange CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_FormulaLimitedExchange).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://fvc33k3g7nbof", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_006d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0077: Expected O, but got Unknown
		//IL_0083: Unknown result type (might be due to invalid IL or missing references)
		//IL_008d: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		n5 = (GImage)((GComponent)this).GetChild("n5");
		n6 = (GImage)((GComponent)this).GetChild("n6");
		n7 = (GImage)((GComponent)this).GetChild("n7");
		n1 = (GImage)((GComponent)this).GetChild("n1");
		Input = (GList)((GComponent)this).GetChild("Input");
		Output = (GList)((GComponent)this).GetChild("Output");
		Exchange = (UI_btn_confirm2)(object)((GComponent)this).GetChild("Exchange");
	}
}
