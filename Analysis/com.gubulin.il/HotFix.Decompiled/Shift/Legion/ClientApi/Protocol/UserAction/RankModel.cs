using ProtoBuf;

namespace Shift.Legion.ClientApi.Protocol.UserAction;

[ProtoContract]
public class RankModel
{
	[ProtoMember(1)]
	public int UserId { get; set; }

	[ProtoMember(2)]
	public string TotalDamage { get; set; }
}
