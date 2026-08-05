using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGOuterTech;

public class UI_btn_SkipAnimBtn : GButton
{
	public GImage n134;

	public GImage n1;

	public GMovieClip n135;

	public const string URL = "ui://th385mtti8uno2o";

	public static string Name = "UI_btn_SkipAnimBtn";

	public static string GetURL()
	{
		return "ui://th385mtti8uno2o";
	}

	public static UI_btn_SkipAnimBtn CreateInstance()
	{
		return (UI_btn_SkipAnimBtn)(object)UIPackage.CreateObject("GvGOuterTech", "btn_SkipAnimBtn");
	}

	public static UI_btn_SkipAnimBtn CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_btn_SkipAnimBtn).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://th385mtti8uno2o", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		((GComponent)this).ConstructFromXML(xml);
		n134 = (GImage)((GComponent)this).GetChild("n134");
		n1 = (GImage)((GComponent)this).GetChild("n1");
		n135 = (GMovieClip)((GComponent)this).GetChild("n135");
	}
}
