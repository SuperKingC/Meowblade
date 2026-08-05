using FairyGUI;

namespace UI.UseItemResult;

public class UseItemResultBinder
{
	public static void BindAll()
	{
		UIObjectFactory.SetPackageItemExtension("ui://800w3r8r9vfju", typeof(UI_increaseButton));
		UIObjectFactory.SetPackageItemExtension("ui://800w3r8r9vfjv", typeof(UI_reduceButton));
		UIObjectFactory.SetPackageItemExtension("ui://800w3r8r9vfjw", typeof(UI_MaxValueBtn));
		UIObjectFactory.SetPackageItemExtension("ui://800w3r8ra0mrj", typeof(UI_main_StellarKeyBuyPanel));
		UIObjectFactory.SetPackageItemExtension("ui://800w3r8rez1c0", typeof(UI_main_GvGUseItemResultPanel));
		UIObjectFactory.SetPackageItemExtension("ui://800w3r8rez1c1", typeof(UI_btn_ConfirmBtn));
		UIObjectFactory.SetPackageItemExtension("ui://800w3r8rez1c5", typeof(UI_com_Content));
		UIObjectFactory.SetPackageItemExtension("ui://800w3r8rez1c6", typeof(UI_btn_BonusItemWrapper));
		UIObjectFactory.SetPackageItemExtension("ui://800w3r8rez1c7", typeof(UI_com_BonusItem));
		UIObjectFactory.SetPackageItemExtension("ui://800w3r8rez1cb", typeof(UI_com_GvGUseItemResultDialog));
		UIObjectFactory.SetPackageItemExtension("ui://800w3r8rgv8uh", typeof(UI_main_GSUseItemResultPanel));
		UIObjectFactory.SetPackageItemExtension("ui://800w3r8rgv8ui", typeof(UI_com_GSUseItemResultDialog));
		UIObjectFactory.SetPackageItemExtension("ui://800w3r8rmzqrc", typeof(UI_btn_ConfirmTake));
		UIObjectFactory.SetPackageItemExtension("ui://800w3r8rmzqrd", typeof(UI_btn_SmallBonusItemWrapper));
		UIObjectFactory.SetPackageItemExtension("ui://800w3r8rne3mg", typeof(UI_com_TalentSrc));
		UIObjectFactory.SetPackageItemExtension("ui://800w3r8rq2d9l", typeof(UI_btn_AmplifierWrapper));
		UIObjectFactory.SetPackageItemExtension("ui://800w3r8rq2d9q", typeof(UI_com_AmplifierSlot));
	}
}
