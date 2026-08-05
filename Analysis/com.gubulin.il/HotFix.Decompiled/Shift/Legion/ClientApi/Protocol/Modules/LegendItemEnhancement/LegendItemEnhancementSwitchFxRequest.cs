using ProtoBuf;

namespace Shift.Legion.ClientApi.Protocol.Modules.LegendItemEnhancement;

[ProtoContract]
public class LegendItemEnhancementSwitchFxRequest : IRequestPacket, IPacketBody
{
	[ProtoMember(99)]
	public int MsgIndex { get; set; }

	[ProtoMember(1)]
	public long InstanceId { get; set; }

	[ProtoMember(2)]
	public int FxIndex { get; set; }

	public int PacketId => PacketIds.MODULES_LEGEND_ITEM_SWITCHFX;
}
