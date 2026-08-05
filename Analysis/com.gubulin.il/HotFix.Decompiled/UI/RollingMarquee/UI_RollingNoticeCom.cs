using FairyGUI;
using FairyGUI.Utils;

namespace UI.RollingMarquee;

public class UI_RollingNoticeCom : GComponent
{
	public GTextField notice;

	public const string URL = "ui://ccmc9e4k8u4a1";

	public static string Name = "UI_RollingNoticeCom";

	public static string GetURL()
	{
		return "ui://ccmc9e4k8u4a1";
	}

	public static UI_RollingNoticeCom CreateInstance()
	{
		return (UI_RollingNoticeCom)(object)UIPackage.CreateObject("RollingMarquee", "RollingNoticeCom");
	}

	public static UI_RollingNoticeCom CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_RollingNoticeCom).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://ccmc9e4k8u4a1", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		notice = (GTextField)((GComponent)this).GetChild("notice");
	}
}
