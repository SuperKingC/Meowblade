using ProtoBuf;

namespace Shift.Legion.ClientApi.Protocol;

[ProtoContract]
public class LoginResponse : IPacketBody
{
	[ProtoMember(1)]
	public User User { get; set; }

	[ProtoMember(3)]
	public int VerifyStatus { get; set; }

	[ProtoMember(4)]
	public bool RequireDeviceInfo { get; set; }

	[ProtoMember(5)]
	public string CredentialsTypeStr { get; set; }

	public int PacketId => PacketIds.USER_LOGIN_REQUEST;
}
