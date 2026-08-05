using Shift.Legion.GvG.Common.Models.GvGMode3;
using Shift.Legion.GvG.Common.Models.GvGMode3.BrawlEvent;

namespace HotFix.Sources.Base.Sources.Scripts.GvG3.GvG3UI.Model.SystemMessageParser;

public class BrawlCampRankInfos
{
	public int BrawlDay { get; set; }

	public GvGMode3PlayerRankInfo PlayerRankInfo { get; set; }

	public BrawlEventRankRewardsConfig RankRewardsConfig { get; set; }
}
