using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGFlagship3;

public class UI_dec_portal02 : GComponent
{
	public GImage n4;

	public GMovieClip n7;

	public GImage n2;

	public UI_dec_portalbg02 n1;

	public GImage n6;

	public GImage n0;

	public GMovieClip n5;

	public Transition t0;

	public const string URL = "ui://tvr786zls54856";

	public static string Name = "UI_dec_portal02";

	public static string GetURL()
	{
		return "ui://tvr786zls54856";
	}

	public static UI_dec_portal02 CreateInstance()
	{
		return (UI_dec_portal02)(object)UIPackage.CreateObject("GvGFlagship3", "dec_portal02");
	}

	public static UI_dec_portal02 CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_dec_portal02).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://tvr786zls54856", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_006d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0077: Expected O, but got Unknown
		//IL_0083: Unknown result type (might be due to invalid IL or missing references)
		//IL_008d: Expected O, but got Unknown
		//IL_0099: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a3: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		n4 = (GImage)((GComponent)this).GetChild("n4");
		n7 = (GMovieClip)((GComponent)this).GetChild("n7");
		n2 = (GImage)((GComponent)this).GetChild("n2");
		n1 = (UI_dec_portalbg02)(object)((GComponent)this).GetChild("n1");
		n6 = (GImage)((GComponent)this).GetChild("n6");
		n0 = (GImage)((GComponent)this).GetChild("n0");
		n5 = (GMovieClip)((GComponent)this).GetChild("n5");
		t0 = ((GComponent)this).GetTransition("t0");
	}
}
