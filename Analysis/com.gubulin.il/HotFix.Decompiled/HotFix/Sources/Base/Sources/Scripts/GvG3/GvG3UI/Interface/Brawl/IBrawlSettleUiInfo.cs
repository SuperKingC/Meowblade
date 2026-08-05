using System.Collections.Generic;
using HotFix.Sources.Base.Sources.Scripts.GvG3.GvG3UI.Model.BrawlUi;

namespace HotFix.Sources.Base.Sources.Scripts.GvG3.GvG3UI.Interface.Brawl;

public interface IBrawlSettleUiInfo
{
	IBrawlIslandUiInfo IslandInfo { get; }

	Dictionary<BrawlRankType, IBrawlRankUiInfo> RankUiInfos { get; }

	Dictionary<BrawlSettleBonusUiType, IBrawlBonusUiInfo> Bonuses { get; }

	int Progress { get; }

	int IslandId { get; }

	int UserRank { get; }
}
