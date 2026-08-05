using FairyGUI;
using FairyGUI.Utils;

namespace UI.AccountInfo;

public class UI_cancelAccountBtn : GButton
{
	public GImage n3;

	public const string URL = "ui://b9yxt7u0pcsj6o";

	public static string Name = "UI_cancelAccountBtn";

	public static string GetURL()
	{
		return "ui://b9yxt7u0pcsj6o";
	}

	public static UI_cancelAccountBtn CreateInstance()
	{
		return (UI_cancelAccountBtn)(object)UIPackage.CreateObject("AccountInfo", "cancelAccountBtn");
	}

	public static UI_cancelAccountBtn CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_cancelAccountBtn).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://b9yxt7u0pcsj6o", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		n3 = (GImage)((GComponent)this).GetChild("n3");
	}
}
