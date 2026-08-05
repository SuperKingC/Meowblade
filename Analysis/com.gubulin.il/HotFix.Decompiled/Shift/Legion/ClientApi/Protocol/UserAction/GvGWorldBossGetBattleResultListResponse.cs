using ProtoBuf;

namespace Shift.Legion.ClientApi.Protocol.UserAction;

[ProtoContract]
public class GvGWorldBossGetBattleResultListResponse : IPacketBody
{
	[ProtoMember(1)]
	public bool Result { get; set; }

	[ProtoMember(2)]
	public string Model { get; set; }

	public int PacketId => PacketIds.USER_ACTION_GVG_WORLDBOSS_GET_BATTLE_RESULT_LIST;
}
