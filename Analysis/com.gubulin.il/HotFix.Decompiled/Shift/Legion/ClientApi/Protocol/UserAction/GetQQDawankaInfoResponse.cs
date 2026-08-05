using ProtoBuf;

namespace Shift.Legion.ClientApi.Protocol.UserAction;

[ProtoContract]
public class GetQQDawankaInfoResponse : IPacketBody
{
	[ProtoMember(999)]
	public int ErrorCode { get; set; }

	[ProtoMember(1, TypeName = "Shift.Legion.ClientApi.Protocol.UserAction.QQDawankaInfo")]
	public QQDawankaInfo Info { get; set; }

	public int PacketId => PacketIds.USER_ACTION_QQ_DAWANKA_INFO_REQUEST;
}
