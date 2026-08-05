using FairyGUI;

namespace UI.MonthCard;

public class MonthCardBinder
{
	public static void BindAll()
	{
		UIObjectFactory.SetPackageItemExtension("ui://4ctl553savmf0", typeof(UI_MonthCardPanel));
		UIObjectFactory.SetPackageItemExtension("ui://4ctl553savmf8", typeof(UI_Title));
		UIObjectFactory.SetPackageItemExtension("ui://4ctl553savmfb", typeof(UI_ConfirmBuyBtn));
		UIObjectFactory.SetPackageItemExtension("ui://4ctl553savmfe", typeof(UI_SecondaryRewardBtn));
		UIObjectFactory.SetPackageItemExtension("ui://4ctl553sazqa10", typeof(UI_countdownBtn));
		UIObjectFactory.SetPackageItemExtension("ui://4ctl553sfq9ez", typeof(UI_ContinueBuyBtn));
		UIObjectFactory.SetPackageItemExtension("ui://4ctl553sgawyl", typeof(UI_EffectiveSfxBack));
		UIObjectFactory.SetPackageItemExtension("ui://4ctl553sjgrlh", typeof(UI_ContractCard));
		UIObjectFactory.SetPackageItemExtension("ui://4ctl553stjci2r", typeof(UI_PrivilegeBtn));
		UIObjectFactory.SetPackageItemExtension("ui://4ctl553sv78k2g", typeof(UI_ConfirmTakeBtn));
	}
}
