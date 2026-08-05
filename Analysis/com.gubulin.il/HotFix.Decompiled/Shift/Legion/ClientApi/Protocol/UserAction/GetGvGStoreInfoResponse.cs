using ProtoBuf;

namespace Shift.Legion.ClientApi.Protocol.UserAction;

[ProtoContract]
public class GetGvGStoreInfoResponse : IPacketBody
{
	[ProtoMember(99)]
	public bool Result { get; set; }

	[ProtoMember(999)]
	public int ErrorCode { get; set; }

	[ProtoMember(1)]
	public bool HasAttended { get; set; }

	[ProtoMember(2)]
	public int NotSilentTimestamp { get; set; }

	[ProtoMember(3)]
	public int RemainingExchangeableRefreshCount { get; set; }

	[ProtoMember(4)]
	public int ActivateMode { get; set; }

	public int PacketId => PacketIds.USER_ACTION_GET_GVG_STORE_INFO;
}
