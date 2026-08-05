using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGOnIsland3;

public class UI_com_BossHealthBarBig : GComponent
{
	public GImage n7;

	public GImage n6;

	public GTextField BossName;

	public UI_com_BossHealthProgessBar HealthBar;

	public GTextField HpText;

	public UI_com_ShadowMaster BossIcon;

	public const string URL = "ui://ebc4ciwrl44l1k";

	public static string Name = "UI_com_BossHealthBarBig";

	public static string GetURL()
	{
		return "ui://ebc4ciwrl44l1k";
	}

	public static UI_com_BossHealthBarBig CreateInstance()
	{
		return (UI_com_BossHealthBarBig)(object)UIPackage.CreateObject("GvGOnIsland3", "com_BossHealthBarBig");
	}

	public static UI_com_BossHealthBarBig CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_BossHealthBarBig).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://ebc4ciwrl44l1k", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_006d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0077: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		n7 = (GImage)((GComponent)this).GetChild("n7");
		n6 = (GImage)((GComponent)this).GetChild("n6");
		BossName = (GTextField)((GComponent)this).GetChild("BossName");
		HealthBar = (UI_com_BossHealthProgessBar)(object)((GComponent)this).GetChild("HealthBar");
		HpText = (GTextField)((GComponent)this).GetChild("HpText");
		BossIcon = (UI_com_ShadowMaster)(object)((GComponent)this).GetChild("BossIcon");
	}
}
