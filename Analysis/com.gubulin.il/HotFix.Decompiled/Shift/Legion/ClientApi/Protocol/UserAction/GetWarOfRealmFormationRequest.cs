using ProtoBuf;

namespace Shift.Legion.ClientApi.Protocol.UserAction;

[ProtoContract]
public class GetWarOfRealmFormationRequest : IRequestPacket, IPacketBody
{
	public int PacketId => PacketIds.USER_ACTION_GET_WAROFREALM_FORMATION_REQUEST;

	[ProtoMember(99)]
	public int MsgIndex { get; set; }
}
