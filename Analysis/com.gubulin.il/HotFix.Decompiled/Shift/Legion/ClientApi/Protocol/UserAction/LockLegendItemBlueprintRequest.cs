using ProtoBuf;

namespace Shift.Legion.ClientApi.Protocol.UserAction;

[ProtoContract]
public class LockLegendItemBlueprintRequest : IRequestPacket, IPacketBody
{
	[ProtoMember(99)]
	public int MsgIndex { get; set; }

	[ProtoMember(1)]
	public string BlueprintId { get; set; }

	[ProtoMember(2)]
	public bool Lock { get; set; }

	public int PacketId => PacketIds.USER_ACTION_LEGENDITEM_LOCK;
}
