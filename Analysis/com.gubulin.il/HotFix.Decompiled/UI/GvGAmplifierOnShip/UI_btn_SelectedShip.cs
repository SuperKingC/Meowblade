using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGAmplifierOnShip;

public class UI_btn_SelectedShip : GButton
{
	public Controller State;

	public Controller c1;

	public GImage n159;

	public GImage n163;

	public GTextField ShipIndex;

	public GTextField ShipName;

	public GButton RaceType;

	public GImage n165;

	public const string URL = "ui://pwlamcyxvb0r15";

	public static string Name = "UI_btn_SelectedShip";

	public static string GetURL()
	{
		return "ui://pwlamcyxvb0r15";
	}

	public static UI_btn_SelectedShip CreateInstance()
	{
		return (UI_btn_SelectedShip)(object)UIPackage.CreateObject("GvGAmplifierOnShip", "btn_SelectedShip");
	}

	public static UI_btn_SelectedShip CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_btn_SelectedShip).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://pwlamcyxvb0r15", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Expected O, but got Unknown
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Expected O, but got Unknown
		//IL_0063: Unknown result type (might be due to invalid IL or missing references)
		//IL_006d: Expected O, but got Unknown
		//IL_0079: Unknown result type (might be due to invalid IL or missing references)
		//IL_0083: Expected O, but got Unknown
		//IL_008f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0099: Expected O, but got Unknown
		//IL_00a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00af: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		State = ((GComponent)this).GetController("State");
		c1 = ((GComponent)this).GetController("c1");
		n159 = (GImage)((GComponent)this).GetChild("n159");
		n163 = (GImage)((GComponent)this).GetChild("n163");
		ShipIndex = (GTextField)((GComponent)this).GetChild("ShipIndex");
		ShipName = (GTextField)((GComponent)this).GetChild("ShipName");
		RaceType = (GButton)((GComponent)this).GetChild("RaceType");
		n165 = (GImage)((GComponent)this).GetChild("n165");
	}
}
