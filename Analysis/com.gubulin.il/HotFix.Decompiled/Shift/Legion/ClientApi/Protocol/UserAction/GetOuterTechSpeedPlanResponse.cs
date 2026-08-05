using ProtoBuf;

namespace Shift.Legion.ClientApi.Protocol.UserAction;

[ProtoContract]
public class GetOuterTechSpeedPlanResponse : IPacketBody
{
	[ProtoMember(999)]
	public int ErrorCode { get; set; }

	[ProtoMember(1)]
	public int TotalCount { get; set; }

	[ProtoMember(2)]
	public int ClaimedCount { get; set; }

	[ProtoMember(3)]
	public bool Claimed { get; set; }

	[ProtoMember(4)]
	public int CouldClaimCount { get; set; }

	[ProtoMember(6)]
	public int NextClaimCount { get; set; }

	[ProtoMember(7)]
	public int GiftPurchaseLimit { get; set; }

	[ProtoMember(8)]
	public int TotalGvGCount { get; set; }

	public int PacketId => PacketIds.USER_ACTION_GET_OUTERTECH_SPEEDPLAN;
}
