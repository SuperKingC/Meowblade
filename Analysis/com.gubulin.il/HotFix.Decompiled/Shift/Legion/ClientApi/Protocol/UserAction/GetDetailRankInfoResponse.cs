using ProtoBuf;
using Shift.Legion.Helpers;

namespace Shift.Legion.ClientApi.Protocol.UserAction;

[ProtoContract]
public class GetDetailRankInfoResponse : IPacketBody
{
	[ProtoMember(1)]
	public bool Result;

	[ProtoMember(2)]
	public string Message;

	[ProtoMember(4)]
	public string _jsonRankRecord;

	private RankRecord _rankRecord;

	[ProtoMember(999)]
	public int ErrorCode { get; set; }

	public RankRecord EnemyRankRecord
	{
		get
		{
			if (_rankRecord == null && !string.IsNullOrEmpty(_jsonRankRecord))
			{
				_rankRecord = JsonHelper.ToObject<RankRecord>(_jsonRankRecord);
			}
			return _rankRecord;
		}
		set
		{
			_rankRecord = value;
			_jsonRankRecord = JsonHelper.ToJson(_rankRecord);
		}
	}

	public int PacketId => PacketIds.USER_ACTION_GET_DETAIL_RANK_INFO_REQUEST;
}
