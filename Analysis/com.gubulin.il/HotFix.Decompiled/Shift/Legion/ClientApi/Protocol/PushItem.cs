using ProtoBuf;

namespace Shift.Legion.ClientApi.Protocol;

[ProtoContract]
public class PushItem
{
	[ProtoMember(1)]
	public int PacketId { get; set; }

	[ProtoMember(2)]
	public string Body { get; set; }
}
