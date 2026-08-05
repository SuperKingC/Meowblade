using System.Collections.Generic;
using ProtoBuf;
using Shift.Legion.Helpers;

namespace Shift.Legion.ClientApi.Protocol.UserAction;

[ProtoContract]
public class GetRankListResponse : IPacketBody
{
	[ProtoMember(1)]
	public bool Result;

	[ProtoMember(2)]
	public string Message;

	[ProtoMember(4)]
	public string _jsonRankSummaryList;

	private List<RankSummary> _rankSummaryList;

	[ProtoMember(5)]
	public int SelfScore;

	[ProtoMember(6)]
	public int UnlockedBlocks;

	[ProtoMember(7)]
	public int UnlockNextBlockProgress;

	[ProtoMember(8)]
	public bool IsInTopTournament;

	[ProtoMember(999)]
	public int ErrorCode { get; set; }

	public List<RankSummary> RankSummaryList
	{
		get
		{
			if (_rankSummaryList == null && !string.IsNullOrEmpty(_jsonRankSummaryList))
			{
				_rankSummaryList = JsonHelper.ToObject<List<RankSummary>>(_jsonRankSummaryList);
			}
			return _rankSummaryList;
		}
		set
		{
			_rankSummaryList = value;
			_jsonRankSummaryList = JsonHelper.ToJson(_rankSummaryList);
		}
	}

	public int PacketId => PacketIds.USER_ACTION_GET_RANK_LIST_REQUEST;
}
