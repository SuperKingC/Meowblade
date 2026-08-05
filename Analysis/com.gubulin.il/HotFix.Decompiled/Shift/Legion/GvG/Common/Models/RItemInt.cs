using ProtoBuf;

namespace Shift.Legion.GvG.Common.Models;

[ProtoContract]
public class RItemInt
{
	[ProtoMember(1)]
	public int ItemId { get; set; }

	[ProtoMember(2)]
	public int cnt { get; set; }

	public RItemInt Clone()
	{
		return new RItemInt
		{
			ItemId = ItemId,
			cnt = cnt
		};
	}
}
