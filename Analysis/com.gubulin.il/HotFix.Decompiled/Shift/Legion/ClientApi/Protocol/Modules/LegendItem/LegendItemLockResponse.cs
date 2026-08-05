using ProtoBuf;

namespace Shift.Legion.ClientApi.Protocol.Modules.LegendItem;

[ProtoContract]
public class LegendItemLockResponse : IPacketBody
{
	[ProtoMember(1)]
	public bool Result { get; set; }

	[ProtoMember(999)]
	public int ErrorCode { get; set; }

	[ProtoMember(3)]
	public bool LockStatus { get; set; }

	public int PacketId => PacketIds.MODULES_LEGEND_ITEM_LOCK;
}
