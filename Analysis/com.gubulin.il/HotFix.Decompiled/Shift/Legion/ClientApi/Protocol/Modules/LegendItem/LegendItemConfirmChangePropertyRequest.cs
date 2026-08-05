using ProtoBuf;

namespace Shift.Legion.ClientApi.Protocol.Modules.LegendItem;

[ProtoContract]
public class LegendItemConfirmChangePropertyRequest : IRequestPacket, IPacketBody
{
	[ProtoMember(99)]
	public int MsgIndex { get; set; }

	[ProtoMember(1)]
	public long InstanceId { get; set; }

	[ProtoMember(2)]
	public int EntryIndex { get; set; }

	[ProtoMember(3)]
	public int EntryType { get; set; }

	[ProtoMember(4)]
	public bool Confirm { get; set; }

	public int PacketId => PacketIds.MODULES_LEGEND_ITEM_CONFIRM_CHANGE_PROPERTY;
}
