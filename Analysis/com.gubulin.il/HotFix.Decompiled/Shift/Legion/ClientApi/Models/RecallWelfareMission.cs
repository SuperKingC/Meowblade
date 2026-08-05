using ProtoBuf;

namespace Shift.Legion.ClientApi.Models;

[ProtoContract]
public class RecallWelfareMission
{
	[ProtoMember(1)]
	public string MissionId { get; set; }

	[ProtoMember(2)]
	public int Type { get; set; }

	[ProtoMember(3)]
	public int TargetValue { get; set; }

	[ProtoMember(4)]
	public int Score { get; set; }

	[ProtoMember(5)]
	public string Level { get; set; }
}
