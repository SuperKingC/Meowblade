using System.Collections.Generic;

namespace Shift.Legion.GvG.Common.Models.GvGMode3;

public class SkyIslandSettlementModel
{
	public Dictionary<int, List<GvGMode3PlayerRankInfo>> _campTotal;

	public Dictionary<int, SettlementCampRankData> _campTotalBossDamage;

	public bool IsDoubleChecked { get; set; }

	public string IZId { get; set; }

	public string IZConfigId { get; set; }

	public Dictionary<string, List<GvGMode3PlayerRankInfo>> CampTotal { get; set; }

	public List<GvGMode3PlayerRankInfo> Fighting { get; set; }

	public List<GvGMode3PlayerRankInfo> Collecting { get; set; }

	public List<GvGMode3PlayerRankInfo> ForgeAmplifier { get; set; }

	public List<GvGMode3PlayerRankInfo> BossDamageRankIZTotal { get; set; }

	public List<GvGMode3PlayerRankInfo> BossDailyDamageRankIZTotal { get; set; }

	public List<GvGMode3PlayerRankInfo> ShadowEnergy { get; set; }

	public Dictionary<string, SettlementCampRankData> CampTotalBossDamage { get; set; }

	public List<GvGMode3PlayerRankInfo> BrawlEventPlayerScoreRankIZTotal { get; set; }

	public List<GvGMode3PlayerRankInfo> BrawlEventPlayerWinRankIZTotal { get; set; }

	public Dictionary<int, List<GvGMode3PlayerRankInfo>> campTotal
	{
		get
		{
			if (_campTotal == null)
			{
				_campTotal = new Dictionary<int, List<GvGMode3PlayerRankInfo>>();
				foreach (KeyValuePair<string, List<GvGMode3PlayerRankInfo>> item in CampTotal)
				{
					_campTotal.Add(int.Parse(item.Key), item.Value);
				}
			}
			return _campTotal;
		}
	}

	public Dictionary<int, SettlementCampRankData> campTotalBossDamage
	{
		get
		{
			if (_campTotalBossDamage == null)
			{
				_campTotalBossDamage = new Dictionary<int, SettlementCampRankData>();
				foreach (KeyValuePair<string, SettlementCampRankData> item in CampTotalBossDamage)
				{
					_campTotalBossDamage.Add(int.Parse(item.Key), item.Value);
				}
			}
			return _campTotalBossDamage;
		}
	}
}
