using ProtoBuf;

namespace Shift.Legion.ClientApi.Protocol.UserAction;

[ProtoContract]
public class GetFormationInfoRequest : IRequestPacket, IPacketBody
{
	[ProtoMember(1)]
	public long Tick;

	[ProtoMember(99)]
	public int MsgIndex { get; set; }

	[ProtoMember(2)]
	public string LevelId { get; set; }

	public int PacketId => PacketIds.USER_ACTION_GET_FORMATION_INFO_REQUEST;
}
