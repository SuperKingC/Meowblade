using ProtoBuf;

namespace Shift.Legion.ClientApi.Models;

[ProtoContract]
public class GvGMode3ShipModel
{
	[ProtoMember(1)]
	public string ShipId { get; set; }

	[ProtoMember(2)]
	public GvGMode3ShipPermanentData PermanentData { get; set; } = null;

	[ProtoMember(3)]
	public GvGMode3ShipTemporaryData TemporaryData { get; set; } = null;
}
