using FairyGUI;

namespace UI.GvGMode3Collecting;

public class GvGMode3CollectingBinder
{
	public static void BindAll()
	{
		UIObjectFactory.SetPackageItemExtension("ui://n2y4xuvarxuq0", typeof(UI_main_GvGMode3CollectingPanel));
		UIObjectFactory.SetPackageItemExtension("ui://n2y4xuvarxuq1", typeof(UI_com_Title));
		UIObjectFactory.SetPackageItemExtension("ui://n2y4xuvarxuq8", typeof(UI_com_CollectingOverview));
		UIObjectFactory.SetPackageItemExtension("ui://n2y4xuvarxuq9", typeof(UI_com_OverviewItem));
		UIObjectFactory.SetPackageItemExtension("ui://n2y4xuvarxuqb", typeof(UI_com_ShipOverview));
		UIObjectFactory.SetPackageItemExtension("ui://n2y4xuvarxuqd", typeof(UI_com_ShipCollectingInformation));
		UIObjectFactory.SetPackageItemExtension("ui://n2y4xuvarxuqe", typeof(UI_com_CollectingItem));
		UIObjectFactory.SetPackageItemExtension("ui://n2y4xuvarxuqh", typeof(UI_goodItemLarge));
		UIObjectFactory.SetPackageItemExtension("ui://n2y4xuvas4pld", typeof(UI_eff_FloatingIsland));
	}
}
