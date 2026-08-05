using System.Collections.Generic;
using ProtoBuf;

namespace Shift.Legion.ClientApi.Protocol.UserAction;

[ProtoContract]
public class GvGWorldBossStartBattleRequest : IRequestPacket, IPacketBody
{
	[ProtoMember(1)]
	public string WBId;

	[ProtoMember(2)]
	public string FormationId;

	[ProtoMember(3)]
	public List<string> SoldierIds;

	[ProtoMember(4)]
	public string IZId;

	[ProtoMember(99)]
	public int MsgIndex { get; set; }

	public int PacketId => PacketIds.USER_ACTION_GVG_WORLDBOSS_START_BATTLE;
}
