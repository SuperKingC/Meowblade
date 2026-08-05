using System.Collections.Generic;
using ProtoBuf;

namespace Shift.Legion.GvGServer.Models.GvGMode3IslandSocket;

[ProtoContract]
public class GvGMode3BattleResult
{
	[ProtoMember(1)]
	public int EntityId;

	[ProtoMember(2)]
	public string BattleId;

	[ProtoMember(5)]
	public int SoldierCost;

	[ProtoMember(6)]
	public int SoldierRemaining;

	[ProtoMember(7)]
	public long BossDamage;

	[ProtoMember(8)]
	public int 机械降神Increase;

	[ProtoMember(9, TypeName = "Shift.Legion.GvGServer.Models.GvGMode3IslandSocket.ScoreChangeInfo")]
	public List<ScoreChangeInfo> ScoreChanged;
}
