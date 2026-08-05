using FairyGUI;
using FairyGUI.Utils;

namespace UI.LegendItemCultivation;

public class UI_LegendItemFilter : GButton
{
	public Controller button;

	public GImage bg;

	public GImage n4;

	public GTextField Title;

	public const string URL = "ui://b9wlonaqmpf91a";

	public static string Name = "UI_LegendItemFilter";

	public static string GetURL()
	{
		return "ui://b9wlonaqmpf91a";
	}

	public static UI_LegendItemFilter CreateInstance()
	{
		return (UI_LegendItemFilter)(object)UIPackage.CreateObject("LegendItemCultivation", "LegendItemFilter");
	}

	public static UI_LegendItemFilter CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_LegendItemFilter).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://b9wlonaqmpf91a", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Expected O, but got Unknown
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		//IL_005c: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		bg = (GImage)((GComponent)this).GetChild("bg");
		n4 = (GImage)((GComponent)this).GetChild("n4");
		Title = (GTextField)((GComponent)this).GetChild("Title");
	}
}
