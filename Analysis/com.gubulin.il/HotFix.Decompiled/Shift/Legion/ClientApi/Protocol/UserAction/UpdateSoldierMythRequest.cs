using ProtoBuf;

namespace Shift.Legion.ClientApi.Protocol.UserAction;

[ProtoContract]
public class UpdateSoldierMythRequest : IRequestPacket, IPacketBody
{
	[ProtoMember(99)]
	public int MsgIndex { get; set; }

	[ProtoMember(1)]
	public string SoldierId { get; set; }

	[ProtoMember(2)]
	public int Level { get; set; }

	public int PacketId => PacketIds.USER_ACTION_UPDATE_SOLDIER_MYTH;
}
