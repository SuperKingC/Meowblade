using ProtoBuf;

namespace Shift.Legion.ClientApi.Protocol.Modules.LegendItemEnhancement;

[ProtoContract]
public class LegendItemEnhancementSwitchMainRequest : IRequestPacket, IPacketBody
{
	[ProtoMember(99)]
	public int MsgIndex { get; set; }

	[ProtoMember(1)]
	public long InstanceId { get; set; }

	[ProtoMember(2)]
	public string EntryId { get; set; }

	public int PacketId => PacketIds.MODULES_LEGEND_ITEM_SWITCHMAIN;
}
