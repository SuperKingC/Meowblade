using ProtoBuf;

namespace Shift.Legion.ClientApi.Protocol.UserAction;

[ProtoContract]
public class ClaimDynamicActivityLTTRRequest : IRequestPacket, IPacketBody
{
	[ProtoMember(99)]
	public int MsgIndex { get; set; }

	[ProtoMember(1)]
	public string ActivityId { get; set; }

	[ProtoMember(2)]
	public int RMB_Level { get; set; }

	public int PacketId => PacketIds.USER_ACTION_CLAIM_DYNAMIC_ACTIVITY_LTTR_REQUEST;
}
