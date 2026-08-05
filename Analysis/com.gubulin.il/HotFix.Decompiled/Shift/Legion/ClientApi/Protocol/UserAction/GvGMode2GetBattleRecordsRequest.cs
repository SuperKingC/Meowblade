using ProtoBuf;

namespace Shift.Legion.ClientApi.Protocol.UserAction;

[ProtoContract]
public class GvGMode2GetBattleRecordsRequest : IRequestPacket, IPacketBody
{
	[ProtoMember(99)]
	public int MsgIndex { get; set; }

	[ProtoMember(1)]
	public int IZId { get; set; }

	[ProtoMember(2)]
	public int SummaryId { get; set; }

	public int PacketId => PacketIds.USER_ACTION_GVGMODE2_GET_BATTLE_RECORDS;
}
