using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGFlagship3;

public class UI_dec_ship04 : GComponent
{
	public GMovieClip n77;

	public GMovieClip n78;

	public GMovieClip n79;

	public GMovieClip n80;

	public GMovieClip n81;

	public GMovieClip n82;

	public GMovieClip n83;

	public GMovieClip n84;

	public const string URL = "ui://tvr786zlojop42";

	public static string Name = "UI_dec_ship04";

	public static string GetURL()
	{
		return "ui://tvr786zlojop42";
	}

	public static UI_dec_ship04 CreateInstance()
	{
		return (UI_dec_ship04)(object)UIPackage.CreateObject("GvGFlagship3", "dec_ship04");
	}

	public static UI_dec_ship04 CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_dec_ship04).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://tvr786zlojop42", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_0083: Unknown result type (might be due to invalid IL or missing references)
		//IL_008d: Expected O, but got Unknown
		//IL_0099: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a3: Expected O, but got Unknown
		//IL_00af: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b9: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		n77 = (GMovieClip)((GComponent)this).GetChild("n77");
		n78 = (GMovieClip)((GComponent)this).GetChild("n78");
		n79 = (GMovieClip)((GComponent)this).GetChild("n79");
		n80 = (GMovieClip)((GComponent)this).GetChild("n80");
		n81 = (GMovieClip)((GComponent)this).GetChild("n81");
		n82 = (GMovieClip)((GComponent)this).GetChild("n82");
		n83 = (GMovieClip)((GComponent)this).GetChild("n83");
		n84 = (GMovieClip)((GComponent)this).GetChild("n84");
	}
}
