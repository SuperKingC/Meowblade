using System.Collections.Generic;
using ProtoBuf;
using Shift.Legion.Helpers;

namespace Shift.Legion.ClientApi.Protocol.UserAction;

[ProtoContract]
public class GetPvPRankLastTurnLast10SelfRankRecordResponse : IPacketBody
{
	[ProtoMember(1)]
	public bool Result;

	public string Message;

	[ProtoMember(3)]
	public string _jsonBattleRecordsList;

	private List<RankChangeRecord> _rankChangeRecords;

	[ProtoMember(999)]
	public int ErrorCode { get; set; }

	public List<RankChangeRecord> RankChangeRecords
	{
		get
		{
			if (_rankChangeRecords == null && !string.IsNullOrEmpty(_jsonBattleRecordsList))
			{
				_rankChangeRecords = JsonHelper.ToObject<List<RankChangeRecord>>(_jsonBattleRecordsList);
			}
			return _rankChangeRecords;
		}
		set
		{
			_rankChangeRecords = value;
			_jsonBattleRecordsList = JsonHelper.ToJson(_rankChangeRecords);
		}
	}

	public int PacketId => PacketIds.USER_ACTION_GET_PVP_RANK_LAST_TURN_LAST_10_SELF_RANK_RECORD_RESULT_REQUEST;
}
