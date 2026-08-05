using ProtoBuf;
using Shift.Legion.ClientApi.Models;

namespace Shift.Legion.ClientApi.Protocol;

[ProtoContract]
public class WarOfRealmReplayResponse : IPacketBody
{
	[ProtoMember(1)]
	public LevelBattleReplay Replay;

	public int PacketId => PacketIds.USER_ACTION_WAROFREALM_REPLAY_REQUEST;

	[ProtoMember(999)]
	public int ErrorCode { get; set; }
}
