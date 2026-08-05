using ProtoBuf;

namespace Shift.Legion.ClientApi.Models;

[ProtoContract]
public class RecallWelfareMissionProgress
{
	[ProtoMember(1)]
	public int MissionType { get; set; }

	[ProtoMember(2)]
	public int CurrentValue { get; set; }
}
