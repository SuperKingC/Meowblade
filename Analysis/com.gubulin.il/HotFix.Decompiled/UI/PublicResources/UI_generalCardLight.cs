using FairyGUI;
using FairyGUI.Utils;

namespace UI.PublicResources;

public class UI_generalCardLight : GButton
{
	public Controller button;

	public GImage n11;

	public const string URL = "ui://kt6rg65ovv0uf1";

	public static string Name = "UI_generalCardLight";

	public static string GetURL()
	{
		return "ui://kt6rg65ovv0uf1";
	}

	public static UI_generalCardLight CreateInstance()
	{
		return (UI_generalCardLight)(object)UIPackage.CreateObject("PublicResources", "generalCardLight");
	}

	public static UI_generalCardLight CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_generalCardLight).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://kt6rg65ovv0uf1", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
