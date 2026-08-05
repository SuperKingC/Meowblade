using FairyGUI;

namespace UI.UpPropGrade;

public class UpPropGradeBinder
{
	public static void BindAll()
	{
		UIObjectFactory.SetPackageItemExtension("ui://blindbbgio2yr", typeof(UI_BlueprintUpGradePanel));
		UIObjectFactory.SetPackageItemExtension("ui://blindbbgio2ys", typeof(UI_BlueprintDialog));
		UIObjectFactory.SetPackageItemExtension("ui://blindbbgio2yt", typeof(UI_BlueprintUpGradeButton));
		UIObjectFactory.SetPackageItemExtension("ui://blindbbgmol0m", typeof(UI_Dialog));
		UIObjectFactory.SetPackageItemExtension("ui://blindbbgmol0n", typeof(UI_DialogLeftContent));
		UIObjectFactory.SetPackageItemExtension("ui://blindbbgmol0o", typeof(UI_DialogRightContent));
		UIObjectFactory.SetPackageItemExtension("ui://blindbbgmol0p", typeof(UI_Property));
		UIObjectFactory.SetPackageItemExtension("ui://blindbbgvecsq", typeof(UI_DialogMiddleContent));
		UIObjectFactory.SetPackageItemExtension("ui://blindbbgx4m20", typeof(UI_ProductUpGradePanel));
		UIObjectFactory.SetPackageItemExtension("ui://blindbbgx4m21", typeof(UI_Product));
		UIObjectFactory.SetPackageItemExtension("ui://blindbbgx4m26", typeof(UI_ProductUpGradeButton));
		UIObjectFactory.SetPackageItemExtension("ui://blindbbgx4m28", typeof(UI_Material));
	}
}
