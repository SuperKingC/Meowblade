using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGFlagship3;

public class UI_dec_portal01 : GComponent
{
	public GImage n4;

	public GImage n2;

	public UI_dec_portalbg01 n1;

	public GImage n0;

	public GMovieClip n5;

	public Transition t0;

	public const string URL = "ui://tvr786zls54852";

	public static string Name = "UI_dec_portal01";

	public static string GetURL()
	{
		return "ui://tvr786zls54852";
	}

	public static UI_dec_portal01 CreateInstance()
	{
		return (UI_dec_portal01)(object)UIPackage.CreateObject("GvGFlagship3", "dec_portal01");
	}

	public static UI_dec_portal01 CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_dec_portal01).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://tvr786zls54852", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		//IL_0061: Expected O, but got Unknown
		//IL_006d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0077: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		n4 = (GImage)((GComponent)this).GetChild("n4");
		n2 = (GImage)((GComponent)this).GetChild("n2");
		n1 = (UI_dec_portalbg01)(object)((GComponent)this).GetChild("n1");
		n0 = (GImage)((GComponent)this).GetChild("n0");
		n5 = (GMovieClip)((GComponent)this).GetChild("n5");
		t0 = ((GComponent)this).GetTransition("t0");
	}
}
