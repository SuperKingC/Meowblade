using ProtoBuf;

namespace Shift.Legion.ClientApi.Protocol.UserAction;

[ProtoContract]
public class CheckLegendItemSlotResponse : IPacketBody
{
	[ProtoMember(99)]
	public bool Result { get; set; }

	[ProtoMember(999)]
	public int ErrorCode { get; set; }

	public int PacketId => PacketIds.USER_ACTION_CHECK_LEGEND_SLOT;
}
