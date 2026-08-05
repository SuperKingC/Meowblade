using System.Collections.Generic;
using ProtoBuf;

namespace Shift.Legion.ClientApi.Protocol.UserAction;

[ProtoContract]
public class ClaimIslandComeAgainDailyMissionBonusResponse : IPacketBody
{
	[ProtoMember(999)]
	public int ErrorCode { get; set; }

	[ProtoMember(1, TypeName = "Shift.Legion.ClientApi.Protocol.UserAction.StockChangeRecord")]
	public List<StockChangeRecord> StockChangeRecords { get; set; }

	[ProtoMember(2)]
	public List<int> DailyMissionRecord { get; set; }

	public int PacketId => PacketIds.USER_ACTION_DYNAMIC_ACTIVITY_ISLAND_COME_AGAIN_CLAIM_MISSIONBONUS_REQUEST;
}
