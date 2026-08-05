using ProtoBuf;

namespace Shift.Legion.ClientApi.Protocol.UserAction;

[ProtoContract]
public class ActivityReviewResponse : IPacketBody
{
	[ProtoMember(1)]
	public long Tick;

	[ProtoMember(2)]
	public bool Result;

	[ProtoMember(3)]
	public string Message;

	public int PacketId => PacketIds.USER_ACTION_ACTIVITIES_REVIEW_REQUEST;
}
