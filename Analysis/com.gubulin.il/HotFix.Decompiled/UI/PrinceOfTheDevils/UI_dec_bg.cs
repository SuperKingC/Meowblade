using FairyGUI;
using FairyGUI.Utils;

namespace UI.PrinceOfTheDevils;

public class UI_dec_bg : GComponent
{
	public GImage n0;

	public GImage n2;

	public GImage n3;

	public GImage n4;

	public GImage n6;

	public GImage n7;

	public GImage n11;

	public GGraph FXWrapper;

	public GMovieClip n14;

	public GMovieClip n15;

	public GMovieClip n16;

	public GMovieClip n17;

	public GMovieClip n18;

	public GMovieClip n19;

	public GImage light_1;

	public GImage light_2;

	public GImage light_3;

	public GImage n5;

	public GImage n1;

	public Transition t0;

	public const string URL = "ui://zko5n3veoymger";

	public static string Name = "UI_dec_bg";

	public static string GetURL()
	{
		return "ui://zko5n3veoymger";
	}

	public static UI_dec_bg CreateInstance()
	{
		return (UI_dec_bg)(object)UIPackage.CreateObject("PrinceOfTheDevils", "dec_bg");
	}

	public static UI_dec_bg CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_dec_bg).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://zko5n3veoymger", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_00c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cf: Expected O, but got Unknown
		//IL_00db: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e5: Expected O, but got Unknown
		//IL_00f1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fb: Expected O, but got Unknown
		//IL_0107: Unknown result type (might be due to invalid IL or missing references)
		//IL_0111: Expected O, but got Unknown
		//IL_011d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0127: Expected O, but got Unknown
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
		((GComponent)this).ConstructFromXML(xml);
		n0 = (GImage)((GComponent)this).GetChild("n0");
		n2 = (GImage)((GComponent)this).GetChild("n2");
		n3 = (GImage)((GComponent)this).GetChild("n3");
		n4 = (GImage)((GComponent)this).GetChild("n4");
		n6 = (GImage)((GComponent)this).GetChild("n6");
		n7 = (GImage)((GComponent)this).GetChild("n7");
		n11 = (GImage)((GComponent)this).GetChild("n11");
		FXWrapper = (GGraph)((GComponent)this).GetChild("FXWrapper");
		n14 = (GMovieClip)((GComponent)this).GetChild("n14");
		n15 = (GMovieClip)((GComponent)this).GetChild("n15");
		n16 = (GMovieClip)((GComponent)this).GetChild("n16");
		n17 = (GMovieClip)((GComponent)this).GetChild("n17");
		n18 = (GMovieClip)((GComponent)this).GetChild("n18");
		n19 = (GMovieClip)((GComponent)this).GetChild("n19");
		light_1 = (GImage)((GComponent)this).GetChild("light-1");
		light_2 = (GImage)((GComponent)this).GetChild("light-2");
		light_3 = (GImage)((GComponent)this).GetChild("light-3");
		n5 = (GImage)((GComponent)this).GetChild("n5");
		n1 = (GImage)((GComponent)this).GetChild("n1");
		t0 = ((GComponent)this).GetTransition("t0");
	}
}
