using FairyGUI;
using FairyGUI.Utils;

namespace UI.PublicResources;

public class UI_sliverCardLight : GButton
{
	public Controller button;

	public GImage n15;

	public const string URL = "ui://kt6rg65ovecst9e";

	public static string Name = "UI_sliverCardLight";

	public static string GetURL()
	{
		return "ui://kt6rg65ovecst9e";
	}

	public static UI_sliverCardLight CreateInstance()
	{
		return (UI_sliverCardLight)(object)UIPackage.CreateObject("PublicResources", "sliverCardLight");
	}

	public static UI_sliverCardLight CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_sliverCardLight).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://kt6rg65ovecst9e", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		n15 = (GImage)((GComponent)this).GetChild("n15");
	}
}
