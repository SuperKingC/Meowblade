using System.Collections.Generic;
using ProtoBuf;

namespace Shift.Legion.ClientApi.Protocol.UserAction;

[ProtoContract]
public class GvGMode2SyncBattleConfigRequest : IRequestPacket, IPacketBody
{
	[ProtoMember(99)]
	public int MsgIndex { get; set; }

	[ProtoMember(1)]
	public List<string> Soldiers { get; set; }

	[ProtoMember(2)]
	public string FormationId { get; set; }

	[ProtoMember(3)]
	public string ShipId { get; set; }

	public int PacketId => PacketIds.USER_ACTION_GVGMODE2_SYNC_BATTLECONFIG;
}
