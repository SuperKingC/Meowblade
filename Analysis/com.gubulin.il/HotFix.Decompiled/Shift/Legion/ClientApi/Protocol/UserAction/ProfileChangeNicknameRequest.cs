using ProtoBuf;

namespace Shift.Legion.ClientApi.Protocol.UserAction;

[ProtoContract]
public class ProfileChangeNicknameRequest : IRequestPacket, IPacketBody
{
	[ProtoMember(1)]
	public string NewNickname;

	[ProtoMember(2)]
	public string OpenId;

	[ProtoMember(3)]
	public string OpenKey;

	[ProtoMember(4)]
	public string Pf;

	[ProtoMember(99)]
	public int MsgIndex { get; set; }

	public int PacketId => PacketIds.USER_ACTION_PROFILE_CHANGE_NICKNAME;
}
