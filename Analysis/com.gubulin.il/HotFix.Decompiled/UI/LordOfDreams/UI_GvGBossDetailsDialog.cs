using FairyGUI;
using FairyGUI.Utils;

namespace UI.LordOfDreams;

public class UI_GvGBossDetailsDialog : GComponent
{
	public GImage Back;

	public GImage n71;

	public GTextField KillBossTimes;

	public GTextField WBScoreMultiplier;

	public const string URL = "ui://0i520nzm9h45oce";

	public static string Name = "UI_GvGBossDetailsDialog";

	public static string GetURL()
	{
		return "ui://0i520nzm9h45oce";
	}

	public static UI_GvGBossDetailsDialog CreateInstance()
	{
		return (UI_GvGBossDetailsDialog)(object)UIPackage.CreateObject("LordOfDreams", "GvGBossDetailsDialog");
	}

	public static UI_GvGBossDetailsDialog CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_GvGBossDetailsDialog).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://0i520nzm9h45oce", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		//IL_0061: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Back = (GImage)((GComponent)this).GetChild("Back");
		n71 = (GImage)((GComponent)this).GetChild("n71");
		KillBossTimes = (GTextField)((GComponent)this).GetChild("KillBossTimes");
		WBScoreMultiplier = (GTextField)((GComponent)this).GetChild("WBScoreMultiplier");
	}
}
