using System.Collections.Generic;
using ProtoBuf;

namespace Shift.Legion.ClientApi.Protocol.UserAction;

[ProtoContract]
public class GvGMode2CreateShipSummaryRequest : IRequestPacket, IPacketBody
{
	[ProtoMember(99)]
	public int MsgIndex { get; set; }

	[ProtoMember(1)]
	public List<string> Soldiers { get; set; }

	[ProtoMember(2)]
	public string FormationId { get; set; }

	public int PacketId => PacketIds.USER_ACTION_GVGMODE2_CREATE_SHIP_SUMMARY;
}
