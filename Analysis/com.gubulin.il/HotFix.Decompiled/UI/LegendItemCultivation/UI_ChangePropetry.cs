using FairyGUI;
using FairyGUI.Utils;

namespace UI.LegendItemCultivation;

public class UI_ChangePropetry : GButton
{
	public Controller button;

	public GImage n7;

	public GGraph n9;

	public GImage n10;

	public const string URL = "ui://b9wlonaqmpf91i";

	public static string Name = "UI_ChangePropetry";

	public static string GetURL()
	{
		return "ui://b9wlonaqmpf91i";
	}

	public static UI_ChangePropetry CreateInstance()
	{
		return (UI_ChangePropetry)(object)UIPackage.CreateObject("LegendItemCultivation", "ChangePropetry");
	}

	public static UI_ChangePropetry CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_ChangePropetry).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://b9wlonaqmpf91i", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		n7 = (GImage)((GComponent)this).GetChild("n7");
		n9 = (GGraph)((GComponent)this).GetChild("n9");
		n10 = (GImage)((GComponent)this).GetChild("n10");
	}
}
