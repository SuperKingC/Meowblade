using FairyGUI;
using FairyGUI.Utils;

namespace UI.LegendItemBlueprint;

public class UI_com_ItemCost : GComponent
{
	public GLoader Icon;

	public GTextField ItemNum;

	public const string URL = "ui://h09dvkcgi2xa38";

	public static string Name = "UI_com_ItemCost";

	public static string GetURL()
	{
		return "ui://h09dvkcgi2xa38";
	}

	public static UI_com_ItemCost CreateInstance()
	{
		return (UI_com_ItemCost)(object)UIPackage.CreateObject("LegendItemBlueprint", "com_ItemCost");
	}

	public static UI_com_ItemCost CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_ItemCost).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://h09dvkcgi2xa38", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		ItemNum = (GTextField)((GComponent)this).GetChild("ItemNum");
	}
}
