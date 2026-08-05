using FairyGUI;

namespace UI.UpdateResources;

public class UpdateResourcesBinder
{
	public static void BindAll()
	{
		UIObjectFactory.SetPackageItemExtension("ui://sui7dihff4sz9", typeof(UI_UniversalConfirmDialog));
		UIObjectFactory.SetPackageItemExtension("ui://sui7dihff4szc", typeof(UI_ClearBtn));
		UIObjectFactory.SetPackageItemExtension("ui://sui7dihff4szd", typeof(UI_RestartBtn));
		UIObjectFactory.SetPackageItemExtension("ui://sui7dihfk1jj0", typeof(UI_UpdateResources));
		UIObjectFactory.SetPackageItemExtension("ui://sui7dihfk1jj4", typeof(UI_UpdateProgressBar));
		UIObjectFactory.SetPackageItemExtension("ui://sui7dihfka6xi", typeof(UI_LogoIcon));
	}
}
