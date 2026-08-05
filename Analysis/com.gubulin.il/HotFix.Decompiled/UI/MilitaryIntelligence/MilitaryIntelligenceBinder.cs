using FairyGUI;

namespace UI.MilitaryIntelligence;

public class MilitaryIntelligenceBinder
{
	public static void BindAll()
	{
		UIObjectFactory.SetPackageItemExtension("ui://nfd5v46ufm8z1h", typeof(UI_light1));
		UIObjectFactory.SetPackageItemExtension("ui://nfd5v46ufm8z1i", typeof(UI_light2));
		UIObjectFactory.SetPackageItemExtension("ui://nfd5v46uhbasr", typeof(UI_StandardCardNew));
		UIObjectFactory.SetPackageItemExtension("ui://nfd5v46uk67u0", typeof(UI_MilitaryIntelligencePanel));
		UIObjectFactory.SetPackageItemExtension("ui://nfd5v46uk67ua", typeof(UI_CardLoader));
		UIObjectFactory.SetPackageItemExtension("ui://nfd5v46uk67ub", typeof(UI_CardInstanceZones));
		UIObjectFactory.SetPackageItemExtension("ui://nfd5v46uk67ue", typeof(UI_CardExpedition));
		UIObjectFactory.SetPackageItemExtension("ui://nfd5v46ul2551c", typeof(UI_Title));
		UIObjectFactory.SetPackageItemExtension("ui://nfd5v46uqfh21r", typeof(UI_btn_01));
	}
}
