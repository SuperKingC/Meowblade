using ProtoBuf;
using Shift.Legion.ClientApi.Models;

namespace Shift.Legion.ClientApi.Protocol.UserAction;

[ProtoContract]
public class GetPvPRankLastTurnLastDayDetailsResultResponse : IPacketBody
{
	[ProtoMember(1)]
	public bool Result;

	[ProtoMember(2)]
	public string Message;

	[ProtoMember(10)]
	public LevelBattleReplay Replay;

	[ProtoMember(999)]
	public int ErrorCode { get; set; }

	public int PacketId => PacketIds.USER_ACTION_GET_PVP_RANK_LAST_TURN_LAST_DAY_DETAILS_RESULT_REQUEST;
}
