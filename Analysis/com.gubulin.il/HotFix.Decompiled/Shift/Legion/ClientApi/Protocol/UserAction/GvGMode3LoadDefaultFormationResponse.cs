using System.Collections.Generic;
using ProtoBuf;

namespace Shift.Legion.ClientApi.Protocol.UserAction;

[ProtoContract]
public class GvGMode3LoadDefaultFormationResponse : IPacketBody
{
	[ProtoMember(1)]
	public bool Result { get; set; }

	[ProtoMember(999)]
	public int ErrorCode { get; set; }

	[ProtoMember(2)]
	public string FormationId { get; set; }

	[ProtoMember(3)]
	public List<string> Group { get; set; } = new List<string>();

	[ProtoMember(4)]
	public List<string> BackupGroup { get; set; } = new List<string>();

	public int PacketId => PacketIds.USER_ACTION_GVGMODE3_LOAD_DEFAULT_FORMATION;
}
