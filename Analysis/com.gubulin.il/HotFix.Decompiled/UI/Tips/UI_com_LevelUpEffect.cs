using FairyGUI;
using FairyGUI.Utils;

namespace UI.Tips;

public class UI_com_LevelUpEffect : GComponent
{
	public GImage n14;

	public GMovieClip n15;

	public GMovieClip n17;

	public GMovieClip n19;

	public GGroup n31;

	public Transition t0;

	public const string URL = "ui://47lbpgx9kpc5j5ltdz";

	public static string Name = "UI_com_LevelUpEffect";

	public static string GetURL()
	{
		return "ui://47lbpgx9kpc5j5ltdz";
	}

	public static UI_com_LevelUpEffect CreateInstance()
	{
		return (UI_com_LevelUpEffect)(object)UIPackage.CreateObject("Tips", "com_LevelUpEffect");
	}

	public static UI_com_LevelUpEffect CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_LevelUpEffect).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://47lbpgx9kpc5j5ltdz", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		n14 = (GImage)((GComponent)this).GetChild("n14");
		n15 = (GMovieClip)((GComponent)this).GetChild("n15");
		n17 = (GMovieClip)((GComponent)this).GetChild("n17");
		n19 = (GMovieClip)((GComponent)this).GetChild("n19");
		n31 = (GGroup)((GComponent)this).GetChild("n31");
		t0 = ((GComponent)this).GetTransition("t0");
	}
}
