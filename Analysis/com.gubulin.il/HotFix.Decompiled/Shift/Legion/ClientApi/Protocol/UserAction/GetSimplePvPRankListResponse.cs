using System.Collections.Generic;
using ProtoBuf;
using Shift.Legion.Helpers;

namespace Shift.Legion.ClientApi.Protocol.UserAction;

[ProtoContract]
public class GetSimplePvPRankListResponse : IPacketBody
{
	[ProtoMember(1)]
	public bool Result;

	[ProtoMember(2)]
	public string Message;

	[ProtoMember(4)]
	public string _jsonSimpleRankList;

	[ProtoMember(5)]
	public int ExpiredAt;

	private List<SimpleRankSummary> _simpleRankList;

	[ProtoMember(999)]
	public int ErrorCode { get; set; }

	public List<SimpleRankSummary> SimpleRankList
	{
		get
		{
			if (_simpleRankList == null && !string.IsNullOrEmpty(_jsonSimpleRankList))
			{
				_simpleRankList = JsonHelper.ToObject<List<SimpleRankSummary>>(_jsonSimpleRankList);
			}
			return _simpleRankList;
		}
		set
		{
			_simpleRankList = value;
			_jsonSimpleRankList = JsonHelper.ToJson(_simpleRankList);
		}
	}

	public int PacketId => PacketIds.USER_ACTION_GET_SIMPLE_PVP_RANK_LIST_REQUEST;
}
