using System.Collections.Generic;
using ProtoBuf;

namespace Shift.Legion.ClientApi.Protocol.Modules.LegendItem;

[ProtoContract]
public class LegendItemReforgeRequest : IRequestPacket, IPacketBody
{
	[ProtoMember(99)]
	public int MsgIndex { get; set; }

	[ProtoMember(1)]
	public long InstanceId { get; set; }

	[ProtoMember(2)]
	public List<int> LockedSubEntryIndexList { get; set; }

	[ProtoMember(3)]
	public int CostIndex { get; set; }

	[ProtoMember(4)]
	public int LockCostIndex { get; set; }

	public int PacketId => PacketIds.MODULES_LEGEND_ITEM_REFORGE;
}
