using System.Collections.Generic;
using FairyGUI;
using HotFix.Sources.Base.Scripts.Helper;
using Shift.Legion.Common.Services;
using UI.LegendItemBlueprint;
using UI.LegendItems;

namespace UI.LegendItemCultivation;

public class TopTournamentLegendItemReminder
{
	private readonly string _tip = "UnequipTopTournamentLegendItemTip".ToLanguage();

	private const string _UN_EQUIP_TOP_TOURNAMENT_LEGEND_ITEM_TIP = "UnequipTopTournamentLegendItemTip";

	private readonly List<string> _needToCloseUis = new List<string>
	{
		UI_main_LegendItemBlueprintSelect.Name,
		UI_main_LegendItemBlueprintForge.Name,
		UI_LegendItemCultivationPanel.Name,
		UI_LegendItemsPanel.Name
	};

	public void RemindGoToUnEquip(string legendItemName)
	{
		string tipText = HotFix.Sources.Base.Scripts.Helper.StringExtensions.Format(_tip, legendItemName);
		tipText.ToConfirmPopup(GoToTopTournamentUi, Cancel, (AlignType)0);
	}

	private void GoToTopTournamentUi()
	{
		foreach (string needToCloseUi in _needToCloseUis)
		{
			GameController.Contexts.Service<IUiService>().ClosePanel(needToCloseUi);
		}
		SharedMessenger.Broadcast("OPEN_PVP_PANEL");
	}

	private static void Cancel()
	{
	}
}
