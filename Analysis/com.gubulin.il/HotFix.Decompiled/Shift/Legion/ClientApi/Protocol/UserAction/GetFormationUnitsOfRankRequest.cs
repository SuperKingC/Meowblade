using ProtoBuf;

namespace Shift.Legion.ClientApi.Protocol.UserAction;

[ProtoContract]
public class GetFormationUnitsOfRankRequest : IRequestPacket
{
	[ProtoMember(1)]
	public long Tick;

	[ProtoMember(2)]
	public int Rank;

	[ProtoMember(99)]
	public int MsgIndex { get; set; }

	public int PacketId => PacketIds.USER_ACTION_GET_FORMATION_UNITS_OF_RANK_REQUEST;
}
