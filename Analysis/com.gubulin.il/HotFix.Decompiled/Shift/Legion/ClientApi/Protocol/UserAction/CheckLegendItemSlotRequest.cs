using System.Collections.Generic;
using ProtoBuf;

namespace Shift.Legion.ClientApi.Protocol.UserAction;

[ProtoContract]
public class CheckLegendItemSlotRequest : IRequestPacket, IPacketBody
{
	[ProtoMember(99)]
	public int MsgIndex { get; set; }

	[ProtoMember(1)]
	public List<string> SoldierId { get; set; }

	public int PacketId => PacketIds.USER_ACTION_CHECK_LEGEND_SLOT;
}
