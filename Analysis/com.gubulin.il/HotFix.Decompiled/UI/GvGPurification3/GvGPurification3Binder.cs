using FairyGUI;

namespace UI.GvGPurification3;

public class GvGPurification3Binder
{
	public static void BindAll()
	{
		UIObjectFactory.SetPackageItemExtension("ui://v7vqvgvm1146l5", typeof(UI_main_GvG3Purification));
		UIObjectFactory.SetPackageItemExtension("ui://v7vqvgvm1146l6", typeof(UI_com_Purification));
		UIObjectFactory.SetPackageItemExtension("ui://v7vqvgvm1146l7", typeof(UI_btn_Pollutant));
		UIObjectFactory.SetPackageItemExtension("ui://v7vqvgvmkvzvld", typeof(UI_ExitAdvancedBtn));
		UIObjectFactory.SetPackageItemExtension("ui://v7vqvgvmsmdjl9", typeof(UI_com_PurifyTip));
		UIObjectFactory.SetPackageItemExtension("ui://v7vqvgvmsmdjlb", typeof(UI_btn_SelectAll));
		UIObjectFactory.SetPackageItemExtension("ui://v7vqvgvmsmdjlc", typeof(UI_btn_Purify));
		UIObjectFactory.SetPackageItemExtension("ui://v7vqvgvmzs6gm2", typeof(UI_main_PurificationEffect));
		UIObjectFactory.SetPackageItemExtension("ui://v7vqvgvmzs6gm3", typeof(UI_dec_01));
		UIObjectFactory.SetPackageItemExtension("ui://v7vqvgvmzs6gm4", typeof(UI_dec_02));
		UIObjectFactory.SetPackageItemExtension("ui://v7vqvgvmzs6gm7", typeof(UI_dec_light01));
		UIObjectFactory.SetPackageItemExtension("ui://v7vqvgvmzs6gm8", typeof(UI_dec_light02));
	}
}
