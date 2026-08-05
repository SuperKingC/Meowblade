using ProtoBuf;

namespace Shift.Legion.GvGServer.Models.GvGMode3IslandManagerSocket;

[ProtoContract]
public class ShipCanDestroyStatus
{
	[ProtoMember(1)]
	public string ShipId;

	[ProtoMember(2)]
	public int ErrorCode;
}
