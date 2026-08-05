using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGRandomEvent3;

public class UI_dec_ScrollBg : GComponent
{
	public GImage n4;

	public UI_dec_Light02 n13;

	public GImage n7;

	public GImage n5;

	public GImage n6;

	public GImage n8;

	public GImage n9;

	public UI_dec_Light01 n10;

	public Transition t0;

	public const string URL = "ui://p4ocf6q0li8t13";

	public static string Name = "UI_dec_ScrollBg";

	public static string GetURL()
	{
		return "ui://p4ocf6q0li8t13";
	}

	public static UI_dec_ScrollBg CreateInstance()
	{
		return (UI_dec_ScrollBg)(object)UIPackage.CreateObject("GvGRandomEvent3", "dec_ScrollBg");
	}

	public static UI_dec_ScrollBg CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_dec_ScrollBg).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://p4ocf6q0li8t13", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
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
		n4 = (GImage)((GComponent)this).GetChild("n4");
		n13 = (UI_dec_Light02)(object)((GComponent)this).GetChild("n13");
		n7 = (GImage)((GComponent)this).GetChild("n7");
		n5 = (GImage)((GComponent)this).GetChild("n5");
		n6 = (GImage)((GComponent)this).GetChild("n6");
		n8 = (GImage)((GComponent)this).GetChild("n8");
		n9 = (GImage)((GComponent)this).GetChild("n9");
		n10 = (UI_dec_Light01)(object)((GComponent)this).GetChild("n10");
		t0 = ((GComponent)this).GetTransition("t0");
	}
}
