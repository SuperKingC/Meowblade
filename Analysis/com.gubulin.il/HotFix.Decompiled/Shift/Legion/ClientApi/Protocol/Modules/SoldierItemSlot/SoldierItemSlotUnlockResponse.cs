using ProtoBuf;
using Shift.Legion.ClientApi.Models;
using Shift.Legion.ClientApi.Protocol.UserAction;

namespace Shift.Legion.ClientApi.Protocol.Modules.SoldierItemSlot;

[ProtoContract]
public class SoldierItemSlotUnlockResponse : IPacketBody
{
	[ProtoMember(1)]
	public bool Result { get; set; }

	[ProtoMember(999)]
	public int ErrorCode { get; set; }

	[ProtoMember(10, TypeName = "Shift.Legion.ClientApi.Models.ResourceRequirement")]
	public ResourceRequirement[] ResourceRequirements { get; set; }

	[ProtoMember(11, TypeName = "Shift.Legion.ClientApi.Protocol.UserAction.StockChangeRecord")]
	public StockChangeRecord[] Costs { get; set; }

	public int PacketId => PacketIds.MODULES_SOLDIER_ITEM_SLOT_UNLOCK;
}
