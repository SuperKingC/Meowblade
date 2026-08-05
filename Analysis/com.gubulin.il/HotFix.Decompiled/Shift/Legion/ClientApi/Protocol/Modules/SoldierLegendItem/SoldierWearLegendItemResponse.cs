using ProtoBuf;

namespace Shift.Legion.ClientApi.Protocol.Modules.SoldierLegendItem;

[ProtoContract]
public class SoldierWearLegendItemResponse : IPacketBody
{
	[ProtoMember(1)]
	public bool Result { get; set; }

	[ProtoMember(10)]
	public long[] Items { get; set; }

	[ProtoMember(999)]
	public int ErrorCode { get; set; }

	public int PacketId => PacketIds.MODULES_SOLDIER_WEAR_LEGEND_ITEM;
}
