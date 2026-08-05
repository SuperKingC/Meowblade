using FairyGUI;
using FairyGUI.Utils;

namespace UI.LegendItemsDraw;

public class UI_battery : GComponent
{
	public GImage n25;

	public const string URL = "ui://xogvri2hs2vzc";

	public static string Name = "UI_battery";

	public static string GetURL()
	{
		return "ui://xogvri2hs2vzc";
	}

	public static UI_battery CreateInstance()
	{
		return (UI_battery)(object)UIPackage.CreateObject("LegendItemsDraw", "battery");
	}

	public static UI_battery CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_battery).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://xogvri2hs2vzc", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		n25 = (GImage)((GComponent)this).GetChild("n25");
	}
}
