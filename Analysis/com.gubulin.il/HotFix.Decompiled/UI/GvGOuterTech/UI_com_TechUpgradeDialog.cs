using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGOuterTech;

public class UI_com_TechUpgradeDialog : GComponent
{
	public Controller Rarity;

	public Controller State;

	public Controller ConsumeState;

	public UI_dec_block10 n74;

	public UI_dec_block09 n73;

	public UI_dec_block09 n72;

	public GImage n43;

	public GLoader n45;

	public UI_dec_block11 n75;

	public UI_dec_block12 n76;

	public GImage n49;

	public UI_com_UpgradeConfirmPane UpgradePane;

	public GGroup n38;

	public GTextField TechName;

	public GTextField Level;

	public GRichTextField Desc;

	public GImage n50;

	public GImage n78;

	public GImage n5;

	public GImage n12;

	public GImage n13;

	public GImage n55;

	public GImage n54;

	public GTextField n14;

	public GTextField n15;

	public GImage n31;

	public GImage n58;

	public GImage n57;

	public GTextField n33;

	public GTextField n18;

	public GTextField UnlockEffect;

	public GTextField CurEffect;

	public GTextField NextEffect;

	public GTextField MaxEffect;

	public GLoader Frame;

	public UI_dec_light03 n77;

	public GLoader n41;

	public GImage n42;

	public GLoader TechIcon;

	public GImage n46;

	public GImage n47;

	public UI_dec_light01 n63;

	public UI_dec_light02 n71;

	public GGroup n48;

	public GTextField n35;

	public GImage n51;

	public GGroup n52;

	public GTextField n36;

	public GImage n53;

	public GGroup n56;

	public GTextField n37;

	public GImage n59;

	public GGroup n60;

	public GImage n61;

	public GImage n62;

	public GTextField n40;

	public GMovieClip n80;

	public GImage n79;

	public GImage n82;

	public GMovieClip n81;

	public GMovieClip n83;

	public GMovieClip n84;

	public GImage n85;

	public GMovieClip n86;

	public GMovieClip n87;

	public GMovieClip n88;

	public GMovieClip n89;

	public GMovieClip n90;

	public GMovieClip n91;

	public GMovieClip n92;

	public GImage n94;

	public GImage n97;

	public GMovieClip n98;

	public Transition t0;

	public Transition t1;

	public Transition UpgradeTrans;

	public Transition UnlockTrans;

	public const string URL = "ui://th385mtttnil2b";

	public static string Name = "UI_com_TechUpgradeDialog";

	public static string GetURL()
	{
		return "ui://th385mtttnil2b";
	}

	public static UI_com_TechUpgradeDialog CreateInstance()
	{
		return (UI_com_TechUpgradeDialog)(object)UIPackage.CreateObject("GvGOuterTech", "com_TechUpgradeDialog");
	}

