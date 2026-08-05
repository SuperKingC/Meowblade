using ProtoBuf;

namespace Shift.Legion.ClientApi.Protocol.Modules.SoldierLegendItem;

[ProtoContract]
public class SoldierEquippedItemsAllRequest : IRequestPacket, IPacketBody
{
	[ProtoMember(99)]
	public int MsgIndex { get; set; }

	public int PacketId => PacketIds.MODULES_SOLDIER_EQUIPPED_ITEMS_ALL;
}
