using ProtoBuf;

namespace Shift.Legion.ClientApi.Protocol.UserAction;

[ProtoContract]
public class StartBattleRequest : IRequestPacket, IPacketBody
{
	[ProtoMember(1)]
	public long Tick;

	[ProtoMember(2)]
	public string LevelId;

	[ProtoMember(4)]
	public string FormationId;

	[ProtoMember(5)]
	public string[] SoldierIds;

	[ProtoMember(6)]
	public int[] Nums;

	[ProtoMember(7)]
	public bool QuickBattle;

	[ProtoMember(99)]
	public int MsgIndex { get; set; }

	public int PacketId => PacketIds.USER_ACTION_START_BATTLE_REQUEST;
}
