using ProtoBuf;

namespace Shift.Legion.ClientApi.Protocol;

[ProtoContract]
public class WarOfRealmClaimRankBonusRequest : IRequestPacket, IPacketBody
{
	public int PacketId => PacketIds.USER_ACTION_WAROFREALM_CLAIMRANKBONUS;

	[ProtoMember(99)]
	public int MsgIndex { get; set; }

	[ProtoMember(1)]
	public string ActivityId { get; set; }
}
