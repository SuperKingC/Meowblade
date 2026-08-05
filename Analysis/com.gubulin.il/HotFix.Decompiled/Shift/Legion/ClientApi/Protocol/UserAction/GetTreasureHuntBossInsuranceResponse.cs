using ProtoBuf;

namespace Shift.Legion.ClientApi.Protocol.UserAction;

[ProtoContract]
public class GetTreasureHuntBossInsuranceResponse : IPacketBody
{
	[ProtoMember(1)]
	public long Tick;

	[ProtoMember(2)]
	public bool Result;

	[ProtoMember(4)]
	public float BossLootInsuranceProgressDisplay;

	[ProtoMember(5)]
	public int BossLootHighLight;

	[ProtoMember(999)]
	public int ErrorCode { get; set; }

	public int PacketId => PacketIds.USER_ACTION_GET_TREASUREHUNT_BOSS_INSURANCE;
}
