using ProtoBuf;

namespace Shift.Legion.ClientApi.Models;

[ProtoContract]
public class TreasureHuntLevelInfo
{
	[ProtoMember(1)]
	public string LevelId;

	[ProtoMember(2)]
	public int Status;

	[ProtoMember(3, TypeName = "Shift.Legion.ClientApi.Models.EnemyTemplate")]
	public EnemyTemplate EnemyTemplate;
}
