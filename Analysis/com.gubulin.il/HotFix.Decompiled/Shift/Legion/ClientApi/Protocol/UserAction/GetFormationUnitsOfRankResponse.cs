using ProtoBuf;

namespace Shift.Legion.ClientApi.Protocol.UserAction;

[ProtoContract]
public class GetFormationUnitsOfRankResponse : IPacketBody
{
	[ProtoMember(1)]
	public bool Result;

	[ProtoMember(2)]
	public string Message;

	[ProtoMember(3)]
	public string BattleConfig;

	[ProtoMember(4)]
	public string BattleConfigDetail;

	public int PacketId => PacketIds.USER_ACTION_GET_FORMATION_UNITS_OF_RANK_REQUEST;
}
