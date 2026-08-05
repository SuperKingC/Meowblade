using ProtoBuf;

namespace Shift.Legion.GvGServer.Models.WorldBossSocket;

[ProtoContract]
public class DamageInfo
{
	[ProtoMember(1)]
	public int EntityId;

	[ProtoMember(2)]
	public string BattleId;

	[ProtoMember(3)]
	public long Damage;

	[ProtoMember(4)]
	public long DamageTotal;

	[ProtoMember(5)]
	public int SoldierCost;

	[ProtoMember(6)]
	public int SoldierRemaining;
}
