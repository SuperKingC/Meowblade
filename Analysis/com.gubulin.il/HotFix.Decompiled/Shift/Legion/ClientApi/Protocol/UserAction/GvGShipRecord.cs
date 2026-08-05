using ProtoBuf;

namespace Shift.Legion.ClientApi.Protocol.UserAction;

[ProtoContract]
public class GvGShipRecord
{
	[ProtoMember(1)]
	public string BattleId { get; set; }

	[ProtoMember(2)]
	public int RedUserId { get; set; }

	[ProtoMember(3)]
	public int BlueUserId { get; set; }

	[ProtoMember(4)]
	public int Winner { get; set; }

	[ProtoMember(5)]
	public string TotalDamage { get; set; }

	[ProtoMember(6)]
	public string WBId { get; set; }

	[ProtoMember(7)]
	public int Timestamp { get; set; }
}
