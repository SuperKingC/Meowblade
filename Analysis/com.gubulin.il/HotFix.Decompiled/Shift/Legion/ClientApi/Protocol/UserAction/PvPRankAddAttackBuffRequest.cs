using ProtoBuf;

namespace Shift.Legion.ClientApi.Protocol.UserAction;

[ProtoContract]
public class PvPRankAddAttackBuffRequest : IRequestPacket, IPacketBody
{
	[ProtoMember(99)]
	public int MsgIndex { get; set; }

	[ProtoMember(1)]
	public int AddBuffCount { get; set; }

	public int PacketId => PacketIds.USER_ACTION_RANK_ADD_ATTACK_BUFF;
}
