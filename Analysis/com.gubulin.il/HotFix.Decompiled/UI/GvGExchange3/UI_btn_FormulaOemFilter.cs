using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGExchange3;

public class UI_btn_FormulaOemFilter : GButton
{
	public Controller button;

	public GImage n3;

	public const string URL = "ui://tt2iq07osmtg2u";

	public static string Name = "UI_btn_FormulaOemFilter";

	public static string GetURL()
	{
		return "ui://tt2iq07osmtg2u";
	}

	public static UI_btn_FormulaOemFilter CreateInstance()
	{
		return (UI_btn_FormulaOemFilter)(object)UIPackage.CreateObject("GvGExchange3", "btn_FormulaOemFilter");
	}

	public static UI_btn_FormulaOemFilter CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_btn_FormulaOemFilter).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://tt2iq07osmtg2u", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		n3 = (GImage)((GComponent)this).GetChild("n3");
	}
}
