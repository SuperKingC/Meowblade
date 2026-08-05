using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGExchange3;

public class UI_btn_OemFormula : GButton
{
	public Controller button;

	public Controller IsShowRace;

	public Controller Rarity;

	public Controller FormulaEnable;

	public GImage n116;

	public GImage n119;

	public GImage n120;

	public GImage n121;

	public GImage n122;

	public GImage n117;

	public GImage n128;

	public GImage n131;

	public GComponent AffectedSoldier;

	public GComponent RaceType;

	public GTextField FormulaName;

	public UI_com_Crit Crit;

	public GImage n129;

	public GTextField AvailableCount;

	public GGroup n130;

	public UI_com_Taitan Taitan;

	public UI_com_FormulaCountdown Countdown;

	public GTextField PlayerName;

	public GImage n126;

	public const string URL = "ui://tt2iq07ouhtx4o";

	public static string Name = "UI_btn_OemFormula";

	public static string GetURL()
	{
		return "ui://tt2iq07ouhtx4o";
	}

	public static UI_btn_OemFormula CreateInstance()
	{
		return (UI_btn_OemFormula)(object)UIPackage.CreateObject("GvGExchange3", "btn_OemFormula");
	}

	public static UI_btn_OemFormula CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_btn_OemFormula).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://tt2iq07ouhtx4o", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_0161: Unknown result type (might be due to invalid IL or missing references)
		//IL_016b: Expected O, but got Unknown
		//IL_0177: Unknown result type (might be due to invalid IL or missing references)
		//IL_0181: Expected O, but got Unknown
		//IL_018d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0197: Expected O, but got Unknown
		//IL_01cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d9: Expected O, but got Unknown
		//IL_01e5: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ef: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		IsShowRace = ((GComponent)this).GetController("IsShowRace");
		Rarity = ((GComponent)this).GetController("Rarity");
		FormulaEnable = ((GComponent)this).GetController("FormulaEnable");
		n116 = (GImage)((GComponent)this).GetChild("n116");
		n119 = (GImage)((GComponent)this).GetChild("n119");
		n120 = (GImage)((GComponent)this).GetChild("n120");
		n121 = (GImage)((GComponent)this).GetChild("n121");
		n122 = (GImage)((GComponent)this).GetChild("n122");
		n117 = (GImage)((GComponent)this).GetChild("n117");
		n128 = (GImage)((GComponent)this).GetChild("n128");
		n131 = (GImage)((GComponent)this).GetChild("n131");
		AffectedSoldier = (GComponent)((GComponent)this).GetChild("AffectedSoldier");
		RaceType = (GComponent)((GComponent)this).GetChild("RaceType");
		FormulaName = (GTextField)((GComponent)this).GetChild("FormulaName");
		Crit = (UI_com_Crit)(object)((GComponent)this).GetChild("Crit");
		n129 = (GImage)((GComponent)this).GetChild("n129");
		AvailableCount = (GTextField)((GComponent)this).GetChild("AvailableCount");
		n130 = (GGroup)((GComponent)this).GetChild("n130");
		Taitan = (UI_com_Taitan)(object)((GComponent)this).GetChild("Taitan");
		Countdown = (UI_com_FormulaCountdown)(object)((GComponent)this).GetChild("Countdown");
		PlayerName = (GTextField)((GComponent)this).GetChild("PlayerName");
		n126 = (GImage)((GComponent)this).GetChild("n126");
	}
}
