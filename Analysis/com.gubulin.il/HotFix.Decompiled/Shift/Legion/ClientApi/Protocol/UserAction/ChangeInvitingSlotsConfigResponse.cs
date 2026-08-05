using ProtoBuf;

namespace Shift.Legion.ClientApi.Protocol.UserAction;

[ProtoContract]
public class ChangeInvitingSlotsConfigResponse : IPacketBody
{
	[ProtoMember(1)]
	public bool Result;

	[ProtoMember(2)]
	public string Message;

	public int PacketId => PacketIds.USER_ACTION_CHANGE_INVITING_SLOTS_CONFIG;
}
