using Assets.Scripts.UI;
using FairyGUI;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Model;
using Shift.Legion.Common.Managers;
using Shift.Legion.Common.Models;
using UI.PublicResources;

namespace HotFix.Sources.Base.Sources.Scripts.GvG3UI.Helper;

internal static class RenderHelper_SimpleSquareSoldier
{
	public static void RenderSoldier(GComponent comp, string soldierId)
	{
		UI_com_SimpleSquareSoldier uI_com_SimpleSquareSoldier = (UI_com_SimpleSquareSoldier)(object)comp;
		string iconPath = UiHelper.GetIconPath(soldierId);
		uI_com_SimpleSquareSoldier.icon.icon.url = "ui://PublicResources/" + iconPath;
		Soldier soldier = GameManagers.Instance.SoldierManager.Get(soldierId);
		uI_com_SimpleSquareSoldier.PotentialLevel.selectedIndex = soldier.PotentialLevel;
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
