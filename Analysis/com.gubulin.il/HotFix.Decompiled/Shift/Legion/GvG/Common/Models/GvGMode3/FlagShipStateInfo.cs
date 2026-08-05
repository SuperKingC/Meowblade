using ProtoBuf;

namespace Shift.Legion.GvG.Common.Models.GvGMode3;

[ProtoContract]
public class FlagShipStateInfo
{
	[ProtoMember(1)]
	public int CampId;

	[ProtoMember(2)]
	public int ShipTargetIslandId;

	[ProtoMember(3)]
	public int Progress;

	[ProtoMember(4)]
	public int Step;

	[ProtoMember(5)]
	public int MainMissionGroupId;
}
