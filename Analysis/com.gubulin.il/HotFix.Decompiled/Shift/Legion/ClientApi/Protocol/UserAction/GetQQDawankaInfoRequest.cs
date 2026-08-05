using ProtoBuf;

namespace Shift.Legion.ClientApi.Protocol.UserAction;

[ProtoContract]
public class GetQQDawankaInfoRequest : IRequestPacket, IPacketBody
{
	[ProtoMember(99)]
	public int MsgIndex { get; set; }

	[ProtoMember(1)]
	public string OpenId { get; set; }

	[ProtoMember(2)]
	public string OpenKey { get; set; }

	[ProtoMember(3)]
	public string Pf { get; set; }

	public int PacketId => PacketIds.USER_ACTION_QQ_DAWANKA_INFO_REQUEST;
}
