using FairyGUI;
using FairyGUI.Utils;

namespace UI.LoginAndName;

public class UI_resetBtn : GButton
{
	public Controller button;

	public GImage back;

	public GLoader icon;

	public const string URL = "ui://yb3s7uv7p8ap2l";

	public static string Name = "UI_resetBtn";

	public static string GetURL()
	{
		return "ui://yb3s7uv7p8ap2l";
	}

	public static UI_resetBtn CreateInstance()
	{
		return (UI_resetBtn)(object)UIPackage.CreateObject("LoginAndName", "resetBtn");
	}

	public static UI_resetBtn CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_resetBtn).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://yb3s7uv7p8ap2l", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		back = (GImage)((GComponent)this).GetChild("back");
		icon = (GLoader)((GComponent)this).GetChild("icon");
	}
}
