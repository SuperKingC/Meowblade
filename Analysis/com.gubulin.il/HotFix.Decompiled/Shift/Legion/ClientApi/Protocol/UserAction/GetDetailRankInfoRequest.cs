using ProtoBuf;

namespace Shift.Legion.ClientApi.Protocol.UserAction;

[ProtoContract]
public class GetDetailRankInfoRequest : IRequestPacket, IPacketBody
{
	[ProtoMember(1)]
	public long Tick;

	[ProtoMember(2)]
	public int Rank;

	[ProtoMember(99)]
	public int MsgIndex { get; set; }

	[ProtoMember(3)]
	public long LastBattleFinishAt { get; set; }

	public int PacketId => PacketIds.USER_ACTION_GET_DETAIL_RANK_INFO_REQUEST;
}
