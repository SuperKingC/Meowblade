using ProtoBuf;

namespace Shift.Legion.ClientApi.Protocol.UserAction;

[ProtoContract]
public class SyncDailyMissionScoreResponse : IPacketBody
{
	[ProtoMember(999)]
	public int ErrorCode { get; set; }

	[ProtoMember(1)]
	public int Score { get; set; }

	public int PacketId => PacketIds.USER_ACTION_SYNC_DAILY_MISSION_SCORE;
}
