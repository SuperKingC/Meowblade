using ProtoBuf;

namespace Shift.Legion.ClientApi.Protocol.UserAction;

[ProtoContract]
public class StockChangedResponse : IPacketBody
{
	[ProtoMember(1)]
	public bool Result;

	[ProtoMember(2)]
	public long Tick;

	[ProtoMember(3)]
	public string Message;

	[ProtoMember(4)]
	public bool MoltenCoreStopProduce;

	[ProtoMember(5)]
	public StockChangeRecord[] NoPassRecords;

	public int PacketId => PacketIds.USER_ACTION_STOCK_CHANGED_REQUEST;
}
