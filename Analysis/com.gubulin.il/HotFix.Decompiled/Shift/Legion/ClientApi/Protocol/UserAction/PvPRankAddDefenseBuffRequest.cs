using ProtoBuf;

namespace Shift.Legion.ClientApi.Protocol.UserAction;

[ProtoContract]
public class PvPRankAddDefenseBuffRequest : IRequestPacket, IPacketBody
{
	[ProtoMember(99)]
	public int MsgIndex { get; set; }

	[ProtoMember(1)]
	public int AddTime { get; set; }

	public int PacketId => PacketIds.USER_ACTION_RANK_ADD_DEFENSE_BUFF;
}
