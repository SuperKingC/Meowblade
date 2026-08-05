using FairyGUI;
using FairyGUI.Utils;

namespace UI.UpgradePotential;

public class UI_PageTitle : GComponent
{
	public Controller PageSwitch;

	public GImage Victory;

	public GLoader icon;

	public const string URL = "ui://l5ik1uclpanqtb1";

	public static string Name = "UI_PageTitle";

	public static string GetURL()
	{
		return "ui://l5ik1uclpanqtb1";
	}

	public static UI_PageTitle CreateInstance()
	{
		return (UI_PageTitle)(object)UIPackage.CreateObject("UpgradePotential", "PageTitle");
	}

	public static UI_PageTitle CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_PageTitle).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://l5ik1uclpanqtb1", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		PageSwitch = ((GComponent)this).GetController("PageSwitch");
		Victory = (GImage)((GComponent)this).GetChild("Victory");
		icon = (GLoader)((GComponent)this).GetChild("icon");
	}
}
