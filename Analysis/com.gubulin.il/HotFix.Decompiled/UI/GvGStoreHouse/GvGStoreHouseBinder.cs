using FairyGUI;

namespace UI.GvGStoreHouse;

public class GvGStoreHouseBinder
{
	public static void BindAll()
	{
		UIObjectFactory.SetPackageItemExtension("ui://6ym14r0de8zud", typeof(UI_GoToFlagShip));
		UIObjectFactory.SetPackageItemExtension("ui://6ym14r0dk58y5", typeof(UI_btn_PageTabFront));
		UIObjectFactory.SetPackageItemExtension("ui://6ym14r0dk58y6", typeof(UI_btn_PageTabBack));
		UIObjectFactory.SetPackageItemExtension("ui://6ym14r0dn0uk0", typeof(UI_main_GvGStoreHousePanel));
		UIObjectFactory.SetPackageItemExtension("ui://6ym14r0dn0uk4", typeof(UI_com_Title));
	}
}
