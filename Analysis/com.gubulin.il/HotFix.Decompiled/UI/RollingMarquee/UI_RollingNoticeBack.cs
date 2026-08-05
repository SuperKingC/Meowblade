using FairyGUI;
using FairyGUI.Utils;

namespace UI.RollingMarquee;

public class UI_RollingNoticeBack : GComponent
{
	public GGraph back;

	public UI_RollingNotice RollingNotice;

	public const string URL = "ui://ccmc9e4kcpij3";

	public static string Name = "UI_RollingNoticeBack";

	public static string GetURL()
	{
		return "ui://ccmc9e4kcpij3";
	}

	public static UI_RollingNoticeBack CreateInstance()
	{
		return (UI_RollingNoticeBack)(object)UIPackage.CreateObject("RollingMarquee", "RollingNoticeBack");
	}

	public static UI_RollingNoticeBack CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_RollingNoticeBack).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://ccmc9e4kcpij3", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		back = (GGraph)((GComponent)this).GetChild("back");
		RollingNotice = (UI_RollingNotice)(object)((GComponent)this).GetChild("RollingNotice");
	}
}
