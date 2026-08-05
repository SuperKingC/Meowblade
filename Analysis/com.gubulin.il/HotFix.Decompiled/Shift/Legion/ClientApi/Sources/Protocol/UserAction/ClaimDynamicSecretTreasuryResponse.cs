using System.Collections.Generic;
using ProtoBuf;
using Shift.Legion.ClientApi.Protocol;
using Shift.Legion.ClientApi.Protocol.UserAction;

namespace Shift.Legion.ClientApi.Sources.Protocol.UserAction;

[ProtoContract]
public class ClaimDynamicSecretTreasuryResponse : IPacketBody
{
	[ProtoMember(999)]
	public int ErrorCode { get; set; }

	[ProtoMember(1, TypeName = "Shift.Legion.ClientApi.Protocol.UserAction.StockChangeRecord")]
	public List<StockChangeRecord> StockChangeRecords { get; set; }

	public int PacketId => PacketIds.USER_ACTION_CLAIM_ACTIVITY_SECRETTREASURY_RECHARGE_BONUS_REQUEST;
}
