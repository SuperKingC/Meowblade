using FairyGUI;

namespace UI.RollingMarquee;

public class RollingMarqueeBinder
{
	public static void BindAll()
	{
		UIObjectFactory.SetPackageItemExtension("ui://ccmc9e4k8u4a0", typeof(UI_RollingNotice));
		UIObjectFactory.SetPackageItemExtension("ui://ccmc9e4k8u4a1", typeof(UI_RollingNoticeCom));
		UIObjectFactory.SetPackageItemExtension("ui://ccmc9e4k8u4a2", typeof(UI_RollingMarqueePanel));
		UIObjectFactory.SetPackageItemExtension("ui://ccmc9e4kcpij3", typeof(UI_RollingNoticeBack));
	}
}
