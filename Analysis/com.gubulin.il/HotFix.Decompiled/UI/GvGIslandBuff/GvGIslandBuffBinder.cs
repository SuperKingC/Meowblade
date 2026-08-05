using FairyGUI;

namespace UI.GvGIslandBuff;

public class GvGIslandBuffBinder
{
	public static void BindAll()
	{
		UIObjectFactory.SetPackageItemExtension("ui://zh7jgfijc7zhs5u", typeof(UI_btn_IslandName));
		UIObjectFactory.SetPackageItemExtension("ui://zh7jgfijnewqfg", typeof(UI_main_IslandBuffPanel));
		UIObjectFactory.SetPackageItemExtension("ui://zh7jgfijnewqfh", typeof(UI_com_IslandBuffDialog));
		UIObjectFactory.SetPackageItemExtension("ui://zh7jgfijnewqfi", typeof(UI_btn_MyCamp));
		UIObjectFactory.SetPackageItemExtension("ui://zh7jgfijnewqfk", typeof(UI_btn_OtherCamp));
		UIObjectFactory.SetPackageItemExtension("ui://zh7jgfijnewqfl", typeof(UI_com_MyCampBuff));
		UIObjectFactory.SetPackageItemExtension("ui://zh7jgfijnewqfm", typeof(UI_com_IslandBuff));
		UIObjectFactory.SetPackageItemExtension("ui://zh7jgfijnewqft", typeof(UI_com_BuffListSmall));
		UIObjectFactory.SetPackageItemExtension("ui://zh7jgfijnewqfv", typeof(UI_com_OccupyStatus));
		UIObjectFactory.SetPackageItemExtension("ui://zh7jgfijnewqg0", typeof(UI_btn_LookBuffDetails));
		UIObjectFactory.SetPackageItemExtension("ui://zh7jgfijnungg9", typeof(UI_com_Camp));
		UIObjectFactory.SetPackageItemExtension("ui://zh7jgfijsch5s5t", typeof(UI_com_IslandBuffListContainer));
	}
}
