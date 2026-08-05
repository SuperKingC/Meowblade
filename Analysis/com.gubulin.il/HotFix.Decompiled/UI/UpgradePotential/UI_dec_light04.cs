using FairyGUI;
using FairyGUI.Utils;

namespace UI.UpgradePotential;

public class UI_dec_light04 : GComponent
{
	public GMovieClip n94;

	public GMovieClip n95;

	public const string URL = "ui://l5ik1uclpanqtax";

	public static string Name = "UI_dec_light04";

	public static string GetURL()
	{
		return "ui://l5ik1uclpanqtax";
	}

	public static UI_dec_light04 CreateInstance()
	{
		return (UI_dec_light04)(object)UIPackage.CreateObject("UpgradePotential", "dec_light04");
	}

	public static UI_dec_light04 CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_dec_light04).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://l5ik1uclpanqtax", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		n94 = (GMovieClip)((GComponent)this).GetChild("n94");
		n95 = (GMovieClip)((GComponent)this).GetChild("n95");
	}
}
