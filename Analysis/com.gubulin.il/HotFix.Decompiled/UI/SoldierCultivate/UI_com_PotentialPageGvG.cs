using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.SoldierCultivate;

public class UI_com_PotentialPageGvG : GComponent
{
	public Controller LevelIconController;

	public GImage n33;

	public GTextField title;

	public GGraph n34;

	public GGraph n70;

	public GImage n67;

	public GImage n114;

	public GImage n113;

	public GGraph unlockContentBack0;

	public GGraph unlockContentBack1;

	public GTextField CurrentAttack;

	public GTextField CurrentDefense;

	public GTextField CurrentHealth;

	public GTextField NextAttack;

	public GTextField NextDefense;

	public GTextField NextHealth;

	public GImage n52;

	public GImage n53;

	public GImage n54;

	public GImage SoulStoneLineLight0;

	public GImage SoulStoneLineLight1;

	public GImage SoulStoneLineLight2;

	public GImage SoulStoneLineLight3;

	public GImage n75;

	public GLoader PromoteItem;

	public GGraph ui_myth_number_2;

	public GGraph ui_myth_logo_2;

	public GImage n40;

	public GImage n41;

	public GGraph ui_myth_logo_1;

	public GRichTextField MLevelText;

	public GGraph ui_myth_number_1;

	public GGraph ui_myth_number_change;

	public GGraph n72;

	public GImage tip1st;

	public GTextField n55;

	public GImage n60;

	public GImage n61;

	public GImage n62;

	public GImage n38;

	public GImage n108;

	public UI_com_MythLevelValueUpdate LevelValueUpdate;

	public GButton MythPromoteBtn;

	public GTextField n43;

	public GTextField CurrentLevel;

	public GImage n51;

	public GTextField NextLevel;

	public GGroup n47;

	public GImage n44;

	public GImage n56;

	public GImage n57;

	public GTextField CostStoneNum;

	public GButton CostStone;

	public GGroup n63;

	public GTextField n71;

	public UI_SoldierAttribute SoldierAttribute;

	public GButton OpenPromote;

	public GButton LPromoteBtn;

	public GImage n69;

	public GImage n74;

	public GButton SoulStone0;

	public GGraph SoulStoneSfxBack0;

	public GButton SoulStone1;

	public GGraph SoulStoneSfxBack1;

	public GButton SoulStone2;

	public GGraph SoulStoneSfxBack2;

	public GButton SoulStone3;

	public GGraph SoulStoneSfxBack3;

	public GGroup n89;

	public GComponent n88;

	public GTextField unlockTip2nd;

	public UI_UnlockSoldierBtn UnlockSoldierBtn;

	public GImage n92;

	public GImage n103;

	public GGraph specialitySfxBack;

	public GImage n97;

	public GGraph specialityBtn;

	public GGroup n99;

	public GGroup n100;

	public GGraph PotentialIconSfxBack;

	public GGraph PromoteItemSfxBack;

	public GGraph PotentialIcon;

	public GGraph ui_myth_to_myth0;

	public Transition t0;

	public Transition ToL;

	public Transition ToM;

	public Transition ToM0;

	public const string URL = "ui://7dantnbimymftcg";

	public static string Name = "UI_com_PotentialPageGvG";

	public static string GetURL()
	{
		return "ui://7dantnbimymftcg";
	}

	public static UI_com_PotentialPageGvG CreateInstance()
	{
		return (UI_com_PotentialPageGvG)(object)UIPackage.CreateObject("SoldierCultivate", "com_PotentialPageGvG");
	}

