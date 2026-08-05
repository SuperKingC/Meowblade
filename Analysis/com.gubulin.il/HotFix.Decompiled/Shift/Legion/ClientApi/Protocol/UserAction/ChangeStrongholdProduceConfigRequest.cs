using ProtoBuf;

namespace Shift.Legion.ClientApi.Protocol.UserAction;

[ProtoContract]
public class ChangeStrongholdProduceConfigRequest : IRequestPacket, IPacketBody
{
	[ProtoMember(1)]
	public long Tick;

	[ProtoMember(2)]
	public string StrongholdId;

	[ProtoMember(3)]
	public string SoldierId;

	[ProtoMember(99)]
	public int MsgIndex { get; set; }

	public int PacketId => PacketIds.USER_ACTION_CHANGE_STRONGHOLD_PRODUCE_CONFIG_REQUEST;
}
