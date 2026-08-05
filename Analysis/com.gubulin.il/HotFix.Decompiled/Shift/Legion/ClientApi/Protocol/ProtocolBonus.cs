using ProtoBuf;

namespace Shift.Legion.ClientApi.Protocol;

[ProtoContract]
public class ProtocolBonus
{
	[ProtoMember(1)]
	public string ItemId { get; set; }

	[ProtoMember(2)]
	public int Qty { get; set; }

	[ProtoMember(4)]
	public int Rarity { get; set; }

	[ProtoMember(5)]
	public bool IsUnlock { get; set; }

	public int Weight { get; set; }
}
