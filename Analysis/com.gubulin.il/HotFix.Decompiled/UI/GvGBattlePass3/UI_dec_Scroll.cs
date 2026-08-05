using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGBattlePass3;

public class UI_dec_Scroll : GComponent
{
	public Controller State;

	public GImage n144;

	public UI_com_BasicFlag n152;

	public UI_com_AdvancedFlag n154;

	public GMovieClip n149;

	public GMovieClip n150;

	public GMovieClip n151;

	public GMovieClip n155;

	public const string URL = "ui://bfjg32hufgvp5a";

	public static string Name = "UI_dec_Scroll";

	public static string GetURL()
	{
		return "ui://bfjg32hufgvp5a";
	}

	public static UI_dec_Scroll CreateInstance()
	{
		return (UI_dec_Scroll)(object)UIPackage.CreateObject("GvGBattlePass3", "dec_Scroll");
	}

	public static UI_dec_Scroll CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_dec_Scroll).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://bfjg32hufgvp5a", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_0072: Expected O, but got Unknown
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0088: Expected O, but got Unknown
		//IL_0094: Unknown result type (might be due to invalid IL or missing references)
		//IL_009e: Expected O, but got Unknown
		//IL_00aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b4: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		State = ((GComponent)this).GetController("State");
		n144 = (GImage)((GComponent)this).GetChild("n144");
		n152 = (UI_com_BasicFlag)(object)((GComponent)this).GetChild("n152");
		n154 = (UI_com_AdvancedFlag)(object)((GComponent)this).GetChild("n154");
		n149 = (GMovieClip)((GComponent)this).GetChild("n149");
		n150 = (GMovieClip)((GComponent)this).GetChild("n150");
		n151 = (GMovieClip)((GComponent)this).GetChild("n151");
		n155 = (GMovieClip)((GComponent)this).GetChild("n155");
	}
}
