using FairyGUI;
using FairyGUI.Utils;

namespace UI.LoginAndName;

public class UI_GoogleBtn : GButton
{
	public Controller button;

	public GImage n0;

	public const string URL = "ui://yb3s7uv7jqcl4c";

	public static string Name = "UI_GoogleBtn";

	public static string GetURL()
	{
		return "ui://yb3s7uv7jqcl4c";
	}

	public static UI_GoogleBtn CreateInstance()
	{
		return (UI_GoogleBtn)(object)UIPackage.CreateObject("LoginAndName", "GoogleBtn");
	}

	public static UI_GoogleBtn CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_GoogleBtn).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://yb3s7uv7jqcl4c", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		n0 = (GImage)((GComponent)this).GetChild("n0");
	}
}
