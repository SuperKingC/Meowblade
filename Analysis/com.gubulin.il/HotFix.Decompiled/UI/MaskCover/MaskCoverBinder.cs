using FairyGUI;

namespace UI.MaskCover;

public class MaskCoverBinder
{
	public static void BindAll()
	{
		UIObjectFactory.SetPackageItemExtension("ui://nhaflg3971lc8", typeof(UI_GuideFinger));
		UIObjectFactory.SetPackageItemExtension("ui://nhaflg39egl39", typeof(UI_DebugInfo));
		UIObjectFactory.SetPackageItemExtension("ui://nhaflg39vb0c0", typeof(UI_MaskCover));
	}
}
