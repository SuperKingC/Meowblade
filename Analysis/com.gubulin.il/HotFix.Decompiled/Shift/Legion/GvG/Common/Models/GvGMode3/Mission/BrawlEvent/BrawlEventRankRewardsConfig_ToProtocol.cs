using System.Collections.Generic;
using ProtoBuf;

namespace Shift.Legion.GvG.Common.Models.GvGMode3.Mission.BrawlEvent;

[ProtoContract]
public class BrawlEventRankRewardsConfig_ToProtocol
{
	[ProtoMember(1)]
	public int[] Rank;

	[ProtoMember(2, TypeName = "Shift.Legion.GvG.Common.Models.RItem")]
	public List<RItem> Rewards;
}
