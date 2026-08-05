using FairyGUI;
using FairyGUI.Utils;

namespace UI.AccountInfo;

public class UI_DeleteUserDataBtn : GButton
{
	public Controller button;

	public GImage n3;

	public const string URL = "ui://b9yxt7u0k3894g";

	public static string Name = "UI_DeleteUserDataBtn";

	public static string GetURL()
	{
		return "ui://b9yxt7u0k3894g";
	}

	public static UI_DeleteUserDataBtn CreateInstance()
	{
		return (UI_DeleteUserDataBtn)(object)UIPackage.CreateObject("AccountInfo", "DeleteUserDataBtn");
	}

	public static UI_DeleteUserDataBtn CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_DeleteUserDataBtn).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://b9yxt7u0k3894g", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		n3 = (GImage)((GComponent)this).GetChild("n3");
	}
}
