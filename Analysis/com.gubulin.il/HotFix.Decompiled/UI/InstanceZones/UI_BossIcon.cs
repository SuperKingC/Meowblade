using FairyGUI;
using FairyGUI.Utils;

namespace UI.InstanceZones;

public class UI_BossIcon : GComponent
{
	public Controller StatusController;

	public GImage n5;

	public GLoader icon;

	public const string URL = "ui://f4wr270rdey17r";

	public static string Name = "UI_BossIcon";

	public static string GetURL()
	{
		return "ui://f4wr270rdey17r";
	}

	public static UI_BossIcon CreateInstance()
	{
		return (UI_BossIcon)(object)UIPackage.CreateObject("InstanceZones", "BossIcon");
	}

	public static UI_BossIcon CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_BossIcon).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://f4wr270rdey17r", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		StatusController = ((GComponent)this).GetController("StatusController");
		n5 = (GImage)((GComponent)this).GetChild("n5");
		icon = (GLoader)((GComponent)this).GetChild("icon");
	}
}
