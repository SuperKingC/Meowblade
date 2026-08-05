using ProtoBuf;

namespace Shift.Legion.ClientApi.Protocol.UserAction;

[ProtoContract]
public class GvGMode3BuildShipRequest : IRequestPacket, IPacketBody
{
	[ProtoMember(99)]
	public int MsgIndex { get; set; }

	[ProtoMember(1)]
	public string ShipRace { get; set; }

	[ProtoMember(2)]
	public int Workers { get; set; }

	[ProtoMember(3)]
	public bool FastBuild { get; set; }

	public int PacketId => PacketIds.USER_ACTION_GVGMODE3_BUILD_SHIP;
}
