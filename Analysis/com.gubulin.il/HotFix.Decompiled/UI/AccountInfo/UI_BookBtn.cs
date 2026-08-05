using FairyGUI;
using FairyGUI.Utils;

namespace UI.AccountInfo;

public class UI_BookBtn : GButton
{
	public Controller button;

	public GImage n0;

	public GLoader icon;

	public const string URL = "ui://b9yxt7u0wgrq2z";

	public static string Name = "UI_BookBtn";

	public static string GetURL()
	{
		return "ui://b9yxt7u0wgrq2z";
	}

	public static UI_BookBtn CreateInstance()
	{
		return (UI_BookBtn)(object)UIPackage.CreateObject("AccountInfo", "BookBtn");
	}

	public static UI_BookBtn CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_BookBtn).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://b9yxt7u0wgrq2z", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		n0 = (GImage)((GComponent)this).GetChild("n0");
		icon = (GLoader)((GComponent)this).GetChild("icon");
	}
}
