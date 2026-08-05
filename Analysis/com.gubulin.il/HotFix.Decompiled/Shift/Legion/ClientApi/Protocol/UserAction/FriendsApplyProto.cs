using ProtoBuf;

namespace Shift.Legion.ClientApi.Protocol.UserAction;

[ProtoContract]
public class FriendsApplyProto
{
	[ProtoMember(1)]
	public int Id { get; set; }

	[ProtoMember(2)]
	public int UserId { get; set; }

	[ProtoMember(4)]
	public int FromUserId { get; set; }

	[ProtoMember(5)]
	public int FromLevel { get; set; }

	[ProtoMember(6)]
	public int FromMaxCombatPower { get; set; }
}
