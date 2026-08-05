using ProtoBuf;

namespace Shift.Legion.GvG.Common.Models;

[ProtoContract]
public class RItem
{
	[ProtoMember(1)]
	public string ItemId { get; set; }

	[ProtoMember(2)]
	public int cnt { get; set; }

	public RItem Clone()
	{
		return new RItem
		{
			ItemId = ItemId,
			cnt = cnt
		};
	}
}
