using ProtoBuf;

namespace Shift.Legion.ClientApi.Protocol.Modules.LegendItem;

[ProtoContract]
public class LegendItemReforgeLockPropertyResponse : IPacketBody
{
	[ProtoMember(1)]
	public bool Result { get; set; }

	[ProtoMember(2)]
	public string Message { get; set; }

	public int PacketId => PacketIds.MODULES_LEGEND_ITEM_REFORGE_LOCK_PROPERTY;
}
