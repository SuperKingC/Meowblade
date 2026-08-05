using System.Collections.Generic;
using ProtoBuf;

namespace Shift.Legion.ClientApi.Protocol.Modules.LegendItem.Models;

[ProtoContract]
public class ItemEntry
{
	[ProtoMember(1)]
	public string EntryId;

	[ProtoMember(2, TypeName = "Shift.Legion.ClientApi.Protocol.Modules.LegendItem.Models.ItemEntryData")]
	public List<ItemEntryData> Attributes;

	[ProtoMember(3, TypeName = "Shift.Legion.ClientApi.Protocol.Modules.LegendItem.Models.ItemEntry")]
	public ItemEntry TmpItemEntry;

	[ProtoMember(4)]
	public int Status;

	[ProtoMember(5)]
	public int ChangeCnt;

	[ProtoMember(6)]
	public int ReforgeLockCnt;

	[ProtoMember(7)]
	public bool IsBlueprintEntry;

	[ProtoMember(8)]
	public string BlueprintEntryPoolId;
}
