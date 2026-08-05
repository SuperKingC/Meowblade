using ProtoBuf;
using Shift.Legion.ClientApi.Protocol;

namespace Shift.Legion.ClientApi.Sources.Protocol.UserAction;

[ProtoContract]
public class ExchangeOuterTechRequest : IRequestPacket, IPacketBody
{
	[ProtoMember(99)]
	public int MsgIndex { get; set; }

	[ProtoMember(1)]
	public string ActivityId { get; set; }

	[ProtoMember(3)]
	public string ItemId { get; set; }

	public int PacketId => PacketIds.USER_ACTION_EXCHANGE_OUTERTECH_REQUEST;
}
