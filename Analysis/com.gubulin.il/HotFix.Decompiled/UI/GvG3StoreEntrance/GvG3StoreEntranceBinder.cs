using FairyGUI;

namespace UI.GvG3StoreEntrance;

public class GvG3StoreEntranceBinder
{
	public static void BindAll()
	{
		UIObjectFactory.SetPackageItemExtension("ui://6ccguk4fewb9m", typeof(UI_btn_StellarKeyEntry));
		UIObjectFactory.SetPackageItemExtension("ui://6ccguk4firuh0", typeof(UI_btn_StoreEntry));
		UIObjectFactory.SetPackageItemExtension("ui://6ccguk4firuh3", typeof(UI_dec_Particleeffect));
		UIObjectFactory.SetPackageItemExtension("ui://6ccguk4firuh8", typeof(UI_dec_Particleeffect2));
		UIObjectFactory.SetPackageItemExtension("ui://6ccguk4firuha", typeof(UI_btn_SoulkeyEntry));
		UIObjectFactory.SetPackageItemExtension("ui://6ccguk4firuhd", typeof(UI_com_Title));
		UIObjectFactory.SetPackageItemExtension("ui://6ccguk4firuhf", typeof(UI_main_GvG3StoreEntrance));
	}
}
