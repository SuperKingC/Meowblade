using ProtoBuf;

namespace Shift.Legion.ClientApi.Protocol.UserAction;

[ProtoContract]
public class GetBattleBonusRequest : IRequestPacket, IPacketBody
{
	[ProtoMember(1)]
	public string BattleId;

	[ProtoMember(2)]
	public string CurrentLevelId;

	[ProtoMember(99)]
	public int MsgIndex { get; set; }

	public int PacketId => PacketIds.USER_ACTION_GET_BATTLE_BONUS_REQUEST;
}
