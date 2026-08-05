using ProtoBuf;

namespace Shift.Legion.ClientApi.Protocol.UserAction;

[ProtoContract]
public class SetFormationUnitsOfRankResponse
{
	[ProtoMember(1)]
	public bool Result;

	[ProtoMember(999)]
	public int ErrorCode { get; set; }

	public int PacketId => PacketIds.USER_ACTION_SET_FORMATION_UNITS_OF_RANK_REQUEST;
}
