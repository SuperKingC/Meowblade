using System.Collections.Generic;
using ProtoBuf;
using Shift.Legion.ClientApi.Protocol.UserAction;
using Shift.Legion.Helpers;

namespace Shift.Legion.ClientApi.Protocol.Modules.LegendItem;

[ProtoContract]
public class SpecialSelectionBluePrintResponse : IPacketBody
{
	[ProtoMember(1, TypeName = "Shift.Legion.ClientApi.Protocol.UserAction.StockChangeRecord")]
	public List<StockChangeRecord> StockChangeRecords;

	[ProtoMember(4)]
	public string NewBlueprints;

	[ProtoMember(999)]
	public int ErrorCode { get; set; }

	public int PacketId => PacketIds.USER_ACTION_LEGENDITEM_SPECILA_BLUEPRINT_CLAIM;

	public List<string> BlueprintIds => JsonHelper.ToObject<List<string>>(NewBlueprints);
}
