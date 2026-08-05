using ProtoBuf;

namespace Shift.Legion.ClientApi.Protocol.UserAction;

[ProtoContract]
public class SetInvitedFromRequest : IRequestPacket, IPacketBody
{
	[ProtoMember(99)]
	public int MsgIndex { get; set; }

	[ProtoMember(1)]
	public string InvitingCode { get; set; }

	public int PacketId => PacketIds.USER_ACTION_SET_INVITED_FROM;
}
