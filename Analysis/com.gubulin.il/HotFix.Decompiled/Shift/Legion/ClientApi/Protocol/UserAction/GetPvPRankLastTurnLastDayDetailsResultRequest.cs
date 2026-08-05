using ProtoBuf;

namespace Shift.Legion.ClientApi.Protocol.UserAction;

[ProtoContract]
public class GetPvPRankLastTurnLastDayDetailsResultRequest : IRequestPacket, IPacketBody
{
	[ProtoMember(99)]
	public int MsgIndex { get; set; }

	[ProtoMember(1)]
	public string BattleId { get; set; }

	public int PacketId => PacketIds.USER_ACTION_GET_PVP_RANK_LAST_TURN_LAST_DAY_DETAILS_RESULT_REQUEST;
}
