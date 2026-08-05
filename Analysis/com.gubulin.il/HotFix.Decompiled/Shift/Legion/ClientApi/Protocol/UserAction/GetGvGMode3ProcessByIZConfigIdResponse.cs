using System.Collections.Generic;
using ProtoBuf;
using Shift.Legion.GvGServer.Models.Map;

namespace Shift.Legion.ClientApi.Protocol.UserAction;

[ProtoContract]
public class GetGvGMode3ProcessByIZConfigIdResponse : IPacketBody
{
	[ProtoMember(1)]
	public bool Result { get; set; }

	[ProtoMember(999)]
	public int ErrorCode { get; set; }

	[ProtoMember(3, TypeName = "Shift.Legion.GvGServer.Models.Map.GvGProcessInfo")]
	public List<GvGProcessInfo> Processes { get; set; }

	public int PacketId => PacketIds.USER_ACTION_GVGMODE3_GET_PROCESS_BY_IZCONFIGID;
}
