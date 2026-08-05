using ProtoBuf;
using Shift.Legion.ClientApi.Models;

namespace Shift.Legion.ClientApi.Protocol.UserAction;

[ProtoContract]
public class GetTreasureHuntBattlePresetFormationResponse : IPacketBody
{
	[ProtoMember(1)]
	public bool Result;

	public string Message;

	[ProtoMember(3, TypeName = "Shift.Legion.ClientApi.Models.TreasureHuntBattleFormationConfig")]
	public TreasureHuntBattleFormationConfig CurFormation;

	[ProtoMember(999)]
	public int ErrorCode { get; set; }

	public int PacketId => PacketIds.USER_ACTION_GET_TREASUREHUNT_ACTIVITY_PRESET_FORMATIONS;
}
