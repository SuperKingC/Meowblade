using FairyGUI;

namespace UI.GvGChangeShipName;

public class GvGChangeShipNameBinder
{
	public static void BindAll()
	{
		UIObjectFactory.SetPackageItemExtension("ui://3pjle3p4ntp93n", typeof(UI_GvGChangeShipNamePanel));
		UIObjectFactory.SetPackageItemExtension("ui://3pjle3p4ntp93o", typeof(UI_ConfirmNameBtn));
	}
}
