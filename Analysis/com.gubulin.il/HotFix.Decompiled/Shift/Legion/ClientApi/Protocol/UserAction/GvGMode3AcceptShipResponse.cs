using ProtoBuf;

namespace Shift.Legion.ClientApi.Protocol.UserAction;

[ProtoContract]
public class GvGMode3AcceptShipResponse : IPacketBody
{
	[ProtoMember(1)]
	public bool Result { get; set; }

	[ProtoMember(999)]
	public int ErrorCode { get; set; }

	[ProtoMember(2)]
	public string jsonGvGMode3Record { get; set; }

	public int PacketId => PacketIds.USER_ACTION_GVGMODE3_ACCEPT_SHIP;
}
