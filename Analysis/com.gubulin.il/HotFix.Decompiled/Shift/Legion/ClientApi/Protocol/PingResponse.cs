using System.Collections.Generic;
using ProtoBuf;

namespace Shift.Legion.ClientApi.Protocol;

[ProtoContract]
public class PingResponse : IPacketBody
{
	[ProtoMember(1)]
	public int Id { get; set; }

	[ProtoMember(2, TypeName = "Shift.Legion.ClientApi.Protocol.PushItem")]
	public List<PushItem> PushItems { get; set; }

	public int PacketId => PacketIds.USER_PING;
}
