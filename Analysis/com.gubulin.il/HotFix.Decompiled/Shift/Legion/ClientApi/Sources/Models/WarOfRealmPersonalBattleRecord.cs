using ProtoBuf;

namespace Shift.Legion.ClientApi.Sources.Models;

[ProtoContract]
public class WarOfRealmPersonalBattleRecord
{
	[ProtoMember(1)]
	public int UserId { get; set; }

	[ProtoMember(2)]
	public int Score { get; set; }

	[ProtoMember(3)]
	public int PlayerOffScore { get; set; }
}
