using System.Collections.Generic;
using ProtoBuf;

namespace Shift.Legion.ClientApi.Protocol.Modules.LegendItem;

[ProtoContract]
public class LegendItemAllResponse : IPacketBody
{
	[ProtoMember(1)]
	public bool Result { get; set; }

	[ProtoMember(2)]
	public List<string> Items { get; set; }

	public int PacketId => PacketIds.MODULES_LEGEND_ITEM_ALL;
}
