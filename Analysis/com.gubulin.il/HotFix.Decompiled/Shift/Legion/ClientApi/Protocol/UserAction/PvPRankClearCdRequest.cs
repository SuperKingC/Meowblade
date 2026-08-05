using ProtoBuf;

namespace Shift.Legion.ClientApi.Protocol.UserAction;

[ProtoContract]
public class PvPRankClearCdRequest : IRequestPacket, IPacketBody
{
	[ProtoMember(99)]
	public int MsgIndex { get; set; }

	[ProtoMember(1)]
	public int TargetUserId { get; set; }

	public int PacketId => PacketIds.USER_ACTION_RANK_CLEAR_CD;
}
