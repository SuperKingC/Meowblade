using ProtoBuf;

namespace Shift.Legion.ClientApi.Protocol.UserAction;

[ProtoContract]
public class GetTotalRecycleExportRequestResponse : IPacketBody
{
	[ProtoMember(1)]
	public long Tick;

	[ProtoMember(2)]
	public bool Result;

	[ProtoMember(3)]
	public string Message;

	[ProtoMember(4)]
	public int RequestCnt;

	public int PacketId => PacketIds.USER_ACTION_GET_TOTAL_EXPORT_REQUEST;
}
