using ProtoBuf;

namespace Shift.Legion.ClientApi.Protocol.UserAction;

[ProtoContract]
public class InformWatchingPvPRankReplayRequest : IRequestPacket, IPacketBody
{
	[ProtoMember(99)]
	public int MsgIndex { get; set; }

	[ProtoMember(1)]
	public string BattleId { get; set; }

	public int PacketId => PacketIds.USER_ACTION_INFORM_WATCHING_PVP_RANK_REPLAY;
}
