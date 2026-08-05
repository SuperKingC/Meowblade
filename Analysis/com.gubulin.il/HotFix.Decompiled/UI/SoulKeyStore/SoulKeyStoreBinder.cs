using FairyGUI;

namespace UI.SoulKeyStore;

public class SoulKeyStoreBinder
{
	public static void BindAll()
	{
		UIObjectFactory.SetPackageItemExtension("ui://3nd2hqkiqmsbu", typeof(UI_dec_cardeffect));
		UIObjectFactory.SetPackageItemExtension("ui://3nd2hqkir89117", typeof(UI_com_Scroll));
		UIObjectFactory.SetPackageItemExtension("ui://3nd2hqkit9an14", typeof(UI_dec_StoneFloating));
		UIObjectFactory.SetPackageItemExtension("ui://3nd2hqkit9an15", typeof(UI_dec_StoneFloatingsmall));
		UIObjectFactory.SetPackageItemExtension("ui://3nd2hqkivzbka", typeof(UI_ActivityTab));
		UIObjectFactory.SetPackageItemExtension("ui://3nd2hqkivzbkb", typeof(UI_CutTab));
		UIObjectFactory.SetPackageItemExtension("ui://3nd2hqkivzbkc", typeof(UI_AddCreditCard));
		UIObjectFactory.SetPackageItemExtension("ui://3nd2hqkivzbke", typeof(UI_FirstTimeDouble));
		UIObjectFactory.SetPackageItemExtension("ui://3nd2hqkivzbki", typeof(UI_SoulKeyStorePanel));
		UIObjectFactory.SetPackageItemExtension("ui://3nd2hqkivzbkj", typeof(UI_Title));
		UIObjectFactory.SetPackageItemExtension("ui://3nd2hqkivzbkl", typeof(UI_currencyBtn));
	}
}
