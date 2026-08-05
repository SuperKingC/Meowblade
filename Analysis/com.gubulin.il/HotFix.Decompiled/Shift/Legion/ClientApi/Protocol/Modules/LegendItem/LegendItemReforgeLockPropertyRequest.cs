using ProtoBuf;

namespace Shift.Legion.ClientApi.Protocol.Modules.LegendItem;

[ProtoContract]
public class LegendItemReforgeLockPropertyRequest : IRequestPacket, IPacketBody
{
	[ProtoMember(99)]
	public int MsgIndex { get; set; }

	[ProtoMember(1)]
	public long InstanceId { get; set; }

	[ProtoMember(2)]
	public int EntryType { get; set; }

	[ProtoMember(3)]
	public int EntryIndex { get; set; }

	public int PacketId => PacketIds.MODULES_LEGEND_ITEM_REFORGE_LOCK_PROPERTY;
}
