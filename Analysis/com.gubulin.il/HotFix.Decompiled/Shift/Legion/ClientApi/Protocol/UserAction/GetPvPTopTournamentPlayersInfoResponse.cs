using System.Collections.Generic;
using ProtoBuf;
using Shift.Legion.Helpers;

namespace Shift.Legion.ClientApi.Protocol.UserAction;

[ProtoContract]
public class GetPvPTopTournamentPlayersInfoResponse : IPacketBody
{
	[ProtoMember(1)]
	public bool Result;

	public string Message;

	[ProtoMember(3)]
	public string Data;

	private List<Dictionary<string, object>> topTournamentNameListInfo;

	[ProtoMember(999)]
	public int ErrorCode { get; set; }

	public List<Dictionary<string, object>> TopTournamentNameListInfo
	{
		get
		{
			if (topTournamentNameListInfo == null && !string.IsNullOrEmpty(Data))
			{
				topTournamentNameListInfo = JsonHelper.ToObject<List<Dictionary<string, object>>>(Data);
			}
			return topTournamentNameListInfo;
		}
	}

	public int PacketId => PacketIds.USER_ACTION_GET_PVP_TOP_TOURNAMENT_PLAYERS_INFO_REQUEST;
}
