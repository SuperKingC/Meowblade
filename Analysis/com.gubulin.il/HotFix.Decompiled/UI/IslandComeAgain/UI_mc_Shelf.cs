using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.IslandComeAgain;

public class UI_mc_Shelf : GComponent
{
	public Controller Type;

	public Controller State;

	public GImage n15;

	public UI_mc_LuckSlotsLock LockPrizePool;

	public GList UnlockPrizePool;

	public GImage n32;

	public GTextField CountDown;

	public GGroup n34;

	public UI_mc_Cloth01 Cloth01;

	public GImage n36;

	public GImage n37;

	public GImage n38;

	public GImage n39;

	public GImage n40;

	public GGroup Cloth02;

	public UI_mc_Cloth03 Cloth03;

	public GImage n42;

	public GImage n43;

	public GImage n44;

	public GImage n45;

	public GImage n46;

	public GGroup n47;

	public GImage n22;

	public GImage n23;

	public GImage n24;

	public GImage n25;

	public GImage n26;

	public GImage n20;

	public GImage n21;

	public GTextField n31;

	public GImage n56;

	public GImage n57;

	public GLoader CurrencyIcon;

	public GTextField Currency;

	public GTextField n52;

	public Transition t0;

	public const string URL = "ui://k2sprg26laau4k";

	public static string Name = "UI_mc_Shelf";

	public static string GetURL()
	{
		return "ui://k2sprg26laau4k";
	}

	public static UI_mc_Shelf CreateInstance()
	{
		return (UI_mc_Shelf)(object)UIPackage.CreateObject("IslandComeAgain", "mc_Shelf");
	}

	public static UI_mc_Shelf CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_mc_Shelf).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://k2sprg26laau4k", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Expected O, but got Unknown
		//IL_0063: Unknown result type (might be due to invalid IL or missing references)
		//IL_006d: Expected O, but got Unknown
		//IL_0079: Unknown result type (might be due to invalid IL or missing references)
		//IL_0083: Expected O, but got Unknown
		//IL_008f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0099: Expected O, but got Unknown
		//IL_00a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00af: Expected O, but got Unknown
		//IL_00d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00db: Expected O, but got Unknown
		//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f1: Expected O, but got Unknown
		//IL_00fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0107: Expected O, but got Unknown
		//IL_0113: Unknown result type (might be due to invalid IL or missing references)
		//IL_011d: Expected O, but got Unknown
		//IL_0129: Unknown result type (might be due to invalid IL or missing references)
		//IL_0133: Expected O, but got Unknown
		//IL_013f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0149: Expected O, but got Unknown
		//IL_016b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0175: Expected O, but got Unknown
		//IL_0181: Unknown result type (might be due to invalid IL or missing references)
		//IL_018b: Expected O, but got Unknown
		//IL_0197: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a1: Expected O, but got Unknown
		//IL_01ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b7: Expected O, but got Unknown
		//IL_01c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_01cd: Expected O, but got Unknown
		//IL_01d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e3: Expected O, but got Unknown
		//IL_01ef: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f9: Expected O, but got Unknown
		//IL_0205: Unknown result type (might be due to invalid IL or missing references)
		//IL_020f: Expected O, but got Unknown
		//IL_021b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0225: Expected O, but got Unknown
		//IL_0231: Unknown result type (might be due to invalid IL or missing references)
		//IL_023b: Expected O, but got Unknown
		//IL_0247: Unknown result type (might be due to invalid IL or missing references)
		//IL_0251: Expected O, but got Unknown
		//IL_025d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0267: Expected O, but got Unknown
		//IL_0273: Unknown result type (might be due to invalid IL or missing references)
		//IL_027d: Expected O, but got Unknown
		//IL_0289: Unknown result type (might be due to invalid IL or missing references)
		//IL_0293: Expected O, but got Unknown
		//IL_02dc: Unknown result type (might be due to invalid IL or missing references)
		//IL_02e6: Expected O, but got Unknown
		//IL_02f2: Unknown result type (might be due to invalid IL or missing references)
		//IL_02fc: Expected O, but got Unknown
		//IL_0308: Unknown result type (might be due to invalid IL or missing references)
		//IL_0312: Expected O, but got Unknown
		//IL_031e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0328: Expected O, but got Unknown
		//IL_0334: Unknown result type (might be due to invalid IL or missing references)
		//IL_033e: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Type = ((GComponent)this).GetController("Type");
		State = ((GComponent)this).GetController("State");
		n15 = (GImage)((GComponent)this).GetChild("n15");
		LockPrizePool = (UI_mc_LuckSlotsLock)(object)((GComponent)this).GetChild("LockPrizePool");
		UnlockPrizePool = (GList)((GComponent)this).GetChild("UnlockPrizePool");
		n32 = (GImage)((GComponent)this).GetChild("n32");
		CountDown = (GTextField)((GComponent)this).GetChild("CountDown");
		n34 = (GGroup)((GComponent)this).GetChild("n34");
		Cloth01 = (UI_mc_Cloth01)(object)((GComponent)this).GetChild("Cloth01");
		n36 = (GImage)((GComponent)this).GetChild("n36");
		n37 = (GImage)((GComponent)this).GetChild("n37");
		n38 = (GImage)((GComponent)this).GetChild("n38");
		n39 = (GImage)((GComponent)this).GetChild("n39");
		n40 = (GImage)((GComponent)this).GetChild("n40");
		Cloth02 = (GGroup)((GComponent)this).GetChild("Cloth02");
		Cloth03 = (UI_mc_Cloth03)(object)((GComponent)this).GetChild("Cloth03");
		n42 = (GImage)((GComponent)this).GetChild("n42");
		n43 = (GImage)((GComponent)this).GetChild("n43");
		n44 = (GImage)((GComponent)this).GetChild("n44");
		n45 = (GImage)((GComponent)this).GetChild("n45");
		n46 = (GImage)((GComponent)this).GetChild("n46");
		n47 = (GGroup)((GComponent)this).GetChild("n47");
		n22 = (GImage)((GComponent)this).GetChild("n22");
		n23 = (GImage)((GComponent)this).GetChild("n23");
		n24 = (GImage)((GComponent)this).GetChild("n24");
		n25 = (GImage)((GComponent)this).GetChild("n25");
		n26 = (GImage)((GComponent)this).GetChild("n26");
		n20 = (GImage)((GComponent)this).GetChild("n20");
		n21 = (GImage)((GComponent)this).GetChild("n21");
		n31 = (GTextField)((GComponent)this).GetChild("n31");
		string id = "ui://k2sprg26laau4k".Replace("ui://", "") + "-" + ((GObject)n31).id;
		((GObject)n31).text = LanguagesManager.GetDesc(id);
		n56 = (GImage)((GComponent)this).GetChild("n56");
		n57 = (GImage)((GComponent)this).GetChild("n57");
		CurrencyIcon = (GLoader)((GComponent)this).GetChild("CurrencyIcon");
		Currency = (GTextField)((GComponent)this).GetChild("Currency");
		n52 = (GTextField)((GComponent)this).GetChild("n52");
		string id2 = "ui://k2sprg26laau4k".Replace("ui://", "") + "-" + ((GObject)n52).id;
		((GObject)n52).text = LanguagesManager.GetDesc(id2);
		t0 = ((GComponent)this).GetTransition("t0");
	}
}
