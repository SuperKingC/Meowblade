using FairyGUI;

namespace UI.Restart;

public class RestartBinder
{
	public static void BindAll()
	{
		UIObjectFactory.SetPackageItemExtension("ui://5mgjx17ngb510", typeof(UI_RestartPanel));
		UIObjectFactory.SetPackageItemExtension("ui://5mgjx17ngb511", typeof(UI_ConfirmDialog));
		UIObjectFactory.SetPackageItemExtension("ui://5mgjx17ngb513", typeof(UI_RefreshCardConfirmBtn));
		UIObjectFactory.SetPackageItemExtension("ui://5mgjx17ngb514", typeof(UI_DialogMiddleContent));
	}
}
