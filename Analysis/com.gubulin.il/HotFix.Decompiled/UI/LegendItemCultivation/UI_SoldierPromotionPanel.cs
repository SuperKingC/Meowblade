using FairyGUI;
using FairyGUI.Utils;

namespace UI.LegendItemCultivation;

public class UI_SoldierPromotionPanel : GComponent
{
	public Controller PageController;

	public GGraph mask;

	public UI_SoldierPromotionDialog Dialog;

	public Transition ShowDialog;

	public const string URL = "ui://b9wlonaqlud8i";

	public static string Name = "UI_SoldierPromotionPanel";

	public static string GetURL()
	{
		return "ui://b9wlonaqlud8i";
	}

	public static UI_SoldierPromotionPanel CreateInstance()
	{
		return (UI_SoldierPromotionPanel)(object)UIPackage.CreateObject("LegendItemCultivation", "SoldierPromotionPanel");
	}

	public static UI_SoldierPromotionPanel CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_SoldierPromotionPanel).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://b9wlonaqlud8i", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		PageController = ((GComponent)this).GetController("PageController");
		mask = (GGraph)((GComponent)this).GetChild("mask");
		Dialog = (UI_SoldierPromotionDialog)(object)((GComponent)this).GetChild("Dialog");
		ShowDialog = ((GComponent)this).GetTransition("ShowDialog");
	}
}
