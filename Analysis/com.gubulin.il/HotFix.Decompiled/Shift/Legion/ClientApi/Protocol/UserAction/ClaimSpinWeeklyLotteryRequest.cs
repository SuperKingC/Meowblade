using ProtoBuf;

namespace Shift.Legion.ClientApi.Protocol.UserAction;

[ProtoContract]
public class ClaimSpinWeeklyLotteryRequest : IRequestPacket, IPacketBody
{
	[ProtoMember(99)]
	public int MsgIndex { get; set; }

	[ProtoMember(1)]
	public int Day { get; set; }

	[ProtoMember(2)]
	public bool Free { get; set; }

	public int PacketId => PacketIds.USER_ACTION_CLAIM_SPINWEEKLYLOTTERY_REQUEST;
}
