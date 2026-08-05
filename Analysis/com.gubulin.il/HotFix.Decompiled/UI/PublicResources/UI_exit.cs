using FairyGUI;
using FairyGUI.Utils;

namespace UI.PublicResources;

public class UI_exit : GButton
{
	public Controller button;

	public GImage n7;

	public const string URL = "ui://kt6rg65ovl2e31";

	public static string Name = "UI_exit";

	public static string GetURL()
	{
		return "ui://kt6rg65ovl2e31";
	}

	public static UI_exit CreateInstance()
	{
		return (UI_exit)(object)UIPackage.CreateObject("PublicResources", "exit");
	}

	public static UI_exit CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_exit).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://kt6rg65ovl2e31", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		n7 = (GImage)((GComponent)this).GetChild("n7");
	}
}
