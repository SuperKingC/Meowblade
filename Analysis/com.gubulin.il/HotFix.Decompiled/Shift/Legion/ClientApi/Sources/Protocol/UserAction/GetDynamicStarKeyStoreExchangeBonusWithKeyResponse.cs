using System.Collections.Generic;
using ProtoBuf;
using Shift.Legion.ClientApi.Protocol;
using Shift.Legion.ClientApi.Protocol.UserAction;

namespace Shift.Legion.ClientApi.Sources.Protocol.UserAction;

[ProtoContract]
public class GetDynamicStarKeyStoreExchangeBonusWithKeyResponse : IPacketBody
{
	[ProtoMember(1, TypeName = "Shift.Legion.ClientApi.Protocol.UserAction.StockChangeRecord")]
	public List<StockChangeRecord> StockChangeRecords;

	[ProtoMember(999)]
	public int ErrorCode { get; set; }

	public int PacketId => PacketIds.USER_ACTION_GET_ACTIVITY_EXCHANGEBONUSWITHKEY_REQUEST;
}
