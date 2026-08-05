using ProtoBuf;

namespace Shift.Legion.ClientApi.Protocol.UserAction;

[ProtoContract]
public class CheckBattleFailedProcessRequest : IRequestPacket, IPacketBody
{
	[ProtoMember(1)]
	public long Tick;

	[ProtoMember(2)]
	public string BattleId;

	[ProtoMember(4)]
	public string CurrentLevelId;

	[ProtoMember(99)]
	public int MsgIndex { get; set; }

	public int PacketId => PacketIds.USER_ACTION_CHECK_BATTLE_FAIL_PROCESS;
}
