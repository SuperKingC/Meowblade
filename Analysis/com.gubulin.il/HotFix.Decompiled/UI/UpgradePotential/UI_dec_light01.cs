using FairyGUI;
using FairyGUI.Utils;

namespace UI.UpgradePotential;

public class UI_dec_light01 : GComponent
{
	public GImage n87;

	public GImage n86;

	public GMovieClip n88;

	public GMovieClip n89;

	public GMovieClip n90;

	public Transition t0;

	public const string URL = "ui://l5ik1uclpanqta4";

	public static string Name = "UI_dec_light01";

	public static string GetURL()
	{
		return "ui://l5ik1uclpanqta4";
	}

	public static UI_dec_light01 CreateInstance()
	{
		return (UI_dec_light01)(object)UIPackage.CreateObject("UpgradePotential", "dec_light01");
	}

	public static UI_dec_light01 CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_dec_light01).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://l5ik1uclpanqta4", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		n87 = (GImage)((GComponent)this).GetChild("n87");
		n86 = (GImage)((GComponent)this).GetChild("n86");
		n88 = (GMovieClip)((GComponent)this).GetChild("n88");
		n89 = (GMovieClip)((GComponent)this).GetChild("n89");
		n90 = (GMovieClip)((GComponent)this).GetChild("n90");
		t0 = ((GComponent)this).GetTransition("t0");
	}
}
