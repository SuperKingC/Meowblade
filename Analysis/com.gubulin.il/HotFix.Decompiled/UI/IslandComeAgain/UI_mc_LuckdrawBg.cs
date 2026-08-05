using FairyGUI;
using FairyGUI.Utils;

namespace UI.IslandComeAgain;

public class UI_mc_LuckdrawBg : GComponent
{
	public GImage n31;

	public const string URL = "ui://k2sprg26laau4u";

	public static string Name = "UI_mc_LuckdrawBg";

	public static string GetURL()
	{
		return "ui://k2sprg26laau4u";
	}

	public static UI_mc_LuckdrawBg CreateInstance()
	{
		return (UI_mc_LuckdrawBg)(object)UIPackage.CreateObject("IslandComeAgain", "mc_LuckdrawBg");
	}

	public static UI_mc_LuckdrawBg CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_mc_LuckdrawBg).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://k2sprg26laau4u", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
