using FairyGUI;
using FairyGUI.Utils;

namespace UI.Battle;

public class UI_UnlockAnimation : GComponent
{
	public GMovieClip main;

	public const string URL = "ui://twlbabicj93ujm";

	public static string Name = "UI_UnlockAnimation";

	public static string GetURL()
	{
		return "ui://twlbabicj93ujm";
	}

	public static UI_UnlockAnimation CreateInstance()
	{
		return (UI_UnlockAnimation)(object)UIPackage.CreateObject("Battle", "UnlockAnimation");
	}

	public static UI_UnlockAnimation CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_UnlockAnimation).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://twlbabicj93ujm", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		main = (GMovieClip)((GComponent)this).GetChild("main");
	}
}
