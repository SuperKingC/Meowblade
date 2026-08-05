using ProtoBuf;

namespace Shift.Legion.ClientApi.Protocol.UserAction;

[ProtoContract]
public class GvGMode3ShipGetRecordResponse : IPacketBody
{
	[ProtoMember(1)]
	public bool Result { get; set; }

	[ProtoMember(999)]
	public int ErrorCode { get; set; }

	[ProtoMember(2)]
	public string jsonGvGMode3Record { get; set; }

	[ProtoMember(3)]
	public string jsonPlayerSettlement { get; set; }

	[ProtoMember(4)]
	public int StopTimestamp { get; set; }

	[ProtoMember(5)]
	public int StartTimestamp { get; set; }

	[ProtoMember(6)]
	public int CloseReason { get; set; }

	[ProtoMember(7)]
	public string jsonGvGSoldiersEquippedItems { get; set; }

	public int PacketId => PacketIds.USER_ACTION_GVGMODE3_GET_RECORD;
}
