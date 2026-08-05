using System.Collections.Generic;
using ProtoBuf;
using Shift.Legion.ClientApi.Models;

namespace Shift.Legion.ClientApi.Protocol.UserAction;

[ProtoContract]
public class DrawRecallWelfareResponse : IPacketBody
{
	[ProtoMember(999)]
	public int ErrorCode { get; set; }

	[ProtoMember(1, TypeName = "Shift.Legion.ClientApi.Models.ERItem")]
	public List<ERItem> DrawResult { get; set; } = new List<ERItem>();

	[ProtoMember(2, TypeName = "Shift.Legion.ClientApi.Protocol.UserAction.StockChangeRecord")]
	public List<StockChangeRecord> StockChangeRecords { get; set; } = new List<StockChangeRecord>();

	[ProtoMember(3)]
	public int TotalScore { get; set; }

	public int PacketId => PacketIds.USER_ACTION_DRAW_RECALLWELFARE_REQUEST;
}
