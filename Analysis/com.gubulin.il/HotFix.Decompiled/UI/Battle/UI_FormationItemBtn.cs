using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.Battle;

public class UI_FormationItemBtn : GButton
{
	public Controller button;

	public Controller LevelTypeController;

	public Controller Status;

	public Controller Assistance;

	public Controller PotentialLevel;

	public GGraph n25;

	public GGraph back;

	public GLoader IconLoader;

	public GTextField SoldierName;

	public GImage UnlockBack;

	public GTextField UnlcokTip;

	public GImage soldierIconBack;

	public GLoader iconFrame;

	public GLoader icon;

	public GComponent SoulStoneLevel;

	public GGroup soldierIcon;

	public GImage n18;

	public GTextField SoldierDesc;

	public GImage n30;

	public GImage n26;

	public GImage mercenaryLogo;

	public GImage n27;

	public GImage n29;

	public GGroup n37;

	public GImage n31;

	public GImage n38;

	public GImage n40;

	public GGroup n28;

	public GImage n41;

	public GImage n42;

	public GImage n46;

	public GGroup n45;

	public GImage n47;

	public GImage n48;

	public GImage n49;

	public GGroup n50;

	public GImage n51;

	public GImage n52;

	public GImage n53;

	public GGroup n54;

	public GImage n55;

	public GImage n56;

	public GImage n57;

	public GGroup n58;

	public GImage n59;

	public GImage n60;

	public GImage n61;

	public GGroup n62;

	public GImage n63;

	public GImage n64;

	public GImage n65;

	public GGroup n66;

	public GGroup n79;

	public GImage n76;

	public GImage n77;

	public GImage n78;

	public GImage n67;

	public GImage n68;

	public GImage n69;

	public GGroup n70;

	public GImage n72;

	public GImage n73;

	public GImage n74;

	public GGroup n75;

	public GTextField UnitNumberInfo;

	public GTextField UserLevel;

	public Transition Breath;

	public Transition numTip;

	public const string URL = "ui://twlbabicuv96w";

	public static string Name = "UI_FormationItemBtn";

	public static string GetURL()
	{
		return "ui://twlbabicuv96w";
	}

	public static UI_FormationItemBtn CreateInstance()
	{
		return (UI_FormationItemBtn)(object)UIPackage.CreateObject("Battle", "FormationItemBtn");
	}

