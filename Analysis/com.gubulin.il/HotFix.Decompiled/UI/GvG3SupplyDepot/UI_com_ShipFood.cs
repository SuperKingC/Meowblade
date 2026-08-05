using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvG3SupplyDepot;

public class UI_com_ShipFood : GComponent
{
	public Controller ShipFoodStatus;

	public GImage n4;

	public GLoader ShipIcon;

	public UI_FoodBar Food;

	public GTextField ShipName;

	public UI_btn_Increase Increase;

	public const string URL = "ui://pobej4q7uado5";

	public static string Name = "UI_com_ShipFood";

	public static string GetURL()
	{
		return "ui://pobej4q7uado5";
	}

	public static UI_com_ShipFood CreateInstance()
	{
		return (UI_com_ShipFood)(object)UIPackage.CreateObject("GvG3SupplyDepot", "com_ShipFood");
	}

	public static UI_com_ShipFood CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_ShipFood).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://pobej4q7uado5", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Expected O, but got Unknown
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_0072: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		ShipFoodStatus = ((GComponent)this).GetController("ShipFoodStatus");
		n4 = (GImage)((GComponent)this).GetChild("n4");
		ShipIcon = (GLoader)((GComponent)this).GetChild("ShipIcon");
		Food = (UI_FoodBar)(object)((GComponent)this).GetChild("Food");
		ShipName = (GTextField)((GComponent)this).GetChild("ShipName");
		Increase = (UI_btn_Increase)(object)((GComponent)this).GetChild("Increase");
	}
}
