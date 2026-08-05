using FairyGUI;

namespace UI.PushFirstTopup;

public class PushFirstTopupBinder
{
	public static void BindAll()
	{
		UIObjectFactory.SetPackageItemExtension("ui://r9ncs56ehni6v44c", typeof(UI_main_FirstTopupPopPanel));
		UIObjectFactory.SetPackageItemExtension("ui://r9ncs56ehni6v44d", typeof(UI_com_FirstTopupDialog));
		UIObjectFactory.SetPackageItemExtension("ui://r9ncs56ehni6v44h", typeof(UI_RechargeBtn));
		UIObjectFactory.SetPackageItemExtension("ui://r9ncs56ehni6v44i", typeof(UI_RechargeMainReward));
		UIObjectFactory.SetPackageItemExtension("ui://r9ncs56ehni6v44j", typeof(UI_RechargeReward));
	}
}
