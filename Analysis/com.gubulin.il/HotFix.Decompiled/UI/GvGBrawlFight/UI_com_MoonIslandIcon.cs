using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGBrawlFight;

public class UI_com_MoonIslandIcon : GComponent
{
	public GImage n2;

	public const string URL = "ui://hozu168rhd0n9h";

	public static string Name = "UI_com_MoonIslandIcon";

	public static string GetURL()
	{
		return "ui://hozu168rhd0n9h";
	}

	public static UI_com_MoonIslandIcon CreateInstance()
	{
		return (UI_com_MoonIslandIcon)(object)UIPackage.CreateObject("GvGBrawlFight", "com_MoonIslandIcon");
	}

	public static UI_com_MoonIslandIcon CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_MoonIslandIcon).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://hozu168rhd0n9h", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		n2 = (GImage)((GComponent)this).GetChild("n2");
	}
}
