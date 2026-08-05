using System.Collections.Generic;
using ProtoBuf;

namespace Shift.Legion.ClientApi.Protocol.UserAction;

[ProtoContract]
public class GvGMode3ClaimSettlementRequest : IRequestPacket, IPacketBody
{
	[ProtoMember(1)]
	public int IZId;

	[ProtoMember(2)]
	public List<int> RewardType;

	[ProtoMember(99)]
	public int MsgIndex { get; set; }

	public int PacketId => PacketIds.USER_ACTION_GVGMODE3_CALIM_SETTLEMENT;
}
