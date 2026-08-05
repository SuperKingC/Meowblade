using System.Collections.Generic;
using ProtoBuf;

namespace Shift.Legion.ClientApi.Protocol.UserAction;

[ProtoContract]
public class GvGGetShipRecordsResponse : IPacketBody
{
	[ProtoMember(1)]
	public bool Result { get; set; }

	[ProtoMember(2, TypeName = "Shift.Legion.ClientApi.Protocol.UserAction.GvGShipRecords")]
	public List<GvGShipRecords> Records { get; set; }

	[ProtoMember(3)]
	public int RecordsLength { get; set; }

	[ProtoMember(4)]
	public string EnvStr { get; set; }

	public int PacketId => PacketIds.USER_ACTION_GVG_GET_SHIP_RECORDS;
}
