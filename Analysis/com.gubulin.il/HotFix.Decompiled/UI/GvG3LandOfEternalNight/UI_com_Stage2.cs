using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvG3LandOfEternalNight;

public class UI_com_Stage2 : GComponent
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

	public UI_eff_star_yellow n78;

	public UI_eff_star_blue n79;

	public UI_eff_star_purple n80;

	public UI_eff_star_purple n81;

	public UI_eff_star_purple n82;

	public UI_eff_star_blue n83;

	public UI_eff_star_purple n84;

	public UI_eff_star_purple n85;

	public UI_eff_star_blue n86;

	public GImage n71;

	public GImage n73;

	public GImage n74;

	public GImage n77;

	public GImage n87;

	public GImage n76;

	public GImage n41;

	public GImage n37;

	public GImage n38;

	public GImage n68;

	public GImage n40;

	public GImage n47;

	public GImage n42;

	public GImage n69;

	public GImage n39;

	public GImage n44;

	public GImage n45;

	public GImage n43;

	public GImage n70;

	public GImage n48;

	public GImage n46;

	public GImage n49;

	public GImage n50;

	public GImage n8;

	public Transition t0;

	public Transition t1;

	public const string URL = "ui://amuqyzl8g180s";

	public static string Name = "UI_com_Stage2";

	public static string GetURL()
	{
		return "ui://amuqyzl8g180s";
	}

	public static UI_com_Stage2 CreateInstance()
	{
		return (UI_com_Stage2)(object)UIPackage.CreateObject("GvG3LandOfEternalNight", "com_Stage2");
	}

	public static UI_com_Stage2 CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_Stage2).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://amuqyzl8g180s", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		n78 = (UI_eff_star_yellow)(object)((GComponent)this).GetChild("n78");
		n79 = (UI_eff_star_blue)(object)((GComponent)this).GetChild("n79");
		n80 = (UI_eff_star_purple)(object)((GComponent)this).GetChild("n80");
		n81 = (UI_eff_star_purple)(object)((GComponent)this).GetChild("n81");
		n82 = (UI_eff_star_purple)(object)((GComponent)this).GetChild("n82");
		n83 = (UI_eff_star_blue)(object)((GComponent)this).GetChild("n83");
		n84 = (UI_eff_star_purple)(object)((GComponent)this).GetChild("n84");
		n85 = (UI_eff_star_purple)(object)((GComponent)this).GetChild("n85");
		n86 = (UI_eff_star_blue)(object)((GComponent)this).GetChild("n86");
		n71 = (GImage)((GComponent)this).GetChild("n71");
		n73 = (GImage)((GComponent)this).GetChild("n73");
		n74 = (GImage)((GComponent)this).GetChild("n74");
		n77 = (GImage)((GComponent)this).GetChild("n77");
		n87 = (GImage)((GComponent)this).GetChild("n87");
		n76 = (GImage)((GComponent)this).GetChild("n76");
		n41 = (GImage)((GComponent)this).GetChild("n41");
		n37 = (GImage)((GComponent)this).GetChild("n37");
		n38 = (GImage)((GComponent)this).GetChild("n38");
		n68 = (GImage)((GComponent)this).GetChild("n68");
		n40 = (GImage)((GComponent)this).GetChild("n40");
		n47 = (GImage)((GComponent)this).GetChild("n47");
		n42 = (GImage)((GComponent)this).GetChild("n42");
		n69 = (GImage)((GComponent)this).GetChild("n69");
		n39 = (GImage)((GComponent)this).GetChild("n39");
		n44 = (GImage)((GComponent)this).GetChild("n44");
		n45 = (GImage)((GComponent)this).GetChild("n45");
		n43 = (GImage)((GComponent)this).GetChild("n43");
		n70 = (GImage)((GComponent)this).GetChild("n70");
		n48 = (GImage)((GComponent)this).GetChild("n48");
		n46 = (GImage)((GComponent)this).GetChild("n46");
		n49 = (GImage)((GComponent)this).GetChild("n49");
		n50 = (GImage)((GComponent)this).GetChild("n50");
		n8 = (GImage)((GComponent)this).GetChild("n8");
		t0 = ((GComponent)this).GetTransition("t0");
		t1 = ((GComponent)this).GetTransition("t1");
	}
}
