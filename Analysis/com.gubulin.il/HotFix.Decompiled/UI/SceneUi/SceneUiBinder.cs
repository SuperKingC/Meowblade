using FairyGUI;

namespace UI.SceneUi;

public class SceneUiBinder
{
	public static void BindAll()
	{
		UIObjectFactory.SetPackageItemExtension("ui://rujfbplhf4ho11", typeof(UI_CampSlotPanel));
		UIObjectFactory.SetPackageItemExtension("ui://rujfbplhj93u12", typeof(UI_item));
		UIObjectFactory.SetPackageItemExtension("ui://rujfbplhmol00", typeof(UI_BuildingTitle));
		UIObjectFactory.SetPackageItemExtension("ui://rujfbplhmol0j", typeof(UI_ProductionNumStage));
		UIObjectFactory.SetPackageItemExtension("ui://rujfbplhmol0k", typeof(UI_ProductionNumFloating));
		UIObjectFactory.SetPackageItemExtension("ui://rujfbplhmol0w", typeof(UI_UpdatingProgressBar));
		UIObjectFactory.SetPackageItemExtension("ui://rujfbplhmol0x", typeof(UI_UpgradedProgressBar));
		UIObjectFactory.SetPackageItemExtension("ui://rujfbplhmol0y", typeof(UI_BuildingUpgradeProgressStage));
		UIObjectFactory.SetPackageItemExtension("ui://rujfbplhmol0z", typeof(UI_buildingDirectionIndicator));
		UIObjectFactory.SetPackageItemExtension("ui://rujfbplhnwjt14", typeof(UI_WorkerBubble));
		UIObjectFactory.SetPackageItemExtension("ui://rujfbplhnwjt17", typeof(UI_MateriaNuml));
		UIObjectFactory.SetPackageItemExtension("ui://rujfbplho9xc18", typeof(UI_IconAndSfx));
		UIObjectFactory.SetPackageItemExtension("ui://rujfbplhwj3d1e", typeof(UI_WorkNum));
		UIObjectFactory.SetPackageItemExtension("ui://rujfbplhx2iy1d", typeof(UI_WorkerTitle1));
		UIObjectFactory.SetPackageItemExtension("ui://rujfbplhxooo1k", typeof(UI_Halo));
	}
}
