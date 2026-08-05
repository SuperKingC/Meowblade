using ProtoBuf;

namespace Shift.Legion.ClientApi.Protocol.UserAction;

[ProtoContract]
public class MainLevelRetreatResponse : IPacketBody
{
	[ProtoMember(1)]
	public bool Result;

	[ProtoMember(999)]
	public int ErrorCode { get; set; }

	public int PacketId => PacketIds.USER_ACTION_MAIN_LEVEL_RETREAT_REQUEST;
}
