using FairyGUI;

namespace UI.DebrisCompound;

public class DebrisCompoundBinder
{
	public static void BindAll()
	{
		UIObjectFactory.SetPackageItemExtension("ui://6n2woz97o4kt0", typeof(UI_classicCardFront));
		UIObjectFactory.SetPackageItemExtension("ui://6n2woz97o4kt1", typeof(UI_ClassicCardBack));
		UIObjectFactory.SetPackageItemExtension("ui://6n2woz97o4kt2", typeof(UI_cardLoaderBtn));
		UIObjectFactory.SetPackageItemExtension("ui://6n2woz97o4kt3", typeof(UI_AdvancedCardFront));
		UIObjectFactory.SetPackageItemExtension("ui://6n2woz97o4kt4", typeof(UI_AdvancedCardBack));
		UIObjectFactory.SetPackageItemExtension("ui://6n2woz97o4kt5", typeof(UI_DrawResultBtn));
		UIObjectFactory.SetPackageItemExtension("ui://6n2woz97o4kt6", typeof(UI_ResultDialog));
		UIObjectFactory.SetPackageItemExtension("ui://6n2woz97o4kt7", typeof(UI_ConfirmBtn));
		UIObjectFactory.SetPackageItemExtension("ui://6n2woz97o4kt8", typeof(UI_DebrisCompoundPanel));
		UIObjectFactory.SetPackageItemExtension("ui://6n2woz97vecs9", typeof(UI_SliverCardFront));
		UIObjectFactory.SetPackageItemExtension("ui://6n2woz97vecsa", typeof(UI_SliverCardBack));
	}
}
