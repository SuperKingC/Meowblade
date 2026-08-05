using FairyGUI;

namespace UI.BlackMarketer;

public class BlackMarketerBinder
{
	public static void BindAll()
	{
		UIObjectFactory.SetPackageItemExtension("ui://036k96hravmf1k", typeof(UI_CardMonth));
		UIObjectFactory.SetPackageItemExtension("ui://036k96hric7j1l", typeof(UI_CardBasis));
		UIObjectFactory.SetPackageItemExtension("ui://036k96hrij812a", typeof(UI_WarOrderBtn));
		UIObjectFactory.SetPackageItemExtension("ui://036k96hrklbyx", typeof(UI_CardContract));
		UIObjectFactory.SetPackageItemExtension("ui://036k96hrklbyz", typeof(UI_CardDiamond));
		UIObjectFactory.SetPackageItemExtension("ui://036k96hrl2552k", typeof(UI_Title));
		UIObjectFactory.SetPackageItemExtension("ui://036k96hrlkzg0", typeof(UI_BlackMarketerPanel));
		UIObjectFactory.SetPackageItemExtension("ui://036k96hrlkzgv", typeof(UI_GiftBag));
		UIObjectFactory.SetPackageItemExtension("ui://036k96hrlkzgw", typeof(UI_CardLoader));
	}
}
