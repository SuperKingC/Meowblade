using FairyGUI;
using FairyGUI.Utils;

namespace UI.LegendItemCultivation;

public class UI_CostItemAndNum : GComponent
{
	public GLoader Icon;

	public GTextField Num;

	public const string URL = "ui://b9wlonaqmpf91f";

	public static string Name = "UI_CostItemAndNum";

	public static string GetURL()
	{
		return "ui://b9wlonaqmpf91f";
	}

	public static UI_CostItemAndNum CreateInstance()
	{
		return (UI_CostItemAndNum)(object)UIPackage.CreateObject("LegendItemCultivation", "CostItemAndNum");
	}

	public static UI_CostItemAndNum CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_CostItemAndNum).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://b9wlonaqmpf91f", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Icon = (GLoader)((GComponent)this).GetChild("Icon");
		Num = (GTextField)((GComponent)this).GetChild("Num");
	}
}
