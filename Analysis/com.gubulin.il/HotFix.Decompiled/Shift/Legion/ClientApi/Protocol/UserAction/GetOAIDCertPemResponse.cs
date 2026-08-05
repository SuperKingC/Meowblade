using ProtoBuf;

namespace Shift.Legion.ClientApi.Protocol.UserAction;

[ProtoContract]
public class GetOAIDCertPemResponse : IPacketBody
{
	[ProtoMember(99)]
	public bool Result { get; set; }

	[ProtoMember(1)]
	public string Key { get; set; }

	public string Message { get; set; }

	public int PacketId => PacketIds.USER_ACTION_GET_OAID_CERT_PEM;
}
