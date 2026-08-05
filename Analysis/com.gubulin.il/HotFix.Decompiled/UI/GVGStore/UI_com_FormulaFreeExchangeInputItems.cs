using FairyGUI;
using FairyGUI.Utils;

namespace UI.GVGStore;

public class UI_com_FormulaFreeExchangeInputItems : GComponent
{
	public GList Items;

	public const string URL = "ui://fvc33k3g7nbom";

	public static string Name = "UI_com_FormulaFreeExchangeInputItems";

	public static string GetURL()
	{
		return "ui://fvc33k3g7nbom";
	}

	public static UI_com_FormulaFreeExchangeInputItems CreateInstance()
	{
		return (UI_com_FormulaFreeExchangeInputItems)(object)UIPackage.CreateObject("GVGStore", "com_FormulaFreeExchangeInputItems");
	}

	public static UI_com_FormulaFreeExchangeInputItems CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_FormulaFreeExchangeInputItems).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://fvc33k3g7nbom", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Items = (GList)((GComponent)this).GetChild("Items");
	}
}
