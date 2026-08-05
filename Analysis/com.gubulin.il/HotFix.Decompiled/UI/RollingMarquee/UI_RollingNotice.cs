using FairyGUI;
using FairyGUI.Utils;

namespace UI.RollingMarquee;

public class UI_RollingNotice : GComponent
{
	public const string URL = "ui://ccmc9e4k8u4a0";

	public static string Name = "UI_RollingNotice";

	public static string GetURL()
	{
		return "ui://ccmc9e4k8u4a0";
	}

	public static UI_RollingNotice CreateInstance()
	{
		return (UI_RollingNotice)(object)UIPackage.CreateObject("RollingMarquee", "RollingNotice");
	}

	public static UI_RollingNotice CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_RollingNotice).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://ccmc9e4k8u4a0", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		((GComponent)this).ConstructFromXML(xml);
	}
}
