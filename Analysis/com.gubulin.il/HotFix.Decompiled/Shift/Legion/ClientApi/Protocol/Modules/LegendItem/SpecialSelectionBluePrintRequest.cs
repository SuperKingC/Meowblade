using ProtoBuf;

namespace Shift.Legion.ClientApi.Protocol.Modules.LegendItem;

[ProtoContract]
public class SpecialSelectionBluePrintRequest : IRequestPacket, IPacketBody
{
	[ProtoMember(99)]
	public int MsgIndex { get; set; }

	[ProtoMember(1)]
	public string Main { get; set; }

	[ProtoMember(3)]
	public string NewFxEntry { get; set; }

	[ProtoMember(5)]
	public string SetAliaPool { get; set; }

	[ProtoMember(7)]
	public int Index { get; set; }

	public int PacketId => PacketIds.USER_ACTION_LEGENDITEM_SPECILA_BLUEPRINT_CLAIM;
}
