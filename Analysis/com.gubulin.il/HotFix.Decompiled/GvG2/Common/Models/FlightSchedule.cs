using ProtoBuf;

namespace GvG2.Common.Models;

[ProtoContract]
public class FlightSchedule
{
	[ProtoMember(1)]
	public int StartTime;

	[ProtoMember(2)]
	public int EndTime;

	[ProtoMember(3)]
	public int[] Route;
}