	public static UI_com_PotentialPageGvG CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_PotentialPageGvG).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://7dantnbimymftcg", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Expected O, but got Unknown
		//IL_008f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0099: Expected O, but got Unknown
		//IL_00a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00af: Expected O, but got Unknown
		//IL_00bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c5: Expected O, but got Unknown
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
		//IL_0155: Unknown result type (might be due to invalid IL or missing references)
		//IL_015f: Expected O, but got Unknown
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
		//IL_029f: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a9: Expected O, but got Unknown
		//IL_02b5: Unknown result type (might be due to invalid IL or missing references)
		//IL_02bf: Expected O, but got Unknown
		//IL_02cb: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d5: Expected O, but got Unknown
		//IL_02e1: Unknown result type (might be due to invalid IL or missing references)
		//IL_02eb: Expected O, but got Unknown
		//IL_02f7: Unknown result type (might be due to invalid IL or missing references)
		//IL_0301: Expected O, but got Unknown
		//IL_030d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0317: Expected O, but got Unknown
		//IL_0323: Unknown result type (might be due to invalid IL or missing references)
		//IL_032d: Expected O, but got Unknown
		//IL_0339: Unknown result type (might be due to invalid IL or missing references)
		//IL_0343: Expected O, but got Unknown
		//IL_034f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0359: Expected O, but got Unknown
		//IL_03a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_03ac: Expected O, but got Unknown
		//IL_03b8: Unknown result type (might be due to invalid IL or missing references)
		//IL_03c2: Expected O, but got Unknown
		//IL_03ce: Unknown result type (might be due to invalid IL or missing references)
		//IL_03d8: Expected O, but got Unknown
		//IL_03e4: Unknown result type (might be due to invalid IL or missing references)
		//IL_03ee: Expected O, but got Unknown
		//IL_03fa: Unknown result type (might be due to invalid IL or missing references)
		//IL_0404: Expected O, but got Unknown
		//IL_0426: Unknown result type (might be due to invalid IL or missing references)
		//IL_0430: Expected O, but got Unknown
		//IL_043c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0446: Expected O, but got Unknown
		//IL_048f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0499: Expected O, but got Unknown
		//IL_04a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_04af: Expected O, but got Unknown
		//IL_04bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_04c5: Expected O, but got Unknown
		//IL_04d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_04db: Expected O, but got Unknown
		//IL_04e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_04f1: Expected O, but got Unknown
		//IL_04fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0507: Expected O, but got Unknown
		//IL_0513: Unknown result type (might be due to invalid IL or missing references)
		//IL_051d: Expected O, but got Unknown
		//IL_0529: Unknown result type (might be due to invalid IL or missing references)
		//IL_0533: Expected O, but got Unknown
		//IL_053f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0549: Expected O, but got Unknown
		//IL_0555: Unknown result type (might be due to invalid IL or missing references)
		//IL_055f: Expected O, but got Unknown
		//IL_056b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0575: Expected O, but got Unknown
		//IL_05d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_05de: Expected O, but got Unknown
		//IL_05ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_05f4: Expected O, but got Unknown
		//IL_0600: Unknown result type (might be due to invalid IL or missing references)
		//IL_060a: Expected O, but got Unknown
		//IL_0616: Unknown result type (might be due to invalid IL or missing references)
		//IL_0620: Expected O, but got Unknown
		//IL_062c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0636: Expected O, but got Unknown
		//IL_0642: Unknown result type (might be due to invalid IL or missing references)
		//IL_064c: Expected O, but got Unknown
		//IL_0658: Unknown result type (might be due to invalid IL or missing references)
		//IL_0662: Expected O, but got Unknown
		//IL_066e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0678: Expected O, but got Unknown
		//IL_0684: Unknown result type (might be due to invalid IL or missing references)
		//IL_068e: Expected O, but got Unknown
		//IL_069a: Unknown result type (might be due to invalid IL or missing references)
		//IL_06a4: Expected O, but got Unknown
		//IL_06b0: Unknown result type (might be due to invalid IL or missing references)
		//IL_06ba: Expected O, but got Unknown
		//IL_06c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_06d0: Expected O, but got Unknown
		//IL_06dc: Unknown result type (might be due to invalid IL or missing references)
		//IL_06e6: Expected O, but got Unknown
		//IL_06f2: Unknown result type (might be due to invalid IL or missing references)
		//IL_06fc: Expected O, but got Unknown
		//IL_0708: Unknown result type (might be due to invalid IL or missing references)
		//IL_0712: Expected O, but got Unknown
		//IL_0773: Unknown result type (might be due to invalid IL or missing references)
		//IL_077d: Expected O, but got Unknown
		//IL_0789: Unknown result type (might be due to invalid IL or missing references)
		//IL_0793: Expected O, but got Unknown
		//IL_079f: Unknown result type (might be due to invalid IL or missing references)
		//IL_07a9: Expected O, but got Unknown
		//IL_07b5: Unknown result type (might be due to invalid IL or missing references)
		//IL_07bf: Expected O, but got Unknown
		//IL_07cb: Unknown result type (might be due to invalid IL or missing references)
		//IL_07d5: Expected O, but got Unknown
		//IL_07e1: Unknown result type (might be due to invalid IL or missing references)
		//IL_07eb: Expected O, but got Unknown
		//IL_07f7: Unknown result type (might be due to invalid IL or missing references)
		//IL_0801: Expected O, but got Unknown
		//IL_080d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0817: Expected O, but got Unknown
		//IL_0823: Unknown result type (might be due to invalid IL or missing references)
		//IL_082d: Expected O, but got Unknown
		//IL_0839: Unknown result type (might be due to invalid IL or missing references)
		//IL_0843: Expected O, but got Unknown
		//IL_084f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0859: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		LevelIconController = ((GComponent)this).GetController("LevelIconController");
		n33 = (GImage)((GComponent)this).GetChild("n33");
		title = (GTextField)((GComponent)this).GetChild("title");
		string id = "ui://7dantnbimymftcg".Replace("ui://", "") + "-" + ((GObject)title).id;
		((GObject)title).text = LanguagesManager.GetDesc(id);
		n34 = (GGraph)((GComponent)this).GetChild("n34");
		n70 = (GGraph)((GComponent)this).GetChild("n70");
		n67 = (GImage)((GComponent)this).GetChild("n67");
		n114 = (GImage)((GComponent)this).GetChild("n114");
		n113 = (GImage)((GComponent)this).GetChild("n113");
		unlockContentBack0 = (GGraph)((GComponent)this).GetChild("unlockContentBack0");
		unlockContentBack1 = (GGraph)((GComponent)this).GetChild("unlockContentBack1");
		CurrentAttack = (GTextField)((GComponent)this).GetChild("CurrentAttack");
		CurrentDefense = (GTextField)((GComponent)this).GetChild("CurrentDefense");
		CurrentHealth = (GTextField)((GComponent)this).GetChild("CurrentHealth");
		NextAttack = (GTextField)((GComponent)this).GetChild("NextAttack");
		NextDefense = (GTextField)((GComponent)this).GetChild("NextDefense");
		NextHealth = (GTextField)((GComponent)this).GetChild("NextHealth");
		n52 = (GImage)((GComponent)this).GetChild("n52");
		n53 = (GImage)((GComponent)this).GetChild("n53");
		n54 = (GImage)((GComponent)this).GetChild("n54");
		SoulStoneLineLight0 = (GImage)((GComponent)this).GetChild("SoulStoneLineLight0");
		SoulStoneLineLight1 = (GImage)((GComponent)this).GetChild("SoulStoneLineLight1");
		SoulStoneLineLight2 = (GImage)((GComponent)this).GetChild("SoulStoneLineLight2");
		SoulStoneLineLight3 = (GImage)((GComponent)this).GetChild("SoulStoneLineLight3");
		n75 = (GImage)((GComponent)this).GetChild("n75");
		PromoteItem = (GLoader)((GComponent)this).GetChild("PromoteItem");
		ui_myth_number_2 = (GGraph)((GComponent)this).GetChild("ui_myth_number_2");
		ui_myth_logo_2 = (GGraph)((GComponent)this).GetChild("ui_myth_logo_2");
		n40 = (GImage)((GComponent)this).GetChild("n40");
		n41 = (GImage)((GComponent)this).GetChild("n41");
		ui_myth_logo_1 = (GGraph)((GComponent)this).GetChild("ui_myth_logo_1");
		MLevelText = (GRichTextField)((GComponent)this).GetChild("MLevelText");
		ui_myth_number_1 = (GGraph)((GComponent)this).GetChild("ui_myth_number_1");
		ui_myth_number_change = (GGraph)((GComponent)this).GetChild("ui_myth_number_change");
		n72 = (GGraph)((GComponent)this).GetChild("n72");
		tip1st = (GImage)((GComponent)this).GetChild("tip1st");
		n55 = (GTextField)((GComponent)this).GetChild("n55");
		string id2 = "ui://7dantnbimymftcg".Replace("ui://", "") + "-" + ((GObject)n55).id;
		((GObject)n55).text = LanguagesManager.GetDesc(id2);
		n60 = (GImage)((GComponent)this).GetChild("n60");
		n61 = (GImage)((GComponent)this).GetChild("n61");
		n62 = (GImage)((GComponent)this).GetChild("n62");
		n38 = (GImage)((GComponent)this).GetChild("n38");
		n108 = (GImage)((GComponent)this).GetChild("n108");
		LevelValueUpdate = (UI_com_MythLevelValueUpdate)(object)((GComponent)this).GetChild("LevelValueUpdate");
		MythPromoteBtn = (GButton)((GComponent)this).GetChild("MythPromoteBtn");
		n43 = (GTextField)((GComponent)this).GetChild("n43");
		string id3 = "ui://7dantnbimymftcg".Replace("ui://", "") + "-" + ((GObject)n43).id;
		((GObject)n43).text = LanguagesManager.GetDesc(id3);
		CurrentLevel = (GTextField)((GComponent)this).GetChild("CurrentLevel");
		n51 = (GImage)((GComponent)this).GetChild("n51");
		NextLevel = (GTextField)((GComponent)this).GetChild("NextLevel");
		n47 = (GGroup)((GComponent)this).GetChild("n47");
		n44 = (GImage)((GComponent)this).GetChild("n44");
		n56 = (GImage)((GComponent)this).GetChild("n56");
		n57 = (GImage)((GComponent)this).GetChild("n57");
		CostStoneNum = (GTextField)((GComponent)this).GetChild("CostStoneNum");
		CostStone = (GButton)((GComponent)this).GetChild("CostStone");
		n63 = (GGroup)((GComponent)this).GetChild("n63");
		n71 = (GTextField)((GComponent)this).GetChild("n71");
		string id4 = "ui://7dantnbimymftcg".Replace("ui://", "") + "-" + ((GObject)n71).id;
		((GObject)n71).text = LanguagesManager.GetDesc(id4);
		SoldierAttribute = (UI_SoldierAttribute)(object)((GComponent)this).GetChild("SoldierAttribute");
		OpenPromote = (GButton)((GComponent)this).GetChild("OpenPromote");
		LPromoteBtn = (GButton)((GComponent)this).GetChild("LPromoteBtn");
		n69 = (GImage)((GComponent)this).GetChild("n69");
		n74 = (GImage)((GComponent)this).GetChild("n74");
		SoulStone0 = (GButton)((GComponent)this).GetChild("SoulStone0");
		SoulStoneSfxBack0 = (GGraph)((GComponent)this).GetChild("SoulStoneSfxBack0");
		SoulStone1 = (GButton)((GComponent)this).GetChild("SoulStone1");
		SoulStoneSfxBack1 = (GGraph)((GComponent)this).GetChild("SoulStoneSfxBack1");
		SoulStone2 = (GButton)((GComponent)this).GetChild("SoulStone2");
		SoulStoneSfxBack2 = (GGraph)((GComponent)this).GetChild("SoulStoneSfxBack2");
		SoulStone3 = (GButton)((GComponent)this).GetChild("SoulStone3");
		SoulStoneSfxBack3 = (GGraph)((GComponent)this).GetChild("SoulStoneSfxBack3");
		n89 = (GGroup)((GComponent)this).GetChild("n89");
		n88 = (GComponent)((GComponent)this).GetChild("n88");
		unlockTip2nd = (GTextField)((GComponent)this).GetChild("unlockTip2nd");
		string id5 = "ui://7dantnbimymftcg".Replace("ui://", "") + "-" + ((GObject)unlockTip2nd).id;
		((GObject)unlockTip2nd).text = LanguagesManager.GetDesc(id5);
		UnlockSoldierBtn = (UI_UnlockSoldierBtn)(object)((GComponent)this).GetChild("UnlockSoldierBtn");
		n92 = (GImage)((GComponent)this).GetChild("n92");
		n103 = (GImage)((GComponent)this).GetChild("n103");
		specialitySfxBack = (GGraph)((GComponent)this).GetChild("specialitySfxBack");
		n97 = (GImage)((GComponent)this).GetChild("n97");
		specialityBtn = (GGraph)((GComponent)this).GetChild("specialityBtn");
		n99 = (GGroup)((GComponent)this).GetChild("n99");
		n100 = (GGroup)((GComponent)this).GetChild("n100");
		PotentialIconSfxBack = (GGraph)((GComponent)this).GetChild("PotentialIconSfxBack");
		PromoteItemSfxBack = (GGraph)((GComponent)this).GetChild("PromoteItemSfxBack");
		PotentialIcon = (GGraph)((GComponent)this).GetChild("PotentialIcon");
		ui_myth_to_myth0 = (GGraph)((GComponent)this).GetChild("ui_myth_to_myth0");
		t0 = ((GComponent)this).GetTransition("t0");
		ToL = ((GComponent)this).GetTransition("ToL");
		ToM = ((GComponent)this).GetTransition("ToM");
		ToM0 = ((GComponent)this).GetTransition("ToM0");
	}
}
