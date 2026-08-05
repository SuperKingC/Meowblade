using System.Collections.Generic;
using ProtoBuf;

namespace Shift.Legion.ClientApi.Protocol.Modules.LegendItem.Models;

[ProtoContract]
public class FxEntryGroup
{
	[ProtoMember(1, TypeName = "Shift.Legion.ClientApi.Protocol.Modules.LegendItem.Models.FxEntryGroup")]
	public List<ItemEntry> Entries { get; set; } = new List<ItemEntry>();

	[ProtoMember(2)]
	public string SetAlias { get; set; }
}
