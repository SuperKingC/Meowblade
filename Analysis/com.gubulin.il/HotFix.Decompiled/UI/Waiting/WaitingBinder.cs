using FairyGUI;

namespace UI.Waiting;

public class WaitingBinder
{
	public static void BindAll()
	{
		UIObjectFactory.SetPackageItemExtension("ui://f36jspecflt25", typeof(UI_btn_Feedback));
		UIObjectFactory.SetPackageItemExtension("ui://f36jspecflt26", typeof(UI_btn_Retry));
		UIObjectFactory.SetPackageItemExtension("ui://f36jspecwqiz1", typeof(UI_WaitingPanel));
	}
}
