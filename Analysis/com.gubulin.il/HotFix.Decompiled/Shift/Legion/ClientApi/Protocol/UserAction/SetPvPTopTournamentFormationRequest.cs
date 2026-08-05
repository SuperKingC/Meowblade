using ProtoBuf;
using Shift.Legion.ClientApi.Models;

namespace Shift.Legion.ClientApi.Protocol.UserAction;

[ProtoContract]
public class SetPvPTopTournamentFormationRequest : IRequestPacket, IPacketBody
{
	[ProtoMember(1, TypeName = "Shift.Legion.ClientApi.Models.RankBattleTopTournamentConfig")]
	public RankBattleTopTournamentConfig Formation;

	[ProtoMember(2)]
	public bool Weekend;

	[ProtoMember(99)]
	public int MsgIndex { get; set; }

	public int PacketId => PacketIds.USER_ACTION_SET_PVP_TOP_TOURNAMENT_FORMATION_REQUEST;
}
