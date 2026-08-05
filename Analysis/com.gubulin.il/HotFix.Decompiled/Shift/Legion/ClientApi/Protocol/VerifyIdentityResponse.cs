using ProtoBuf;

namespace Shift.Legion.ClientApi.Protocol;

[ProtoContract]
public class VerifyIdentityResponse : IPacketBody
{
	[ProtoMember(1)]
	public bool Result { get; set; }

	[ProtoMember(2)]
	public string Message { get; set; }

	[ProtoMember(3)]
	public int VerifyStatus { get; set; }

	[ProtoMember(4)]
	public int Code { get; set; }

	[ProtoMember(5)]
	public int RemainVerifyCnt { get; set; }

	public int PacketId => PacketIds.USER_VERIFY_IDENTITY_REQUEST;
}
