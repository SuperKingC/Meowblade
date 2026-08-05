using System.Collections.Generic;
using ProtoBuf;
using Shift.Legion.ClientApi.Protocol.Modules.LegendItem.Models;

namespace Shift.Legion.ClientApi.Models;

[ProtoContract]
public class LegendItemBrief
{
	[ProtoMember(1)]
	public string ItemId;

	[ProtoMember(2)]
	public int Score;

	[ProtoMember(3)]
	public int EnhanceLevel;

	[ProtoMember(4)]
	public float CombatPowerModifier;

	[ProtoMember(5)]
	public string SetAlias;

	[ProtoMember(10, TypeName = "Shift.Legion.ClientApi.Models.ItemEntryBrief")]
	public List<ItemEntryBrief> MainEntries;

	[ProtoMember(11, TypeName = "Shift.Legion.ClientApi.Models.ItemEntryBrief")]
	public List<ItemEntryBrief> SubEntries;

	[ProtoMember(12, TypeName = "Shift.Legion.ClientApi.Models.ItemEntryBrief")]
	public List<ItemEntryBrief> FxEntries;

	public static LegendItemBrief Parse(LegendItem legendItem)
	{
		return new LegendItemBrief
		{
			ItemId = legendItem.ItemId,
			Score = legendItem.Score,
			EnhanceLevel = legendItem.EnhanceLevel,
			MainEntries = ItemEntryBrief.Parse(legendItem.MainEntries),
			SubEntries = ItemEntryBrief.Parse(legendItem.SubEntries),
			FxEntries = ItemEntryBrief.Parse(legendItem.FxEntries)
		};
	}
}
