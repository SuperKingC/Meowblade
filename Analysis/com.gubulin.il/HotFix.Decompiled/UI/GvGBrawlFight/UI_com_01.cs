using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGBrawlFight;

public class UI_com_01 : GComponent
{
	public GImage hasMyShipIcon;

	public GLoader Icon;

	public Transition t0;

	public const string URL = "ui://hozu168riwm75q";

	public static string Name = "UI_com_01";

	public static string GetURL()
	{
		return "ui://hozu168riwm75q";
	}

	public static UI_com_01 CreateInstance()
	{
		return (UI_com_01)(object)UIPackage.CreateObject("GvGBrawlFight", "com_01");
	}

	public static UI_com_01 CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_01).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://hozu168riwm75q", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		hasMyShipIcon = (GImage)((GComponent)this).GetChild("hasMyShipIcon");
		Icon = (GLoader)((GComponent)this).GetChild("Icon");
		t0 = ((GComponent)this).GetTransition("t0");
	}
}
