using System.Collections.Generic;
using ProtoBuf;
using Shift.Legion.Helpers;

namespace Shift.Legion.ClientApi.Protocol.UserAction;

[ProtoContract]
public class GetLegendItemLotteryActivityProgressesResponse : IPacketBody
{
	[ProtoMember(1)]
	public long Tick;

	[ProtoMember(2)]
	public bool Result;

	[ProtoMember(4)]
	public string _jsonScoreOfLotteryActivities;

	private Dictionary<string, int> _scoreOfLotteryActivities;

	[ProtoMember(999)]
	public int ErrorCode { get; set; }

	public Dictionary<string, int> ScoreOfLotteryActivities
	{
		get
		{
			if (_scoreOfLotteryActivities == null && !string.IsNullOrEmpty(_jsonScoreOfLotteryActivities))
			{
				_scoreOfLotteryActivities = JsonHelper.ToObject<Dictionary<string, int>>(_jsonScoreOfLotteryActivities);
			}
			return _scoreOfLotteryActivities;
		}
		set
		{
			_scoreOfLotteryActivities = value;
			_jsonScoreOfLotteryActivities = JsonHelper.ToJson(_scoreOfLotteryActivities);
		}
	}

	public int PacketId => PacketIds.USER_ACTION_GET_LEGEND_ITEM_ACTIVITY_PROGRESS;
}
