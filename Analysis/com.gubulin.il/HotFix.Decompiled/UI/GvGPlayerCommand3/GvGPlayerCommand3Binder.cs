using FairyGUI;

namespace UI.GvGPlayerCommand3;

public class GvGPlayerCommand3Binder
{
	public static void BindAll()
	{
		UIObjectFactory.SetPackageItemExtension("ui://vheg8vabeai31", typeof(UI_main_PlayerCommand));
		UIObjectFactory.SetPackageItemExtension("ui://vheg8vabeai32", typeof(UI_com_CancelCommand));
		UIObjectFactory.SetPackageItemExtension("ui://vheg8vabeai34", typeof(UI_btn_CancelCommand));
		UIObjectFactory.SetPackageItemExtension("ui://vheg8vabeai35", typeof(UI_main_CancelCommand));
		UIObjectFactory.SetPackageItemExtension("ui://vheg8vabeai36", typeof(UI_com_CommandMessage));
		UIObjectFactory.SetPackageItemExtension("ui://vheg8vabeai37", typeof(UI_btn_DefaultMessageFilter));
		UIObjectFactory.SetPackageItemExtension("ui://vheg8vabeai3a", typeof(UI_btn_DefaultMessage));
		UIObjectFactory.SetPackageItemExtension("ui://vheg8vabeai3c", typeof(UI_btn_ConfirmBtn));
		UIObjectFactory.SetPackageItemExtension("ui://vheg8vabeai3d", typeof(UI_com_IssueCommand));
		UIObjectFactory.SetPackageItemExtension("ui://vheg8vabeai3f", typeof(UI_com_SelectedMessage));
		UIObjectFactory.SetPackageItemExtension("ui://vheg8vabeai3g", typeof(UI_btn_CommandMessage));
		UIObjectFactory.SetPackageItemExtension("ui://vheg8vabeai3i", typeof(UI_btn_ContributionPointAdd));
		UIObjectFactory.SetPackageItemExtension("ui://vheg8vabeai3j", typeof(UI_btn_TimeAdd));
		UIObjectFactory.SetPackageItemExtension("ui://vheg8vabfmir0", typeof(UI_btn_Command));
		UIObjectFactory.SetPackageItemExtension("ui://vheg8vabnfmek", typeof(UI_com_TimeBar));
		UIObjectFactory.SetPackageItemExtension("ui://vheg8vabnfmew", typeof(UI_btn_ConfirmBtn2));
		UIObjectFactory.SetPackageItemExtension("ui://vheg8vabq1hvx", typeof(UI_com_CommandIcon));
	}
}