	public static UI_FormationItemBtn CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_FormationItemBtn).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://twlbabicuv96w", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_006a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0074: Expected O, but got Unknown
		//IL_0080: Unknown result type (might be due to invalid IL or missing references)
		//IL_008a: Expected O, but got Unknown
		//IL_0096: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a0: Expected O, but got Unknown
		//IL_00ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b6: Expected O, but got Unknown
		//IL_00ff: Unknown result type (might be due to invalid IL or missing references)
		//IL_0109: Expected O, but got Unknown
		//IL_0115: Unknown result type (might be due to invalid IL or missing references)
		//IL_011f: Expected O, but got Unknown
		//IL_0168: Unknown result type (might be due to invalid IL or missing references)
		//IL_0172: Expected O, but got Unknown
		//IL_017e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0188: Expected O, but got Unknown
		//IL_0194: Unknown result type (might be due to invalid IL or missing references)
		//IL_019e: Expected O, but got Unknown
		//IL_01aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b4: Expected O, but got Unknown
		//IL_01c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ca: Expected O, but got Unknown
		//IL_01d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e0: Expected O, but got Unknown
		//IL_01ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f6: Expected O, but got Unknown
		//IL_0202: Unknown result type (might be due to invalid IL or missing references)
		//IL_020c: Expected O, but got Unknown
		//IL_0218: Unknown result type (might be due to invalid IL or missing references)
		//IL_0222: Expected O, but got Unknown
		//IL_022e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0238: Expected O, but got Unknown
		//IL_0244: Unknown result type (might be due to invalid IL or missing references)
		//IL_024e: Expected O, but got Unknown
		//IL_025a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0264: Expected O, but got Unknown
		//IL_0270: Unknown result type (might be due to invalid IL or missing references)
		//IL_027a: Expected O, but got Unknown
		//IL_0286: Unknown result type (might be due to invalid IL or missing references)
		//IL_0290: Expected O, but got Unknown
		//IL_029c: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a6: Expected O, but got Unknown
		//IL_02b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_02bc: Expected O, but got Unknown
		//IL_02c8: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d2: Expected O, but got Unknown
		//IL_02de: Unknown result type (might be due to invalid IL or missing references)
		//IL_02e8: Expected O, but got Unknown
		//IL_02f4: Unknown result type (might be due to invalid IL or missing references)
		//IL_02fe: Expected O, but got Unknown
		//IL_030a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0314: Expected O, but got Unknown
		//IL_0320: Unknown result type (might be due to invalid IL or missing references)
		//IL_032a: Expected O, but got Unknown
		//IL_0336: Unknown result type (might be due to invalid IL or missing references)
		//IL_0340: Expected O, but got Unknown
		//IL_034c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0356: Expected O, but got Unknown
		//IL_0362: Unknown result type (might be due to invalid IL or missing references)
		//IL_036c: Expected O, but got Unknown
		//IL_0378: Unknown result type (might be due to invalid IL or missing references)
		//IL_0382: Expected O, but got Unknown
		//IL_038e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0398: Expected O, but got Unknown
		//IL_03a4: Unknown result type (might be due to invalid IL or missing references)
		//IL_03ae: Expected O, but got Unknown
		//IL_03ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_03c4: Expected O, but got Unknown
		//IL_03d0: Unknown result type (might be due to invalid IL or missing references)
		//IL_03da: Expected O, but got Unknown
		//IL_03e6: Unknown result type (might be due to invalid IL or missing references)
		//IL_03f0: Expected O, but got Unknown
		//IL_03fc: Unknown result type (might be due to invalid IL or missing references)
		//IL_0406: Expected O, but got Unknown
		//IL_0412: Unknown result type (might be due to invalid IL or missing references)
		//IL_041c: Expected O, but got Unknown
		//IL_0428: Unknown result type (might be due to invalid IL or missing references)
		//IL_0432: Expected O, but got Unknown
		//IL_043e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0448: Expected O, but got Unknown
		//IL_0454: Unknown result type (might be due to invalid IL or missing references)
		//IL_045e: Expected O, but got Unknown
		//IL_046a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0474: Expected O, but got Unknown
		//IL_0480: Unknown result type (might be due to invalid IL or missing references)
		//IL_048a: Expected O, but got Unknown
		//IL_0496: Unknown result type (might be due to invalid IL or missing references)
		//IL_04a0: Expected O, but got Unknown
		//IL_04ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_04b6: Expected O, but got Unknown
		//IL_04c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_04cc: Expected O, but got Unknown
		//IL_04d8: Unknown result type (might be due to invalid IL or missing references)
		//IL_04e2: Expected O, but got Unknown
		//IL_04ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_04f8: Expected O, but got Unknown
		//IL_0504: Unknown result type (might be due to invalid IL or missing references)
		//IL_050e: Expected O, but got Unknown
		//IL_051a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0524: Expected O, but got Unknown
		//IL_0530: Unknown result type (might be due to invalid IL or missing references)
		//IL_053a: Expected O, but got Unknown
		//IL_0546: Unknown result type (might be due to invalid IL or missing references)
		//IL_0550: Expected O, but got Unknown
		//IL_055c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0566: Expected O, but got Unknown
		//IL_0572: Unknown result type (might be due to invalid IL or missing references)
		//IL_057c: Expected O, but got Unknown
		//IL_0588: Unknown result type (might be due to invalid IL or missing references)
		//IL_0592: Expected O, but got Unknown
		//IL_059e: Unknown result type (might be due to invalid IL or missing references)
		//IL_05a8: Expected O, but got Unknown
		//IL_05b4: Unknown result type (might be due to invalid IL or missing references)
		//IL_05be: Expected O, but got Unknown
		//IL_05ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_05d4: Expected O, but got Unknown
		//IL_05e0: Unknown result type (might be due to invalid IL or missing references)
		//IL_05ea: Expected O, but got Unknown
		//IL_05f6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0600: Expected O, but got Unknown
		//IL_0649: Unknown result type (might be due to invalid IL or missing references)
		//IL_0653: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		LevelTypeController = ((GComponent)this).GetController("LevelTypeController");
		Status = ((GComponent)this).GetController("Status");
		Assistance = ((GComponent)this).GetController("Assistance");
		PotentialLevel = ((GComponent)this).GetController("PotentialLevel");
		n25 = (GGraph)((GComponent)this).GetChild("n25");
		back = (GGraph)((GComponent)this).GetChild("back");
		IconLoader = (GLoader)((GComponent)this).GetChild("IconLoader");
		SoldierName = (GTextField)((GComponent)this).GetChild("SoldierName");
		string id = "ui://twlbabicuv96w".Replace("ui://", "") + "-" + ((GObject)SoldierName).id;
		((GObject)SoldierName).text = LanguagesManager.GetDesc(id);
		UnlockBack = (GImage)((GComponent)this).GetChild("UnlockBack");
		UnlcokTip = (GTextField)((GComponent)this).GetChild("UnlcokTip");
		string id2 = "ui://twlbabicuv96w".Replace("ui://", "") + "-" + ((GObject)UnlcokTip).id;
		((GObject)UnlcokTip).text = LanguagesManager.GetDesc(id2);
		soldierIconBack = (GImage)((GComponent)this).GetChild("soldierIconBack");
		iconFrame = (GLoader)((GComponent)this).GetChild("iconFrame");
		icon = (GLoader)((GComponent)this).GetChild("icon");
		SoulStoneLevel = (GComponent)((GComponent)this).GetChild("SoulStoneLevel");
		soldierIcon = (GGroup)((GComponent)this).GetChild("soldierIcon");
		n18 = (GImage)((GComponent)this).GetChild("n18");
		SoldierDesc = (GTextField)((GComponent)this).GetChild("SoldierDesc");
		n30 = (GImage)((GComponent)this).GetChild("n30");
		n26 = (GImage)((GComponent)this).GetChild("n26");
		mercenaryLogo = (GImage)((GComponent)this).GetChild("mercenaryLogo");
		n27 = (GImage)((GComponent)this).GetChild("n27");
		n29 = (GImage)((GComponent)this).GetChild("n29");
		n37 = (GGroup)((GComponent)this).GetChild("n37");
		n31 = (GImage)((GComponent)this).GetChild("n31");
		n38 = (GImage)((GComponent)this).GetChild("n38");
		n40 = (GImage)((GComponent)this).GetChild("n40");
		n28 = (GGroup)((GComponent)this).GetChild("n28");
		n41 = (GImage)((GComponent)this).GetChild("n41");
		n42 = (GImage)((GComponent)this).GetChild("n42");
		n46 = (GImage)((GComponent)this).GetChild("n46");
		n45 = (GGroup)((GComponent)this).GetChild("n45");
		n47 = (GImage)((GComponent)this).GetChild("n47");
		n48 = (GImage)((GComponent)this).GetChild("n48");
		n49 = (GImage)((GComponent)this).GetChild("n49");
		n50 = (GGroup)((GComponent)this).GetChild("n50");
		n51 = (GImage)((GComponent)this).GetChild("n51");
		n52 = (GImage)((GComponent)this).GetChild("n52");
		n53 = (GImage)((GComponent)this).GetChild("n53");
		n54 = (GGroup)((GComponent)this).GetChild("n54");
		n55 = (GImage)((GComponent)this).GetChild("n55");
		n56 = (GImage)((GComponent)this).GetChild("n56");
		n57 = (GImage)((GComponent)this).GetChild("n57");
		n58 = (GGroup)((GComponent)this).GetChild("n58");
		n59 = (GImage)((GComponent)this).GetChild("n59");
		n60 = (GImage)((GComponent)this).GetChild("n60");
		n61 = (GImage)((GComponent)this).GetChild("n61");
		n62 = (GGroup)((GComponent)this).GetChild("n62");
		n63 = (GImage)((GComponent)this).GetChild("n63");
		n64 = (GImage)((GComponent)this).GetChild("n64");
		n65 = (GImage)((GComponent)this).GetChild("n65");
		n66 = (GGroup)((GComponent)this).GetChild("n66");
		n79 = (GGroup)((GComponent)this).GetChild("n79");
		n76 = (GImage)((GComponent)this).GetChild("n76");
		n77 = (GImage)((GComponent)this).GetChild("n77");
		n78 = (GImage)((GComponent)this).GetChild("n78");
		n67 = (GImage)((GComponent)this).GetChild("n67");
		n68 = (GImage)((GComponent)this).GetChild("n68");
		n69 = (GImage)((GComponent)this).GetChild("n69");
		n70 = (GGroup)((GComponent)this).GetChild("n70");
		n72 = (GImage)((GComponent)this).GetChild("n72");
		n73 = (GImage)((GComponent)this).GetChild("n73");
		n74 = (GImage)((GComponent)this).GetChild("n74");
		n75 = (GGroup)((GComponent)this).GetChild("n75");
		UnitNumberInfo = (GTextField)((GComponent)this).GetChild("UnitNumberInfo");
		string id3 = "ui://twlbabicuv96w".Replace("ui://", "") + "-" + ((GObject)UnitNumberInfo).id;
		((GObject)UnitNumberInfo).text = LanguagesManager.GetDesc(id3);
		UserLevel = (GTextField)((GComponent)this).GetChild("UserLevel");
		Breath = ((GComponent)this).GetTransition("Breath");
		numTip = ((GComponent)this).GetTransition("numTip");
	}
}
