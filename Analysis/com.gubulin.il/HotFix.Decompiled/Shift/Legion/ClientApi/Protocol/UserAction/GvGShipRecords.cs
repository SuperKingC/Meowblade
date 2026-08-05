using System.Collections.Generic;
using ProtoBuf;

namespace Shift.Legion.ClientApi.Protocol.UserAction;

[ProtoContract]
public class GvGShipRecords
{
	[ProtoMember(1)]
	public int RecordId { get; set; }

	[ProtoMember(2, TypeName = "Shift.Legion.ClientApi.Protocol.UserAction.GvGShipRecord")]
	public List<GvGShipRecord> ShipRecords { get; set; }

	[ProtoMember(3)]
	public int CreatedTime { get; set; }

	[ProtoMember(4)]
	public string TotalDamage { get; set; }

	[ProtoMember(5)]
	public string ShipId { get; set; }
}
