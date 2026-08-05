using ProtoBuf;

namespace Shift.Legion.ClientApi.Protocol;

[ProtoContract]
public class VerifyIdentityTapTapResponse : IPacketBody
{
	[ProtoMember(1)]
	public bool Result { get; set; }

	[ProtoMember(2)]
	public string VerifyMessage { get; set; }

	[ProtoMember(3)]
	public bool can_play { get; set; }

	[ProtoMember(4)]
	public int code { get; set; }

	[ProtoMember(5)]
	public int cost_time { get; set; }

	[ProtoMember(6)]
	public int remain_time { get; set; }

	[ProtoMember(7)]
	public string tittle { get; set; }

	[ProtoMember(8)]
	public int Verified { get; set; }

	[ProtoMember(9)]
	public string restrict_type { get; set; }

	public int PacketId => PacketIds.USER_VERIFY_IDENTITY_TAPTAP_REQUEST;
}
