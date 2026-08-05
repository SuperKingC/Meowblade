using ProtoBuf;

namespace HotFix.Sources.Base.Sources.Scripts.GvG3.GvG3WorldMap.Model;

[ProtoContract]
public class ShipPlanStatusInfo
{
	[ProtoMember(1)]
	public int PlanStatus;

	[ProtoMember(2)]
	public int PlanAttackCount;

	[ProtoMember(3)]
	public int AttackedCount;
}
