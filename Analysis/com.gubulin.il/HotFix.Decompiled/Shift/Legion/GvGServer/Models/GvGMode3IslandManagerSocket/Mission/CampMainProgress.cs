using ProtoBuf;

namespace Shift.Legion.GvGServer.Models.GvGMode3IslandManagerSocket.Mission;

[ProtoContract]
public class CampMainProgress
{
	[ProtoMember(1)]
	public int CampId;

	[ProtoMember(2)]
	public int Rank;

	[ProtoMember(3)]
	public int Progress;

	[ProtoMember(4)]
	public int Step;
}
