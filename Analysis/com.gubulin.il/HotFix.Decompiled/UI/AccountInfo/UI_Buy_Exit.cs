using FairyGUI;
using FairyGUI.Utils;

namespace UI.AccountInfo;

public class UI_Buy_Exit : GButton
{
	public Controller button;

	public GImage n0;

	public const string URL = "ui://b9yxt7u0gz0s2d";

	public static string Name = "UI_Buy_Exit";

	public static string GetURL()
	{
		return "ui://b9yxt7u0gz0s2d";
	}

	public static UI_Buy_Exit CreateInstance()
	{
		return (UI_Buy_Exit)(object)UIPackage.CreateObject("AccountInfo", "Buy_Exit");
	}

	public static UI_Buy_Exit CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_Buy_Exit).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://b9yxt7u0gz0s2d", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		n0 = (GImage)((GComponent)this).GetChild("n0");
	}
}
