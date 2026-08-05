using System.Collections.Generic;
using ProtoBuf;

namespace Shift.Legion.ClientApi.Protocol.UserAction;

[ProtoContract]
public class SyncFormationUnitsRequest : IRequestPacket, IPacketBody
{
	[ProtoMember(1)]
	public long Tick;

	[ProtoMember(2)]
	public string Context;

	[ProtoMember(3)]
	public string Mode;

	[ProtoMember(4)]
	public List<string> UnitsId;

	[ProtoMember(99)]
	public int MsgIndex { get; set; }

	public int PacketId => PacketIds.USER_ACTION_SYNC_FORMATION_UNITS_REQUEST;
}
