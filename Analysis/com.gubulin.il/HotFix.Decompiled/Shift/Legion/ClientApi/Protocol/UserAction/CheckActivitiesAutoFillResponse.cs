using System.Collections.Generic;
using ProtoBuf;

namespace Shift.Legion.ClientApi.Protocol.UserAction;

[ProtoContract]
public class CheckActivitiesAutoFillResponse : IPacketBody
{
	[ProtoMember(1)]
	public long Tick;

	[ProtoMember(2)]
	public bool Result;

	[ProtoMember(3)]
	public string Message;

	[ProtoMember(4)]
	public int DeltaTime;

	[ProtoMember(5)]
	public Dictionary<string, int> ActivitiesNeedAutoFill;

	public int PacketId => PacketIds.USER_ACTION_CHECK_ACTIVITIES_AUTO_FILL_REQUEST;
}
