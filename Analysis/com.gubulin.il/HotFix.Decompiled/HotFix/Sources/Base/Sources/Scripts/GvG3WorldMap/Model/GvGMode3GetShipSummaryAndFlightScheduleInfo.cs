using HotFix.Sources.Base.Sources.Scripts.GvG3.GvG3WorldMap.Model;
using ProtoBuf;

namespace HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Model;

[ProtoContract]
public class GvGMode3GetShipSummaryAndFlightScheduleInfo
{
	[ProtoMember(1)]
	public int EntityId;

	[ProtoMember(2)]
	public int UserId;

	[ProtoMember(3)]
	public string ShipId;

	[ProtoMember(4, TypeName = "HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Model.FlightSchedule")]
	public FlightSchedule FlightSchedule;

	[ProtoMember(5)]
	public int State;

	[ProtoMember(6)]
	public int StayIslandId;

	[ProtoMember(10)]
	public int CampId;

	[ProtoMember(11)]
	public float AvatarScale;

	[ProtoMember(12, TypeName = "HotFix.Sources.Base.Sources.Scripts.GvG3.GvG3WorldMap.Model.ShipPlanStatusInfo")]
	public ShipPlanStatusInfo ShipPlanStatus;
}
