using ProtoBuf;
using Shift.Legion.ClientApi.Protocol.Modules.LegendItem.Models;

namespace Shift.Legion.ClientApi.Protocol.Modules.LegendItemEnhancement;

[ProtoContract]
public class LegendItemEnhancementSwitchMainResponse : IPacketBody
{
	[ProtoMember(999)]
	public int ErrorCode { get; set; }

	[ProtoMember(1)]
	public Shift.Legion.ClientApi.Protocol.Modules.LegendItem.Models.LegendItem TargetItem { get; set; }

	public int PacketId => PacketIds.MODULES_LEGEND_ITEM_SWITCHMAIN;
}
