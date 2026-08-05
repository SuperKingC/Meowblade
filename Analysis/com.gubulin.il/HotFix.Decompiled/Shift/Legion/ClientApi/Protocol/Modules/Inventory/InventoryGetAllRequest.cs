using ProtoBuf;

namespace Shift.Legion.ClientApi.Protocol.Modules.Inventory;

[ProtoContract]
public class InventoryGetAllRequest : IRequestPacket, IPacketBody
{
	[ProtoMember(99)]
	public int MsgIndex { get; set; }

	public int PacketId => PacketIds.MODULES_INVENTORY_GET_ALL;
}
