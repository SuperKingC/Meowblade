using FairyGUI;

namespace UI.GvG3Medal;

public class GvG3MedalBinder
{
	public static void BindAll()
	{
		UIObjectFactory.SetPackageItemExtension("ui://g5hi1peogwf80", typeof(UI_main_GvG3Medal));
		UIObjectFactory.SetPackageItemExtension("ui://g5hi1peolq581", typeof(UI_com_Title));
		UIObjectFactory.SetPackageItemExtension("ui://g5hi1peolq582", typeof(UI_com_MedalRecords));
		UIObjectFactory.SetPackageItemExtension("ui://g5hi1peolq583", typeof(UI_com_MedalDialog));
		UIObjectFactory.SetPackageItemExtension("ui://g5hi1peolq584", typeof(UI_com_AcquiredMedals));
		UIObjectFactory.SetPackageItemExtension("ui://g5hi1peon4czm", typeof(UI_com_PublishedMedals));
		UIObjectFactory.SetPackageItemExtension("ui://g5hi1peon4czn", typeof(UI_btn_Confirm));
		UIObjectFactory.SetPackageItemExtension("ui://g5hi1peosxgw12", typeof(UI_com_NotActiveMedal));
		UIObjectFactory.SetPackageItemExtension("ui://g5hi1peosxgw13", typeof(UI_com_MedalRecord));
		UIObjectFactory.SetPackageItemExtension("ui://g5hi1peosxgwr", typeof(UI_com_UserAvatarBig));
		UIObjectFactory.SetPackageItemExtension("ui://g5hi1peosxgws", typeof(UI_com_AvatarLoader));
		UIObjectFactory.SetPackageItemExtension("ui://g5hi1peosxgwu", typeof(UI_com_MedalSmall));
		UIObjectFactory.SetPackageItemExtension("ui://g5hi1peosxgwv", typeof(UI_com_MedalBig));
		UIObjectFactory.SetPackageItemExtension("ui://g5hi1peosxgww", typeof(UI_com_MedalActivated));
		UIObjectFactory.SetPackageItemExtension("ui://g5hi1peosxgwy", typeof(UI_btn_ChangeMedal));
		UIObjectFactory.SetPackageItemExtension("ui://g5hi1peosxgwz", typeof(UI_btn_RemoveMedal));
	}
}
