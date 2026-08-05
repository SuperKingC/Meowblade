using ProtoBuf;

namespace Shift.Legion.ClientApi.Protocol;

[ProtoContract]
public class WarOfRealmSettlementRequest : IRequestPacket, IPacketBody
{
	public int PacketId => PacketIds.USER_ACTION_WAROFREALM_GET_LOTTERYINFO;

	[ProtoMember(99)]
	public int MsgIndex { get; set; }

	[ProtoMember(1)]
	public string ActivityId { get; set; }

	[ProtoMember(2)]
	public int StageStatus { get; set; }
}
