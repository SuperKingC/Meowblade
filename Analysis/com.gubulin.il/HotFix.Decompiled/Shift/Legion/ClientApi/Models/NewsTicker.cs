using ProtoBuf;

namespace Shift.Legion.ClientApi.Models;

[ProtoContract]
public class NewsTicker
{
	[ProtoMember(1)]
	public int Id { get; set; }

	[ProtoMember(2)]
	public string Content { get; set; }

	[ProtoMember(3)]
	public int Repeat { get; set; }

	public NewsTickerType Type { get; set; }
}
