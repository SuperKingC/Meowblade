using ProtoBuf;

namespace Shift.Legion.ClientApi.Protocol.UserAction;

[ProtoContract]
public class GvGMode3GetIZSettlementRecordResponse : IPacketBody
{
	[ProtoMember(1)]
	public bool Result { get; set; }

	[ProtoMember(999)]
	public int ErrorCode { get; set; }

	[ProtoMember(3)]
	public string jsonIZrSettlement { get; set; }

	public int PacketId => PacketIds.USER_ACTION_GVGMODE3_GET_IZSETTLEMENT_RECORD;
}
