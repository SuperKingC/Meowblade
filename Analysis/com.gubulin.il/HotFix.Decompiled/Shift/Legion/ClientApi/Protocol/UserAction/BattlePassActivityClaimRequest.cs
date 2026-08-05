using ProtoBuf;

namespace Shift.Legion.ClientApi.Protocol.UserAction;

[ProtoContract]
public class BattlePassActivityClaimRequest : IRequestPacket, IPacketBody
{
	[ProtoMember(1)]
	public string ActivityId;

	[ProtoMember(2)]
	public string node;

	[ProtoMember(99)]
	public int MsgIndex { get; set; }

	public int PacketId => PacketIds.USER_ACTION_BATTLEPASS_ACTIVITY_CLAIM_REQUEST;
}
