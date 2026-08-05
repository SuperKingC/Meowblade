using FairyGUI;

namespace UI.EnemyIntroduction;

public class EnemyIntroductionBinder
{
	public static void BindAll()
	{
		UIObjectFactory.SetPackageItemExtension("ui://rn232z3eeohrj2", typeof(UI_SkillBtnOutside));
		UIObjectFactory.SetPackageItemExtension("ui://rn232z3eeohrj3", typeof(UI_SkillBtnInside));
		UIObjectFactory.SetPackageItemExtension("ui://rn232z3emol0is", typeof(UI_EnemyIntroduction));
		UIObjectFactory.SetPackageItemExtension("ui://rn232z3emol0iz", typeof(UI_ExitAdvancedBtn));
		UIObjectFactory.SetPackageItemExtension("ui://rn232z3eocw1ji", typeof(UI_SoldierAnimarion));
		UIObjectFactory.SetPackageItemExtension("ui://rn232z3erqrej4", typeof(UI_LegendSlot));
		UIObjectFactory.SetPackageItemExtension("ui://rn232z3erqrej7", typeof(UI_LegendItemSlot));
	}
}
