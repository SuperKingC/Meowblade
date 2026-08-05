using FairyGUI;

namespace UI.CraftItemPopup;

public class CraftItemPopupBinder
{
	public static void BindAll()
	{
		UIObjectFactory.SetPackageItemExtension("ui://4pn38ozniuisb", typeof(UI_main_CraftItemPopupPanel_GvG));
		UIObjectFactory.SetPackageItemExtension("ui://4pn38ozniuisd", typeof(UI_btn_CraftBtn));
		UIObjectFactory.SetPackageItemExtension("ui://4pn38ozniuise", typeof(UI_com_CraftItemPopupDialog));
		UIObjectFactory.SetPackageItemExtension("ui://4pn38ozniuisf", typeof(UI_com_Content));
		UIObjectFactory.SetPackageItemExtension("ui://4pn38ozniuish", typeof(UI_com_ConsumptionRate));
		UIObjectFactory.SetPackageItemExtension("ui://4pn38ozniuisi", typeof(UI_btn_IncreaseButton));
		UIObjectFactory.SetPackageItemExtension("ui://4pn38ozniuisj", typeof(UI_btn_ReduceButton));
		UIObjectFactory.SetPackageItemExtension("ui://4pn38oznnqv8n", typeof(UI_com_Consumption));
		UIObjectFactory.SetPackageItemExtension("ui://4pn38oznqobzlp", typeof(UI_main_CraftItemPopupPanel_GS));
		UIObjectFactory.SetPackageItemExtension("ui://4pn38ozntxb6lq", typeof(UI_btn_MaxValueBtn));
	}
}
