using FairyGUI;
using FairyGUI.Utils;

namespace UI.PublicResources;

public class UI_specialCardLight : GButton
{
	public Controller button;

	public GImage n11;

	public const string URL = "ui://kt6rg65ovv0uf4";

	public static string Name = "UI_specialCardLight";

	public static string GetURL()
	{
		return "ui://kt6rg65ovv0uf4";
	}

	public static UI_specialCardLight CreateInstance()
	{
		return (UI_specialCardLight)(object)UIPackage.CreateObject("PublicResources", "specialCardLight");
	}

	public static UI_specialCardLight CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_specialCardLight).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://kt6rg65ovv0uf4", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		n11 = (GImage)((GComponent)this).GetChild("n11");
	}
}
