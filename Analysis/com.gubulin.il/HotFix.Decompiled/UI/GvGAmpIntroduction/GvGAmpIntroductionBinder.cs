using FairyGUI;

namespace UI.GvGAmpIntroduction;

public class GvGAmpIntroductionBinder
{
	public static void BindAll()
	{
		UIObjectFactory.SetPackageItemExtension("ui://vt1dz12wkz6b0", typeof(UI_mian_GvGAmpIntroductionPopup));
		UIObjectFactory.SetPackageItemExtension("ui://vt1dz12wkz6b2", typeof(UI_com_GvGAmpIntroductionDialog));
	}
}
