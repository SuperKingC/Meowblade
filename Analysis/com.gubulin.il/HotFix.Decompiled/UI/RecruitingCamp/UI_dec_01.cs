using FairyGUI;
using FairyGUI.Utils;

namespace UI.RecruitingCamp;

public class UI_dec_01 : GComponent
{
	public GImage n208;

	public GImage n209;

	public GImage n207;

	public GImage n206;

	public GImage n211;

	public GImage n213;

	public GImage n212;

	public GMovieClip n220;

	public GMovieClip n219;

	public GImage n210;

	public GMovieClip n218;

	public GImage n215;

	public GImage n216;

	public GImage n217;

	public GMovieClip n221;

	public GMovieClip n222;

	public GImage n214;

	public GMovieClip n223;

	public Transition t0;

	public Transition t1;

	public Transition t2;

	public Transition t3;

	public Transition t4;

	public Transition t5;

	public Transition t6;

	public const string URL = "ui://72fujxhkq91k3w";

	public static string Name = "UI_dec_01";

	public static string GetURL()
	{
		return "ui://72fujxhkq91k3w";
	}

	public static UI_dec_01 CreateInstance()
	{
		return (UI_dec_01)(object)UIPackage.CreateObject("RecruitingCamp", "dec_01");
	}

	public static UI_dec_01 CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_dec_01).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://72fujxhkq91k3w", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		((GComponent)this).ConstructFromXML(xml);
		n208 = (GImage)((GComponent)this).GetChild("n208");
		n209 = (GImage)((GComponent)this).GetChild("n209");
		n207 = (GImage)((GComponent)this).GetChild("n207");
		n206 = (GImage)((GComponent)this).GetChild("n206");
		n211 = (GImage)((GComponent)this).GetChild("n211");
		n213 = (GImage)((GComponent)this).GetChild("n213");
		n212 = (GImage)((GComponent)this).GetChild("n212");
		n220 = (GMovieClip)((GComponent)this).GetChild("n220");
		n219 = (GMovieClip)((GComponent)this).GetChild("n219");
		n210 = (GImage)((GComponent)this).GetChild("n210");
		n218 = (GMovieClip)((GComponent)this).GetChild("n218");
		n215 = (GImage)((GComponent)this).GetChild("n215");
		n216 = (GImage)((GComponent)this).GetChild("n216");
		n217 = (GImage)((GComponent)this).GetChild("n217");
		n221 = (GMovieClip)((GComponent)this).GetChild("n221");
		n222 = (GMovieClip)((GComponent)this).GetChild("n222");
		n214 = (GImage)((GComponent)this).GetChild("n214");
		n223 = (GMovieClip)((GComponent)this).GetChild("n223");
		t0 = ((GComponent)this).GetTransition("t0");
		t1 = ((GComponent)this).GetTransition("t1");
		t2 = ((GComponent)this).GetTransition("t2");
		t3 = ((GComponent)this).GetTransition("t3");
		t4 = ((GComponent)this).GetTransition("t4");
		t5 = ((GComponent)this).GetTransition("t5");
		t6 = ((GComponent)this).GetTransition("t6");
	}
}
