using ProtoBuf;

namespace Shift.Legion.ClientApi.Protocol.UserAction;

[ProtoContract]
public class GetPvPRankLastTurnResultRequest : IRequestPacket, IPacketBody
{
	[ProtoMember(99)]
	public int MsgIndex { get; set; }

	[ProtoMember(1)]
	public int SeasonId { get; set; }

	[ProtoMember(2)]
	public int TurnId { get; set; }

	public int PacketId => PacketIds.USER_ACTION_GET_PVP_RANK_LAST_TURN_RESULT_REQUEST;
}
