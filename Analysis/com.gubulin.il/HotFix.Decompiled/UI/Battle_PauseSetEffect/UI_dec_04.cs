using FairyGUI;
using FairyGUI.Utils;

namespace UI.Battle_PauseSetEffect;

public class UI_dec_04 : GComponent
{
	public GMovieClip n7;

	public Transition t0;

	public const string URL = "ui://e9jxbc7wwt9zn";

	public static string Name = "UI_dec_04";

	public static string GetURL()
	{
		return "ui://e9jxbc7wwt9zn";
	}

	public static UI_dec_04 CreateInstance()
	{
		return (UI_dec_04)(object)UIPackage.CreateObject("Battle_PauseSetEffect", "dec_04");
	}

	public static UI_dec_04 CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_dec_04).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://e9jxbc7wwt9zn", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		n7 = (GMovieClip)((GComponent)this).GetChild("n7");
		t0 = ((GComponent)this).GetTransition("t0");
	}
}
