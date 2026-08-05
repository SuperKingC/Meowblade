using ProtoBuf;

namespace Shift.Legion.ClientApi.Protocol;

[ProtoContract]
public class WarOfRealmReplayRequest : IRequestPacket, IPacketBody
{
	public int PacketId => PacketIds.USER_ACTION_WAROFREALM_REPLAY_REQUEST;

	[ProtoMember(99)]
	public int MsgIndex { get; set; }

	[ProtoMember(1)]
	public string BattleId { get; set; }
}
