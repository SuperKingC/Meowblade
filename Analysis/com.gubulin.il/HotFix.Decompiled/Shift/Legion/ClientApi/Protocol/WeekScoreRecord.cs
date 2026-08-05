using ProtoBuf;

namespace Shift.Legion.ClientApi.Protocol;

[ProtoContract]
public class WeekScoreRecord
{
	[ProtoMember(1)]
	public int Week { get; set; }

	[ProtoMember(2)]
	public int Coefficient { get; set; }

	[ProtoMember(3)]
	public int TotalScore { get; set; }
}
