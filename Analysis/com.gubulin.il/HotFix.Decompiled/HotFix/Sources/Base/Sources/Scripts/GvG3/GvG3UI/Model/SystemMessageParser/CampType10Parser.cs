using System.Collections.Generic;
using Shift.Legion.GvG.Common.Models.GvGMode3;
using Shift.Legion.GvG.Common.Models.GvGMode3.BrawlEvent;
using Shift.Legion.Helpers;

namespace HotFix.Sources.Base.Sources.Scripts.GvG3.GvG3UI.Model.SystemMessageParser;

public class CampType10Parser
{
	public BrawlCampRankInfos Parse(List<object> messageList)
	{
		if (messageList.Count != 4)
		{
			return null;
		}
		int brawlDay = (int)messageList[1];
		string json = (string)messageList[2];
		GvGMode3PlayerRankInfo playerRankInfo = JsonHelper.ToObject<GvGMode3PlayerRankInfo>(json);
		string json2 = (string)messageList[3];
		BrawlEventRankRewardsConfig rankRewardsConfig = JsonHelper.ToObject<BrawlEventRankRewardsConfig>(json2);
		return new BrawlCampRankInfos
		{
			BrawlDay = brawlDay,
			PlayerRankInfo = playerRankInfo,
			RankRewardsConfig = rankRewardsConfig
		};
	}
}
