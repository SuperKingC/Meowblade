namespace HotFix.Sources.Base.Sources.Scripts.GvG3.GvG3UI.Interface.Brawl;

public interface IBrawlIslandUiInfo
{
	string BrawlModeIcon { get; }

	string IslandName { get; }

	string MConfigId { get; }

	int IslandId { get; }

	int MUID { get; }

	int IslandSubType { get; }

	bool IsFinal { get; }
}
