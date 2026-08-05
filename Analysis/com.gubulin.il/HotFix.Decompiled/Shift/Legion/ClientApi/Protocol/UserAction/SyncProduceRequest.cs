using ProtoBuf;

namespace Shift.Legion.ClientApi.Protocol.UserAction;

[ProtoContract]
public class SyncProduceRequest : IRequestPacket, IPacketBody
{
	[ProtoMember(99)]
	public int MsgIndex { get; set; }

	[ProtoMember(1)]
	public long Tick { get; set; }

	[ProtoMember(2)]
	public bool GetAllProduceStates { get; set; }

	public int PacketId => PacketIds.USER_ACTION_SYNC_PRODUCE_REQUEST;
}
