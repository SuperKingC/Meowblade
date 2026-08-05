using ProtoBuf;

namespace Shift.Legion.GvGServer.Models.GvGMode3IslandManagerSocket;

[ProtoContract]
public class IslandDataVersionModel
{
	[ProtoMember(1)]
	public int IslandId;

	[ProtoMember(2)]
	public int Num;
}
