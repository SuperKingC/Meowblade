using ProtoBuf;

namespace Shift.Legion.ClientApi.Protocol.UserAction;

[ProtoContract]
public class ModifyFriendsApplyRequest : IRequestPacket, IPacketBody
{
	[ProtoMember(99)]
	public int MsgIndex { get; set; }

	[ProtoMember(1)]
	public int Id { get; set; }

	[ProtoMember(2)]
	public bool Agree { get; set; }

	public int PacketId => PacketIds.USER_ACTION_MODIFY_FRIENDS_APPLY;
}
