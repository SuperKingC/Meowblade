using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGWorldMap3;

public class UI_com_SweepEffect : GComponent
{
	public GGraph Mask;

	public GImage n3;

	public UI_dec_fire n29;

	public UI_dec_box n20;

	public UI_dec_light02 n4;

	public GMovieClip n13;

	public GMovieClip n14;

	public GMovieClip n15;

	public GMovieClip n16;

	public GMovieClip n17;

	public GMovieClip n18;

	public GMovieClip n19;

	public GMovieClip n22;

	public GMovieClip n21;

	public UI_dec_Records n23;

	public GImage n25;

	public GMovieClip n24;

	public Transition Sweep;

	public const string URL = "ui://4eq8fgd2qjkisam";

	public static string Name = "UI_com_SweepEffect";

	public static string GetURL()
	{
		return "ui://4eq8fgd2qjkisam";
	}

	public static UI_com_SweepEffect CreateInstance()
	{
		return (UI_com_SweepEffect)(object)UIPackage.CreateObject("GvGWorldMap3", "com_SweepEffect");
	}

	public static UI_com_SweepEffect CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_SweepEffect).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://4eq8fgd2qjkisam", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
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
		//IL_015f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0169: Expected O, but got Unknown
		//IL_0175: Unknown result type (might be due to invalid IL or missing references)
		//IL_017f: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Mask = (GGraph)((GComponent)this).GetChild("Mask");
		n3 = (GImage)((GComponent)this).GetChild("n3");
		n29 = (UI_dec_fire)(object)((GComponent)this).GetChild("n29");
		n20 = (UI_dec_box)(object)((GComponent)this).GetChild("n20");
		n4 = (UI_dec_light02)(object)((GComponent)this).GetChild("n4");
		n13 = (GMovieClip)((GComponent)this).GetChild("n13");
		n14 = (GMovieClip)((GComponent)this).GetChild("n14");
		n15 = (GMovieClip)((GComponent)this).GetChild("n15");
		n16 = (GMovieClip)((GComponent)this).GetChild("n16");
		n17 = (GMovieClip)((GComponent)this).GetChild("n17");
		n18 = (GMovieClip)((GComponent)this).GetChild("n18");
		n19 = (GMovieClip)((GComponent)this).GetChild("n19");
		n22 = (GMovieClip)((GComponent)this).GetChild("n22");
		n21 = (GMovieClip)((GComponent)this).GetChild("n21");
		n23 = (UI_dec_Records)(object)((GComponent)this).GetChild("n23");
		n25 = (GImage)((GComponent)this).GetChild("n25");
		n24 = (GMovieClip)((GComponent)this).GetChild("n24");
		Sweep = ((GComponent)this).GetTransition("Sweep");
	}
}
