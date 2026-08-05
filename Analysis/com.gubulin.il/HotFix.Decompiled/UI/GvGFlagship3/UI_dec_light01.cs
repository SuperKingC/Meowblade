using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGFlagship3;

public class UI_dec_light01 : GComponent
{
	public GImage n21;

	public GMovieClip n24;

	public GMovieClip n25;

	public GMovieClip n22;

	public GMovieClip n23;

	public Transition t0;

	public const string URL = "ui://tvr786zljb4i3b";

	public static string Name = "UI_dec_light01";

	public static string GetURL()
	{
		return "ui://tvr786zljb4i3b";
	}

	public static UI_dec_light01 CreateInstance()
	{
		return (UI_dec_light01)(object)UIPackage.CreateObject("GvGFlagship3", "dec_light01");
	}

	public static UI_dec_light01 CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_dec_light01).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://tvr786zljb4i3b", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		((GComponent)this).ConstructFromXML(xml);
		n21 = (GImage)((GComponent)this).GetChild("n21");
		n24 = (GMovieClip)((GComponent)this).GetChild("n24");
		n25 = (GMovieClip)((GComponent)this).GetChild("n25");
		n22 = (GMovieClip)((GComponent)this).GetChild("n22");
		n23 = (GMovieClip)((GComponent)this).GetChild("n23");
		t0 = ((GComponent)this).GetTransition("t0");
	}
}
