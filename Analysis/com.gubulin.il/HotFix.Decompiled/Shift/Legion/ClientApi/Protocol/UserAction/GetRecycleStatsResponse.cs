using System.Collections.Generic;
using ProtoBuf;
using Shift.Legion.ClientApi.Sources.Protocol;

namespace Shift.Legion.ClientApi.Protocol.UserAction;

[ProtoContract]
public class GetRecycleStatsResponse : IPacketBody
{
	[ProtoMember(1)]
	public long Tick;

	[ProtoMember(2)]
	public bool Result;

	[ProtoMember(3)]
	public string Message;

	[ProtoMember(4, TypeName = "Shift.Legion.ClientApi.Sources.Protocol.RecycleDailyProduceStat")]
	public List<RecycleDailyProduceStat> RecycleStats;

	public int PacketId => PacketIds.USER_ACTION_GET_RECYCLE_STATS;
}
