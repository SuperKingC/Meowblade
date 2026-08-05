using ProtoBuf;

namespace Shift.Legion.ClientApi.Protocol.UserAction;

[ProtoContract]
public class QQClaimDawankaRequest : IRequestPacket, IPacketBody
{
	[ProtoMember(99)]
	public int MsgIndex { get; set; }

	[ProtoMember(1)]
	public string OpenId { get; set; }

	[ProtoMember(2)]
	public string OpenKey { get; set; }

	[ProtoMember(3)]
	public string Pf { get; set; }

	[ProtoMember(4)]
	public int Level { get; set; }

	public int PacketId => PacketIds.USER_ACTION_QQ_CLAIM_DAWANKA_REQUEST;
}
