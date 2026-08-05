using System.Collections.Generic;
using ProtoBuf;

namespace Shift.Legion.GvG.Common.Models.GvGMode3;

[ProtoContract]
public class GvGMode3PlayerRankInfo
{
	[ProtoMember(1)]
	public int UserId;

	[ProtoMember(2)]
	public long RankData;

	[ProtoMember(3)]
	public int CampId;

	[ProtoMember(4, TypeName = "Shift.Legion.GvG.Common.Models.GvGMode3.GvGMode3PlayerRankDataDetail")]
	public List<GvGMode3PlayerRankDataDetail> RankDataDetail;

	[ProtoMember(5)]
	public int Rank { get; set; }
}
