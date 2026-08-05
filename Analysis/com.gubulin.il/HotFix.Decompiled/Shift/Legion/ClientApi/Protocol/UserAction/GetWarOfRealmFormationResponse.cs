using ProtoBuf;
using Shift.Legion.ClientApi.Models;

namespace Shift.Legion.ClientApi.Protocol.UserAction;

[ProtoContract]
public class GetWarOfRealmFormationResponse : IPacketBody
{
	public int PacketId => PacketIds.USER_ACTION_GET_WAROFREALM_FORMATION_REQUEST;

	[ProtoMember(999)]
	public int ErrorCode { get; set; }

	[ProtoMember(1, TypeName = "Shift.Legion.ClientApi.Models.WarOfRealmConfig")]
	public WarOfRealmConfig Formation { get; set; }
}
