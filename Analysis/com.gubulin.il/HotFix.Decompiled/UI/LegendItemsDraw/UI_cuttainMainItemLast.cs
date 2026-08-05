using FairyGUI;
using FairyGUI.Utils;

namespace UI.LegendItemsDraw;

public class UI_cuttainMainItemLast : GButton
{
	public Controller button;

	public GImage n4;

	public const string URL = "ui://xogvri2hs2vzb";

	public static string Name = "UI_cuttainMainItemLast";

	public static string GetURL()
	{
		return "ui://xogvri2hs2vzb";
	}

	public static UI_cuttainMainItemLast CreateInstance()
	{
		return (UI_cuttainMainItemLast)(object)UIPackage.CreateObject("LegendItemsDraw", "cuttainMainItemLast");
	}

	public static UI_cuttainMainItemLast CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_cuttainMainItemLast).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://xogvri2hs2vzb", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		n4 = (GImage)((GComponent)this).GetChild("n4");
	}
}
