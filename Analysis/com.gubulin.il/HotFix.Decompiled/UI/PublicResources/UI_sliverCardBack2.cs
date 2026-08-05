using FairyGUI;
using FairyGUI.Utils;

namespace UI.PublicResources;

public class UI_sliverCardBack2 : GButton
{
	public Controller button;

	public GImage n20;

	public const string URL = "ui://kt6rg65ovecst9d";

	public static string Name = "UI_sliverCardBack2";

	public static string GetURL()
	{
		return "ui://kt6rg65ovecst9d";
	}

	public static UI_sliverCardBack2 CreateInstance()
	{
		return (UI_sliverCardBack2)(object)UIPackage.CreateObject("PublicResources", "sliverCardBack2");
	}

	public static UI_sliverCardBack2 CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_sliverCardBack2).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://kt6rg65ovecst9d", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		n20 = (GImage)((GComponent)this).GetChild("n20");
	}
}
