using System.Collections.Generic;
using ProtoBuf;

namespace Shift.Legion.ClientApi.Protocol.UserAction;

[ProtoContract]
public class GetFormationInfoResponse : IPacketBody
{
	[ProtoMember(1)]
	public bool Result;

	[ProtoMember(3)]
	public long Tick;

	[ProtoMember(4)]
	public string FormationId;

	[ProtoMember(5)]
	public List<string> UnitsId;

	[ProtoMember(999)]
	public int ErrorCode { get; set; }

	public int PacketId => PacketIds.USER_ACTION_GET_FORMATION_INFO_REQUEST;
}
