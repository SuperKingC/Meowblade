using FairyGUI;
using FairyGUI.Utils;

namespace UI.LegendItemsDraw;

public class UI_LegendItemFront : GButton
{
	public Controller button;

	public UI_LegendItem Content;

	public const string URL = "ui://xogvri2hs2vzm";

	public static string Name = "UI_LegendItemFront";

	public static string GetURL()
	{
		return "ui://xogvri2hs2vzm";
	}

	public static UI_LegendItemFront CreateInstance()
	{
		return (UI_LegendItemFront)(object)UIPackage.CreateObject("LegendItemsDraw", "LegendItemFront");
	}

	public static UI_LegendItemFront CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_LegendItemFront).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://xogvri2hs2vzm", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		Content = (UI_LegendItem)(object)((GComponent)this).GetChild("Content");
	}
}
