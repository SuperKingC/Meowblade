using FairyGUI;
using FairyGUI.Utils;

namespace UI.LegendItemCultivation;

public class UI_LegendItemC : GButton
{
	public Controller button;

	public Controller LoackType;

	public UI_Highlighting Highlighting;

	public GButton Content;

	public GImage Lock;

	public GImage SelectNote;

	public const string URL = "ui://b9wlonaqlud8p";

	public static string Name = "UI_LegendItemC";

	public static string GetURL()
	{
		return "ui://b9wlonaqlud8p";
	}

	public static UI_LegendItemC CreateInstance()
	{
		return (UI_LegendItemC)(object)UIPackage.CreateObject("LegendItemCultivation", "LegendItemC");
	}

	public static UI_LegendItemC CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_LegendItemC).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://b9wlonaqlud8p", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Expected O, but got Unknown
		//IL_0063: Unknown result type (might be due to invalid IL or missing references)
		//IL_006d: Expected O, but got Unknown
		//IL_0079: Unknown result type (might be due to invalid IL or missing references)
		//IL_0083: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		LoackType = ((GComponent)this).GetController("LoackType");
		Highlighting = (UI_Highlighting)(object)((GComponent)this).GetChild("Highlighting");
		Content = (GButton)((GComponent)this).GetChild("Content");
		Lock = (GImage)((GComponent)this).GetChild("Lock");
		SelectNote = (GImage)((GComponent)this).GetChild("SelectNote");
	}
}
