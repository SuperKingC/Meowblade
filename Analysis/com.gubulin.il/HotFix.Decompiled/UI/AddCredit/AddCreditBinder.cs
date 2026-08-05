using FairyGUI;

namespace UI.AddCredit;

public class AddCreditBinder
{
	public static void BindAll()
	{
		UIObjectFactory.SetPackageItemExtension("ui://4pot8w0vavmf0", typeof(UI_BlackMarketerAddCredit));
		UIObjectFactory.SetPackageItemExtension("ui://4pot8w0vavmf1", typeof(UI_Title));
		UIObjectFactory.SetPackageItemExtension("ui://4pot8w0vavmf2", typeof(UI_AddCreditCard));
		UIObjectFactory.SetPackageItemExtension("ui://4pot8w0vavmf4", typeof(UI_FirstTimeDouble));
		UIObjectFactory.SetPackageItemExtension("ui://4pot8w0vl1ase", typeof(UI_CardLoader));
	}
}
