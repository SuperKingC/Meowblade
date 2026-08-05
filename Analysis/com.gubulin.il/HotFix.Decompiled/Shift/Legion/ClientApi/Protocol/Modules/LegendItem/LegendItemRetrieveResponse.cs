using ProtoBuf;
using Shift.Legion.ClientApi.Protocol.Modules.LegendItem.Models;

namespace Shift.Legion.ClientApi.Protocol.Modules.LegendItem;

[ProtoContract]
public class LegendItemRetrieveResponse : IPacketBody
{
	[ProtoMember(1)]
	public bool Result { get; set; }

	[ProtoMember(2, TypeName = "Shift.Legion.ClientApi.Protocol.Modules.LegendItem.Models.LegendItem")]
	public Shift.Legion.ClientApi.Protocol.Modules.LegendItem.Models.LegendItem Item { get; set; }

	public int PacketId => PacketIds.MODULES_LEGEND_ITEM_RETRIEVE;
}
