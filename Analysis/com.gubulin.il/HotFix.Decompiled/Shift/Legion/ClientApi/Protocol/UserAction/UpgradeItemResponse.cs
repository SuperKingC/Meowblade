using ProtoBuf;

namespace Shift.Legion.ClientApi.Protocol.UserAction;

[ProtoContract]
public class UpgradeItemResponse : IPacketBody
{
	[ProtoMember(1)]
	public bool Result;

	[ProtoMember(3)]
	public long Tick;

	[ProtoMember(999)]
	public int ErrorCode { get; set; }

	public int PacketId => PacketIds.USER_ACTION_UPGRADE_ITEM_REQUEST;
}
