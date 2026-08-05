using FairyGUI;

namespace UI.SoldierFormationInfo;

public class SoldierFormationInfoBinder
{
	public static void BindAll()
	{
		UIObjectFactory.SetPackageItemExtension("ui://r7u60zpohc8r0", typeof(UI_SoldierFormationInfoPanel));
		UIObjectFactory.SetPackageItemExtension("ui://r7u60zpohc8r1", typeof(UI_SoldierFormationInfo));
		UIObjectFactory.SetPackageItemExtension("ui://r7u60zpohc8r2", typeof(UI_SoldierFormationInfoDialog));
	}
}
