using FairyGUI;
using FairyGUI.Utils;

namespace UI.LoginAndName;

public class UI_LogoIcon : GComponent
{
	public GImage n0;

	public const string URL = "ui://yb3s7uv7ka6x45";

	public static string Name = "UI_LogoIcon";

	public static string GetURL()
	{
		return "ui://yb3s7uv7ka6x45";
	}

	public static UI_LogoIcon CreateInstance()
	{
		return (UI_LogoIcon)(object)UIPackage.CreateObject("LoginAndName", "LogoIcon");
	}

	public static UI_LogoIcon CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_LogoIcon).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://yb3s7uv7ka6x45", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		n0 = (GImage)((GComponent)this).GetChild("n0");
	}
}
