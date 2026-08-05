using ProtoBuf;

namespace Shift.Legion.ClientApi.Protocol.UserAction;

[ProtoContract]
public class MoonBattlePassActivityClaimRequest : IRequestPacket, IPacketBody
{
	[ProtoMember(1)]
	public string ActivityId;

	[ProtoMember(2)]
	public string node;

	[ProtoMember(99)]
	public int MsgIndex { get; set; }

	public int PacketId => PacketIds.USER_ACTION_WEEKLYBATTLEPASS_ACTIVITY_CLAIM_REQUEST;
}
