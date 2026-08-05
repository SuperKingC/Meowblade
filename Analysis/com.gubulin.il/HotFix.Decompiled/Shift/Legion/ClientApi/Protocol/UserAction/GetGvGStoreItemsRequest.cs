using ProtoBuf;

namespace Shift.Legion.ClientApi.Protocol.UserAction;

[ProtoContract]
public class GetGvGStoreItemsRequest : IRequestPacket, IPacketBody
{
	[ProtoMember(99)]
	public int MsgIndex { get; set; }

	[ProtoMember(1)]
	public bool Manual { get; set; }

	public int PacketId => PacketIds.USER_ACTION_GET_GVG_STORE_ITEMS;
}
