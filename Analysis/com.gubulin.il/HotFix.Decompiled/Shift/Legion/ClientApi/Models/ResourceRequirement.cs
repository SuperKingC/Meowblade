using ProtoBuf;

namespace Shift.Legion.ClientApi.Models;

[ProtoContract]
public class ResourceRequirement
{
	[ProtoMember(1)]
	public string ItemId;

	[ProtoMember(2)]
	public int Qty;
}
