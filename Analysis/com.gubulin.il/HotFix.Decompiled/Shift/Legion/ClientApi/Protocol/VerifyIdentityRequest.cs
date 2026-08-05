using ProtoBuf;

namespace Shift.Legion.ClientApi.Protocol;

[ProtoContract]
public class VerifyIdentityRequest : IRequestPacket, IPacketBody
{
	[ProtoMember(99)]
	public int MsgIndex { get; set; }

	[ProtoMember(1)]
	public string IdNumber { get; set; }

	[ProtoMember(2)]
	public string Name { get; set; }

	public int PacketId => PacketIds.USER_VERIFY_IDENTITY_REQUEST;
}
