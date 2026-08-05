using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvG3LandOfEternalNight;

public class UI_com_Stage1 : GComponent
{
	public GGraph mask;

	public GImage n9;

	public GImage fx_energy;

	public UI_eff_star_yellow n56;

	public UI_eff_star_blue n57;

	public UI_eff_star_purple n58;

	public UI_eff_star_purple n59;

	public UI_eff_star_purple n60;

	public UI_eff_star_blue n61;

	public UI_eff_star_purple n62;

	public UI_eff_star_purple n63;

	public UI_eff_star_blue n64;

	public UI_eff_star_yellow n65;

	public GImage n10;

	public GImage n11;

	public GImage n51;

	public GImage n37;

	public GImage n38;

	public GImage n39;

	public GImage n40;

	public GImage n41;

	public GImage n42;

	public GImage n43;

	public GImage n44;

	public GImage n45;

	public GImage n46;

	public GImage n47;

	public GImage n48;

	public GImage n49;

	public GGroup center;

	public GImage n13;

	public GImage n14;

	public GImage n15;

	public GImage n16;

	public GImage n17;

	public GImage n27;

	public GImage n28;

	public GImage n29;

	public GImage n30;

	public GImage n31;

	public GImage n32;

	public GImage n33;

	public GImage n34;

	public GImage n35;

	public GImage n36;

	public GGroup outside;

	public GImage n79;

	public GImage n66;

	public GImage n67;

	public GImage n68;

	public GImage n69;

	public GImage n70;

	public GImage n71;

	public GImage n72;

	public GImage n73;

	public GImage n75;

	public GImage n74;

	public GImage n76;

	public GImage n77;

	public GImage n78;

	public GImage n80;

	public GGroup outside2;

	public GImage n50;

	public GImage n8;

	public Transition t0;

	public Transition t1;

	public const string URL = "ui://amuqyzl8g1809";

	public static string Name = "UI_com_Stage1";

	public static string GetURL()
	{
		return "ui://amuqyzl8g1809";
	}

	public static UI_com_Stage1 CreateInstance()
	{
		return (UI_com_Stage1)(object)UIPackage.CreateObject("GvG3LandOfEternalNight", "com_Stage1");
	}

