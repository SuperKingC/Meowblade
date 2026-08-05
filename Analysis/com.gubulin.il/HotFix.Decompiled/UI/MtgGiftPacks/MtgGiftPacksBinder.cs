using FairyGUI;

namespace UI.MtgGiftPacks;

public class MtgGiftPacksBinder
{
	public static void BindAll()
	{
		UIObjectFactory.SetPackageItemExtension("ui://4pzrvwm6l1asa", typeof(UI_CardLoader));
		UIObjectFactory.SetPackageItemExtension("ui://4pzrvwm6mksc0", typeof(UI_MtgGiftPacksPanel));
		UIObjectFactory.SetPackageItemExtension("ui://4pzrvwm6mksc1", typeof(UI_Title));
		UIObjectFactory.SetPackageItemExtension("ui://4pzrvwm6mksc2", typeof(UI_MtgPack));
	}
}
