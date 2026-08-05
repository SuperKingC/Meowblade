using FairyGUI;
using FairyGUI.Utils;

namespace UI.WeekActivityPass;

public class UI_dec_Scroll : GComponent
{
	public UI_com_WeekFlag n152;

	public UI_com_WeekFlag n154;

	public UI_com_WeekFlag n156;

	public GMovieClip n149;

	public GMovieClip n151;

	public GMovieClip n155;

	public GMovieClip n157;

	public const string URL = "ui://11dkggb8nk8f2m";

	public static string Name = "UI_dec_Scroll";

	public static string GetURL()
	{
		return "ui://11dkggb8nk8f2m";
	}

	public static UI_dec_Scroll CreateInstance()
	{
		return (UI_dec_Scroll)(object)UIPackage.CreateObject("WeekActivityPass", "dec_Scroll");
	}

	public static UI_dec_Scroll CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_dec_Scroll).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://11dkggb8nk8f2m", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		//IL_0061: Expected O, but got Unknown
		//IL_006d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0077: Expected O, but got Unknown
		//IL_0083: Unknown result type (might be due to invalid IL or missing references)
		//IL_008d: Expected O, but got Unknown
		//IL_0099: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a3: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		n152 = (UI_com_WeekFlag)(object)((GComponent)this).GetChild("n152");
		n154 = (UI_com_WeekFlag)(object)((GComponent)this).GetChild("n154");
		n156 = (UI_com_WeekFlag)(object)((GComponent)this).GetChild("n156");
		n149 = (GMovieClip)((GComponent)this).GetChild("n149");
		n151 = (GMovieClip)((GComponent)this).GetChild("n151");
		n155 = (GMovieClip)((GComponent)this).GetChild("n155");
		n157 = (GMovieClip)((GComponent)this).GetChild("n157");
	}
}
