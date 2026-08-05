using FairyGUI;
using FairyGUI.Utils;

namespace UI.LoginAndName;

public class UI_WeChatBtn1 : GButton
{
	public Controller button;

	public GImage n8;

	public const string URL = "ui://yb3s7uv7btkn1o";

	public static string Name = "UI_WeChatBtn1";

	public static string GetURL()
	{
		return "ui://yb3s7uv7btkn1o";
	}

	public static UI_WeChatBtn1 CreateInstance()
	{
		return (UI_WeChatBtn1)(object)UIPackage.CreateObject("LoginAndName", "WeChatBtn1");
	}

	public static UI_WeChatBtn1 CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_WeChatBtn1).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://yb3s7uv7btkn1o", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		n8 = (GImage)((GComponent)this).GetChild("n8");
	}
}
