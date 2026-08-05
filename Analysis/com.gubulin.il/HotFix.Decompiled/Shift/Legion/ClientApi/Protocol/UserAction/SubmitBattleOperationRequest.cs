using ProtoBuf;

namespace Shift.Legion.ClientApi.Protocol.UserAction;

[ProtoContract]
public class SubmitBattleOperationRequest : IRequestPacket, IPacketBody
{
	[ProtoMember(1)]
	public long Tick;

	[ProtoMember(2)]
	public string BattleId;

	[ProtoMember(3)]
	public int SubLevelIndex;

	[ProtoMember(4)]
	public string FormationId;

	[ProtoMember(5)]
	public string[] Units;

	[ProtoMember(99)]
	public int MsgIndex { get; set; }

	public int PacketId => PacketIds.USER_ACTION_SUBMIT_BATTLE_OPERATION_REQUEST;
}
