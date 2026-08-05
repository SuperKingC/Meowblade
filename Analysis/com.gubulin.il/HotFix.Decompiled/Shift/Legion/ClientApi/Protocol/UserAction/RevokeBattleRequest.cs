using ProtoBuf;

namespace Shift.Legion.ClientApi.Protocol.UserAction;

[ProtoContract]
public class RevokeBattleRequest : IRequestPacket, IPacketBody
{
	[ProtoMember(10)]
	public string BattleId;

	[ProtoMember(99)]
	public int MsgIndex { get; set; }

	public int PacketId => PacketIds.USER_ACTION_REVOKE_BATTLE_REQUEST;
}
