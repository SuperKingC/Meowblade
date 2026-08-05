using ProtoBuf;

namespace Shift.Legion.ClientApi.Protocol.UserAction;

[ProtoContract]
public class GetOuterTechGiftRequest : IRequestPacket, IPacketBody
{
	[ProtoMember(99)]
	public int MsgIndex { get; set; }

	[ProtoMember(1)]
	public string ActivityId { get; set; }

	public int PacketId => PacketIds.USER_ACTION_GET_ACTIVITY_OUTERTECHGIFT_REQUEST;
}
