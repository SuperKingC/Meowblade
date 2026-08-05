using ProtoBuf;
using Shift.Legion.ClientApi.Models;

namespace Shift.Legion.ClientApi.Protocol.UserAction;

[ProtoContract]
public class SetTreasureHuntBattlePresetFormationRequest : IRequestPacket, IPacketBody
{
	[ProtoMember(1, TypeName = "Shift.Legion.ClientApi.Models.TreasureHuntBattleFormationConfig")]
	public TreasureHuntBattleFormationConfig Formation;

	[ProtoMember(99)]
	public int MsgIndex { get; set; }

	public int PacketId => PacketIds.USER_ACTION_SET_TREASUREHUNT_ACTIVITY_PRESET_FORMATIONS;
}
