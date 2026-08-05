using System.Collections.Generic;
using UnityEngine;

public static class GvGSingleBattleSoldierSummary_Extension
{
	public static void DeductOneTeam(this Dictionary<string, GvGSingleBattleSoldierSummary> summary, ref GvGSingleBattleInfo info)
	{
		foreach (KeyValuePair<string, GvGSingleBattleSoldierSummary> item in summary)
		{
			string key = item.Key;
			int num = Mathf.Min(item.Value.PerTeamMemberCnt, item.Value.Total);
			summary[key].Total -= num;
			info.AttackerSoilderSummary.Add(key, new GvGSingleBattleSoldierSummary
			{
				SoldierId = item.Value.SoldierId,
				SoldierLevel = item.Value.SoldierLevel,
				PotentialLevel = item.Value.PotentialLevel,
				PerTeamMemberCnt = item.Value.PerTeamMemberCnt
			});
		}
	}

	public static void Die(this Dictionary<string, GvGSingleBattleSoldierSummary> summary, int DeadCnt = -1)
	{
		foreach (KeyValuePair<string, GvGSingleBattleSoldierSummary> item in summary)
		{
			if (DeadCnt < 0)
			{
				summary[item.Key].Total = 0;
			}
			else
			{
				summary[item.Key].Total -= DeadCnt;
			}
		}
	}

	public static void DieRandom(this Dictionary<string, GvGSingleBattleSoldierSummary> summary)
	{
		foreach (KeyValuePair<string, GvGSingleBattleSoldierSummary> item in summary)
		{
			summary[item.Key].Total -= Random.Range(1, summary[item.Key].Total - 1);
		}
	}
}
