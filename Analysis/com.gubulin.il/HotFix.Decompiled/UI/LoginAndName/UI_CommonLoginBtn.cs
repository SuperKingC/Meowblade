using FairyGUI;
using FairyGUI.Utils;

namespace UI.LoginAndName;

public class UI_CommonLoginBtn : GButton
{
	public Controller button;

	public GLoader BtnLoader;

	public const string URL = "ui://yb3s7uv7fa274g";

	public static string Name = "UI_CommonLoginBtn";

	public static string GetURL()
	{
		return "ui://yb3s7uv7fa274g";
	}

	public static UI_CommonLoginBtn CreateInstance()
	{
		return (UI_CommonLoginBtn)(object)UIPackage.CreateObject("LoginAndName", "CommonLoginBtn");
	}

	public static UI_CommonLoginBtn CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_CommonLoginBtn).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://yb3s7uv7fa274g", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		BtnLoader = (GLoader)((GComponent)this).GetChild("BtnLoader");
	}
}
