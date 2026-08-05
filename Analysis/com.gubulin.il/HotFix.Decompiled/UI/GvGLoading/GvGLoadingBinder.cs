using FairyGUI;

namespace UI.GvGLoading;

public class GvGLoadingBinder
{
	public static void BindAll()
	{
		UIObjectFactory.SetPackageItemExtension("ui://wvi1oqrw9u003", typeof(UI_Temp_Ships));
		UIObjectFactory.SetPackageItemExtension("ui://wvi1oqrwgfov0", typeof(UI_main_GvGLoadingPanel));
		UIObjectFactory.SetPackageItemExtension("ui://wvi1oqrwl8w00", typeof(UI_main_GvGLoading2Panel));
	}
}
