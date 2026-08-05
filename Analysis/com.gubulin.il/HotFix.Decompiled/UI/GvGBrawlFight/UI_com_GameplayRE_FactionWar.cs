using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGBrawlFight;

public class UI_com_GameplayRE_FactionWar : GComponent
{
	public GImage n4;

	public const string URL = "ui://hozu168rniiv6c";

	public static string Name = "UI_com_GameplayRE_FactionWar";

	public static string GetURL()
	{
		return "ui://hozu168rniiv6c";
	}

	public static UI_com_GameplayRE_FactionWar CreateInstance()
	{
		return (UI_com_GameplayRE_FactionWar)(object)UIPackage.CreateObject("GvGBrawlFight", "com_GameplayRE_FactionWar");
	}

	public static UI_com_GameplayRE_FactionWar CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_GameplayRE_FactionWar).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://hozu168rniiv6c", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		n4 = (GImage)((GComponent)this).GetChild("n4");
	}
}
