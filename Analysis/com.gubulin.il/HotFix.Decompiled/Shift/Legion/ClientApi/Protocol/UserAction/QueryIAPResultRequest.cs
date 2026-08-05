using ProtoBuf;

namespace Shift.Legion.ClientApi.Protocol.UserAction;

[ProtoContract]
public class QueryIAPResultRequest : IRequestPacket, IPacketBody
{
	[ProtoMember(1)]
	public int OrderId;

	[ProtoMember(2)]
	public string TransactionId;

	[ProtoMember(3)]
	public string Receipt;

	[ProtoMember(99)]
	public int MsgIndex { get; set; }

	public int PacketId => PacketIds.QUERY_IAP_RESULT_REQUEST;
}
