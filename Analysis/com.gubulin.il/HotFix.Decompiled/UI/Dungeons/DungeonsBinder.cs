using FairyGUI;

namespace UI.Dungeons;

public class DungeonsBinder
{
	public static void BindAll()
	{
		UIObjectFactory.SetPackageItemExtension("ui://e3srq2g9kpcle", typeof(UI_repairBtn));
		UIObjectFactory.SetPackageItemExtension("ui://e3srq2g9kpclf", typeof(UI_upgradeBtn));
		UIObjectFactory.SetPackageItemExtension("ui://e3srq2g9kpclg", typeof(UI_acceptanceBtn));
		UIObjectFactory.SetPackageItemExtension("ui://e3srq2g9o7r00", typeof(UI_DungeonsPanel));
		UIObjectFactory.SetPackageItemExtension("ui://e3srq2g9o7r0a", typeof(UI_DungeonLevel));
		UIObjectFactory.SetPackageItemExtension("ui://e3srq2g9t0xvb", typeof(UI_ScrollBar1_grip));
		UIObjectFactory.SetPackageItemExtension("ui://e3srq2g9t0xvd", typeof(UI_buildingCard));
		UIObjectFactory.SetPackageItemExtension("ui://e3srq2g9tfsim", typeof(UI_soldierFormationInfoBack));
		UIObjectFactory.SetPackageItemExtension("ui://e3srq2g9vv0uk", typeof(UI_Title));
	}
}
