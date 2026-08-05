using FairyGUI;

namespace UI.PushGiftBag;

public class PushGiftBagBinder
{
	public static void BindAll()
	{
		UIObjectFactory.SetPackageItemExtension("ui://ume49e0adecw8", typeof(UI_PushGiftBagPanel));
		UIObjectFactory.SetPackageItemExtension("ui://ume49e0adecw9", typeof(UI_PageButtonLeft));
		UIObjectFactory.SetPackageItemExtension("ui://ume49e0adecwa", typeof(UI_PageButtonRight));
		UIObjectFactory.SetPackageItemExtension("ui://ume49e0adecwb", typeof(UI_Dialog));
		UIObjectFactory.SetPackageItemExtension("ui://ume49e0adecwc", typeof(UI_Title));
		UIObjectFactory.SetPackageItemExtension("ui://ume49e0adecwe", typeof(UI_ConfirmBuyBtn));
		UIObjectFactory.SetPackageItemExtension("ui://ume49e0adecwf", typeof(UI_TakeItemContent));
	}
}
