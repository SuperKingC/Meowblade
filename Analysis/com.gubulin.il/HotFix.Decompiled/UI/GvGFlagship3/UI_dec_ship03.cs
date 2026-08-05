using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGFlagship3;

public class UI_dec_ship03 : GComponent
{
	public GMovieClip n66;

	public GMovieClip n67;

	public GMovieClip n68;

	public GMovieClip n69;

	public GMovieClip n70;

	public GMovieClip n71;

	public GMovieClip n72;

	public GMovieClip n73;

	public GMovieClip n74;

	public GMovieClip n75;

	public GMovieClip n76;

	public const string URL = "ui://tvr786zlojop41";

	public static string Name = "UI_dec_ship03";

	public static string GetURL()
	{
		return "ui://tvr786zlojop41";
	}

	public static UI_dec_ship03 CreateInstance()
	{
		return (UI_dec_ship03)(object)UIPackage.CreateObject("GvGFlagship3", "dec_ship03");
	}

	public static UI_dec_ship03 CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_dec_ship03).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://tvr786zlojop41", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_00c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cf: Expected O, but got Unknown
		//IL_00db: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e5: Expected O, but got Unknown
		//IL_00f1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fb: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		n66 = (GMovieClip)((GComponent)this).GetChild("n66");
		n67 = (GMovieClip)((GComponent)this).GetChild("n67");
		n68 = (GMovieClip)((GComponent)this).GetChild("n68");
		n69 = (GMovieClip)((GComponent)this).GetChild("n69");
		n70 = (GMovieClip)((GComponent)this).GetChild("n70");
		n71 = (GMovieClip)((GComponent)this).GetChild("n71");
		n72 = (GMovieClip)((GComponent)this).GetChild("n72");
		n73 = (GMovieClip)((GComponent)this).GetChild("n73");
		n74 = (GMovieClip)((GComponent)this).GetChild("n74");
		n75 = (GMovieClip)((GComponent)this).GetChild("n75");
		n76 = (GMovieClip)((GComponent)this).GetChild("n76");
	}
}
