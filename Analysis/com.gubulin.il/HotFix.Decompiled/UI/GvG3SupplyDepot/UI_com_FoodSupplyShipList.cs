using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvG3SupplyDepot;

public class UI_com_FoodSupplyShipList : GComponent
{
	public GList Ships;

	public GLoader flyAnim;

	public const string URL = "ui://pobej4q7a1l0y1m";

	public static string Name = "UI_com_FoodSupplyShipList";

	public static string GetURL()
	{
		return "ui://pobej4q7a1l0y1m";
	}

	public static UI_com_FoodSupplyShipList CreateInstance()
	{
		return (UI_com_FoodSupplyShipList)(object)UIPackage.CreateObject("GvG3SupplyDepot", "com_FoodSupplyShipList");
	}

	public static UI_com_FoodSupplyShipList CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_FoodSupplyShipList).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://pobej4q7a1l0y1m", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Ships = (GList)((GComponent)this).GetChild("Ships");
		flyAnim = (GLoader)((GComponent)this).GetChild("flyAnim");
	}
}