	public static UI_com_TechUpgradeDialog CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_TechUpgradeDialog).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://th385mtttnil2b", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_008a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0094: Expected O, but got Unknown
		//IL_00a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00aa: Expected O, but got Unknown
		//IL_00e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ec: Expected O, but got Unknown
		//IL_010e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0118: Expected O, but got Unknown
		//IL_0124: Unknown result type (might be due to invalid IL or missing references)
		//IL_012e: Expected O, but got Unknown
		//IL_013a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0144: Expected O, but got Unknown
		//IL_0150: Unknown result type (might be due to invalid IL or missing references)
		//IL_015a: Expected O, but got Unknown
		//IL_0166: Unknown result type (might be due to invalid IL or missing references)
		//IL_0170: Expected O, but got Unknown
		//IL_017c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0186: Expected O, but got Unknown
		//IL_0192: Unknown result type (might be due to invalid IL or missing references)
		//IL_019c: Expected O, but got Unknown
		//IL_01a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b2: Expected O, but got Unknown
		//IL_01be: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c8: Expected O, but got Unknown
		//IL_01d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_01de: Expected O, but got Unknown
		//IL_01ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f4: Expected O, but got Unknown
		//IL_0200: Unknown result type (might be due to invalid IL or missing references)
		//IL_020a: Expected O, but got Unknown
		//IL_0253: Unknown result type (might be due to invalid IL or missing references)
		//IL_025d: Expected O, but got Unknown
		//IL_02a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b0: Expected O, but got Unknown
		//IL_02bc: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c6: Expected O, but got Unknown
		//IL_02d2: Unknown result type (might be due to invalid IL or missing references)
		//IL_02dc: Expected O, but got Unknown
		//IL_02e8: Unknown result type (might be due to invalid IL or missing references)
		//IL_02f2: Expected O, but got Unknown
		//IL_033b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0345: Expected O, but got Unknown
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
		//IL_04ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_04b6: Expected O, but got Unknown
		//IL_04c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_04cc: Expected O, but got Unknown
		//IL_0517: Unknown result type (might be due to invalid IL or missing references)
		//IL_0521: Expected O, but got Unknown
		//IL_052d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0537: Expected O, but got Unknown
		//IL_0543: Unknown result type (might be due to invalid IL or missing references)
		//IL_054d: Expected O, but got Unknown
		//IL_0598: Unknown result type (might be due to invalid IL or missing references)
		//IL_05a2: Expected O, but got Unknown
		//IL_05ae: Unknown result type (might be due to invalid IL or missing references)
		//IL_05b8: Expected O, but got Unknown
		//IL_05c4: Unknown result type (might be due to invalid IL or missing references)
		//IL_05ce: Expected O, but got Unknown
		//IL_0619: Unknown result type (might be due to invalid IL or missing references)
		//IL_0623: Expected O, but got Unknown
		//IL_062f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0639: Expected O, but got Unknown
		//IL_0645: Unknown result type (might be due to invalid IL or missing references)
		//IL_064f: Expected O, but got Unknown
		//IL_065b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0665: Expected O, but got Unknown
		//IL_0671: Unknown result type (might be due to invalid IL or missing references)
		//IL_067b: Expected O, but got Unknown
		//IL_06c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_06d0: Expected O, but got Unknown
		//IL_06dc: Unknown result type (might be due to invalid IL or missing references)
		//IL_06e6: Expected O, but got Unknown
		//IL_06f2: Unknown result type (might be due to invalid IL or missing references)
		//IL_06fc: Expected O, but got Unknown
		//IL_0708: Unknown result type (might be due to invalid IL or missing references)
		//IL_0712: Expected O, but got Unknown
		//IL_071e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0728: Expected O, but got Unknown
		//IL_0734: Unknown result type (might be due to invalid IL or missing references)
		//IL_073e: Expected O, but got Unknown
		//IL_074a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0754: Expected O, but got Unknown
		//IL_0760: Unknown result type (might be due to invalid IL or missing references)
		//IL_076a: Expected O, but got Unknown
		//IL_0776: Unknown result type (might be due to invalid IL or missing references)
		//IL_0780: Expected O, but got Unknown
		//IL_078c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0796: Expected O, but got Unknown
		//IL_07a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_07ac: Expected O, but got Unknown
		//IL_07b8: Unknown result type (might be due to invalid IL or missing references)
		//IL_07c2: Expected O, but got Unknown
		//IL_07ce: Unknown result type (might be due to invalid IL or missing references)
		//IL_07d8: Expected O, but got Unknown
		//IL_07e4: Unknown result type (might be due to invalid IL or missing references)
		//IL_07ee: Expected O, but got Unknown
		//IL_07fa: Unknown result type (might be due to invalid IL or missing references)
		//IL_0804: Expected O, but got Unknown
		//IL_0810: Unknown result type (might be due to invalid IL or missing references)
		//IL_081a: Expected O, but got Unknown
		//IL_0826: Unknown result type (might be due to invalid IL or missing references)
		//IL_0830: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Rarity = ((GComponent)this).GetController("Rarity");
		State = ((GComponent)this).GetController("State");
		ConsumeState = ((GComponent)this).GetController("ConsumeState");
		n74 = (UI_dec_block10)(object)((GComponent)this).GetChild("n74");
		n73 = (UI_dec_block09)(object)((GComponent)this).GetChild("n73");
		n72 = (UI_dec_block09)(object)((GComponent)this).GetChild("n72");
		n43 = (GImage)((GComponent)this).GetChild("n43");
		n45 = (GLoader)((GComponent)this).GetChild("n45");
		n75 = (UI_dec_block11)(object)((GComponent)this).GetChild("n75");
		n76 = (UI_dec_block12)(object)((GComponent)this).GetChild("n76");
		n49 = (GImage)((GComponent)this).GetChild("n49");
		UpgradePane = (UI_com_UpgradeConfirmPane)(object)((GComponent)this).GetChild("UpgradePane");
		n38 = (GGroup)((GComponent)this).GetChild("n38");
		TechName = (GTextField)((GComponent)this).GetChild("TechName");
		Level = (GTextField)((GComponent)this).GetChild("Level");
		Desc = (GRichTextField)((GComponent)this).GetChild("Desc");
		n50 = (GImage)((GComponent)this).GetChild("n50");
		n78 = (GImage)((GComponent)this).GetChild("n78");
		n5 = (GImage)((GComponent)this).GetChild("n5");
		n12 = (GImage)((GComponent)this).GetChild("n12");
		n13 = (GImage)((GComponent)this).GetChild("n13");
		n55 = (GImage)((GComponent)this).GetChild("n55");
		n54 = (GImage)((GComponent)this).GetChild("n54");
		n14 = (GTextField)((GComponent)this).GetChild("n14");
		string id = "ui://th385mtttnil2b".Replace("ui://", "") + "-" + ((GObject)n14).id;
		((GObject)n14).text = LanguagesManager.GetDesc(id);
		n15 = (GTextField)((GComponent)this).GetChild("n15");
		string id2 = "ui://th385mtttnil2b".Replace("ui://", "") + "-" + ((GObject)n15).id;
		((GObject)n15).text = LanguagesManager.GetDesc(id2);
		n31 = (GImage)((GComponent)this).GetChild("n31");
		n58 = (GImage)((GComponent)this).GetChild("n58");
		n57 = (GImage)((GComponent)this).GetChild("n57");
		n33 = (GTextField)((GComponent)this).GetChild("n33");
		string id3 = "ui://th385mtttnil2b".Replace("ui://", "") + "-" + ((GObject)n33).id;
		((GObject)n33).text = LanguagesManager.GetDesc(id3);
		n18 = (GTextField)((GComponent)this).GetChild("n18");
		string id4 = "ui://th385mtttnil2b".Replace("ui://", "") + "-" + ((GObject)n18).id;
		((GObject)n18).text = LanguagesManager.GetDesc(id4);
		UnlockEffect = (GTextField)((GComponent)this).GetChild("UnlockEffect");
		CurEffect = (GTextField)((GComponent)this).GetChild("CurEffect");
		NextEffect = (GTextField)((GComponent)this).GetChild("NextEffect");
		MaxEffect = (GTextField)((GComponent)this).GetChild("MaxEffect");
		Frame = (GLoader)((GComponent)this).GetChild("Frame");
		n77 = (UI_dec_light03)(object)((GComponent)this).GetChild("n77");
		n41 = (GLoader)((GComponent)this).GetChild("n41");
		n42 = (GImage)((GComponent)this).GetChild("n42");
		TechIcon = (GLoader)((GComponent)this).GetChild("TechIcon");
		n46 = (GImage)((GComponent)this).GetChild("n46");
		n47 = (GImage)((GComponent)this).GetChild("n47");
		n63 = (UI_dec_light01)(object)((GComponent)this).GetChild("n63");
		n71 = (UI_dec_light02)(object)((GComponent)this).GetChild("n71");
		n48 = (GGroup)((GComponent)this).GetChild("n48");
		n35 = (GTextField)((GComponent)this).GetChild("n35");
		string id5 = "ui://th385mtttnil2b".Replace("ui://", "") + "-" + ((GObject)n35).id;
		((GObject)n35).text = LanguagesManager.GetDesc(id5);
		n51 = (GImage)((GComponent)this).GetChild("n51");
		n52 = (GGroup)((GComponent)this).GetChild("n52");
		n36 = (GTextField)((GComponent)this).GetChild("n36");
		string id6 = "ui://th385mtttnil2b".Replace("ui://", "") + "-" + ((GObject)n36).id;
		((GObject)n36).text = LanguagesManager.GetDesc(id6);
		n53 = (GImage)((GComponent)this).GetChild("n53");
		n56 = (GGroup)((GComponent)this).GetChild("n56");
		n37 = (GTextField)((GComponent)this).GetChild("n37");
		string id7 = "ui://th385mtttnil2b".Replace("ui://", "") + "-" + ((GObject)n37).id;
		((GObject)n37).text = LanguagesManager.GetDesc(id7);
		n59 = (GImage)((GComponent)this).GetChild("n59");
		n60 = (GGroup)((GComponent)this).GetChild("n60");
		n61 = (GImage)((GComponent)this).GetChild("n61");
		n62 = (GImage)((GComponent)this).GetChild("n62");
		n40 = (GTextField)((GComponent)this).GetChild("n40");
		string id8 = "ui://th385mtttnil2b".Replace("ui://", "") + "-" + ((GObject)n40).id;
		((GObject)n40).text = LanguagesManager.GetDesc(id8);
		n80 = (GMovieClip)((GComponent)this).GetChild("n80");
		n79 = (GImage)((GComponent)this).GetChild("n79");
		n82 = (GImage)((GComponent)this).GetChild("n82");
		n81 = (GMovieClip)((GComponent)this).GetChild("n81");
		n83 = (GMovieClip)((GComponent)this).GetChild("n83");
		n84 = (GMovieClip)((GComponent)this).GetChild("n84");
		n85 = (GImage)((GComponent)this).GetChild("n85");
		n86 = (GMovieClip)((GComponent)this).GetChild("n86");
		n87 = (GMovieClip)((GComponent)this).GetChild("n87");
		n88 = (GMovieClip)((GComponent)this).GetChild("n88");
		n89 = (GMovieClip)((GComponent)this).GetChild("n89");
		n90 = (GMovieClip)((GComponent)this).GetChild("n90");
		n91 = (GMovieClip)((GComponent)this).GetChild("n91");
		n92 = (GMovieClip)((GComponent)this).GetChild("n92");
		n94 = (GImage)((GComponent)this).GetChild("n94");
		n97 = (GImage)((GComponent)this).GetChild("n97");
		n98 = (GMovieClip)((GComponent)this).GetChild("n98");
		t0 = ((GComponent)this).GetTransition("t0");
		t1 = ((GComponent)this).GetTransition("t1");
		UpgradeTrans = ((GComponent)this).GetTransition("UpgradeTrans");
		UnlockTrans = ((GComponent)this).GetTransition("UnlockTrans");
	}
}
