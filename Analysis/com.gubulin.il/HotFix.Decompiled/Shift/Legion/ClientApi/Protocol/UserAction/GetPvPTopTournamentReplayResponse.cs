using ProtoBuf;
using Shift.Legion.ClientApi.Models;

namespace Shift.Legion.ClientApi.Protocol.UserAction;

[ProtoContract]
public class GetPvPTopTournamentReplayResponse : IPacketBody
{
	[ProtoMember(1)]
	public bool Result;

	[ProtoMember(2)]
	public string Message;

	[ProtoMember(10, TypeName = "Shift.Legion.ClientApi.Models.LevelBattleReplay")]
	public LevelBattleReplay Replay;

	[ProtoMember(999)]
	public int ErrorCode { get; set; }

	public int PacketId => PacketIds.USER_ACTION_GET_PVP_TOP_TOURNAMENT_REPLAY_REQUEST;
}
