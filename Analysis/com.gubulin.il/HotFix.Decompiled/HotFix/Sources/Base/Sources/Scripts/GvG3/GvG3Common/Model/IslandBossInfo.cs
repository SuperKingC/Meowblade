using ProtoBuf;

namespace HotFix.Sources.Base.Sources.Scripts.GvG3.GvG3Common.Model;

[ProtoContract]
public class IslandBossInfo
{
	[ProtoMember(1)]
	public long BossMaxHp;

	[ProtoMember(2)]
	public float BossAttack;

	[ProtoMember(3)]
	public float BossDefense;
}
