using FairyGUI;
using FairyGUI.Utils;

namespace UI.LegendItemCultivation;

public class UI_btn_AddLegendItem : GButton
{
	public GImage n0;

	public const string URL = "ui://b9wlonaqh4zmhn";

	public static string Name = "UI_btn_AddLegendItem";

	public static string GetURL()
	{
		return "ui://b9wlonaqh4zmhn";
	}

	public static UI_btn_AddLegendItem CreateInstance()
	{
		return (UI_btn_AddLegendItem)(object)UIPackage.CreateObject("LegendItemCultivation", "btn_AddLegendItem");
	}

	public static UI_btn_AddLegendItem CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_btn_AddLegendItem).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://b9wlonaqh4zmhn", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		n0 = (GImage)((GComponent)this).GetChild("n0");
	}
}
