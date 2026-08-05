using Assets.Scripts.UI;
using FairyGUI;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Model;
using UI.PublicResources;

namespace HotFix.Sources.Base.Sources.Scripts.GvG3UI.Helper;

internal static class RenderHelper_SimpleSolierIcon
{
	public static void RenderSoldier(GComponent comp, string soldierId)
	{
		UI_com_SimpleSolierIcon uI_com_SimpleSolierIcon = (UI_com_SimpleSolierIcon)(object)comp;
		string iconPath = UiHelper.GetIconPath(soldierId);
		uI_com_SimpleSolierIcon.icon.url = "ui://PublicResources/" + iconPath;
	}

	public static void RenderAmplifierAffectedSoldier(GComponent comp, AmplifierModel ampConfig)
	{
		RenderSoldier(comp, ampConfig.AffectedSoldier);
	}

	public static void RenderAmplifierAffectedSoldier(GComponent comp, int idx)
	{
		AmplifierModel amplifierModel = AmpConfigHelper.Configs.TryGetNormalAmplifier(idx);
		RenderSoldier(comp, amplifierModel.AffectedSoldier);
	}
}
