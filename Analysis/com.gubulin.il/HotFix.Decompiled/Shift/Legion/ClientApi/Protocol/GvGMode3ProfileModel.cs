using ProtoBuf;

namespace Shift.Legion.ClientApi.Protocol;

[ProtoContract]
public class GvGMode3ProfileModel
{
	[ProtoMember(1)]
	public int UserId { get; set; }

	[ProtoMember(4, TypeName = " Shift.Legion.ClientApi.Protocol.UserProfile")]
	public UserProfile Profile { get; set; }

	[ProtoMember(5)]
	public int VersionNumber { get; set; }
}
