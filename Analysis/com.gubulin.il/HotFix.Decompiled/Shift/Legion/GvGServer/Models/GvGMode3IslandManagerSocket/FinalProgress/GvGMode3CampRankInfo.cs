using ProtoBuf;

namespace Shift.Legion.GvGServer.Models.GvGMode3IslandManagerSocket.FinalProgress;

[ProtoContract]
public class GvGMode3CampRankInfo
{
	[ProtoMember(1)]
	public int CampId;

	[ProtoMember(2)]
	public long RankData;

	[ProtoMember(3)]
	public int Rank;

	[ProtoMember(4)]
	public bool HasBegin;
}
