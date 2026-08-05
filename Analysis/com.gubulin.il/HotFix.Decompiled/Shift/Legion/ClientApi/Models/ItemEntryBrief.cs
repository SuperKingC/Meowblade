using System.Collections.Generic;
using ProtoBuf;
using Shift.Legion.ClientApi.Protocol.Modules.LegendItem.Models;

namespace Shift.Legion.ClientApi.Models;

[ProtoContract]
public class ItemEntryBrief
{
	[ProtoMember(1)]
	public string EntryId;

	[ProtoMember(2, TypeName = "Shift.Legion.ClientApi.Protocol.Modules.LegendItem.Models.ItemEntryData")]
	public List<ItemEntryData> Attributes;

	[ProtoMember(3)]
	public int Status;

	public static List<ItemEntryBrief> Parse(List<ItemEntry> itemEntries)
	{
		List<ItemEntryBrief> list = new List<ItemEntryBrief>();
		if (itemEntries == null)
		{
			return list;
		}
		foreach (ItemEntry itemEntry in itemEntries)
		{
			list.Add(Parse(itemEntry));
		}
		return list;
	}

	public static ItemEntryBrief Parse(ItemEntry itemEntry)
	{
		return new ItemEntryBrief
		{
			EntryId = itemEntry.EntryId,
			Attributes = itemEntry.Attributes
		};
	}
}
