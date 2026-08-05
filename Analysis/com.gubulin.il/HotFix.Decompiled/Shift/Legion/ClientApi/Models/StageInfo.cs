using ProtoBuf;

namespace Shift.Legion.ClientApi.Models;

[ProtoContract]
public class StageInfo
{
	[ProtoMember(1)]
	public int StageStatus { get; set; }

	[ProtoMember(2)]
	public int BeginTime { get; set; }

	[ProtoMember(3)]
	public int EndTime { get; set; }

	[ProtoMember(4)]
	public int SettleTime { get; set; }

	[ProtoMember(5)]
	public int DisplayTime { get; set; }
}
