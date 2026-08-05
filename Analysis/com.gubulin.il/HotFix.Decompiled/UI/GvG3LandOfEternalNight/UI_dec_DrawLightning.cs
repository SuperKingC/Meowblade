using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvG3LandOfEternalNight;

public class UI_dec_DrawLightning : GComponent
{
	public GMovieClip n95;

	public Transition t0;

	public const string URL = "ui://amuqyzl8ricp20";

	public static string Name = "UI_dec_DrawLightning";

	public static string GetURL()
	{
		return "ui://amuqyzl8ricp20";
	}

	public static UI_dec_DrawLightning CreateInstance()
	{
		return (UI_dec_DrawLightning)(object)UIPackage.CreateObject("GvG3LandOfEternalNight", "dec_DrawLightning");
	}

	public static UI_dec_DrawLightning CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_dec_DrawLightning).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://amuqyzl8ricp20", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		n95 = (GMovieClip)((GComponent)this).GetChild("n95");
		t0 = ((GComponent)this).GetTransition("t0");
	}
}
