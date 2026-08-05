using System.Collections.Generic;
using ProtoBuf;
using Shift.Legion.ClientApi.Protocol.Store;

namespace Shift.Legion.ClientApi.Protocol.UserAction;

[ProtoContract]
public class GetOuterTechGiftResponse : IPacketBody
{
	[ProtoMember(1, TypeName = "Shift.Legion.ClientApi.Protocol.Store.StoreItem")]
	public List<StoreItem> StoreItems { get; set; }

	[ProtoMember(999)]
	public int ErrorCode { get; set; }

	public int PacketId => PacketIds.USER_ACTION_GET_ACTIVITY_OUTERTECHGIFT_REQUEST;
}
