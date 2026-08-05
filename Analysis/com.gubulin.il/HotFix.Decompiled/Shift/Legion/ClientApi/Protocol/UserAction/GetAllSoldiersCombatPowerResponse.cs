using ProtoBuf;

namespace Shift.Legion.ClientApi.Protocol.UserAction;

[ProtoContract]
public class GetAllSoldiersCombatPowerResponse : IPacketBody
{
	[ProtoMember(1)]
	public long Tick;

	[ProtoMember(2)]
	public bool Result;

	[ProtoMember(999)]
	public int ErrorCode { get; set; }

	[ProtoMember(4)]
	public string AllSoldiersCombatPower { get; set; }

	public int PacketId => PacketIds.USER_ACTION_GET_ALL_SOLDIERS_COMBAT_POWER;
}
