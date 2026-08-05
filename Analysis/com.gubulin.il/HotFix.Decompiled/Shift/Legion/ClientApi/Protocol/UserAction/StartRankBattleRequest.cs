using ProtoBuf;

namespace Shift.Legion.ClientApi.Protocol.UserAction;

[ProtoContract]
public class StartRankBattleRequest : IRequestPacket, IPacketBody
{
	[ProtoMember(1)]
	public long Tick;

	[ProtoMember(99)]
	public int MsgIndex { get; set; }

	[ProtoMember(2)]
	public int TargetRank { get; set; }

	[ProtoMember(3)]
	public long LastBattleFinishAt { get; set; }

	[ProtoMember(4)]
	public bool ThumbnailMode { get; set; }

	public int PacketId => PacketIds.USER_ACTION_START_RANK_BATTLE_REQUEST;
}
