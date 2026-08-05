using ProtoBuf;

namespace Shift.Legion.GvG.Common.Models.GvGMode3.Mission.BrawlEvent;

[ProtoContract]
public class BrawlEventInfo
{
	[ProtoMember(1)]
	public int MUId { get; set; }
}
