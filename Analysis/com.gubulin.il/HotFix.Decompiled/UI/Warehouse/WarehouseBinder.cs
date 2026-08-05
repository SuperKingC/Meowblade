using FairyGUI;

namespace UI.Warehouse;

public class WarehouseBinder
{
	public static void BindAll()
	{
		UIObjectFactory.SetPackageItemExtension("ui://kh10nzowkj2bi", typeof(UI_btn_Switchavailable));
		UIObjectFactory.SetPackageItemExtension("ui://kh10nzowl3sc0", typeof(UI_WarehousePanel));
		UIObjectFactory.SetPackageItemExtension("ui://kh10nzowp7vm5", typeof(UI_btn_SwitchCollection));
		UIObjectFactory.SetPackageItemExtension("ui://kh10nzowvv0u1", typeof(UI_Title));
		UIObjectFactory.SetPackageItemExtension("ui://kh10nzowvv0u2", typeof(UI_switchProp));
		UIObjectFactory.SetPackageItemExtension("ui://kh10nzowvv0u3", typeof(UI_switchEquip));
		UIObjectFactory.SetPackageItemExtension("ui://kh10nzowvv0u4", typeof(UI_switchGood));
	}
}
