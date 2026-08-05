using ProtoBuf;

namespace Shift.Legion.ClientApi.Protocol;

[ProtoContract]
public class StatsTapTapReviewRequest : IRequestPacket, IPacketBody
{
	[ProtoMember(99)]
	public int MsgIndex { get; set; }

	[ProtoMember(1)]
	public string OpenId { get; set; }

	[ProtoMember(2)]
	public string Name { get; set; }

	public int PacketId => PacketIds.USER_ACTION_STATS_TAPTAP_REVIEW_REQUEST;
}
