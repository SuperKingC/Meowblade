using ProtoBuf;

namespace Shift.Legion.ClientApi.Protocol.UserAction;

[ProtoContract]
public class GetUserProfileUrlResponse : IPacketBody
{
	[ProtoMember(1)]
	public string UserProfilePath { get; set; }

	public int PacketId => PacketIds.USER_ACTION_GET_USER_PROFILE_URL;
}
