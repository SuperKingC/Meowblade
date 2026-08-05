using FairyGUI;
using FairyGUI.Utils;

namespace UI.LegendItemBlueprint;

public class UI_com_LegendItemCost : GComponent
{
	public Controller Type;

	public GButton EvoLegendItem;

	public GTextField Num;

	public GImage n5;

	public const string URL = "ui://h09dvkcgjpqa17";

	public static string Name = "UI_com_LegendItemCost";

	public static string GetURL()
	{
		return "ui://h09dvkcgjpqa17";
	}

	public static UI_com_LegendItemCost CreateInstance()
	{
		return (UI_com_LegendItemCost)(object)UIPackage.CreateObject("LegendItemBlueprint", "com_LegendItemCost");
	}

	public static UI_com_LegendItemCost CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_LegendItemCost).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://h09dvkcgjpqa17", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		Type = ((GComponent)this).GetController("Type");
		EvoLegendItem = (GButton)((GComponent)this).GetChild("EvoLegendItem");
		Num = (GTextField)((GComponent)this).GetChild("Num");
		n5 = (GImage)((GComponent)this).GetChild("n5");
	}
}
