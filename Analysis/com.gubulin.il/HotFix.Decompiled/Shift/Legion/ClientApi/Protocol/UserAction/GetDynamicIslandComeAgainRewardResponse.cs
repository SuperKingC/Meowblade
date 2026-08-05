using System.Collections.Generic;
using ProtoBuf;
using Shift.Legion.Helpers;

namespace Shift.Legion.ClientApi.Protocol.UserAction;

[ProtoContract]
public class GetDynamicIslandComeAgainRewardResponse : IPacketBody
{
	[ProtoMember(1)]
	public bool Result;

	[ProtoMember(2)]
	public string RewardInfos;

	[ProtoMember(999)]
	public int ErrorCode { get; set; }

	[ProtoMember(4)]
	public int RealCost { get; set; }

	public int PacketId => PacketIds.USER_ACTION_GET_DYNAMIC_ACTIVITY_ISLAND_COME_AGAIN_CLAIM_REQUEST;

	public List<IslandComeAgainPrizePool.ItemInfo> GetReward()
	{
		if (string.IsNullOrEmpty(RewardInfos))
		{
			return null;
		}
		return JsonHelper.ToObject<List<IslandComeAgainPrizePool.ItemInfo>>(RewardInfos);
	}
}
