using FairyGUI;

namespace UI.NewbieMission;

public class NewbieMissionBinder
{
	public static void BindAll()
	{
		UIObjectFactory.SetPackageItemExtension("ui://kmmwvr7ck11jq", typeof(UI_MissionInfoDialog));
		UIObjectFactory.SetPackageItemExtension("ui://kmmwvr7ckk930", typeof(UI_NewbieMissionPanel));
		UIObjectFactory.SetPackageItemExtension("ui://kmmwvr7ckk933", typeof(UI_MissionColumn));
		UIObjectFactory.SetPackageItemExtension("ui://kmmwvr7cu32t9", typeof(UI_GotoBtn));
		UIObjectFactory.SetPackageItemExtension("ui://kmmwvr7cu32ta", typeof(UI_ArrowBtn));
	}
}
