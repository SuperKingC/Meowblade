using ProtoBuf;

namespace Shift.Legion.ClientApi.Models;

[ProtoContract]
public class WarLottery
{
	[ProtoMember(1)]
	public int UserId { get; set; }

	[ProtoMember(2)]
	public int Amount { get; set; }
}
