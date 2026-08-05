using ProtoBuf;

namespace Shift.Legion.ClientApi.Protocol.Modules.SoldierLegendItem;

[ProtoContract]
public class SoldierTakeOffLegendItemResponse : IPacketBody
{
	[ProtoMember(1)]
	public bool Result { get; set; }

	[ProtoMember(999)]
	public int ErrorCode { get; set; }

	[ProtoMember(10)]
	public long[] Items { get; set; }

	public int PacketId => PacketIds.MODULES_SOLDIER_TAKE_OFF_LEGEND_ITEM;
}
