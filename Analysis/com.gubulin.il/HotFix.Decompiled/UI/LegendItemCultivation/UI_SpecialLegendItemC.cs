using FairyGUI;
using FairyGUI.Utils;

namespace UI.LegendItemCultivation;

public class UI_SpecialLegendItemC : GButton
{
	public Controller button;

	public Controller ShowType;

	public GButton Content;

	public GImage SelectNote;

	public const string URL = "ui://b9wlonaqfs401p";

	public static string Name = "UI_SpecialLegendItemC";

	public static string GetURL()
	{
		return "ui://b9wlonaqfs401p";
	}

	public static UI_SpecialLegendItemC CreateInstance()
	{
		return (UI_SpecialLegendItemC)(object)UIPackage.CreateObject("LegendItemCultivation", "SpecialLegendItemC");
	}

	public static UI_SpecialLegendItemC CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_SpecialLegendItemC).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://b9wlonaqfs401p", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Expected O, but got Unknown
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		ShowType = ((GComponent)this).GetController("ShowType");
		Content = (GButton)((GComponent)this).GetChild("Content");
		SelectNote = (GImage)((GComponent)this).GetChild("SelectNote");
	}
}
