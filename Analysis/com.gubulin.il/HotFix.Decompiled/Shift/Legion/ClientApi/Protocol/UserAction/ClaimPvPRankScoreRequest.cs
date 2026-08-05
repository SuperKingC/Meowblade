using ProtoBuf;

namespace Shift.Legion.ClientApi.Protocol.UserAction;

[ProtoContract]
public class ClaimPvPRankScoreRequest : IRequestPacket, IPacketBody
{
	[ProtoMember(1)]
	public long Tick;

	[ProtoMember(99)]
	public int MsgIndex { get; set; }

	public int PacketId => PacketIds.USER_ACTION_CLAIM_PVP_RANK_SCORE_REQUEST;
}
