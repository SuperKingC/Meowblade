using ProtoBuf;

namespace Shift.Legion.ClientApi.Protocol;

[ProtoContract]
public class VerifyIdentityBilibiliRequest : IRequestPacket, IPacketBody
{
	[ProtoMember(99)]
	public int MsgIndex { get; set; }

	[ProtoMember(1)]
	public string AccessKey { get; set; }

	public int PacketId => PacketIds.USER_VERIFY_IDENTIFY_BILIBILI_REQUEST;
}
