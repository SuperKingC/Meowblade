using FairyGUI;
using FairyGUI.Utils;

namespace UI.AccountInfo;

public class UI_exitBtn : GButton
{
	public Controller button;

	public GImage frame;

	public GImage icon;

	public const string URL = "ui://b9yxt7u0f4szt";

	public static string Name = "UI_exitBtn";

	public static string GetURL()
	{
		return "ui://b9yxt7u0f4szt";
	}

	public static UI_exitBtn CreateInstance()
	{
		return (UI_exitBtn)(object)UIPackage.CreateObject("AccountInfo", "exitBtn");
	}

	public static UI_exitBtn CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_exitBtn).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://b9yxt7u0f4szt", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		frame = (GImage)((GComponent)this).GetChild("frame");
		icon = (GImage)((GComponent)this).GetChild("icon");
	}
}
