using ProtoBuf;

namespace Shift.Legion.ClientApi.Protocol.Modules.LegendItem;

[ProtoContract]
public class DrawCardTestRequest : IRequestPacket, IPacketBody
{
	[ProtoMember(99)]
	public int MsgIndex { get; set; }

	[ProtoMember(1)]
	public string ActivityId { get; set; }

	[ProtoMember(2)]
	public int CostOption { get; set; } = 0;

	[ProtoMember(3)]
	public string DrawOption { get; set; }

	[ProtoMember(4)]
	public int Repeat { get; set; } = 1;

	public int PacketId => PacketIds.MODULES_VERIFY_N_VALIDATE_DRAW_CARD_TEST;
}
