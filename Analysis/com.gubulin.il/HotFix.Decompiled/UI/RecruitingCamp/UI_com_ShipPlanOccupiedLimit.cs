using FairyGUI;
using FairyGUI.Utils;

namespace UI.RecruitingCamp;

public class UI_com_ShipPlanOccupiedLimit : GComponent
{
	public GTextField ShipPlanOccupiedValue;

	public GTextField LeftBracket;

	public GTextField RightBracket;

	public GTextField StockLimit;

	public GImage n87;

	public const string URL = "ui://72fujxhkhnl143";

	public static string Name = "UI_com_ShipPlanOccupiedLimit";

	public static string GetURL()
	{
		return "ui://72fujxhkhnl143";
	}

	public static UI_com_ShipPlanOccupiedLimit CreateInstance()
	{
		return (UI_com_ShipPlanOccupiedLimit)(object)UIPackage.CreateObject("RecruitingCamp", "com_ShipPlanOccupiedLimit");
	}

	public static UI_com_ShipPlanOccupiedLimit CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_ShipPlanOccupiedLimit).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://72fujxhkhnl143", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		//IL_0061: Expected O, but got Unknown
		//IL_006d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0077: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		ShipPlanOccupiedValue = (GTextField)((GComponent)this).GetChild("ShipPlanOccupiedValue");
		LeftBracket = (GTextField)((GComponent)this).GetChild("LeftBracket");
		RightBracket = (GTextField)((GComponent)this).GetChild("RightBracket");
		StockLimit = (GTextField)((GComponent)this).GetChild("StockLimit");
		n87 = (GImage)((GComponent)this).GetChild("n87");
	}
}
