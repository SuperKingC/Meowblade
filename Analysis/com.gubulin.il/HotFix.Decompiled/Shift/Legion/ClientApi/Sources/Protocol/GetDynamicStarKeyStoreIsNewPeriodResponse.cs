using ProtoBuf;
using Shift.Legion.ClientApi.Protocol;

namespace Shift.Legion.ClientApi.Sources.Protocol;

[ProtoContract]
public class GetDynamicStarKeyStoreIsNewPeriodResponse : IPacketBody
{
	[ProtoMember(1)]
	public bool IsNew { get; set; }

	[ProtoMember(2)]
	public bool IsActive { get; set; }

	[ProtoMember(999)]
	public int ErrorCode { get; set; }

	public int PacketId => PacketIds.USER_ACTION_GET_ACTIVITY_STARTKEYSTORENEWPERIOD_REQUEST;
}
