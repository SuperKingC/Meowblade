using ProtoBuf;

namespace Shift.Legion.ClientApi.Protocol.UserAction;

[ProtoContract]
public class ExchangeSpinWeeklyRequest : IRequestPacket, IPacketBody
{
	[ProtoMember(99)]
	public int MsgIndex { get; set; }

	[ProtoMember(1)]
	public int Index { get; set; }

	[ProtoMember(2)]
	public int Repeat { get; set; }

	public int PacketId => PacketIds.USER_ACTION_EXCHANGE_SPINWEEKLY_REQUEST;
}
