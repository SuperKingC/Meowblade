using FairyGUI;

namespace UI.PaymentOptions;

public class PaymentOptionsBinder
{
	public static void BindAll()
	{
		UIObjectFactory.SetPackageItemExtension("ui://jy8z3hj6gpwa0", typeof(UI_PaymentOptionsDialog));
		UIObjectFactory.SetPackageItemExtension("ui://jy8z3hj6gpwa1", typeof(UI_Dialog));
		UIObjectFactory.SetPackageItemExtension("ui://jy8z3hj6gpwa7", typeof(UI_AlipayBtn));
		UIObjectFactory.SetPackageItemExtension("ui://jy8z3hj6gpwa8", typeof(UI_WeChatPayBtn));
	}
}
