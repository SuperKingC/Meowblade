using System.Collections.Generic;
using ProtoBuf;
using Shift.Legion.Helpers;

namespace Shift.Legion.ClientApi.Protocol.UserAction;

[ProtoContract]
public class GetPvPTopTournamentRankResponse : IPacketBody
{
	[ProtoMember(1)]
	public bool Result;

	public string Message;

	[ProtoMember(3)]
	public string Data;

	private List<Dictionary<string, object>> topTournamentRankListInfo;

	[ProtoMember(999)]
	public int ErrorCode { get; set; }

	public List<Dictionary<string, object>> TopTournamentRankListInfo
	{
		get
		{
			if (topTournamentRankListInfo == null && !string.IsNullOrEmpty(Data))
			{
				topTournamentRankListInfo = JsonHelper.ToObject<List<Dictionary<string, object>>>(Data);
			}
			return topTournamentRankListInfo;
		}
	}

	public int PacketId => PacketIds.USER_ACTION_GET_PVP_TOP_TOURNAMENT_RANK_REQUEST;
}
