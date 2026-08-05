using System.Collections.Generic;
using ProtoBuf;
using Shift.Legion.GvG.Common.Models;

namespace Shift.Legion.ClientApi.Protocol.UserAction;

[ProtoContract]
public class DrawOuterTechResponse : IPacketBody
{
	[ProtoMember(1, TypeName = "Shift.Legion.GvG.Common.Models.RItem")]
	public List<RItem> DrawResult { get; set; } = new List<RItem>();

	[ProtoMember(3, TypeName = "Shift.Legion.ClientApi.Protocol.UserAction.StockChangeRecord")]
	public StockChangeRecord[] StockChangeRecords { get; set; }

	[ProtoMember(999)]
	public int ErrorCode { get; set; }

	public int PacketId => PacketIds.USER_ACTION_DRAW_OUTERTECH_REQUEST;
}
