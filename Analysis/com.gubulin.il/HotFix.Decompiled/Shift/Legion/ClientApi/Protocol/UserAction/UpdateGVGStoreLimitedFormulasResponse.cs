using System.Collections.Generic;
using ProtoBuf;

namespace Shift.Legion.ClientApi.Protocol.UserAction;

[ProtoContract]
public class UpdateGVGStoreLimitedFormulasResponse : IPacketBody
{
	[ProtoMember(99)]
	public bool Result { get; set; }

	[ProtoMember(999)]
	public int ErrorCode { get; set; }

	[ProtoMember(1)]
	public List<string> CurFormulas { get; set; }

	[ProtoMember(2)]
	public int NextUpdateTime { get; set; }

	public int PacketId => PacketIds.USER_ACTION_GET_GVG_STORE_LIMITED_FORMULAS;
}
