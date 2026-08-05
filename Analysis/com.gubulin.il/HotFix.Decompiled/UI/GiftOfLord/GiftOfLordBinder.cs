using FairyGUI;

namespace UI.GiftOfLord;

public class GiftOfLordBinder
{
	public static void BindAll()
	{
		UIObjectFactory.SetPackageItemExtension("ui://nz2z1ab8jg8wm", typeof(UI_com_AchievementWrapper));
		UIObjectFactory.SetPackageItemExtension("ui://nz2z1ab8t0xz0", typeof(UI_main_GiftOfLord));
		UIObjectFactory.SetPackageItemExtension("ui://nz2z1ab8t0xz9", typeof(UI_Title));
		UIObjectFactory.SetPackageItemExtension("ui://nz2z1ab8t0xza", typeof(UI_com_Achievement));
		UIObjectFactory.SetPackageItemExtension("ui://nz2z1ab8t0xzb", typeof(UI_receiveBtn));
		UIObjectFactory.SetPackageItemExtension("ui://nz2z1ab8t0xzd", typeof(UI_com_ListBackground));
		UIObjectFactory.SetPackageItemExtension("ui://nz2z1ab8t0xze", typeof(UI_com_Desc));
	}
}
