using FairyGUI;

namespace UI.GvGShipLaunch;

public class GvGShipLaunchBinder
{
	public static void BindAll()
	{
		UIObjectFactory.SetPackageItemExtension("ui://tc205cu3fgyl0", typeof(UI_main_GvGShipLaunch));
		UIObjectFactory.SetPackageItemExtension("ui://tc205cu3fgyl3", typeof(UI_com_IslandList));
		UIObjectFactory.SetPackageItemExtension("ui://tc205cu3fgyl4", typeof(UI_btn_SelectLaunchIsland));
		UIObjectFactory.SetPackageItemExtension("ui://tc205cu3fgyl5", typeof(UI_btn_IslandInfo));
		UIObjectFactory.SetPackageItemExtension("ui://tc205cu3mony9", typeof(UI_btn_SelectLaunchIslandCancel));
	}
}
