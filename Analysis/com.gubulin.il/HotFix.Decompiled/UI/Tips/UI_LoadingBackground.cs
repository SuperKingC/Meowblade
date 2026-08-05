using FairyGUI;
using FairyGUI.Utils;

namespace UI.Tips;

public class UI_LoadingBackground : GComponent
{
	public GLoader background;

	public const string URL = "ui://47lbpgx9gp9d1e";

	public static string Name = "UI_LoadingBackground";

	public static string GetURL()
	{
		return "ui://47lbpgx9gp9d1e";
	}

	public static UI_LoadingBackground CreateInstance()
	{
		return (UI_LoadingBackground)(object)UIPackage.CreateObject("Tips", "LoadingBackground");
	}

	public static UI_LoadingBackground CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_LoadingBackground).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://47lbpgx9gp9d1e", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		background = (GLoader)((GComponent)this).GetChild("background");
	}
}
