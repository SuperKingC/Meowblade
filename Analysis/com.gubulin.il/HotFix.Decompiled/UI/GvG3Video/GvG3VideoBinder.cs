using FairyGUI;

namespace UI.GvG3Video;

public class GvG3VideoBinder
{
	public static void BindAll()
	{
		UIObjectFactory.SetPackageItemExtension("ui://2itu6489ezmi1", typeof(UI_com_VideoPlayer));
		UIObjectFactory.SetPackageItemExtension("ui://2itu6489ezmi3", typeof(UI_btn_Play));
		UIObjectFactory.SetPackageItemExtension("ui://2itu6489ezmi5", typeof(UI_com_VideoReward));
		UIObjectFactory.SetPackageItemExtension("ui://2itu6489ezmi6", typeof(UI_btn_Reward));
		UIObjectFactory.SetPackageItemExtension("ui://2itu6489fuvq8", typeof(UI_btn_VideoPreview));
		UIObjectFactory.SetPackageItemExtension("ui://2itu6489fuvq9", typeof(UI_com_VideoInfo));
		UIObjectFactory.SetPackageItemExtension("ui://2itu6489ogcpr", typeof(UI_com_Videos));
		UIObjectFactory.SetPackageItemExtension("ui://2itu6489oztu0", typeof(UI_main_GvG3Video));
		UIObjectFactory.SetPackageItemExtension("ui://2itu6489q0evt", typeof(UI_com_Title));
	}
}
