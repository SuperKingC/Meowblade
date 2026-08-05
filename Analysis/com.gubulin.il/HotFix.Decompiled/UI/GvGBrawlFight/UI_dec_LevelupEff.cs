using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGBrawlFight;

public class UI_dec_LevelupEff : GComponent
{
	public GImage n107;

	public GMovieClip n111;

	public GImage n108;

	public GMovieClip n112;

	public GImage n109;

	public GMovieClip n114;

	public GMovieClip n110;

	public Transition t0;

	public const string URL = "ui://hozu168rxig185";

	public static string Name = "UI_dec_LevelupEff";

	public static string GetURL()
	{
		return "ui://hozu168rxig185";
	}

	public static UI_dec_LevelupEff CreateInstance()
	{
		return (UI_dec_LevelupEff)(object)UIPackage.CreateObject("GvGBrawlFight", "dec_LevelupEff");
	}

	public static UI_dec_LevelupEff CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_dec_LevelupEff).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://hozu168rxig185", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		((GComponent)this).ConstructFromXML(xml);
		n107 = (GImage)((GComponent)this).GetChild("n107");
		n111 = (GMovieClip)((GComponent)this).GetChild("n111");
		n108 = (GImage)((GComponent)this).GetChild("n108");
		n112 = (GMovieClip)((GComponent)this).GetChild("n112");
		n109 = (GImage)((GComponent)this).GetChild("n109");
		n114 = (GMovieClip)((GComponent)this).GetChild("n114");
		n110 = (GMovieClip)((GComponent)this).GetChild("n110");
		t0 = ((GComponent)this).GetTransition("t0");
	}
}
