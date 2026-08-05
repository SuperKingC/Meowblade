using ProtoBuf;

namespace Shift.Legion.ClientApi.Protocol.UserAction;

[ProtoContract]
public class GetUserProfileUrlRequest : IRequestPacket, IPacketBody
{
	[ProtoMember(99)]
	public int MsgIndex { get; set; }

	public int PacketId => PacketIds.USER_ACTION_GET_USER_PROFILE_URL;
}
