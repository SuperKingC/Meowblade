using ProtoBuf;

namespace Shift.Legion.ClientApi.Protocol.UserAction;

[ProtoContract]
public class StockChangedRequest : IRequestPacket, IPacketBody
{
	[ProtoMember(1)]
	public long Tick;

	[ProtoMember(2, TypeName = "Shift.Legion.ClientApi.Protocol.UserAction.StockChangeRecord")]
	public StockChangeRecord[] Records;

	[ProtoMember(99)]
	public int MsgIndex { get; set; }

	public int PacketId => PacketIds.USER_ACTION_STOCK_CHANGED_REQUEST;
}
