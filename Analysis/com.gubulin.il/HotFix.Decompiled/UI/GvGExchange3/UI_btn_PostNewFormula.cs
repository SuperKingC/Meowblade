using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGExchange3;

public class UI_btn_PostNewFormula : GButton
{
	public Controller button;

	public GGraph n5;

	public GImage n3;

	public const string URL = "ui://tt2iq07oj1h82z";

	public static string Name = "UI_btn_PostNewFormula";

	public static string GetURL()
	{
		return "ui://tt2iq07oj1h82z";
	}

	public static UI_btn_PostNewFormula CreateInstance()
	{
		return (UI_btn_PostNewFormula)(object)UIPackage.CreateObject("GvGExchange3", "btn_PostNewFormula");
	}

	public static UI_btn_PostNewFormula CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_btn_PostNewFormula).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://tt2iq07oj1h82z", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		n5 = (GGraph)((GComponent)this).GetChild("n5");
		n3 = (GImage)((GComponent)this).GetChild("n3");
	}
}
