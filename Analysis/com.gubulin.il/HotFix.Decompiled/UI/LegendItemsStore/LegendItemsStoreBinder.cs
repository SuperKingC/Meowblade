using FairyGUI;

namespace UI.LegendItemsStore;

public class LegendItemsStoreBinder
{
	public static void BindAll()
	{
		UIObjectFactory.SetPackageItemExtension("ui://i6o930evfjjs9", typeof(UI_AddCreditCard));
		UIObjectFactory.SetPackageItemExtension("ui://i6o930evfjjsa", typeof(UI_FirstTimeDouble));
		UIObjectFactory.SetPackageItemExtension("ui://i6o930evfjjsd", typeof(UI_LegendItemsStorePanel));
		UIObjectFactory.SetPackageItemExtension("ui://i6o930evfjjsg", typeof(UI_Title));
		UIObjectFactory.SetPackageItemExtension("ui://i6o930evjzvw19", typeof(UI_CutTab));
		UIObjectFactory.SetPackageItemExtension("ui://i6o930evvltp10", typeof(UI_ActivityTab));
	}
}
