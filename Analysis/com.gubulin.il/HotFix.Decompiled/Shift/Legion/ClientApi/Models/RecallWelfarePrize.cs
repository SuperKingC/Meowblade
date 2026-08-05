using ProtoBuf;

namespace Shift.Legion.ClientApi.Models;

[ProtoContract]
public class RecallWelfarePrize
{
	[ProtoMember(1)]
	public string ItemId { get; set; }

	[ProtoMember(2)]
	public int Qty { get; set; }

	[ProtoMember(3)]
	public int DrawCase { get; set; }

	[ProtoMember(5)]
	public string PrizeId { get; set; }

	[ProtoMember(6)]
	public int Rarity { get; set; }
}
