using ProtoBuf;

namespace Shift.Legion.ClientApi.Protocol;

[ProtoContract]
public class GetServerStatusResponse : IPacketBody
{
	[ProtoMember(1)]
	public bool Result;

	[ProtoMember(10)]
	public int Status;

	[ProtoMember(999)]
	public int ErrorCode { get; set; }

	public int PacketId => PacketIds.GET_SERVER_STATUS_REQUEST;
}
