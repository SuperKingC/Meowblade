using ProtoBuf;

namespace Shift.Legion.ClientApi.Protocol.UserAction;

[ProtoContract]
public class GetSelfRecycleStatsRequest : IPacketBody, IRequestPacket
{
	[ProtoMember(1)]
	public long Tick;

	[ProtoMember(2)]
	public string Message;

	[ProtoMember(99)]
	public int MsgIndex { get; set; }

	public int PacketId => PacketIds.USER_ACTION_GET_SELF_RECYCLE_STATS;
}
