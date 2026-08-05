using ProtoBuf;

namespace Shift.Legion.ClientApi.Protocol.Modules.SoldierItemSlot;

[ProtoContract]
public class SoldierItemSlotUnlockRequest : IRequestPacket, IPacketBody
{
	[ProtoMember(99)]
	public int MsgIndex { get; set; }

	[ProtoMember(1)]
	public string SoldierId { get; set; }

	[ProtoMember(2)]
	public int SlotId { get; set; }

	public int PacketId => PacketIds.MODULES_SOLDIER_ITEM_SLOT_UNLOCK;
}
