using ProtoBuf;

namespace Shift.Legion.ClientApi.Protocol.UserAction;

[ProtoContract]
public class GvGWorldBossRecordRanking2Response : IPacketBody
{
	[ProtoMember(1)]
	public bool Result { get; set; }

	[ProtoMember(2)]
	public WBRankingModel Model { get; set; }

	[ProtoMember(3)]
	public string SelfDamage { get; set; }

	[ProtoMember(4)]
	public int SelfRank { get; set; }

	[ProtoMember(5)]
	public int TotalRank { get; set; }

	[ProtoMember(6)]
	public int LastRefreshTimestamp { get; set; }

	public int PacketId => PacketIds.USER_ACTION_GVG_WORLDBOSS_RECORD_RANKING2;
}
