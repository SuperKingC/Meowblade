using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGWorldMap3;

public class UI_ShipFoodProgress : GProgressBar
{
	public Controller button;

	public GImage n5;

	public GImage bar;

	public GTextField FoodStockValue;

	public const string URL = "ui://4eq8fgd2vykndl";

	public static string Name = "UI_ShipFoodProgress";

	public static string GetURL()
	{
		return "ui://4eq8fgd2vykndl";
	}

	public static UI_ShipFoodProgress CreateInstance()
	{
		return (UI_ShipFoodProgress)(object)UIPackage.CreateObject("GvGWorldMap3", "ShipFoodProgress");
	}

	public static UI_ShipFoodProgress CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_ShipFoodProgress).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://4eq8fgd2vykndl", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		n5 = (GImage)((GComponent)this).GetChild("n5");
		bar = (GImage)((GComponent)this).GetChild("bar");
		FoodStockValue = (GTextField)((GComponent)this).GetChild("FoodStockValue");
	}
}
