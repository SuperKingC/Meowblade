using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGShipOverview;

public class UI_ChangeNameBtn : GButton
{
	public GImage n88;

	public const string URL = "ui://7ymaonxtaa6p2c";

	public static string Name = "UI_ChangeNameBtn";

	public static string GetURL()
	{
		return "ui://7ymaonxtaa6p2c";
	}

	public static UI_ChangeNameBtn CreateInstance()
	{
		return (UI_ChangeNameBtn)(object)UIPackage.CreateObject("GvGShipOverview", "ChangeNameBtn");
	}

	public static UI_ChangeNameBtn CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_ChangeNameBtn).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://7ymaonxtaa6p2c", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		n88 = (GImage)((GComponent)this).GetChild("n88");
	}
}
