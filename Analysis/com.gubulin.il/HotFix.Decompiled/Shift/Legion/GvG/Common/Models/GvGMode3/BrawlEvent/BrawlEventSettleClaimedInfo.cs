using ProtoBuf;

namespace Shift.Legion.GvG.Common.Models.GvGMode3.BrawlEvent;

[ProtoContract]
public class BrawlEventSettleClaimedInfo
{
	[ProtoMember(1)]
	public int Day { get; set; }

	[ProtoMember(2)]
	public long MessageId { get; set; }

	[ProtoMember(3)]
	public bool IsClaimed { get; set; }
}
