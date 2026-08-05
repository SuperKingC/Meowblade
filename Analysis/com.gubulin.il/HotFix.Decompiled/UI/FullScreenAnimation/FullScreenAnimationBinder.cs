using FairyGUI;

namespace UI.FullScreenAnimation;

public class FullScreenAnimationBinder
{
	public static void BindAll()
	{
		UIObjectFactory.SetPackageItemExtension("ui://huhayyi1d0ym5", typeof(UI_SummaryMissionReward));
		UIObjectFactory.SetPackageItemExtension("ui://huhayyi1h3uh0", typeof(UI_FullScreenAnimationPanel));
		UIObjectFactory.SetPackageItemExtension("ui://huhayyi1h3uh1", typeof(UI_ExchangeSoldiersPos));
	}
}
