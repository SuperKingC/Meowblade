using FairyGUI;

namespace UI.Lottery;

public class LotteryBinder
{
	public static void BindAll()
	{
		UIObjectFactory.SetPackageItemExtension("ui://gxhnhhxkhblgq", typeof(UI_ChooseLotteryPage));
		UIObjectFactory.SetPackageItemExtension("ui://gxhnhhxkhblgr", typeof(UI_LotteryTimesProcessBar));
		UIObjectFactory.SetPackageItemExtension("ui://gxhnhhxkhblgs", typeof(UI_LotteryRulesBtn));
		UIObjectFactory.SetPackageItemExtension("ui://gxhnhhxkhblgt", typeof(UI_DetailInfoPopup));
		UIObjectFactory.SetPackageItemExtension("ui://gxhnhhxkhblgu", typeof(UI_DetaillistPopup));
		UIObjectFactory.SetPackageItemExtension("ui://gxhnhhxkhblgv", typeof(UI_DetaillistItem));
		UIObjectFactory.SetPackageItemExtension("ui://gxhnhhxkhblgw", typeof(UI_OpenLotteryBtn));
		UIObjectFactory.SetPackageItemExtension("ui://gxhnhhxkqgmmx", typeof(UI_ConfirmWindow));
		UIObjectFactory.SetPackageItemExtension("ui://gxhnhhxkqgmmy", typeof(UI_ConfirmBtn));
		UIObjectFactory.SetPackageItemExtension("ui://gxhnhhxkqgmmz", typeof(UI_CancelBtn));
		UIObjectFactory.SetPackageItemExtension("ui://gxhnhhxkrtxa0", typeof(UI_Lottery));
		UIObjectFactory.SetPackageItemExtension("ui://gxhnhhxkrtxa4", typeof(UI_generialJackpotBtn));
		UIObjectFactory.SetPackageItemExtension("ui://gxhnhhxkrtxa6", typeof(UI_SpecialJackpotBtn));
		UIObjectFactory.SetPackageItemExtension("ui://gxhnhhxkrtxa7", typeof(UI_SpecialJackpotBtnB));
		UIObjectFactory.SetPackageItemExtension("ui://gxhnhhxkrtxa8", typeof(UI_ExitBtn));
		UIObjectFactory.SetPackageItemExtension("ui://gxhnhhxkrtxa9", typeof(UI_EnterJackpotBtn));
		UIObjectFactory.SetPackageItemExtension("ui://gxhnhhxkrtxaa", typeof(UI_LotteryResultPage));
		UIObjectFactory.SetPackageItemExtension("ui://gxhnhhxkrtxac", typeof(UI_GetAllBtn));
		UIObjectFactory.SetPackageItemExtension("ui://gxhnhhxkrtxad", typeof(UI_ShareBtn));
		UIObjectFactory.SetPackageItemExtension("ui://gxhnhhxkrtxae", typeof(UI_NotAllBtn));
		UIObjectFactory.SetPackageItemExtension("ui://gxhnhhxkrtxaf", typeof(UI_DetailedListBtn));
		UIObjectFactory.SetPackageItemExtension("ui://gxhnhhxkrtxal", typeof(UI_OpenJackpotBtn));
		UIObjectFactory.SetPackageItemExtension("ui://gxhnhhxkrtxao", typeof(UI_ReadyLotteryPage));
	}
}
