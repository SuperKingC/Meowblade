using ProtoBuf;

namespace Shift.Legion.GvG.Common.Models.GvGMode3;

[ProtoContract]
public class GvGMode3IslandRankInfo
{
	[ProtoMember(1)]
	public int UserId;

	[ProtoMember(2)]
	public long Data;

	[ProtoMember(3)]
	public int CampId;
}
