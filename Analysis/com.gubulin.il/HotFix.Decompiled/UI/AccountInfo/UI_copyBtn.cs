using FairyGUI;
using FairyGUI.Utils;

namespace UI.AccountInfo;

public class UI_copyBtn : GButton
{
	public Controller button;

	public Controller isDefault;

	public GImage n8;

	public GImage n9;

	public const string URL = "ui://b9yxt7u0t1jr5";

	public static string Name = "UI_copyBtn";

	public static string GetURL()
	{
		return "ui://b9yxt7u0t1jr5";
	}

	public static UI_copyBtn CreateInstance()
	{
		return (UI_copyBtn)(object)UIPackage.CreateObject("AccountInfo", "copyBtn");
	}

	public static UI_copyBtn CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_copyBtn).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://b9yxt7u0t1jr5", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		n8 = (GImage)((GComponent)this).GetChild("n8");
		n9 = (GImage)((GComponent)this).GetChild("n9");
	}
}
