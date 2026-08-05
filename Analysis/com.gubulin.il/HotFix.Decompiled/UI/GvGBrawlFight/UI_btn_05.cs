using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGBrawlFight;

public class UI_btn_05 : GButton
{
	public const string URL = "ui://hozu168riwm75h";

	public static string Name = "UI_btn_05";

	public static string GetURL()
	{
		return "ui://hozu168riwm75h";
	}

	public static UI_btn_05 CreateInstance()
	{
		return (UI_btn_05)(object)UIPackage.CreateObject("GvGBrawlFight", "btn_05");
	}

	public static UI_btn_05 CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_btn_05).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://hozu168riwm75h", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		((GComponent)this).ConstructFromXML(xml);
	}
}
