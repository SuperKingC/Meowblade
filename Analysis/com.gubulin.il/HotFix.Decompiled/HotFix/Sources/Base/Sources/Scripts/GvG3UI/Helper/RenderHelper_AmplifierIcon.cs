using FairyGUI;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Model;
using UI.PublicResources;

namespace HotFix.Sources.Base.Sources.Scripts.GvG3UI.Helper;

internal static class RenderHelper_AmplifierIcon
{
	public static void RenderAmplifier(GComponent comp, int idx)
	{
		UI_com_AmplifierIcon uI_com_AmplifierIcon = (UI_com_AmplifierIcon)(object)comp;
		AmplifierModel amplifierModel = AmpConfigHelper.Configs.TryGetNormalAmplifier(idx);
		uI_com_AmplifierIcon.PropIcon.url = "ui://PublicResourcesRGB/" + amplifierModel.Icon;
		uI_com_AmplifierIcon.QualityFrame.url = $"ui://PublicResourcesRGB/Amp_Quality_{amplifierModel.Quality}";
	}

	public static void RenderAmplifier(GComponent comp, AmplifierModel ampConfig)
	{
		UI_com_AmplifierIcon uI_com_AmplifierIcon = (UI_com_AmplifierIcon)(object)comp;
		uI_com_AmplifierIcon.PropIcon.url = "ui://PublicResourcesRGB/" + ampConfig.Icon;
		uI_com_AmplifierIcon.QualityFrame.url = $"ui://PublicResourcesRGB/Amp_Quality_{ampConfig.Quality}";
	}
}
