using ProtoBuf;

namespace Shift.Legion.GvGServer.Models.GvGMode2IslandSocket;

[ProtoContract]
public class GvGMode2BattleResult
{
	[ProtoMember(1)]
	public int EntityId;

	[ProtoMember(2)]
	public string BattleId;

	[ProtoMember(5)]
	public int SoldierCost;

	[ProtoMember(6)]
	public int SoldierRemaining;
}
