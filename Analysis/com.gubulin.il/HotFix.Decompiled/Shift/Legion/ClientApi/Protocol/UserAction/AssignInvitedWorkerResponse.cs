using ProtoBuf;

namespace Shift.Legion.ClientApi.Protocol.UserAction;

[ProtoContract]
public class AssignInvitedWorkerResponse : IPacketBody
{
	[ProtoMember(1)]
	public bool Result;

	[ProtoMember(2)]
	public string Message;

	public int PacketId => PacketIds.USER_ACTION_ASSIGN_INVITED_WORKER;
}
