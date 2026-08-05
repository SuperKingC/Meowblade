using FairyGUI;
using FairyGUI.Utils;

namespace UI.LoginAndName;

public class UI_Account : GButton
{
	public Controller button;

	public GImage n5;

	public GLoader icon;

	public const string URL = "ui://yb3s7uv7q12t1v";

	public static string Name = "UI_Account";

	public static string GetURL()
	{
		return "ui://yb3s7uv7q12t1v";
	}

	public static UI_Account CreateInstance()
	{
		return (UI_Account)(object)UIPackage.CreateObject("LoginAndName", "Account");
	}

	public static UI_Account CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_Account).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://yb3s7uv7q12t1v", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		n5 = (GImage)((GComponent)this).GetChild("n5");
		icon = (GLoader)((GComponent)this).GetChild("icon");
	}
}
