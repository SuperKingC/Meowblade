using ProtoBuf;
using Shift.Legion.ClientApi.Protocol.Modules.Inventory.Models;

namespace Shift.Legion.ClientApi.Protocol.Modules.Inventory;

[ProtoContract]
public class InventoryRetrieveResponse : IPacketBody
{
	[ProtoMember(1)]
	public bool Result { get; set; }

	[ProtoMember(2)]
	public InventoryItem Item { get; set; }

	public int PacketId => PacketIds.MODULES_INVENTORY_RETRIEVE;
}
