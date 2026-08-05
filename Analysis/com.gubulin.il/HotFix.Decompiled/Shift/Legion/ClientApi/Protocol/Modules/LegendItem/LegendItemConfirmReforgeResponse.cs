using ProtoBuf;

namespace Shift.Legion.ClientApi.Protocol.Modules.LegendItem;

[ProtoContract]
public class LegendItemConfirmReforgeResponse : IPacketBody
{
	[ProtoMember(1)]
	public bool Result { get; set; }

	[ProtoMember(999)]
	public int ErrorCode { get; set; }

	[ProtoMember(3)]
	public int NewScore { get; set; }

	[ProtoMember(4)]
	public float NewCombatPowerModifier { get; set; }

	public int PacketId => PacketIds.MODULES_LEGEND_ITEM_CONFIRM_REFORGE;
}
