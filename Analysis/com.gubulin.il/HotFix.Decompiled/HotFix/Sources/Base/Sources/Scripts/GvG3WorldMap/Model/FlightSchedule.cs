using ProtoBuf;

namespace HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Model;

[ProtoContract]
public class FlightSchedule
{
	[ProtoMember(1)]
	public int TimeStamp;

	[ProtoMember(2)]
	public int EndTime;

	[ProtoMember(3)]
	public int[] Route;

	[ProtoMember(4)]
	public int DistanceTraveled;

	[ProtoMember(5)]
	public bool IsReturning;
}
