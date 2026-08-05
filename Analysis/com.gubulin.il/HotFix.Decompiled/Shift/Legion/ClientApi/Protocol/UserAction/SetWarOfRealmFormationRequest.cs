using ProtoBuf;
using Shift.Legion.ClientApi.Models;

namespace Shift.Legion.ClientApi.Protocol.UserAction;

[ProtoContract]
public class SetWarOfRealmFormationRequest : IRequestPacket, IPacketBody
{
	public int PacketId => PacketIds.USER_ACTION_SET_WAROFREALM_FORMATION_REQUEST;

	[ProtoMember(99)]
	public int MsgIndex { get; set; }

	[ProtoMember(1, TypeName = "Shift.Legion.ClientApi.Models.WarOfRealmConfig")]
	public WarOfRealmConfig Formation { get; set; }
}
