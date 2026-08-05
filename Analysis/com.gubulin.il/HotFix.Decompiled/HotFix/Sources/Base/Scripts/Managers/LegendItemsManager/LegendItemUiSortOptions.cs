using Assets.Scripts.UI;

namespace HotFix.Sources.Base.Scripts.Managers.LegendItemsManager;

public class LegendItemUiSortOptions
{
	public LegendItemUi A { get; }

	public LegendItemUi B { get; }

	public LegendItemSortEnhanceLevelOption EnhanceLevelOption { get; }

	public LegendItemUiSortOptions(LegendItemUi a, LegendItemUi b, LegendItemSortEnhanceLevelOption enhanceLevelOption = LegendItemSortEnhanceLevelOption.MaxToMin)
	{
		A = a;
		B = b;
		EnhanceLevelOption = enhanceLevelOption;
	}
}
