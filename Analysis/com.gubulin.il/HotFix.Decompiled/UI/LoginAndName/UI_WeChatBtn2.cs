using FairyGUI;
using FairyGUI.Utils;

namespace UI.LoginAndName;

public class UI_WeChatBtn2 : GButton
{
	public Controller button;

	public GImage n10;

	public const string URL = "ui://yb3s7uv7x2iy1p";

	public static string Name = "UI_WeChatBtn2";

	public static string GetURL()
	{
		return "ui://yb3s7uv7x2iy1p";
	}

	public static UI_WeChatBtn2 CreateInstance()
	{
		return (UI_WeChatBtn2)(object)UIPackage.CreateObject("LoginAndName", "WeChatBtn2");
	}

	public static UI_WeChatBtn2 CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_WeChatBtn2).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://yb3s7uv7x2iy1p", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		n10 = (GImage)((GComponent)this).GetChild("n10");
	}
}
