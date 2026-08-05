using ProtoBuf;

namespace Shift.Legion.ClientApi.Protocol.UserAction;

[ProtoContract]
public class ReviewInvitedWorkersRequest : IRequestPacket, IPacketBody
{
	[ProtoMember(1)]
	public int WorkerUserId;

	[ProtoMember(99)]
	public int MsgIndex { get; set; }

	public int PacketId => PacketIds.USER_ACTION_REVIEW_INVITED_WORKERS;
}
