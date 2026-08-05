using FairyGUI;

namespace UI.LegendItems;

public class LegendItemsBinder
{
	public static void BindAll()
	{
		UIObjectFactory.SetPackageItemExtension("ui://l6qef30p99khp", typeof(UI_BlueprintSplit));
		UIObjectFactory.SetPackageItemExtension("ui://l6qef30pcae1a", typeof(UI_btn_LegendItem));
		UIObjectFactory.SetPackageItemExtension("ui://l6qef30pfz2se", typeof(UI_com_BlueprintList));
		UIObjectFactory.SetPackageItemExtension("ui://l6qef30plud89", typeof(UI_ScrollBarA_grip));
		UIObjectFactory.SetPackageItemExtension("ui://l6qef30pv5cz0", typeof(UI_LegendItemsPanel));
		UIObjectFactory.SetPackageItemExtension("ui://l6qef30pv5cz4", typeof(UI_com_ArmsList));
		UIObjectFactory.SetPackageItemExtension("ui://l6qef30pv5cz7", typeof(UI_tab_switchButtonA));
		UIObjectFactory.SetPackageItemExtension("ui://l6qef30pwh8wc", typeof(UI_com_Title));
	}
}
