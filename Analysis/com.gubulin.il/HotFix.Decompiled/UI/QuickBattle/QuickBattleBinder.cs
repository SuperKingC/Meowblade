using FairyGUI;

namespace UI.QuickBattle;

public class QuickBattleBinder
{
	public static void BindAll()
	{
		UIObjectFactory.SetPackageItemExtension("ui://kqd1t06oc5l21k", typeof(UI_BattleMiniMap));
		UIObjectFactory.SetPackageItemExtension("ui://kqd1t06oc5l21l", typeof(UI_FortRed));
		UIObjectFactory.SetPackageItemExtension("ui://kqd1t06oc5l21m", typeof(UI_FortBlue));
		UIObjectFactory.SetPackageItemExtension("ui://kqd1t06oc5l21n", typeof(UI_AbatisVertical));
		UIObjectFactory.SetPackageItemExtension("ui://kqd1t06of2580", typeof(UI_QuickBattlePanel));
		UIObjectFactory.SetPackageItemExtension("ui://kqd1t06of2581", typeof(UI_QuickBattleStage));
		UIObjectFactory.SetPackageItemExtension("ui://kqd1t06of25815", typeof(UI_HeadPortrait));
		UIObjectFactory.SetPackageItemExtension("ui://kqd1t06of2581i", typeof(UI_EnemyIcon));
		UIObjectFactory.SetPackageItemExtension("ui://kqd1t06of2581j", typeof(UI_TeamBlueBtn));
		UIObjectFactory.SetPackageItemExtension("ui://kqd1t06of2584", typeof(UI_BattleLoader));
		UIObjectFactory.SetPackageItemExtension("ui://kqd1t06of2589", typeof(UI_OurInfomationBar));
		UIObjectFactory.SetPackageItemExtension("ui://kqd1t06of258a", typeof(UI_OurHPbar));
		UIObjectFactory.SetPackageItemExtension("ui://kqd1t06of258c", typeof(UI_EnemyInfomationBar));
		UIObjectFactory.SetPackageItemExtension("ui://kqd1t06of258d", typeof(UI_EnemyHPbar));
		UIObjectFactory.SetPackageItemExtension("ui://kqd1t06of258h", typeof(UI_MakeWar));
		UIObjectFactory.SetPackageItemExtension("ui://kqd1t06of258l", typeof(UI_SoldierFormation));
		UIObjectFactory.SetPackageItemExtension("ui://kqd1t06of258n", typeof(UI_soliderItem));
		UIObjectFactory.SetPackageItemExtension("ui://kqd1t06of258x", typeof(UI_TeamRedBtn));
		UIObjectFactory.SetPackageItemExtension("ui://kqd1t06of258y", typeof(UI_MyIcon));
		UIObjectFactory.SetPackageItemExtension("ui://kqd1t06on4411p", typeof(UI_Abatis));
		UIObjectFactory.SetPackageItemExtension("ui://kqd1t06on4411q", typeof(UI_AbatisHorizontal));
		UIObjectFactory.SetPackageItemExtension("ui://kqd1t06on4411r", typeof(UI_offensiveProgressItem));
		UIObjectFactory.SetPackageItemExtension("ui://kqd1t06on4411v", typeof(UI_offensiveProgressInitItem));
		UIObjectFactory.SetPackageItemExtension("ui://kqd1t06oqcyp20", typeof(UI_LegendItemsBack));
		UIObjectFactory.SetPackageItemExtension("ui://kqd1t06osv6o1z", typeof(UI_Avatar));
	}
}
