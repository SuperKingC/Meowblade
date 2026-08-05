using FairyGUI;
using FairyGUI.Utils;

namespace UI.LoginAndName;

public class UI_TapTapBtn : GButton
{
	public Controller button;

	public GImage n9;

	public const string URL = "ui://yb3s7uv7ndu53n";

	public static string Name = "UI_TapTapBtn";

	public static string GetURL()
	{
		return "ui://yb3s7uv7ndu53n";
	}

	public static UI_TapTapBtn CreateInstance()
	{
		return (UI_TapTapBtn)(object)UIPackage.CreateObject("LoginAndName", "TapTapBtn");
	}

	public static UI_TapTapBtn CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_TapTapBtn).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://yb3s7uv7ndu53n", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		n9 = (GImage)((GComponent)this).GetChild("n9");
	}
}
