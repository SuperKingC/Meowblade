using ProtoBuf;

namespace Shift.Legion.ClientApi.Protocol.UserAction;

[ProtoContract]
public class GetShadowDemonActivityRequest : IRequestPacket, IPacketBody
{
	[ProtoMember(1)]
	public string ActivityId;

	[ProtoMember(99)]
	public int MsgIndex { get; set; }

	public int PacketId => PacketIds.USER_ACTION_GET_SHADOWDEMONACTIVITY;
}
