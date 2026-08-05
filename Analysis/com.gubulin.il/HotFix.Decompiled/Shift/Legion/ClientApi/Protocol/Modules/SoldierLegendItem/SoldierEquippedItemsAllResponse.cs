using ProtoBuf;
using Shift.Legion.ClientApi.Protocol.Modules.SoldierLegendItem.Models;

namespace Shift.Legion.ClientApi.Protocol.Modules.SoldierLegendItem;

[ProtoContract]
public class SoldierEquippedItemsAllResponse : IPacketBody
{
	[ProtoMember(10, TypeName = "Shift.Legion.ClientApi.Protocol.Modules.SoldierLegendItem.Models.SoldiersEquippedItems")]
	public SoldiersEquippedItems SoldiersEquippedItems;

	[ProtoMember(1)]
	public bool Result { get; set; }

	[ProtoMember(2)]
	public string Message { get; set; }

	public int PacketId => PacketIds.MODULES_SOLDIER_EQUIPPED_ITEMS_ALL;
}
