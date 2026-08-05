using ProtoBuf;

namespace Shift.Legion.ClientApi.Models;

[ProtoContract]
public class WarRankData
{
	[ProtoMember(1)]
	public int UserId { get; set; }

	[ProtoMember(2)]
	public int Score { get; set; }

	[ProtoMember(3)]
	public int Rank { get; set; }
}
