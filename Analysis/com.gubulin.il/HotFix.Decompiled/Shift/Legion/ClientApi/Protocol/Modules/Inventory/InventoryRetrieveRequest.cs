using ProtoBuf;

namespace Shift.Legion.ClientApi.Protocol.Modules.Inventory;

[ProtoContract]
public class InventoryRetrieveRequest : IRequestPacket, IPacketBody
{
	[ProtoMember(99)]
	public int MsgIndex { get; set; }

	[ProtoMember(1)]
	public long InstanceId { get; set; }

	public int PacketId => PacketIds.MODULES_INVENTORY_RETRIEVE;
}
