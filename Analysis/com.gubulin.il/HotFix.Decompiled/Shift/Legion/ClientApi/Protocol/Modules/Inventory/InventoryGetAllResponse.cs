using System.Collections.Generic;
using ProtoBuf;
using Shift.Legion.ClientApi.Protocol.Modules.Inventory.Models;

namespace Shift.Legion.ClientApi.Protocol.Modules.Inventory;

[ProtoContract]
public class InventoryGetAllResponse : IPacketBody
{
	[ProtoMember(1)]
	public bool Result { get; set; }

	[ProtoMember(2, TypeName = "Shift.Legion.ClientApi.Protocol.Modules.Inventory.Models.InventoryItem")]
	public List<InventoryItem> Items { get; set; }

	public int PacketId => PacketIds.MODULES_INVENTORY_GET_ALL;
}
