using FairyGUI;
using FairyGUI.Utils;

namespace UI.LegendItemCultivation;

public class UI_com_SwitchMainAttItem : GComponent
{
	public Controller Selected;

	public GImage frame;

	public GImage n9;

	public GImage checkMark;

	public GRichTextField primeAttribute;

	public const string URL = "ui://b9wlonaqcl004";

	public static string Name = "UI_com_SwitchMainAttItem";

	public static string GetURL()
	{
		return "ui://b9wlonaqcl004";
	}

	public static UI_com_SwitchMainAttItem CreateInstance()
	{
		return (UI_com_SwitchMainAttItem)(object)UIPackage.CreateObject("LegendItemCultivation", "com_SwitchMainAttItem");
	}

	public static UI_com_SwitchMainAttItem CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_SwitchMainAttItem).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://b9wlonaqcl004", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_0072: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Selected = ((GComponent)this).GetController("Selected");
		frame = (GImage)((GComponent)this).GetChild("frame");
		n9 = (GImage)((GComponent)this).GetChild("n9");
		checkMark = (GImage)((GComponent)this).GetChild("checkMark");
		primeAttribute = (GRichTextField)((GComponent)this).GetChild("primeAttribute");
	}
}
