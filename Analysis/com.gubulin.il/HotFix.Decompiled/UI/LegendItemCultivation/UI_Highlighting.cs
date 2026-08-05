using FairyGUI;
using FairyGUI.Utils;

namespace UI.LegendItemCultivation;

public class UI_Highlighting : GComponent
{
	public GImage n4;

	public const string URL = "ui://b9wlonaqmpf914";

	public static string Name = "UI_Highlighting";

	public static string GetURL()
	{
		return "ui://b9wlonaqmpf914";
	}

	public static UI_Highlighting CreateInstance()
	{
		return (UI_Highlighting)(object)UIPackage.CreateObject("LegendItemCultivation", "Highlighting");
	}

	public static UI_Highlighting CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_Highlighting).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://b9wlonaqmpf914", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		n4 = (GImage)((GComponent)this).GetChild("n4");
	}
}
