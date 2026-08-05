using ProtoBuf;

namespace Shift.Legion.ClientApi.Protocol;

[ProtoContract]
public class NeedRestartResponse : IPacketBody
{
	[ProtoMember(1)]
	public string Tip { get; set; }

	[ProtoMember(2)]
	public bool IsEnforced { get; set; }

	public int PacketId => PacketIds.NEED_RESTART;
}
