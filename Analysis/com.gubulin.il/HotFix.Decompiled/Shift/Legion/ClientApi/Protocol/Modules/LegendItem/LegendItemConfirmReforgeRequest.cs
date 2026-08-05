using ProtoBuf;

namespace Shift.Legion.ClientApi.Protocol.Modules.LegendItem;

[ProtoContract]
public class LegendItemConfirmReforgeRequest : IRequestPacket, IPacketBody
{
	[ProtoMember(99)]
	public int MsgIndex { get; set; }

	[ProtoMember(1)]
	public long InstanceId { get; set; }

	[ProtoMember(2)]
	public bool Confirm { get; set; }

	public int PacketId => PacketIds.MODULES_LEGEND_ITEM_CONFIRM_REFORGE;
}
