using System.Collections.Generic;
using Shift.Legion.GvG.Common.Models;

namespace HotFix.Sources.Base.Sources.Scripts.GvG3.GvG3UI.UI.GvGWorldMapPanel.Model;

public static class SweepRewardExtension
{
	public static List<RItem> ToRItems(this SweepReward reward)
	{
		return reward.DisplayBonus.ToRItemList();
	}
}
