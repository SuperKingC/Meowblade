using FairyGUI;

namespace HotFix.Sources.Base.Sources.Scripts.GvG3.GvG3UI.Interface.Brawl;

public interface IBrawlRankUiInfo
{
	int Progress { get; }

	int RankType { get; }

	int HasScore { get; }

	bool HasExtraScorePar { get; }

	long RankScore { get; }

	int ShipRace { get; }

	int Rank { get; }

	void DisplayBuffInfo(EventContext context);
}
