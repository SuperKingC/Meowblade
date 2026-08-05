using ProtoBuf;

namespace Shift.Legion.ClientApi.Protocol.UserAction;

[ProtoContract]
public class ClaimRecycleRebateRequest : IPacketBody, IRequestPacket
{
	[ProtoMember(1)]
	public long Tick;

	[ProtoMember(2)]
	public int ClaimQty;

	[ProtoMember(99)]
	public int MsgIndex { get; set; }

	public int PacketId => PacketIds.USER_ACTION_CLAIM_RECYCLE_REBATE;
}
