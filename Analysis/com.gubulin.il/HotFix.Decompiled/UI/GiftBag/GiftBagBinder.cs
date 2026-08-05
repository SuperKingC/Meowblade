using FairyGUI;

namespace UI.GiftBag;

public class GiftBagBinder
{
	public static void BindAll()
	{
		UIObjectFactory.SetPackageItemExtension("ui://4fqsd8h6avmf0", typeof(UI_AddCreditCard));
		UIObjectFactory.SetPackageItemExtension("ui://4fqsd8h6avmf1", typeof(UI_FirstTimeDouble));
		UIObjectFactory.SetPackageItemExtension("ui://4fqsd8h6avmf2", typeof(UI_Title));
		UIObjectFactory.SetPackageItemExtension("ui://4fqsd8h6avmf3", typeof(UI_GiftBagPanel));
		UIObjectFactory.SetPackageItemExtension("ui://4fqsd8h6avmfe", typeof(UI_ConfirmBuyBtn));
		UIObjectFactory.SetPackageItemExtension("ui://4fqsd8h6avmff", typeof(UI_HotSaleItem));
		UIObjectFactory.SetPackageItemExtension("ui://4fqsd8h6avmfk", typeof(UI_HotSaleGift));
		UIObjectFactory.SetPackageItemExtension("ui://4fqsd8h6ay0l1j", typeof(UI_PageItemBack));
		UIObjectFactory.SetPackageItemExtension("ui://4fqsd8h6qfz8y", typeof(UI_PageItem));
		UIObjectFactory.SetPackageItemExtension("ui://4fqsd8h6t1jru", typeof(UI_HotSaleGiftItem));
		UIObjectFactory.SetPackageItemExtension("ui://4fqsd8h6t1jrv", typeof(UI_PageSwitch_item));
		UIObjectFactory.SetPackageItemExtension("ui://4fqsd8h6t1jrw", typeof(UI_PageSwitch_popup));
		UIObjectFactory.SetPackageItemExtension("ui://4fqsd8h6t1jrx", typeof(UI_PageSwitch));
		UIObjectFactory.SetPackageItemExtension("ui://4fqsd8h6toms1b", typeof(UI_HelpPanel));
		UIObjectFactory.SetPackageItemExtension("ui://4fqsd8h6toms1c", typeof(UI_HelpDialog));
	}
}
