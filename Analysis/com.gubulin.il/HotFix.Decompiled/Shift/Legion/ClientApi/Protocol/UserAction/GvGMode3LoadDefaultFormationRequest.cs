using ProtoBuf;

namespace Shift.Legion.ClientApi.Protocol.UserAction;

[ProtoContract]
public class GvGMode3LoadDefaultFormationRequest : IRequestPacket, IPacketBody
{
	[ProtoMember(99)]
	public int MsgIndex { get; set; }

	[ProtoMember(1)]
	public int ShipRace { get; set; }

	public int PacketId => PacketIds.USER_ACTION_GVGMODE3_LOAD_DEFAULT_FORMATION;
}
