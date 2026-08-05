using System.Collections.Generic;
using ProtoBuf;
using Shift.Legion.Helpers;

namespace Shift.Legion.ClientApi.Protocol.UserAction;

[ProtoContract]
public class GetPvPRankLastTurnLastDaySinglePlayerRecordResultResponse : IPacketBody
{
	[ProtoMember(1)]
	public bool Result;

	public string Message;

	[ProtoMember(3)]
	public string Records;

	private List<RankChangeRecord> _rankChangeRecords;

	[ProtoMember(999)]
	public int ErrorCode { get; set; }

	public List<RankChangeRecord> RankChangeRecords
	{
		get
		{
			if (_rankChangeRecords == null && !string.IsNullOrEmpty(Records))
			{
				_rankChangeRecords = JsonHelper.ToObject<List<RankChangeRecord>>(Records);
			}
			return _rankChangeRecords;
		}
	}

	public int PacketId => PacketIds.USER_ACTION_GET_PVP_RANK_LAST_TURN_LAST_DAY_SINGLE_PLAYER_RECORD_RESULT_REQUEST;
}
