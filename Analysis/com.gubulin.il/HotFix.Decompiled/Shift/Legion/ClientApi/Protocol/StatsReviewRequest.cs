using ProtoBuf;

namespace Shift.Legion.ClientApi.Protocol;

[ProtoContract]
public class StatsReviewRequest : IRequestPacket, IPacketBody
{
	[ProtoMember(99)]
	public int MsgIndex { get; set; }

	[ProtoMember(1)]
	public int Action { get; set; }

	[ProtoMember(2)]
	public string Channel { get; set; }

	public int PacketId => PacketIds.USER_ACTION_STATS_REVIEW_REQUEST;
}
