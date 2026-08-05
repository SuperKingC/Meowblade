using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.Battle;

public class UI_GvGTotalDamageNew : GButton
{
	public Controller button;

	public Controller SfxController;

	public GMovieClip n25;

	public GImage n3;

	public GImage n20;

	public GImage n13;

	public GImage n14;

	public GImage n18;

	public GMovieClip n21;

	public GMovieClip n22;

	public GMovieClip n24;

	public GMovieClip n23;

	public GImage n8;

	public GImage n9;

	public GTextField Damage;

	public GMovieClip n10;

	public GMovieClip n11;

	public GMovieClip n12;

	public GMovieClip n15;

	public GMovieClip n16;

	public GMovieClip n17;

	public GMovieClip n19;

	public GTextField n5;

	public GImage n4;

	public Transition D1_D2;

	public Transition D3_D6;

	public const string URL = "ui://twlbabich5wglg";

	public static string Name = "UI_GvGTotalDamageNew";

	public static string GetURL()
	{
		return "ui://twlbabich5wglg";
	}

	public static UI_GvGTotalDamageNew CreateInstance()
	{
		return (UI_GvGTotalDamageNew)(object)UIPackage.CreateObject("Battle", "GvGTotalDamageNew");
	}

	public static UI_GvGTotalDamageNew CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_GvGTotalDamageNew).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://twlbabich5wglg", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Expected O, but got Unknown
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Expected O, but got Unknown
		//IL_0063: Unknown result type (might be due to invalid IL or missing references)
		//IL_006d: Expected O, but got Unknown
		//IL_0079: Unknown result type (might be due to invalid IL or missing references)
		//IL_0083: Expected O, but got Unknown
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
		//IL_0242: Unknown result type (might be due to invalid IL or missing references)
		//IL_024c: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		SfxController = ((GComponent)this).GetController("SfxController");
		n25 = (GMovieClip)((GComponent)this).GetChild("n25");
		n3 = (GImage)((GComponent)this).GetChild("n3");
		n20 = (GImage)((GComponent)this).GetChild("n20");
		n13 = (GImage)((GComponent)this).GetChild("n13");
		n14 = (GImage)((GComponent)this).GetChild("n14");
		n18 = (GImage)((GComponent)this).GetChild("n18");
		n21 = (GMovieClip)((GComponent)this).GetChild("n21");
		n22 = (GMovieClip)((GComponent)this).GetChild("n22");
		n24 = (GMovieClip)((GComponent)this).GetChild("n24");
		n23 = (GMovieClip)((GComponent)this).GetChild("n23");
		n8 = (GImage)((GComponent)this).GetChild("n8");
		n9 = (GImage)((GComponent)this).GetChild("n9");
		Damage = (GTextField)((GComponent)this).GetChild("Damage");
		n10 = (GMovieClip)((GComponent)this).GetChild("n10");
		n11 = (GMovieClip)((GComponent)this).GetChild("n11");
		n12 = (GMovieClip)((GComponent)this).GetChild("n12");
		n15 = (GMovieClip)((GComponent)this).GetChild("n15");
		n16 = (GMovieClip)((GComponent)this).GetChild("n16");
		n17 = (GMovieClip)((GComponent)this).GetChild("n17");
		n19 = (GMovieClip)((GComponent)this).GetChild("n19");
		n5 = (GTextField)((GComponent)this).GetChild("n5");
		string id = "ui://twlbabich5wglg".Replace("ui://", "") + "-" + ((GObject)n5).id;
		((GObject)n5).text = LanguagesManager.GetDesc(id);
		n4 = (GImage)((GComponent)this).GetChild("n4");
		D1_D2 = ((GComponent)this).GetTransition("D1_D2");
		D3_D6 = ((GComponent)this).GetTransition("D3_D6");
	}
}
