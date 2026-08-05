using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGFlagship3;

public class UI_com_background : GComponent
{
	public Controller Camp;

	public GImage n10;

	public UI_dec_land03 n35;

	public UI_dec_land02 n34;

	public UI_dec_land n33;

	public GImage n11;

	public GImage n12;

	public GLoader n18;

	public GLoader n17;

	public GLoader n15;

	public GMovieClip n99;

	public GLoader n14;

	public GMovieClip n102;

	public GImage n36;

	public UI_com_flag05 n32;

	public UI_com_flag04 n31;

	public UI_com_flag03 n30;

	public UI_com_flag01 n28;

	public UI_com_flag02 n29;

	public GImage n20;

	public UI_dec_light08 n93;

	public UI_dec_light09 n96;

	public UI_dec_light07 n46;

	public UI_dec_light06 n41;

	public UI_dec_light05 n39;

	public UI_dec_light04 n40;

	public UI_dec_light03 n38;

	public UI_dec_light02 n37;

	public UI_dec_light01 n21;

	public GMovieClip n24;

	public GMovieClip n25;

	public GMovieClip n26;

	public GMovieClip n27;

	public UI_dec_rock01 n50;

	public UI_dec_rock02 n54;

	public GImage n19;

	public UI_dec_ship02 n56;

	public UI_dec_ship01 n60;

	public UI_dec_ship03 n66;

	public UI_dec_ship04 n77;

	public UI_dec_ship05 n85;

	public GImage n13;

	public GMovieClip n97;

	public GMovieClip n98;

	public GMovieClip n100;

	public GMovieClip n101;

	public Transition t0;

	public Transition t1;

	public Transition t2;

	public Transition t3;

	public Transition t4;

	public const string URL = "ui://tvr786zljb4i39";

	public static string Name = "UI_com_background";

	public static string GetURL()
	{
		return "ui://tvr786zljb4i39";
	}

	public static UI_com_background CreateInstance()
	{
		return (UI_com_background)(object)UIPackage.CreateObject("GvGFlagship3", "com_background");
	}

