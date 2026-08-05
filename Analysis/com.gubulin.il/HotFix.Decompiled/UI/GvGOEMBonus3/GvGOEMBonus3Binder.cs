using FairyGUI;

namespace UI.GvGOEMBonus3;

public class GvGOEMBonus3Binder
{
	public static void BindAll()
	{
		UIObjectFactory.SetPackageItemExtension("ui://h3bpjkt7pg605p", typeof(UI_main_GvG3OemBonus));
		UIObjectFactory.SetPackageItemExtension("ui://h3bpjkt7pg607", typeof(UI_com_ForgeResult));
		UIObjectFactory.SetPackageItemExtension("ui://h3bpjkt7pg60b", typeof(UI_btn_ConfirmBtn));
		UIObjectFactory.SetPackageItemExtension("ui://h3bpjkt7pzxd5q", typeof(UI_com_Amplifier));
		UIObjectFactory.SetPackageItemExtension("ui://h3bpjkt7pzxd5u", typeof(UI_com_OemBonus));
		UIObjectFactory.SetPackageItemExtension("ui://h3bpjkt7t0zv62", typeof(UI_main_GvG3FormulaOemBonus));
		UIObjectFactory.SetPackageItemExtension("ui://h3bpjkt7t0zv63", typeof(UI_com_FormulaForgeResult));
	}
}
