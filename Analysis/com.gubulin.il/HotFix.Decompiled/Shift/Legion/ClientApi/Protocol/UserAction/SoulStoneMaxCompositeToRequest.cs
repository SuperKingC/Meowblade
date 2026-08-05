using ProtoBuf;

namespace Shift.Legion.ClientApi.Protocol.UserAction;

[ProtoContract]
public class SoulStoneMaxCompositeToRequest : IRequestPacket, IPacketBody
{
	[ProtoMember(1)]
	public string SoldierId;

	[ProtoMember(2)]
	public int TargetPotentialLevel;

	[ProtoMember(3)]
	public long Tick;

	[ProtoMember(99)]
	public int MsgIndex { get; set; }

	public int PacketId => PacketIds.USER_ACTION_SOUL_STONE_MAX_COMPOSITE_TO_REQUEST;
}
