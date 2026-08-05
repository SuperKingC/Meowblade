using ProtoBuf;

namespace Shift.Legion.ClientApi.Models;

[ProtoContract]
public class ERItem
{
	[ProtoMember(1)]
	public string PrizeId { get; set; }

	[ProtoMember(3)]
	public int Index { get; set; }
}
