using ProtoBuf;

namespace Shift.Legion.ClientApi.Protocol.UserAction;

[ProtoContract]
public class ModifyFriendsApplyResponse : IPacketBody
{
	[ProtoMember(1)]
	public bool Result { get; set; }

	[ProtoMember(999)]
	public int ErrorCode { get; set; }

	public string Message { get; set; }

	public int PacketId => PacketIds.USER_ACTION_MODIFY_FRIENDS_APPLY;
}
