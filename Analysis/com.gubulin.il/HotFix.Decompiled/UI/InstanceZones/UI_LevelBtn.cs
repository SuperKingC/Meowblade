using FairyGUI;
using FairyGUI.Utils;

namespace UI.InstanceZones;

public class UI_LevelBtn : GButton
{
	public Controller button;

	public Controller SelecedtStatus;

	public Controller AvailableStatus;

	public Controller CombatStatus;

	public GLoader icon;

	public GLoader light;

	public GImage SandClock;

	public GTextField countDown;

	public GGraph bonusBack0;

	public GLoader bonusIcon0;

	public GTextField bonusNum0;

	public GGroup BonusDesc0;

	public GGraph bonusBack1;

	public GLoader bonusIcon1;

	public GTextField bonusNum1;

	public GGroup BonusDesc1;

	public GGraph bonusBack2;

	public GLoader bonusIcon2;

	public GTextField bonusNum2;

	public GGroup BonusDesc2;

	public GMovieClip startWar;

	public GGraph SfxBack1;

	public GGraph SfxBack2;

	public const string URL = "ui://f4wr270rdpf03s";

	public static string Name = "UI_LevelBtn";

	public static string GetURL()
	{
		return "ui://f4wr270rdpf03s";
	}

	public static UI_LevelBtn CreateInstance()
	{
		return (UI_LevelBtn)(object)UIPackage.CreateObject("InstanceZones", "LevelBtn");
	}

	public static UI_LevelBtn CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_LevelBtn).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://f4wr270rdpf03s", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0059: Unknown result type (might be due to invalid IL or missing references)
		//IL_0063: Expected O, but got Unknown
		//IL_006f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0079: Expected O, but got Unknown
		//IL_0085: Unknown result type (might be due to invalid IL or missing references)
		//IL_008f: Expected O, but got Unknown
		//IL_009b: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a5: Expected O, but got Unknown
		//IL_00b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bb: Expected O, but got Unknown
		//IL_00c7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d1: Expected O, but got Unknown
		//IL_00dd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e7: Expected O, but got Unknown
		//IL_00f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fd: Expected O, but got Unknown
		//IL_0109: Unknown result type (might be due to invalid IL or missing references)
		//IL_0113: Expected O, but got Unknown
		//IL_011f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0129: Expected O, but got Unknown
		//IL_0135: Unknown result type (might be due to invalid IL or missing references)
		//IL_013f: Expected O, but got Unknown
		//IL_014b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0155: Expected O, but got Unknown
		//IL_0161: Unknown result type (might be due to invalid IL or missing references)
		//IL_016b: Expected O, but got Unknown
		//IL_0177: Unknown result type (might be due to invalid IL or missing references)
		//IL_0181: Expected O, but got Unknown
		//IL_018d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0197: Expected O, but got Unknown
		//IL_01a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ad: Expected O, but got Unknown
		//IL_01b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c3: Expected O, but got Unknown
		//IL_01cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d9: Expected O, but got Unknown
		//IL_01e5: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ef: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		SelecedtStatus = ((GComponent)this).GetController("SelecedtStatus");
		AvailableStatus = ((GComponent)this).GetController("AvailableStatus");
		CombatStatus = ((GComponent)this).GetController("CombatStatus");
		icon = (GLoader)((GComponent)this).GetChild("icon");
		light = (GLoader)((GComponent)this).GetChild("light");
		SandClock = (GImage)((GComponent)this).GetChild("SandClock");
		countDown = (GTextField)((GComponent)this).GetChild("countDown");
		bonusBack0 = (GGraph)((GComponent)this).GetChild("bonusBack0");
		bonusIcon0 = (GLoader)((GComponent)this).GetChild("bonusIcon0");
		bonusNum0 = (GTextField)((GComponent)this).GetChild("bonusNum0");
		BonusDesc0 = (GGroup)((GComponent)this).GetChild("BonusDesc0");
		bonusBack1 = (GGraph)((GComponent)this).GetChild("bonusBack1");
		bonusIcon1 = (GLoader)((GComponent)this).GetChild("bonusIcon1");
		bonusNum1 = (GTextField)((GComponent)this).GetChild("bonusNum1");
		BonusDesc1 = (GGroup)((GComponent)this).GetChild("BonusDesc1");
		bonusBack2 = (GGraph)((GComponent)this).GetChild("bonusBack2");
		bonusIcon2 = (GLoader)((GComponent)this).GetChild("bonusIcon2");
		bonusNum2 = (GTextField)((GComponent)this).GetChild("bonusNum2");
		BonusDesc2 = (GGroup)((GComponent)this).GetChild("BonusDesc2");
		startWar = (GMovieClip)((GComponent)this).GetChild("startWar");
		SfxBack1 = (GGraph)((GComponent)this).GetChild("SfxBack1");
		SfxBack2 = (GGraph)((GComponent)this).GetChild("SfxBack2");
	}
}
