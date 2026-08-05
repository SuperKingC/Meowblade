using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGBrawlFight;

public class UI_com_IslandShip : GComponent
{
	public GImage n15;

	public GLoader icon;

	public Transition t0;

	public const string URL = "ui://hozu168r9ykh6n";

	public static string Name = "UI_com_IslandShip";

	public static string GetURL()
	{
		return "ui://hozu168r9ykh6n";
	}

	public static UI_com_IslandShip CreateInstance()
	{
		return (UI_com_IslandShip)(object)UIPackage.CreateObject("GvGBrawlFight", "com_IslandShip");
	}

	public static UI_com_IslandShip CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_IslandShip).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://hozu168r9ykh6n", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		n15 = (GImage)((GComponent)this).GetChild("n15");
		icon = (GLoader)((GComponent)this).GetChild("icon");
		t0 = ((GComponent)this).GetTransition("t0");
	}
}
