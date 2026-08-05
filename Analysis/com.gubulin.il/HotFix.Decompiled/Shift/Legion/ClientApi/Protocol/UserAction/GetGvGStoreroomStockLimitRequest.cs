using ProtoBuf;

namespace Shift.Legion.ClientApi.Protocol.UserAction;

[ProtoContract]
public class GetGvGStoreroomStockLimitRequest : IRequestPacket, IPacketBody
{
	[ProtoMember(99)]
	public int MsgIndex { get; set; }

	[ProtoMember(1)]
	public bool IsEvo { get; set; }

	public int PacketId => PacketIds.SER_ACTION_GET_GVG_STOREROOM_STOCK_LIMIT;
}
