using FairyGUI;

namespace UI.MaterialIntroduction;

public class MaterialIntroductionBinder
{
	public static void BindAll()
	{
		UIObjectFactory.SetPackageItemExtension("ui://l3jq1eamic7j1", typeof(UI_RepairBtn));
		UIObjectFactory.SetPackageItemExtension("ui://l3jq1eamic7j2", typeof(UI_MaterialIntroductionPanel));
		UIObjectFactory.SetPackageItemExtension("ui://l3jq1eamic7j3", typeof(UI_MaterialIntroduction));
		UIObjectFactory.SetPackageItemExtension("ui://l3jq1eamic7j4", typeof(UI_Content));
		UIObjectFactory.SetPackageItemExtension("ui://l3jq1eamic7j5", typeof(UI_MaterialIntroductionRight));
		UIObjectFactory.SetPackageItemExtension("ui://l3jq1eamic7j6", typeof(UI_consumption));
	}
}
