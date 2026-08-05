using ProtoBuf;

namespace Shift.Legion.ClientApi.Protocol.Modules.SoldierLegendItem;

[ProtoContract]
public class SoldierWearLegendItemRequest : IRequestPacket, IPacketBody
{
	[ProtoMember(99)]
	public int MsgIndex { get; set; }

	[ProtoMember(1)]
	public string SoldierId { get; set; }

	[ProtoMember(2)]
	public int SlotId { get; set; }

	[ProtoMember(3)]
	public long InstanceId { get; set; }

	public int PacketId => PacketIds.MODULES_SOLDIER_WEAR_LEGEND_ITEM;
}
