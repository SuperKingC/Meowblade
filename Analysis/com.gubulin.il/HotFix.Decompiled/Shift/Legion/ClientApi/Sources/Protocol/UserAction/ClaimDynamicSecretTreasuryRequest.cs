using ProtoBuf;
using Shift.Legion.ClientApi.Protocol;

namespace Shift.Legion.ClientApi.Sources.Protocol.UserAction;

[ProtoContract]
public class ClaimDynamicSecretTreasuryRequest : IPacketBody, IRequestPacket
{
	[ProtoMember(99)]
	public int MsgIndex { get; set; }

	[ProtoMember(1)]
	public int Level { get; set; }

	public int PacketId => PacketIds.USER_ACTION_CLAIM_ACTIVITY_SECRETTREASURY_RECHARGE_BONUS_REQUEST;
}
