using System.Collections.Generic;
using ProtoBuf;

namespace Shift.Legion.ClientApi.Protocol.UserAction;

[ProtoContract]
public class LockLegendItemBlueprintResponse : IPacketBody
{
	[ProtoMember(999)]
	public int ErrorCode { get; set; }

	[ProtoMember(1)]
	public List<string> LockedBlueprint { get; set; }

	public int PacketId => PacketIds.USER_ACTION_LEGENDITEM_LOCK;
}
