using ProtoBuf;

namespace Shift.Legion.ClientApi.Protocol.UserAction;

[ProtoContract]
public class ClaimRecallWelfareBonusRequest : IPacketBody, IRequestPacket
{
	[ProtoMember(99)]
	public int MsgIndex { get; set; }

	[ProtoMember(1)]
	public string MissionId { get; set; }

	public int PacketId => PacketIds.USER_ACTION_CLAIM_RECALLWELFARE_REQUEST;
}
