using ProtoBuf;

namespace Shift.Legion.ClientApi.Protocol;

[ProtoContract]
public class UserProfileAvatar
{
	[ProtoMember(1)]
	public byte[] AvatarData;
}
