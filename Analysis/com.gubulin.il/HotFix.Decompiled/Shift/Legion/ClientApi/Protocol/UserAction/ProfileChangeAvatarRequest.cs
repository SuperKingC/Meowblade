using ProtoBuf;

namespace Shift.Legion.ClientApi.Protocol.UserAction;

[ProtoContract]
public class ProfileChangeAvatarRequest : IRequestPacket, IPacketBody
{
	[ProtoMember(1)]
	public byte[] NewAvatarData132;

	[ProtoMember(2)]
	public byte[] NewAvatarData450;

	[ProtoMember(99)]
	public int MsgIndex { get; set; }

	public int PacketId => PacketIds.USER_ACTION_PROFILE_CHANGE_AVATAR;
}
