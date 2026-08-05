using System.Collections.Generic;
using ProtoBuf;
using Shift.Legion.ClientApi.Protocol;
using Shift.Legion.ClientApi.Protocol.UserAction;

namespace Shift.Legion.ClientApi.Sources.UserAction;

[ProtoContract]
public class SplitBlueprintResponse : IPacketBody
{
	[ProtoMember(999)]
	public int ErrorCode { get; set; }

	[ProtoMember(1)]
	public List<StockChangeRecord> StockChangeRecords { get; set; }

	public int PacketId => PacketIds.USER_ACTION_SPLITBLUEPRINT_REQUEST;
}
