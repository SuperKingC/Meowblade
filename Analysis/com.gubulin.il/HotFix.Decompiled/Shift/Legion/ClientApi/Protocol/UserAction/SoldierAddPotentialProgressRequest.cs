using ProtoBuf;

namespace Shift.Legion.ClientApi.Protocol.UserAction;

[ProtoContract]
public class SoldierAddPotentialProgressRequest : IRequestPacket, IPacketBody
{
	[ProtoMember(1)]
	public long Tick;

	[ProtoMember(2)]
	public string SoldierId;

	[ProtoMember(3)]
	public int Position;

	[ProtoMember(4)]
	public int Num;

	[ProtoMember(99)]
	public int MsgIndex { get; set; }

	public int PacketId => PacketIds.USER_ACTION_SOLDIER_ADD_POTENTIAL_PROGRESS_REQUEST;
}
