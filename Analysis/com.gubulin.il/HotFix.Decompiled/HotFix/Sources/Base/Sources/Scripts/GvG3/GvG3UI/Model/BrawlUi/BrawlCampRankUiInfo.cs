using FairyGUI;
using HotFix.Sources.Base.Sources.Scripts.GvG3.GvG3UI.Interface.Brawl;
using Shift.Legion.GvG.Common.Models.GvGMode3.BrawlEvent;

namespace HotFix.Sources.Base.Sources.Scripts.GvG3.GvG3UI.Model.BrawlUi;

public class BrawlCampRankUiInfo : IBrawlRankUiInfo
{
	public int Progress { get; }

	public int RankType { get; }

	public int HasScore { get; }

	public bool HasExtraScorePar { get; }

	public long RankScore { get; }

	public int ShipRace { get; }

	public int Rank { get; }

	public void DisplayBuffInfo(EventContext context)
	{
	}

	public BrawlCampRankUiInfo(BrawlEventSettleInfo info, int progress)
	{
		Progress = progress;
		RankType = 1;
		HasScore = ((info.CampRank > 0) ? 1 : 0);
		HasExtraScorePar = info.HasExtraScorePar;
		ShipRace = info.ShipRace;
		RankScore = info.CampScore;
		Rank = info.CampRank;
	}
}
