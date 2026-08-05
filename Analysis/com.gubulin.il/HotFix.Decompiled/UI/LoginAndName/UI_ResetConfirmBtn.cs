using FairyGUI;
using FairyGUI.Utils;

namespace UI.LoginAndName;

public class UI_ResetConfirmBtn : GButton
{
	public Controller button;

	public GImage n3;

	public GImage n4;

	public const string URL = "ui://yb3s7uv7xhx93i";

	public static string Name = "UI_ResetConfirmBtn";

	public static string GetURL()
	{
		return "ui://yb3s7uv7xhx93i";
	}

	public static UI_ResetConfirmBtn CreateInstance()
	{
		return (UI_ResetConfirmBtn)(object)UIPackage.CreateObject("LoginAndName", "ResetConfirmBtn");
	}

	public static UI_ResetConfirmBtn CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_ResetConfirmBtn).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://yb3s7uv7xhx93i", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		n3 = (GImage)((GComponent)this).GetChild("n3");
		n4 = (GImage)((GComponent)this).GetChild("n4");
	}
}