	public static UI_com_background CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_background).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://tvr786zljb4i39", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0088: Expected O, but got Unknown
		//IL_0094: Unknown result type (might be due to invalid IL or missing references)
		//IL_009e: Expected O, but got Unknown
		//IL_00aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b4: Expected O, but got Unknown
		//IL_00c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ca: Expected O, but got Unknown
		//IL_00d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e0: Expected O, but got Unknown
		//IL_00ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f6: Expected O, but got Unknown
		//IL_0102: Unknown result type (might be due to invalid IL or missing references)
		//IL_010c: Expected O, but got Unknown
		//IL_0118: Unknown result type (might be due to invalid IL or missing references)
		//IL_0122: Expected O, but got Unknown
		//IL_012e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0138: Expected O, but got Unknown
		//IL_01b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_01bc: Expected O, but got Unknown
		//IL_028e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0298: Expected O, but got Unknown
		//IL_02a4: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ae: Expected O, but got Unknown
		//IL_02ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c4: Expected O, but got Unknown
		//IL_02d0: Unknown result type (might be due to invalid IL or missing references)
		//IL_02da: Expected O, but got Unknown
		//IL_0312: Unknown result type (might be due to invalid IL or missing references)
		//IL_031c: Expected O, but got Unknown
		//IL_0396: Unknown result type (might be due to invalid IL or missing references)
		//IL_03a0: Expected O, but got Unknown
		//IL_03ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_03b6: Expected O, but got Unknown
		//IL_03c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_03cc: Expected O, but got Unknown
		//IL_03d8: Unknown result type (might be due to invalid IL or missing references)
		//IL_03e2: Expected O, but got Unknown
		//IL_03ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_03f8: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Camp = ((GComponent)this).GetController("Camp");
		n10 = (GImage)((GComponent)this).GetChild("n10");
		n35 = (UI_dec_land03)(object)((GComponent)this).GetChild("n35");
		n34 = (UI_dec_land02)(object)((GComponent)this).GetChild("n34");
		n33 = (UI_dec_land)(object)((GComponent)this).GetChild("n33");
		n11 = (GImage)((GComponent)this).GetChild("n11");
		n12 = (GImage)((GComponent)this).GetChild("n12");
		n18 = (GLoader)((GComponent)this).GetChild("n18");
		n17 = (GLoader)((GComponent)this).GetChild("n17");
		n15 = (GLoader)((GComponent)this).GetChild("n15");
		n99 = (GMovieClip)((GComponent)this).GetChild("n99");
		n14 = (GLoader)((GComponent)this).GetChild("n14");
		n102 = (GMovieClip)((GComponent)this).GetChild("n102");
		n36 = (GImage)((GComponent)this).GetChild("n36");
		n32 = (UI_com_flag05)(object)((GComponent)this).GetChild("n32");
		n31 = (UI_com_flag04)(object)((GComponent)this).GetChild("n31");
		n30 = (UI_com_flag03)(object)((GComponent)this).GetChild("n30");
		n28 = (UI_com_flag01)(object)((GComponent)this).GetChild("n28");
		n29 = (UI_com_flag02)(object)((GComponent)this).GetChild("n29");
		n20 = (GImage)((GComponent)this).GetChild("n20");
		n93 = (UI_dec_light08)(object)((GComponent)this).GetChild("n93");
		n96 = (UI_dec_light09)(object)((GComponent)this).GetChild("n96");
		n46 = (UI_dec_light07)(object)((GComponent)this).GetChild("n46");
		n41 = (UI_dec_light06)(object)((GComponent)this).GetChild("n41");
		n39 = (UI_dec_light05)(object)((GComponent)this).GetChild("n39");
		n40 = (UI_dec_light04)(object)((GComponent)this).GetChild("n40");
		n38 = (UI_dec_light03)(object)((GComponent)this).GetChild("n38");
		n37 = (UI_dec_light02)(object)((GComponent)this).GetChild("n37");
		n21 = (UI_dec_light01)(object)((GComponent)this).GetChild("n21");
		n24 = (GMovieClip)((GComponent)this).GetChild("n24");
		n25 = (GMovieClip)((GComponent)this).GetChild("n25");
		n26 = (GMovieClip)((GComponent)this).GetChild("n26");
		n27 = (GMovieClip)((GComponent)this).GetChild("n27");
		n50 = (UI_dec_rock01)(object)((GComponent)this).GetChild("n50");
		n54 = (UI_dec_rock02)(object)((GComponent)this).GetChild("n54");
		n19 = (GImage)((GComponent)this).GetChild("n19");
		n56 = (UI_dec_ship02)(object)((GComponent)this).GetChild("n56");
		n60 = (UI_dec_ship01)(object)((GComponent)this).GetChild("n60");
		n66 = (UI_dec_ship03)(object)((GComponent)this).GetChild("n66");
		n77 = (UI_dec_ship04)(object)((GComponent)this).GetChild("n77");
		n85 = (UI_dec_ship05)(object)((GComponent)this).GetChild("n85");
		n13 = (GImage)((GComponent)this).GetChild("n13");
		n97 = (GMovieClip)((GComponent)this).GetChild("n97");
		n98 = (GMovieClip)((GComponent)this).GetChild("n98");
		n100 = (GMovieClip)((GComponent)this).GetChild("n100");
		n101 = (GMovieClip)((GComponent)this).GetChild("n101");
		t0 = ((GComponent)this).GetTransition("t0");
		t1 = ((GComponent)this).GetTransition("t1");
		t2 = ((GComponent)this).GetTransition("t2");
		t3 = ((GComponent)this).GetTransition("t3");
		t4 = ((GComponent)this).GetTransition("t4");
	}
}
