using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGBrawlFight;

public class UI_com_BrawlIslandIcon : GComponent
{
	public GGraph IslandIcon;

	public const string URL = "ui://hozu168r80d19s";

	public static string Name = "UI_com_BrawlIslandIcon";

	public static string GetURL()
	{
		return "ui://hozu168r80d19s";
	}

	public static UI_com_BrawlIslandIcon CreateInstance()
	{
		return (UI_com_BrawlIslandIcon)(object)UIPackage.CreateObject("GvGBrawlFight", "com_BrawlIslandIcon");
	}

	public static UI_com_BrawlIslandIcon CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_BrawlIslandIcon).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://hozu168r80d19s", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		IslandIcon = (GGraph)((GComponent)this).GetChild("IslandIcon");
	}
}
