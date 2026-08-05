using ProtoBuf;

namespace Shift.Legion.ClientApi.Protocol.UserAction;

[ProtoContract]
public class SyncPendingReceiptsRequest : IRequestPacket, IPacketBody
{
	[ProtoMember(1)]
	public string ProductId;

	[ProtoMember(2)]
	public string Receipt;

	[ProtoMember(99)]
	public int MsgIndex { get; set; }

	public int PacketId => PacketIds.SYNC_PENDING_RECEIPTS_REQUEST;
}
