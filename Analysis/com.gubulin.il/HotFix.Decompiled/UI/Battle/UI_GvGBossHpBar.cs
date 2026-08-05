using FairyGUI;
using FairyGUI.Utils;

namespace UI.Battle;

public class UI_GvGBossHpBar : GComponent
{
	public GImage n1;

	public UI_GvGBattleRecordBossHpBar BossHpBar;

	public GImage n11;

	public GImage n2;

	public UI_GvGBossIcon BossIcon;

	public GTextField BossName;

	public GTextField HpBarCount;

	public GList BossAbilitties;

	public GTextField BossLevel;

	public const string URL = "ui://twlbabiccvfml5";

	public static string Name = "UI_GvGBossHpBar";

	public static string GetURL()
	{
		return "ui://twlbabiccvfml5";
	}

	public static UI_GvGBossHpBar CreateInstance()
	{
		return (UI_GvGBossHpBar)(object)UIPackage.CreateObject("Battle", "GvGBossHpBar");
	}

	public static UI_GvGBossHpBar CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_GvGBossHpBar).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://twlbabiccvfml5", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Expected O, but got Unknown
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		//IL_0061: Expected O, but got Unknown
		//IL_0083: Unknown result type (might be due to invalid IL or missing references)
		//IL_008d: Expected O, but got Unknown
		//IL_0099: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a3: Expected O, but got Unknown
		//IL_00af: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b9: Expected O, but got Unknown
		//IL_00c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cf: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		n1 = (GImage)((GComponent)this).GetChild("n1");
		BossHpBar = (UI_GvGBattleRecordBossHpBar)(object)((GComponent)this).GetChild("BossHpBar");
		n11 = (GImage)((GComponent)this).GetChild("n11");
		n2 = (GImage)((GComponent)this).GetChild("n2");
		BossIcon = (UI_GvGBossIcon)(object)((GComponent)this).GetChild("BossIcon");
		BossName = (GTextField)((GComponent)this).GetChild("BossName");
		HpBarCount = (GTextField)((GComponent)this).GetChild("HpBarCount");
		BossAbilitties = (GList)((GComponent)this).GetChild("BossAbilitties");
		BossLevel = (GTextField)((GComponent)this).GetChild("BossLevel");
	}
}
