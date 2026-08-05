using System.Collections.Generic;
using ProtoBuf;

namespace Shift.Legion.ClientApi.Protocol.Modules.LegendItemEnhancement;

[ProtoContract]
public class LegendItemEnhancementEnhanceRequest : IRequestPacket, IPacketBody
{
	[ProtoMember(99)]
	public int MsgIndex { get; set; }

	[ProtoMember(1)]
	public long EnhanceTargetId { get; set; }

	[ProtoMember(2)]
	public List<long> FoodIds { get; set; }

	public int PacketId => PacketIds.MODULES_LEGEND_ITEM_ENHANCEMENT_ENHANCE;
}
