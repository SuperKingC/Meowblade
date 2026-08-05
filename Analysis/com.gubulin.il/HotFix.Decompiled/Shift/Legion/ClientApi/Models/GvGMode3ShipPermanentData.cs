using ProtoBuf;

namespace Shift.Legion.ClientApi.Models;

[ProtoContract]
public class GvGMode3ShipPermanentData
{
	[ProtoMember(1)]
	public bool IsJoinIZ { get; set; }

	[ProtoMember(2)]
	public string ShipName { get; set; }

	[ProtoMember(3)]
	public int ShipBuildState { get; set; }

	[ProtoMember(4)]
	public int TargetBuildCompleteTime { get; set; }

	[ProtoMember(5)]
	public int ShipRace { get; set; }

	[ProtoMember(6)]
	public int ManPower { get; set; }

	[ProtoMember(7)]
	public int Index { get; set; }

	[ProtoMember(8)]
	public int BuildStartTime { get; set; }

	[ProtoMember(9)]
	public bool HasLaunch { get; set; }
}
