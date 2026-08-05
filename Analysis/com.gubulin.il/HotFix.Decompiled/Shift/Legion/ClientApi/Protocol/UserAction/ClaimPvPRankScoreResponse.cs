using ProtoBuf;

namespace Shift.Legion.ClientApi.Protocol.UserAction;

[ProtoContract]
public class ClaimPvPRankScoreResponse : IPacketBody
{
	[ProtoMember(1)]
	public bool Result;

	[ProtoMember(3)]
	public int PvPRankScoreStock;

	[ProtoMember(4)]
	public int ClaimedScore;

	[ProtoMember(999)]
	public int ErrorCode { get; set; }

	public int PacketId => PacketIds.USER_ACTION_CLAIM_PVP_RANK_SCORE_REQUEST;
}
