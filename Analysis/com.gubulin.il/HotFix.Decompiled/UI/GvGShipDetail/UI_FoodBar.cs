using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGShipDetail;

public class UI_FoodBar : GProgressBar
{
	public GImage n8;

	public GImage bar;

	public const string URL = "ui://u6x0b1gndxsb27";

	public static string Name = "UI_FoodBar";

	public static string GetURL()
	{
		return "ui://u6x0b1gndxsb27";
	}

	public static UI_FoodBar CreateInstance()
	{
		return (UI_FoodBar)(object)UIPackage.CreateObject("GvGShipDetail", "FoodBar");
	}

	public static UI_FoodBar CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_FoodBar).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://u6x0b1gndxsb27", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		n8 = (GImage)((GComponent)this).GetChild("n8");
		bar = (GImage)((GComponent)this).GetChild("bar");
	}
}
