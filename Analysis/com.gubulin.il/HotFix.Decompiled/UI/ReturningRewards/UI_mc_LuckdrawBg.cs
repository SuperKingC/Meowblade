using FairyGUI;
using FairyGUI.Utils;

namespace UI.ReturningRewards;

public class UI_mc_LuckdrawBg : GComponent
{
	public GImage n31;

	public const string URL = "ui://rx5ntv98kaq510";

	public static string Name = "UI_mc_LuckdrawBg";

	public static string GetURL()
	{
		return "ui://rx5ntv98kaq510";
	}

	public static UI_mc_LuckdrawBg CreateInstance()
	{
		return (UI_mc_LuckdrawBg)(object)UIPackage.CreateObject("ReturningRewards", "mc_LuckdrawBg");
	}

	public static UI_mc_LuckdrawBg CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_mc_LuckdrawBg).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://rx5ntv98kaq510", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		n31 = (GImage)((GComponent)this).GetChild("n31");
	}
}
