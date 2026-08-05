using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGFlagship3;

public class UI_dec_ship02 : GComponent
{
	public GMovieClip n56;

	public GMovieClip n57;

	public GMovieClip n59;

	public GMovieClip n63;

	public GMovieClip n65;

	public const string URL = "ui://tvr786zlojop3y";

	public static string Name = "UI_dec_ship02";

	public static string GetURL()
	{
		return "ui://tvr786zlojop3y";
	}

	public static UI_dec_ship02 CreateInstance()
	{
		return (UI_dec_ship02)(object)UIPackage.CreateObject("GvGFlagship3", "dec_ship02");
	}

	public static UI_dec_ship02 CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_dec_ship02).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://tvr786zlojop3y", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		n56 = (GMovieClip)((GComponent)this).GetChild("n56");
		n57 = (GMovieClip)((GComponent)this).GetChild("n57");
		n59 = (GMovieClip)((GComponent)this).GetChild("n59");
		n63 = (GMovieClip)((GComponent)this).GetChild("n63");
		n65 = (GMovieClip)((GComponent)this).GetChild("n65");
	}
}
