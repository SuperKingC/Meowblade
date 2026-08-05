using ProtoBuf;

namespace Shift.Legion.ClientApi.Protocol.UserAction;

[ProtoContract]
public class UnlockFormationResponse : IPacketBody
{
	[ProtoMember(1)]
	public bool Result;

	[ProtoMember(2)]
	public string Message;

	[ProtoMember(3)]
	public long Tick;

	public int PacketId => PacketIds.USER_ACTION_UNLOCK_FORMATION_REQUEST;
}
