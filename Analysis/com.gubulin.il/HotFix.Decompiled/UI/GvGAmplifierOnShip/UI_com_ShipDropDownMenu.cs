using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGAmplifierOnShip;

public class UI_com_ShipDropDownMenu : GComponent
{
	public GImage n161;

	public GList ShipList;

	public const string URL = "ui://pwlamcyxpm8p17";

	public static string Name = "UI_com_ShipDropDownMenu";

	public static string GetURL()
	{
		return "ui://pwlamcyxpm8p17";
	}

	public static UI_com_ShipDropDownMenu CreateInstance()
	{
		return (UI_com_ShipDropDownMenu)(object)UIPackage.CreateObject("GvGAmplifierOnShip", "com_ShipDropDownMenu");
	}

	public static UI_com_ShipDropDownMenu CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_ShipDropDownMenu).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://pwlamcyxpm8p17", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		n161 = (GImage)((GComponent)this).GetChild("n161");
		ShipList = (GList)((GComponent)this).GetChild("ShipList");
	}
}
