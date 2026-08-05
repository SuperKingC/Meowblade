using FairyGUI;
using FairyGUI.Utils;

namespace UI.IslandComeAgain;

public class UI_mc_LuckdrawBackLock : GComponent
{
	public GImage n28;

	public GImage n30;

	public GImage n31;

	public const string URL = "ui://k2sprg26laau4n";

	public static string Name = "UI_mc_LuckdrawBackLock";

	public static string GetURL()
	{
		return "ui://k2sprg26laau4n";
	}

	public static UI_mc_LuckdrawBackLock CreateInstance()
	{
		return (UI_mc_LuckdrawBackLock)(object)UIPackage.CreateObject("IslandComeAgain", "mc_LuckdrawBackLock");
	}

	public static UI_mc_LuckdrawBackLock CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_mc_LuckdrawBackLock).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://k2sprg26laau4n", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		n28 = (GImage)((GComponent)this).GetChild("n28");
		n30 = (GImage)((GComponent)this).GetChild("n30");
		n31 = (GImage)((GComponent)this).GetChild("n31");
	}
}
