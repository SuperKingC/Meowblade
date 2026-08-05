using ProtoBuf;
using Shift.Legion.ClientApi.Protocol.Store;

namespace Shift.Legion.ClientApi.Protocol.UserAction;

[ProtoContract]
public class GetShadowDemonActivityResponse : IPacketBody
{
	[ProtoMember(1, TypeName = "Shift.Legion.ClientApi.Protocol.Store.StoreItem")]
	public StoreItem[] StoreItems;

	[ProtoMember(999)]
	public int ErrorCode { get; set; }

	public int PacketId => PacketIds.USER_ACTION_GET_SHADOWDEMONACTIVITY;
}
