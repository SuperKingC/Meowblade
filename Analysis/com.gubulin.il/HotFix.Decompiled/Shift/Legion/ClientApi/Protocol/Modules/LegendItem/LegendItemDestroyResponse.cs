using ProtoBuf;

namespace Shift.Legion.ClientApi.Protocol.Modules.LegendItem;

[ProtoContract]
public class LegendItemDestroyResponse : IPacketBody
{
	[ProtoMember(1)]
	public bool Result { get; set; }

	public int PacketId => PacketIds.MODULES_LEGEND_ITEM_DESTROY;
}
