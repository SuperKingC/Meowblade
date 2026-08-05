using ProtoBuf;

namespace Shift.Legion.ClientApi.Protocol.UserAction;

[ProtoContract]
public class SyncWeeklyMissionScoreResponse : IPacketBody
{
	[ProtoMember(1)]
	public long Tick;

	[ProtoMember(2)]
	public bool Result;

	[ProtoMember(3)]
	public string Message;

	[ProtoMember(4)]
	public int Score;

	public int PacketId => PacketIds.USER_ACTION_SYNC_WEEKLY_MISSION_SCORE;
}
