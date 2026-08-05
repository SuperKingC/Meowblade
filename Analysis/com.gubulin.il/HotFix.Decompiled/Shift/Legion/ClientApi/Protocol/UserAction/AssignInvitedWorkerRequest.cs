using ProtoBuf;

namespace Shift.Legion.ClientApi.Protocol.UserAction;

[ProtoContract]
public class AssignInvitedWorkerRequest : IRequestPacket, IPacketBody
{
	[ProtoMember(1)]
	public int WorkerUserId;

	[ProtoMember(2)]
	public int SlotIndex;

	[ProtoMember(3)]
	public string BuildingType;

	[ProtoMember(4)]
	public int WorkbenchIndex;

	[ProtoMember(99)]
	public int MsgIndex { get; set; }

	public int PacketId => PacketIds.USER_ACTION_ASSIGN_INVITED_WORKER;
}
