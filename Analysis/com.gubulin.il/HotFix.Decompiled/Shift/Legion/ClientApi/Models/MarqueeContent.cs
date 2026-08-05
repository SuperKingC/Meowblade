using ProtoBuf;

namespace Shift.Legion.ClientApi.Models;

[ProtoContract]
public class MarqueeContent
{
	[ProtoMember(1)]
	public int Id { get; set; }

	[ProtoMember(2)]
	public string Content { get; set; }

	[ProtoMember(3)]
	public int Repeat { get; set; }

	[ProtoMember(4)]
	public int Timestamp { get; set; }
}
