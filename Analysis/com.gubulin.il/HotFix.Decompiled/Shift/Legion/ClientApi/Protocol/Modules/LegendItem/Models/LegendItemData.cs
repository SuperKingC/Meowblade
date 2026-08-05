using System.Collections.Generic;
using ProtoBuf;

namespace Shift.Legion.ClientApi.Protocol.Modules.LegendItem.Models;

[ProtoContract]
public class LegendItemData
{
	[ProtoMember(1)]
	public int EnhanceLevel { get; set; }

	[ProtoMember(2)]
	public int EnhanceExp { get; set; }

	[ProtoMember(3)]
	public bool Locked { get; set; }

	[ProtoMember(10, TypeName = "Shift.Legion.ClientApi.Protocol.Modules.LegendItem.Models.ItemEntry")]
	public List<ItemEntry> MainEntries { get; set; }

	[ProtoMember(11, TypeName = "Shift.Legion.ClientApi.Protocol.Modules.LegendItem.Models.ItemEntry")]
	public List<ItemEntry> SubEntries { get; set; }

	[ProtoMember(12, TypeName = "Shift.Legion.ClientApi.Protocol.Modules.LegendItem.Models.ItemEntry")]
	public List<ItemEntry> FxEntries { get; set; }

	[ProtoMember(13)]
	public int ReforgeCnt { get; set; }

	[ProtoMember(14)]
	public string SetAlias { get; set; }

	[ProtoMember(15, TypeName = "Shift.Legion.ClientApi.Protocol.Modules.LegendItem.Models.ItemEntry")]
	public List<ItemEntry> AlterMainEntries { get; set; }

	[ProtoMember(17, TypeName = "Shift.Legion.ClientApi.Protocol.Modules.LegendItem.Models.FxEntryGroup")]
	public List<FxEntryGroup> AlterFxEntries { get; set; }
}
