using ProtoBuf;
using Shift.Legion.ClientApi.Models;

namespace Shift.Legion.ClientApi.Protocol.UserAction;

[ProtoContract]
public class GetPvPTopTournamentFormationResponse : IPacketBody
{
	[ProtoMember(1)]
	public bool Result;

	public string Message;

	[ProtoMember(3, TypeName = "Shift.Legion.ClientApi.Models.RankBattleTopTournamentConfig")]
	public RankBattleTopTournamentConfig CurFormation;

	[ProtoMember(4, TypeName = "Shift.Legion.ClientApi.Models.RankBattleTopTournamentConfig")]
	public RankBattleTopTournamentConfig WeekendFormation;

	[ProtoMember(999)]
	public int ErrorCode { get; set; }

	public int PacketId => PacketIds.USER_ACTION_GET_PVP_TOP_TOURNAMENT_FORMATION_REQUEST;
}
