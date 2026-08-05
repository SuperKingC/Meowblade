using ProtoBuf;

namespace Shift.Legion.ClientApi.Protocol.UserAction;

[ProtoContract]
public class GetQQInfoResponse : IPacketBody
{
	[ProtoMember(999)]
	public int ErrorCode { get; set; }

	[ProtoMember(1, TypeName = "Shift.Legion.ClientApi.Protocol.UserAction.QQGameRecord")]
	public QQGameRecord Record { get; set; }

	public int PacketId => PacketIds.USER_ACTION_QQ_INFO_REQUEST;
}
