using FairyGUI;

namespace UI.Souvenir;

public class SouvenirBinder
{
	public static void BindAll()
	{
		UIObjectFactory.SetPackageItemExtension("ui://8kibkcqi8zhy0", typeof(UI_main_Souvenir));
		UIObjectFactory.SetPackageItemExtension("ui://8kibkcqi8zhy1", typeof(UI_com_Content));
		UIObjectFactory.SetPackageItemExtension("ui://8kibkcqi8zhy2", typeof(UI_com_LineText));
	}
}
