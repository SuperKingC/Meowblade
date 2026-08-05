using FairyGUI;
using FairyGUI.Utils;

namespace UI.LoginAndName;

public class UI_userNameBtn : GButton
{
	public Controller button;

	public GTextField name;

	public const string URL = "ui://yb3s7uv7bw1c25";

	public static string Name = "UI_userNameBtn";

	public static string GetURL()
	{
		return "ui://yb3s7uv7bw1c25";
	}

	public static UI_userNameBtn CreateInstance()
	{
		return (UI_userNameBtn)(object)UIPackage.CreateObject("LoginAndName", "userNameBtn");
	}

	public static UI_userNameBtn CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_userNameBtn).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://yb3s7uv7bw1c25", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		name = (GTextField)((GComponent)this).GetChild("name");
	}
}
