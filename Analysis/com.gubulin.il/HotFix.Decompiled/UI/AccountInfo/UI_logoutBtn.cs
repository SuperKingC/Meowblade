using FairyGUI;
using FairyGUI.Utils;

namespace UI.AccountInfo;

public class UI_logoutBtn : GButton
{
	public Controller button;

	public Controller isDefault;

	public GGraph n4;

	public GImage n5;

	public GImage n7;

	public GImage n8;

	public GImage n9;

	public const string URL = "ui://b9yxt7u0p8ap1k";

	public static string Name = "UI_logoutBtn";

	public static string GetURL()
	{
		return "ui://b9yxt7u0p8ap1k";
	}

	public static UI_logoutBtn CreateInstance()
	{
		return (UI_logoutBtn)(object)UIPackage.CreateObject("AccountInfo", "logoutBtn");
	}

	public static UI_logoutBtn CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_logoutBtn).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://b9yxt7u0p8ap1k", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Expected O, but got Unknown
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Expected O, but got Unknown
		//IL_0063: Unknown result type (might be due to invalid IL or missing references)
		//IL_006d: Expected O, but got Unknown
		//IL_0079: Unknown result type (might be due to invalid IL or missing references)
		//IL_0083: Expected O, but got Unknown
		//IL_008f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0099: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		isDefault = ((GComponent)this).GetController("isDefault");
		n4 = (GGraph)((GComponent)this).GetChild("n4");
		n5 = (GImage)((GComponent)this).GetChild("n5");
		n7 = (GImage)((GComponent)this).GetChild("n7");
		n8 = (GImage)((GComponent)this).GetChild("n8");
		n9 = (GImage)((GComponent)this).GetChild("n9");
	}
}
