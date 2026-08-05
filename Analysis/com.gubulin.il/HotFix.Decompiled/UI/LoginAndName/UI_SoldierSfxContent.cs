using FairyGUI;
using FairyGUI.Utils;

namespace UI.LoginAndName;

public class UI_SoldierSfxContent : GComponent
{
	public const string URL = "ui://yb3s7uv7q12t1y";

	public static string Name = "UI_SoldierSfxContent";

	public static string GetURL()
	{
		return "ui://yb3s7uv7q12t1y";
	}

	public static UI_SoldierSfxContent CreateInstance()
	{
		return (UI_SoldierSfxContent)(object)UIPackage.CreateObject("LoginAndName", "SoldierSfxContent");
	}

	public static UI_SoldierSfxContent CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_SoldierSfxContent).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://yb3s7uv7q12t1y", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		((GComponent)this).ConstructFromXML(xml);
	}
}
