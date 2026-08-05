using ProtoBuf;

namespace Shift.Legion.ClientApi.Models;

[ProtoContract]
public class AcquiredRecord
{
	[ProtoMember(1)]
	public long Ts;

	[ProtoMember(2)]
	public string StockContext;

	[ProtoMember(3)]
	public string Mark;
}
