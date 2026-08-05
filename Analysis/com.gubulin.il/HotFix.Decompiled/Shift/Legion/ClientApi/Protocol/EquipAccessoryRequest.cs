using ProtoBuf;

namespace Shift.Legion.ClientApi.Protocol;

[ProtoContract]
public class EquipAccessoryRequest : IRequestPacket, IPacketBody
{
	[ProtoMember(99)]
	public int MsgIndex { get; set; }

	[ProtoMember(1)]
	public string ItemId { get; set; }

	[ProtoMember(2)]
	public int Type { get; set; }

	public int PacketId => PacketIds.USER_ACTION_EQUIP_ACCESSORY;
}
