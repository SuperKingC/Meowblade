using ProtoBuf;

namespace Shift.Legion.ClientApi.Protocol;

[ProtoContract]
public class CheckReviewPointRequest : IRequestPacket, IPacketBody
{
	[ProtoMember(99)]
	public int MsgIndex { get; set; }

	[ProtoMember(1)]
	public string CredentialType { get; set; }

	[ProtoMember(2)]
	public string CredentialVal { get; set; }

	public int PacketId => PacketIds.USER_ACTION_CHECK_REVIEW_POINT_REQUEST;
}
