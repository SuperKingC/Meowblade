using ProtoBuf;

namespace Shift.Legion.ClientApi.Protocol.UserAction;

[ProtoContract]
public class GetGvGMedalRecordResponse : IPacketBody
{
	[ProtoMember(1)]
	public string JsonGvGMedalRecord { get; set; }

	[ProtoMember(999)]
	public int ErrorCode { get; set; }

	public int PacketId => PacketIds.USER_ACTION_GVGMEDALRECORD_REQUEST;
}
