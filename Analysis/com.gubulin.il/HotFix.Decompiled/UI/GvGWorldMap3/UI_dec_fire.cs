using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGWorldMap3;

public class UI_dec_fire : GComponent
{
	public GMovieClip n29;

	public GMovieClip n30;

	public GMovieClip n31;

	public GMovieClip n32;

	public GMovieClip n33;

	public const string URL = "ui://4eq8fgd2g2oqsb4";

	public static string Name = "UI_dec_fire";

	public static string GetURL()
	{
		return "ui://4eq8fgd2g2oqsb4";
	}

	public static UI_dec_fire CreateInstance()
	{
		return (UI_dec_fire)(object)UIPackage.CreateObject("GvGWorldMap3", "dec_fire");
	}

	public static UI_dec_fire CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_dec_fire).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://4eq8fgd2g2oqsb4", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		n29 = (GMovieClip)((GComponent)this).GetChild("n29");
		n30 = (GMovieClip)((GComponent)this).GetChild("n30");
		n31 = (GMovieClip)((GComponent)this).GetChild("n31");
		n32 = (GMovieClip)((GComponent)this).GetChild("n32");
		n33 = (GMovieClip)((GComponent)this).GetChild("n33");
	}
}
