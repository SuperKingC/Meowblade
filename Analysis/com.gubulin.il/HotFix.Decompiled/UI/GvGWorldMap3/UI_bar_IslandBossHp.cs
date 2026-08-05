using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGWorldMap3;

public class UI_bar_IslandBossHp : GProgressBar
{
	public GImage n2;

	public GImage bar;

	public GTextField title;

	public const string URL = "ui://4eq8fgd2h5gss92";

	public static string Name = "UI_bar_IslandBossHp";

	public static string GetURL()
	{
		return "ui://4eq8fgd2h5gss92";
	}

	public static UI_bar_IslandBossHp CreateInstance()
	{
		return (UI_bar_IslandBossHp)(object)UIPackage.CreateObject("GvGWorldMap3", "bar_IslandBossHp");
	}

	public static UI_bar_IslandBossHp CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_bar_IslandBossHp).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://4eq8fgd2h5gss92", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		n2 = (GImage)((GComponent)this).GetChild("n2");
		bar = (GImage)((GComponent)this).GetChild("bar");
		title = (GTextField)((GComponent)this).GetChild("title");
	}
}
