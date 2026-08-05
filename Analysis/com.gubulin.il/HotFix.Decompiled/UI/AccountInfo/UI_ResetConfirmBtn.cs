using FairyGUI;
using FairyGUI.Utils;

namespace UI.AccountInfo;

public class UI_ResetConfirmBtn : GButton
{
	public Controller button;

	public GImage n3;

	public GImage n4;

	public const string URL = "ui://b9yxt7u0k38944";

	public static string Name = "UI_ResetConfirmBtn";

	public static string GetURL()
	{
		return "ui://b9yxt7u0k38944";
	}

	public static UI_ResetConfirmBtn CreateInstance()
	{
		return (UI_ResetConfirmBtn)(object)UIPackage.CreateObject("AccountInfo", "ResetConfirmBtn");
	}

	public static UI_ResetConfirmBtn CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_ResetConfirmBtn).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://b9yxt7u0k38944", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
