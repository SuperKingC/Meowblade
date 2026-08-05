using ProtoBuf;

namespace Shift.Legion.ClientApi.Protocol.UserAction;

[ProtoContract]
public class SetFormationUnitsOfRankRequest : IRequestPacket, IPacketBody
{
	[ProtoMember(1)]
	public long Tick;

	[ProtoMember(2)]
	public int Rank;

	[ProtoMember(3)]
	public string FormationsId;

	[ProtoMember(4)]
	public string UnitsId;

	[ProtoMember(99)]
	public int MsgIndex { get; set; }

	public int PacketId => PacketIds.USER_ACTION_SET_FORMATION_UNITS_OF_RANK_REQUEST;
}
