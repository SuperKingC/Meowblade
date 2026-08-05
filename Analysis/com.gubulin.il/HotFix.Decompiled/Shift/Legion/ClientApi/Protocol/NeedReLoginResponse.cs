using ProtoBuf;

namespace Shift.Legion.ClientApi.Protocol;

[ProtoContract]
public class NeedReLoginResponse : IPacketBody
{
	[ProtoMember(1)]
	public string Tip { get; set; }

	public int PacketId => PacketIds.NEED_RE_LOGIN;
}
