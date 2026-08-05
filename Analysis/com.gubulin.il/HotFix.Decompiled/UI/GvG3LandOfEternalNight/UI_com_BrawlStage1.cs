using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvG3LandOfEternalNight;

public class UI_com_BrawlStage1 : GComponent
{
	public GGraph mask;

	public GImage n9;

	public GImage fx_energy;

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

	public GImage n10;

	public GImage n11;

	public GImage cloud00;

	public GImage n90;

	public UI_dec_DrawlCloud_01 cloud01;

	public UI_dec_DrawlCloud_02 cloud02;

	public UI_dec_DrawlCloud_03 cloud03;

	public GImage n51;

	public UI_dec_DrawlCloud_04 cloud04;

	public UI_dec_DrawlCloud_05 cloud05;

	public UI_dec_DrawlCloud_06 cloud06;

	public GImage n50;

	public GImage n8;

	public Transition t0;

	public Transition t1;

	public const string URL = "ui://amuqyzl8ricp19";

	public static string Name = "UI_com_BrawlStage1";

	public static string GetURL()
	{
		return "ui://amuqyzl8ricp19";
	}

	public static UI_com_BrawlStage1 CreateInstance()
	{
		return (UI_com_BrawlStage1)(object)UIPackage.CreateObject("GvG3LandOfEternalNight", "com_BrawlStage1");
	}

	public static UI_com_BrawlStage1 CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_BrawlStage1).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://amuqyzl8ricp19", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_01cd: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d7: Expected O, but got Unknown
		//IL_0225: Unknown result type (might be due to invalid IL or missing references)
		//IL_022f: Expected O, but got Unknown
		//IL_023b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0245: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		mask = (GGraph)((GComponent)this).GetChild("mask");
		n9 = (GImage)((GComponent)this).GetChild("n9");
		fx_energy = (GImage)((GComponent)this).GetChild("fx-energy");
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
		n10 = (GImage)((GComponent)this).GetChild("n10");
		n11 = (GImage)((GComponent)this).GetChild("n11");
		cloud00 = (GImage)((GComponent)this).GetChild("cloud00");
		n90 = (GImage)((GComponent)this).GetChild("n90");
		cloud01 = (UI_dec_DrawlCloud_01)(object)((GComponent)this).GetChild("cloud01");
		cloud02 = (UI_dec_DrawlCloud_02)(object)((GComponent)this).GetChild("cloud02");
		cloud03 = (UI_dec_DrawlCloud_03)(object)((GComponent)this).GetChild("cloud03");
		n51 = (GImage)((GComponent)this).GetChild("n51");
		cloud04 = (UI_dec_DrawlCloud_04)(object)((GComponent)this).GetChild("cloud04");
		cloud05 = (UI_dec_DrawlCloud_05)(object)((GComponent)this).GetChild("cloud05");
		cloud06 = (UI_dec_DrawlCloud_06)(object)((GComponent)this).GetChild("cloud06");
		n50 = (GImage)((GComponent)this).GetChild("n50");
		n8 = (GImage)((GComponent)this).GetChild("n8");
		t0 = ((GComponent)this).GetTransition("t0");
		t1 = ((GComponent)this).GetTransition("t1");
	}
}
