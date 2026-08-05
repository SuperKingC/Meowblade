using ProtoBuf;

namespace Shift.Legion.ClientApi.Protocol.UserAction;

[ProtoContract]
public class SignInClaimResponse : IPacketBody
{
	[ProtoMember(1)]
	public long Tick;

	[ProtoMember(2)]
	public bool Result;

	[ProtoMember(4)]
	public int TotalSignIn;

	[ProtoMember(6)]
	public bool DynamicActivityCanSignIn;

	[ProtoMember(7)]
	public string DynamicActivityProgress;

	[ProtoMember(999)]
	public int ErrorCode { get; set; }

	public int PacketId => PacketIds.USER_ACTION_SIGN_IN_CLAIM_REQUEST;
}
