using System.Collections.Generic;
using Shift.Legion.Common.Models;
using UI.AddCredit;
using UI.GiftBag;
using UI.MonthCard;
using UI.MtgGiftPacks;

namespace UI.BlackMarketer;

public class BlackMarketerPanelsSort
{
	private readonly Dictionary<string, int> _uiPanelIdx = new Dictionary<string, int>
	{
		{
			UI_GiftBagPanel.Name,
			1
		},
		{
			UI_MonthCardPanel.Name,
			2
		},
		{
			UI_MtgGiftPacksPanel.Name,
			3
		},
		{
			UI_BlackMarketerAddCredit.Name,
			4
		}
	};

	public void SortBlackMarketerActivities(List<Activity> activities)
	{
		if (activities != null && activities.Count != 0)
		{
			activities.Sort((Activity a, Activity b) => GetUiPanelIndex(a.UiName) - GetUiPanelIndex(b.UiName));
		}
	}

	public int GetUiPanelIndex(string uiName)
	{
		int value;
		return _uiPanelIdx.TryGetValue(uiName, out value) ? value : 0;
	}
}
