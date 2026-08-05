using ProtoBuf;

namespace Shift.Legion.ClientApi.Protocol.UserAction;

[ProtoContract]
public class DawankaBonusClaimRecord
{
	[ProtoMember(1)]
	public int Level { get; set; }

	[ProtoMember(2)]
	public int ClaimedTs { get; set; }

	[ProtoMember(3)]
	public bool UsingCard { get; set; }
}
