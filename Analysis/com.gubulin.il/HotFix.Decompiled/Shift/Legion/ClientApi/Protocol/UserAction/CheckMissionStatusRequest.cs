using ProtoBuf;

namespace Shift.Legion.ClientApi.Protocol.UserAction;

[ProtoContract]
public class CheckMissionStatusRequest : IRequestPacket, IPacketBody
{
	[ProtoMember(99)]
	public int MsgIndex { get; set; }

	[ProtoMember(1)]
	public string MissionId { get; set; }

	[ProtoMember(2)]
	public int MissionStatus { get; set; }

	public int PacketId => PacketIds.USER_ACTION_CHECK_MISSION_STATUS_REQUEST;
}
