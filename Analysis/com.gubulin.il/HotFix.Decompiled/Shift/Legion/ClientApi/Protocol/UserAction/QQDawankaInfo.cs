using ProtoBuf;

namespace Shift.Legion.ClientApi.Protocol.UserAction;

[ProtoContract]
public class QQDawankaInfo
{
	[ProtoMember(1)]
	public int Score { get; set; } = 0;

	[ProtoMember(2)]
	public int Level { get; set; } = 0;

	[ProtoMember(3)]
	public int Discount { get; set; } = 0;

	[ProtoMember(4)]
	public int PayReturnCount { get; set; } = 0;

	[ProtoMember(5)]
	public bool IsUsingCard { get; set; } = false;

	[ProtoMember(6)]
	public int RealLevel { get; set; } = 0;

	[ProtoMember(7)]
	public long CardExpireTs { get; set; }
}
