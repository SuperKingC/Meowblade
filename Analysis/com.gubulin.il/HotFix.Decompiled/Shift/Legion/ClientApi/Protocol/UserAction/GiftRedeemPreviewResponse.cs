using System.Collections.Generic;
using ProtoBuf;

namespace Shift.Legion.ClientApi.Protocol.UserAction;

[ProtoContract]
public class GiftRedeemPreviewResponse : IPacketBody
{
	[ProtoMember(1)]
	public long Tick;

	[ProtoMember(2)]
	public bool Result;

	[ProtoMember(999)]
	public int ErrorCode { get; set; }

	[ProtoMember(3)]
	public Dictionary<string, int> Bonuses { get; set; }

	public int PacketId => PacketIds.USER_ACTION_GIFT_REDEEM_PREVIEW;
}
