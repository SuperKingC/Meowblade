using FairyGUI;

namespace UI.Screenshots;

public class ScreenshotsBinder
{
	public static void BindAll()
	{
		UIObjectFactory.SetPackageItemExtension("ui://pzmiqysmh95m0", typeof(UI_ScreenshotsPanel));
		UIObjectFactory.SetPackageItemExtension("ui://pzmiqysmldgh2", typeof(UI_InvitationDialog));
	}
}
