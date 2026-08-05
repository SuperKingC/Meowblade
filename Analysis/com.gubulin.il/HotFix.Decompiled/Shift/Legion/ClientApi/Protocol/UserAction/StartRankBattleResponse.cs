using ProtoBuf;

namespace Shift.Legion.ClientApi.Protocol.UserAction;

[ProtoContract]
public class StartRankBattleResponse : IPacketBody
{
	[ProtoMember(1)]
	public bool Result;

	[ProtoMember(2)]
	public long Tick;

	[ProtoMember(3)]
	public string Message;

	[ProtoMember(4)]
	public string BattleId;

	[ProtoMember(999)]
	public int ErrorCode { get; set; }

	public int PacketId => PacketIds.USER_ACTION_START_RANK_BATTLE_REQUEST;
}
