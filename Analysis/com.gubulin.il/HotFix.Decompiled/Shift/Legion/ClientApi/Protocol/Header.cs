using ProtoBuf;

namespace Shift.Legion.ClientApi.Protocol;

[ProtoContract]
public class Header
{
	[ProtoMember(1)]
	public int PacketId { get; set; }

	[ProtoMember(3)]
	public int Token { get; set; }

	[ProtoMember(4)]
	public int Size { get; set; }
}
