using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGFlagship3;

public class UI_dec_ship01 : GComponent
{
	public GMovieClip n60;

	public GMovieClip n64;

	public const string URL = "ui://tvr786zlojop3x";

	public static string Name = "UI_dec_ship01";

	public static string GetURL()
	{
		return "ui://tvr786zlojop3x";
	}

	public static UI_dec_ship01 CreateInstance()
	{
		return (UI_dec_ship01)(object)UIPackage.CreateObject("GvGFlagship3", "dec_ship01");
	}

	public static UI_dec_ship01 CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_dec_ship01).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://tvr786zlojop3x", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		n60 = (GMovieClip)((GComponent)this).GetChild("n60");
		n64 = (GMovieClip)((GComponent)this).GetChild("n64");
	}
}
