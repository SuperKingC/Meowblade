using FairyGUI;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Model;
using UI.PublicResources;

namespace HotFix.Sources.Base.Sources.Scripts.GvG3UI.Helper;

internal static class RenderHelper_AmpAffectedRange
{
	public static void RenderAmplifierAffectedRange(GComponent comp, AmplifierModel ampConfig)
	{
		UI_com_AmpAffectedRange uI_com_AmpAffectedRange = (UI_com_AmpAffectedRange)(object)comp;
		bool flag = string.IsNullOrEmpty(ampConfig.AffectedSoldier);
		uI_com_AmpAffectedRange.IsShowRace.selectedIndex = (flag ? 1 : 0);
		if (flag)
		{
			RenderHelper_RaceTypeIcon.RenderAmplifierAffectedRace((GComponent)(object)uI_com_AmpAffectedRange.RaceType, ampConfig);
		}
		else
		{
			RenderHelper_SimpleSquareSoldier.RenderAmplifierAffectedSoldier((GComponent)(object)uI_com_AmpAffectedRange.AffectedSoldier, ampConfig);
		}
	}

	public static void RenderAmplifierAffectedSoldier(GComponent comp, int idx)
	{
		AmplifierModel ampConfig = AmpConfigHelper.Configs.TryGetNormalAmplifier(idx);
		RenderAmplifierAffectedRange(comp, ampConfig);
	}
}
