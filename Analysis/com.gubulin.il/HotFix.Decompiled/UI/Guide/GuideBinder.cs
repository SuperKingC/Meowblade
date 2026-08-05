using FairyGUI;

namespace UI.Guide;

public class GuideBinder
{
	public static void BindAll()
	{
		UIObjectFactory.SetPackageItemExtension("ui://5vxjvcrbb5yvx", typeof(UI_Finger));
		UIObjectFactory.SetPackageItemExtension("ui://5vxjvcrbg6t9s", typeof(UI_FrameBorder));
		UIObjectFactory.SetPackageItemExtension("ui://5vxjvcrbg6t9t", typeof(UI_npc));
		UIObjectFactory.SetPackageItemExtension("ui://5vxjvcrbg6t9u", typeof(UI_tips));
		UIObjectFactory.SetPackageItemExtension("ui://5vxjvcrbqy8o7", typeof(UI_skip2));
		UIObjectFactory.SetPackageItemExtension("ui://5vxjvcrbqy8oa", typeof(UI_arrow));
		UIObjectFactory.SetPackageItemExtension("ui://5vxjvcrbqy8of", typeof(UI_Guide));
		UIObjectFactory.SetPackageItemExtension("ui://5vxjvcrbtiupy", typeof(UI_com_MaincityEntrance));
	}
}
