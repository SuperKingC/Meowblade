using System.Collections.Generic;
using ProtoBuf;

namespace Shift.Legion.ClientApi.Protocol.UserAction;

[ProtoContract]
public class QQClaimDawankaResponse : IPacketBody
{
	[ProtoMember(3, TypeName = "Shift.Legion.ClientApi.Protocol.UserAction.StockChangeRecord")]
	public List<StockChangeRecord> StockChangeRecords;

	[ProtoMember(999)]
	public int ErrorCode { get; set; }

	[ProtoMember(1, TypeName = "Shift.Legion.ClientApi.Protocol.UserAction.QQDawankaInfo")]
	public QQDawankaInfo Info { get; set; }

	[ProtoMember(2, TypeName = "Shift.Legion.ClientApi.Protocol.UserAction.QQGameRecord")]
	public QQGameRecord Record { get; set; }

	public int PacketId => PacketIds.USER_ACTION_QQ_CLAIM_DAWANKA_REQUEST;
}
