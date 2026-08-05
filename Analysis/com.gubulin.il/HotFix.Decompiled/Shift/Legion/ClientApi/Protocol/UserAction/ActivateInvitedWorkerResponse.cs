using ProtoBuf;

namespace Shift.Legion.ClientApi.Protocol.UserAction;

[ProtoContract]
public class ActivateInvitedWorkerResponse : IPacketBody
{
	[ProtoMember(1)]
	public bool Result;

	[ProtoMember(2)]
	public string Message;

	public int PacketId => PacketIds.USER_ACTION_ACTIVATE_INVITED_WORKER;
}
