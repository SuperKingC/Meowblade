using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGShipOverview;

public class UI_ShipDetailBtn : GButton
{
	public const string URL = "ui://7ymaonxtoktw2x";

	public static string Name = "UI_ShipDetailBtn";

	public static string GetURL()
	{
		return "ui://7ymaonxtoktw2x";
	}

	public static UI_ShipDetailBtn CreateInstance()
	{
		return (UI_ShipDetailBtn)(object)UIPackage.CreateObject("GvGShipOverview", "ShipDetailBtn");
	}

	public static UI_ShipDetailBtn CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_ShipDetailBtn).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://7ymaonxtoktw2x", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		((GComponent)this).ConstructFromXML(xml);
	}
}
