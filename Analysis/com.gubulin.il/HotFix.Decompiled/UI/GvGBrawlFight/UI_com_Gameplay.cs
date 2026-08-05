using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGBrawlFight;

public class UI_com_Gameplay : GComponent
{
	public GLoader Loader;

	public const string URL = "ui://hozu168rniiv6a";

	public static string Name = "UI_com_Gameplay";

	public static string GetURL()
	{
		return "ui://hozu168rniiv6a";
	}

	public static UI_com_Gameplay CreateInstance()
	{
		return (UI_com_Gameplay)(object)UIPackage.CreateObject("GvGBrawlFight", "com_Gameplay");
	}

	public static UI_com_Gameplay CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_Gameplay).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://hozu168rniiv6a", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Loader = (GLoader)((GComponent)this).GetChild("Loader");
	}
}
