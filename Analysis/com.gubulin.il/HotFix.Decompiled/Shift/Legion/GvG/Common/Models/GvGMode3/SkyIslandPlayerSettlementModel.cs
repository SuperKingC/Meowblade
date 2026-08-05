using System.Collections.Generic;
using Shift.Legion.GvG.Common.Models.GvGMode3.ObserverStat;
using Shift.Legion.Helpers;

namespace Shift.Legion.GvG.Common.Models.GvGMode3;

public class SkyIslandPlayerSettlementModel
{
	public bool CampRewardIsClaimed = false;

	public SkyIslandSettlement_AmplifierDetail AmplifierDetail;

	public bool AmplifierDetail_RewardIsClaimed;

	public Dictionary<int, SettlementCampRankData> _CampTotalRank_Dict;

	public Dictionary<eLeaderboardType, SettlementRankData> _selfRankDatas;

	public Dictionary<eLeaderboardType, SettlementRankData> _selfFinalProgressRankDatas;

	public Dictionary<eObserverStatKey, string> _observerStatData;

	private BestKillShip _BestKillShip;

	public bool IsDoubleChecked { get; set; }

	public int UserId { get; set; }

	public int CampId { get; set; }

	public int SettlementTimestamp { get; set; }

	public string IZShowName { get; set; }

	public string IZId { get; set; }

	public string IZConfigId { get; set; }

	public List<SettlementCampRankData> SettlementCampRankDatas { get; set; }

	public Dictionary<string, int> CampRankReward => CampTotalRankDict[CampId].Reward;

	public Dictionary<string, SettlementRankData> SelfRankDatas { get; set; } = new Dictionary<string, SettlementRankData>();

	public Dictionary<string, SettlementRankData> SelfFinalProgressRankDatas { get; set; } = new Dictionary<string, SettlementRankData>();

	public Dictionary<string, List<int>> GvGBattlePassRecord { get; set; } = new Dictionary<string, List<int>>();

	public bool GvGBattlePassRecordIsClosed { get; set; } = false;

	public float ContributionPoints { get; set; }

	public bool HasAdvancedPass { get; set; } = false;

	public bool HasPremiumPass { get; set; }

	public int BattlePassVersion { get; set; }

	public Dictionary<string, string> ObserverStatData { get; set; } = new Dictionary<string, string>();

	public List<SettlementTrophy> SettlementTrophies { get; set; } = new List<SettlementTrophy>();

	public int SelfRank { get; set; }

	public Dictionary<string, int> SoldierInShips { get; set; } = new Dictionary<string, int>();

	public Dictionary<string, int> ShipPlanRemainingSoldiers { get; set; } = new Dictionary<string, int>();

	public Dictionary<int, SettlementCampRankData> CampTotalRankDict
	{
		get
		{
			if (_CampTotalRank_Dict == null)
			{
				_CampTotalRank_Dict = new Dictionary<int, SettlementCampRankData>();
				foreach (SettlementCampRankData settlementCampRankData in SettlementCampRankDatas)
				{
					_CampTotalRank_Dict.Add(settlementCampRankData.CampId, settlementCampRankData);
				}
			}
			return _CampTotalRank_Dict;
		}
	}

	public Dictionary<eLeaderboardType, SettlementRankData> selfRankDatas
	{
		get
		{
			if (_selfRankDatas == null)
			{
				_selfRankDatas = new Dictionary<eLeaderboardType, SettlementRankData>();
				foreach (KeyValuePair<string, SettlementRankData> selfRankData in SelfRankDatas)
				{
					_selfRankDatas.Add((eLeaderboardType)int.Parse(selfRankData.Key), selfRankData.Value);
				}
			}
			return _selfRankDatas;
		}
	}

	public Dictionary<eLeaderboardType, SettlementRankData> selfFinalProgressRankDatas
	{
		get
		{
			if (_selfFinalProgressRankDatas == null)
			{
				_selfFinalProgressRankDatas = new Dictionary<eLeaderboardType, SettlementRankData>();
				foreach (KeyValuePair<string, SettlementRankData> selfFinalProgressRankData in SelfFinalProgressRankDatas)
				{
					_selfFinalProgressRankDatas.Add((eLeaderboardType)int.Parse(selfFinalProgressRankData.Key), selfFinalProgressRankData.Value);
				}
			}
			return _selfFinalProgressRankDatas;
		}
	}

	public Dictionary<eObserverStatKey, string> observerStatData
	{
		get
		{
			if (_observerStatData == null)
			{
				_observerStatData = new Dictionary<eObserverStatKey, string>();
				foreach (KeyValuePair<string, string> observerStatDatum in ObserverStatData)
				{
					_observerStatData.Add((eObserverStatKey)int.Parse(observerStatDatum.Key), observerStatDatum.Value);
				}
			}
			return _observerStatData;
		}
	}

	public bool IsSettlementBonusClaimed => CampRewardIsClaimed && IsSelfRankBonusClaimed && IsSelfFinalProgressRankBonusClaimed;

	public bool IsSelfRankBonusClaimed
	{
		get
		{
			bool flag = true;
			foreach (SettlementRankData value in SelfRankDatas.Values)
			{
				flag &= value.HasClaimed;
			}
			return flag;
		}
	}

	public bool IsSelfFinalProgressRankBonusClaimed
	{
		get
		{
			bool flag = true;
			foreach (SettlementRankData value in SelfFinalProgressRankDatas.Values)
			{
				flag &= value.HasClaimed;
			}
			return flag;
		}
	}

	public BestKillShip BestKillShip
	{
		get
		{
			if (_BestKillShip == null)
			{
				_BestKillShip = JsonHelper.ToObject<BestKillShip>(observerStatData[eObserverStatKey.BestKillShip]);
			}
			return _BestKillShip;
		}
	}
}
