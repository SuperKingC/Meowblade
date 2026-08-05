using FairyGUI;
using FairyGUI.Utils;

namespace UI.AccountInfo;

public class UI_modifyBtn : GButton
{
	public Controller button;

	public Controller isDefault;

	public GImage n9;

	public GImage n10;

	public const string URL = "ui://b9yxt7u0t1jra";

	public static string Name = "UI_modifyBtn";

	public static string GetURL()
	{
		return "ui://b9yxt7u0t1jra";
	}

	public static UI_modifyBtn CreateInstance()
	{
		return (UI_modifyBtn)(object)UIPackage.CreateObject("AccountInfo", "modifyBtn");
	}

	public static UI_modifyBtn CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_modifyBtn).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://b9yxt7u0t1jra", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Expected O, but got Unknown
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		isDefault = ((GComponent)this).GetController("isDefault");
		n9 = (GImage)((GComponent)this).GetChild("n9");
		n10 = (GImage)((GComponent)this).GetChild("n10");
	}
}
