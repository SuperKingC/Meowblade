using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGBrawlFight;

public class UI_com_dragShipIcon : GComponent
{
	public GLoader ship;

	public const string URL = "ui://hozu168rvb402e";

	public static string Name = "UI_com_dragShipIcon";

	public static string GetURL()
	{
		return "ui://hozu168rvb402e";
	}

	public static UI_com_dragShipIcon CreateInstance()
	{
		return (UI_com_dragShipIcon)(object)UIPackage.CreateObject("GvGBrawlFight", "com_dragShipIcon");
	}

	public static UI_com_dragShipIcon CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_dragShipIcon).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://hozu168rvb402e", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		ship = (GLoader)((GComponent)this).GetChild("ship");
	}
}
