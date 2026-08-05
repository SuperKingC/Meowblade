using FairyGUI;

namespace UI.Plot;

public class PlotBinder
{
	public static void BindAll()
	{
		UIObjectFactory.SetPackageItemExtension("ui://56axd6he8h2b0", typeof(UI_clickarea));
		UIObjectFactory.SetPackageItemExtension("ui://56axd6he8h2b2", typeof(UI_skip1));
		UIObjectFactory.SetPackageItemExtension("ui://56axd6he8h2b9", typeof(UI_PlotDialog));
		UIObjectFactory.SetPackageItemExtension("ui://56axd6hevl2ea", typeof(UI_PlotNpc));
	}
}
