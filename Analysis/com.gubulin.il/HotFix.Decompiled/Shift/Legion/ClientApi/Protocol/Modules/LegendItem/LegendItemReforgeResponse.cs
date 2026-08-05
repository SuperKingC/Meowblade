using ProtoBuf;
using Shift.Legion.ClientApi.Protocol.Modules.LegendItem.Models;
using Shift.Legion.ClientApi.Protocol.UserAction;

namespace Shift.Legion.ClientApi.Protocol.Modules.LegendItem;

[ProtoContract]
public class LegendItemReforgeResponse : IPacketBody
{
	[ProtoMember(1)]
	public bool Result { get; set; }

	[ProtoMember(2)]
	public string Message { get; set; }

	[ProtoMember(3, TypeName = "Shift.Legion.ClientApi.Protocol.Modules.LegendItem.Models.LegendItem")]
	public Shift.Legion.ClientApi.Protocol.Modules.LegendItem.Models.LegendItem ReforgedItem { get; set; }

	[ProtoMember(4)]
	public int Code { get; set; }

	[ProtoMember(5, TypeName = "Shift.Legion.ClientApi.Protocol.UserAction.StockChangeRecord")]
	public StockChangeRecord[] Costs { get; set; }

	public int PacketId => PacketIds.MODULES_LEGEND_ITEM_REFORGE;
}
