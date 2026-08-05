using ProtoBuf;

namespace Shift.Legion.ClientApi.Protocol.UserAction;

[ProtoContract]
public class ChangeFormationResponse : IPacketBody
{
	[ProtoMember(1)]
	public bool Result;

	[ProtoMember(999)]
	public int ErrorCode { get; set; }

	public int PacketId => PacketIds.USER_ACTION_CHANGE_FORMATION_REQUEST;
}
