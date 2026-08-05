using ProtoBuf;

namespace Shift.Legion.ClientApi.Protocol.UserAction;

[ProtoContract]
public class PvPRankClearCdResponse : IPacketBody
{
	[ProtoMember(1)]
	public bool Result;

	[ProtoMember(999)]
	public int ErrorCode { get; set; }

	[ProtoMember(3)]
	public StockChangeRecord[] CostRecords { get; set; }

	public int PacketId => PacketIds.USER_ACTION_RANK_CLEAR_CD;
}
