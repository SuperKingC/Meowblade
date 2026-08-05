using ProtoBuf;

namespace Shift.Legion.ClientApi.Protocol.UserAction;

[ProtoContract]
public class ProfileChangeNicknameResponse : IPacketBody
{
	[ProtoMember(1)]
	public bool Result { get; set; }

	[ProtoMember(999)]
	public int ErrorCode { get; set; }

	[ProtoMember(3)]
	public string CostItems { get; set; }

	[ProtoMember(4)]
	public string ValidNewNickName { get; set; }

	public string Message { get; set; }

	public int PacketId => PacketIds.USER_ACTION_PROFILE_CHANGE_NICKNAME;
}
