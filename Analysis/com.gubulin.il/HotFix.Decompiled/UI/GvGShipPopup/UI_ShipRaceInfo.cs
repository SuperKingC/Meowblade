using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGShipPopup;

public class UI_ShipRaceInfo : GComponent
{
	public GImage n13;

	public GLoader RaceIcon;

	public GTextField Info;

	public const string URL = "ui://pwrbvhpvlaby38";

	public static string Name = "UI_ShipRaceInfo";

	public static string GetURL()
	{
		return "ui://pwrbvhpvlaby38";
	}

	public static UI_ShipRaceInfo CreateInstance()
	{
		return (UI_ShipRaceInfo)(object)UIPackage.CreateObject("GvGShipPopup", "ShipRaceInfo");
	}

	public static UI_ShipRaceInfo CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_ShipRaceInfo).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://pwrbvhpvlaby38", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		n13 = (GImage)((GComponent)this).GetChild("n13");
		RaceIcon = (GLoader)((GComponent)this).GetChild("RaceIcon");
		Info = (GTextField)((GComponent)this).GetChild("Info");
	}
}
