using System.Collections.Generic;
using ProtoBuf;
using Shift.Legion.ClientApi.Protocol.Modules.LegendItem.Models;
using Shift.Legion.ClientApi.Protocol.UserAction;

namespace Shift.Legion.ClientApi.Protocol.Modules.LegendItemEnhancement;

[ProtoContract]
public class LegendItemEnhancementSwapMainResponse : IPacketBody
{
	[ProtoMember(999)]
	public int ErrorCode { get; set; }

	[ProtoMember(1)]
	public Shift.Legion.ClientApi.Protocol.Modules.LegendItem.Models.LegendItem TargetItem { get; set; }

	[ProtoMember(2)]
	public List<StockChangeRecord> StockChangeRecords { get; set; }

	public int PacketId => PacketIds.MODULES_LEGEND_ITEM_SWAPMAIN;
}
