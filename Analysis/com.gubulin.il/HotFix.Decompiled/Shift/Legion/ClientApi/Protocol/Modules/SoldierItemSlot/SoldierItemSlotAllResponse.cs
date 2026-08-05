using ProtoBuf;
using Shift.Legion.ClientApi.Protocol.Modules.SoldierItemSlot.Models;

namespace Shift.Legion.ClientApi.Protocol.Modules.SoldierItemSlot;

[ProtoContract]
public class SoldierItemSlotAllResponse : IPacketBody
{
	[ProtoMember(10, TypeName = "Shift.Legion.ClientApi.Protocol.Modules.SoldierItemSlot.Models.SoldiersItemSlots")]
	public SoldiersItemSlots SoldiersItemSlots;

	[ProtoMember(1)]
	public bool Result { get; set; }

	[ProtoMember(999)]
	public int ErrorCode { get; set; }

	public int PacketId => PacketIds.MODULES_SOLDIER_ITEM_SLOT_ALL;
}
