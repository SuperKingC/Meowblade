using FairyGUI;

namespace UI.BlueprintGachaDetailInfo;

public class BlueprintGachaDetailInfoBinder
{
	public static void BindAll()
	{
		UIObjectFactory.SetPackageItemExtension("ui://ojhszwlpsxwp1", typeof(UI_main_BlueprintGachaDetailInfoPanel));
		UIObjectFactory.SetPackageItemExtension("ui://ojhszwlpsxwp2", typeof(UI_com_BlueprintGachaDetailInfoDIalog));
		UIObjectFactory.SetPackageItemExtension("ui://ojhszwlpsxwp3", typeof(UI_exitBtn));
		UIObjectFactory.SetPackageItemExtension("ui://ojhszwlpsxwp5", typeof(UI_com_DetailInfoDIalogTips));
	}
}