	public static UI_com_Stage1 CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_Stage1).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://amuqyzl8g1809", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_0133: Unknown result type (might be due to invalid IL or missing references)
		//IL_013d: Expected O, but got Unknown
		//IL_0149: Unknown result type (might be due to invalid IL or missing references)
		//IL_0153: Expected O, but got Unknown
		//IL_015f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0169: Expected O, but got Unknown
		//IL_0175: Unknown result type (might be due to invalid IL or missing references)
		//IL_017f: Expected O, but got Unknown
		//IL_018b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0195: Expected O, but got Unknown
		//IL_01a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ab: Expected O, but got Unknown
		//IL_01b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c1: Expected O, but got Unknown
		//IL_01cd: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d7: Expected O, but got Unknown
		//IL_01e3: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ed: Expected O, but got Unknown
		//IL_01f9: Unknown result type (might be due to invalid IL or missing references)
		//IL_0203: Expected O, but got Unknown
		//IL_020f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0219: Expected O, but got Unknown
		//IL_0225: Unknown result type (might be due to invalid IL or missing references)
		//IL_022f: Expected O, but got Unknown
		//IL_023b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0245: Expected O, but got Unknown
		//IL_0251: Unknown result type (might be due to invalid IL or missing references)
		//IL_025b: Expected O, but got Unknown
		//IL_0267: Unknown result type (might be due to invalid IL or missing references)
		//IL_0271: Expected O, but got Unknown
		//IL_027d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0287: Expected O, but got Unknown
		//IL_0293: Unknown result type (might be due to invalid IL or missing references)
		//IL_029d: Expected O, but got Unknown
		//IL_02a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b3: Expected O, but got Unknown
		//IL_02bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c9: Expected O, but got Unknown
		//IL_02d5: Unknown result type (might be due to invalid IL or missing references)
		//IL_02df: Expected O, but got Unknown
		//IL_02eb: Unknown result type (might be due to invalid IL or missing references)
		//IL_02f5: Expected O, but got Unknown
		//IL_0301: Unknown result type (might be due to invalid IL or missing references)
		//IL_030b: Expected O, but got Unknown
		//IL_0317: Unknown result type (might be due to invalid IL or missing references)
		//IL_0321: Expected O, but got Unknown
		//IL_032d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0337: Expected O, but got Unknown
		//IL_0343: Unknown result type (might be due to invalid IL or missing references)
		//IL_034d: Expected O, but got Unknown
		//IL_0359: Unknown result type (might be due to invalid IL or missing references)
		//IL_0363: Expected O, but got Unknown
		//IL_036f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0379: Expected O, but got Unknown
		//IL_0385: Unknown result type (might be due to invalid IL or missing references)
		//IL_038f: Expected O, but got Unknown
		//IL_039b: Unknown result type (might be due to invalid IL or missing references)
		//IL_03a5: Expected O, but got Unknown
		//IL_03b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_03bb: Expected O, but got Unknown
		//IL_03c7: Unknown result type (might be due to invalid IL or missing references)
		//IL_03d1: Expected O, but got Unknown
		//IL_03dd: Unknown result type (might be due to invalid IL or missing references)
		//IL_03e7: Expected O, but got Unknown
		//IL_03f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_03fd: Expected O, but got Unknown
		//IL_0409: Unknown result type (might be due to invalid IL or missing references)
		//IL_0413: Expected O, but got Unknown
		//IL_041f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0429: Expected O, but got Unknown
		//IL_0435: Unknown result type (might be due to invalid IL or missing references)
		//IL_043f: Expected O, but got Unknown
		//IL_044b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0455: Expected O, but got Unknown
		//IL_0461: Unknown result type (might be due to invalid IL or missing references)
		//IL_046b: Expected O, but got Unknown
		//IL_0477: Unknown result type (might be due to invalid IL or missing references)
		//IL_0481: Expected O, but got Unknown
		//IL_048d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0497: Expected O, but got Unknown
		//IL_04a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_04ad: Expected O, but got Unknown
		//IL_04b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_04c3: Expected O, but got Unknown
		//IL_04cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_04d9: Expected O, but got Unknown
		//IL_04e5: Unknown result type (might be due to invalid IL or missing references)
		//IL_04ef: Expected O, but got Unknown
		//IL_04fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0505: Expected O, but got Unknown
		//IL_0511: Unknown result type (might be due to invalid IL or missing references)
		//IL_051b: Expected O, but got Unknown
		//IL_0527: Unknown result type (might be due to invalid IL or missing references)
		//IL_0531: Expected O, but got Unknown
		//IL_053d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0547: Expected O, but got Unknown
		//IL_0553: Unknown result type (might be due to invalid IL or missing references)
		//IL_055d: Expected O, but got Unknown
		//IL_0569: Unknown result type (might be due to invalid IL or missing references)
		//IL_0573: Expected O, but got Unknown
		//IL_057f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0589: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		mask = (GGraph)((GComponent)this).GetChild("mask");
		n9 = (GImage)((GComponent)this).GetChild("n9");
		fx_energy = (GImage)((GComponent)this).GetChild("fx-energy");
		n56 = (UI_eff_star_yellow)(object)((GComponent)this).GetChild("n56");
		n57 = (UI_eff_star_blue)(object)((GComponent)this).GetChild("n57");
		n58 = (UI_eff_star_purple)(object)((GComponent)this).GetChild("n58");
		n59 = (UI_eff_star_purple)(object)((GComponent)this).GetChild("n59");
		n60 = (UI_eff_star_purple)(object)((GComponent)this).GetChild("n60");
		n61 = (UI_eff_star_blue)(object)((GComponent)this).GetChild("n61");
		n62 = (UI_eff_star_purple)(object)((GComponent)this).GetChild("n62");
		n63 = (UI_eff_star_purple)(object)((GComponent)this).GetChild("n63");
		n64 = (UI_eff_star_blue)(object)((GComponent)this).GetChild("n64");
		n65 = (UI_eff_star_yellow)(object)((GComponent)this).GetChild("n65");
		n10 = (GImage)((GComponent)this).GetChild("n10");
		n11 = (GImage)((GComponent)this).GetChild("n11");
		n51 = (GImage)((GComponent)this).GetChild("n51");
		n37 = (GImage)((GComponent)this).GetChild("n37");
		n38 = (GImage)((GComponent)this).GetChild("n38");
		n39 = (GImage)((GComponent)this).GetChild("n39");
		n40 = (GImage)((GComponent)this).GetChild("n40");
		n41 = (GImage)((GComponent)this).GetChild("n41");
		n42 = (GImage)((GComponent)this).GetChild("n42");
		n43 = (GImage)((GComponent)this).GetChild("n43");
		n44 = (GImage)((GComponent)this).GetChild("n44");
		n45 = (GImage)((GComponent)this).GetChild("n45");
		n46 = (GImage)((GComponent)this).GetChild("n46");
		n47 = (GImage)((GComponent)this).GetChild("n47");
		n48 = (GImage)((GComponent)this).GetChild("n48");
		n49 = (GImage)((GComponent)this).GetChild("n49");
		center = (GGroup)((GComponent)this).GetChild("center");
		n13 = (GImage)((GComponent)this).GetChild("n13");
		n14 = (GImage)((GComponent)this).GetChild("n14");
		n15 = (GImage)((GComponent)this).GetChild("n15");
		n16 = (GImage)((GComponent)this).GetChild("n16");
		n17 = (GImage)((GComponent)this).GetChild("n17");
		n27 = (GImage)((GComponent)this).GetChild("n27");
		n28 = (GImage)((GComponent)this).GetChild("n28");
		n29 = (GImage)((GComponent)this).GetChild("n29");
		n30 = (GImage)((GComponent)this).GetChild("n30");
		n31 = (GImage)((GComponent)this).GetChild("n31");
		n32 = (GImage)((GComponent)this).GetChild("n32");
		n33 = (GImage)((GComponent)this).GetChild("n33");
		n34 = (GImage)((GComponent)this).GetChild("n34");
		n35 = (GImage)((GComponent)this).GetChild("n35");
		n36 = (GImage)((GComponent)this).GetChild("n36");
		outside = (GGroup)((GComponent)this).GetChild("outside");
		n79 = (GImage)((GComponent)this).GetChild("n79");
		n66 = (GImage)((GComponent)this).GetChild("n66");
		n67 = (GImage)((GComponent)this).GetChild("n67");
		n68 = (GImage)((GComponent)this).GetChild("n68");
		n69 = (GImage)((GComponent)this).GetChild("n69");
		n70 = (GImage)((GComponent)this).GetChild("n70");
		n71 = (GImage)((GComponent)this).GetChild("n71");
		n72 = (GImage)((GComponent)this).GetChild("n72");
		n73 = (GImage)((GComponent)this).GetChild("n73");
		n75 = (GImage)((GComponent)this).GetChild("n75");
		n74 = (GImage)((GComponent)this).GetChild("n74");
		n76 = (GImage)((GComponent)this).GetChild("n76");
		n77 = (GImage)((GComponent)this).GetChild("n77");
		n78 = (GImage)((GComponent)this).GetChild("n78");
		n80 = (GImage)((GComponent)this).GetChild("n80");
		outside2 = (GGroup)((GComponent)this).GetChild("outside2");
		n50 = (GImage)((GComponent)this).GetChild("n50");
		n8 = (GImage)((GComponent)this).GetChild("n8");
		t0 = ((GComponent)this).GetTransition("t0");
		t1 = ((GComponent)this).GetTransition("t1");
	}
}
