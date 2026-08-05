using ProtoBuf;

namespace Shift.Legion.ClientApi.Protocol.Modules.SoldierItemSlot;

[ProtoContract]
public class SoldierItemSlotAllRequest : IRequestPacket, IPacketBody
{
	[ProtoMember(99)]
	public int MsgIndex { get; set; }

	public int PacketId => PacketIds.MODULES_SOLDIER_ITEM_SLOT_ALL;
}
