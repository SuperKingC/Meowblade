using ProtoBuf;

namespace Shift.Legion.ClientApi.Protocol.UserAction;

[ProtoContract]
public class GetDynamicIslandComeAgainRewardRequest : IRequestPacket, IPacketBody
{
	[ProtoMember(1)]
	public long Tick;

	[ProtoMember(2)]
	public int PrizePoolId;

	[ProtoMember(3)]
	public int PrizePoolIndex;

	[ProtoMember(99)]
	public int MsgIndex { get; set; }

	public int PacketId => PacketIds.USER_ACTION_GET_DYNAMIC_ACTIVITY_ISLAND_COME_AGAIN_CLAIM_REQUEST;
}
