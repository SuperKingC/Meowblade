using ProtoBuf;

namespace Shift.Legion.GvGServer.Models.GvGMode3IslandManagerSocket.FlagShip;

[ProtoContract]
public class CampUserInfo
{
	[ProtoMember(1)]
	public int UserId;

	[ProtoMember(2)]
	public int ShipCount;
}
