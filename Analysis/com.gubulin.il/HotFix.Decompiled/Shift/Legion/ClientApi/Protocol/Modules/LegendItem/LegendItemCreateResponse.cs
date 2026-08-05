using System.Collections.Generic;
using ProtoBuf;
using Shift.Legion.ClientApi.Protocol.Modules.LegendItem.Models;

namespace Shift.Legion.ClientApi.Protocol.Modules.LegendItem;

[ProtoContract]
public class LegendItemCreateResponse : IPacketBody
{
	[ProtoMember(1)]
	public bool Result { get; set; }

	[ProtoMember(2)]
	public string Message { get; set; }

	[ProtoMember(3)]
	public int Code { get; set; }

	[ProtoMember(4, TypeName = "Shift.Legion.ClientApi.Protocol.Modules.LegendItem.Models.LegendItem")]
	public List<Shift.Legion.ClientApi.Protocol.Modules.LegendItem.Models.LegendItem> Items { get; set; }

	public int PacketId => PacketIds.MODULES_LEGEND_ITEM_CREATE;
}
