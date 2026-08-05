using System.Collections.Generic;
using ProtoBuf;

namespace Shift.Legion.ClientApi.Protocol.UserAction;

[ProtoContract]
public class AssignSoldierToTreasureHuntActivityRequest : IRequestPacket, IPacketBody
{
	[ProtoMember(1)]
	public long Tick;

	[ProtoMember(2)]
	public List<KeyValuePair<string, int>> Soldiers;

	[ProtoMember(99)]
	public int MsgIndex { get; set; }

	public int PacketId => PacketIds.USER_ACTION_ASSIGN_SOLDIER_TO_TREASUREHUNT_ACTIVITY;
}
