using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvG3SupplyDepot;

public class UI_FoodBar : GProgressBar
{
	public Controller ShipFoodStatus;

	public GLoader bar;

	public GTextField FoodNumber;

	public GImage n14;

	public GLoader n16;

	public const string URL = "ui://pobej4q7uado7";

	public static string Name = "UI_FoodBar";

	public static string GetURL()
	{
		return "ui://pobej4q7uado7";
	}

	public static UI_FoodBar CreateInstance()
	{
		return (UI_FoodBar)(object)UIPackage.CreateObject("GvG3SupplyDepot", "FoodBar");
	}

	public static UI_FoodBar CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_FoodBar).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://pobej4q7uado7", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Expected O, but got Unknown
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		//IL_005c: Expected O, but got Unknown
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_0072: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		ShipFoodStatus = ((GComponent)this).GetController("ShipFoodStatus");
		bar = (GLoader)((GComponent)this).GetChild("bar");
		FoodNumber = (GTextField)((GComponent)this).GetChild("FoodNumber");
		n14 = (GImage)((GComponent)this).GetChild("n14");
		n16 = (GLoader)((GComponent)this).GetChild("n16");
	}
}
