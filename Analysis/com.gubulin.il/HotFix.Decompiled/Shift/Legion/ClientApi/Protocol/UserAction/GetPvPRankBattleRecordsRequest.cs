using ProtoBuf;

namespace Shift.Legion.ClientApi.Protocol.UserAction;

[ProtoContract]
public class GetPvPRankBattleRecordsRequest : IRequestPacket, IPacketBody
{
	[ProtoMember(99)]
	public int MsgIndex { get; set; }

	[ProtoMember(1)]
	public long Tick { get; set; }

	[ProtoMember(2)]
	public int Offset { get; set; }

	[ProtoMember(3)]
	public int CutOffAt { get; set; }

	public int PacketId => PacketIds.USER_ACTION_GET_PVP_RANK_BATTLE_RECORDS_REQUEST;
}
