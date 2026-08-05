using System.Collections.Generic;
using ProtoBuf;

namespace Shift.Legion.GvG.Common.Models.GvGMode3.BrawlEvent;

[ProtoContract]
public class ReviewResult
{
	[ProtoMember(1)]
	public int IslandId;

	[ProtoMember(2)]
	public int WinnerCamp;

	[ProtoMember(3, TypeName = "Shift.Legion.GvG.Common.Models.GvGMode3.BrawlEvent.CampSignUpInfo")]
	public List<CampSignUpInfo> CampSignUpInfos;

	[ProtoMember(4)]
	public int SignUpCountMax;

	[ProtoMember(5)]
	public int MissionSubType;

	[ProtoMember(7)]
	public int ReplayDuration;

	[ProtoMember(8, TypeName = "Shift.Legion.GvG.Common.Models.RItem")]
	public RItem FirstFinalReward;

	[ProtoMember(9)]
	public int MUID;

	[ProtoMember(10)]
	public string MConfigId;

	[ProtoMember(11)]
	public int MVPUserId;

	public int GetCampSignUpCount(int camp)
	{
		if (CampSignUpInfos == null)
		{
			return 0;
		}
		foreach (CampSignUpInfo campSignUpInfo in CampSignUpInfos)
		{
			if (campSignUpInfo.CampId == camp)
			{
				return campSignUpInfo.Cnt;
			}
		}
		return 0;
	}

	public bool HasBattleReplay()
	{
		return ReplayDuration > 0;
	}
}
