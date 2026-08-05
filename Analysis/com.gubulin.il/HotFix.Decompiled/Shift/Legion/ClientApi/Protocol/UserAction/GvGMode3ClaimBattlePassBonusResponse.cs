using System.Collections.Generic;
using ProtoBuf;

namespace Shift.Legion.ClientApi.Protocol.UserAction;

[ProtoContract]
public class GvGMode3ClaimBattlePassBonusResponse : IPacketBody
{
	[ProtoMember(3, TypeName = "Shift.Legion.ClientApi.Protocol.UserAction.StockChangeRecord")]
	public List<StockChangeRecord> StockChangeRecords;

	[ProtoMember(1)]
	public bool Result { get; set; }

	[ProtoMember(999)]
	public int ErrorCode { get; set; }

	[ProtoMember(2)]
	public string BattlePassClaimedBonus { get; set; }

	public int PacketId => PacketIds.USER_ACTION_GVGMODE3_CLAIM_BATTLE_PASS_BONUS;
}
