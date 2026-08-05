using FairyGUI;

namespace UI.GvGPurificationResult3;

public class GvGPurificationResult3Binder
{
	public static void BindAll()
	{
		UIObjectFactory.SetPackageItemExtension("ui://l9ol6w5fsmdj0", typeof(UI_main_GvG3PurificationResult));
		UIObjectFactory.SetPackageItemExtension("ui://l9ol6w5fsmdj1", typeof(UI_com_PurificationResult));
		UIObjectFactory.SetPackageItemExtension("ui://l9ol6w5fsmdj2", typeof(UI_com_Item));
		UIObjectFactory.SetPackageItemExtension("ui://l9ol6w5fsmdj3", typeof(UI_btn_ConfirmBtn));
	}
}
