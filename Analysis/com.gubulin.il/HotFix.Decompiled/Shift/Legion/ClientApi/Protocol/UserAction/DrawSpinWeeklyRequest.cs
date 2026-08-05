using ProtoBuf;

namespace Shift.Legion.ClientApi.Protocol.UserAction;

[ProtoContract]
public class DrawSpinWeeklyRequest : IRequestPacket, IPacketBody
{
	[ProtoMember(99)]
	public int MsgIndex { get; set; }

	[ProtoMember(1)]
	public int DrawRepeat { get; set; }

	public int PacketId => PacketIds.USER_ACTION_DRAW_SPINWEEKLY_REQUEST;
}
