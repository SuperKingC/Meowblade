using System.Collections.Generic;
using ProtoBuf;

namespace Shift.Legion.ClientApi.Protocol.UserAction;

[ProtoContract]
public class RankTopTournamentRecordsProto
{
	[ProtoMember(1)]
	public int Day { get; set; }

	[ProtoMember(2)]
	public int UserId { get; set; }

	[ProtoMember(3)]
	public float WinRate { get; set; }

	[ProtoMember(4)]
	public List<string> WinBattleIds { get; set; } = new List<string>();

	[ProtoMember(5)]
	public List<string> FailedBattleIds { get; set; } = new List<string>();
}
