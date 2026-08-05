using ProtoBuf;

namespace Shift.Legion.ClientApi.Protocol.UserAction;

[ProtoContract]
public class GetPvPTopTournamentRecordSinglePlayerRequest : IRequestPacket, IPacketBody
{
	[ProtoMember(99)]
	public int MsgIndex { get; set; }

	[ProtoMember(1)]
	public int Day { get; set; }

	[ProtoMember(2)]
	public int UserId { get; set; }

	public int PacketId => PacketIds.USER_ACTION_GET_PVP_TOP_TOURNAMENT_RECORD_SINGLE_PLAYER_REQUEST;
}
