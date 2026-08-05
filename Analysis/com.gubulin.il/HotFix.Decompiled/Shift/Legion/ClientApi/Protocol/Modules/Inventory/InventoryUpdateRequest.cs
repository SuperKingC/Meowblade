using ProtoBuf;
using Shift.Legion.ClientApi.Protocol.Modules.Inventory.Models;

namespace Shift.Legion.ClientApi.Protocol.Modules.Inventory;

[ProtoContract]
public class InventoryUpdateRequest : IRequestPacket, IPacketBody
{
	[ProtoMember(99)]
	public int MsgIndex { get; set; }

	[ProtoMember(1)]
	public InventoryLog InventoryLog { get; set; }

	public int PacketId => PacketIds.MODULES_INVENTORY_UPDATE;
}
