using System.Collections.Generic;
using ProtoBuf;
using Shift.Legion.Helpers;

namespace Shift.Legion.ClientApi.Protocol.UserAction;

[ProtoContract]
public class GetPvPRankLastTurnLastDayResultResponse : IPacketBody
{
	[ProtoMember(1)]
	public bool Result;

	public string Message;

	[ProtoMember(3)]
	public string Data;

	private Dictionary<string, List<Dictionary<string, object>>> battleLogData;

	[ProtoMember(999)]
	public int ErrorCode { get; set; }

	public int PacketId => PacketIds.USER_ACTION_GET_PVP_RANK_LAST_TURN_LAST_DAY_RESULT_REQUEST;

	public Dictionary<string, List<Dictionary<string, object>>> BattleLogData
	{
		get
		{
			if (battleLogData == null && !string.IsNullOrEmpty(Data))
			{
				battleLogData = JsonHelper.ToObject<Dictionary<string, List<Dictionary<string, object>>>>(Data);
			}
			return battleLogData;
		}
	}
}
