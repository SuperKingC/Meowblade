using ProtoBuf;

namespace Shift.Legion.ClientApi.Protocol.UserAction;

[ProtoContract]
public class ClaimIslandComeAgainDailyMissionBonusRequest : IRequestPacket, IPacketBody
{
	public int PacketId => PacketIds.USER_ACTION_DYNAMIC_ACTIVITY_ISLAND_COME_AGAIN_CLAIM_MISSIONBONUS_REQUEST;

	[ProtoMember(99)]
	public int MsgIndex { get; set; }

	[ProtoMember(1)]
	public int MissionId { get; set; }
}
