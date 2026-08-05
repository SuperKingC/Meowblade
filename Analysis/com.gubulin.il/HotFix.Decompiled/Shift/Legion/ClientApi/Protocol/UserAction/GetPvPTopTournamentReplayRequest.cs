using ProtoBuf;

namespace Shift.Legion.ClientApi.Protocol.UserAction;

[ProtoContract]
public class GetPvPTopTournamentReplayRequest : IRequestPacket, IPacketBody
{
	[ProtoMember(1)]
	public string BattleId;

	[ProtoMember(99)]
	public int MsgIndex { get; set; }

	public int PacketId => PacketIds.USER_ACTION_GET_PVP_TOP_TOURNAMENT_REPLAY_REQUEST;
}
