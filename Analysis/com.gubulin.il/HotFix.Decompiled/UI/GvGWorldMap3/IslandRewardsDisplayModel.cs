using System.Collections.Generic;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Model;

namespace UI.GvGWorldMap3;

public class IslandRewardsDisplayModel
{
	public IslandDisplayRewardType MainReward;

	public List<IslandDisplayReward> MainRewardList;

	public IslandDisplayRewardType RandomEventReward;

	public List<IslandDisplayReward> RandomEventRewardList;

	public int Count
	{
		get
		{
			int num = 0;
			if (MainRewardList != null)
			{
				num++;
			}
			if (RandomEventRewardList != null)
			{
				num++;
			}
			return num;
		}
	}

	public void Clear()
	{
		MainRewardList = null;
		RandomEventRewardList = null;
		MainReward = IslandDisplayRewardType.Empty;
		RandomEventReward = IslandDisplayRewardType.Empty;
	}
}
