using FairyGUI;

namespace UI.StellarKeyStore;

public class StellarKeyStoreBinder
{
	public static void BindAll()
	{
		UIObjectFactory.SetPackageItemExtension("ui://khops95ljjo119", typeof(UI_com_ProductCardContent));
		UIObjectFactory.SetPackageItemExtension("ui://khops95ljjo11a", typeof(UI_com_KeyStock));
		UIObjectFactory.SetPackageItemExtension("ui://khops95lk7x91b", typeof(UI_btn_OpenCraftPanel));
		UIObjectFactory.SetPackageItemExtension("ui://khops95lmclp1c", typeof(UI_com_CraftDialog));
		UIObjectFactory.SetPackageItemExtension("ui://khops95lmclp1d", typeof(UI_main_StellarKeyCraftPopup));
		UIObjectFactory.SetPackageItemExtension("ui://khops95lmclp1e", typeof(UI_com_FormulaSlot));
		UIObjectFactory.SetPackageItemExtension("ui://khops95lmclp1f", typeof(UI_btn_CraftBtn));
		UIObjectFactory.SetPackageItemExtension("ui://khops95lyjov0", typeof(UI_main_StellarKeyStorePanel));
		UIObjectFactory.SetPackageItemExtension("ui://khops95lyjov1", typeof(UI_com_Title));
		UIObjectFactory.SetPackageItemExtension("ui://khops95lyjovb", typeof(UI_btn_ProductCard));
		UIObjectFactory.SetPackageItemExtension("ui://khops95lyjovm", typeof(UI_btn_PageTab));
	}
}
