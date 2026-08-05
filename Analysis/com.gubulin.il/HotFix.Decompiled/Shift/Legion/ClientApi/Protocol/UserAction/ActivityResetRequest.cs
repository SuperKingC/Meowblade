using ProtoBuf;

namespace Shift.Legion.ClientApi.Protocol.UserAction;

[ProtoContract]
public class ActivityResetRequest : IRequestPacket, IPacketBody
{
	[ProtoMember(1)]
	public long Tick;

	[ProtoMember(2)]
	public string ActivityId;

	[ProtoMember(99)]
	public int MsgIndex { get; set; }

	public int PacketId => PacketIds.USER_ACTION_ACTIVITY_RESET_REQUEST;
}
