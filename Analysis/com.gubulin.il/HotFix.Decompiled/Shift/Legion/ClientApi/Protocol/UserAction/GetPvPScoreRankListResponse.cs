using System.Collections.Generic;
using ProtoBuf;
using Shift.Legion.Helpers;

namespace Shift.Legion.ClientApi.Protocol.UserAction;

[ProtoContract]
public class GetPvPScoreRankListResponse : IPacketBody
{
	[ProtoMember(1)]
	public bool Result;

	[ProtoMember(2)]
	public string Message;

	[ProtoMember(4)]
	public string _jsonScoreRankList;

	[ProtoMember(5)]
	public int ExpiredAt;

	private List<ScoreRankSummary> _scoreRankList;

	[ProtoMember(999)]
	public int ErrorCode { get; set; }

	public List<ScoreRankSummary> ScoreRankList
	{
		get
		{
			if (_scoreRankList == null && !string.IsNullOrEmpty(_jsonScoreRankList))
			{
				_scoreRankList = JsonHelper.ToObject<List<ScoreRankSummary>>(_jsonScoreRankList);
			}
			return _scoreRankList;
		}
		set
		{
			_scoreRankList = value;
			_jsonScoreRankList = JsonHelper.ToJson(_scoreRankList);
		}
	}

	public int PacketId => PacketIds.USER_ACTION_GET_PVP_SCORE_RANK_LIST_REQUEST;
}
