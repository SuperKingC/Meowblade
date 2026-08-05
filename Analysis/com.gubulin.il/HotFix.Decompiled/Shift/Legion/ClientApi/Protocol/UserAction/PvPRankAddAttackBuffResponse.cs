using ProtoBuf;

namespace Shift.Legion.ClientApi.Protocol.UserAction;

[ProtoContract]
public class PvPRankAddAttackBuffResponse : IPacketBody
{
	[ProtoMember(1)]
	public bool Result;

	[ProtoMember(3)]
	public int AttackBuffCnt;

	[ProtoMember(999)]
	public int ErrorCode { get; set; }

	[ProtoMember(4)]
	public StockChangeRecord[] CostRecords { get; set; }

	public int PacketId => PacketIds.USER_ACTION_RANK_ADD_ATTACK_BUFF;
}
