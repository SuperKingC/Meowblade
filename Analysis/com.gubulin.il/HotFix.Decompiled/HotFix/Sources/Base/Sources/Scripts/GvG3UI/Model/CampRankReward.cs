using System.Collections.Generic;
using Shift.Legion.GvGServer.Models.GvGMode3IslandManagerSocket.Mission;

namespace HotFix.Sources.Base.Sources.Scripts.GvG3UI.Model;

public class CampRankReward
{
	public int CampProgress;

	public List<CampMainProgress> MainProgress;

	public bool SelfClaimCampRankReward;

	public CampRankReward(int campProgress, List<CampMainProgress> mainProgress, bool selfClaimCampRankReward)
	{
		CampProgress = campProgress;
		SelfClaimCampRankReward = selfClaimCampRankReward;
		MainProgress = new List<CampMainProgress>();
		int i;
		for (i = 1; i < 5; i++)
		{
			MainProgress.Add(mainProgress.Find((CampMainProgress m) => m.CampId == i));
		}
	}
}
