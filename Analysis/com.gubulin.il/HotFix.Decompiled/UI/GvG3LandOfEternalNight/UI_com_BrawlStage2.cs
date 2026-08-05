using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvG3LandOfEternalNight;

public class UI_com_BrawlStage2 : GComponent
{
	public GGraph mask;

	public GImage n9;

	public GImage fx_energy;

	public GImage n71;

	public GImage n73;

	public GImage n74;

	public GImage n77;

	public GImage n87;

	public UI_dec_DrawLightning n56;

	public UI_dec_DrawLightning n57;

	public UI_dec_DrawLightning n58;

	public UI_dec_DrawLightning n59;

	public UI_dec_DrawLightning n60;

	public UI_dec_DrawLightning n61;

	public UI_dec_DrawLightning n62;

	public UI_dec_DrawLightning n63;

	public UI_dec_DrawLightning n64;

	public UI_dec_DrawLightning n65;

	public UI_dec_DrawLightning n78;

	public UI_dec_DrawLightning n79;

	public UI_dec_DrawLightning n80;

	public UI_dec_DrawLightning n81;

	public UI_dec_DrawLightning n82;

	public UI_dec_DrawLightning n83;

	public UI_dec_DrawLightning n84;

	public UI_dec_DrawLightning n85;

	public UI_dec_DrawLightning n86;

	public UI_dec_DrawLightning n95;

	public GImage n76;

	public GImage cloud00;

	public UI_dec_DrawlCloud_01 cloud01;

	public GImage n68;

	public UI_dec_DrawlCloud_02 cloud02;

	public GImage n69;

	public UI_dec_DrawlCloud_03 cloud03;

	public UI_dec_DrawlCloud_04 cloud04;

	public GImage n70;

	public UI_dec_DrawlCloud_05 cloud05;

	public UI_dec_DrawlCloud_06 cloud06;

	public GImage n50;

	public GImage n8;

	public Transition t0;

	public Transition t1;

	public const string URL = "ui://amuqyzl8ricp1a";

	public static string Name = "UI_com_BrawlStage2";

	public static string GetURL()
	{
		return "ui://amuqyzl8ricp1a";
	}

	public static UI_com_BrawlStage2 CreateInstance()
	{
		return (UI_com_BrawlStage2)(object)UIPackage.CreateObject("GvG3LandOfEternalNight", "com_BrawlStage2");
	}

	public static UI_com_BrawlStage2 CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_BrawlStage2).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://amuqyzl8ricp1a", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		//IL_0061: Expected O, but got Unknown
		//IL_006d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0077: Expected O, but got Unknown
		//IL_0083: Unknown result type (might be due to invalid IL or missing references)
		//IL_008d: Expected O, but got Unknown
		//IL_0099: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a3: Expected O, but got Unknown
		//IL_00af: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b9: Expected O, but got Unknown
		//IL_027d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0287: Expected O, but got Unknown
		//IL_0293: Unknown result type (might be due to invalid IL or missing references)
		//IL_029d: Expected O, but got Unknown
		//IL_02bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c9: Expected O, but got Unknown
		//IL_02eb: Unknown result type (might be due to invalid IL or missing references)
		//IL_02f5: Expected O, but got Unknown
		//IL_032d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0337: Expected O, but got Unknown
		//IL_036f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0379: Expected O, but got Unknown
		//IL_0385: Unknown result type (might be due to invalid IL or missing references)
		//IL_038f: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		mask = (GGraph)((GComponent)this).GetChild("mask");
		n9 = (GImage)((GComponent)this).GetChild("n9");
		fx_energy = (GImage)((GComponent)this).GetChild("fx-energy");
		n71 = (GImage)((GComponent)this).GetChild("n71");
		n73 = (GImage)((GComponent)this).GetChild("n73");
		n74 = (GImage)((GComponent)this).GetChild("n74");
		n77 = (GImage)((GComponent)this).GetChild("n77");
		n87 = (GImage)((GComponent)this).GetChild("n87");
		n56 = (UI_dec_DrawLightning)(object)((GComponent)this).GetChild("n56");
		n57 = (UI_dec_DrawLightning)(object)((GComponent)this).GetChild("n57");
		n58 = (UI_dec_DrawLightning)(object)((GComponent)this).GetChild("n58");
		n59 = (UI_dec_DrawLightning)(object)((GComponent)this).GetChild("n59");
		n60 = (UI_dec_DrawLightning)(object)((GComponent)this).GetChild("n60");
		n61 = (UI_dec_DrawLightning)(object)((GComponent)this).GetChild("n61");
		n62 = (UI_dec_DrawLightning)(object)((GComponent)this).GetChild("n62");
		n63 = (UI_dec_DrawLightning)(object)((GComponent)this).GetChild("n63");
		n64 = (UI_dec_DrawLightning)(object)((GComponent)this).GetChild("n64");
		n65 = (UI_dec_DrawLightning)(object)((GComponent)this).GetChild("n65");
		n78 = (UI_dec_DrawLightning)(object)((GComponent)this).GetChild("n78");
		n79 = (UI_dec_DrawLightning)(object)((GComponent)this).GetChild("n79");
		n80 = (UI_dec_DrawLightning)(object)((GComponent)this).GetChild("n80");
		n81 = (UI_dec_DrawLightning)(object)((GComponent)this).GetChild("n81");
		n82 = (UI_dec_DrawLightning)(object)((GComponent)this).GetChild("n82");
		n83 = (UI_dec_DrawLightning)(object)((GComponent)this).GetChild("n83");
		n84 = (UI_dec_DrawLightning)(object)((GComponent)this).GetChild("n84");
		n85 = (UI_dec_DrawLightning)(object)((GComponent)this).GetChild("n85");
		n86 = (UI_dec_DrawLightning)(object)((GComponent)this).GetChild("n86");
		n95 = (UI_dec_DrawLightning)(object)((GComponent)this).GetChild("n95");
		n76 = (GImage)((GComponent)this).GetChild("n76");
		cloud00 = (GImage)((GComponent)this).GetChild("cloud00");
		cloud01 = (UI_dec_DrawlCloud_01)(object)((GComponent)this).GetChild("cloud01");
		n68 = (GImage)((GComponent)this).GetChild("n68");
		cloud02 = (UI_dec_DrawlCloud_02)(object)((GComponent)this).GetChild("cloud02");
		n69 = (GImage)((GComponent)this).GetChild("n69");
		cloud03 = (UI_dec_DrawlCloud_03)(object)((GComponent)this).GetChild("cloud03");
		cloud04 = (UI_dec_DrawlCloud_04)(object)((GComponent)this).GetChild("cloud04");
		n70 = (GImage)((GComponent)this).GetChild("n70");
		cloud05 = (UI_dec_DrawlCloud_05)(object)((GComponent)this).GetChild("cloud05");
		cloud06 = (UI_dec_DrawlCloud_06)(object)((GComponent)this).GetChild("cloud06");
		n50 = (GImage)((GComponent)this).GetChild("n50");
		n8 = (GImage)((GComponent)this).GetChild("n8");
		t0 = ((GComponent)this).GetTransition("t0");
		t1 = ((GComponent)this).GetTransition("t1");
	}
}
