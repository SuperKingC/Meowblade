using FairyGUI;
using FairyGUI.Utils;

namespace UI.LoginAndName;

public class UI_IosBtn : GButton
{
	public Controller button;

	public GImage n7;

	public const string URL = "ui://yb3s7uv7btkn1l";

	public static string Name = "UI_IosBtn";

	public static string GetURL()
	{
		return "ui://yb3s7uv7btkn1l";
	}

	public static UI_IosBtn CreateInstance()
	{
		return (UI_IosBtn)(object)UIPackage.CreateObject("LoginAndName", "IosBtn");
	}

	public static UI_IosBtn CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_IosBtn).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://yb3s7uv7btkn1l", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		n7 = (GImage)((GComponent)this).GetChild("n7");
	}
}
