using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGFlagship3;

public class UI_dec_ship05 : GComponent
{
	public GMovieClip n85;

	public GMovieClip n86;

	public GMovieClip n87;

	public GMovieClip n88;

	public const string URL = "ui://tvr786zlojop43";

	public static string Name = "UI_dec_ship05";

	public static string GetURL()
	{
		return "ui://tvr786zlojop43";
	}

	public static UI_dec_ship05 CreateInstance()
	{
		return (UI_dec_ship05)(object)UIPackage.CreateObject("GvGFlagship3", "dec_ship05");
	}

	public static UI_dec_ship05 CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_dec_ship05).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://tvr786zlojop43", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		((GComponent)this).ConstructFromXML(xml);
		n85 = (GMovieClip)((GComponent)this).GetChild("n85");
		n86 = (GMovieClip)((GComponent)this).GetChild("n86");
		n87 = (GMovieClip)((GComponent)this).GetChild("n87");
		n88 = (GMovieClip)((GComponent)this).GetChild("n88");
	}
}
