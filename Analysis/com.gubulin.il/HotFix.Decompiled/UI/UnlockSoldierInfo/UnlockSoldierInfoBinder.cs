using FairyGUI;

namespace UI.UnlockSoldierInfo;

public class UnlockSoldierInfoBinder
{
	public static void BindAll()
	{
		UIObjectFactory.SetPackageItemExtension("ui://jctgkd2udqft8", typeof(UI_UnlockStone));
		UIObjectFactory.SetPackageItemExtension("ui://jctgkd2urxdc0", typeof(UI_UnlockSoldierInfoPanel));
		UIObjectFactory.SetPackageItemExtension("ui://jctgkd2urxdc2", typeof(UI_SoldierAnimarion));
		UIObjectFactory.SetPackageItemExtension("ui://jctgkd2urxdc4", typeof(UI_SkillBtnOutside));
		UIObjectFactory.SetPackageItemExtension("ui://jctgkd2urxdc6", typeof(UI_SkillBtnInside));
	}
}
