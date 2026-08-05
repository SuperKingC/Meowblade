using System.Collections.Generic;
using ProtoBuf;

namespace Shift.Legion.GvG.Common.Models.GvGMode3;

[ProtoContract]
public class GvGMode3LeaderboardData
{
	[ProtoMember(1)]
	public string BonusItemId = null;

	[ProtoMember(2)]
	public bool IsBonusClaimed = false;

	[ProtoMember(3)]
	public long MyRankData = 0L;

	[ProtoMember(4)]
	public int MyRanking;

	[ProtoMember(5, TypeName = "Shift.Legion.GvG.Common.Models.GvGMode3.GvGMode3PlayerRankInfo")]
	public List<GvGMode3PlayerRankInfo> RankList = new List<GvGMode3PlayerRankInfo>();

	[ProtoMember(6)]
	public int ListMaxCount;

	[ProtoMember(7, TypeName = "Shift.Legion.GvG.Common.Models.GvGMode3.GvGMode3PlayerRankInfo")]
	public GvGMode3PlayerRankInfo MyBrawlEventRankData;
}
