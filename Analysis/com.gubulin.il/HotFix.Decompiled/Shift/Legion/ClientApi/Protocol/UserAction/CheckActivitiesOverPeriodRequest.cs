using System.Collections.Generic;
using ProtoBuf;

namespace Shift.Legion.ClientApi.Protocol.UserAction;

[ProtoContract]
public class CheckActivitiesOverPeriodRequest : IRequestPacket, IPacketBody
{
	[ProtoMember(1)]
	public long Tick;

	[ProtoMember(2)]
	public List<string> ActivityIds = new List<string>();

	[ProtoMember(3)]
	public List<int> ActivityTypes = new List<int>();

	[ProtoMember(99)]
	public int MsgIndex { get; set; }

	public int PacketId => PacketIds.USER_ACTION_CHECK_ACTIVITIES_OVER_PERIOD_REQUEST;
}
