using System.Collections.Generic;
using Shift.Legion.Helpers;

namespace HotFix.Sources.Base.Sources.Scripts.GvG3UI.Model;

public class CampProgressRedDot
{
	public int CampProgress { get; }

	public Dictionary<int, bool> MissionCanClaim { get; }

	public Dictionary<int, bool> RankCanClaim { get; }

	public CampProgressRedDot(int progress, string missionCanClaim, string rankCanClaim)
	{
		CampProgress = progress;
		MissionCanClaim = (string.IsNullOrEmpty(missionCanClaim) ? new Dictionary<int, bool>() : JsonHelper.ToObject<Dictionary<int, bool>>(missionCanClaim));
		RankCanClaim = (string.IsNullOrEmpty(rankCanClaim) ? new Dictionary<int, bool>() : JsonHelper.ToObject<Dictionary<int, bool>>(rankCanClaim));
	}

	public bool HasMainRedDot()
	{
		bool flag = false;
		foreach (bool value in MissionCanClaim.Values)
		{
			if (value)
			{
				flag = true;
				break;
			}
		}
		bool flag2 = false;
		foreach (bool value2 in RankCanClaim.Values)
		{
			if (value2)
			{
				flag2 = true;
				break;
			}
		}
		return flag || flag2;
	}

	public bool HasLastProgressRedDot()
	{
		bool flag = false;
		foreach (KeyValuePair<int, bool> item in MissionCanClaim)
		{
			if (item.Key < CampProgress && item.Value)
			{
				flag = true;
				break;
			}
		}
		bool flag2 = false;
		foreach (KeyValuePair<int, bool> item2 in RankCanClaim)
		{
			if (item2.Key < CampProgress && item2.Value)
			{
				flag2 = true;
				break;
			}
		}
		return flag || flag2;
	}

	public bool HasNextProgressRedDot()
	{
		bool flag = false;
		foreach (KeyValuePair<int, bool> item in MissionCanClaim)
		{
			if (item.Key > CampProgress && item.Value)
			{
				flag = true;
				break;
			}
		}
		bool flag2 = false;
		foreach (KeyValuePair<int, bool> item2 in RankCanClaim)
		{
			if (item2.Key > CampProgress && item2.Value)
			{
				flag2 = true;
				break;
			}
		}
		return flag || flag2;
	}
}
