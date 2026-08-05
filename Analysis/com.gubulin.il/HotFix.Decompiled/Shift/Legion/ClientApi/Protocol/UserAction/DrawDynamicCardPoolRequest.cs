using ProtoBuf;

namespace Shift.Legion.ClientApi.Protocol.UserAction;

[ProtoContract]
public class DrawDynamicCardPoolRequest : IRequestPacket, IPacketBody
{
	[ProtoMember(1)]
	public long Tick;

	[ProtoMember(2)]
	public string ActivityId;

	[ProtoMember(3)]
	public string DrawOption;

	[ProtoMember(4)]
	public int CostOption;

	[ProtoMember(99)]
	public int MsgIndex { get; set; }

	public int PacketId => PacketIds.USER_ACTION_DRAW_CARDPOOL_ACTIVITY_REQUEST;
}
