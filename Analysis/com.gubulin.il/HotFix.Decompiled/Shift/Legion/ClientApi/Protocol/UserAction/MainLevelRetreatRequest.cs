using ProtoBuf;

namespace Shift.Legion.ClientApi.Protocol.UserAction;

[ProtoContract]
public class MainLevelRetreatRequest : IRequestPacket, IPacketBody
{
	[ProtoMember(1)]
	public string BattleId;

	[ProtoMember(99)]
	public int MsgIndex { get; set; }

	public int PacketId => PacketIds.USER_ACTION_MAIN_LEVEL_RETREAT_REQUEST;
}
